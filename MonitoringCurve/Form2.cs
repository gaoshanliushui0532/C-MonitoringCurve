using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoringCurve
{
    public partial class Form2 : Form
    {
        //public static SerialPort sp = null; //声明一个串口类
        public static bool isOpen = false;
        bool isSetProperty = false;
        public static Byte[] CommReceivedData = new Byte[100]; // 创建接收字节数组 

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MaximizeBox = false;

            for (int i = 0; i < 10; i++) //最大支持串口，可根据需求添加 
            {
                //String str = i + 1;
                cbxCOMPort.Items.Add("COM" + Convert.ToString(i + 1));
            }
            cbxCOMPort.SelectedIndex = 0;

            cbxBandBate.Items.Add("1200");
            cbxBandBate.Items.Add("2400");
            cbxBandBate.Items.Add("4800");
            cbxBandBate.Items.Add("9600");
            cbxBandBate.Items.Add("19200");
            cbxBandBate.Items.Add("38400");
            cbxBandBate.Items.Add("43000");
            cbxBandBate.Items.Add("56000");
            cbxBandBate.Items.Add("57600");
            cbxBandBate.Items.Add("115200");
            cbxBandBate.SelectedIndex = 3;

            //列出停止位
            cbxStopBit.Items.Add("0");
            cbxStopBit.Items.Add("1");
            cbxStopBit.Items.Add("1.5");
            cbxStopBit.Items.Add("2");
            cbxStopBit.SelectedIndex = 1;
            //列出数据位
            cbxDataBit.Items.Add("8");
            cbxDataBit.Items.Add("7");
            cbxDataBit.Items.Add("6");
            cbxDataBit.Items.Add("5");
            cbxDataBit.SelectedIndex = 0;
            //列出奇偶校验位
            cbxParity.Items.Add("无");
            cbxParity.Items.Add("奇校验");
            cbxParity.Items.Add("偶校验");
            cbxParity.SelectedIndex = 0;
            // 默认char 类型
            //Form1.rbnHex.Checked = true;
            // 检测串口端口 
          //  BtnCheckCom_Click(sender, e);
        }

        private void BtnCheckCom_Click(object sender, EventArgs e)
        {
            bool comExistence = false; // 有可用串口标志位 
            cbxCOMPort.Items.Clear(); //清除所有串口标志位
            for (int i = 0; 1 < 10; i++)
            {
                try
                {
                    spTemp = Form1.serialPort1. .("COM" + Convert.ToString(i + 1));
                    spTemp.Open();
                    spTemp.Close();
                    cbxCOMPort.Items.Add("COM" + Convert.ToString(i + 1));
                    comExistence = true;

                }
                catch (Exception)
                {
                    continue;
                }
                if (comExistence)
                {
                    cbxCOMPort.SelectedIndex = 0;
                    return;
                }
                else
                {
                    MessageBox.Show("没有找到可用串口！", "错误提示！");
                }

            }
        }
        private bool CheckPortSetting() //检查串口设置 
        {
            if (cbxCOMPort.Text.Trim() == "") return false;
            if (cbxBandBate.Text.Trim() == "") return false;
            if (cbxDataBit.Text.Trim() == "") return false;
            if (cbxStopBit.Text.Trim() == "") return false;
            if (cbxParity.Text.Trim() == "") return false;
            return true;
        }
       
        private void SetPortProperty() //检查串口属性
        {
          //  sp = new SerialPort();
            //Form1.sp = new SerialPort();
            serialPort1.PortName = cbxCOMPort.Text.Trim();//设置串口名
            sp.BaudRate = Convert.ToInt32(cbxBandBate.Text.Trim());
            //停止位
            float f = Convert.ToSingle(cbxStopBit.Text.Trim());
            if (f == 0)
            {
                sp.StopBits = StopBits.None;
            }
            else if (f == 1.5)
            {
                sp.StopBits = StopBits.OnePointFive;
            }
            else if (f == 2)
            {
                sp.StopBits = StopBits.Two;
            }
            else
            {
                sp.StopBits = StopBits.One;
            }
            //设置数据位 
            sp.DataBits = Convert.ToInt32(cbxDataBit.Text.Trim());
            //设置奇偶校验位
            string str = cbxParity.Text.Trim();
            if (str.CompareTo("无") == 0)
            {
                sp.Parity = Parity.None;
            }
            else if (str.CompareTo("奇校验") == 0)
            {
                sp.Parity = Parity.Odd;
            }
            else if (str.CompareTo("偶") == 0)
            {
                sp.Parity = Parity.Even;
            }
            else
            {
                sp.Parity = Parity.Even;
            }
            sp.ReadTimeout = 1; // 设置超时读取时间 
            sp.RtsEnable = true;
            //定义数据接收事件，当串口接收到数据后触发事件
            sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);

        }

        private void BtnOpenCom_Click(object sender, EventArgs e)
        {

            if (isOpen == false)
            {
                if (!CheckPortSetting()) // 检查串口设置 
                {
                    MessageBox.Show("串口未设置！", "错误提示！");
                    return;
                }
                if (!isSetProperty) // 设置串口属性 
                {
                    SetPortProperty();
                    isSetProperty = true;
                }
                try // 打开串口 
                {
                  //  Form1.seri Open();
                    isOpen = true;
                    btnOpenCom.Text = "关闭串口";
                    //串口打开后相关串口属性按钮不可用
                    cbxCOMPort.Enabled = false;
                    cbxBandBate.Enabled = false;
                    cbxDataBit.Enabled = false;
                    cbxParity.Enabled = false;
                    cbxStopBit.Enabled = false;
                    //rbnChar.Enabled = false;
                    //rbnHex.Enabled = true;
                }
                catch (Exception)
                {
                    //打开串口后相关标志位取消 
                    isSetProperty = false;
                    isOpen = false;
                    MessageBox.Show("串口无效或已被占用！", "错误提示！");
                }
            }
            else
            {
                try // 关闭串口 
                {
                    sp.Close();
                    isOpen = false;
                    btnOpenCom.Text = "打开串口";
                    //串口打开后相关串口属性按钮不可用
                    cbxCOMPort.Enabled = true;
                    cbxBandBate.Enabled = true;
                    cbxDataBit.Enabled = true;
                    cbxParity.Enabled = true;
                    cbxStopBit.Enabled = true;
                    //rbnChar.Enabled = true;
                    //rbnHex.Enabled = true;
                }
                catch (Exception)
                {
                    //打开串口后相关标志位取消 
                    MessageBox.Show("关闭串口时发生错误！", "错误提示！");
                }
            }
        }
        public void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
        }

        private void BtnClearData_Click(object sender, EventArgs e)
        {
            
        }

        public void BtnSentData_Click(object sender, EventArgs e)
        {
          

        }

        private void SerialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
           
        }

        private void RbnChar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Hide();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.SendToBack();
        }
    }
}
