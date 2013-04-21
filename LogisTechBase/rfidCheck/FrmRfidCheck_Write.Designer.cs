namespace LogisTechBase.rfidCheck
{
    partial class FrmRfidCheck_Write
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRfidCheck_Write));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EditTag = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnPersonManage = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.Label();
            this.lblEpc = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(862, 506);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(923, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 30);
            this.button1.TabIndex = 13;
            this.button1.Text = "关联标签(&L)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(923, 550);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(101, 30);
            this.button6.TabIndex = 35;
            this.button6.Text = "退出(&X)";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(868, 526);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "学生信息";
            // 
            // EditTag
            // 
            this.EditTag.Location = new System.Drawing.Point(923, 149);
            this.EditTag.Name = "EditTag";
            this.EditTag.Size = new System.Drawing.Size(101, 30);
            this.EditTag.TabIndex = 43;
            this.EditTag.Text = "编辑标签(&E)";
            this.EditTag.UseVisualStyleBackColor = true;
            this.EditTag.Visible = false;
            this.EditTag.Click += new System.EventHandler(this.EditTag_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(885, 525);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(157, 10);
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            // 
            // btnPersonManage
            // 
            this.btnPersonManage.Location = new System.Drawing.Point(923, 94);
            this.btnPersonManage.Name = "btnPersonManage";
            this.btnPersonManage.Size = new System.Drawing.Size(101, 30);
            this.btnPersonManage.TabIndex = 43;
            this.btnPersonManage.Text = "学生管理(&M)";
            this.btnPersonManage.UseVisualStyleBackColor = true;
            this.btnPersonManage.Click += new System.EventHandler(this.btnPersonManage_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Location = new System.Drawing.Point(12, 441);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(731, 28);
            this.groupBox5.TabIndex = 47;
            this.groupBox5.TabStop = false;
            this.groupBox5.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "label7";
            this.label7.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(884, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 10);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "邮箱：";
            this.label4.Visible = false;
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Location = new System.Drawing.Point(66, 58);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(0, 12);
            this.txtName.TabIndex = 8;
            this.txtName.Visible = false;
            // 
            // txtTel
            // 
            this.txtTel.AutoSize = true;
            this.txtTel.Location = new System.Drawing.Point(66, 89);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(0, 12);
            this.txtTel.TabIndex = 9;
            this.txtTel.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 40;
            this.label6.Text = "考勤码：";
            // 
            // txtMail
            // 
            this.txtMail.AutoSize = true;
            this.txtMail.Location = new System.Drawing.Point(66, 120);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(0, 12);
            this.txtMail.TabIndex = 10;
            this.txtMail.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "学号：";
            // 
            // txtId
            // 
            this.txtId.AutoSize = true;
            this.txtId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtId.Location = new System.Drawing.Point(75, 19);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(0, 12);
            this.txtId.TabIndex = 11;
            // 
            // lblEpc
            // 
            this.lblEpc.AutoSize = true;
            this.lblEpc.Location = new System.Drawing.Point(228, 19);
            this.lblEpc.Name = "lblEpc";
            this.lblEpc.Size = new System.Drawing.Size(0, 12);
            this.lblEpc.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "电话：";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "姓名：";
            this.label2.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblEpc);
            this.groupBox3.Controls.Add(this.txtId);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtMail);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtTel);
            this.groupBox3.Controls.Add(this.txtName);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(1003, 514);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(139, 47);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Visible = false;
            // 
            // FrmRfidCheck_Write
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 606);
            this.Controls.Add(this.btnPersonManage);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.EditTag);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRfidCheck_Write";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "标签初始化";
            this.Load += new System.EventHandler(this.FrmRfidCheck_Write_Load);
            this.Shown += new System.EventHandler(this.FrmRfidCheck_Write_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button EditTag;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnPersonManage;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label txtTel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtId;
        private System.Windows.Forms.Label lblEpc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}