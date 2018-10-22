using System;
using System.Collections.Generic;
using System.Linq;
using Accord;

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
        public double Delta { get; set; }

        public MyRange(double min, double max, double step = 0.1)
        {
            Min = min;
            Max = max;
            Delta = step;
        }

        public double[] ToDouble()
        {
            return Enumerable
                .Range(0, (int)((Max - Min) / Delta) + 1)
                .Select(z => z * Delta + Min)
                .ToArray();}
    }
}