using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml;
using LogisTechBase.rfidCheck;
using System.IO.Ports;
using System.Text.RegularExpressions;
using AsynchronousSocket;
using Config;

namespace LogisTechBase
{

    public partial class FrmRfidCheck_Server : Form
    {
        #region Members

        string server_ip_and_port = string.Empty;//考勤服务端的ip地址和端口，作为广播发送到局域网内的计算机上
        //RFIDHelper _RFIDHelper = new RFIDHelper();

        SerialPort comport = new SerialPort();
        ISerialPortConfigItem ispc =
                 ConfigManager.GetConfigItem(SerialPortConfigItemName.超高频RFID串口设置);
        List<byte> maxbuf = new List<byte>();
        List<string> epcList = new List<string>();//记录读到的epc
        public static ManualResetEvent EventEPCList = new ManualResetEvent(true);
        public static ManualResetEvent EventIdList_Temp = new ManualResetEvent(true);

        List<Person> personList;
        List<CheckRecord> checkRecordList_temp = new List<CheckRecord>();//作为数据库的缓存，页面load时读入数据，页面退出时写入数据库中
        string receiveData;
        AsynchronousSocketListener listener = null;
        InvokeDic _UpdateList = new InvokeDic();
        bool bRemoteCheckClosed = true;//标识远程考勤服务是否关闭，如果为true，则表示已经关闭
        #endregion

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

        public FrmRfidCheck_Server()
        {
            InitializeComponent();
            this.labelStatus.Text = string.Empty;
            this.lblCheckedCount.Text = "0";
            this.lblUncheckedCount.Text = "0";
            this.Load += new EventHandler(FrmRfidCheck_Server_Load);
        }

        private void FrmRfidCheck_Server_Load(object sender, EventArgs e)
        {
            this.initial_person_list();
            this.initial_check_state();
            this.FormClosing += new FormClosingEventHandler(FrmRfidCheck_Server_FormClosing);
        }

