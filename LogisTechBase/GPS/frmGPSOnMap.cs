using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Net;
using httpHelper;
using System.Diagnostics;
using Config;

namespace LogisTechBase
{
    public partial class frmGPSOnMap : Form
    {
        private SerialPort comport = new SerialPort();
        ISerialPortConfigItem ispci =
                ConfigManager.GetConfigItem(SerialPortConfigItemName.GPS串口设置);
        public string instring;
        public string[] gpsString;
        public double ellipHeight;
        NmeaInterpreter GPS = new NmeaInterpreter();
        NMEA2OSG OSGconv = new NMEA2OSG();
        delegate void deleInvokeMapControlPos(string lat, string lng);
        string __IP;
        string __timerStamp = string.Empty;
        string __port = string.Empty;
        string __MobileName = string.Empty;
        System.Windows.Forms.Timer __timer = null;
        bool stop_receive = false;
        public frmGPSOnMap()
        {
            InitializeComponent();
            if (this.__timer == null)
            {
                this.__timer = new System.Windows.Forms.Timer();
                this.__timer.Interval = 5000;
                this.__timer.Tick += new EventHandler(__timer_Tick);
            }
            comport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);

            GPS.PositionReceived += new NmeaInterpreter.PositionReceivedEventHandler(GPS_PositionReceived);

            this.FormClosing += new FormClosingEventHandler(frmGPSOnMap_FormClosing);

        }

        void frmGPSOnMap_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.stop_receive = true;

            Thread.Sleep(1000);

            if (this.comport != null)
            {
                this.comport.Close();
            }
        }

        private void GPS_PositionReceived(string Lat, string Lon)
        {
            if (OSGconv.ParseNMEA(Lat, Lon, ellipHeight))
            {
                deleInvokeMapControlPos dele = delegate(string _lat, string _lon)
                {
                    this.txtLat.Text = _lat;
                    this.txtLng.Text = _lon;
                };
                if (this.stop_receive == false)
                {

                    this.Invoke(dele, (Convert.ToString(OSGconv.deciLat)), (Convert.ToString(OSGconv.deciLon)));
                }
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            HandleGPSstring(sender, e);
        }
        private void HandleGPSstring(object s, EventArgs e)
        {
            string inbuff;
            inbuff = comport.ReadExisting();
            if (inbuff != null)
            {
                if (inbuff.StartsWith("$"))
                {
                    instring = inbuff;
                }
                else
                {
                    StringBuilder sb = new StringBuilder(instring);
                    sb.Append(inbuff);
                    instring = sb.ToString();
                }
                gpsString = instring.Split();
                foreach (string item in gpsString) GPS.Parse(item);
            }
        }
        bool bRunning = false;
        private void button1_Click(object sender, EventArgs e)
        {

            if (this.bRunning == true)
            {
                this.__timer.Enabled = false;
                this.matrixCircularProgressControl1.Stop();
                this.bRunning = false;
                this.button1.Text = "开始";
            }
            else
            {
                if (parseIPandPort())
                {

                    this.stop_receive = false;
                    if (ConfigManager.SetSerialPort(ref comport, this.ispci))
                    {
                        try
                        {

                            // Open the port
                            comport.Open();
                            this.GPS.StartInterpreter();
                            this.matrixCircularProgressControl1.Start();
                            this.bRunning = true;
                            this.button1.Text = "停止";
                            if (this.__timer != null)
                            {
                                this.__timer.Enabled = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "异常提示");
                        }
                    }
                }
            }
        }

        private void btnShowMap_Click(object sender, EventArgs e)
        {
            if (this.parseIPandPort())
            {
                //打开浏览器，进入实验箱WebGIS服务
                string url = "http://" + this.__IP + ":9003/index.php";
                System.Diagnostics.Process.Start(url);
            }
        }
        bool parseIPandPort()
        {
            string ip = this.txtIP.Text;
            try
            {
                if (ip.Contains("www"))
                {
                    IPHostEntry hostInfo = Dns.GetHostEntry(ip);
                    if (hostInfo != null && hostInfo.AddressList.Length > 0)
                    {
                        for (int i = 0; i < hostInfo.AddressList.Length; i++)
                        {
                            IPAddress ipa = hostInfo.AddressList[i];
                            if (ipa.IsIPv6LinkLocal || ipa.IsIPv6Multicast || ipa.IsIPv6LinkLocal)
                            {
                                continue;
                            }
                            this.__IP = ipa.ToString();
                            break;
                        }
                    }
                }
                else
                {

                    IPAddress ipTry = null;

                    ipTry = IPAddress.Parse(ip);
                    this.__IP = ip;
                }
            }
            catch
            {
                MessageBox.Show("请输入正确的IP地址：(0-255).(0-255).(0-255).(0-255)");
                return false;
            }
            if (this.txtMobileIndex.Text == null || this.txtMobileIndex.Text.Length <= 0)
            {
                MessageBox.Show("请输入GPS终端的编号！");
                return false;
            }
            else
            {
                this.__MobileName = this.txtMobileIndex.Text;
            }
            string strPort = this.txtPort.Text;
            if (strPort == null)
            {
                strPort = string.Empty;
            }
            try
            {
                int port = int.Parse(strPort);
                if (port < 80)
                {
                    MessageBox.Show("端口号不符合系统要求！");
                    return false;
                }
                __port = port.ToString();
            }
            catch
            {
                MessageBox.Show("端口号不符合系统要求！");
                return false;
            }
            return true;
        }


        void __timer_Tick(object sender, EventArgs e)
        {
            try
            {
                string restUrl = "http://" + this.__IP + ":" + this.__port + "/index.php/GPSAPIPost/postCarPoint";
                //Location l = new Location(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), this.__MobileName);
                CarPoint c = new CarPoint();

                c.Latitude = (double.Parse(this.txtLat.Text) * 3600000).ToString();
                c.Longitude = (double.Parse(this.txtLng.Text) * 3600000).ToString();
                c.Time = this.__timerStamp;
                c.CarID = this.__MobileName;
                string jsonString = fastJSON.JSON.Instance.ToJSON(c);
                HttpWebConnect helper = new HttpWebConnect();
                helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_return);
                // {"state":null,"strCarID":"J001","strTime":"2012-02-12 11:42:45","strLatitude":"0","strLongitude":"0"}
                helper.TryPostData(restUrl, jsonString);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }


        }
        void helper_RequestCompleted_return(object o)
        {
            deleControlInvoke dele = delegate(object op)
            {
                string strLocations = (string)op;
                Debug.WriteLine(
                    string.Format("frmGPSOnMap.helper_RequestCompleted_return  ->  = {0}"
                    , strLocations));
            };
            this.Invoke(dele, o);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
