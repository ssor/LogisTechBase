using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Config;

namespace LogisTechBase
{
    public partial class frmReadBar : Form
    {
        private System.IO.Ports.SerialPort comport = new System.IO.Ports.SerialPort();//定义串口
        ISerialPortConfigItem ispci = ConfigManager.GetConfigItem(SerialPortConfigItemName.条码模块);
        private bool bClosing = false;
        bool isPortOpen = false;
        bool isReadingBarcode = false;
        InvokeDic _InvokeList = new InvokeDic();
        Timer _timer = new Timer();
        string barcodeCommand = "ff5555af1111111111";
        byte[] bytesCommandToWrite;

        DataTable dataTable = null;
        public frmReadBar()
        {
            InitializeComponent();

            this.comport.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(comport_DataReceived);
            this._timer.Interval = 500;
            this._timer.Tick += new EventHandler(_timer_Tick);

            MatchCollection mc = Regex.Matches(barcodeCommand, @"(?i)[\da-f]{2}");
            //MatchCollection mc = Regex.Matches(txt_Send.Text, @"(?i)[\da-f]{2}");
            List<byte> buf = new List<byte>();//填充到这个临时列表中
            //依次添加到列表中
            foreach (Match m in mc)
            {
                buf.Add(Byte.Parse(m.ToString(), System.Globalization.NumberStyles.HexNumber));
            }
            bytesCommandToWrite = buf.ToArray();


            dataTable = new DataTable();
            dataTable.Columns.Add("条码", typeof(string));
            dataTable.Columns.Add("时间", typeof(string));


            this.Shown += new EventHandler(frmReadBar_Shown);
        }

        void frmReadBar_Shown(object sender, EventArgs e)
        {
            this.updateText(string.Empty);
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            if (this.isReadingBarcode == true)
            {
                try
                {
                    //转换列表为数组后发送
                    comport.Write(bytesCommandToWrite, 0, bytesCommandToWrite.Length);
                    //this.comport.Write(barcodeCommand);
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine(
                        string.Format("frmReadBar._timer_Tick  ->  = {0}"
                        , ex.Message));
                }
            }
        }
        string buffer = string.Empty;
        void comport_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (this.bClosing == true)
            {
                return;
            }
            try
            {
                string temp = comport.ReadExisting();
                buffer += temp;
                Debug.WriteLine(
                    string.Format("frmReadBar.comport_DataReceived  ->  = {0}"
                    , buffer));
                if (buffer.IndexOf("\r\n") != -1)
                {
                    this.Invoke(new deleUpdateContorl(updateText), buffer);
                    buffer = string.Empty;
                }

            }
            catch (System.Exception ex)
            {
                Debug.WriteLine("frmReadBar -> comport_DataReceived  " + ex.Message);
            }
        }
        void updateText(string str)
        {
            if (!_InvokeList.CheckItem("updateText"))
            {
                return;
            }
            _InvokeList.SetItem("updateText", false);

            Debug.WriteLine(
                string.Format("frmReadBar.updateText  ->  = {0}"
                , str));
            if (str != string.Empty)
            {
                DataRow dr = this.dataTable.NewRow();
                dr["条码"] = str;
                dr["时间"] = DateTime.Now.ToString("");
                this.dataTable.Rows.InsertAt(dr, 0);
                //this.dataTable.Rows.Add(new object[] { str, DateTime.Now.ToString("") });
            }
            this.dataGridView1.DataSource = dataTable;
            DataGridViewColumnCollection columns = this.dataGridView1.Columns;
            columns[0].Width = 240;
            columns[1].Width = 150;
            _InvokeList.SetItem("updateText", true);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.isPortOpen == true)
            {
                MessageBox.Show("请先关闭串口！", "提示");
                return;
            }
            this.Close();
        }
        bool open_serialport()
        {
            bool bR = true;
            try
            {
                if (this.isPortOpen == false)
                {
                    bClosing = false;
                    // 设置串口参数
                    if (!comport.IsOpen)
                    {

                        if (ConfigManager.SetSerialPort(ref comport, ispci))
                        {

                            comport.Open();//尝试打开串口
                            this.btn_opencom.Text = "关闭串口";
                            this.btnSerialPortConfig.Enabled = false;
                            this.isPortOpen = true;
                            //bClosing = false;
                        }
                    }
                }
            }
            catch (Exception ex)//进行异常捕获
            {
                MessageBox.Show(ex.Message);
                bR = false;
            }
            return bR;
        }
        bool close_serialport()
        {
            bool bR = true;
            try
            {
                if (this.isPortOpen == true)
                {

                    bClosing = true;
                    bool bOk = false;
                    if (comport.IsOpen)
                    {
                        bOk = _InvokeList.ChekcAllItem();
                        // 如果没有全部完成，则要将消息处理让出，使Invoke有机会完成
                        while (!bOk)
                        {
                            Application.DoEvents();
                            bOk = _InvokeList.ChekcAllItem();
                        }
                        //打开时点击，则关闭串口
                        comport.Close();
                        this.btnSerialPortConfig.Enabled = true;
                        btn_opencom.Text = "打开串口";
                        this.isPortOpen = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                bR = false;
            }
            return bR;
        }
        private void btn_opencom_Click(object sender, EventArgs e)
        {
            if (this.isPortOpen == true)
            {
                this.close_serialport();
            }
            else
            {
                this.open_serialport();
            }
        }

        private void btnSerialPortConfig_Click(object sender, EventArgs e)
        {
            SerialPortConfig spc = new SerialPortConfig(this.ispci, "条码模块串口设置");
            spc.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.isReadingBarcode == false)//开始读取条码
            {
                if (this.isPortOpen == false)
                {
                    if (this.open_serialport() == true)
                    {
                        this.beginToReadBarcode();
                        this.ProgressControl1.Start();
                    }
                }
                else
                {
                    this.beginToReadBarcode();
                    this.ProgressControl1.Start();
                }
            }
            else//停止读取条码
            {
                this.isReadingBarcode = false;
                this.button1.Text = "开始";
                this._timer.Enabled = false;
                this.ProgressControl1.Stop();
            }
        }
        void beginToReadBarcode()
        {
            this.isReadingBarcode = true;
            this.button1.Text = "停止";
            // 循环发送命令
            this._timer.Enabled = true;

        }
    }
}
