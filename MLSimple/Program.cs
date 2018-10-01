using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            var nero = new MlpSimple(2, 2, 1);
            var input = new double[4][]
            {
                new double[] {-1, -1},
                new double[] {-1, 1},
                new double[] {1, -1},
                new double[] {1, 1}
            };
            var output = new double[4][]
            {
                new double[] {-1},
                new double[] {1},
                new double[] {1},
                new double[] {-1}
            };

            nero.Learn(input, output);
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(nero.Compute(input[i])[0]);
            }

            Console.ReadKey();
        }
    }

    public class Neuron
    {
        public double[] Weights, Input;
        public double Out, Error, Drv, Bias, BiasWeight;

        public Neuron(int inputsCount)
        {
            Weights = new double[inputsCount];
            InitWeights();
        }

        int seed = (int) DateTime.Now.Ticks;
        private double Rnd() => ((new Random(seed++)).NextDouble() * 2 - 1);

        public void InitWeights()
        {
            var l = Weights.Length;
            for (int i = 0; i < l; i++)
                Weights[i] = 2 * Rnd() / l;
            BiasWeight = 2 * Rnd() / l;
        }

        public double Compute(double[] input)
        {
            Input = input;
            Out = 0;
            for (int i = 0; i < input.Length; i++)
                Out += input[i] * Weights[i];
            Out += BiasWeight;
            Out = Math.Tanh(Out);
            Drv = (1 - Out) * (1 + Out);
            return Out;
        }

        public void TuneWeight(double learnRate)
        {
            for (int i = 0; i < Input.Length; i++)
                Weights[i] += Input[i] * Error * learnRate;
            BiasWeight += Error * learnRate;
        }
    }

    public class Layer
    {
        public Neuron[] neurons;
        public Layer nextLayer;
        public double[] Outputs;

        public Layer(int neuronsCount, int inputsCount)
        {
            neurons = new Neuron[neuronsCount];
            for (int i = 0; i < neurons.Length; i++)
                neurons[i] = new Neuron(inputsCount);
        }

        public double[] ComputeForward(double[] input)
        {
            Outputs = new double[neurons.Length];
            for (int i = 0; i < neurons.Length; i++)
                Outputs[i] = neurons[i].Compute(input);
            return Outputs;
        }

        public void ComputeBackward()
        {
            if (nextLayer != null)
                for (int i = 0; i < neurons.Length; i++)
                    OneBackItter(i);
        }

        private void OneBackItter(int i)
        {
            double backPropError = 0;
            for (int j = 0; j < nextLayer.neurons.Length; j++)
                backPropError += nextLayer.neurons[j].Weights[i] * nextLayer.neurons[j].Error;
            neurons[i].Error = backPropError * neurons[i].Drv;
        }
    }

    public class MlpSimple
    {
        public Layer[] Layers;

        public MlpSimple(int inputs, params int[] structure)
        {
            Layers = new Layer[structure.Length];
            Layers[0] = new Layer(structure[0], inputs);

            for (int i = 1; i < structure.Length; i++)
            {
                var neuronsCount = structure[i];
                var inputsCount = structure[i - 1];
                Layers[i] = new Layer(neuronsCount, inputsCount);
            }
            for (int i = 0; i < Layers.Length - 1; i++)
                Layers[i].nextLayer = Layers[i + 1];
        }

        public double[] Compute(double[] vector)
        {
            ComputeForward(vector);
            return Layers.Last().Outputs;
        }

        public void ComputeForward(double[] input)
        {
            for (int i = 0; i < Layers.Length; i++)
                input = Layers[i].ComputeForward(input);
        }

        public void ComputeBackward(double[] output)
        {
            var lastLayer = Layers.Last();
            for (int i = 0; i < output.Length; i++)
                lastLayer.neurons[i].Error = (output[i] - lastLayer.neurons[i].Out) * lastLayer.neurons[i].Drv;
            for (int i = Layers.Length - 1; i >= 0; i--)
                Layers[i].ComputeBackward();
        }

        public void TuneWeights()
        {
            for (int i = 0; i < Layers.Length; i++)
            for (int j = 0; j < Layers[i].neurons.Length; j++)
                Layers[i].neurons[j].TuneWeight(learnRate);
        }

        public void OneTune(double[][] inputs, double[][] outputs, int index = -1)
        {
            ComputeForward(inputs[index]);
            ComputeBackward(outputs[index]);
            TuneWeights();
        }

        double learnRate;

        public void Learn(double[][] inputs, double[][] outputs, int epoh = 100, double learnRate = 0.1)
        {
            this.learnRate = learnRate;
            for (int j = 0; j < epoh; j++)
            for (int i = 0; i < inputs.Count(); i++)
                OneTune(inputs, outputs, i);
        }
    }
}