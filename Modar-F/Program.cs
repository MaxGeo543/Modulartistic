using System;
using System.Collections.Generic;

namespace Modar_F
{
    internal class Program
    {
        static void Main(string[] args)
        {
            State s1 = new State(500, 0, 500, 0, 0, 1, 1, 0, 0, 1, 1, 1, (0, 0, 0, 0), (1, 1, 1), new List<double> { 0 }, "State1");
            State s2 = new State(500, 500, 500, 0, 0, 1, 1, 0, 0, 1, 1, 1, (0, 0, 0, 0), (1, 1, 1), new List<double> { 0 }, "State2");
            
            Easing easing = Easing.SineIn();
            Scene sc1 = new Scene(s1, 5, easing);
            Scene sc2 = new Scene(s2, 5, easing);
            
            StateSequence ss = new StateSequence();
            ss.Add(sc1);
            ss.Add(sc2);
            
            Func<double, double, List<double>, double> function = (x, y, p) => Functions.Product(x, y);

            ss.GenerateAnimation(new System.Drawing.Size(500, 500), function, 12, "");
            //took 1:21 for a 10 sec gif. thats fine-ish
        }
    }
}
