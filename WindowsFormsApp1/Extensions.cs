using System;
using Accord.Neuro;

namespace WindowsFormsApp1
{
    public static class Extensions
    {
        public static void ForEachWeight(this ActivationNetwork network, Func<double, double> modifier)
        {
            foreach (var l in network.Layers)
                l.ForEachWeight(modifier);
        }

        public static void ForEachWeight(this Layer layer, Func<double, double> modifier)
        {
            foreach (var n in layer.Neurons)
            {
                if (n is ActivationNeuron)
                    (n as ActivationNeuron).Threshold = modifier((n as ActivationNeuron).Threshold);
                for (int i = 0; i < n.Weights.Length; i++)
                    n.Weights[i] = modifier(n.Weights[i]);
            }
        }
    }

    public class Tanh:IActivationFunction,ICloneable
    {
        public Tanh(double alpha)
        {
            Alpha = alpha;
        }

        public Tanh()
        {
            Alpha = 1;
        }

        public double Alpha { get; set; }
        
        public double Function(double x)
        {
            return 2 / (1 + Math.Exp(-2 * Alpha * x)) - 1;
        }

        public double Derivative(double x)
        {
            return Alpha * (1 - Math.Pow(Function(x),2));
        }

        public double Derivative2(double y)
        {
            return -Alpha * 2 *Function(y)* Derivative(y);
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
