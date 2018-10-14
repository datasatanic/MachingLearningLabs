using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Accord.IO;
using Accord.Math;
using Lab3_1;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private bool f = true;
        private double[] res;
        private ConcurrentQueue<double> err = new ConcurrentQueue<double>();
        private double Iteration = 0.0;
        public double[][] Input { get; set; }
        public double[][] Output { get; set; }
        private SimpleNetwork Net;

        public Form1()
        {
            InitializeComponent();
            var data = new MatReader(@"D:\Учеба\4 курс\Нейроматематика\LAB3\данные к задачам\simplefit_dataset\sd.mat");
            var t = data.FieldNames;
            Input = data.Read<double[,]>("x").ToJagged().Transpose();
            Output = data.Read<double[,]>("y").ToJagged().Transpose();
            res = new double[Input.Length];
            Net = new SimpleNetwork(new int[] { 1, 50, 1 });
            chart2.Series.Add(new Series("ошибка"));
            chart2.Series[0].XValueType = ChartValueType.Double;
            chart2.Series[0].YValueType = ChartValueType.Double;
            chart2.Series[0].ChartType = SeriesChartType.Spline;
            chart2.Series[0].Color = Color.Red;
        }

        public Series CreateSeries(double[] input, double[] output, string name, Color color)
        {
            var points = new List<Point>();
            var series = new Series(name);
            series.XValueType = ChartValueType.Double;
            series.YValueType = ChartValueType.Double;
            series.ChartType = SeriesChartType.Spline;
            series.Color = color;
            for (int i = 0; i < input.Length; i++)
            {
                series.Points.AddXY(input[i], output[i]);
            }
            return series;

        }

        public void Learn()
        {
            Net.Learn(Input, Output);
            for (int i = 0; i < Input.Length; i++)
            {
                res[i] = Net.Compute(Input[i]);
            }
            Iteration++;
        }

        public void Draw()
        {
            chart1.Series.Clear();
            chart1.Series.Add(CreateSeries(Input.Select(z => z[0]).ToArray(), Output.Select(z => z[0]).ToArray(), "Исходные", Color.Blue));
            chart1.Series.Add(CreateSeries(Input.Select(z => z[0]).ToArray(), res, "Регрессия", Color.Red));
            var e = Net.Error(Input, Output);
            chart2.Series[0].Points.AddXY(Iteration,e);
            errLabel.Text = e.ToString();
            chart1.Refresh();
            chart2.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (worker.CancellationPending != true)
            {
                Learn();
                if (Iteration % 1000==0) { 
                    Thread.Sleep(200);
                    worker.ReportProgress(0);
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }
    }
}