        /// <summary>
        /// 初始化列表中的学生信息
        /// </summary>
        void initial_person_list()
        {
            this.personList = rfidCheck_CheckOn.GetPersonList();
            int ichecked = 0;
            this.lblUncheckedCount.Text = (this.personList.Count - ichecked).ToString();
            this.lblCheckedCount.Text = ichecked.ToString();


            DataTable table = null;
            if (this.dataGridView1.DataSource == null)
            {
                table = new DataTable();
                table.Columns.Add("学号", typeof(string));
                table.Columns.Add("姓名", typeof(string));
                table.Columns.Add("考勤时间", typeof(string));
            }
            else
            {
                table = (DataTable)this.dataGridView1.DataSource;
            }

            table.Rows.Clear();

            for (int j = 0; j < this.personList.Count; j++)
            {
                table.Rows.Add(new object[]{
                    this.personList[j].id_num,
                    this.personList[j].name,
                    ""
                });
            }
            dataGridView1.DataSource = table;
            ///*
            if (!dataGridView1.Columns.Contains("checkColumn"))
            {
                DataGridViewCheckBoxColumn cc = new DataGridViewCheckBoxColumn();
                cc.HeaderText = "";
                cc.Name = "checkColumn";
                cc.Width = 50;
                dataGridView1.Columns.Insert(0, cc);
            }
            this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            int headerW = this.dataGridView1.RowHeadersWidth;
            int columnsW = 0;
            DataGridViewColumnCollection columns = this.dataGridView1.Columns;
            columns[0].Width = 50;
            for (int i = 0; i < columns.Count; i++)
            {
                columnsW += columns[i].Width;
            }
            if (columnsW + headerW < this.dataGridView1.Width)
            {
                int leftTotalWidht = this.dataGridView1.Width - columnsW - headerW;
                int eachColumnAddedWidth = leftTotalWidht / (columns.Count - 1);
                for (int i = 1; i < columns.Count; i++)
                {
                    columns[i].Width += eachColumnAddedWidth;
                }
            }


            // * */
        }
        //启动考勤时初始化保存的考勤信息
        void initial_check_state()
        {
            DataTable dt = nsConfigDB.ConfigDB.getTable(Program.check_info_table);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    CheckRecord cr = new CheckRecord(dr["key"].ToString(), dr["time"].ToString());
                    this.checkRecordList_temp.Add(cr);
                }
                DataGridViewRowCollection rows = this.dataGridView1.Rows;
                foreach (CheckRecord cr in this.checkRecordList_temp)
                {
                    string id = cr.id;
                    string studentid = string.Empty;
                    foreach (Person p in this.personList)
                    {
                        if (p.epc == id)
                        {
                            studentid = p.id_num;
                            break;
                        }
                    }
                    foreach (DataGridViewRow vr in rows)
                    {
                        DataGridViewCell cepc = (DataGridViewCell)vr.Cells[1];
                        if (((string)cepc.Value) == studentid)
                        {
                            DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)vr.Cells[0];
                            cbc.Value = Boolean.TrueString;

                            this.lblCheckedCount.Text = (int.Parse(this.lblCheckedCount.Text) + 1).ToString();
                            this.lblUncheckedCount.Text = (int.Parse(this.lblUncheckedCount.Text) - 1).ToString();
                            break;
                        }
                    }
                }

            }
        }


        void FrmRfidCheck_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bRemoteCheckClosed == false)
            {
                e.Cancel = true;
                MessageBox.Show("请先关闭远程考勤服务！");
                return;
            }

            ExitProg();
            if (checkRecordList_temp.Count > 0)
            {
                for (int i = 0; i < checkRecordList_temp.Count; i++)
                {
                    rfidCheck_CheckOn.AddCheckRecord(checkRecordList_temp[i]);
                }
            }

        }

        string GetPersonNamebyID(string id)
        {
            if (null == id)
            {
                return null;
            }
            string strR = null;
            for (int i = 0; i < personList.Count; i++)
            {
                if (id == personList[i].epc)
                {
                    strR = personList[i].name;
                    break;
                }
            }
            return strR;
        }
        bool CheckIdList_TempExist(string newID)
        {
            EventIdList_Temp.WaitOne(1000, false);
            EventIdList_Temp.Reset();

            bool bExist = false;
            if (null == checkRecordList_temp)
            {
                return bExist;
            }
            for (int i = 0; i < checkRecordList_temp.Count; i++)
            {
                if (newID == checkRecordList_temp[i].id)
                {
                    bExist = true;
                    break;
                }
            }
            EventIdList_Temp.Set();
            return bExist;
        }
        void AddNewIDToCheckRecordList_Temp(string newID)
        {
            EventIdList_Temp.WaitOne(1000, false);
            EventIdList_Temp.Reset();

            bool bAdd = true;
            for (int i = 0; i < checkRecordList_temp.Count; i++)
            {
                if (newID == checkRecordList_temp[i].id)
                {
                    bAdd = false;
                    break;
                }
            }
            if (bAdd)
            {
                string strDateTime = rfidCheck_CheckOn.GetFormatDateTimeString(DateTime.Now);
                checkRecordList_temp.Add(new CheckRecord(newID, strDateTime));
            }

            EventIdList_Temp.Set();
        }
        void frmRfidCheck_Server_Checkin(string id)
        {
            this.AddNewIDToCheckRecordList_Temp(id);
            deleControlInvoke dele = delegate(object o)
            {
                DataGridViewRowCollection rows = this.dataGridView1.Rows;
                foreach (DataGridViewRow vr in rows)
                {
                    string studentid = string.Empty;
                    foreach (Person p in this.personList)
                    {
                        if (p.epc == id)
                        {
                            studentid = p.id_num;
                            break;
                        }
                    }
                    DataGridViewCell cepc = (DataGridViewCell)vr.Cells[1];
                    if (((string)cepc.Value) == studentid)
                    {
                        DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)vr.Cells[0];
                        cbc.Value = Boolean.TrueString;

                        this.lblCheckedCount.Text = (int.Parse(this.lblCheckedCount.Text) + 1).ToString();
                        this.lblUncheckedCount.Text = (int.Parse(this.lblUncheckedCount.Text) - 1).ToString();
                        break;
                    }
                }

            };
            this.Invoke(dele, id);
        }

        private void btn_startserver_Click(object sender, EventArgs e)
        {
            int nPort = 13000;
            Regex r = new Regex(@"\d[1-9]\d{1,4}");

            if (r.IsMatch(this.txtPort.Text))
            {
                try
                {
                    nPort = int.Parse(r.Match(this.txtPort.Text).ToString());
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            if (nPort == 15001)
            {
                MessageBox.Show("15001端口在系统中有特定用途，请设置别的端口！", "信息提示", MessageBoxButtons.OK);
                return;
            }
            listener = new AsynchronousSocketListener();
            listener.eventProcessMsg += new deleAsynSocketProcessMsg(listener_eventProcessMsg);
            listener.eventGetSendContent += new deleAsynSocketListenerGetContent(listener_eventGetSendContent);
            listener.PortNum = nPort;
            listener.StartListening();
            this.bRemoteCheckClosed = false;
            this.btn_startserver.Enabled = false;
            string ip = this.GetLocalIP4();
            this.labelStatus.Text = "远程考勤服务(" + ip + ":" + nPort.ToString() + ")运行中...";
            this.server_ip_and_port = ip + ":" + nPort.ToString();
            //rfidCheck_CheckOn.CheckOn("20112104");
            this.startBroadcast();
        }
        Socket clientSocket = null; //The main client socket
        System.Windows.Forms.Timer __broadcast_timer = null;
        private void startBroadcast()
        {
            __broadcast_timer = new System.Windows.Forms.Timer();
            __broadcast_timer.Interval = 1000;
            __broadcast_timer.Tick += new EventHandler(__broadcast_timer_Tick);
            Socket Socket = new Socket(AddressFamily.InterNetwork,
               SocketType.Dgram, ProtocolType.Udp);
            Socket.EnableBroadcast = true;
            IPEndPoint iep = new IPEndPoint(IPAddress.Broadcast, 10000);
            byte[] byteData = System.Text.Encoding.UTF8.GetBytes(this.server_ip_and_port);
            try
            {
                Socket.BeginSendTo(byteData, 0,
                                            byteData.Length, SocketFlags.None,
                                            iep, null, null);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK);
                return;
            }

            //如果出现异常，clientSocket 不会被赋值，也不回有timer轮询
            clientSocket = Socket;
            __broadcast_timer.Enabled = true;
        }

        void __broadcast_timer_Tick(object sender, EventArgs e)
        {
            if (clientSocket != null)
            {
                IPEndPoint iep = new IPEndPoint(IPAddress.Broadcast, 15001);
                byte[] byteData = System.Text.Encoding.UTF8.GetBytes(this.server_ip_and_port);
                try
                {
                    clientSocket.BeginSendTo(byteData, 0,
                                                byteData.Length, SocketFlags.None,
                                                iep, null, null);
                }
                catch (System.Exception ex)
                {
                    //MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK);
                    return;
                }
            }
        }
        string listener_eventGetSendContent()
        {
            // 根据协议返回特定值，客户端由此确定成功与否
            //if (rfidCheck_CheckOn.CheckIDExist(receiveData))
            if (this.CheckIdList_TempExist(receiveData))
            {
                string name = GetPersonNamebyID(receiveData);
                return ((int)CheckProtocol.Success).ToString() + "&" + receiveData + "&" + name;
            }
            else
            {
                return ((int)CheckProtocol.Failed).ToString();
            }
        }

        void listener_eventProcessMsg(AsynSocketProcessMsg msg)
        {
            switch ((int)msg.nCode)
            {
                //case (int)enumAsynSocketPocessCode.SocketNormalOutPut:
                //    Console.WriteLine(msg.strMsg);
                //    break;
                case (int)enumAsynSocketPocessCode.SocketNormalEndReceive:
                    // 接收到客户端传来的学号信息，记录到数据库中
                    receiveData = msg.strMsg;
                    //rfidCheck_CheckOn.CheckOn(receiveData);
                    this.frmRfidCheck_Server_Checkin(receiveData);
                    break;
            }
        }

        private void btn_stopserver_Click_1(object sender, EventArgs e)
        {
            if (null != this.listener)
            {
                listener.StopListener();
                listener = null;
            }
            this.bRemoteCheckClosed = true;
            this.btn_startserver.Enabled = true;

            this.labelStatus.Text = "服务于 " + DateTime.Now.ToString() + " 停止运行.";
        }


        void ExitProg()
        {
            bool bOk = false;
            if (null != comport)
            {
                if (comport.IsOpen)
                {
                    bOk = _UpdateList.ChekcAllItem();
                    // 如果没有全部完成，则要将消息处理让出，使Invoke有机会完成
                    while (!bOk)
                    {
                        Application.DoEvents();
                        bOk = _UpdateList.ChekcAllItem();
                    }
                    comport.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnResetCheckRecord_Click(object sender, EventArgs e)
        {
            this.personList = rfidCheck_CheckOn.GetPersonList();
            this.lblUncheckedCount.Text = this.personList.Count.ToString();
            this.lblCheckedCount.Text = "0";

            DataTable dt = nsConfigDB.ConfigDB.getTable(Program.check_info_table);
            if (dt != null && dt.Rows.Count > 0)
            {
                dt.Rows.Clear();
            }
            nsConfigDB.ConfigDB.save(Program.check_info_table);

            DataGridViewRowCollection rows = this.dataGridView1.Rows;
            foreach (DataGridViewRow vr in rows)
            {
                DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)vr.Cells[0];
                cbc.Value = Boolean.FalseString;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (CheckRecord cr in checkRecordList_temp)
            {
                nsConfigDB.ConfigDB.saveConfig(Program.check_info_table, cr.id, new string[] { cr.checkDate });
            }
        }
    }

}
