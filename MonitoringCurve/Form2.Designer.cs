namespace MonitoringCurve
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.串口设置 = new System.Windows.Forms.GroupBox();
            this.btnOpenCom = new System.Windows.Forms.Button();
            this.btnCheckCom = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxParity = new System.Windows.Forms.ComboBox();
            this.cbxDataBit = new System.Windows.Forms.ComboBox();
            this.cbxStopBit = new System.Windows.Forms.ComboBox();
            this.cbxBandBate = new System.Windows.Forms.ComboBox();
            this.cbxCOMPort = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbnChar = new System.Windows.Forms.RadioButton();
            this.rbnHex = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbxReceData = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbxSendData = new System.Windows.Forms.ListBox();
            this.btnSentData = new System.Windows.Forms.Button();
            this.btnClearData = new System.Windows.Forms.Button();
            this.串口设置.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // 串口设置
            // 
            this.串口设置.Controls.Add(this.btnOpenCom);
            this.串口设置.Controls.Add(this.btnCheckCom);
            this.串口设置.Controls.Add(this.label5);
            this.串口设置.Controls.Add(this.label4);
            this.串口设置.Controls.Add(this.label3);
            this.串口设置.Controls.Add(this.label2);
            this.串口设置.Controls.Add(this.label1);
            this.串口设置.Controls.Add(this.cbxParity);
            this.串口设置.Controls.Add(this.cbxDataBit);
            this.串口设置.Controls.Add(this.cbxStopBit);
            this.串口设置.Controls.Add(this.cbxBandBate);
            this.串口设置.Controls.Add(this.cbxCOMPort);
            this.串口设置.Location = new System.Drawing.Point(21, 12);
            this.串口设置.Name = "串口设置";
            this.串口设置.Size = new System.Drawing.Size(226, 271);
            this.串口设置.TabIndex = 0;
            this.串口设置.TabStop = false;
            this.串口设置.Text = "串口设置";
            // 
            // btnOpenCom
            // 
            this.btnOpenCom.Location = new System.Drawing.Point(112, 216);
            this.btnOpenCom.Name = "btnOpenCom";
            this.btnOpenCom.Size = new System.Drawing.Size(75, 23);
            this.btnOpenCom.TabIndex = 11;
            this.btnOpenCom.Text = "打开串口";
            this.btnOpenCom.UseVisualStyleBackColor = true;
            this.btnOpenCom.Click += new System.EventHandler(this.BtnOpenCom_Click);
            // 
            // btnCheckCom
            // 
            this.btnCheckCom.Location = new System.Drawing.Point(20, 216);
            this.btnCheckCom.Name = "btnCheckCom";
            this.btnCheckCom.Size = new System.Drawing.Size(75, 23);
            this.btnCheckCom.TabIndex = 10;
            this.btnCheckCom.Text = "检测串口";
            this.btnCheckCom.UseVisualStyleBackColor = true;
            this.btnCheckCom.Click += new System.EventHandler(this.BtnCheckCom_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "数据位：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "奇偶校验：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "停止位：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "波特率：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "串口号：";
            // 
            // cbxParity
            // 
            this.cbxParity.FormattingEnabled = true;
            this.cbxParity.Location = new System.Drawing.Point(96, 151);
            this.cbxParity.Name = "cbxParity";
            this.cbxParity.Size = new System.Drawing.Size(110, 23);
            this.cbxParity.TabIndex = 4;
            // 
            // cbxDataBit
            // 
            this.cbxDataBit.FormattingEnabled = true;
            this.cbxDataBit.Location = new System.Drawing.Point(96, 122);
            this.cbxDataBit.Name = "cbxDataBit";
            this.cbxDataBit.Size = new System.Drawing.Size(110, 23);
            this.cbxDataBit.TabIndex = 3;
            // 
            // cbxStopBit
            // 
            this.cbxStopBit.FormattingEnabled = true;
            this.cbxStopBit.Location = new System.Drawing.Point(96, 93);
            this.cbxStopBit.Name = "cbxStopBit";
            this.cbxStopBit.Size = new System.Drawing.Size(110, 23);
            this.cbxStopBit.TabIndex = 2;
            // 
            // cbxBandBate
            // 
            this.cbxBandBate.FormattingEnabled = true;
            this.cbxBandBate.Location = new System.Drawing.Point(96, 64);
            this.cbxBandBate.Name = "cbxBandBate";
            this.cbxBandBate.Size = new System.Drawing.Size(110, 23);
            this.cbxBandBate.TabIndex = 1;
            // 
            // cbxCOMPort
            // 
            this.cbxCOMPort.FormattingEnabled = true;
            this.cbxCOMPort.Location = new System.Drawing.Point(96, 35);
            this.cbxCOMPort.Name = "cbxCOMPort";
            this.cbxCOMPort.Size = new System.Drawing.Size(110, 23);
            this.cbxCOMPort.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbnChar);
            this.groupBox2.Controls.Add(this.rbnHex);
            this.groupBox2.Location = new System.Drawing.Point(21, 289);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 134);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "显示类型";
            // 
            // rbnChar
            // 
            this.rbnChar.AutoSize = true;
            this.rbnChar.Location = new System.Drawing.Point(33, 35);
            this.rbnChar.Name = "rbnChar";
            this.rbnChar.Size = new System.Drawing.Size(88, 19);
            this.rbnChar.TabIndex = 2;
            this.rbnChar.TabStop = true;
            this.rbnChar.Text = "字符显示";
            this.rbnChar.UseVisualStyleBackColor = true;
            // 
            // rbnHex
            // 
            this.rbnHex.AutoSize = true;
            this.rbnHex.Location = new System.Drawing.Point(33, 75);
            this.rbnHex.Name = "rbnHex";
            this.rbnHex.Size = new System.Drawing.Size(82, 19);
            this.rbnHex.TabIndex = 3;
            this.rbnHex.TabStop = true;
            this.rbnHex.Text = "HEX显示";
            this.rbnHex.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbxReceData);
            this.groupBox3.Location = new System.Drawing.Point(274, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(570, 256);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据接收";
            // 
            // lbxReceData
            // 
            this.lbxReceData.FormattingEnabled = true;
            this.lbxReceData.ItemHeight = 15;
            this.lbxReceData.Location = new System.Drawing.Point(0, 24);
            this.lbxReceData.Name = "lbxReceData";
            this.lbxReceData.Size = new System.Drawing.Size(564, 229);
            this.lbxReceData.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbxSendData);
            this.groupBox4.Location = new System.Drawing.Point(274, 274);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(483, 149);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "数据发送";
            // 
            // lbxSendData
            // 
            this.lbxSendData.FormattingEnabled = true;
            this.lbxSendData.ItemHeight = 15;
            this.lbxSendData.Items.AddRange(new object[] {
            "234254246546",
            "565",
            "5656"});
            this.lbxSendData.Location = new System.Drawing.Point(6, 30);
            this.lbxSendData.MultiColumn = true;
            this.lbxSendData.Name = "lbxSendData";
            this.lbxSendData.ScrollAlwaysVisible = true;
            this.lbxSendData.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbxSendData.Size = new System.Drawing.Size(456, 109);
            this.lbxSendData.TabIndex = 1;
            // 
            // btnSentData
            // 
            this.btnSentData.Location = new System.Drawing.Point(763, 375);
            this.btnSentData.Name = "btnSentData";
            this.btnSentData.Size = new System.Drawing.Size(75, 23);
            this.btnSentData.TabIndex = 12;
            this.btnSentData.Text = "发送数据";
            this.btnSentData.UseVisualStyleBackColor = true;
            this.btnSentData.Click += new System.EventHandler(this.BtnSentData_Click);
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(763, 304);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(75, 23);
            this.btnClearData.TabIndex = 11;
            this.btnClearData.Text = "清空数据";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.BtnClearData_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 450);
            this.Controls.Add(this.btnSentData);
            this.Controls.Add(this.btnClearData);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.串口设置);
            this.Name = "Form2";
            this.Text = "串口助手";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.串口设置.ResumeLayout(false);
            this.串口设置.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox 串口设置;
        private System.Windows.Forms.Button btnOpenCom;
        private System.Windows.Forms.Button btnCheckCom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxParity;
        private System.Windows.Forms.ComboBox cbxDataBit;
        private System.Windows.Forms.ComboBox cbxStopBit;
        private System.Windows.Forms.ComboBox cbxBandBate;
        private System.Windows.Forms.ComboBox cbxCOMPort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbnChar;
        private System.Windows.Forms.RadioButton rbnHex;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lbxReceData;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnSentData;
        private System.Windows.Forms.Button btnClearData;
        public System.Windows.Forms.ListBox lbxSendData;
    }
}