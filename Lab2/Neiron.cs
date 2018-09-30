using System;

namespace Lab2
{
    class Neiron
    {
        public double[] weight;
        public const double delta = 0.1;

        public Neiron(int count)
        {
            this.weight = new double[count];
            var rand = new Random();
            for (int i = 0; i < count; i++)
            {
                weight[i] = rand.NextDouble() - 0.5;
            }
        }

        public int Schet(double[] model)
        {
            double s = 0;
            for (int i = 0; i < weight.Length; i++)
            {
                s += model[i] * weight[i];
            }

            return (Math.Sign(s) <= 0) ? -1 : 1;
        }

        public void Learn(double[] model, int target)
        {
            do
            {
                var res = Schet(model);
                if (target != res)
                {
                    double err;
                    double sum = 0;
                    for (int i = 0; i < weight.Length; i++)
                    {
                        err = -1 * res * model[i] * delta;
                        sum += err * err;
                        weight[i] += err;
                    }
                }
                else
                {
                    break;
                }
            } while (true);
        }
    }
}