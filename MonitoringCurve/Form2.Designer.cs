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
            this.串口设置.SuspendLayout();
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
            this.btnOpenCom.AutoSize = true;
            this.btnOpenCom.Location = new System.Drawing.Point(112, 216);
            this.btnOpenCom.Name = "btnOpenCom";
            this.btnOpenCom.Size = new System.Drawing.Size(77, 25);
            this.btnOpenCom.TabIndex = 11;
            this.btnOpenCom.Text = "打开串口";
            this.btnOpenCom.UseVisualStyleBackColor = true;
            this.btnOpenCom.Click += new System.EventHandler(this.BtnOpenCom_Click);
            // 
            // btnCheckCom
            // 
            this.btnCheckCom.AutoSize = true;
            this.btnCheckCom.Location = new System.Drawing.Point(20, 216);
            this.btnCheckCom.Name = "btnCheckCom";
            this.btnCheckCom.Size = new System.Drawing.Size(77, 25);
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
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 303);
            this.Controls.Add(this.串口设置);
            this.Name = "Form2";
            this.Text = "串口助手";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.MdiChildActivate += new System.EventHandler(this.Form2_Load);
            this.串口设置.ResumeLayout(false);
            this.串口设置.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
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
    }
}