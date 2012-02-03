using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;


namespace LogisTechBase
{

    public partial class GPSA : Form
    {
        /// <summary>
        /// 每个调用UI更新的函数在该列表中添加表示更新状态的标识，开始时将其标识为false，完成后标识为true
        /// form退出时，首先检查该列表中的标识是否全为true，之后才会释放UI资源
        /// </summary>
        InvokeDic _InvokeList = new InvokeDic();
        #region declarations
        // NMEA interpreter
        NmeaInterpreter GPS = new NmeaInterpreter();
        // OSGridConverter
        NMEA2OSG OSGconv = new NMEA2OSG();

        ISerialPortConfigItem ispci =
            SerialPortConfigItem.GetConfigItem(SerialPortConfigItemName.GPS串口设置);
            //SerialPortConfigItem.GetConfigItem(SerialPortConfigItemName.GPSSerialPortConfig);
        //ISerialPortConfigItem ispci = SerialPortConfigItem.GetGPSConfigItem();


        // The main control for communicating through the RS-232 port
        private SerialPort comport = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        public string[] gpsString;
        public string instring;
        public string[] nrthest;
        public double ellipHeight;
        bool bShowGPGSV = true;
        bool bShowGPRMC = true;
        bool bShowGPGMC = true;
        #endregion

        public GPSA()
        {
            // Build the form
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(GPSA_FormClosing);
            // Restore the users settings
            InitialiseControlValues();
            comport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);//zxy

            GPS.GPGSVReceived += new NmeaInterpreter.SearialDataReceivedEventHandler(GPS_DataGPRSVReceived);
            GPS.GPRMCReceived += new NmeaInterpreter.SearialDataReceivedEventHandler(GPS_DataGPRMCReceived);
            GPS.GPGMCParsed += new NmeaInterpreter.SearialDataReceivedEventHandler(GPS_GPGMCParsed);

            GPS.PositionReceived += new NmeaInterpreter.PositionReceivedEventHandler(GPS_PositionReceived);
            GPS.SatellitesInViewReceived += new NmeaInterpreter.SatellitesInViewReceivedEventHandler(GPS_SatellitesInViewReceived);//ZXY
            GPS.SatellitesUsed += new NmeaInterpreter.SatellitesUsedReceivedEventHandler(GPS_SatellitesUsed);
            GPS.SpeedReceived += new NmeaInterpreter.SpeedReceivedEventHandler(GPS_SpeedReceived);
            GPS.BearingReceived += new NmeaInterpreter.BearingReceivedEventHandler(GPS_BearingReceived);
            GPS.FixLost += new NmeaInterpreter.FixLostEventHandler(GPS_FixLost);
            GPS.FixObtained += new NmeaInterpreter.FixObtainedEventHandler(GPS_FixObtained);
            GPS.HDOPReceived += new NmeaInterpreter.HDOPReceivedEventHandler(GPS_HDOPReceived);//zxy
            GPS.EllipsoidHeightReceived += new NmeaInterpreter.EllipsoidHeightReceivedEventHandler(GPS_EllipsoidHeightReceived);  //zxy

            //OSGconv.NorthingEastingReceived += new NMEA2OSG.NorthingEastingReceivedEventHandler(OSGconv_NorthingEastingReceived);//zxy
            //OSGconv.NatGridRefReceived += new NMEA2OSG.NatGridRefReceivedEventHandler(OSGconv_NatGridRefReceived);//zxy
        }

