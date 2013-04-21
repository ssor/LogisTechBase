namespace LogisTechBase
{
    partial class frmGPSMonitoring
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGPSMonitoring));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MainMap = new GMap.NET.WindowsForms.GMapControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOff = new System.Windows.Forms.Button();
            this.btnOn = new System.Windows.Forms.Button();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.txtLng = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGoto = new System.Windows.Forms.Button();
            this.txtMobileIndex = new System.Windows.Forms.TextBox();
            this.btnSerialPortConfig = new System.Windows.Forms.Button();
            this.lbLat = new System.Windows.Forms.Label();
            this.lbLng = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbZoom = new System.Windows.Forms.TrackBar();
            this.cboxShow = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnShowPoint = new System.Windows.Forms.Button();
            this.dgvImportedPoints = new System.Windows.Forms.DataGridView();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbZoom)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportedPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MainMap);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(857, 412);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "在线地图";
            // 
            // MainMap
            // 
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(3, 17);
            this.MainMap.MapType = GMap.NET.MapType.GoogleMapChina;
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 19;
            this.MainMap.MinZoom = 5;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.Position = ((GMap.NET.PointLatLng)(resources.GetObject("MainMap.Position")));
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(851, 392);
            this.MainMap.TabIndex = 0;
            this.MainMap.Zoom = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPort);
            this.groupBox2.Controls.Add(this.txtIP);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnOff);
            this.groupBox2.Controls.Add(this.btnOn);
            this.groupBox2.Controls.Add(this.txtLat);
            this.groupBox2.Controls.Add(this.txtLng);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnGoto);
            this.groupBox2.Controls.Add(this.txtMobileIndex);
            this.groupBox2.Location = new System.Drawing.Point(12, 423);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(857, 101);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(271, 63);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(133, 21);
            this.txtPort.TabIndex = 25;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(80, 62);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(148, 21);
            this.txtIP.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "端口：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(420, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "GPS终端编号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "服务IP地址：";
            // 
            // btnOff
            // 
            this.btnOff.Enabled = false;
            this.btnOff.Location = new System.Drawing.Point(738, 62);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(113, 23);
            this.btnOff.TabIndex = 19;
            this.btnOff.Text = "断开GPS终端（&D)";
            this.btnOff.UseVisualStyleBackColor = true;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            // 
            // btnOn
            // 
            this.btnOn.Location = new System.Drawing.Point(608, 62);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(113, 23);
            this.btnOn.TabIndex = 18;
            this.btnOn.Text = "连接GPS终端（&C)";
            this.btnOn.UseVisualStyleBackColor = true;
            this.btnOn.Click += new System.EventHandler(this.btnOn_Click);
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(273, 19);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(131, 21);
            this.txtLat.TabIndex = 4;
            // 
            // txtLng
            // 
            this.txtLng.Location = new System.Drawing.Point(44, 20);
            this.txtLng.Name = "txtLng";
            this.txtLng.Size = new System.Drawing.Size(184, 21);
            this.txtLng.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "纬度：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "经度：";
            // 
            // btnGoto
            // 
            this.btnGoto.Location = new System.Drawing.Point(418, 18);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(88, 23);
            this.btnGoto.TabIndex = 19;
            this.btnGoto.Text = "去此位置(&G)";
            this.btnGoto.UseVisualStyleBackColor = true;
            this.btnGoto.Click += new System.EventHandler(this.btnGoto_Click);
            // 
            // txtMobileIndex
            // 
            this.txtMobileIndex.Location = new System.Drawing.Point(507, 62);
            this.txtMobileIndex.Name = "txtMobileIndex";
            this.txtMobileIndex.Size = new System.Drawing.Size(87, 21);
            this.txtMobileIndex.TabIndex = 24;
            // 
            // btnSerialPortConfig
            // 
            this.btnSerialPortConfig.Location = new System.Drawing.Point(548, 692);
            this.btnSerialPortConfig.Name = "btnSerialPortConfig";
            this.btnSerialPortConfig.Size = new System.Drawing.Size(75, 23);
            this.btnSerialPortConfig.TabIndex = 20;
            this.btnSerialPortConfig.Text = "串口设置";
            this.btnSerialPortConfig.UseVisualStyleBackColor = true;
            this.btnSerialPortConfig.Visible = false;
            this.btnSerialPortConfig.Click += new System.EventHandler(this.button4_Click);
            // 
            // lbLat
            // 
            this.lbLat.AutoSize = true;
            this.lbLat.Location = new System.Drawing.Point(43, 41);
            this.lbLat.Name = "lbLat";
            this.lbLat.Size = new System.Drawing.Size(41, 12);
            this.lbLat.TabIndex = 16;
            this.lbLat.Text = "label5";
            // 
            // lbLng
            // 
            this.lbLng.AutoSize = true;
            this.lbLng.Location = new System.Drawing.Point(43, 20);
            this.lbLng.Name = "lbLng";
            this.lbLng.Size = new System.Drawing.Size(47, 12);
            this.lbLng.TabIndex = 15;
            this.lbLng.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "纬度：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(174, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "度";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(176, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "经度：";
            // 
            // tbZoom
            // 
            this.tbZoom.Location = new System.Drawing.Point(875, 15);
            this.tbZoom.Maximum = 19;
            this.tbZoom.Minimum = 5;
            this.tbZoom.Name = "tbZoom";
            this.tbZoom.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbZoom.Size = new System.Drawing.Size(45, 402);
            this.tbZoom.TabIndex = 4;
            this.tbZoom.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbZoom.Value = 8;
            this.tbZoom.ValueChanged += new System.EventHandler(this.tbZoom_ValueChanged);
            // 
            // cboxShow
            // 
            this.cboxShow.AutoSize = true;
            this.cboxShow.Location = new System.Drawing.Point(422, 696);
            this.cboxShow.Name = "cboxShow";
            this.cboxShow.Size = new System.Drawing.Size(96, 16);
            this.cboxShow.TabIndex = 20;
            this.cboxShow.Text = "在地图中显示";
            this.cboxShow.UseVisualStyleBackColor = true;
            this.cboxShow.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lbLng);
            this.groupBox5.Controls.Add(this.lbLat);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Location = new System.Drawing.Point(229, 704);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(210, 63);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "地图中心点坐标";
            this.groupBox5.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(787, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 10);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 28);
            this.button1.TabIndex = 22;
            this.button1.Text = "导入点数据(&I)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnShowPoint);
            this.groupBox4.Controls.Add(this.dgvImportedPoints);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Location = new System.Drawing.Point(15, 530);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(854, 139);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "数据导入";
            // 
            // btnShowPoint
            // 
            this.btnShowPoint.Location = new System.Drawing.Point(16, 63);
            this.btnShowPoint.Name = "btnShowPoint";
            this.btnShowPoint.Size = new System.Drawing.Size(94, 28);
            this.btnShowPoint.TabIndex = 24;
            this.btnShowPoint.Text = "显示到地图(&S)";
            this.btnShowPoint.UseVisualStyleBackColor = true;
            this.btnShowPoint.Click += new System.EventHandler(this.btnShowPoint_Click);
            // 
            // dgvImportedPoints
            // 
            this.dgvImportedPoints.ColumnHeadersHeight = 25;
            this.dgvImportedPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvImportedPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.index,
            this.cTime,
            this.cLon,
            this.clat});
            this.dgvImportedPoints.Location = new System.Drawing.Point(132, 10);
            this.dgvImportedPoints.Name = "dgvImportedPoints";
            this.dgvImportedPoints.ReadOnly = true;
            this.dgvImportedPoints.RowHeadersWidth = 10;
            this.dgvImportedPoints.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvImportedPoints.RowTemplate.Height = 23;
            this.dgvImportedPoints.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvImportedPoints.Size = new System.Drawing.Size(716, 123);
            this.dgvImportedPoints.TabIndex = 23;
            // 
            // index
            // 
            this.index.Frozen = true;
            this.index.HeaderText = "序号";
            this.index.Name = "index";
            this.index.ReadOnly = true;
            this.index.Width = 35;
            // 
            // cTime
            // 
            this.cTime.Frozen = true;
            this.cTime.HeaderText = "时间";
            this.cTime.Name = "cTime";
            this.cTime.ReadOnly = true;
            this.cTime.Width = 170;
            // 
            // cLon
            // 
            this.cLon.Frozen = true;
            this.cLon.HeaderText = "经度";
            this.cLon.Name = "cLon";
            this.cLon.ReadOnly = true;
            this.cLon.Width = 250;
            // 
            // clat
            // 
            this.clat.Frozen = true;
            this.clat.HeaderText = "纬度";
            this.clat.Name = "clat";
            this.clat.ReadOnly = true;
            this.clat.Width = 250;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(770, 685);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 27);
            this.button2.TabIndex = 25;
            this.button2.Text = "退出（&X)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmGPSMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 726);
            this.Controls.Add(this.btnSerialPortConfig);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cboxShow);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.tbZoom);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGPSMonitoring";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GIS实验";
            this.Load += new System.EventHandler(this.frmGPSExperiment_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGPSExperiment_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbZoom)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportedPoints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtLng;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbLat;
        private System.Windows.Forms.Label lbLng;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGoto;
        private System.Windows.Forms.Button btnOff;
        private System.Windows.Forms.Button btnOn;
        private System.Windows.Forms.TrackBar tbZoom;
        private GMap.NET.WindowsForms.GMapControl MainMap;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cboxShow;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvImportedPoints;
        private System.Windows.Forms.Button btnShowPoint;
        private System.Windows.Forms.Button btnSerialPortConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLon;
        private System.Windows.Forms.DataGridViewTextBoxColumn clat;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMobileIndex;
    }
}