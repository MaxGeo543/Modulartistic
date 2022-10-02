using NCalc;
using System;

namespace Modar_F
{
    public class Easing
    {
        private Func<double, double, double, double, double> easingFunction;
        private Expression easingExpression;
        private string Name;

        private Easing(Func<double, double, double, double, double> f, string name)
        {
            easingFunction = f;
            Name = name;
        }

        private Easing(Func<double, double, double, double, double> f, Expression t)
        {
            easingExpression = t;
            easingFunction = f;
        }

        private static double ExpressionFunction(Expression e, double a, double b, int i, int j)
        {
            e.Parameters["a"] = a;
            e.Parameters["b"] = b;
            e.Parameters["i"] = i;
            e.Parameters["j"] = j;

            return (double)e.Evaluate();
        }

        public double Ease(double start, double end, int idx, int maxIdx)
        {
            return easingFunction(start, end, idx, maxIdx);
        }

        public static Easing Custom(string funcStr, int validityDepth, double validityTolerance)
        {
            Expression e = new Expression(funcStr);
            Func<double, double, double, double, double> f = (start, end, idx, maxIdx) => ExpressionFunction(e, start, end, (int)idx, (int)maxIdx);

            //Validity Check here
            return new Easing(f, e);
        }

        public static Easing SineIn()
        {
            Func<double, double, double, double, double> f = (start, end, idx, maxIdx) => start + (end - start) * (1 - Math.Cos(Math.PI * idx / maxIdx / 2));
            return new Easing(f, "SineIn");
        }

        public static Easing SineOut()
        {
            Func<double, double, double, double, double> f = (start, end, idx, maxIdx) => start + (end - start) * (Math.Sin(Math.PI * idx / maxIdx / 2));
            return new Easing(f, "SineOut");
        }

        public static Easing SineInOut()
        {
            Func<double, double, double, double, double> f = (start, end, idx, maxIdx) => start + (end - start) * (-(Math.Cos(Math.PI * idx / maxIdx) - 1) / 2);
            return new Easing(f, "SineInOut");
        }

        public static Easing ElasticIn()
        {
            Func<double, double, double, double, double> f = (start, end, idx, maxIdx) => start + (end - start) * (-Math.Pow(2, 10 * idx / maxIdx - 10) * Math.Sin((idx / maxIdx * 10 - 10.75) * (2 * Math.PI) / 3));
            return new Easing(f, "ElasticIn");
        }

        public static Easing ElasticOut()
        {
            Func<double, double, double, double, double> f = (start, end, idx, maxIdx) => start + (end - start) * (Math.Pow(2, -10 * idx / maxIdx) * Math.Sin((idx / maxIdx * 10 - 0.75) * (2 * Math.PI) / 3) + 1);
            return new Easing(f, "ElasticOut");
        }

        public static Easing ElasticInOut()
        {
            Func<double, double, double, double, double> f = (start, end, idx, maxIdx) => start + (end - start) * (Math.Pow(2, -10 * idx / maxIdx) * Math.Sin((idx / maxIdx * 10 - 0.75) * (2 * Math.PI) / 3) + 1);
            return new Easing(f, "ElasticInOut");
        }

        public static Easing BounceOut()
        {
            Func<double, double, double, double, double> f = (start, end, idx, maxIdx) => start + (end - start) * BounceOut_Function(idx/maxIdx);
            return new Easing(f, "BounceOut");
        }

        private static double BounceOut_Function(double x)
        {
            const double n1 = 7.5625;
            const double d1 = 2.75;

            if (x < 1 / d1)
            {
                return n1 * x * x;
            }
            else if (x < 2 / d1)
            {
                return n1 * (x -= 1.5 / d1) * x + 0.75;
            }
            else if (x < 2.5 / d1)
            {
                return n1 * (x -= 2.25 / d1) * x + 0.9375;
            }
            else
            {
                return n1 * (x -= 2.625 / d1) * x + 0.984375;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}