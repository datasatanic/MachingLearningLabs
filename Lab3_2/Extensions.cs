using Accord;
using Accord.Math;

namespace Lab3_2
{
    public static class Extensions
    {
        public static string ToText<T>(this T[] x,string format=null)
        {
            string s = "{ ";
            for (int i = 0; i < x.Length; i++)
            {

                s += x[i].ToString() +" ";
            }

            return s+"}";
        }
        }
}