using System;
using System.Collections.Generic;


namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Введите число:");
                var result = Resh.Schet(double.Parse(Console.ReadLine()));
                Console.WriteLine("Ответ:{0}",(result==null)?"null":result.ToString());
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }

    public static class Resh
    {
        static Resh()
        {
            Initialize();
        }
        private const int n = 1000;
        private const double e = 1;
        private static List<double> xi;

        private static void Initialize()
        {
            xi=new List<double>();
            for (int i = -n; i <= n; i++)
            {
                xi.Add(i*0.1);
            }
    }

        public static double? Schet(double x)
        {
            double y;
            for (int i=0;i<2*n;i++)
            {
                 y = (x - xi[i]) / (xi[i + 1] - xi[i]);
                if (y > 0 && y <= 1)
                    return ((Math.Exp(xi[i + 1]) - Math.Exp(xi[i]))*x - xi[i] * Math.Exp(xi[i + 1]) +xi[i + 1] * Math.Exp(xi[i])) / (xi[i + 1] - xi[i]);
            }
            return null;
        }
        
    }
}
