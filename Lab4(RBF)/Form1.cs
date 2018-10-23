using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lab2;
using Lab3_2;


namespace Lab4
{
    public partial class Form1 : Form
    {
        private Kohonen net;
        private double avg;
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

            double[,] input = new double[,] { { 2.1 }, { 3.2 }, { 4 } };
            double[,] output = new double[,] { { 1.5 }, { 2.4 }, { 3.4 } };
            var network = new RBFNetwork(input, output);
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
            if (e.TabPageIndex == 1)
            {
                DrawChart();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("1", "1");
            dataGridView1.Rows.Add("9.4", "6.4");
            dataGridView1.Rows.Add("2.5", "2.1");
            dataGridView1.Rows.Add("8", "7.7");
            dataGridView1.Rows.Add("0.5", "2.2");
            dataGridView1.Rows.Add("8.3", "7.4");
            dataGridView1.Rows.Add("7", "7");
            dataGridView1.Rows.Add("2.8", "0.8");
            dataGridView1.Rows.Add("1.2", "3");
            dataGridView1.Rows.Add("7.8", "6.1");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rowCount = dataGridView1.Rows.Count-1;
            double[][] Input=new double[rowCount][];
            for (int i = 0; i < rowCount; i++)
            {
                var row = dataGridView1.Rows[i];
                Input[i] = new[]{double.Parse(row.Cells[0].Value.ToString().Replace('.',',')),
                    double.Parse(row.Cells[1].Value.ToString().Replace('.',','))};
            }
            net=new Kohonen(Input,1);
            net.Learn();
        
            var res = Input.Select(x => net.Compute(x)[0]).ToArray();
            avg = res.Average();
            for (int i = 0; i < rowCount; i++)
            {
                dataGridView1.Rows[i].Cells[2].Value = (res[i] >= avg) ? 0 : 1;
            }

            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = (net.Compute(new double[]
            {
                double.Parse(textBox1.Text.Replace('.', ',')),
                double.Parse(textBox2.Text.Replace('.', ','))
            })[0]>avg)?"0":"1";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
    }

}

