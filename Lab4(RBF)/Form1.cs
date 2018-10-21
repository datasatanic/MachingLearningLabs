using System;
using System.Drawing;
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

        private void button1_Click(object sender, EventArgs e)
        {
            double[,] input =new  double[,]{ {2.1},{ 3.2},{ 4} };
            double[,] output =new  double[,]{ {1.5},{2.4},{3.4} };
            var network=new RBFNetwork(input,output);
            var series1 = new Series("Исходные данные")
            {
                ChartType = SeriesChartType.Point,
                Color = Color.Red
            };
            for (int i = 0; i < input.Length; i++)
            {
                series1.Points.AddXY(input[i, 0], output[i, 0]);
            }
            network.Learn();
            var range = new MyRange(1, 6);
            

        }
    }
    //TODO:Реализовать сеть Кохонена
    public class Kohonen
    {
        public DistanceNetwork Network { get; set; }
        public IUnsupervisedLearning Teacher { get; set; }
        public Kohonen()
        {
           Network = new DistanceNetwork(1, 3);
           Teacher = new SOMLearning(Network);
        }
    }


}
