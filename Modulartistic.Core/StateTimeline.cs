﻿using System;
using System.Collections.Generic;
using System.Linq;
using AnimatedGif;
using System.IO;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FFMpegCore.Extensions.SkiaSharp;
using FFMpegCore.Pipes;
using FFMpegCore;
using FFMpegCore.Enums;

namespace Modulartistic.Core
{
    /// <summary>
    /// StateTimeline consisting of a BaseStates and several timed StateEvents
    /// </summary>
    public class StateTimeline
    {
        #region properties
        /// <summary>
        /// The Name of this StateTimeline
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Length in Milliseconds
        /// </summary>
        public uint Length { get; set; }
        
        /// <summary>
        /// Base State
        /// </summary>
        public State Base { get; set; }

        /// <summary>
        /// List of StateEvents with their start Timings (in Milliseconds)
        /// </summary>
        public List<StateEvent> Events { get; set; }
        #endregion

        #region constructors
        /// <summary>
        /// Creates an Empty StateTimeline
        /// </summary>
        public StateTimeline()
        {
            Name = "";
            Length = 0;
            Base = new State();
            Events = new List<StateEvent>();
        }

        /// <summary>
        /// Creates an Empty StateTimeline
        /// </summary>
        /// <param name="name">The name of the TimeLine</param>
        public StateTimeline(string name)
        {
            Name = name;
            Length = 0;
            Base = new State();
            Events = new List<StateEvent>();
        }
        #endregion

        #region methods
        public int TotalFrameCount(uint framerate)
        {
            return (int)(framerate * Length / 1000);
        }

        public double LengthInSeconds()
        {
            return Length / 1000;
        }
        #endregion

        #region Methods for animation Creation
        private IEnumerable<IVideoFrame> EnumerateFrames(GenerationArgs args, int max_threads)
        {
            // parses GenerationArgs
            uint framerate = args.Framerate.GetValueOrDefault(Constants.FRAMERATE_DEFAULT);

            // loops through the frames
            List<StateEvent> activeEvents = new List<StateEvent>();
            ulong frames = framerate * Length / 1000;
            for (uint i = 0; i < frames; i++)
            {
                // Get Time in Seconds and milliseconds
                double second = Convert.ToDouble(i) / Convert.ToDouble(framerate);
                uint time = Convert.ToUInt32(second * 1000);

                // Add events triggered on this tick to active events
                while (Events.Count > 0 && Events[0].StartTime <= time)
                {
                    activeEvents.Add(Events[0]);
                    Events.RemoveAt(0);
                }

                // Make a list with all current states of the active events
                List<State> states = new List<State>();
                for (int j = 0; j < activeEvents.Count; j++)
                {
                    StateEvent se = activeEvents[j];
                    uint activationTime = se.StartTime;

                    if (!se.IsActive(time)) { activeEvents.RemoveAt(j); }
                    states.Add(se.CurrentState(time, Base));
                }

                // Somehow combine all states into one single state
                State FrameState = new State();
                for (StateProperty j = 0; j <= StateProperty.i9; j++)
                {
                    FrameState[j] = (Base[j] + states.Sum(state => state[j])) / (states.Count + 1);
                }

                // Create Image of state
                FrameState.Name = "Frame_" + i.ToString().PadLeft(frames.ToString().Length, '0');
                if (max_threads == 0 || max_threads == 1) { yield return new BitmapVideoFrameWrapper(FrameState.GetBitmap(args, 1)); }
                else { yield return new BitmapVideoFrameWrapper(FrameState.GetBitmap(args, max_threads)); }
            }
        }
        
