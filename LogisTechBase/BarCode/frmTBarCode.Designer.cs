namespace LogisTechBase
{
    partial class frmTBarCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTBarCode));
            this.barcodeControl1 = new TECIT.TBarCode.Windows.BarcodeControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBarCodeType = new System.Windows.Forms.ComboBox();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // barcodeControl1
            // 
            this.barcodeControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.barcodeControl1.Barcode.BarWidthReduction = 0;
            this.barcodeControl1.Barcode.Data = "6901009901753";
            this.barcodeControl1.Barcode.Dpi = -1;
            this.barcodeControl1.Barcode.ModuleWidth = -1;
            this.barcodeControl1.Barcode.QuietZoneBottom = 0;
            this.barcodeControl1.Barcode.QuietZoneLeft = 0;
            this.barcodeControl1.Barcode.QuietZoneRight = 0;
            this.barcodeControl1.Barcode.QuietZoneTop = 0;
            this.barcodeControl1.Barcode.TextBlockHeight = 0;
            this.barcodeControl1.Barcode.TextBlockWidth = 0;
            this.barcodeControl1.Barcode.TextPosition = ((System.Drawing.RectangleF)(resources.GetObject("resource.TextPosition")));
            this.barcodeControl1.Barcode.TextPositionLeft = 0;
            this.barcodeControl1.Barcode.TextPositionTop = 0;
            this.barcodeControl1.Location = new System.Drawing.Point(12, 12);
            this.barcodeControl1.Name = "barcodeControl1";
            this.barcodeControl1.Size = new System.Drawing.Size(387, 128);
            this.barcodeControl1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "编码类型：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "编码内容：";
            // 
            // cmbBarCodeType
            // 
            this.cmbBarCodeType.FormattingEnabled = true;
            this.cmbBarCodeType.Location = new System.Drawing.Point(108, 161);
            this.cmbBarCodeType.Name = "cmbBarCodeType";
            this.cmbBarCodeType.Size = new System.Drawing.Size(187, 20);
            this.cmbBarCodeType.TabIndex = 4;
            this.cmbBarCodeType.SelectedIndexChanged += new System.EventHandler(this.cmbBarCodeType_SelectedIndexChanged);
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(108, 199);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(187, 21);
            this.txtBarCode.TabIndex = 5;
            this.txtBarCode.TextChanged += new System.EventHandler(this.txtBarCode_TextChanged);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(235, 299);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(75, 23);
            this.btnSaveImage.TabIndex = 6;
            this.btnSaveImage.Text = "保存为...";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(329, 300);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 7;
            this.btnQuit.Text = "退出";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(141, 300);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmTBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 337);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.cmbBarCodeType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.barcodeControl1);
            this.MaximizeBox = false;
            this.Name = "frmTBarCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "条形码";
            this.Load += new System.EventHandler(this.frmTBarCode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TECIT.TBarCode.Windows.BarcodeControl barcodeControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBarCodeType;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button btnPrint;
    }
}