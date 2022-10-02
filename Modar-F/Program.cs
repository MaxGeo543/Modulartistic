using ScottPlot.Drawing.Colormaps;
using System;
using System.Collections.Generic;

namespace Modar_F
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Easing easing = Easing.BounceOut();

            List<double> dataY = new List<double>();
            int max = 1000;
            for (int i = 0; i <= max ; i++)
            {
                dataY.Add(easing.Ease(0,1,i,max));
            }
            var plt = new ScottPlot.Plot();
            //plt.AddScatter(dataX, dataY);
            plt.AddSignal(dataY.ToArray(), sampleRate: 48_000);
            plt.SaveFig(easing.ToString() + ".png");
        }
    }
}
