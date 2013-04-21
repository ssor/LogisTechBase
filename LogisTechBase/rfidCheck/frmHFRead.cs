using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Config;
using System.Text.RegularExpressions;

namespace LogisTechBase
{
    public partial class frmHFRead : Form
    {
        private System.IO.Ports.SerialPort comport = new System.IO.Ports.SerialPort();//定义串口
        ISerialPortConfigItem ispci = ConfigManager.GetConfigItem(SerialPortConfigItemName.高频RFID串口设置);
        private bool bClosing = false;
        bool isPortOpen = false;
        bool isReading = false;
        InvokeDic _InvokeList = new InvokeDic();
        System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        DataTable dataTable = null;

        public frmHFRead()
        {
            InitializeComponent();


            //this.comport.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(comport_DataReceived);
            this._timer.Interval = 3000;
            this._timer.Tick += new EventHandler(_timer_Tick);


            dataTable = new DataTable();
            dataTable.Columns.Add("标签UID", typeof(string));
            dataTable.Columns.Add("协议类型", typeof(string));
            dataTable.Columns.Add("读取次数", typeof(int));
            dataTable.Columns.Add("读取时间", typeof(string));

            this.Shown += new EventHandler(frmHFRead_Shown);

        }

        void frmHFRead_Shown(object sender, EventArgs e)
        {
            this.refreshTable(string.Empty, string.Empty);
        }
        int currentProto = 1;
        void _timer_Tick(object sender, EventArgs e)
        {

            if (this.isReading == true)
            {
                string str2Write = string.Empty;
                switch (currentProto)
                {
                    case 1://tagit
                        if (this.ckbTagit.Checked)
                        {
                            str2Write = HFCommandItem.设置TAGIT协议;
                            this.comport.DataReceived -= comport_DataReceived;
                            this.comport.Write(str2Write);
                            str2Write = HFCommandItem.读取TAGIT协议标签;
                            this.comport.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(comport_DataReceived);
                            Debug.WriteLine(
                                string.Format("frmHFRead._timer_Tick  ->  = {0}"
                                , "读取TAGIT协议标签"));
                        }
                        break;
                    case 2://
                        if (this.ckb15693.Checked)
                        {
                            str2Write = HFCommandItem.设置15693协议;
                            this.comport.DataReceived -= comport_DataReceived;
                            this.comport.Write(str2Write);
                            str2Write = HFCommandItem.读取15693协议标签;
                            this.comport.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(comport_DataReceived);
                            Debug.WriteLine(
    string.Format("frmHFRead._timer_Tick  ->  = {0}"
    , "读取15693协议标签"));
                        }
                        break;
                    case 3://
                        if (this.ckb14443a.Checked)
                        {
                            str2Write = HFCommandItem.设置14443A协议;
                            this.comport.DataReceived -= comport_DataReceived;
                            this.comport.Write(str2Write);
                            str2Write = HFCommandItem.读取14443A协议标签;
                            this.comport.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(comport_DataReceived);
                            Debug.WriteLine(
string.Format("frmHFRead._timer_Tick  ->  = {0}"
, "读取14443A协议标签"));
                        }
                        break;
                    case 4://
                        if (this.ckb14443b.Checked)
                        {
                            str2Write = HFCommandItem.设置14443B协议;
                            this.comport.DataReceived -= comport_DataReceived;
                            this.comport.Write(str2Write);
                            str2Write = HFCommandItem.读取14443B协议标签;
                            this.comport.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(comport_DataReceived);
                            Debug.WriteLine(
string.Format("frmHFRead._timer_Tick  ->  = {0}"
, "读取14443B协议标签"));
                        }
                        break;
                }
                if (currentProto == 4)
                {
                    currentProto = 1;
                }
                else
                {
                    currentProto++;
                }
                try
                {
                    Thread.Sleep(300);
                    //转换列表为数组后发送
                    //comport.Write(bytesCommandToWrite, 0, bytesCommandToWrite.Length);
                    this.comport.Write(str2Write);
                }
                catch (System.Exception ex)
                {
                    Debug.WriteLine(
                        string.Format("frmHFRead._timer_Tick  ->  = {0}"
                        , ex.Message));
                }
            }
        }
        StringBuilder buffer = new StringBuilder();
        void protocal_parse(string data)
        {
            string strPro = string.Empty;
            buffer.Append(data);

            //解析返回的数据
            // 首先确定已经接收到的数据中含有指示命令和标签UID
            string currentData = buffer.ToString();
            Debug.WriteLine(
    string.Format("frmHFRead.comport_DataReceived  -> current buffer = {0}"
    , currentData));
            //处理1443A协议
            strPro = "14443A协议";
            //未读取到
            MatchCollection mc = Regex.Matches(currentData, @"0109000304A0010000[\r\n]+14443A REQA.[\r\n]+\(\)");
            if (mc.Count > 0)
            {
                Match m = mc[0];
                buffer.Replace(m.Value, "");
            }
            mc = Regex.Matches(currentData, @"0109000304A0010000[\r\n]+14443A REQA.[\r\n]+\(\w+\)\(\w+\)\(\w+\)\(\w+\)\[(?<tag>\w+)\]");
            foreach (Match m in mc)
            {
                string tag = m.Groups["tag"].Value;
                if (tag != string.Empty)
                {
                    this.Invoke(new deleControlInvoke(receiveNewTagInfo), new HFTagInfo(strPro, tag));
                }
                buffer.Replace(m.Value, "");
            }
            strPro = "14443B协议";
            mc = Regex.Matches(currentData, @"0109000304B0040000[\r\n]+14443B REQB.([\r\n]+\[\]){16}");
            if (mc.Count > 0)
            {
                Match m = mc[0];
                buffer.Replace(m.Value, "");
            }
            mc = Regex.Matches(currentData, @"0109000304B0040000[\r\n]+14443B REQB.[\r\n]+\[(?<tag>\w+)\]([\r\n]+\[\]){15}");
            foreach (Match m in mc)
            {
                string tag = m.Groups["tag"].Value;
                if (tag != string.Empty)
                {
                    this.Invoke(new deleControlInvoke(receiveNewTagInfo), new HFTagInfo(strPro, tag));
                }
                buffer.Replace(m.Value, "");
            }
            strPro = "15693协议";
            mc = Regex.Matches(currentData, @"010B000304142401000000[\r\n]+ISO 15693 Inventory request.[\r\n]+\[,\w+\]");
            if (mc.Count > 0)
            {
                Match m = mc[0];
                buffer.Replace(m.Value, "");
            }
            mc = Regex.Matches(currentData, @"010B000304142401000000[\r\n]+ISO 15693 Inventory request.[\r\n]+\[(?<tag>\w+),\w+\]");
            foreach (Match m in mc)
            {
                string tag = m.Groups["tag"].Value;
                if (tag != string.Empty)
                {
                    this.Invoke(new deleControlInvoke(receiveNewTagInfo), new HFTagInfo(strPro, tag));
                }
                buffer.Replace(m.Value, "");
            }

            //清楚无用信息，放置内存过大
            mc = Regex.Matches(currentData, @"010C00030410002101000000[\r\n]+Register write request.");
            if (mc.Count > 0)
            {
                Match m = mc[0];
                buffer.Replace(m.Value, "");
            }
            mc = Regex.Matches(currentData, @"010C00030410002101090000[\r\n]+Register write request.");
            if (mc.Count > 0)
            {
                Match m = mc[0];
                buffer.Replace(m.Value, "");
            }
            mc = Regex.Matches(currentData, @"010C000304100021010C0000[\r\n]+Register write request.");
            if (mc.Count > 0)
            {
                Match m = mc[0];
                buffer.Replace(m.Value, "");
            }
        }


