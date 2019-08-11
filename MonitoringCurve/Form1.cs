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
using System.Threading;
namespace MonitoringCurve
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      
        static DateTime startTime = DateTime.Now.AddSeconds(-1);
        DateTime endTime = startTime.AddSeconds(10);
        DateTime kd = DateTime.Parse("00:00:01");
        Random random = new Random();       //随机函数，产生Y轴数据
        DataTable dt = new DataTable(); //创建数据表，存储数据
        int flag = 0;   //设置Timer控件是否生效
        int i = 0;      //显示数据表中的数据行数
          
        private void Form1_Load(object sender, EventArgs e)
        {
           // #region 折线图
            // 设置显示范围        

            chart1.DataSource = dt;//绑定数据
            // 设置曲线的样式
            chart1.Series["Series1"].ChartType = SeriesChartType.Line;//设置图表类型
            chart1.Series["Series2"].ChartType = SeriesChartType.Line;//设置图表类型

            chart1.Series["Series1"].IsValueShownAsLabel = true;//显示数据点的值
            chart1.Series["Series2"].IsValueShownAsLabel = true;//显示数据点的值
            //使能线条
            chart1.Series["Series3"].Enabled = false;
            chart1.Series["Series4"].Enabled = false;
            chart1.Series["Series5"].Enabled = false;
            // 线的颜色：红色
            chart1.Series["Series1"].Color = System.Drawing.Color.Red;
            chart1.Series["Series2"].Color = System.Drawing.Color.Blue;

            chart1.Series["Series1"].BorderColor = Color.Green;

            // 线宽2个像素
            chart1.Series["Series1"].BorderWidth = 2;
            chart1.Series["Series2"].BorderWidth = 2;
            // 图示上的文字
            chart1.Series["Series1"].LegendText = "动态温度点";
            chart1.Series["Series2"].LegendText = "风速";
            chart1.Series["Series3"].LegendText = "33";

            chart1.Series["Series1"].MarkerStyle = MarkerStyle.Circle; //线条上的数据点标志类型
            chart1.Series["Series2"].MarkerStyle = MarkerStyle.Circle; //线条上的数据点标志类型

            //X轴设置
            // chart1.ChartAreas["ChartArea1"].AxisX.Title = "时间";//X轴标题
            chart1.ChartAreas["ChartArea1"].AxisX.TitleAlignment = StringAlignment.Near;//设置X轴标题的名称所在位置位近
            chart1.ChartAreas["ChartArea1"].AxisX.MajorTickMark.Enabled = true; //坐标轴上的刻度线
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = true;//不显示竖着的分割线
            chart1.ChartAreas["ChartArea1"].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;//主网格为虚线
            chart1.ChartAreas["ChartArea1"].AxisX.LineColor = Color.Blue; //X轴颜色
            this.chart1.ChartAreas["ChartArea1"].AxisX.IsMarksNextToAxis = true;
            this.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsEndLabelVisible = true;//最后一个标签点显示

            //设置X轴字体类型、大小、颜色
            this.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular);
            this.chart1.ChartAreas["ChartArea1"].AxisX.LabelAutoFitMaxFontSize = 12;
            this.chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.ForeColor = Color.Black;
            //Y轴设置
            // chart1.ChartAreas["ChartArea1"].AxisY.Title = "气温";//Y轴标题
            //  chart1.ChartAreas["ChartArea1"].AxisY.TitleAlignment = StringAlignment.Far;//设置Y轴标题的名称所在位置位远
            chart1.ChartAreas["ChartArea1"].AxisY.Interval = 10;
            chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 100;
            chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorTickMark.Enabled = false;//坐标轴上的刻度线，为false时少了小横杆线
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas["ChartArea1"].AxisY.LineColor = Color.Blue;

            /************************************************************************/
            /* 本文重点讲解时间格式的设置
             * 但第一个点并不能保证在原点第一个时间坐标位置，与时间间隔跨度有关系
             * 需要设置最小时间,最大小时，时间间隔类型，时间间隔值等四个参数，以保证当前网络跨度内容显示6个主网络线*/
            /************************************************************************/
            chart1.Series["Series1"].XValueType = ChartValueType.DateTime;     //X轴标签为时间类型
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "HH:mm:ss";  //X轴上显示时、分、秒


            // 准备数据
            int[] values = { 95, 30, 20, 23, 60, 87, 42, 77, 92, 51, 29, 11, 11, 87 };

            // 在chart中显示数据
            int x = 0;
            //foreach (int v in values)
            {

          //      Random rd = new Random();       //随机函数，产生Y轴数据
           //     DataTable dt = new DataTable(); //创建数据表，存储数据

             //   series.Points.AddXY(DateTime.Now.ToString("hh:mm:ss:ffff"), Form2.CommReceivedData[0]);//yy-MM-dd 
              //  series1.Points.AddXY(DateTime.Now, Form2.CommReceivedData[1]);
                //x++;
            }
            //清空原来数据缓存
            chart1.Series["Series1"].Points.Clear();

            //设置Chart大小
            chart1.Width = Width - 3;
            chart1.Height = Height - 3;
            chart1.BackColor = Color.CadetBlue;
            dt.Columns.Add("XTime", System.Type.GetType("System.String"));
            dt.Columns.Add("YTemp", System.Type.GetType("System.String"));
            dt.Columns.Add("YT44p", System.Type.GetType("System.String"));

        }

        private void 通讯ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form serialForm = new Form2();//实体化一个Form类
            serialForm.Show();//弹出f
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DataRow dr = dt.NewRow();
            dr["XTime"] = DateTime.Now.ToString("hh:mm:ss:ffff");
            dr["YTemp"] = random.Next(0, 100);
            dr["YT44p"] = random.Next(0, 90);
            dt.Rows.Add(dr);

            if (dt.Rows.Count > 1)
            {
                i = dt.Rows.Count - 1;
                chart1.Series[0].Points.AddXY(DateTime.Now.ToOADate(),//         Convert.ToDateTime(dt.Rows[i]["XTime"].ToString()),
                    Convert.ToDouble(dt.Rows[i]["YTemp"].ToString()));
                chart1.Series[1].Points.AddXY(DateTime.Now.ToOADate(),//         Convert.ToDateTime(dt.Rows[i]["XTime"].ToString()),
                    Convert.ToDouble(dt.Rows[i]["YT44p"].ToString()));
            }

          
            if (DateTime.Now.ToOADate() > endTime.ToOADate())
            {
                endTime = endTime.AddSeconds(10);//延长X时间轴
                startTime = DateTime.Now.AddSeconds(-1);

                chart1.ChartAreas["ChartArea1"].AxisX.Minimum = startTime.ToOADate();
                chart1.ChartAreas["ChartArea1"].AxisX.Maximum = endTime.ToOADate();
                TimeSpan jianGe = endTime - startTime;
                chart1.ChartAreas["ChartArea1"].AxisX.Interval = jianGe.TotalSeconds / 10;
                chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "hh:mm:ss";
                //chartArea.AxisX.Enabled = true;
            }

        }
    }
}
//#endregion