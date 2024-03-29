﻿using System;
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
using System.IO.Ports;

namespace MonitoringCurve
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        // Form serialForm = new Form2();//实体化一个Form类
        private Form serialForm = null; //定义子窗口对象

        static DateTime startTime = DateTime.Now.AddSeconds(-1);
        DateTime endTime = startTime.AddSeconds(10);
        DateTime kd = DateTime.Parse("00:00:01");
        Random random = new Random();       //随机函数，产生Y轴数据
        DataTable dt = new DataTable(); //创建数据表，存储数据
        int i = 0;      //显示数据表中的数据行数


        private void Form1_Load(object sender, EventArgs e)
        {
            
            // #region 折线图
            // 设置显示范围        

            chart1.DataSource = dt;//绑定数据
            // 设置曲线的样式
            chart1.Series["Series1"].ChartType = SeriesChartType.Line;//设置图表类型
            chart1.Series["Series2"].ChartType = SeriesChartType.Line;//设置图表类型
            chart1.Series["Series3"].ChartType = SeriesChartType.Line;//设置图表类型
            chart1.Series["Series4"].ChartType = SeriesChartType.Line;//设置图表类型
            chart1.Series["Series5"].ChartType = SeriesChartType.Line;//设置图表类型
            chart1.Series["Series6"].ChartType = SeriesChartType.Line;//设置图表类型
            chart1.Series["Series7"].ChartType = SeriesChartType.Line;//设置图表类型
            chart1.Series["Series8"].ChartType = SeriesChartType.Line;//设置图表类型
            chart1.Series["Series9"].ChartType = SeriesChartType.Line;//设置图表类型
            chart1.Series["Series10"].ChartType = SeriesChartType.Line;//设置图表类型

            chart1.Series["Series1"].IsValueShownAsLabel = true;//显示数据点的值
            chart1.Series["Series2"].IsValueShownAsLabel = true;//显示数据点的值
            chart1.Series["Series3"].IsValueShownAsLabel = true;//显示数据点的值
            chart1.Series["Series4"].IsValueShownAsLabel = true;//显示数据点的值
            chart1.Series["Series5"].IsValueShownAsLabel = true;//显示数据点的值
            chart1.Series["Series6"].IsValueShownAsLabel = true;//显示数据点的值
            chart1.Series["Series7"].IsValueShownAsLabel = true;//显示数据点的值
            chart1.Series["Series8"].IsValueShownAsLabel = true;//显示数据点的值
            chart1.Series["Series9"].IsValueShownAsLabel = true;//显示数据点的值
            chart1.Series["Series10"].IsValueShownAsLabel = true;//显示数据点的值
            chart1.Series["Series11"].IsValueShownAsLabel = true;//显示数据点的值
            chart1.Series["Series12"].IsValueShownAsLabel = true;//显示数据点的值
            chart1.Series["Series13"].IsValueShownAsLabel = true;//显示数据点的值
            //使能线条
            chart1.Series["Series3"].Enabled = true;
            chart1.Series["Series4"].Enabled = true;
            chart1.Series["Series5"].Enabled = true;
            chart1.Series["Series6"].Enabled = true;
            chart1.Series["Series7"].Enabled = true;
            chart1.Series["Series8"].Enabled = true;
            chart1.Series["Series9"].Enabled = true;
            chart1.Series["Series10"].Enabled = false;
            chart1.Series["Series11"].Enabled = false;
            chart1.Series["Series12"].Enabled = false;
            chart1.Series["Series13"].Enabled = false;
            // 线的颜色：红色
            chart1.Series["Series1"].Color = System.Drawing.Color.Red;
            chart1.Series["Series2"].Color = System.Drawing.Color.Blue;

            chart1.Series["Series1"].BorderColor = Color.Green;

            // 线宽2个像素
            chart1.Series["Series1"].BorderWidth = 2;
            chart1.Series["Series2"].BorderWidth = 2;
            // 图示上的文字
            chart1.Series["Series1"].LegendText = "出水温度";
            chart1.Series["Series2"].LegendText = "进水温度";
            chart1.Series["Series3"].LegendText = "比例阀电流";
            chart1.Series["Series4"].LegendText = "水流量";
            chart1.Series["Series5"].LegendText = "风机风速";
            chart1.Series["Series6"].LegendText = "备用";
            chart1.Series["Series7"].LegendText = "备用";
            chart1.Series["Series8"].LegendText = "备用";
            chart1.Series["Series9"].LegendText = "备用";
            chart1.Series["Series10"].LegendText = "备用";

            chart1.Series["Series1"].MarkerStyle = MarkerStyle.Circle; //线条上的数据点标志类型
            chart1.Series["Series2"].MarkerStyle = MarkerStyle.Circle; //线条上的数据点标志类型
            chart1.Series["Series3"].MarkerStyle = MarkerStyle.Circle; //线条上的数据点标志类型
            chart1.Series["Series4"].MarkerStyle = MarkerStyle.Circle; //线条上的数据点标志类型
            chart1.Series["Series5"].MarkerStyle = MarkerStyle.Circle; //线条上的数据点标志类型
            chart1.Series["Series6"].MarkerStyle = MarkerStyle.Circle; //线条上的数据点标志类型
            chart1.Series["Series7"].MarkerStyle = MarkerStyle.Circle; //线条上的数据点标志类型
            chart1.Series["Series8"].MarkerStyle = MarkerStyle.Circle; //线条上的数据点标志类型
            chart1.Series["Series9"].MarkerStyle = MarkerStyle.Circle; //线条上的数据点标志类型
            chart1.Series["Series10"].MarkerStyle = MarkerStyle.Circle; //线条上的数据点标志类型

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
            chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 260;
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
            //Form serialForm = new Form2();//实体化一个Form类
            // this.ShowInTaskbar = true;

            if (serialForm == null || serialForm.IsDisposed)
            {
                serialForm = new Form2();
            }
           // serialForm.MdiParent = this; //建立父子关系

            serialForm.Show(); //显示子窗口
            SerialDataReceivedEvent();
            serialForm.Focus();  //子窗口获得焦点
            serialForm.ShowInTaskbar = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //判断校验和
            int nSum = 0;
            int ii;
            for (ii = 0; ii < 14; ii++)
                nSum += Form2.CommReceivedData[ii];
            ii = (nSum >> 8) ^ 0xaa;
            nSum = (nSum & 0xFF) ^ 0x55;
            nSum = ii + nSum;    // 添加校验和 
            if (nSum != Form2.CommReceivedData[14])
                return;
           
            DataRow dr = dt.NewRow();
            dr["XTime"] = DateTime.Now.ToString("hh:mm:ss:ffff");
            dr["YTemp"] = Form2.CommReceivedData[0];// random.Next(0, 100);
            dr["YT44p"] = Form2.CommReceivedData[1]; // random.Next(0, 90);
            dt.Rows.Add(dr);

            if (dt.Rows.Count > 1)
            {
                i = dt.Rows.Count - 1;
                chart1.Series[0].Points.AddXY(DateTime.Now.ToOADate(),//         Convert.ToDateTime(dt.Rows[i]["XTime"].ToString()),
                    Convert.ToDouble(dt.Rows[i]["YTemp"].ToString()));
                chart1.Series[1].Points.AddXY(DateTime.Now.ToOADate(),//         Convert.ToDateTime(dt.Rows[i]["XTime"].ToString()),
                    Convert.ToDouble(dt.Rows[i]["YT44p"].ToString()));
            }

            textBox1.Text = dt.Rows[i]["YT44p"].ToString();
            textBox2.Text = dt.Rows[i]["YTemp"].ToString();

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

        private void Button1_Click(object sender, EventArgs e)
        {
            if(chart1.Series["Series2"].Enabled == true)
                chart1.Series["Series2"].Enabled = false;
            else
                chart1.Series["Series2"].Enabled = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (chart1.Series["Series1"].Enabled == true)
                chart1.Series["Series1"].Enabled = false;
            else
                chart1.Series["Series1"].Enabled = true;
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {

            if(CommonRes.serialPort1.IsOpen)
            {
                string Str;
                try // 写串口数据 
                {
                    if (timer1.Enabled == true)
                    {
                        Str = "FF FF 0A 00 00 00 00 00 00 01 6D 00 78";
                        timer1.Enabled = false;
                    }
                    else
                    {
                        Str = "FF FF 0A 00 00 00 00 00 00 01 6D 00 78";
                        timer1.Enabled = true;
                    }
                   
                    string[] strArr = Str.Trim().Split(' ');
                    byte[] data = new byte[strArr.Length];
                    //逐个字符变为16进制字节数据
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        data[i] = Convert.ToByte(strArr[i], 16);
                    }
                    CommonRes.serialPort1.Write(data, 0, data.Length);
                    //sp.WriteLine("FF FF 0A 00 00 00 00 00 00 01 6D 00 78");//"FF FF 00 00 FF FF"
                }
                catch (Exception)
                {
                    MessageBox.Show("发送数据时发生错误！", "错误提示！");
                }
            }
            else
            {
                //BtnOpenCom_Click();
                timer1.Enabled = false;
                
                MessageBox.Show("串口未打开！", "错误提示！");
                return;
            }
        }


        private void Button20_Click(object sender, EventArgs e)
        {

            string[] strArr = textBox20.Text.Trim().Split(' ');

        }
        private bool CheckSenddata() //检查串口设置 
        {
            if (tbxSendData.Text.Trim() == "") return false;
            return true;
        }
        private void BtnSentData_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommonRes.serialPort1.IsOpen)
                {
                    try // 写串口数据 
                    {
                        string[] strArr = tbxSendData.Text.Trim().Split(' ');
                        byte[] data = new byte[strArr.Length];
                        //逐个字符变为16进制字节数据
                        for (int i = 0; i < strArr.Length; i++)
                        {
                            data[i] = Convert.ToByte(strArr[i], 16);
                        }
                        CommonRes.serialPort1.Write(data, 0, data.Length);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("发送数据时发生错误！", "错误提示！");
                    }

                }
                else
                {
                    MessageBox.Show("串口未打开！", "错误提示！");
                    return;
                }
                if (!CheckSenddata()) // 检测要发送的数据 
                {
                    MessageBox.Show("请输入要发送的数据！", "错误提示！");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("串口未打开！", "错误提示！");
                return;
            }
        }

        private void BtnClearData_Click(object sender, EventArgs e)
        {
            lbxReceData.Items.Clear();
        }
        public  void SerialDataReceivedEvent()
        {
            CommonRes.serialPort1 = new SerialPort();
            //定义数据接收事件，当串口接收到数据后触发事件
            CommonRes.serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort1_DataReceived);
        }
        public void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(50);//延时100ms等待串口接收 
            //this.Invoke是跨线程访问方法
            this.Invoke((EventHandler)(delegate
            {
                if (rbnHex.Checked == false)
                {
                    CommonRes.serialPort1.ReadTimeout = 100000;
                    lbxReceData.Text += CommonRes.serialPort1.ReadLine();

                }
                else
                {
                    Byte[] ReceivedData = new Byte[CommonRes.serialPort1.BytesToRead + 1]; // 创建接收字节数组 
                    CommonRes.serialPort1.Read(ReceivedData, 0, ReceivedData.Length); // 读取所接受字节的数据 
                    string RecvDataText = null;


                    int DataLength;
                    DataLength = ReceivedData.Length;
                    if (DataLength > 15)
                        DataLength = 15;
                    for (int i = 0; i < DataLength; i++)
                    {
                        RecvDataText += ReceivedData[i].ToString("X2") + " ";
                        Form2.CommReceivedData[i] = ReceivedData[i];
                        //this.dataGridView1.Name. = 
                    }
                    //判断校验和
                    /*
                    int nSum = 0;
                    int ii = 0;
                    for (ii = 0; ii < 14; ii++)
                        nSum += CommReceivedData[ii];
                    ii = (nSum >> 8) ^ 0xaa;
                    nSum = (nSum & 0xFF) ^ 0x55;
                    nSum = ii + nSum;    // 添加校验和 
                    if (nSum != CommReceivedData[14])
                        return;
                    */
                    RecvDataText += "--";
                    RecvDataText += DateTime.Now.ToString("HH:mm:ss:fff");
                    lbxReceData.Items.Add(RecvDataText);
                }
                CommonRes.serialPort1.DiscardInBuffer(); // 丢弃缓冲区里的数据 
            }));
        }

        private void SerialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show("接收数据错误！", "错误提示！");
            return;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            groupBox3.Height = tabControl1.Height * 80 / 100;
            groupBox4.Height = tabControl1.Height * 13 / 100;
            groupBox4.Top = tabControl1.Height * 80 / 100 + 10;

            groupBox4.Width = tabControl1.Width * 80 / 100 + 10;

            groupBox2.Height = tabControl1.Height * 13 / 100;
            groupBox2.Top = tabControl1.Height * 80 / 100 + 10;

            groupBox2.Width = tabControl1.Width * 15 / 100 + 10;
        }

        private void TabControl1_SizeChanged(object sender, EventArgs e)
        {
            groupBox3.Height = tabControl1.Height * 80 / 100;
            groupBox4.Height = tabControl1.Height * 13 / 100;
            groupBox4.Top = tabControl1.Height * 80 / 100 + 10;
            groupBox4.Width = tabControl1.Width * 80 / 100 + 10;

            groupBox2.Height = tabControl1.Height * 13 / 100;
            groupBox2.Top = tabControl1.Height * 80 / 100 + 10;

            groupBox2.Width = tabControl1.Width * 15 / 100 + 10;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
//#endregion