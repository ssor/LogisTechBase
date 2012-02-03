using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net;
using AsynchronousSocket;
using System.Threading;
using System.Text.RegularExpressions;

namespace LogisTechBase.rfidCheck
{
    /* 客户端流程说明：
     * 1 为防止客户端连接到阅读器时，阅读器正处于识别标签的状态，在form显示完成后
     *   首先发送停止识别标签的命令
     * 2 客户端开始考勤时，发送识别标签命令
     * 3 当识别到标签时，发送停止标签识别的命令，否则之后发送命令会无响应
     * 4 如果停止标签识别成功，则发送读取锁定密码区域的命令
     * 5 如果读取到数据成功，则将返回的epc发送到服务端
     * 6 回到2
     * 综观整个过程，如果接收停止标签识别消息，则有三种可能：
     *  form显示完成、客户端停止考勤、客户端要读取数据
     */
    public partial class FrmRfidCheck_Client : Form
    {
        //记录考勤成功的的epc，防止同一标签不断发送考勤信息
        List<string> epcList = new List<string>();
        InventoryStopState StopState = InventoryStopState.Initializing;
        //在窗口初始化完成后，会首先发送一个停止获取标签的stop命令，
        //在窗口关闭时，也会发送一个stop命令，此时bStartOrCloseStop为false
        bool bStartOrCloseStop = true; 
        // 记录已经发送向服务端，但是未得到回复的EPC，防止在处理过程中重复发送
        List<string> ProcessingepcList = new List<string>();

        public static ManualResetEvent EventEPCList = new ManualResetEvent(true);
        SerialPort comport = new SerialPort();
        List<byte> maxbuf = new List<byte>();

        //public Dictionary<string, bool> dicFormUpdatedList = new Dictionary<string, bool>();
        InvokeDic _UpdateList = new InvokeDic();
        RFIDHelper _RFIDHelper = new RFIDHelper();

        bool bRfidCheckClosed = true;//标识本地考勤服务是否已经关闭，如果为true，则表示已经关闭

        int _Port;
        string _IP;
        //System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        //System.Timers.Timer _timer = new System.Timers.Timer(1000);
        public FrmRfidCheck_Client()
        {
            InitializeComponent();
            this.labelStatus.Text = "";
            this.Shown += new EventHandler(FrmRfidCheck_Client_Shown);
            comport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            //使得Helper类可以向串口中写入数据
            _RFIDHelper.evtWriteToSerialPort += new deleVoid_Byte_Func(RFIDHelper_evtWriteToSerialPort);
            // 处理当前操作的状态
            _RFIDHelper.evtCardState += new deleVoid_RFIDEventType_Object_Func(_RFIDHelper_evtCardState);

            //_timer.Elapsed += new System.Timers.ElapsedEventHandler(_time_Elapsed);
            //_timer.Tick += new EventHandler(_timer_Tick);
            //_timer.Interval = 1000;

        }

        void _time_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            string readCommand =
            RFIDHelper.RmuReadDataCommandComposer(
                    RMU_CommandType.RMU_SingleReadData
                       , "12345678",
                       0,
                       2,
                       2,
                       null);
            _RFIDHelper.SendCommand(readCommand, RFIDEventType.RMU_SingleReadData);

        }

        void _timer_Tick(object sender, EventArgs e)
        {
            string readCommand =
                    RFIDHelper.RmuReadDataCommandComposer(
                        RMU_CommandType.RMU_SingleReadData
                           , "12345678",
                           0,
                           2,
                           2,
                           null);
            _RFIDHelper.SendCommand(readCommand, RFIDEventType.RMU_SingleReadData);

        }

