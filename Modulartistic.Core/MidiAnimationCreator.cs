﻿using System;
using System.Collections.Generic;
using System.Linq;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using NCalc;
using System.IO;
using Melanchall.DryWetMidi.Common;

namespace Modulartistic.Core
{
    public class MidiAnimationCreator
    {
        public static StateTimeline CreateStateTimeline(string midi_path, StateTimelineTemplate template)
        {
            if (!File.Exists(midi_path)) { throw new FileNotFoundException("The file " + midi_path + "was not found. "); }
            
            var midiFile = MidiFile.Read(midi_path);
            TempoMap tmpMap = midiFile.GetTempoMap();

            StateTimeline timeline = new StateTimeline();
            timeline.Length = (uint)((TimeSpan)(MetricTimeSpan)midiFile.GetDuration(TimeSpanType.Metric)).TotalMilliseconds;

            // Debugging
            // Console.WriteLine(((TimeSpan)(MetricTimeSpan)midiFile.GetDuration(TimeSpanType.Metric)).ToString());

            if (!template.OrderAndValidate()) { throw new Exception("For each channel only 1 EventType must be given"); }


            Console.WriteLine("The Template defines EventTypes for following Channels: ");
            foreach (StateEventType eventType in template.Events) { Console.Write($"{eventType.Channel} "); }
            
            Console.WriteLine("\nThe Midi file uses following Channels: ");
            foreach (FourBitNumber channel in midiFile.GetChannels()) { Console.Write($"{channel} "); }
            Console.WriteLine();

            timeline.Base = template.Base;
            List<Note> notes = midiFile.GetNotes().ToList();
            foreach (StateEventType eventType in template.Events)
            {
                for (int i = 0; i < notes.Count;  i++)
                {
                    Note note = notes[i];

                    if (note.Channel == eventType.Channel)
                    {
                        Dictionary<string, double> mappings = new Dictionary<string, double>()
                        {
                            { "Length", ((TimeSpan)(MetricTimeSpan)note.LengthAs(TimeSpanType.Metric, tmpMap)).TotalMilliseconds},
                            { "NoteNumber", note.NoteNumber },
                            { "Octave", note.Octave },
                            { "Velocity", note.Velocity },
                            { "OffVelocity", note.OffVelocity },
                            { "StartTime", ((TimeSpan)(MetricTimeSpan)note.TimeAs(TimeSpanType.Metric, tmpMap)).TotalMilliseconds },
                            { "EndTime", ((TimeSpan)(MetricTimeSpan)note.EndTimeAs(TimeSpanType.Metric, tmpMap)).TotalMilliseconds }
                        };

                        StateEvent SE = new StateEvent();
                        SE.AttackTime = eventType.AttackTime;
                        SE.DecayTime = eventType.DecayTime;
                        SE.ReleaseTime = eventType.ReleaseTime;
                        SE.AttackEasingType = eventType.AttackEasingType;
                        SE.DecayEasingType = eventType.DecayEasingType; ;
                        SE.ReleaseEasingType = eventType.ReleaseEasingType;
                        SE.Length = (uint)((TimeSpan)(MetricTimeSpan)note.LengthAs(TimeSpanType.Metric, tmpMap)).TotalMilliseconds;

                        
                        foreach (KeyValuePair<StateProperty, string> keyValuePair in eventType.SustainValueMappings)
                        {
                            Expression exp = new Expression(keyValuePair.Value);
                            foreach (KeyValuePair<string, double> mapping in mappings)
                            {
                                exp.Parameters[mapping.Key] = mapping.Value;
                            }
                            SE.SustainValues[keyValuePair.Key] = Convert.ToDouble(exp.Evaluate());
                        }

                        foreach (KeyValuePair<StateProperty, string> keyValuePair in eventType.PeakValueMappings)
                        {
                            Expression exp = new Expression(keyValuePair.Value);
                            foreach (KeyValuePair<string, double> mapping in mappings)
                            {
                                exp.Parameters[mapping.Key] = mapping.Value;
                            }
                            SE.PeakValues[keyValuePair.Key] = Convert.ToDouble(exp.Evaluate());
                        }
                        SE.StartTime = (uint)((TimeSpan)(MetricTimeSpan)note.TimeAs(TimeSpanType.Metric, tmpMap)).TotalMilliseconds;

                        timeline.Events.Add(SE);
                    }
                }
            }

            return timeline;
        }

        public static void GenerateAnimation(string midi_path, StateTimelineTemplate template, string path_out = "") 
        {
            StateTimeline timeline = CreateStateTimeline(midi_path, template);
            timeline.Name = Path.GetFileNameWithoutExtension(midi_path);
            Console.WriteLine("Creating Animation with " + timeline.TotalFrameCount(template.Metadata.Framerate) + " Frames");
            timeline.GenerateAnimation(template.Metadata, 1, AnimationType.Gif, true, path_out);
        }

        public static void GenerateJson(string midi_path, StateTimelineTemplate template, string path_out = "")
        {
            GenerationData gd = new GenerationData();
            
            gd.Add(template.Metadata);
            StateTimeline timeline = CreateStateTimeline(midi_path, template);
            timeline.Name = midi_path[..midi_path.IndexOf('.')];
            gd.Name = midi_path[..midi_path.IndexOf('.')];
            gd.Add(timeline);

            gd.SaveJson(path_out);
        }
    }
}