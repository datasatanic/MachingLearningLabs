using System;
using Accord.Math;

namespace Lab4
{
    public class RBFNetwork
    {
        public double[,] Input { get; set; }
        public double[,] Output { get; set; }
        public RbfNeuron[] Layer { get; set; }=new RbfNeuron[3];
        public double[] Weight { get; set; }
        
        
        public RBFNetwork(double[,] input, double[,] output)
        {
            Input = input;
            Output = output;
            Layer[0]=new RbfNeuron(2,1);
            Layer[1]=new RbfNeuron(3,1);
            Layer[2]=new RbfNeuron(4,1);
        }

        public void Learn()
        {
            double[,] matrix = new double[Input.Length, Layer.Length];
            for (int i = 0; i < Input.GetLength(0); i++)
            {
                for (int j = 0; j < Layer.Length; j++)
                {
                    matrix[i, j] = Layer[j].GaussFunction(Input[i, 0]);
                }
            }
            Weight = matrix.TransposeAndDot(Output).GetColumn(0);
        }
        public double Compute(double x)
        {
            double[] res=new double[Layer.Length];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = Layer[i].GaussFunction(x);
            }
            return res.Dot(Weight);
        }
    }
    public class RbfNeuron
    {
        public double C { get; set; }
        public double Sigma { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="c"></param>
        /// <param name="sigma"></param>
        public RbfNeuron(double c, double sigma)
        {
            this.C = c;
            this.Sigma = sigma;
        }

        public double GaussFunction(double x) => Math.Exp(-(Math.Pow((x - C), 2) / 2 / Math.Pow(Sigma, 2)));
    }
}
