using System;

namespace Lab2
{
    public static class MyMath
    {
        public static double Sigma(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
    }
}