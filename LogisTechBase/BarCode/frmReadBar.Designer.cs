namespace LogisTechBase
{
    partial class frmReadBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReadBar));
            this.btnSerialPortConfig = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_opencom = new System.Windows.Forms.Button();
            this.ProgressControl1 = new LogisTechBase.MatrixCircularProgressControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSerialPortConfig
            // 
            this.btnSerialPortConfig.Location = new System.Drawing.Point(459, 177);
            this.btnSerialPortConfig.Name = "btnSerialPortConfig";
            this.btnSerialPortConfig.Size = new System.Drawing.Size(85, 29);
            this.btnSerialPortConfig.TabIndex = 38;
            this.btnSerialPortConfig.Text = "串口设置";
            this.btnSerialPortConfig.UseVisualStyleBackColor = true;
            this.btnSerialPortConfig.Visible = false;
            this.btnSerialPortConfig.Click += new System.EventHandler(this.btnSerialPortConfig_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(459, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 29);
            this.button1.TabIndex = 40;
            this.button1.Text = "开始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 21;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(413, 444);
            this.dataGridView1.TabIndex = 41;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 464);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(435, 466);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 10);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(459, 488);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 29);
            this.button2.TabIndex = 44;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_opencom
            // 
            this.btn_opencom.Location = new System.Drawing.Point(459, 126);
            this.btn_opencom.Name = "btn_opencom";
            this.btn_opencom.Size = new System.Drawing.Size(85, 29);
            this.btn_opencom.TabIndex = 45;
            this.btn_opencom.Text = "打开串口";
            this.btn_opencom.UseVisualStyleBackColor = true;
            this.btn_opencom.Click += new System.EventHandler(this.btn_opencom_Click);
            // 
            // ProgressControl1
            // 
            this.ProgressControl1.BackColor = System.Drawing.Color.Transparent;
            this.ProgressControl1.Interval = 60;
            this.ProgressControl1.Location = new System.Drawing.Point(472, 70);
            this.ProgressControl1.MinimumSize = new System.Drawing.Size(28, 28);
            this.ProgressControl1.Name = "ProgressControl1";
            this.ProgressControl1.Rotation = LogisTechBase.MatrixCircularProgressControl.Direction.CLOCKWISE;
            this.ProgressControl1.Size = new System.Drawing.Size(56, 50);
            this.ProgressControl1.StartAngle = 270F;
            this.ProgressControl1.TabIndex = 46;
            this.ProgressControl1.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            // 
            // frmReadBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 529);
            this.Controls.Add(this.ProgressControl1);
            this.Controls.Add(this.btn_opencom);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSerialPortConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReadBar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "条码读取实验";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSerialPortConfig;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_opencom;
        private MatrixCircularProgressControl ProgressControl1;
    }
}