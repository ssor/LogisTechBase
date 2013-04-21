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
using System.Net.Sockets;
using RfidReader;
using Config;
using System.Diagnostics;

namespace LogisTechBase.rfidCheck
{
    public partial class FrmRfidCheck_Client : Form, IRFIDHelperSubscriber
    {
        #region Members
        //记录考勤成功的的epc，防止同一标签不断发送考勤信息
        List<string> epcList = new List<string>();
        //在窗口初始化完成后，会首先发送一个停止获取标签的stop命令，
        //在窗口关闭时，也会发送一个stop命令，此时bStartOrCloseStop为false
        bool bRunning = false;
        // 记录已经发送向服务端，但是未得到回复的EPC，防止在处理过程中重复发送
        List<string> ProcessingepcList = new List<string>();
        SerialPortConfigItem spci =
        ConfigManager.GetConfigItem(SerialPortConfigItemName.超高频RFID串口设置);
        public static ManualResetEvent EventEPCList = new ManualResetEvent(true);
        IDataTransfer dataTransfer = null;
        SerialPort comport = null;
        Rmu900RFIDHelper rmu900Helper = null;
        List<byte> maxbuf = new List<byte>();

        //public Dictionary<string, bool> dicFormUpdatedList = new Dictionary<string, bool>();
        InvokeDic _UpdateList = new InvokeDic();
        //RFIDHelper _RFIDHelper = new RFIDHelper();

        bool bRfidCheckClosed = true;//标识本地考勤服务是否已经关闭，如果为true，则表示已经关闭

        int _Port;
        string _IP;
        System.Timers.Timer _timer = new System.Timers.Timer(1000);
        #endregion

        public FrmRfidCheck_Client()
        {
            InitializeComponent();
            this.Shown += new EventHandler(FrmRfidCheck_Client_Shown);

            dataTransfer = new SerialPortDataTransfer();
            try
            {
                comport = new SerialPort(spci.GetItemValue(enumSerialPortConfigItem.串口名称), int.Parse(spci.GetItemValue(enumSerialPortConfigItem.波特率)), Parity.None, 8, StopBits.One);
                ((SerialPortDataTransfer)dataTransfer).Comport = comport;

                rmu900Helper = new Rmu900RFIDHelper(dataTransfer);
                rmu900Helper.Subscribe(this);
                dataTransfer.AddParser(rmu900Helper);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "异常提示");
            }

        }


