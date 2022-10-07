using System;
using System.Collections.Generic;
using System.Text;

namespace MoreMath
{
    struct Fraction
    {
        public UInt64 Numerator;
        public UInt64 Denominator;
        public bool Negative;

        public Fraction(UInt64 num, UInt64 denom, bool neg)
        {
            Numerator = num;
            Denominator = denom;
            Negative = neg;
        }

        public Fraction(Int64 num, Int64 denom)
        {
            Numerator = (ulong)Math.Abs(num);
            Denominator = (ulong)Math.Abs(denom);
            Negative = Math.Sign(num) != Math.Sign(denom);
        }

        public Fraction FromDouble(double d)
        {
            UInt64 wholePart = (ulong)Math.Floor(d);
            Fraction s1 = new Fraction(wholePart, 1, d < 0);

            double decimalPart = d - wholePart;
            Fraction s2 = new Fraction((ulong)(decimalPart*Math.Pow(10,19)), (ulong)Math.Pow(10, 19), d < 0);

            Fraction result = s1 + s2;

            return Fraction.Simplify(result);
        }

        public int Sign
        {
            get
            {
                if (Numerator == 0)
                    return 0;
                else if (Negative)
                    return -1;
                else
                    return 1;
            }
        }

        public void Simplify()
        {
            while (MoreMath.GCD(Numerator, Denominator) != 1)
            {
                ulong gcd = MoreMath.GCD(Numerator, Denominator);
                Numerator /= gcd;
                Denominator /= gcd;
            }
        }

        public static Fraction Simplify(Fraction r)
        {
            Fraction fraction = r;
            fraction.Simplify();
            return fraction;
        }

        public override bool Equals(Object other)
        {
            if (other is Fraction)
            {
                return Simplify(this).Numerator == Simplify((Fraction)other).Numerator && Simplify(this).Denominator == Simplify((Fraction)other).Denominator;
            }
            else
                return false;
        }

        public static bool operator<(Fraction left, Fraction right)
        {
            if (left.Sign != right.Sign)
            {
                return left.Sign < right.Sign;
            }
            else
            {
                ulong fact = MoreMath.LCM(left.Denominator, right.Denominator);
                return (left.Numerator * fact / left.Denominator < right.Numerator * fact / right.Denominator) == !left.Negative;
            }

        }

        public static bool operator >(Fraction left, Fraction right)
        {
            if (left.Sign != right.Sign)
            {
                return left.Sign > right.Sign;
            }
            else
            {
                ulong fact = MoreMath.LCM(left.Denominator, right.Denominator);
                return (left.Numerator * fact / left.Denominator > right.Numerator * fact / right.Denominator) == left.Negative;
            }

        }

        public static Fraction Abs(Fraction f)
        {
            return new Fraction(f.Numerator, f.Denominator, false);
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            ulong newDenominator = MoreMath.LCM(a.Denominator, b.Denominator);
            ulong newNumerator;
            bool newNegative;
            if (a.Negative == b.Negative)
            {
                newNegative = a.Negative;
                newNumerator = a.Numerator * newDenominator / a.Denominator + b.Numerator * newDenominator / b.Denominator;
            }
            else if (a.Negative)
            {
                newNegative = a.Negative;
            }


            // return Fraction.Simplify(new Fraction(newNumerator, newDenominator, newNegative));
            return new Fraction(1, 1, true);
        }
            
    }
}
