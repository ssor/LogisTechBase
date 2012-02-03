using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TECIT.TBarCode;
using System.Drawing.Printing;

namespace LogisTechBase
{
    public partial class frmTBarCode : Form
    {
        public frmTBarCode()
        {
            InitializeComponent();

            // Initialize "Save File" dialog.
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.Filter =
              "Bitmap (*.BMP)|*.bmp"
              + "|CompuServe GIF (*.GIF)|*.gif"
              + "|Enhanced Metafile (*.EMF)|*.emf"
              + "|JPEG (*.JPG)|*.jpg"
              + "|PCX (*.PCX)|*.pcx"
              + "|PNG (*.PNG)|*.png"
              + "|TIFF (*.TIF)|*.tif";
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                string extension = System.IO.Path.GetExtension(filename);
                ImageType type;
                switch (extension.ToUpper())
                {
                    case ".BMP":
                        type = ImageType.Bmp;
                        break;
                    case ".GIF":
                        type = ImageType.Gif;
                        break;
                    case ".EMF":
                        type = ImageType.Emf;
                        break;
                    case ".JPG":
                        type = ImageType.Jpg;
                        break;
                    case ".PCX":
                        type = ImageType.Pcx;
                        break;
                    case ".PNG":
                        type = ImageType.Png;
                        break;
                    case ".TIF":
                        type = ImageType.Tif;
                        break;
                    default:
                        MessageBox.Show("The selected bitmap format is not supported.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
                barcodeControl1.Barcode.Draw(filename, type);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDialog1.Document = new PrintDocument();
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDialog1.Document.PrinterSettings = printDialog1.PrinterSettings;
                printDialog1.Document.PrintPage += PrintPage;
                printDialog1.Document.Print();
            }
        }
        // The PrintPage event is raised for each page which is printed.
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            // Get current printer resolution.
            float dpiX = ev.Graphics.DpiX;
            float dpiY = ev.Graphics.DpiY;

            //
            // Set bounding rectangle of barcode: 
            // Here we simply use a fixed barcode size. 
            // Better would be to use fixed module width, as shown in part 1.
            // Barcode position: X = 10 mm, Y = 10 mm.
            // Barcode size: Width = 100 mm, Height = 50 mm.
            // Millimeter values have to be converted to dots.
            //
            barcodeControl1.Barcode.BoundingRectangle = new Rectangle((int)(10 / 25.4 * dpiX),
                                                       (int)(10 / 25.4 * dpiY),
                                                       (int)(50 / 25.4 * dpiX),
                                                       (int)(30 / 25.4 * dpiY));

            // Draw barcode.
            barcodeControl1.Barcode.Draw(ev.Graphics);
        }

        private void frmTBarCode_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 112;i++ )
            {
                string strTemp = Enum.GetName(typeof(BarcodeType),i);
                this.cmbBarCodeType.Items.Add(strTemp);
            }
            this.cmbBarCodeType.SelectedIndex = 13;
        }

        private void cmbBarCodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSelectedBarcodeType =  this.cmbBarCodeType.SelectedItem.ToString();
            this.barcodeControl1.Barcode.BarcodeType = (BarcodeType)Enum.Parse(typeof(BarcodeType),strSelectedBarcodeType, true); 
        }

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            if (this.txtBarCode.Text!=null&&this.txtBarCode.Text.Length>0)
            {
                this.barcodeControl1.Text = txtBarCode.Text;
            }
        }
    }
}
