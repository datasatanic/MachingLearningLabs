using System;
using System.Linq;
using WindowsFormsApp1;
using Accord.Neuro;
using Accord.Neuro.Learning;

namespace Lab3_1
{
        public class SimpleNetwork
        {
            /// <summary>
            /// Нейронная сеть
            /// </summary>
            public ActivationNetwork Net { get; set; }
            /// <summary>
            /// Алгоритм обучения нейронной сети методом обратной распростронения ошибки
            /// </summary>
            public BackPropagationLearning teacher { get; set; }
            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="struc"> Структура нейронной сети</param>
            public SimpleNetwork(int[] struc)
            {
                Net = new ActivationNetwork(new BipolarSigmoidFunction(), struc[0],struc.Skip(1).ToArray());
                teacher=new BackPropagationLearning(Net);
                var rand=new Random();
                Net.ForEachWeight(x=>2*rand.NextDouble()-1);
              //  teacher.LearningRate = 1;
               // teacher.Momentum = 0.0001;
            }

            public void Learn(double[][] input,double[][] output)
            {
                //teacher.RunEpoch(input, output);
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        teacher.Run(input[i], output[i]);
                    }
                }
            }

            public double Error(double[][] input, double[][] output)
            {
                var err = 0.0;
                for (var index = 0; index < input.Length; index++)
                {

                    err += Math.Abs(Net.Compute(input[index])[0] - output[index][0]);
                }
                return err;
            }

            public double Compute(double[] input)
            {
                return Net.Compute(input)[0];
            }

        }
    
}

