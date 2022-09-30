using NCalc;
using System;

namespace Modar_F
{
    public class Easing
    {
        private Func<double, double, double, double, double> easingFunction;
        private Expression easingExpression;

        private Easing(Func<double, double, double, double, double> f)
        {
            easingFunction = f;
        }

        private Easing(Func<double, double, double, double, double> f, Expression t)
        {
            easingExpression = t;
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
            Func<double, double, double, double, double> f = (start, end, idx, maxIdx) => start + (end - start) * ((1 - Math.Cos(Math.PI * idx / maxIdx)) / 2);
            return new Easing(f);
        }
    }
}