        void FrmRfidCheck_Client_Shown(object sender, EventArgs e)
        {
            //StopState = InventoryStopState.Initializing;
            //_RFIDHelper.SendCommand(RFIDHelper.RFIDCommand_RMU_StopGet, RFIDEventType.RMU_StopGet);
        }
        void _RFIDHelper_evtCardState(RFIDEventType eventType, object o)
        {
            string value = "";
            switch ((int)eventType)
            {
                case (int)RFIDEventType.RMU_Exception:
                    if (null != o)
                    {

                    }
                    MessageBox.Show("设备尚未准备就绪！");
                    break;
                case (int)RFIDEventType.RMU_CardIsReady:
                    //_RFIDHelper.SendCommand(RFIDHelper.RFIDCommand_RMU_InventoryAnti3, RFIDEventType.RMU_InventoryAnti);
                   
                    break;
                case (int)RFIDEventType.RMU_InventoryAnti:
                    this.bRfidCheckClosed = false;
                    if (this.button1.InvokeRequired)
                    {
                        this.button1.Invoke(new deleUpdateContorl(this.UpdateButton1), "关闭");
                    }
                    else
                    {
                        this.button1.Text = "关闭";
                    }
                    if (null == o)
                    {
                        value = "正在检测标签...";
                    }
                    else
                        if ((string)o != "ok")
                        {
                            ////string id = RFIDHelper.GetIDFromEPC((string)o); 
                            ////value = "读取到学号：" + id;
                            //value = "读取到标签：" + (string)o;
                            ////读取密码段
                            //string readCommand = 
                            //    RFIDHelper.RmuReadDataCommandComposer(
                            //                        RMU_CommandType.RMU_SingleReadData
                            //                           , "12345678",
                            //                           0,
                            //                           2,
                            //                           2,
                            //                           null);
                            //_RFIDHelper.SendCommand(readCommand, RFIDEventType.RMU_SingleReadData);
                            ////CheckToRemoteServer(id);

                            this.StopState = InventoryStopState.StopForOtherCommand;
                            _RFIDHelper.SendCommand(RFIDHelper.RFIDCommand_RMU_StopGet
                                                    , RFIDEventType.RMU_StopGet);

                        }
                    if (this.labelStatus.InvokeRequired)
                    {
                        this.labelStatus.Invoke(new deleUpdateContorl(UpdateStatusLable), value);
                    }
                    else
                    {
                        //this.statusLabel.Text = value;
                        UpdateStatusLable(value);
                    }
                    break;
                case (int)RFIDEventType.RMU_SingleReadData:
                    if (null != o)
                    {
                        string data = (string)o;
                        int n = data.IndexOf("&");//data + & + uii
                        string uii = data.Substring(n + 1);
                        string epc = RFIDHelper.GetEPCFormUII(uii);
                        value = "读取到标签：" + uii;
                        if (this.labelStatus.InvokeRequired)
                        {
                            this.labelStatus.Invoke(new deleUpdateContorl(UpdateStatusLable), value);
                        }
                        else
                        {
                            //this.statusLabel.Text = value;
                            UpdateStatusLable(value);
                        }
                        //CheckToRemoteServer(epc);

                        //重新开始读取标签
                        _RFIDHelper.SendCommand(RFIDHelper.RFIDCommand_RMU_InventoryAnti3
                                                , RFIDEventType.RMU_InventoryAnti);
                    }
                    break;
                case (int)RFIDEventType.RMU_StopGet:
                    string buttonText = "";
                    switch ((int)this.StopState)
                    {
                        case (int)InventoryStopState.Initializing:
                            {
                                value = "本地考勤服务开始";
                                buttonText = "关闭";
                                _RFIDHelper.SendCommand(RFIDHelper.RFIDCommand_RMU_InventoryAnti3
                                                        , RFIDEventType.RMU_InventoryAnti);
                            }
                            break;
                        case (int)InventoryStopState.Stop:
                            {
                                _RFIDHelper.StopCallback();
                                value = "本地考勤服务停止";
                                buttonText = "打开";
                            }
                            break;
                        case (int)InventoryStopState.StopForOtherCommand:
                            {
                                value = "本地考勤服务开始";
                                buttonText = "关闭";
                                //读取密码段
                                string readCommand =
                                    RFIDHelper.RmuReadDataCommandComposer(
                                                        RMU_CommandType.RMU_SingleReadData
                                                           , "12345678",
                                                           0,
                                                           2,
                                                           2,
                                                           null);
                                _RFIDHelper.SendCommand(readCommand
                                                        , RFIDEventType.RMU_SingleReadData);

                            }
                            break;
                    }
                    //if (bStartOrCloseStop == true)//如果只是开始时的初始化命令
                    //{
                    //    this.bRfidCheckClosed = false;
                    //    value = "本地考勤服务开始";
                    //    buttonText = "关闭";
                    //    //this.StartReadRFIDTag();
                    //}
                    //else
                    //{
                    //    _RFIDHelper.StopCallback();
                    //    this.bRfidCheckClosed = true;
                    //    value = "本地考勤服务停止";
                    //    buttonText = "打开";
                    //}

                    if (this.button1.InvokeRequired)
                    {
                        this.button1.Invoke(new deleUpdateContorl(this.UpdateButton1),buttonText );
                    }
                    else
                    {
                        this.button1.Text = buttonText;
                    }

                    if (this.labelStatus.InvokeRequired)
                    {
                        this.labelStatus.Invoke(new deleUpdateContorl(UpdateStatusLable), value);
                    }
                    else
                    {
                        //this.statusLabel.Text = value;
                        UpdateStatusLable(value);
                    }
                    break;
            }
        }