        public async Task<string> GenerateAnimation(GenerationArgs args, int max_threads, AnimationType type, bool keepframes, string out_dir)
        {
            // If out-dir is empty set to default, then check if it exists
            out_dir = out_dir == "" ? Constants.OUTPUTFOLDER : out_dir;
            if (!Directory.Exists(out_dir)) { throw new DirectoryNotFoundException("The Directory " + out_dir + " was not found."); }

            // set the absolute path for the file to be save
            string file_path_out = Path.Join(out_dir, (Name == "" ? Constants.STATETIMELINE_NAME_DEFAULT : Name));
            // Validate (if file with same name exists already, append index)
            file_path_out = Helper.ValidFileName(file_path_out);

            // parse framerate from GenerationArgs
            uint framerate = args.Framerate.GetValueOrDefault(Constants.FRAMERATE_DEFAULT);

            // Order Events
            Events = Events.OrderBy((a) => a.StartTime).ToList();

            // set Length if Length == 0
            if (Length == 0)
            {
                Length = Events.Max(x => x.StartTime + x.Length + x.ReleaseTime) + 500;
            }

            switch (type)
            {
                case AnimationType.None:
                    {
                        throw new Exception("No AnimationType was specified. ");
                    }
                case AnimationType.Gif:
                    {
                        if (keepframes)
                        {
                            string folder = GenerateFrames(args, max_threads, file_path_out);
                            CreateGif(framerate, folder);
                        }
                        else
                        {
                            await CreateGif(args, max_threads, file_path_out);
                        }
                        return file_path_out + @".gif";
                    }
                case AnimationType.Mp4:
                    {
                        if (keepframes)
                        {
                            string folder = GenerateFrames(args, max_threads, file_path_out);
                            CreateMp4(framerate, folder);
                        }
                        else
                        {
                            await CreateMp4(args, max_threads, file_path_out);
                        }
                        return file_path_out + @".mp4";
                    }
                default:
                    {
                        throw new Exception("Unrecognized AnimationType");
                    }
            }
        }

        private async Task CreateMp4(GenerationArgs args, int max_threads, string absolute_out_filepath)
        {
            // parsing framerate and setting piping source
            uint framerate = args.Framerate.GetValueOrDefault(Constants.FRAMERATE_DEFAULT);
            var videoFramesSource = new RawVideoPipeSource(EnumerateFrames(args, max_threads))
            {
                FrameRate = framerate, // set source frame rate
            };

            // parsing size
            System.Drawing.Size size = new System.Drawing.Size(args.Size[0], args.Size[1]);

            // generate the mp4 file
            try
            {
                await FFMpegArguments
                .FromPipeInput(videoFramesSource)
                .OutputToFile(absolute_out_filepath + @".mp4", false, options => options
                    .WithVideoCodec(VideoCodec.LibX265)
                    .WithVideoBitrate(16000) // find a balance between quality and file size
                    .WithFramerate(framerate))
                .ProcessAsynchronously();
            }
            catch (Exception e)
            {
                throw new Exception("Error generating animation. ", e);
            }
        }

        private async Task CreateGif(GenerationArgs args, int max_threads, string absolute_out_filepath)
        {
            // parsing framerate and setting piping source
            uint framerate = args.Framerate.GetValueOrDefault(Constants.FRAMERATE_DEFAULT);
            var videoFramesSource = new RawVideoPipeSource(EnumerateFrames(args, max_threads))
            {
                FrameRate = framerate, // set source frame rate
            };

            // parsing size
            System.Drawing.Size size = new System.Drawing.Size(args.Size[0], args.Size[1]);

            // generate the gif file
            try
            {
                await FFMpegArguments
                .FromPipeInput(videoFramesSource)
                .OutputToFile(absolute_out_filepath + @".gif", false, options => options
                    .WithGifPaletteArgument(0, size, (int)framerate)
                    .WithFramerate(framerate))
                .ProcessAsynchronously();
            }
            catch (Exception e)
            {
                throw new Exception("Error generating animation. ", e);
            }
        }

