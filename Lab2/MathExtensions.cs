using System;
using System.Collections.Generic;

namespace Lab2
{
    public static class MyMath
    {
        public static double Sigma(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
    }
    public class MyRange
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public double Step { get; set; }
        private List<double> Numbers { get; set; }=new List<double>();


        public MyRange(double min, double max, double step = 0.1)
        {
            Min = min;
            Max = max;
            Step = step;
            for (double i = Min; i < Max; i++)
            {
                Numbers.Add(i);
                i += Step;
            }
        }

        public double[] ToDouble()
        {
            return Numbers.ToArray();
        }
    }
}