using NCalc;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Modar_F
{
    public class Functions
    {
        public static double mod(double d1, double d2)
        {
            if (d2 <= 0)
                throw new DivideByZeroException();
            else
                return d1 - d2 * Math.Floor(d1 / d2);
        }

        //Custom currently takes WAY too long - maybe find better way to implement (redundent I think, needs testing)
        public static double Custom(Expression expression, double x, double y, List<double> paras)
        {
            Expression func = expression;
            func.Parameters["x"] = x;
            func.Parameters["y"] = y;

            func.Parameters["i_0"] = paras[0];
            func.Parameters["i"] = paras[0];
            func.Parameters["i_1"] = paras[1];
            func.Parameters["j"] = paras[1];
            func.Parameters["i_2"] = paras[2];
            func.Parameters["i_3"] = paras[3];
            func.Parameters["i_4"] = paras[4];
            func.Parameters["i_5"] = paras[5];
            func.Parameters["i_6"] = paras[6];
            func.Parameters["i_7"] = paras[7];
            func.Parameters["i_8"] = paras[8];
            func.Parameters["i_9"] = paras[9];

            return (double)func.Evaluate();
        }

        public static double Circle(double x, double y)
        {
            return Math.Pow(x, 2) + Math.Pow(y, 2);
        }

        public static double Product(double x, double y)
        {
            return x * y;
        }

        public static double Mandelbrot(double x, double y, int depth)
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
    }
}
