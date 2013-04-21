using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using httpHelper;
using System.Diagnostics;

namespace LogisTechBase
{
    public partial class frmGPSReceiver : Form
    {
        bool bRunning = false;
        Timer __timer = null;
        string __IP;
        string __timerStamp = string.Empty;
        string __port = string.Empty;
        List<CarPoint> __pointList = new List<CarPoint>();
        public frmGPSReceiver()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.__timer == null)
            {
                this.__timer = new Timer();
                this.__timer.Interval = 5000;
                this.__timer.Tick += new EventHandler(__timer_Tick);
            }
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

                    this.__pointList.Clear();
                    this.__timerStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    this.__timer.Enabled = true;
                    this.bRunning = true;
                    this.matrixCircularProgressControl1.Start();
                    this.button1.Text = "停止";
                }
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
        string __MobileName = string.Empty;
        void __timer_Tick(object sender, EventArgs e)
        {
            //this.__IP = "localhost";
            //string restUrl = "http://182.18.26.127:80/index.php/LogisTechBase/CarMonitorGet/getLatestCarPoints";
            string restUrl = "http://" + this.__IP + ":" + this.__port + "/index.php/GPSAPIGet/getLatestCarPoint/id/"+this.__MobileName;
            //Location l = new Location(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), this.__MobileName);
            //CarPoint c = new CarPoint();
            //c.Time = this.__timerStamp;
            //c.CarID = this.__MobileName;
            //string jsonString = fastJSON.JSON.Instance.ToJSON(c);
            HttpWebConnect helper = new HttpWebConnect();
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_return);
            // {"state":null,"strCarID":"J001","strTime":"2012-02-12 11:42:45","strLatitude":"0","strLongitude":"0"}
            helper.TryPostData(restUrl, "");

        }
        // www.motathink.com
        void helper_RequestCompleted_return(object o)
        {
            deleControlInvoke dele = delegate(object op)
            {
                string strLocations = (string)op;
                Debug.WriteLine(
                    string.Format("frmGPSReceiver.helper_RequestCompleted_return  ->  = {0}"
                    , strLocations));
                CarPoint c = (CarPoint)fastJSON.JSON.Instance.ToObject(strLocations, typeof(CarPoint));
                //如果返回的最新的位置不符合当前的时间要求，就不显示
                if (string.Compare(this.__timerStamp, c.Time) < 0)
                {
                    this.__timerStamp = c.Time;
                    this.txtLocations.Text += c.toLocationString();
                    this.__pointList.Add(c);
                }
                //object olist = fastJSON.JSON.Instance.ToObjectList(strLocations, typeof(List<CarPoint>), typeof(CarPoint));
                //List<CarPoint> locationList = (List<CarPoint>)olist;
                //this.__pointList.AddRange(locationList);
                //for (int i = 0; i < locationList.Count; i++)
                //{
                //    //
                //    this.txtLocations.Text += locationList[i].toLocationString();
                //    if (i == locationList.Count - 1)
                //    {
                //        if (string.Compare(this.__timerStamp, locationList[i].strTime) < 0)
                //        {
                //            this.__timerStamp = locationList[i].strTime;
                //        }
                //    }
                //}
            };
            this.Invoke(dele, o);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.__timer.Enabled = false;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Debug.WriteLine(
                    string.Format("frmGPSReceiver.button2_Click  ->  = {0}"
                    , saveFileDialog1.FileName));
                string strPath = saveFileDialog1.FileName;
                DataSet ds = new DataSet("Points");

                DataTable dt = new DataTable("point");
                dt.Columns.Add("time", typeof(string));
                dt.Columns.Add("latitude", typeof(string));
                dt.Columns.Add("longitude", typeof(string));
                ds.Tables.Add(dt);

                for (int i = 0; i < __pointList.Count; i++)
                {
                    CarPoint c = __pointList[i];
                    dt.Rows.Add(new object[] { c.Time, c.Latitude, c.Longitude });
                }

                ds.WriteXml(strPath);

            }

            return;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
    public class CarPoint
    {
        public string state;
        public string CarID = string.Empty;
        // no arguments constructor is necessary
        public CarPoint()
        {
            this.CarID = "0";
            this.Latitude = "0";
            this.Longitude = "0";
            this.Time = "0";

        }
        public CarPoint(string strCarID_in, string strTime_in, string strLat_in, string strLon_in)
        {
            this.CarID = strCarID_in;
            this.Time = strTime_in;
            this.Latitude = strLat_in;
            this.Longitude = strLon_in;
        }
        public string Time;
        public string Latitude = "0";
        public string Longitude = "0";
        public string toLocationString()
        {
            try
            {
                return "经度: " + (double.Parse(this.Longitude) / 3600000).ToString() + "  纬度: " + (double.Parse(this.Latitude) / 3600000).ToString() + "  时间: " + this.Time + "\r\n";
            }
            catch
            {
                return "暂时未获得有效数据";
            }
        }

    }
    public class Location
    {
        public string timeStamp;
        public string name;
        public string lat;
        public string lng;
        public Location()
        {

        }
        public Location(string _time, string _name)
        {
            this.timeStamp = _time;
            this.name = _name;
        }
        public string toLocationString()
        {
            return "经度: " + this.lng + "  纬度: " + this.lat + "  时间: " + this.timeStamp + "\r\n";
        }
    }
}
