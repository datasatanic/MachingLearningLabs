using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp1;
using Accord.IO;
using Accord.Math;
using Accord.Neuro;
using Accord.Neuro.Learning;

namespace Lab3_2
{
    public partial class Form1 : Form
    {
        public List<Tuple<double[], double[]>> LearnList = new List<Tuple<double[], double[]>>();
        public ActivationNetwork Network { get; set; }
        public BackPropagationLearning Teacher { get; set; }
        public double err;
        public int Iteration { get; set; }


        public Form1()
        {
            InitializeComponent();
            var data = new MatReader(@"D:\Учеба\4 курс\Нейроматематика\LAB3\данные к задачам\mnist\data.mat");
            var Input = data.Read<double[,]>("X").ToJagged();
            var output = data.Read<byte[,]>("y");
            var Output = new double[output.Length][];
            for (var index = 0; index < output.GetLength(0); index++)
            {
                var t = new double[10];
                t[output[index, 0] % 10] = 1;
                Output[index] = t;
            }
            for (var index = 0; index < Input.Length; index++)
            {
                LearnList.Add(new Tuple<double[], double[]>(Input[index], Output[index]));
            }

            LearnList.Shuffle();

            chart1.ChartAreas[0].Name = "Контрольная выборка";
            Series series = new Series("Ошибка");
            series.ChartType = SeriesChartType.Spline;
            series.Color = Color.Red;
            chart1.Series.Add(series);

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (Network == null)
            {
                Network = new ActivationNetwork(new BipolarSigmoidFunction(), 400, 400, 10);
                var rand = new Random();
                Network.ForEachWeight(z => 2 * rand.NextDouble() - 1);
            }
            Teacher = new BackPropagationLearning(Network);
            Teacher.Momentum = 0.0001;
            Teacher.LearningRate = 1;
            Iteration = 0;
            int res;
            double rep = 0.0;
            int learncount = (int)(LearnList.Count * 0.8);
            while (!worker.CancellationPending)
            {
                Learn(LearnList.Select(z => z.Item1).Take(learncount).ToArray(), LearnList.Select(z => z.Item2).Take(learncount).ToArray());
                Iteration++;
                if (Iteration % 100 == 0)
                {
                    res = 0;
                    err = 0.0;
                    Parallel.For(learncount, LearnList.Count,
                        i =>
                        {
                            res += (Network.Compute(LearnList[i].Item1) == LearnList[i].Item2) ? 1 : 0;
                            err += computeErr(LearnList[i].Item1, LearnList[i].Item2);
                        });
                    rep = res / (LearnList.Count * 0.2) * 100;
                    backgroundWorker1.ReportProgress((int)rep);
                }
            }
        }

        public void Learn(double[][] input, double[][] output)
        {
            Teacher.RunEpoch(input, output);
        }

        public double computeErr(double[] x, double[] y)
        {
            var res = Network.Compute(x);
            var err = 0.0;
            Parallel.For(0, y.Length, z => err += Math.Pow((y[z] - res[z]), 2));
            return err;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            chart1.Series[0].Points.AddXY(Iteration, err);
            textBox1.Text = Iteration.ToString();
            textBox2.Text = e.ProgressPercentage.ToString() + "%";
            if(e.ProgressPercentage>=70)
                backgroundWorker1.CancelAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            button1.Enabled = true;
            button2.Enabled = false;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();
            var m = MessageBox.Show("Сохранить сеть?", "", MessageBoxButtons.YesNoCancel);
            if (m == DialogResult.Yes)
            {
                var File = new FileStream("Network.txt", FileMode.OpenOrCreate);
                Network.Save(File);
            }
            else if (m == DialogResult.Cancel)
            {
                e.Cancel = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var File = new FileStream("Network.txt", FileMode.Open);
                var b = new BinaryFormatter();
                Network = Accord.Neuro.Network.Load(File) as ActivationNetwork;
                MessageBox.Show("Сеть загружена");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Файл не существует");
            }

        }
    }
}
