﻿using System.Numerics;

namespace Modulartistic.AddOns.Fractals
{
    [AddOn]
    public class FractalFunctions
    {
        public static double Mandelbrot(double x, double y, int depth = 10)
        {
            Complex z_0 = new Complex(x, y);
            Complex z = 0;

            int i = 0;
            while (i < depth)
            {
                z = Complex.Pow(z, 2) + z_0;
                double a = Complex.Abs(z);
                if (a > 2)
                    return double.NaN;
                i++;
            }
            return Complex.Abs(z);
        }

        public static double Juliaset(double z_x, double z_y, double c_x, double c_y, int depth)
        {
            Complex z_0 = new Complex(z_x, z_y);
            Complex c = new Complex(c_x, c_y);
            Complex z = z_0;

            int i = 0;
            while (i < depth)
            {
                z = Complex.Pow(z, 2) + c;
                double a = Complex.Abs(z);
                if (a > 2)
                    return Double.NaN;
                i++;
            }
            return Complex.Abs(z);
        }

        public static double BurningShip(double x, double y, int depth)
        {
            double zx = x;
            double zy = y;
            int i = 0;

            while (i < depth)
            {
                double xtemp = zx*zx - zy*zy + x;
                zy = Math.Abs(2*zx*zy) + y;
                zx = xtemp;

                if (zx*zx + zy*zy > 4)
                {
                    return double.NaN;
                }

                i++;
            }

            return zx * zx + zy * zy;
        }

    }
}
