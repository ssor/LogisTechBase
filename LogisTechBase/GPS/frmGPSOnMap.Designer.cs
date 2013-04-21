namespace LogisTechBase
{
    partial class frmGPSOnMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGPSOnMap));
            this.btnShowMap = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtMobileIndex = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.txtLng = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.matrixCircularProgressControl1 = new LogisTechBase.MatrixCircularProgressControl();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowMap
            // 
            this.btnShowMap.Location = new System.Drawing.Point(500, 147);
            this.btnShowMap.Name = "btnShowMap";
            this.btnShowMap.Size = new System.Drawing.Size(88, 28);
            this.btnShowMap.TabIndex = 3;
            this.btnShowMap.Text = "显示地图(&M)";
            this.btnShowMap.UseVisualStyleBackColor = true;
            this.btnShowMap.Click += new System.EventHandler(this.btnShowMap_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(312, 20);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(77, 21);
            this.txtPort.TabIndex = 15;
            this.txtPort.Text = "10000";
            // 
            // txtMobileIndex
            // 
            this.txtMobileIndex.Location = new System.Drawing.Point(97, 57);
            this.txtMobileIndex.Name = "txtMobileIndex";
            this.txtMobileIndex.Size = new System.Drawing.Size(106, 21);
            this.txtMobileIndex.TabIndex = 14;
            this.txtMobileIndex.Text = "J001";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(96, 19);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(173, 21);
            this.txtIP.TabIndex = 13;
            this.txtIP.Text = "www.motathink.com";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "端口：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "GPS终端编号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "服务IP地址：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMobileIndex);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 257);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 120);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数设置";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(500, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 28);
            this.button1.TabIndex = 17;
            this.button1.Text = "开始发送(&S)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(485, 367);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 10);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(500, 400);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 28);
            this.button3.TabIndex = 20;
            this.button3.Text = "退出(&X)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(335, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "注：从串口获得的GPS数据将被传送到服务器，以显示在地图上";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtLat);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtLng);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(467, 224);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "位置信息";
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(57, 77);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(187, 21);
            this.txtLat.TabIndex = 8;
            // 
            // txtLng
            // 
            this.txtLng.Location = new System.Drawing.Point(57, 33);
            this.txtLng.Name = "txtLng";
            this.txtLng.Size = new System.Drawing.Size(187, 21);
            this.txtLng.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "纬度：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "经度：";
            // 
            // matrixCircularProgressControl1
            // 
            this.matrixCircularProgressControl1.BackColor = System.Drawing.Color.Transparent;
            this.matrixCircularProgressControl1.Interval = 60;
            this.matrixCircularProgressControl1.Location = new System.Drawing.Point(500, 60);
            this.matrixCircularProgressControl1.MinimumSize = new System.Drawing.Size(28, 28);
            this.matrixCircularProgressControl1.Name = "matrixCircularProgressControl1";
            this.matrixCircularProgressControl1.Rotation = LogisTechBase.MatrixCircularProgressControl.Direction.CLOCKWISE;
            this.matrixCircularProgressControl1.Size = new System.Drawing.Size(77, 56);
            this.matrixCircularProgressControl1.StartAngle = 270F;
            this.matrixCircularProgressControl1.TabIndex = 18;
            this.matrixCircularProgressControl1.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            // 
            // frmGPSOnMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 440);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.matrixCircularProgressControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnShowMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGPSOnMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GPS地图操作实验";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowMap;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtMobileIndex;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private MatrixCircularProgressControl matrixCircularProgressControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.TextBox txtLng;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}