namespace LogisTechBase
{
    partial class FrmRfidCheck_Server
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRfidCheck_Server));
            this.btn_stopserver = new System.Windows.Forms.Button();
            this.btn_startserver = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUncheckedCount = new System.Windows.Forms.Label();
            this.lblCheckedCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.btnResetCheckRecord = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_stopserver
            // 
            this.btn_stopserver.Location = new System.Drawing.Point(428, 76);
            this.btn_stopserver.Name = "btn_stopserver";
            this.btn_stopserver.Size = new System.Drawing.Size(102, 30);
            this.btn_stopserver.TabIndex = 11;
            this.btn_stopserver.Text = "停止(&T)";
            this.btn_stopserver.UseVisualStyleBackColor = true;
            this.btn_stopserver.Click += new System.EventHandler(this.btn_stopserver_Click_1);
            // 
            // btn_startserver
            // 
            this.btn_startserver.Location = new System.Drawing.Point(428, 29);
            this.btn_startserver.Name = "btn_startserver";
            this.btn_startserver.Size = new System.Drawing.Size(102, 30);
            this.btn_startserver.TabIndex = 10;
            this.btn_startserver.Text = "启动(&R)";
            this.btn_startserver.UseVisualStyleBackColor = true;
            this.btn_startserver.Click += new System.EventHandler(this.btn_startserver_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(463, 414);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(58, 21);
            this.txtPort.TabIndex = 36;
            this.txtPort.Text = "13000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 417);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 37;
            this.label2.Text = "端口：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(383, 406);
            this.dataGridView1.TabIndex = 38;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(428, 507);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 29);
            this.button1.TabIndex = 40;
            this.button1.Text = "退出(&X)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblUncheckedCount);
            this.groupBox3.Controls.Add(this.lblCheckedCount);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 463);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "已考勤人列表";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 45;
            this.label3.Text = "未考勤人数：";
            // 
            // lblUncheckedCount
            // 
            this.lblUncheckedCount.AutoSize = true;
            this.lblUncheckedCount.Location = new System.Drawing.Point(349, 438);
            this.lblUncheckedCount.Name = "lblUncheckedCount";
            this.lblUncheckedCount.Size = new System.Drawing.Size(29, 12);
            this.lblUncheckedCount.TabIndex = 45;
            this.lblUncheckedCount.Text = "1111";
            // 
            // lblCheckedCount
            // 
            this.lblCheckedCount.AutoSize = true;
            this.lblCheckedCount.Location = new System.Drawing.Point(81, 438);
            this.lblCheckedCount.Name = "lblCheckedCount";
            this.lblCheckedCount.Size = new System.Drawing.Size(29, 12);
            this.lblCheckedCount.TabIndex = 45;
            this.lblCheckedCount.Text = "1111";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "已考勤人数：";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(419, 466);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(294, 10);
            this.groupBox4.TabIndex = 44;
            this.groupBox4.TabStop = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(2, 535);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(41, 12);
            this.labelStatus.TabIndex = 45;
            this.labelStatus.Text = "label1";
            // 
            // btnResetCheckRecord
            // 
            this.btnResetCheckRecord.Location = new System.Drawing.Point(428, 194);
            this.btnResetCheckRecord.Name = "btnResetCheckRecord";
            this.btnResetCheckRecord.Size = new System.Drawing.Size(102, 30);
            this.btnResetCheckRecord.TabIndex = 46;
            this.btnResetCheckRecord.Text = "考勤重置(&N)";
            this.btnResetCheckRecord.UseVisualStyleBackColor = true;
            this.btnResetCheckRecord.Click += new System.EventHandler(this.btnResetCheckRecord_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(429, 148);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 30);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "保存结果(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmRfidCheck_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 553);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnResetCheckRecord);
            this.Controls.Add(this.btn_stopserver);
            this.Controls.Add(this.btn_startserver);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRfidCheck_Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考勤服务端";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Button btn_stopserver;
        private System.Windows.Forms.Button btn_startserver;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUncheckedCount;
        private System.Windows.Forms.Label lblCheckedCount;
        private System.Windows.Forms.Button btnResetCheckRecord;
        private System.Windows.Forms.Button btnSave;
    }
}