        void comport_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (this.bClosing == true)
            {
                return;
            }
            try
            {
                string temp = comport.ReadExisting();
                //comport.re
                //int n = comport.BytesToRead;
                //先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致
                //byte[] buf = new byte[n];
                //声明一个临时数组存储当前来的串口数据
                //增加接收计数
                //comport.Read(buf, 0, n);
                this.protocal_parse(temp);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(
                    string.Format("frmHFRead.comport_DataReceived  -> exception = {0}"
                    , ex.Message));
            }
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

        void receiveNewTagInfo(object o)
        {
            HFTagInfo info = (HFTagInfo)o;
            this.refreshTable(info.标签ID, info.协议类型);
        }
        void refreshTable(string id, string proto)
        {
            if (!_InvokeList.CheckItem("refreshTable"))
            {
                return;
            }
            _InvokeList.SetItem("refreshTable", false);

            if (id != string.Empty)
            {
                DataRow[] rows = dataTable.Select("标签UID = '" + id + "'");
                if (rows.Length > 0)
                {
                    DataRow dr = rows[0];
                    int count = (int)dr["读取次数"];
                    count++;
                    //dr["读取次数"] = count++;
                    //dr["读取时间"] = DateTime.Now.ToString("");
                    DataRow drNew = this.dataTable.NewRow();
                    drNew["标签UID"] = dr["标签UID"];
                    drNew["协议类型"] = dr["协议类型"];
                    drNew["读取次数"] = count;
                    drNew["读取时间"] = DateTime.Now.ToString("HH:mm:ss");
                    dataTable.Rows.Remove(dr);//将新更改的行置顶
                    dataTable.Rows.InsertAt(drNew, 0);
                }
                else
                {

                    DataRow dr = this.dataTable.NewRow();
                    dr["标签UID"] = id;
                    dr["协议类型"] = proto;
                    dr["读取次数"] = 1;
                    dr["读取时间"] = DateTime.Now.ToString("HH:mm:ss");
                    this.dataTable.Rows.InsertAt(dr, 0);
                    //this.dataTable.Rows.Add(new object[] { str, DateTime.Now.ToString("") });
                }

            }
            this.dataGridView1.DataSource = dataTable;
            DataGridViewColumnCollection columns = this.dataGridView1.Columns;
            columns[0].Width = 240;
            columns[1].Width = 150;
            columns[2].Width = 100;
            columns[3].Width = 120;
            _InvokeList.SetItem("refreshTable", true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.isReading == false)//开始读取条码
            {
                if (this.isPortOpen == false)
                {
                    if (this.open_serialport() == true)
                    {
                        this.comport.Write(HFCommandItem.查询读写器状态);
                        this.beginToRead();
                        this.ProgressControl1.Start();
                    }
                }
                else
                {
                    this.beginToRead();
                    this.ProgressControl1.Start();
                }
            }
            else//停止读取条码
            {
                this.isReading = false;
                this.button1.Text = "开始";
                this._timer.Enabled = false;
                this.ProgressControl1.Stop();
            }
        }
        void beginToRead()
        {
            this.isReading = true;
            this.button1.Text = "停止";
            // 循环发送命令
            this._timer.Enabled = true;

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
                this._timer.Enabled = false;
            }
            else
            {
                this.open_serialport();
            }
        }

        private void btnSerialPortConfig_Click(object sender, EventArgs e)
        {
            SerialPortConfig spc = new SerialPortConfig(this.ispci, "高频RFID模块串口设置");
            spc.ShowDialog();
        }
        //测试协议解析
        private void button3_Click(object sender, EventArgs e)
        {
            string data = "0109000304A0010000 14443A REQA. (0200)(1CABF5FEBC)[1CABF5FEBC]";
            data = "010B000304142401000000 ISO 15693 Inventory request. [698D773E000104E0,5B]";
            data = "0109000304B0040000 14443B REQB.[5000000000D103860C008080][][][][][][][][][][][][][][][]";
            this.protocal_parse(data);
        }
    }

    public class HFTagInfo
    {
        public string 协议类型 = string.Empty;
        public string 标签ID = string.Empty;
        public HFTagInfo(string pro, string tag)
        {
            this.标签ID = tag;
            this.协议类型 = pro;
        }
    }
}
