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
        SerialPort sp = null; //声明一个串口类
        bool isOpen = false;
        bool isSetProperty = false;
        bool isHex = false;
        public static Byte[] CommReceivedData = new Byte[15]; // 创建接收字节数组 
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
            rbnChar.Checked = true;
        }

        private void BtnCheckCom_Click(object sender, EventArgs e)
        {
            bool comExistence = false; // 有可用串口标志位 
            cbxCOMPort.Items.Clear(); //清除所有串口标志位
            for (int i = 0; 1 < 10; i++)
            {
                try
                {
                    SerialPort sp = new SerialPort("COM" + Convert.ToString(i + 1));
                    sp.Open();
                    sp.Close();
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
        private bool CheckSenddata() //检查串口设置 
        {
            if (lbxSendData.Text.Trim() == "") return false;
            return true;
        }
        private void SetPortProperty() //检查串口属性
        {
            sp = new SerialPort();
            sp.PortName = cbxCOMPort.Text.Trim();//设置串口名
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
            if (rbnHex.Checked)
            {
                isHex = true;
            }
            else
            {
                isHex = false;
            }

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
                    sp.Open();
                    isOpen = true;
                    btnOpenCom.Text = "关闭串口";
                    //串口打开后相关串口属性按钮不可用
                    cbxCOMPort.Enabled = false;
                    cbxBandBate.Enabled = false;
                    cbxDataBit.Enabled = false;
                    cbxParity.Enabled = false;
                    cbxStopBit.Enabled = false;
                    rbnChar.Enabled = false;
                    rbnHex.Enabled = false;
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
                    rbnChar.Enabled = true;
                    rbnHex.Enabled = true;
                }
                catch (Exception)
                {
                    //打开串口后相关标志位取消 
                    MessageBox.Show("关闭串口时发生错误！", "错误提示！");
                }
            }
        }
        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(100);//延时100ms等待串口接收 
            //this.Invoke是跨线程访问方法
            this.Invoke((EventHandler)(delegate
            {
                if (isHex == false)
                {
                    lbxReceData.Text += sp.ReadLine();

                }
                else
                {
                    Byte[] ReceivedData = new Byte[sp.BytesToRead+1]; // 创建接收字节数组 
                    sp.Read(ReceivedData, 0, ReceivedData.Length); // 读取所接受字节的数据 
                    string RecvDataText = null;
                    for (int i = 0; i < ReceivedData.Length - 1; i++)
                    {
                        RecvDataText += (ReceivedData[i].ToString("X2") + "");
                        CommReceivedData[i] = ReceivedData[i];
                    }
                    lbxReceData.Text += RecvDataText;
                    lbxReceData.Text += DateTime.Now.ToString("hh:mm:ss:ffff");
                }
                sp.DiscardInBuffer(); // 丢弃缓冲区里的数据 
            }));
        }

        private void BtnClearData_Click(object sender, EventArgs e)
        {
            lbxReceData.Text = "";
        }

        private void BtnSentData_Click(object sender, EventArgs e)
        {
            if(isOpen)
            {
                try // 写串口数据 
                {
                    sp.WriteLine(lbxSendData.Text);
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
            if(!CheckSenddata()) // 检测要发送的数据 
            {
                MessageBox.Show("请输入要发送的数据！", "错误提示！");
                return;
            }
            
        }
    }
}
