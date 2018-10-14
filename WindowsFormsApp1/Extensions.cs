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
}