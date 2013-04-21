namespace LogisTechBase.rfidCheck
{
    partial class FrmRfidCheck_Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRfidCheck_Client));
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.matrixCircularProgressControl1 = new LogisTechBase.MatrixCircularProgressControl();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 46;
            this.label1.Text = "IP：";
            // 
            // txtIP
            // 
            this.txtIP.Enabled = false;
            this.txtIP.Location = new System.Drawing.Point(22, 47);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(118, 21);
            this.txtIP.TabIndex = 47;
            this.txtIP.Text = "192.168.1.100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 49;
            this.label3.Text = "端口号：";
            // 
            // txtPort
            // 
            this.txtPort.Enabled = false;
            this.txtPort.Location = new System.Drawing.Point(146, 47);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(88, 21);
            this.txtPort.TabIndex = 50;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(279, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 29);
            this.button1.TabIndex = 51;
            this.button1.Text = "开始(&O)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(13, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 88);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器参数：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(279, 383);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 29);
            this.button2.TabIndex = 55;
            this.button2.Text = "退出(&X)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(265, 360);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(125, 10);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(13, 383);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(153, 21);
            this.txtid.TabIndex = 57;
            this.txtid.Text = "000000000000000000003016";
            this.txtid.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(172, 383);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 29);
            this.button3.TabIndex = 55;
            this.button3.Text = "测试";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // matrixCircularProgressControl1
            // 
            this.matrixCircularProgressControl1.BackColor = System.Drawing.Color.Transparent;
            this.matrixCircularProgressControl1.Interval = 60;
            this.matrixCircularProgressControl1.Location = new System.Drawing.Point(292, 12);
            this.matrixCircularProgressControl1.MinimumSize = new System.Drawing.Size(28, 28);
            this.matrixCircularProgressControl1.Name = "matrixCircularProgressControl1";
            this.matrixCircularProgressControl1.Rotation = LogisTechBase.MatrixCircularProgressControl.Direction.CLOCKWISE;
            this.matrixCircularProgressControl1.Size = new System.Drawing.Size(64, 66);
            this.matrixCircularProgressControl1.StartAngle = 270F;
            this.matrixCircularProgressControl1.TabIndex = 58;
            this.matrixCircularProgressControl1.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.matrixCircularProgressControl1.Load += new System.EventHandler(this.matrixCircularProgressControl1_Load);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(13, 142);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(246, 227);
            this.txtLog.TabIndex = 59;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 60;
            this.label2.Text = "考勤记录：";
            // 
            // FrmRfidCheck_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 430);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.matrixCircularProgressControl1);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRfidCheck_Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考勤学生端";
            this.Load += new System.EventHandler(this.FrmRfidCheck_Client_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Button button3;
        private MatrixCircularProgressControl matrixCircularProgressControl1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label2;
    }
}