using System;
using System.Drawing;

namespace Modar_F
{
    internal class ColorConverter
    {
        public static Color ConvertHSV2RGB(double hue, double saturation, double value)
        {
            double chroma = saturation * value;
            double Hi = hue / 60;
            double X = chroma * (1 - Math.Abs(Hi % 2 - 1));

            Color color;
            double[] rgb;

            if (0 <= Hi && Hi < 1)
                rgb = new double[3] { chroma, X, 0 };
            else if (1 <= Hi && Hi < 2)
                rgb = new double[3] { X, chroma, 0 };
            else if (2 <= Hi && Hi < 3)
                rgb = new double[3] { 0, chroma, X };
            else if (3 <= Hi && Hi < 4)
                rgb = new double[3] { 0, X, chroma };
            else if (4 <= Hi && Hi < 5)
                rgb = new double[3] { X, 0, chroma };
            else if (5 <= Hi && Hi < 6)
                rgb = new double[3] { chroma, 0, X };
            else
                rgb = new double[3] { 0, 0, 0 };
            int r = (int)(255 * (rgb[0] + (value - chroma)));
            int g = (int)(255 * (rgb[1] + (value - chroma)));
            int b = (int)(255 * (rgb[2] + (value - chroma)));
            color = Color.FromArgb(255, r, g, b);
            return color;
        }

        public static Color ARGBFromTuple((double, double, double, double) tup)
        {
            double a = tup.Item1;
            double r = tup.Item2;
            double g = tup.Item3;
            double b = tup.Item4;

            if (a > 1) { a = 1; }
            if (r > 1) { r = 1; }
            if (g > 1) { g = 1; }
            if (b > 1) { b = 1; }

            return Color.FromArgb((int)(255 * a), (int)(255 * r), (int)(255 * g), (int)(255 * b));
        }
    }
}
