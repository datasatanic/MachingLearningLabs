using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.IO;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var Network = new NeuralNetwork(15,new LearningNumberList());
            Network.ChangeTarget('8');
            var res = Network.Check(new double[]
            {
                1, 1, 1,
                1, 0, 1,
                1, 1, 1,
                1, 0, 1,
                1, 1, 1
            });
            Console.WriteLine(res);
         
   //         var a = new MatReader(new FileStream(@"C:\Users\Ogoli\Desktop\emnist-letters.mat",FileMode.Open));
 

        }
    }
}