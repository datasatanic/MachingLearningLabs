using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
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
            for (var index = 0; index <Input.Length; index++)
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
                Network = new ActivationNetwork(new SigmoidFunction(), LearnList[0].Item1.Length, 100,10);
                var rand = new Random();
                Network.ForEachWeight(z => 2 * rand.NextDouble() - 1);
            }
            Teacher = new BackPropagationLearning(Network);
            Teacher.Momentum = 0.0001;
            Teacher.LearningRate = 0.1;
            Iteration = 0;
            int res;
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
                            var t= computeErr(LearnList[i].Item1, LearnList[i].Item2);
                            res += (t <= 0.1) ? 1 : 0;//(Network.Compute(LearnList[i].Item1) == LearnList[i].Item2) ? 1 : 0;
                            err = (t>=err)?t:err;
                        });
                    var rep = res / (LearnList.Count * 0.2) * 100;
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

            if (e.ProgressPercentage >= 95)
            {
                MessageBox.Show("Достигнуто :textBox2.Text");
                BackgroundWorkerStop();
            }
        }

        public void BackgroundWorkerStop()
        {
            backgroundWorker1.CancelAsync();
            if (button1.Enabled)
            {
                button1.Enabled = false;
                button2.Enabled = true;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorkerStop();
            backgroundWorker1.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BackgroundWorkerStop();
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
                File.Close();
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (Network==null)
            {
                MessageBox.Show("Сеть не загружена");
                return;
            }
            var rand=new Random();
            var i = rand.Next((int)(LearnList.Count*0.8), LearnList.Count);
            var res = Network.Compute(LearnList[i].Item1);
            MessageBox.Show($"Исходные:{LearnList[i].Item2.ToCSharp()}\nCompute:{res.ToCSharp()}\nЭто: {res.ArgMax()}"); //res.IndexOf(res.Max())}");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Network == null)
            {
                MessageBox.Show("Сеть не загружена");
                return;
            }
            int res = 0;
            List<Tuple<int,double[]>> list=new List<Tuple<int, double[]>>();
            var l=Parallel.ForEach(LearnList, z =>
            {
                var t = Network.Compute(z.Item1);
                if (t.ArgMax() == z.Item2.ArgMax())
                    res++;
                else
                {
                    list.Add(new Tuple<int,double[]>(LearnList.IndexOf(z),t));
                }
            });
            if (!l.IsCompleted)
                Thread.Sleep(1000);
            listView1.Items.Clear();
            int[] rep = new int[10];
            foreach (var item in list)
            {
                var arr = new int[item.Item2.Length];
                arr[item.Item2.ArgMax()] = 1;
                listView1.Items.Add($"{item.Item1}:{LearnList[item.Item1].Item2.ToText()} {arr.ToText()} {LearnList[item.Item1].Item2.ArgMax()}-{item.Item2.ArgMax()}");
                rep[LearnList[item.Item1].Item2.ArgMax()]++;
            }

            textBox2.Text = ((double)res / (double)LearnList.Count * 100).ToString() + "%";
            MessageBox.Show($"Не распознано:{list.Count}\n Чаще всего:{rep.ArgMax()}");
        }
    }
}
