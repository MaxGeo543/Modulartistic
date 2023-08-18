﻿using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modulartistic.Drawing
{
    public struct Color
    {
        private SKColor _color;
        internal SKColor SK { get => _color; }

        public byte R { get => _color.Red; }
        public byte G { get => _color.Green; }
        public byte B { get => _color.Blue; }
        public byte A { get => _color.Alpha; }

        #region Constructors
        public Color(byte red, byte green, byte blue, byte alpha)
        {
            _color = new SKColor(red, green, blue, alpha);
        }

        public Color(int red, int green, int blue, int alpha)
        {
            _color = new SKColor((byte)red, (byte)green, (byte)blue, (byte)alpha);
        }
        #endregion

        #region Methods
        public static Color FromHSV(float hue, float saturation, float value )
        {
            float chroma = saturation * value;
            float Hi = hue / 60;
            float X = chroma * (1 - Math.Abs(Hi % 2 - 1));

            float[] rgb;

            if (0 <= Hi && Hi < 1)
                rgb = new float[3] { chroma, X, 0 };
            else if (1 <= Hi && Hi < 2)
                rgb = new float[3] { X, chroma, 0 };
            else if (2 <= Hi && Hi < 3)
                rgb = new float[3] { 0, chroma, X };
            else if (3 <= Hi && Hi < 4)
                rgb = new float[3] { 0, X, chroma };
            else if (4 <= Hi && Hi < 5)
                rgb = new float[3] { X, 0, chroma };
            else if (5 <= Hi && Hi < 6)
                rgb = new float[3] { chroma, 0, X };
            else
                rgb = new float[3] { 0, 0, 0 };
            byte r = (byte)(255 * (rgb[0] + (value - chroma)));
            byte g = (byte)(255 * (rgb[1] + (value - chroma)));
            byte b = (byte)(255 * (rgb[2] + (value - chroma)));
            
            return new Color(r, g, b, 255);
        }
        #endregion


    }
}