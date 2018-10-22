using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Accord.Neuro;
using Accord.Neuro.Learning;
using Lab2;



namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawChart()
        {
            if (chart1.Series.Any())
            {
               return;
            }
            double[,] input =new  double[,]{ {2.1},{ 3.2},{ 4} };
            double[,] output =new  double[,]{ {1.5},{2.4},{3.4} };
            var network=new RBFNetwork(input,output);
            var series1 = new Series("Исходные данные")
            {
                ChartType = SeriesChartType.Point,
                Color = Color.Red,
                MarkerStyle = MarkerStyle.Circle
            };
            for (int i = 0; i < input.Length; i++)
            {
                series1.Points.AddXY(input[i, 0], output[i, 0]);
            }
            network.Learn();
            var range = new MyRange(1, 6).ToDouble();
            var result = range.Select(x => network.Compute(x)).ToArray();
            var series2 = new Series("Результирующие данные")
            {
                ChartType = SeriesChartType.Spline,
                Color = Color.BlueViolet
            };
            for (int i = 0; i < range.Length; i++)
            {
                series2.Points.AddXY(range[i], result[i][0]);
            }
            chart1.Series.Add(series1);
            chart1.Series.Add(series2);
            chart1.Refresh();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex==2)
            {
                DrawChart();
            }
        }
    }
    //TODO:Реализовать сеть Кохонена
    public class Kohonen
    {
        public DistanceNetwork Network { get; set; }
        public IUnsupervisedLearning Teacher { get; set; }
        public Kohonen()
        {
           Network = new DistanceNetwork(2, 4);
           Teacher = new SOMLearning(Network);
        }

        public void Learn(double[][] input,double[][] output)
        {
            
        }
    }


}