        private string GenerateFrames(GenerationArgs args, int max_threads, string out_dir)
        {
            // parses GenerationArgs
            uint framerate = args.Framerate.GetValueOrDefault(Constants.FRAMERATE_DEFAULT);

            // create Directory for frames if not exist
            if (!Directory.Exists(out_dir)) { Directory.CreateDirectory(out_dir); }

            // Order Events
            Events = Events.OrderBy((a) => a.StartTime).ToList();

            // set Length if Length == 0
            if (Length == 0)
            {
                Length = Events.Max(x => x.StartTime + x.Length + x.ReleaseTime) + 500;
            }

            List<StateEvent> activeEvents = new List<StateEvent>();

            // iterate over all frames
            ulong frames = framerate * Length / 1000;
            for (uint i = 0; i < frames; i++)
            {
                // Get Time in Seconds and milliseconds
                double second = Convert.ToDouble(i) / Convert.ToDouble(framerate);
                uint time = Convert.ToUInt32(second * 1000);

                // Add events triggered on this tick to active events
                while (Events.Count > 0 && Events[0].StartTime <= time)
                {
                    activeEvents.Add(Events[0]);
                    Events.RemoveAt(0);
                }

                // Make a list with all current states of the active events
                List<State> states = new List<State>();
                for (int j = 0; j < activeEvents.Count; j++)
                {
                    StateEvent se = activeEvents[j];
                    uint activationTime = se.StartTime;

                    if (!se.IsActive(time)) { activeEvents.RemoveAt(j); }
                    states.Add(se.CurrentState(time, Base));
                }

                // Somehow combine all states into one single state
                State FrameState = new State();

                for (StateProperty j = StateProperty.Mod; j <= StateProperty.i9; j++)
                {
                    FrameState[j] = (Base[j] + states.Sum(state => state[j])) / (states.Count + 1);
                }

                // Create Image of state
                FrameState.Name = "Frame_" + i.ToString().PadLeft(frames.ToString().Length, '0');
                FrameState.GenerateImage(args, max_threads, out_dir);
            }

            return out_dir;
        }

        /// <summary>
        /// Create Animation after having generated all frames beforehand and save as gif
        /// </summary>
        /// <param name="framerate">The framerate</param>
        /// <param name="folder">The absolute path to folder where the generated Scenes are</param>
        private void CreateGif(double framerate, string folder)
        {
            // Creating the image list
            List<string> imgPaths = Directory.GetFiles(folder).ToList();
            // create gif
            FFMpeg.JoinImageSequence(folder + @".gif", frameRate: framerate, imgPaths.ToArray());
        }

        /// <summary>
        /// Create Animation after having generated all frames beforehand and save as mp4
        /// </summary>
        /// <param name="framerate">The framerate</param>
        /// <param name="folder">The absolute path to folder where the generated Scenes are</param>
        private void CreateMp4(double framerate, string folder)
        {
            // Creating the image list
            List<string> imgPaths = Directory.GetFiles(folder).ToList();
            // create mp4
            FFMpeg.JoinImageSequence(folder + @".mp4", frameRate: framerate, imgPaths.ToArray());
        }
        #endregion
    }

    /// <summary>
    /// The StateEvent with Envelope Properties
    /// </summary>
    public class StateEvent
    {
        #region Properties
        // All times in milliseconds!
        
        /// <summary>
        /// StartTime of Event in Milliseconds
        /// </summary>
        public uint StartTime { get; set; }

        /// <summary>
        /// Length of Event in Milliseconds
        /// </summary>
        public uint Length { get; set; }

        /// <summary>
        /// AttackTime in Milliseconds
        /// </summary>
        public uint AttackTime { get; set; }
        /// <summary>
        /// Easing Function the Attack uses
        /// </summary>
        [JsonIgnore]
        public Easing AttackEasing { get; set; }
        public string AttackEasingType { get => AttackEasing.Type; set => AttackEasing = Easing.FromString(value); }
        /// <summary>
        /// DecayTime in Millisecond
        /// </summary>
        public uint DecayTime { get; set; }
        /// <summary>
        /// Easing Function the Decay uses
        /// </summary>
        [JsonIgnore]
        public Easing DecayEasing { get; set; }
        public string DecayEasingType { get => DecayEasing.Type; set => DecayEasing = Easing.FromString(value); }
        /// <summary>
        /// ReleaseTime in Milliseconds
        /// </summary>
        public uint ReleaseTime { get; set; }
        /// <summary>
        /// Easing Function the Release uses
        /// </summary>
        [JsonIgnore]
        public Easing ReleaseEasing { get; set; }
        public string ReleaseEasingType { get => ReleaseEasing.Type; set => ReleaseEasing = Easing.FromString(value); }

