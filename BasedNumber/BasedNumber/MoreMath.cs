using System;
using System.Collections.Generic;
using System.Text;

namespace MoreMath
{
    class MoreMath
    {
        public static ulong GCD(ulong a, ulong b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }

        public static ulong LCM(ulong a, ulong b)
        {
            return a * b / GCD(a, b);
        }
    }
}
