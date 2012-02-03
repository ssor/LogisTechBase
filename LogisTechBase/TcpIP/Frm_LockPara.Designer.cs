namespace LogisTechBase
{
    partial class Frm_LockPara
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_LockPara));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_Kill = new System.Windows.Forms.ComboBox();
            this.cmb_accesspsw = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmb_UII = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmb_TID = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmb_User = new System.Windows.Forms.ComboBox();
            this.btn_createlockpara = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_Kill);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "销毁密码";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmb_Kill
            // 
            this.cmb_Kill.FormattingEnabled = true;
            this.cmb_Kill.Items.AddRange(new object[] {
            "不锁定",
            "开放状态下锁定",
            "永久锁定"});
            this.cmb_Kill.Location = new System.Drawing.Point(14, 20);
            this.cmb_Kill.Name = "cmb_Kill";
            this.cmb_Kill.Size = new System.Drawing.Size(121, 20);
            this.cmb_Kill.TabIndex = 1;
            // 
            // cmb_accesspsw
            // 
            this.cmb_accesspsw.FormattingEnabled = true;
            this.cmb_accesspsw.Items.AddRange(new object[] {
            "不锁定",
            "开放状态下锁定",
            "永久锁定"});
            this.cmb_accesspsw.Location = new System.Drawing.Point(14, 20);
            this.cmb_accesspsw.Name = "cmb_accesspsw";
            this.cmb_accesspsw.Size = new System.Drawing.Size(121, 20);
            this.cmb_accesspsw.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmb_accesspsw);
            this.groupBox2.Location = new System.Drawing.Point(171, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 55);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "存取密码";
            // 
            // cmb_UII
            // 
            this.cmb_UII.FormattingEnabled = true;
            this.cmb_UII.Items.AddRange(new object[] {
            "不锁定",
            "开放状态下锁定",
            "永久锁定"});
            this.cmb_UII.Location = new System.Drawing.Point(14, 20);
            this.cmb_UII.Name = "cmb_UII";
            this.cmb_UII.Size = new System.Drawing.Size(121, 20);
            this.cmb_UII.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmb_UII);
            this.groupBox3.Location = new System.Drawing.Point(12, 76);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(141, 55);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "UII 空间锁定";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmb_TID);
            this.groupBox4.Location = new System.Drawing.Point(171, 76);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(141, 55);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "TID 空间锁定";
            // 
            // cmb_TID
            // 
            this.cmb_TID.FormattingEnabled = true;
            this.cmb_TID.Items.AddRange(new object[] {
            "不锁定",
            "开放状态下锁定",
            "永久锁定"});
            this.cmb_TID.Location = new System.Drawing.Point(14, 20);
            this.cmb_TID.Name = "cmb_TID";
            this.cmb_TID.Size = new System.Drawing.Size(121, 20);
            this.cmb_TID.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmb_User);
            this.groupBox5.Location = new System.Drawing.Point(12, 149);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(141, 55);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "用户空间锁定";
            // 
            // cmb_User
            // 
            this.cmb_User.FormattingEnabled = true;
            this.cmb_User.Items.AddRange(new object[] {
            "不锁定",
            "开放状态下锁定",
            "永久锁定"});
            this.cmb_User.Location = new System.Drawing.Point(14, 20);
            this.cmb_User.Name = "cmb_User";
            this.cmb_User.Size = new System.Drawing.Size(121, 20);
            this.cmb_User.TabIndex = 1;
            // 
            // btn_createlockpara
            // 
            this.btn_createlockpara.Location = new System.Drawing.Point(200, 143);
            this.btn_createlockpara.Name = "btn_createlockpara";
            this.btn_createlockpara.Size = new System.Drawing.Size(87, 23);
            this.btn_createlockpara.TabIndex = 5;
            this.btn_createlockpara.Text = "生成";
            this.btn_createlockpara.UseVisualStyleBackColor = true;
            this.btn_createlockpara.Click += new System.EventHandler(this.btn_createlockpara_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(200, 177);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(87, 23);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Frm_LockPara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 218);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_createlockpara);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_LockPara";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "锁定参数设置";
            this.Load += new System.EventHandler(this.Frm_LockPara_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmb_Kill;
        private System.Windows.Forms.ComboBox cmb_accesspsw;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmb_UII;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmb_TID;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cmb_User;
        private System.Windows.Forms.Button btn_createlockpara;
        private System.Windows.Forms.Button btn_cancel;
    }
}