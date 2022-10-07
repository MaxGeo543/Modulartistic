using System;
using System.Diagnostics;

namespace MoreMath
{
    class Program
    {
        static void Main(string[] args)
        {
            RawNaturalNumber Zero = RawNaturalNumber.ZERO;
            RawNaturalNumber One = RawNaturalNumber.Succ(Zero);
            RawNaturalNumber Two = RawNaturalNumber.Succ(One);
            RawNaturalNumber Variable = Two*Two;
            Variable *= Two;
            Variable *= Two;
            Variable *= Two;
            Variable *= Variable;
            Variable *= Variable;
            Variable *= Variable;
            Variable *= Variable;
            Variable *= Variable;
            //Console.WriteLine(Variable.Value);
        }
    }
}
