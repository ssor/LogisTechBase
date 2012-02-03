namespace LogisTechBase
{
    partial class frmQRCodeEncode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQRCodeEncode));
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.checkBoxArtistic = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.qrCodeControl1 = new LogisTechBase.QrCodeControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxInput
            // 
            this.textBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInput.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxInput.Location = new System.Drawing.Point(410, 71);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(208, 24);
            this.textBoxInput.TabIndex = 0;
            this.textBoxInput.Text = "QRCode";
            this.textBoxInput.TextChanged += new System.EventHandler(this.textBoxInput_TextChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(533, 343);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(85, 24);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "保存图像";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkBoxArtistic
            // 
            this.checkBoxArtistic.AutoSize = true;
            this.checkBoxArtistic.Location = new System.Drawing.Point(410, 31);
            this.checkBoxArtistic.Name = "checkBoxArtistic";
            this.checkBoxArtistic.Size = new System.Drawing.Size(84, 16);
            this.checkBoxArtistic.TabIndex = 4;
            this.checkBoxArtistic.Text = "生成艺术码";
            this.checkBoxArtistic.UseVisualStyleBackColor = true;
            this.checkBoxArtistic.CheckedChanged += new System.EventHandler(this.checkBoxArtistic_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.qrCodeControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 362);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // qrCodeControl1
            // 
            this.qrCodeControl1.AutoSize = true;
            this.qrCodeControl1.Font = new System.Drawing.Font("Broadway", 8.25F);
            this.qrCodeControl1.Location = new System.Drawing.Point(15, 20);
            this.qrCodeControl1.Name = "qrCodeControl1";
            this.qrCodeControl1.Size = new System.Drawing.Size(176, 176);
            this.qrCodeControl1.TabIndex = 3;
            this.qrCodeControl1.Text = "QrCode";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(410, 373);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 10);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(533, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "退出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmQRCodeEncode
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(630, 440);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxArtistic);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQRCodeEncode";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "二维码编码实验";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonSave;
        private QrCodeControl qrCodeControl1;
        private System.Windows.Forms.CheckBox checkBoxArtistic;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
    }
}

