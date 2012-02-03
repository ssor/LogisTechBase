using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using System.Globalization;
using GMap.NET.WindowsForms.Markers;
using System.Net.NetworkInformation;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace LogisTechBase
{
    public partial class frmGPSExperiment : Form
    {
        GMapMarker center;
        GMapMarker currentMarker;
        bool isMouseDown = false;
        GMapOverlay top;
        GMapOverlay mapLayerPoints;
        InvokeDic _InvokeList = new InvokeDic();
        GMapMarkerPoint carPointMarker;
        // NMEA interpreter
        NmeaInterpreter GPS = new NmeaInterpreter();
        ISerialPortConfigItem ispci =
                SerialPortConfigItem.GetConfigItem(SerialPortConfigItemName.GPS串口设置);
        // OSGridConverter
        NMEA2OSG OSGconv = new NMEA2OSG();
        private SerialPort comport = new SerialPort();
        public string[] gpsString;
        public string instring;
        public string[] nrthest;
        public double ellipHeight;

        delegate void deleInvokeMapControlPos(double lat, double lng);

        public frmGPSExperiment()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(frmGPSExperiment_FormClosing);
            //验证网络连接是否可用
            try
            {
                System.Net.IPHostEntry e = System.Net.Dns.GetHostEntry("www.google.com");
            }
            catch
            {
                this.MainMap.Manager.Mode = AccessMode.CacheOnly;
                MessageBox.Show("网络连接不可用！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //设置地图属性
            MainMap.Position = new PointLatLng(39.9081561293562, 116.365127563477);
            MainMap.DragButton = MouseButtons.Left;
            MainMap.Manager.Mode = AccessMode.ServerAndCache;
            //MainMap.Manager.Mode = AccessMode.ServerOnly;

            //事件绑定
            MainMap.OnCurrentPositionChanged += new CurrentPositionChanged(MainMap_OnCurrentPositionChanged);//位置改变
            MainMap.OnMapZoomChanged += new MapZoomChanged(MainMap_OnMapZoomChanged);//比例尺改变
            MainMap.MouseDown += new MouseEventHandler(MainMap_MouseDown);
            MainMap.MouseUp += new MouseEventHandler(MainMap_MouseUp);

            mapLayerPoints = new GMapOverlay(MainMap, "Points");
            MainMap.Overlays.Add(mapLayerPoints);

            top = new GMapOverlay(MainMap, "top");
            MainMap.Overlays.Add(top);

            // map center
            center = new GMapMarkerCross(MainMap.Position);
            top.Markers.Add(center);

            currentMarker = new GMapMarkerGoogleRed(MainMap.Position);
            currentMarker.ToolTipText = "经度:" + MainMap.Position.Lng.ToString() + " 纬度:" + MainMap.Position.Lat.ToString();
            currentMarker.ToolTipMode = MarkerTooltipMode.Always;
            currentMarker.IsHitTestVisible = false;
            top.Markers.Add(currentMarker);

            comport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);

            GPS.PositionReceived += new NmeaInterpreter.PositionReceivedEventHandler(GPS_PositionReceived);
            GPS.PositionReceived += new NmeaInterpreter.PositionReceivedEventHandler(GPS_PositionReceivedByMapControl);
            //this.txtLat.TextChanged += new EventHandler(txtLat_TextChanged);
            //this.txtLng.TextChanged += new EventHandler(txtLat_TextChanged);

        }

        void txtLat_TextChanged(object sender, EventArgs e)
        {
            //this.drawMap(txtLat.Text, txtLng.Text);
        }
        private void GPS_PositionReceivedByMapControl(string Lat, string Lon)
        {
            //if (OSGconv.ParseNMEA(Lat, Lon, ellipHeight))
            //{
            //    MainMap.Position = new PointLatLng(OSGconv.deciLat, OSGconv.deciLon);
            //}

            if (!_InvokeList.CheckItem("UpdateMapControlPosition"))
            {
                return;
            }
            Debug.WriteLine(string.Format(
                        "GPS_PositionReceivedByMapControl -> lat = {0} lon = {1}"
                        , Lat.ToString(), Lon.ToString()));
            _InvokeList.SetItem("UpdateMapControlPosition", false);
            //convert to OS grid
            if (OSGconv.ParseNMEA(Lat, Lon, ellipHeight))
            {
                //display decimal values of lat and lon
                if (MainMap.InvokeRequired)
                {
                    //MainMap.Invoke(new deleInvokeMapControlPos(UpdateMapControlPosition)
                    MainMap.BeginInvoke(new deleInvokeMapControlPos(UpdateMapControlPosition)
                                        , OSGconv.deciLat, OSGconv.deciLon);
                }
                else
                {
                    UpdateMapControlPosition(OSGconv.deciLat, OSGconv.deciLon);
                }
            }
        }
        void UpdateMapControlPosition(double lat, double lng)
        {
            MainMap.Position = new PointLatLng(lat, lng);
            //if (currentMarker.IsVisible)
            //{
            //    currentMarker.Position = MainMap.Position;
            //    currentMarker.ToolTipText = "经度:" + MainMap.Position.Lng.ToString() + " 纬度:" + MainMap.Position.Lat.ToString();
            //    currentMarker.ToolTipMode = MarkerTooltipMode.Always;
            //}
            _InvokeList.SetItem("UpdateMapControlPosition", true);
        }
        private void GPS_PositionReceived(string Lat, string Lon)
        {
            if (
                !_InvokeList.CheckItem("GPS_PositionReceived_deciLat") ||
                !_InvokeList.CheckItem("GPS_PositionReceived_deciLon")
                )
            {
                return;
            }

            _InvokeList.SetItem("GPS_PositionReceived_deciLat", false);
            _InvokeList.SetItem("GPS_PositionReceived_deciLon", false);

            //convert to OS grid
            if (OSGconv.ParseNMEA(Lat, Lon, ellipHeight))
            {
                //display decimal values of lat and lon
                if (txtLat.InvokeRequired)
                {
                    //txtLat.Invoke(new deleUpdateContorl(Update_textBoxDeciLat), Convert.ToString(OSGconv.deciLat));
                    txtLat.BeginInvoke(new deleUpdateContorl(Update_textBoxDeciLat), Convert.ToString(OSGconv.deciLat));
                }
                else
                {
                    Update_textBoxDeciLat(Convert.ToString(OSGconv.deciLat));
                    //txtLat.Text = Convert.ToString(OSGconv.deciLat);
                }
                if (txtLng.InvokeRequired)
                {
                    txtLng.BeginInvoke(new deleUpdateContorl(Update_textBoxDeciLon), Convert.ToString(OSGconv.deciLon));
                    //txtLng.Invoke(new deleUpdateContorl(Update_textBoxDeciLon), Convert.ToString(OSGconv.deciLon));
                }
                else
                {
                    Update_textBoxDeciLon(Convert.ToString(OSGconv.deciLon));
                    //txtLng.Text = Convert.ToString(OSGconv.deciLon);
                }
            }
        }
        void Update_textBoxDeciLon(string deciLon)
        {
            txtLng.Text = deciLon;
            _InvokeList.SetItem("GPS_PositionReceived_deciLon", true);
        }
        void Update_textBoxDeciLat(string deciLat)
        {
            txtLat.Text = deciLat;
            _InvokeList.SetItem("GPS_PositionReceived_deciLat", true);
        }
        private void frmGPSExperiment_Load(object sender, EventArgs e)
        {
            txtLat.Text = "39.9081561293562";
            txtLng.Text = "116.365127563477";
            //lbLat.Text = "39.9081561293562";
            //lbLng.Text = "116.365127563477";
        }

        //当前位置改变
        void MainMap_OnCurrentPositionChanged(PointLatLng point)
        {
            center.Position = point;
            this.txtLat.Text = point.Lat.ToString(CultureInfo.InvariantCulture);
            this.txtLng.Text = point.Lng.ToString(CultureInfo.InvariantCulture);
            //this.lbLat.Text = point.Lat.ToString(CultureInfo.InvariantCulture);
            //this.lbLng.Text = point.Lng.ToString(CultureInfo.InvariantCulture);
        }

        // MapZoomChanged
        void MainMap_OnMapZoomChanged()
        {
            this.tbZoom.Value = (int)(MainMap.Zoom);
            center.Position = MainMap.Position;
        }

        void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
            }
        }


        private void tbZoom_ValueChanged(object sender, EventArgs e)
        {
            MainMap.Zoom = (tbZoom.Value);
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            //double lat = double.Parse(txtLat.Text, CultureInfo.InvariantCulture);
            //double lng = double.Parse(txtLng.Text, CultureInfo.InvariantCulture);
            //MainMap.Position = new PointLatLng(lat, lng);
            //if (currentMarker.IsVisible)
            //{
            //    currentMarker.Position = MainMap.Position;
            //    currentMarker.ToolTipText = "经度:" + MainMap.Position.Lng.ToString() + " 纬度:" + MainMap.Position.Lat.ToString();
            //    currentMarker.ToolTipMode = MarkerTooltipMode.Always;
            //}
            drawMap(txtLat.Text, txtLng.Text);
        }

        private void drawMap(string lat, string lng)
        {
            try
            {
                if (lat == string.Empty || lng == string.Empty)
                {
                    return;
                }
                double _lat = double.Parse(lat, CultureInfo.InvariantCulture);
                double _lng = double.Parse(lng, CultureInfo.InvariantCulture);
                MainMap.Position = new PointLatLng(_lat, _lng);
                if (currentMarker.IsVisible)
                {
                    currentMarker.Position = MainMap.Position;
                    currentMarker.ToolTipText = "经度:" + MainMap.Position.Lng.ToString() + " 纬度:" + MainMap.Position.Lat.ToString();
                    currentMarker.ToolTipMode = MarkerTooltipMode.Always;
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(string.Format(
                            "drawMap -> {0}"
                            , ex.Message));
            }

        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            //if (!comport.IsOpen)
            //{
            //    comport.Open();
            //    btnOn.Enabled = false;
            //    btnOff.Enabled = true;
            //}
            // Set the port's settings
            if (ConfigManager.SetSerialPort(ref comport, this.ispci))
            {
                // Open the port
                comport.Open();
                this.btnSerialPortConfig.Enabled = false;
                this.btnOff.Enabled = true;
                this.btnOn.Enabled = false;
                this.GPS.StartInterpreter();
            }
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            bool bOk = false;
            if (comport.IsOpen)
            {
                GPS.StopInterpreter();//首先要截断新Invoke

                // 检查已经发生的Invoke是否已经全部完成
                //bOk = CheckInvokeEnd();
                bOk = _InvokeList.ChekcAllItem();
                // 如果没有全部完成，则要将消息处理让出，使Invoke有机会完成
                while (!bOk)
                {
                    Application.DoEvents();
                    Thread.Sleep(200);
                    //bOk = CheckInvokeEnd();
                    bOk = _InvokeList.ChekcAllItem();
                }
                // 全部完成后，关闭串口
                comport.Close();
                this.btnSerialPortConfig.Enabled = true;
                this.btnOff.Enabled = false;
                this.btnOn.Enabled = true;
            }
            //if (comport.IsOpen)
            //{
            //    comport.Close();
            //    btnOff.Enabled = false;
            //    btnOn.Enabled = true;
            //}
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // This method will be called when there is data waiting in the port's buffer
            // Read all the data waiting in the buffer and pasrse it

            /* http://forums.microsoft.com/MSDN/ShowPost.aspx?PageIndex=2&SiteID=1&PostID=293187
             * You would need to use Control.Invoke() to update the GUI controls
             * because unlike Windows Forms events like Button.Click which are processed 
             * in the GUI thread, SerialPort events are processed in a non-GUI thread 
             * (more precisely a ThreadPool thread). 
             */
            //this.Invoke(new EventHandler(HandleGPSstring));
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

        private void frmGPSExperiment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comport.IsOpen == true)
            {
                e.Cancel = true;
                MessageBox.Show("请先关闭GPS串口！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SerialPortConfig fsp = new SerialPortConfig(ispci, "GPS串口设置");
            fsp.ShowDialog();
        }
        private void ExitProg()
        {
            if (comport.IsOpen)
            {
                GPS.StopInterpreter();
                //bool bOk = CheckInvokeEnd();
                bool bOk = _InvokeList.ChekcAllItem();
                while (!bOk)
                {
                    Application.DoEvents();
                    Thread.Sleep(200);
                    //bOk = CheckInvokeEnd();
                    bOk = _InvokeList.ChekcAllItem();
                }
                if (bOk == true)
                {
                    comport.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExitProg();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "xml files (*.xml)|*.xml";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Debug.WriteLine(string.Format(
                                "button1_Click -> file name {0}"
                                , openFileDialog1.FileName));
                    string filePath = openFileDialog1.FileName;
                    DataSet myDataSet = new DataSet();
                    myDataSet.ReadXml(filePath);
                    DataTableCollection tables = myDataSet.Tables;
                    if (tables.Contains("point"))
                    {
                        DataTable tb = tables["point"];
                        this.dgvImportedPoints.Rows.Clear();

                        int i = 1;
                        foreach (DataRow dr in tb.Rows)
                        {
                            Debug.WriteLine(string.Format(
                                        "button1_Click -> {0} {1} {2}"
                                        , dr[0].ToString(), dr[1].ToString(), dr[2].ToString()));
                            string[] row1 = new string[] { i.ToString(), dr[0].ToString(), dr[2].ToString(), dr[1].ToString() };

                            this.dgvImportedPoints.Rows.Add(row1);
                            i++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("选择文件中数据格式有误！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("读取文件时发生意外错误： " + ex.Message);
                }
            }

        }

        private void btnShowPoint_Click(object sender, EventArgs e)
        {
            mapLayerPoints.Markers.Clear();
            if (this.dgvImportedPoints.Rows.Count > 0)
            {
                DataGridViewRowCollection rc = dgvImportedPoints.Rows;
                try
                {
                    for (int i = 0; i < rc.Count - 1; i++)
                    {
                        string index = rc[i].Cells[0].Value.ToString();
                        string time = rc[i].Cells[1].Value.ToString();
                        string lng = rc[i].Cells[2].Value.ToString();
                        string lat = rc[i].Cells[3].Value.ToString();

                        double dLng = double.Parse(lng);
                        double dLat = double.Parse(lat);
                        GMapMarkerPoint gp = new GMapMarkerPoint(new PointLatLng(dLat, dLng),index);
                        mapLayerPoints.Markers.Add(gp);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //carPointMarker = new GMapMarkerPoint(center.Position);
            //mapLayerPoints.Markers.Remove(carPointMarker);
        }
    }
}