        /// <summary>
        /// Dictionary of Peak Values
        /// </summary>
        public Dictionary<StateProperty, double> PeakValues { get; set; }
        /// <summary>
        /// Dictionary of Susatain Values
        /// </summary>
        public Dictionary<StateProperty, double> SustainValues { get; set; }
        #endregion

        /// <summary>
        /// Creates a Standard StateEvent
        /// </summary>
        public StateEvent()
        {
            PeakValues = new Dictionary<StateProperty, double>();
            SustainValues = new Dictionary<StateProperty, double>();

            StartTime = 0; 
            Length = 0;
            AttackTime = 0;
            AttackEasing = Easing.Linear();
            DecayTime = 0;
            DecayEasing = Easing.Linear();
            ReleaseTime = 0;
            ReleaseEasing = Easing.Linear();
        }

        /// <summary>
        /// Gets the Current State of this StateEvent
        /// </summary>
        /// <param name="currentTime">The Current Time (in Milliseconds)</param>
        /// <param name="BaseState">The BaseState</param>
        /// <returns>State</returns>
        /// <exception cref="Exception">if Activation Time is before Current time</exception>
        public State CurrentState(uint currentTime, State BaseState)
        {
            long t_active = currentTime - StartTime;
            if (t_active < 0) { throw new Exception(); }

            State result = new State();
            // Attack
            if (t_active < AttackTime)
            {
                Easing easing = AttackEasing;
                for (StateProperty i = 0; i < StateProperty.i9; i++)
                {
                    if (!PeakValues.ContainsKey(i)) { result[i] = BaseState[i]; }
                    else { result[i] = easing.Ease(BaseState[i], PeakValues[i], Convert.ToInt32(t_active / 2), Convert.ToInt32(AttackTime / 2)); }
                }
            }
            // Decay
            else if (t_active < AttackTime + DecayTime)
            {
                Easing easing = DecayEasing;
                for (StateProperty i = 0; i < StateProperty.i9; i++)
                {
                    if (!SustainValues.ContainsKey(i) && !PeakValues.ContainsKey(i))
                    {
                        result[i] = BaseState[i];
                    }
                    else
                    {
                        result[i] = easing.Ease(
                            PeakValues.ContainsKey(i) ? PeakValues[i] : BaseState[i],
                            SustainValues.ContainsKey(i) ? SustainValues[i] : BaseState[i],
                            Convert.ToInt32((t_active - AttackTime) / 2),
                            Convert.ToInt32(DecayTime / 2));
                    }
                }
            }
            // Sustain
            else if (t_active < AttackTime + Length + DecayTime)
            {
                for (StateProperty i = 0; i < StateProperty.i9; i++)
                {
                    result[i] = SustainValues.ContainsKey(i) ? SustainValues[i] : BaseState[i];
                }
            }
            // Release
            else if (t_active < AttackTime + Length + DecayTime + ReleaseTime)
            {
                Easing easing = ReleaseEasing;
                for (StateProperty i = 0; i < StateProperty.i9; i++)
                {
                    if (!SustainValues.ContainsKey(i) && !PeakValues.ContainsKey(i)) { result[i] = BaseState[i]; }
                    else
                    {
                        result[i] = easing.Ease(
                            SustainValues.ContainsKey(i) ? SustainValues[i] : PeakValues[i],
                            BaseState[i],
                            Convert.ToInt32((t_active - AttackTime - Length - DecayTime) / 2),
                            Convert.ToInt32(ReleaseTime / 2));
                    }
                }
            }
            else
            {
                for (StateProperty i = 0; i < StateProperty.i9; i++)
                {
                    result[i] = BaseState[i];
                }
            }

            return result;
        }

        /// <summary>
        /// Whether this StateEvent is still Active
        /// </summary>
        /// <param name="currentTime">The Current Time</param>
        /// <returns>bool</returns>
        /// <exception cref="Exception">If Activation Time is after Current Time</exception>
        public bool IsActive(uint currentTime)
        {
            long t_active = currentTime - StartTime;
            if (t_active < 0) { return false; }

            if (t_active >= AttackTime + Length + DecayTime + ReleaseTime) { return false; }
            else { return true; }
        }
    }
}