        void FrmRfidCheck_Client_Shown(object sender, EventArgs e)
        {
            //_RFIDHelper.SendCommand(RFIDHelper.RFIDCommand_RMU_StopGet, RFIDEventType.RMU_StopGet);
            listening_udp_broadcast();
        }
        Socket serverSocket;
        string GetLocalIP4()
        {
            IPAddress ipAddress = null;
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            for (int i = 0; i < ipHostInfo.AddressList.Length; i++)
            {
                ipAddress = ipHostInfo.AddressList[i];
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    break;
                }
                else
                {
                    ipAddress = null;
                }
            }
            if (null == ipAddress)
            {
                return null;
            }
            return ipAddress.ToString();
        }
        byte[] byteData = new byte[1024];
        private void listening_udp_broadcast()
        {
            try
            {
                //We are using UDP sockets
                serverSocket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Dgram, ProtocolType.Udp);
                IPAddress ip = IPAddress.Parse(this.GetLocalIP4());
                IPEndPoint ipEndPoint = new IPEndPoint(ip, 15001);
                serverSocket.Bind(ipEndPoint);
                //防止客户端强行中断造成的异常
                long IOC_IN = 0x80000000;
                long IOC_VENDOR = 0x18000000;
                long SIO_UDP_CONNRESET = IOC_IN | IOC_VENDOR | 12;

                byte[] optionInValue = { Convert.ToByte(false) };
                byte[] optionOutValue = new byte[4];
                serverSocket.IOControl((int)SIO_UDP_CONNRESET, optionInValue, optionOutValue);

                IPEndPoint ipeSender = new IPEndPoint(IPAddress.Any, 0);
                //The epSender identifies the incoming clients
                EndPoint epSender = (EndPoint)ipeSender;

                //Start receiving data
                serverSocket.BeginReceiveFrom(byteData, 0, byteData.Length,
                    SocketFlags.None, ref epSender, new AsyncCallback(OnReceive), epSender);
            }
            catch (Exception ex)
            {

            }
        }
        bool __bGetIP = false;//是否已经获得教师端广播的IP地址
        void OnReceive(IAsyncResult ar)
        {
            if (__bGetIP == true)
            {
                return;
            }
            try
            {
                IPEndPoint ipeSender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint epSender = (EndPoint)ipeSender;

                serverSocket.EndReceiveFrom(ar, ref epSender);

                string strReceived = Encoding.UTF8.GetString(byteData);

                Array.Clear(byteData, 0, byteData.Length);
                int i = strReceived.IndexOf("\0");
                string ip_and_port = strReceived.Substring(0, i);

                deleUpdateContorl dele = delegate(string s)
                {
                    string[] array = s.Split(':');
                    if (array.Length >= 2)
                    {
                        __bGetIP = true;
                        string ip = array[0];
                        string port = array[1];
                        this.txtIP.Text = ip;
                        this.txtPort.Text = port;
                    }
                };
                this.Invoke(dele, ip_and_port);
            }
            catch (Exception ex)
            {

            }
        }

        // 将读到的EPC添加到列表中
        bool AddEPC2List(string strEpc)
        {

            EventEPCList.WaitOne(1000, false);
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
            if (this.bRunning == true)
            {
                bRunning = false;
                this.button1.Text = "开始(&O)";
                rmu900Helper.StopInventory();
                this.matrixCircularProgressControl1.Stop();
            }
            else
            {
                bRunning = true;
                this.button1.Text = "关闭(&C)";
                rmu900Helper.StartInventory();
                this.matrixCircularProgressControl1.Start();
            }
        }
        void UpdateEpcList(object o)
        {
            deleControlInvoke dele = delegate(object oEpc)
            {
                string value = oEpc as string;
                this.CheckToRemoteServer(value);
            };
            this.Invoke(dele, o);
        }

        void CheckToRemoteServer(string id)
        {
            //if (AddEPC2List(id))
            if (!epcList.Contains(id) && !ProcessingepcList.Contains(id))
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

        void append_log(string log)
        {
            deleControlInvoke dele = delegate(object olog)
            {
                string strLog = (string)olog;
                this.txtLog.Text = this.txtLog.Text + strLog + " " + DateTime.Now.ToString("yyyy-mm-dd HH-MM-ss") + "\r\n";
            };
            this.Invoke(dele, log);
        }
        void asc_eventProcessMsg(AsynSocketProcessMsg msg)
        {
            switch (msg.nCode)
            {
                case (int)enumAsynSocketPocessCode.SocketNormalEndReceive:
                    if (((int)CheckProtocol.Success).ToString() == msg.strMsg.Substring(0, 1))
                    {
                        string[] tempA = msg.strMsg.Split('&');
                        epcList.Add(tempA[1]);//考勤成功id加入到列表中，
                        ProcessingepcList.Remove(tempA[1]);
                        if (tempA.Length > 2)
                        {

                            AudioAlert.PlayAlert();
                            this.append_log(tempA[2] + "同学考勤完成!");
                        }
                    }
                    else
                        if (((int)CheckProtocol.Failed).ToString() == msg.strMsg)
                        {
                            ProcessingepcList.Clear();
                            this.append_log("考勤失败!");
                        }
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSerialPortConfig_Click(object sender, EventArgs e)
        {

            SerialPortConfig spc = new SerialPortConfig(spci, null);
            //SerialPortConfig spc = new SerialPortConfig();
            spc.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 000000000000000000003016
            string id = this.txtid.Text;
            AsynchronousSocketClient asc = new AsynchronousSocketClient();
            asc.eventProcessMsg += new deleAsynSocketProcessMsg(asc_eventProcessMsg);
            try
            {
                asc.StartClient(id, this.txtIP.Text, int.Parse(this.txtPort.Text));
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void matrixCircularProgressControl1_Load(object sender, EventArgs e)
        {

        }

        #region IRFIDHelperSubscriber 成员

        public void NewMessageArrived()
        {
            string r2 = rmu900Helper.CheckInventory();
            if (r2 != string.Empty)
            {
                this.UpdateEpcList(r2);
                Debug.WriteLine("读取到标签 " + r2);

            }
        }

        #endregion
    }
}
