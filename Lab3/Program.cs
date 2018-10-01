using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Accord.IO;
using Accord.Math;
using Accord.Neuro;
using Accord.Neuro.Learning;
using Lab2;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion

            //var reader = new MatReader(@"D:\Учеба\4 курс\Нейроматематика\LAB3\данные к задачам\mnist\data.mat");
            //var names = reader.Fields.Keys;
            //foreach (var name in names)
            //{

            //    Console.WriteLine(name);
            //}

            //var t = reader.Read<byte[,]>("y");
            //t[0,0] = 0;
            //for (int i = 0; i < 5000; i+=500)
            //{

            //    Console.WriteLine(t[i,0]);
            //} 
            #endregion

            //var Input = new LearningWordAnswer().List;
            //double[][] train=new double[Input.Count][];
            //double[][] output = new double[Input.Count][];
            //for (int i = 0; i < Input.Count; i++)
            //{
            //    train[i] = Input[i].image;
            //    output[i] =new double[]{ (Input[i].Value == 'C') ? 1.0 : 0.0 };
            //}
            var neuro = new ActivationNetwork(new BipolarSigmoidFunction(),2,3,1);
            var learn = new BackPropagationLearning(neuro);

            learn.LearningRate = 0.1;
            double err;
            var input = new double[4][]{
                new double[] {-1,-1},
                new double[] {-1,1},
                new double[] { 1,-1},
                new double[] { 1,1}
            };
            var output = new double[4][]
            {
                new double[] {-1},
                new double[] {1},
                new double[] {1},
                new double[] {-1},

            };
            do
            {
               err=learn.RunEpoch(input, output);
               Console.WriteLine(err);

            } while (err>=2.1);


            foreach (var item in input)
            {

                Console.WriteLine($"{item[0]},{item[1]}:{neuro.Compute(item)[0]} \n");
            }

            Console.ReadKey();
        }
    }
}
