using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Accord.IO;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new MatReader(@"D:\Учеба\4 курс\Нейроматематика\LAB3\данные к задачам\mnist\data.mat");
            var names = reader.Fields.Keys;
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            var t = reader.Read<byte[,]>("y");
            t[0,0] = 0;
            for (int i = 0; i < 5000; i+=500)
            {
               
                Console.WriteLine(t[i,0]);
            }

            Console.ReadKey();
        }
    }
}
