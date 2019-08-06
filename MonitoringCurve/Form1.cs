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

namespace MonitoringCurve
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 设置曲线的样式
            Series series = chart1.Series[0];
            Series series1 = chart1.Series[1];
            // 画样条曲线（Spline）
            series.ChartType = SeriesChartType.Spline;
            series1.ChartType = SeriesChartType.Spline;
            // 线宽2个像素
            series.BorderWidth = 2;
            series1.BorderWidth = 2;
            // 线的颜色：红色
            series.Color = System.Drawing.Color.Red;
            series1.Color = System.Drawing.Color.Blue;
            // 图示上的文字
            series.LegendText = "演示曲线";
            series1.LegendText = "演示曲线1";

            // 准备数据
            int[] values = { 95, 30, 20, 23, 60, 87, 42, 77, 92, 51, 29, 11, 11, 87 };

            // 在chart中显示数据
            int x = 0;
            foreach (int v in values)
            {
                series.Points.AddXY(x, v);
                series1.Points.AddXY(x, v - 3);
                x++;
            }

            // 设置显示范围
            ChartArea chartArea = chart1.ChartAreas[0];
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 1100;
            chartArea.AxisY.Minimum = 0d;
            chartArea.AxisY.Maximum = 100d;
        }

        private void 通讯ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form serialForm = new Form2();//实体化一个Form类
            serialForm.Show();//弹出f
        }
    }
}
