using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Modar_F
{
    public class State
    {
        public double Mod { get; set; }
        public double ModLimLow { get; set; }
        public double ModLimUp { get; set; }

        public double X0 { get; set; }
        public double Y0 { get; set; }
        public double XZoom { get; set; }
        public double YZoom { get; set; }
        public double Rotation { get; set; }

        public double ColorMinimum { get; set; }
        public double ColorSaturation { get; set; }
        public double ColorValue { get; set; }
        public double ColorAlpha { get; set; }
        public (double, double, double, double) InvalidColor { get; set; }
        public (double, double, double) ColorFactors { get; set; }

        public List<double> Parameters { get; set; }

        public string Name { get; set; }

        public State()
        {
            Mod = 500;
            ModLimLow = 0;
            ModLimUp = 500;

            X0 = 0;
            Y0 = 0;
            XZoom = 1;
            YZoom = 1;
            Rotation = 0;

            ColorMinimum = 0;
            ColorSaturation = 1;
            ColorValue = 1;
            ColorAlpha = 1;
            InvalidColor = (0, 0, 0, 0);
            ColorFactors = (1.0, 1.0, 1.0);

            Parameters = new List<double>(new double[10]);

            Name = "";
        }

        public State(
            double mod,
            double modLimLow,
            double modLimUp,

            double x0,
            double y0,
            double xZoom,
            double yZoom,
            double rotation,

            double colMin,
            double colSat,
            double colVal,
            double colAlpha,
            (double, double, double, double) invalCol,
            (double, double, double) colFact,

            List<double> parameters,

            string name = "")
        {
            Mod = mod;
            ModLimLow = modLimLow;
            ModLimUp = modLimUp;

            X0 = x0;
            Y0 = y0;
            XZoom = xZoom;
            YZoom = yZoom;
            Rotation = rotation;

            ColorMinimum = colMin;
            ColorSaturation = colSat;
            ColorValue = colVal;
            ColorAlpha = colAlpha;
            InvalidColor = invalCol;
            ColorFactors = colFact;

            Parameters = parameters;
            if (Parameters.Count < 10)
            {
                Parameters.AddRange(new double[10 - Parameters.Count]);
            }
            else if (Parameters.Count > 10)
            {
                throw new Exception();
            }

            Name = name;
        }

        public void GenerateImage(Size size, Func<double, double, List<double>, double> func, string path_out = @"")
        {
            //Bitmap for pixel data
            Bitmap image = new Bitmap(size.Width, size.Height);

            //iterate over every pixel
            int y = 0;
            while (y < size.Height)
            {
                int x = 0;
                while (x < size.Width)
                {
                    //Console.WriteLine(x.ToString() + " " + y.ToString());
                    //calculate actual x,y values (x_ & y_)
                    //Then pass them into the function
                    double x_ = X0 + Math.Cos(Rotation) * XZoom * (x - (double)size.Width / 2) - Math.Sin(Rotation) * YZoom * (y - size.Height / 2);
                    double y_ = Y0 + Math.Cos(Rotation) * YZoom * (y - (double)size.Height / 2) + Math.Sin(Rotation) * XZoom * (x - size.Width / 2);
                    double pixel;
                    try
                    {
                        double n = func(x_, y_, Parameters);
                        pixel = Functions.mod((double)n, Mod);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        pixel = -1;
                    }

                    //setting pixel to -1 if not within the limits
                    if (Mod <= 0) { Mod = double.Epsilon; }
                    if (ModLimLow < 0) { ModLimLow = 0; }
                    else if (ModLimLow > Mod) { ModLimLow = Mod; }
                    if (ModLimUp < 0) { ModLimUp = 0; }
                    else if (ModLimUp > Mod) { ModLimUp = Mod; }

                    if (ModLimLow == ModLimUp) { pixel = -1; }
                    else if (ModLimLow < ModLimUp)
                    {
                        if (!(pixel >= ModLimLow && pixel <= ModLimUp))
                        {
                            pixel = -1;
                        }
                    }
                    else
                    {
                        if (pixel >= ModLimLow && pixel <= ModLimUp)
                        {
                            pixel = -1;
                        }
                    }

                    //setting col to inval col if pixel == -1
                    Color color;
                    if (pixel >= 0)
                    {
                        if (ColorAlpha > 1) { ColorAlpha = 1; }
                        if (ColorSaturation > 1) { ColorSaturation = 1; }
                        if (ColorValue > 1) { ColorValue = 1; }

                        //Convert the value of Evaluation to hue and then to an RGB color
                        double hue = Functions.mod(ColorMinimum + 360 / Mod * pixel, 360);
                        color = ColorConverter.ConvertHSV2RGB(hue, ColorSaturation, ColorValue);

                        int a = (int)(255 * ColorAlpha);
                        int r = (int)(color.R * ColorFactors.Item1);
                        int g = (int)(color.G * ColorFactors.Item2);
                        int b = (int)(color.B * ColorFactors.Item3);

                        if (r > 255) { r = 255; }
                        if (g > 255) { g = 255; }
                        if (b > 255) { b = 255; }
                        if (r < 0) { r = 0; }
                        if (g < 0) { g = 0; }
                        if (b < 0) { b = 0; }

                        color = Color.FromArgb(a, r, g, b);
                    }
                    else
                    {
                        color = ColorConverter.ARGBFromTuple(InvalidColor);
                    }

                    //append the pixel to the image bitmap
                    image.SetPixel(x, y, color);
                    x++;
                }
                y++;
            }

            //Create Output Folder if not exist
            if (!Directory.Exists(@"Output"))
            {
                Directory.CreateDirectory(@"Output");
            }

            //Make path
            string path;
            if (path_out == "")
            {
                path = @"Output";
            }
            else { path = path_out; }

            path += Path.DirectorySeparatorChar + Name;

            //Edit the filename so that it's unique
            if (File.Exists(path + @".png") || File.Exists(path + @".gif") || Directory.Exists(path))
            {
                int i = 1;
                while (File.Exists(path + "_" + i + @".png") || File.Exists(path + "_" + i + @".gif") || Directory.Exists(path + "_" + i))
                {
                    i++;
                }
                path = path + "_" + i + @".png";
            }
            //save the image
            image.Save(path + @".png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
