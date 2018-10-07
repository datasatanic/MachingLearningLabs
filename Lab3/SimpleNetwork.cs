using System;
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
            public SimpleNetwork()
            {
                Net=new ActivationNetwork(new SigmoidFunction(),1,3,1);
                teacher=new BackPropagationLearning(Net);
           }

            public void Learn(double[][] input,double[][] output)
            {
                //teacher.RunEpoch(input, output);
                for (int i = 0; i < input.Length; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        teacher.LearningRate = 1;
                        teacher.Momentum = 0.00001;
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

