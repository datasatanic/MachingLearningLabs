using Accord.Neuro;
using Accord.Neuro.Learning;

namespace Lab4
{
    public class Kohonen
    {
        public DistanceNetwork Network { get; set; }
        private SOMLearning Teacher { get; set; }
        public double[][] Input { get; set; }
        /// <summary>
        /// Создание сети Кохонена
        /// </summary>
        /// <param name="input"> Количество входов</param>
        /// <param name="neuronsCount"> Количество нейронов</param>
        public Kohonen(double[][] input,int neuronsCount)
        {
            Input = input;
            //TODO:Понять как это работает
            Network = new DistanceNetwork(input[0].Length,neuronsCount);
            Teacher = new SOMLearning(Network);
        }

        public void Learn()
        {
            Teacher.LearningRadius = 0;
            Teacher.RunEpoch(Input);
        }

        public double[] Compute(double[] input)
        {
            return Network.Compute(input);
        }
    }
}