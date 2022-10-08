using Gif.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Modar_F
{
    public class StateSequence
    {
        private List<Scene> sequence;
        public string Name;
        public StateSequence()
        {
            sequence = new List<Scene>();
            Name = @"";
        }

        public StateSequence(List<Scene> sequence, string name)
        {
            this.sequence = sequence;
            Name = name;
        }

        public StateSequence(string name)
        {
            sequence = new List<Scene>();
            Name = name;
        }

        public void Add(Scene newScene)
        {
            sequence.Add(newScene);
        }

        public void Clear()
        {
            sequence.Clear();
        }

        public void RemoveAt(int idx)
        {
            sequence.RemoveAt(idx % Count);
        }

        public int Count
        {
            get => sequence.Count;
        }

        public Scene this[int idx]
        {
            get => sequence[idx % Count];
        }

        public void GenerateScene(int idx, Size size, Func<double, double, List<double>, double> func, int framerate, string path_out = @"")
        {
            //Defining the start and endstates
            State startState = this[idx].state;
            State endState = this[idx + 1].state;

            //Make path
            string path;
            if (path_out == "")
            {
                path = @"Output";
            }
            else { path = path_out; }

            if (startState.Name == "") { path += Path.DirectorySeparatorChar + "Scene"; }
            else { path += Path.DirectorySeparatorChar + startState.Name; }

            //Edit the Output Path
            if (File.Exists(path + @".png") || File.Exists(path + @".gif") || Directory.Exists(path))
            {
                int i = 1;
                while (File.Exists(path + "_" + i + @".png") || File.Exists(path + "_" + i + @".gif") || Directory.Exists(path + "_" + i))
                {
                    i++;
                }
                path = path + "_" + i;
            }
            //Create Output Path
            Directory.CreateDirectory(path);


            int frames = (int)this[idx].length * framerate;
            for (int i = 0; i < frames; i++)
            {
                State frameState = new State();
                frameState.Name = "Frame_" + i.ToString().PadLeft(frames.ToString().Length, '0');
                foreach (var prop in typeof(State).GetProperties())
                {
                    if (prop.PropertyType == typeof(double))
                    {
                        //Make sure The values are within their boundaries (e.g. 0 < colVal < 1 etc.)
                        double startValue = (double)typeof(State).GetProperty(prop.Name).GetValue(startState);
                        double endValue = (double)typeof(State).GetProperty(prop.Name).GetValue(endState);
                        double newValue = this[idx].easing.Ease(startValue, endValue, i, frames);

                        typeof(State).GetProperty(prop.Name).SetValue(frameState, newValue);
                    }
                    else if (prop.PropertyType == typeof((double, double, double, double)))
                    {
                        //Maybe optimize this
                        double start, end;

                        start = ((ValueTuple<double, double, double, double>)typeof(State).GetProperty(prop.Name).GetValue(startState)).Item1;
                        end = ((ValueTuple<double, double, double, double>)typeof(State).GetProperty(prop.Name).GetValue(endState)).Item1;
                        double a = this[idx].easing.Ease(start, end, i, frames);

                        start = ((ValueTuple<double, double, double, double>)typeof(State).GetProperty(prop.Name).GetValue(startState)).Item2;
                        end = ((ValueTuple<double, double, double, double>)typeof(State).GetProperty(prop.Name).GetValue(endState)).Item2;
                        double r = this[idx].easing.Ease(start, end, i, frames);

                        start = ((ValueTuple<double, double, double, double>)typeof(State).GetProperty(prop.Name).GetValue(startState)).Item3;
                        end = ((ValueTuple<double, double, double, double>)typeof(State).GetProperty(prop.Name).GetValue(endState)).Item3;
                        double g = this[idx].easing.Ease(start, end, i, frames);

                        start = ((ValueTuple<double, double, double, double>)typeof(State).GetProperty(prop.Name).GetValue(startState)).Item4;
                        end = ((ValueTuple<double, double, double, double>)typeof(State).GetProperty(prop.Name).GetValue(endState)).Item4;
                        double b = this[idx].easing.Ease(start, end, i, frames);

                        typeof(State).GetProperty(prop.Name).SetValue(frameState, (a, r, g, b));
                    }
                    else if (prop.PropertyType == typeof((double, double, double)))
                    {
                        //Maybe optimize this
                        double start, end;

                        start = ((ValueTuple<double, double, double>)typeof(State).GetProperty(prop.Name).GetValue(startState)).Item1;
                        end = ((ValueTuple<double, double, double>)typeof(State).GetProperty(prop.Name).GetValue(endState)).Item1;
                        double r = this[idx].easing.Ease(start, end, i, frames);

                        start = ((ValueTuple<double, double, double>)typeof(State).GetProperty(prop.Name).GetValue(startState)).Item2;
                        end = ((ValueTuple<double, double, double>)typeof(State).GetProperty(prop.Name).GetValue(endState)).Item2;
                        double g = this[idx].easing.Ease(start, end, i, frames);

                        start = ((ValueTuple<double, double, double>)typeof(State).GetProperty(prop.Name).GetValue(startState)).Item3;
                        end = ((ValueTuple<double, double, double>)typeof(State).GetProperty(prop.Name).GetValue(endState)).Item3;
                        double b = this[idx].easing.Ease(start, end, i, frames);

                        typeof(State).GetProperty(prop.Name).SetValue(frameState, (r, g, b));
                    }
                    else if (prop.PropertyType == typeof(List<double>))
                    {
                        List<double> startValue = (List<double>)typeof(State).GetProperty(prop.Name).GetValue(startState);
                        List<double> endValue = (List<double>)typeof(State).GetProperty(prop.Name).GetValue(endState);
                        List<double> newValue = new List<double>(new double[10]);

                        for (int j = 0; j < 10; j++)
                        {
                            newValue[j] = this[idx].easing.Ease(startValue[j], endValue[j], i, frames);
                        }
                        typeof(State).GetProperty(prop.Name).SetValue(frameState, newValue);
                    }
                }
                frameState.GenerateImage(size, func, path);
            }
        }

        public void GenerateAnimation(Size size, Func<double, double, List<double>, double> func, int framerate, string path_out = @"")
        {
            // creating filename and path
            //Make path
            string path;
            if (path_out == "")
            {
                path = @"Output";
            }
            else { path = path_out; }

            if (Name == "") { path += Path.DirectorySeparatorChar + "Animation"; }
            else { path += Path.DirectorySeparatorChar + Name; }

            //Edit the Output Path
            if (File.Exists(path + @".png") || File.Exists(path + @".gif") || Directory.Exists(path))
            {
                int i = 1;
                while (File.Exists(path + "_" + i + @".png") || File.Exists(path + "_" + i + @".gif") || Directory.Exists(path + "_" + i))
                {
                    i++;
                }
                path = path + "_" + i;
            }
            //create the Output path
            Directory.CreateDirectory(path);

            for (int i = 0; i < Count; i++)
            {
                GenerateScene(i, size, func, framerate, path);
            }

            // path -> folder, path - Animation.name = path_out = path_out(GenerateAnimation)
            CreateGif(framerate, path, path_out);
        }

        private void CreateGif(double framerate, string folder, string path_out)
        {
            //initialize the gif maker
            AnimatedGifEncoder e = new AnimatedGifEncoder();

            //Start Gif creation and set Delay and Repeat
            e.Start();
            e.SetDelay((int)(1000 / framerate));
            e.SetRepeat(0);

            //Start Frame Appendation(is that a word?)
            List<string> sceneDirs = new List<string>();
            for (int i = 0; i < Count; i++)
            {
                //Initialize sceneDirs List
                string sceneDir = folder;
                //Define the scenDir of the current scene
                if (this[i].state.Name == "") { sceneDir += Path.DirectorySeparatorChar + "Scene"; }
                else { sceneDir += Path.DirectorySeparatorChar + this[i].state.Name; }
                //If that sceneDir already existed it will be in the list -> increment j in "Scene_j"
                if (sceneDirs.Contains(sceneDir))
                {
                    int j = 1;
                    while (sceneDirs.Contains(sceneDir + "_" + j))
                    {
                        j++;
                    }
                    sceneDir = sceneDir + "_" + j;
                }
                //Add the actual sceneDir to the List
                sceneDirs.Add(sceneDir);

                //Get Images from sceneDir
                string[] images = Directory.GetFiles(sceneDir);

                //Loop over all images and Add them as frames to the gif
                for (int j = 0, count = images.Length; j < count; j++)
                {
                    e.AddFrame(Image.FromFile(images[j]));
                    Console.WriteLine(j);
                }
            }
            // creating filename and path
            //Make path
            string path;
            if (path_out == "")
            {
                path = @"Output";
            }
            else { path = path_out; }

            path += Path.DirectorySeparatorChar + new DirectoryInfo(folder).Name;
            path += @".gif";

            //Finish the gif creation
            e.Finish();
            //initialize MemoryStream (idk what that is or does, it was in the example)
            MemoryStream ms = e.Output();

            //initialize FileStream (Same)
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);

            //Save the gif
            fs.Write(ms.ToArray(), 0, (int)ms.Length);
            fs.Close();
        }
    }
}