        private void StartReadRFIDTag()
        {
            //_timer.Enabled = true;
            //_timer.Start();
            this.StopState = InventoryStopState.Initializing;
            _RFIDHelper.SendCommand(RFIDHelper.RFIDCommand_RMU_StopGet, RFIDEventType.RMU_StopGet);

        }
        private void StopReadRFIDTag()
        {
            //_timer.Enabled = false;
            //_timer.Stop();
            this.StopState = InventoryStopState.Stop;
            _RFIDHelper.SendCommand(RFIDHelper.RFIDCommand_RMU_StopGet, RFIDEventType.RMU_StopGet);

        }
        void UpdateButton1(string value)
        {
            if (!_UpdateList.CheckItem("UpdateButton1"))
            {
                return;
            }
            _UpdateList.SetItem("UpdateButton1", false);


            //if (this.dicFormUpdatedList.ContainsKey("UpdateButton1") &&
            //    this.dicFormUpdatedList["UpdateButton1"] == false)
            //{
            //    // 说明前一个Invoke正在进行
            //    return;
            //}
            //if (!this.dicFormUpdatedList.ContainsKey("UpdateButton1"))
            //{
            //    this.dicFormUpdatedList.Add("UpdateButton1", false);
            //}
            //this.dicFormUpdatedList["UpdateButton1"] = false;

            this.button1.Text = value;

            //this.dicFormUpdatedList["UpdateButton1"] = true;
            _UpdateList.SetItem("UpdateButton1", true);
        }
        void UpdateStatusLable(string value)
        {
            if (!_UpdateList.CheckItem("UpdateStatusLable"))
            {
                return;
            }
            _UpdateList.SetItem("UpdateStatusLable", false);

            this.labelStatus.Text = value;

            _UpdateList.SetItem("UpdateStatusLable", true);
        }
        void RFIDHelper_evtWriteToSerialPort(byte[] value)
        {
            if (comport == null)
            {
                return;
            }
            try
            {
                if (!comport.IsOpen)
                {
                    ConfigManager.SetSerialPort(ref comport);
                    comport.Open();

                }
                comport.Write(value, 0, value.Length);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int n = comport.BytesToRead;//n为返回的字节数
                byte[] buf = new byte[n];//初始化buf 长度为n
                comport.Read(buf, 0, n);//读取返回数据并赋值到数组
                _RFIDHelper.Parse(buf);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // 将读到的EPC添加到列表中
        bool AddEPC2List(string strEpc)
        {

            EventEPCList.WaitOne(1000,false);
            EventEPCList.Reset();// 防止多线程干扰
            bool bR = false;

            if (epcList.Count > 0)
            {
                if (epcList[0] != strEpc)
                {
                    epcList.Clear();
                }
                epcList.Add(strEpc);
            }
            else
            {
                epcList.Add(strEpc);
            }
            if (epcList.Count > 5)
            {
                epcList.Clear();
                bR = true;
            }
            EventEPCList.Set();
            return bR;
        }

        private void FrmRfidCheck_Client_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(FrmRfidCheck_Client_FormClosing);
            this.txtIP.Text = "";
            this.txtPort.Text = "13000";
        }

        void FrmRfidCheck_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bRfidCheckClosed == false)
            {
                e.Cancel = true;
                MessageBox.Show("请先关闭本地考勤服务！");
                return;
            }
            this.comportClear();
        }
        void comportClear()
        {
            bool bOK = false;
            bOK = _UpdateList.ChekcAllItem();
            while (!bOK)
            {
                Application.DoEvents();
                bOK = _UpdateList.ChekcAllItem();
            }
            if (null != comport)
            {
                if (comport.IsOpen)
                {
                    comport.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int port = 13000;
                if (this.txtPort.Text != null && this.txtPort.Text != "")
                {
                    port = int.Parse(this.txtPort.Text);
                }
                string ip = "127.0.0.1";
                Regex r = new Regex(@"((2[0-4]\d|25[0-5]|[01]?[0-9]?\d)\.){3}(2[0-4]\d|25[0-5]|[01]?[0-9]?\d)");
                if (r.IsMatch(this.txtIP.Text))
                {
                    ip = r.Match(this.txtIP.Text).ToString();
                }
                else
                {
                    MessageBox.Show("请输入正确的ip地址！");
                    return;
                }
                _Port = port;
                _IP = ip;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (this.button1.Text == "关闭")
            {
                //_RFIDHelper.StopCallback();
                this.StopReadRFIDTag();
                bStartOrCloseStop = false;
                //_RFIDHelper.SendCommand(RFIDHelper.RFIDCommand_RMU_StopGet, RFIDEventType.RMU_StopGet);
                return;
            }
            if (this.button1.Text == "打开")
            {
                _RFIDHelper.StartCallback();
                bStartOrCloseStop = true;
                this.StartReadRFIDTag();
                // 首先发送停止获得标签的指令，防止正在不断返回标签导致读取失败
                //_RFIDHelper.SendCommand(RFIDHelper.RFIDCommand_RMU_StopGet, RFIDEventType.RMU_StopGet);
                //_RFIDHelper.SendCommand(RFIDHelper.RFIDCommand_RMU_GetStatus, RFIDEventType.RMU_CardIsReady);
            }
        }
        void CheckToRemoteServer(string id)
        {
            //if (AddEPC2List(id))
            if(!epcList.Contains(id) && !ProcessingepcList.Contains(id))
            {
                AsynchronousSocketClient asc = new AsynchronousSocketClient();
                asc.eventProcessMsg += new deleAsynSocketProcessMsg(asc_eventProcessMsg);
                try
                {
                    ProcessingepcList.Add(id);
                    asc.StartClient(id, _IP, _Port);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        void asc_eventProcessMsg(AsynSocketProcessMsg msg)
        {
            switch (msg.nCode)
            {
                case (int)enumAsynSocketPocessCode.SocketNormalEndReceive:
                    if (((int)CheckProtocol.Success).ToString() == msg.strMsg.Substring(0,1))
                    {
                        string[] tempA = msg.strMsg.Split('&');
                        epcList.Add(tempA[1]);//考勤成功id加入到列表中，
                        ProcessingepcList.Remove(tempA[1]);
                        if (tempA.Length > 2)
                        {
                            MessageBox.Show(tempA[2] + "同学，您的已经考勤完成!");
                        }
                    }
                    else
                        if (((int)CheckProtocol.Failed).ToString() == msg.strMsg)
                        {
                            ProcessingepcList.Clear();
                            MessageBox.Show("考勤失败!");
                        }
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public enum InventoryStopState
    {
        Initializing = 0,
        Stop,
        StopForOtherCommand
    }
}
