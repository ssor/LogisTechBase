namespace LogisTechBase
{
    partial class frmGPSReceiver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGPSReceiver));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLocations = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMobileIndex = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.matrixCircularProgressControl1 = new LogisTechBase.MatrixCircularProgressControl();
            this.btnShowMap = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(559, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "开始接收(&S)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLocations);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 377);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "接收到的GPS数据";
            // 
            // txtLocations
            // 
            this.txtLocations.BackColor = System.Drawing.Color.White;
            this.txtLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLocations.Location = new System.Drawing.Point(3, 17);
            this.txtLocations.Multiline = true;
            this.txtLocations.Name = "txtLocations";
            this.txtLocations.ReadOnly = true;
            this.txtLocations.Size = new System.Drawing.Size(511, 357);
            this.txtLocations.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(559, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "导出数据(&O)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "服务IP地址：";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(90, 408);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(117, 21);
            this.txtIP.TabIndex = 4;
            this.txtIP.Text = "www.motathink.com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 412);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "GPS终端编号：";
            // 
            // txtMobileIndex
            // 
            this.txtMobileIndex.Location = new System.Drawing.Point(417, 408);
            this.txtMobileIndex.Name = "txtMobileIndex";
            this.txtMobileIndex.Size = new System.Drawing.Size(106, 21);
            this.txtMobileIndex.TabIndex = 5;
            this.txtMobileIndex.Text = "J001";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(16, 436);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(455, 10);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(477, 436);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(144, 10);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(559, 462);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 28);
            this.button3.TabIndex = 7;
            this.button3.Text = "退出(&X)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "points";
            this.saveFileDialog1.Filter = "xml文件|*.xml";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 412);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "端口：";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(250, 409);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(77, 21);
            this.txtPort.TabIndex = 9;
            this.txtPort.Text = "10000";
            // 
            // matrixCircularProgressControl1
            // 
            this.matrixCircularProgressControl1.BackColor = System.Drawing.Color.Transparent;
            this.matrixCircularProgressControl1.Interval = 60;
            this.matrixCircularProgressControl1.Location = new System.Drawing.Point(563, 51);
            this.matrixCircularProgressControl1.MinimumSize = new System.Drawing.Size(28, 28);
            this.matrixCircularProgressControl1.Name = "matrixCircularProgressControl1";
            this.matrixCircularProgressControl1.Rotation = LogisTechBase.MatrixCircularProgressControl.Direction.CLOCKWISE;
            this.matrixCircularProgressControl1.Size = new System.Drawing.Size(77, 56);
            this.matrixCircularProgressControl1.StartAngle = 270F;
            this.matrixCircularProgressControl1.TabIndex = 8;
            this.matrixCircularProgressControl1.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            // 
            // btnShowMap
            // 
            this.btnShowMap.Location = new System.Drawing.Point(559, 164);
            this.btnShowMap.Name = "btnShowMap";
            this.btnShowMap.Size = new System.Drawing.Size(88, 28);
            this.btnShowMap.TabIndex = 2;
            this.btnShowMap.Text = "显示地图(&M)";
            this.btnShowMap.UseVisualStyleBackColor = true;
            this.btnShowMap.Visible = false;
            this.btnShowMap.Click += new System.EventHandler(this.btnShowMap_Click);
            // 
            // frmGPSReceiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 500);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtMobileIndex);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShowMap);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.matrixCircularProgressControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGPSReceiver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GPS数据接收实验";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLocations;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMobileIndex;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button3;
        private MatrixCircularProgressControl matrixCircularProgressControl1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnShowMap;
    }
}