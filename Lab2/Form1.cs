using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab2
{
    public partial class Form1 : Form
    {
        private double step;
        private const double piecesCount = 100;
        private const double minX = -1 * Math.PI;
        private const double maxX = Math.PI;
        private const int furieStepCount = 10;
        private void SetupChart()
        {
            this.chart.Series.Clear();
            this.chart.Titles.Add("Графики функций");
            this.chart.ChartAreas[0].AxisX.LabelStyle.Format = "{0:#.###}";
        }
        private void DrawFunctions()
        {
            double x = minX;
            Series commonSeries = this.chart.Series.Add("График основной функции");
            commonSeries.ChartType = SeriesChartType.Line;
            Series furieSeries = this.chart.Series.Add("График суммы ряда Фурье");
            furieSeries.ChartType = SeriesChartType.Line;
            while (x<maxX)
            {
                commonSeries.Points.AddXY(x, CommonFunction(x));
                furieSeries.Points.AddXY(x, FurieFunction(x));
                x += step;
            }
            
        }
        private double CommonFunction(double x)
        {
            double ans = 0;
            if (x >= minX && x < 0) ans = 0;
            else if (x >= 0 && x <= maxX) ans = 1 - 4 * x;
            return ans;
        }
        private double FurieFunction(double x)
        {
            double a0 = 1 - 2 * Math.PI;
            double sum = 0; 
            for (int n=1;n<=furieStepCount;n++)
            {
                sum += ((4*(1 - Math.Pow(-1, n))) / (n * n)) * Math.Cos(n * x);
                sum += (((4 * Math.PI - 1) * Math.Pow(-1, n) + 1 ) / n) * Math.Sin(n * x);
            }
            sum /= Math.PI;
            sum += a0/2;
            return sum;
        }
        public Form1()
        {
            InitializeComponent();
            SetupChart();
            step = (maxX - minX) / piecesCount;
            DrawFunctions();
        }

        private void chart_Click(object sender, EventArgs e)
        {

        }
    }
}
