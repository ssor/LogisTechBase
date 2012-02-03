namespace LogisTechBase
{
    partial class frmBarcodeTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBarcodeTest));
            this.barcode = new System.Windows.Forms.PictureBox();
            this.txtEncoded = new System.Windows.Forms.TextBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslEncodedType = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblLibraryVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblCredits = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbRotateFlip = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveXML = new System.Windows.Forms.Button();
            this.lblLabelLocation = new System.Windows.Forms.Label();
            this.btnLoadXML = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnEncode = new System.Windows.Forms.Button();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.cbLabelLocation = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.cbBarcodeAlign = new System.Windows.Forms.ComboBox();
            this.btnForeColor = new System.Windows.Forms.Button();
            this.lblEncodingTime = new System.Windows.Forms.Label();
            this.chkGenerateLabel = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbEncodeType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.barcode)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barcode
            // 
            this.barcode.BackColor = System.Drawing.Color.Transparent;
            this.barcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barcode.Location = new System.Drawing.Point(3, 17);
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(374, 321);
            this.barcode.TabIndex = 13;
            this.barcode.TabStop = false;
            // 
            // txtEncoded
            // 
            this.txtEncoded.Location = new System.Drawing.Point(6, 15);
            this.txtEncoded.Multiline = true;
            this.txtEncoded.Name = "txtEncoded";
            this.txtEncoded.ReadOnly = true;
            this.txtEncoded.Size = new System.Drawing.Size(368, 55);
            this.txtEncoded.TabIndex = 14;
            this.txtEncoded.TabStop = false;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(28, 37);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(163, 21);
            this.txtData.TabIndex = 1;
            this.txtData.Text = "038000356216";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "编码内容";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslEncodedType,
            this.tslblLibraryVersion,
            this.tslblCredits});
            this.statusStrip1.Location = new System.Drawing.Point(0, 487);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(754, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 30;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslEncodedType
            // 
            this.tsslEncodedType.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslEncodedType.Name = "tsslEncodedType";
            this.tsslEncodedType.Size = new System.Drawing.Size(4, 17);
            // 
            // tslblLibraryVersion
            // 
            this.tslblLibraryVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tslblLibraryVersion.Name = "tslblLibraryVersion";
            this.tslblLibraryVersion.Size = new System.Drawing.Size(735, 17);
            this.tslblLibraryVersion.Spring = true;
            // 
            // tslblCredits
            // 
            this.tslblCredits.Name = "tslblCredits";
            this.tslblCredits.Size = new System.Drawing.Size(0, 17);
            this.tslblCredits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(633, 172);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(101, 35);
            this.btnPrint.TabIndex = 54;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 53;
            this.label10.Text = "旋转角度";
            // 
            // cbRotateFlip
            // 
            this.cbRotateFlip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRotateFlip.FormattingEnabled = true;
            this.cbRotateFlip.Items.AddRange(new object[] {
            "Center",
            "Left",
            "Right"});
            this.cbRotateFlip.Location = new System.Drawing.Point(28, 131);
            this.cbRotateFlip.Name = "cbRotateFlip";
            this.cbRotateFlip.Size = new System.Drawing.Size(108, 20);
            this.cbRotateFlip.TabIndex = 52;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(633, 110);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "另存为";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveXML
            // 
            this.btnSaveXML.Location = new System.Drawing.Point(395, 559);
            this.btnSaveXML.Name = "btnSaveXML";
            this.btnSaveXML.Size = new System.Drawing.Size(76, 21);
            this.btnSaveXML.TabIndex = 46;
            this.btnSaveXML.Text = "保存 &XML";
            this.btnSaveXML.UseVisualStyleBackColor = true;
            this.btnSaveXML.Visible = false;
            this.btnSaveXML.Click += new System.EventHandler(this.btnSaveXML_Click);
            // 
            // lblLabelLocation
            // 
            this.lblLabelLocation.AutoSize = true;
            this.lblLabelLocation.Location = new System.Drawing.Point(25, 261);
            this.lblLabelLocation.Name = "lblLabelLocation";
            this.lblLabelLocation.Size = new System.Drawing.Size(53, 12);
            this.lblLabelLocation.TabIndex = 48;
            this.lblLabelLocation.Text = "码值位置";
            // 
            // btnLoadXML
            // 
            this.btnLoadXML.Location = new System.Drawing.Point(395, 586);
            this.btnLoadXML.Name = "btnLoadXML";
            this.btnLoadXML.Size = new System.Drawing.Size(77, 21);
            this.btnLoadXML.TabIndex = 47;
            this.btnLoadXML.Text = "加载 XML";
            this.btnLoadXML.UseVisualStyleBackColor = true;
            this.btnLoadXML.Visible = false;
            this.btnLoadXML.Click += new System.EventHandler(this.btnLoadXML_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 50;
            this.label8.Text = "对齐方式";
            // 
            // btnEncode
            // 
            this.btnEncode.Location = new System.Drawing.Point(633, 48);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(101, 35);
            this.btnEncode.TabIndex = 3;
            this.btnEncode.Text = "编码";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(71, 180);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(35, 21);
            this.txtHeight.TabIndex = 44;
            this.txtHeight.Text = "150";
            // 
            // cbLabelLocation
            // 
            this.cbLabelLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLabelLocation.FormattingEnabled = true;
            this.cbLabelLocation.Items.AddRange(new object[] {
            "BottomCenter",
            "BottomLeft",
            "BottomRight",
            "TopCenter",
            "TopLeft",
            "TopRight"});
            this.cbLabelLocation.Location = new System.Drawing.Point(28, 276);
            this.cbLabelLocation.Name = "cbLabelLocation";
            this.cbLabelLocation.Size = new System.Drawing.Size(90, 20);
            this.cbLabelLocation.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 38;
            this.label4.Text = "前景色";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 42;
            this.label6.Text = "高";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(28, 180);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(35, 21);
            this.txtWidth.TabIndex = 43;
            this.txtWidth.Text = "300";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 41;
            this.label7.Text = "宽";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 357);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 39;
            this.label5.Text = "背景色";
            // 
            // btnBackColor
            // 
            this.btnBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackColor.Location = new System.Drawing.Point(28, 372);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(90, 21);
            this.btnBackColor.TabIndex = 37;
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // cbBarcodeAlign
            // 
            this.cbBarcodeAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBarcodeAlign.FormattingEnabled = true;
            this.cbBarcodeAlign.Items.AddRange(new object[] {
            "Center",
            "Left",
            "Right"});
            this.cbBarcodeAlign.Location = new System.Drawing.Point(28, 227);
            this.cbBarcodeAlign.Name = "cbBarcodeAlign";
            this.cbBarcodeAlign.Size = new System.Drawing.Size(67, 20);
            this.cbBarcodeAlign.TabIndex = 49;
            // 
            // btnForeColor
            // 
            this.btnForeColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForeColor.Location = new System.Drawing.Point(28, 325);
            this.btnForeColor.Name = "btnForeColor";
            this.btnForeColor.Size = new System.Drawing.Size(90, 21);
            this.btnForeColor.TabIndex = 36;
            this.btnForeColor.UseVisualStyleBackColor = true;
            this.btnForeColor.Click += new System.EventHandler(this.btnForeColor_Click);
            // 
            // lblEncodingTime
            // 
            this.lblEncodingTime.AutoSize = true;
            this.lblEncodingTime.Location = new System.Drawing.Point(108, 156);
            this.lblEncodingTime.Name = "lblEncodingTime";
            this.lblEncodingTime.Size = new System.Drawing.Size(0, 12);
            this.lblEncodingTime.TabIndex = 45;
            // 
            // chkGenerateLabel
            // 
            this.chkGenerateLabel.AutoSize = true;
            this.chkGenerateLabel.Location = new System.Drawing.Point(125, 21);
            this.chkGenerateLabel.Name = "chkGenerateLabel";
            this.chkGenerateLabel.Size = new System.Drawing.Size(72, 16);
            this.chkGenerateLabel.TabIndex = 40;
            this.chkGenerateLabel.Text = "显示码值";
            this.chkGenerateLabel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "编码类型";
            // 
            // cbEncodeType
            // 
            this.cbEncodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEncodeType.FormattingEnabled = true;
            this.cbEncodeType.ItemHeight = 12;
            this.cbEncodeType.Items.AddRange(new object[] {
            "UPC-A",
            "UPC-E",
            "UPC 2 Digit Ext.",
            "UPC 5 Digit Ext.",
            "EAN-13",
            "JAN-13",
            "EAN-8",
            "ITF-14",
            "Interleaved 2 of 5",
            "Standard 2 of 5",
            "Codabar",
            "PostNet",
            "Bookland/ISBN",
            "Code 11",
            "Code 39",
            "Code 39 Extended",
            "Code 93",
            "Code 128",
            "Code 128-A",
            "Code 128-B",
            "Code 128-C",
            "LOGMARS",
            "MSI",
            "Telepen"});
            this.cbEncodeType.Location = new System.Drawing.Point(28, 82);
            this.cbEncodeType.Name = "cbEncodeType";
            this.cbEncodeType.Size = new System.Drawing.Size(108, 20);
            this.cbEncodeType.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 51;
            this.label9.Text = "x";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.barcode);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 341);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "条形码";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.cbRotateFlip);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtData);
            this.groupBox3.Controls.Add(this.cbEncodeType);
            this.groupBox3.Controls.Add(this.lblLabelLocation);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.chkGenerateLabel);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lblEncodingTime);
            this.groupBox3.Controls.Add(this.txtHeight);
            this.groupBox3.Controls.Add(this.btnForeColor);
            this.groupBox3.Controls.Add(this.cbLabelLocation);
            this.groupBox3.Controls.Add(this.cbBarcodeAlign);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnBackColor);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtWidth);
            this.groupBox3.Location = new System.Drawing.Point(395, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(217, 418);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "输入信息";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEncoded);
            this.groupBox1.Location = new System.Drawing.Point(12, 354);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 76);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "码值";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(633, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 29);
            this.button1.TabIndex = 56;
            this.button1.Text = "退出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(611, 420);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 10);
            this.groupBox4.TabIndex = 57;
            this.groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(611, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 10);
            this.groupBox5.TabIndex = 57;
            this.groupBox5.TabStop = false;
            // 
            // frmBarcodeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 509);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSaveXML);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.btnLoadXML);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBarcodeTest";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "条形码编码实验";
            this.Load += new System.EventHandler(this.TestApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barcode)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox barcode;
        private System.Windows.Forms.TextBox txtEncoded;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslEncodedType;
        private System.Windows.Forms.ComboBox cbEncodeType;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripStatusLabel tslblCredits;
        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.Button btnForeColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkGenerateLabel;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblEncodingTime;
        private System.Windows.Forms.Button btnSaveXML;
        private System.Windows.Forms.Button btnLoadXML;
        private System.Windows.Forms.ToolStripStatusLabel tslblLibraryVersion;
        private System.Windows.Forms.Label lblLabelLocation;
        private System.Windows.Forms.ComboBox cbLabelLocation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbBarcodeAlign;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbRotateFlip;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}