        void GPSA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comport.IsOpen == true)
            {
                e.Cancel = true;
                MessageBox.Show("请先关闭GPS串口！");
            }
        }

        #region serialport
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {//zxy
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
        {//zxy
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
                    instring += inbuff;
                }
                gpsString = instring.Split();
                foreach (string item in gpsString) GPS.Parse(item);
            }
        }
        #endregion

        private void InitialiseControlValues()
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExitProg();
        }

        void myTimer_Elapsed_ExitProg(object sender, System.Timers.ElapsedEventArgs e)
        {
            ExitProg();
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
            this.Close();
        }

        #region GPS data
        private void GPS_DataGPRMCReceived(string strGprmc)
        {
            if (!_InvokeList.CheckItem("GPS_DataGPRMCReceived"))
            {
                return;
            }
            _InvokeList.SetItem("GPS_DataGPRMCReceived", false);

            this.tbGpsData.Invoke(new deleUpdateContorl(Update_tbGpsData_GPRMC), strGprmc);

        }
        void Update_tbGpsData_GPRMC(string s)
        {
            if (this.bShowGPRMC)
            {
                if (this.tbGpsData.Text == "")
                {
                    this.tbGpsData.Text = s;
                }
                else
                {
                    this.tbGpsData.Text = s + "\r\n" + this.tbGpsData.Text;
                }
            }
            _InvokeList.SetItem("GPS_DataGPRMCReceived", true);
        }
        private void GPS_GPGMCParsed(string strMc)
        {
            if (!_InvokeList.CheckItem("GPS_GPGMCParsed"))
            {
                return;
            }
            _InvokeList.SetItem("GPS_GPGMCParsed", false);

            this.tbGpsData.Invoke(new deleUpdateContorl(Update_tbGpsData_GPGMC), strMc);

        }
        void Update_tbGpsData_GPGMC(string s)
        {
            if (bShowGPGMC)
            {
                if (this.tbGpsData.Text == "")
                {
                    this.tbGpsData.Text = s;
                }
                else
                {
                    this.tbGpsData.Text = s + "\r\n" + this.tbGpsData.Text;
                }
            }
            _InvokeList.SetItem("GPS_GPGMCParsed", true);
        }
        private void GPS_DataGPRSVReceived(string strGprsv)
        {
            if (!_InvokeList.CheckItem("GPS_DataGPRSVReceived"))
            {
                return;
            }
            _InvokeList.SetItem("GPS_DataGPRSVReceived", false);

            this.tbGpsData.Invoke(new deleUpdateContorl(Update_tbGpsData_GPRSV), strGprsv);

        }

        void Update_tbGpsData_GPRSV(string s)
        {
            if (this.bShowGPGSV)
            {
                if (this.tbGpsData.Text == "")
                {
                    this.tbGpsData.Text = s;
                }
                else
                {
                    this.tbGpsData.Text = s + "\r\n" + this.tbGpsData.Text;
                }
            }
            _InvokeList.SetItem("GPS_DataGPRSVReceived", true);
        }
        private void GPS_PositionReceived(string Lat, string Lon)
        {
            if (!_InvokeList.CheckItem("GPS_PositionReceived_lat") ||
                !_InvokeList.CheckItem("GPS_PositionReceived_lon") ||
                !_InvokeList.CheckItem("GPS_PositionReceived_deciLat") ||
                !_InvokeList.CheckItem("GPS_PositionReceived_deciLon")
                )
            {
                return;
            }


            _InvokeList.SetItem("GPS_PositionReceived_lat", false);
            _InvokeList.SetItem("GPS_PositionReceived_lon", false);
            _InvokeList.SetItem("GPS_PositionReceived_deciLat", false);
            _InvokeList.SetItem("GPS_PositionReceived_deciLon", false);
            if (textBoxLat.InvokeRequired)
            {
                textBoxLat.Invoke(new deleUpdateContorl(Update_textBoxLat), Lat);
            }
            else
            {
                textBoxLat.Text = Lat;
            }
            if (textBoxLon.InvokeRequired)
            {
                textBoxLon.Invoke(new deleUpdateContorl(Update_textBoxlon), Lon);
            }
            else
            {
                textBoxLon.Text = Lon;
            }
            //convert to OS grid
            if (OSGconv.ParseNMEA(Lat, Lon, ellipHeight))
            {
                //display decimal values of lat and lon
                if (textBox1.InvokeRequired)
                {
                    textBox1.Invoke(new deleUpdateContorl(Update_textBoxDeciLat), Convert.ToString(OSGconv.deciLat));
                }
                else
                {
                    textBox1.Text = Convert.ToString(OSGconv.deciLat);
                }
                if (textBox2.InvokeRequired)
                {
                    textBox2.Invoke(new deleUpdateContorl(Update_textBoxDeciLon), Convert.ToString(OSGconv.deciLon));
                }
                else
                {
                    textBox2.Text = Convert.ToString(OSGconv.deciLon);
                }
            }
        }
        void Update_textBoxDeciLon(string deciLon)
        {
            textBox2.Text = deciLon;
            _InvokeList.SetItem("GPS_PositionReceived_deciLon", true);
        }
        void Update_textBoxDeciLat(string deciLat)
        {
            textBox1.Text = deciLat;
            _InvokeList.SetItem("GPS_PositionReceived_deciLat", true);
        }
        void Update_textBoxLat(string Lat)
        {
            textBoxLat.Text = Lat;
            _InvokeList.SetItem("GPS_PositionReceived_lat", true);
        }
        void Update_textBoxlon(string Lon)
        {
            textBoxLon.Text = Lon;
            _InvokeList.SetItem("GPS_PositionReceived_lon", true);
        }
        private void GPS_SatellitesInViewReceived(int SatInView)
        {
            if (!_InvokeList.CheckItem("GPS_SatellitesInViewReceived"))
            {
                return;
            }
            _InvokeList.SetItem("GPS_SatellitesInViewReceived", false);


            if (textBoxSatInView.InvokeRequired)
            {
                this.textBoxSatInView.Invoke(new deleUpdateContorl(Update_textBoxSatellitesInView), SatInView.ToString());
            }
            else
            {
                textBoxSatInView.Text = Convert.ToString(SatInView);
            }
        }
        void Update_textBoxSatellitesInView(string SatellitesInView)
        {
            textBoxSatInView.Text = SatellitesInView;
            _InvokeList.SetItem("GPS_SatellitesInViewReceived", true);
        }
        private void GPS_SatellitesUsed(int SatInUse)
        {
            if (!_InvokeList.CheckItem("GPS_SatellitesUsed"))
            {
                return;
            }
            _InvokeList.SetItem("GPS_SatellitesUsed", false);


            if (textBoxSatInUse.InvokeRequired)
            {
                this.textBoxSatInUse.Invoke(new deleUpdateContorl(Update_textBoxSatInUse), SatInUse.ToString());
            }
            else
            {
                textBoxSatInUse.Text = Convert.ToString(SatInUse);
            }
        }
        void Update_textBoxSatInUse(string SatInUse)
        {
            textBoxSatInUse.Text = SatInUse;
            _InvokeList.SetItem("GPS_SatellitesUsed", true);
        }
        private void GPS_SpeedReceived(double Speed)
        {
            if (!_InvokeList.CheckItem("GPS_SpeedReceived"))
            {
                return;
            }
            _InvokeList.SetItem("GPS_SpeedReceived", false);


            if (textBoxSpeed.InvokeRequired)
            {
                this.textBoxSpeed.Invoke(new deleUpdateContorl(Update_textBoxSpeed), Speed.ToString());
            }
            else
            {
                textBoxSpeed.Text = Convert.ToString(Speed);
            }
        }
        void Update_textBoxSpeed(string Speed)
        {
            textBoxSpeed.Text = Speed;
            _InvokeList.SetItem("GPS_SpeedReceived", true);
        }
        private void GPS_BearingReceived(double Bearing)
        {
            if (!_InvokeList.CheckItem("GPS_BearingReceived"))
            {
                return;
            }
            _InvokeList.SetItem("GPS_BearingReceived", false);

            if (textBoxBearing.InvokeRequired)
            {
                this.textBoxBearing.Invoke(new deleUpdateContorl(Update_textBoxBearing), Bearing.ToString());
            }
            else
            {
                textBoxBearing.Text = Convert.ToString(Bearing);
            }
        }
        void Update_textBoxBearing(string Bearing)
        {
            textBoxBearing.Text = Bearing;
            _InvokeList.SetItem("GPS_BearingReceived", true);
        }
        void GPS_FixLost()
        {
            if (!_InvokeList.CheckItem("GPS_FixLost"))
            {
                return;
            }
            _InvokeList.SetItem("GPS_FixLost", false);

            if (textBoxFix.InvokeRequired)
            {
                this.textBoxFix.Invoke(new deleUpdateContorl(Update_textBoxFixLost), "无效数据");
            }
            else
            {
                textBoxFix.Text = "无效数据";
            }
        }
        void Update_textBoxFixLost(string fix)
        {
            textBoxFix.Text = fix;
            _InvokeList.SetItem("GPS_FixLost", true);
        }
        void GPS_FixObtained()
        {
            if (!_InvokeList.CheckItem("GPS_FixObtained"))
            {
                return;
            }
            _InvokeList.SetItem("GPS_FixObtained", false);

            if (textBoxFix.InvokeRequired)
            {
                this.textBoxFix.Invoke(new deleUpdateContorl(Update_textBoxFixObtained), "有效数据");
            }
            else
            {
                textBoxFix.Text = "有效数据";
            }
        }
        void Update_textBoxFixObtained(string fix)
        {
            textBoxFix.Text = fix;
            _InvokeList.SetItem("GPS_FixObtained", true);
        }
        void GPS_HDOPReceived(double value)
        {
            if (!_InvokeList.CheckItem("GPS_HDOPReceived"))
            {
                return;
            }
            _InvokeList.SetItem("GPS_HDOPReceived", false);

            if (textBoxHDOP.InvokeRequired)
            {
                this.textBoxHDOP.Invoke(new deleUpdateContorl(Update_textBoxHDOP), value.ToString());
            }
            else
            {
                textBoxHDOP.Text = Convert.ToString(value);
            }
        }
        void Update_textBoxHDOP(string value)
        {
            textBoxHDOP.Text = value;

            _InvokeList.SetItem("GPS_HDOPReceived", true);
        }
        void GPS_EllipsoidHeightReceived(double value)
        {
            ellipHeight = value;
            if (!_InvokeList.CheckItem("GPS_EllipsoidHeightReceived"))
            {
                return;
            }
            _InvokeList.SetItem("GPS_EllipsoidHeightReceived", false);


            if (textBoxEllipsoidHeight.InvokeRequired)
            {
                this.textBoxEllipsoidHeight.Invoke(new deleUpdateContorl(Update_textBoxEllipsoidHeight), value.ToString());
            }
            else
            {
                textBoxEllipsoidHeight.Text = Convert.ToString(value);
            }
        }
        void Update_textBoxEllipsoidHeight(string value)
        {
            textBoxEllipsoidHeight.Text = value;
            _InvokeList.SetItem("GPS_EllipsoidHeightReceived", true);
        }
        #endregion

        #region OSGconv data

        void OSGconv_NatGridRefReceived(string ngr)
        {
            textBoxGridRef.Text = ngr;
        }

        void OSGconv_NorthingEastingReceived(double northing, double easting)
        {//zxy
            textBoxNorthing.Text = Convert.ToString(northing);
            textBoxEasting.Text = Convert.ToString(easting);
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
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
                this.ProgressControl1.Stop();
                if (button1.InvokeRequired)
                {
                    button1.Invoke(new deleUpdateCommContorl(UpdateControl), "button", button1, "打开端口");
                }
                else
                {
                    button1.Text = "打开端口";
                }
            }
            else
            {
                // Set the port's settings
                if (ConfigManager.SetSerialPort(ref comport, this.ispci))
                {
                    // Open the port
                    comport.Open();
                    this.btnSerialPortConfig.Enabled = false;
                    this.GPS.StartInterpreter();
                    button1.Text = "关闭端口";
                    this.ProgressControl1.Start();
                }
            }
        }
        void UpdateControl(string type, object control, string content)
        {
            if (type == "button")
            {
                ((Button)control).Text = content;
                return;
            }
            if (type == "label")
            {
                ((Label)control).Text = content;
                return;
            }
        }
        void myTimer_Elapsed_CloseSerialPort(object sender, System.Timers.ElapsedEventArgs e)
        {
            button1_Click(null, null);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ExitProg();
        }

        private void lblComPort_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBoxGPGSV_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGPGSV.Checked)
            {
                bShowGPGSV = true;
            }
            else
            {
                bShowGPGSV = false;
            }
        }

        private void checkBoxGPRMC_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGPRMC.Checked)
            {
                bShowGPRMC = true;
            }
            else
            {
                bShowGPRMC = false;
            }
        }

        private void checkBoxGPGMC_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGPGMC.Checked)
            {
                bShowGPGMC = true;
            }
            else
            {
                bShowGPGMC = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.tbGpsData.Text = "";
        }
        private void btnSerialPortConfig_Click(object sender, EventArgs e)
        {
            SerialPortConfig fsp = new SerialPortConfig(ispci, "GPS串口设置");
            fsp.ShowDialog();
        }


    }

}
