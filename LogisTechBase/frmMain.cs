using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LogisTechBase.rfidCheck;
using Config;

namespace LogisTechBase
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Color c = Color.FromArgb(232, 245, 251);
            this.BackColor = c;
            this.axShockwaveFlash1.BGColor = "e8f5fb";
            //this.axShockwaveFlash1.BGColor = "96d3fd";

            //this.menuStrip1.BackColor = c;
            //this.statusStrip1.BackColor = c;
            this.Shown += new EventHandler(frmMain_Shown);

        }

        void frmMain_Shown(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            this.axShockwaveFlash1.Movie = path + @"\flash.swf";
        }

        private void lbtnGis_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lbtnSP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmRS232Experiment frmSP = new frmRS232Experiment();
            //frmSP.ShowDialog();
        }

        private void lbtnGPS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmGPSExperiment frmGps = new frmGPSExperiment();
            //frmGps.ShowDialog();
        }

        private void TSMItem串口通信实验_Click(object sender, EventArgs e)
        {
            //SerialPortConfigItem spci = 
            //    SerialPortConfigItem.GetConfigItem(SerialPortConfigItemName.CommonSerialPortConfig);
            SerialPortConfigItem spci =
                ConfigManager.GetConfigItem(SerialPortConfigItemName.常用串口设置);
            FrmSerialPort frmSP = new FrmSerialPort(spci);
            //frmSP.flag = 0;//串口基本实验
            frmSP.Text = "串口通信基础实验";
            frmSP.ShowDialog();
        }

        private void tsmi超高频RFID系统的操作实验_Click(object sender, EventArgs e)
        {

        }

        private void tsmiGPS通讯实验_Click(object sender, EventArgs e)
        {
            //frmGPSExperiment frmGps = new frmGPSExperiment();
            //frmGps.ShowDialog();
        }

        private void tSMItem上位机控制GSMGPRS模块基本实验_Click(object sender, EventArgs e)
        {
            SerialPortConfigItem spci =
    ConfigManager.GetConfigItem(SerialPortConfigItemName.GSM模块串口设置);
            GPRSCommandItem ci = new GPRSCommandItem();
            FrmSerialPort frmSP = new FrmSerialPort(ci, spci);
            frmSP.Text = "上位机控制GSM/GPRS模块基本实验";
            //frmSP.flag = 1;//上位机控制GSM/GPRS模块基本实验
            frmSP.ShowDialog();
        }

        private void TSMItem上位机控制GSMGPRS模块短信收发实验_Click(object sender, EventArgs e)
        {
            SerialPortConfigItem spci =
    ConfigManager.GetConfigItem(SerialPortConfigItemName.GSM模块串口设置);
            FrmSerialPort frmSP = new FrmSerialPort(spci);
            frmSP.Text = "上位机控制GSM/GPRS模块短信收发实验";
            //frmSP.flag = 2;//上位机控制GSM/GPRS模块基本实验

            frmSP.ShowDialog();
        }

        private void tsmi上位机控制GPRS通话实验_Click(object sender, EventArgs e)
        {
            SerialPortConfigItem spci =
    ConfigManager.GetConfigItem(SerialPortConfigItemName.GSM模块串口设置);
            FrmSerialPort frmSP = new FrmSerialPort(spci);
            frmSP.Text = "上位机控制GSM/GPRS模块通话基本实验";
            //frmSP.flag = 3;//上位机控制GSM/GPRS模块通话基本实验

            frmSP.ShowDialog();
        }

        private void tsmi上位机控制GPRS进行数据无线传输试验_Click(object sender, EventArgs e)
        {
            SerialPortConfigItem spci =
    ConfigManager.GetConfigItem(SerialPortConfigItemName.GSM模块串口设置);
            FrmSerialPort frmSP = new FrmSerialPort(spci);
            frmSP.Text = "上位机控制GSM/GPRS进行无线数据传输实验";
            //frmSP.flag = 4;//上位机控制GSM/GPRS进行无线数据传输实验
            frmSP.ShowDialog();
        }

        private void tsmi条形码打印机安装实验_Click(object sender, EventArgs e)
        {

        }

        private void tsmi一维条形码编码实验_Click(object sender, EventArgs e)
        {
            frmBarcodeTest bt = new frmBarcodeTest();
            bt.Show();
            //frmTBarCode tc = new frmTBarCode();
            //tc.Show();
        }

        private void 标签读取实验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUHF frmUHF = new FrmUHF();
            frmUHF.ShowDialog();
        }

        private void 通信分析试验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerialPortConfigItem spci =
    ConfigManager.GetConfigItem(SerialPortConfigItemName.超高频RFID串口设置);
            UhfCommandItem uhfItem = new UhfCommandItem();
            FrmSerialPort frmSP = new FrmSerialPort(uhfItem, spci);
            frmSP.SetShowDataStyle(SerialPortDataStyle.Hex);
            frmSP.SetSendDataStyle(SerialPortDataStyle.Hex);
            frmSP.Text = "RFID模块通信分析实验";
            //frmSP.flag = 5;//RFID模块通信分析实验
            frmSP.ShowDialog();
        }

        private void gPS数据分析实验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GPSA GPSA = new GPSA();
            GPSA.Text = "GPS数据分析实验";
            GPSA.ShowDialog();
        }

        private void 建立TCPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form2 frmSTCPIP = new Form2();
            //frmSTCPIP.Text = "建立TCP/IP服务器";
            SGSserverForm frmSTCPIP = new SGSserverForm();
            frmSTCPIP.Show();
        }

        private void 建立TCPIP客户端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form3 CTCPIP = new Form3();
            //CTCPIP.Text = "建立TCP/IP客户端";
            //CTCPIP.Show();

            LoginForm loginForm = new LoginForm();

            loginForm.ShowDialog();
            if (loginForm.DialogResult == DialogResult.OK)
            {
                SGSClient sgsClientForm = new SGSClient();
                sgsClientForm.clientSocket = loginForm.clientSocket;
                sgsClientForm.strName = loginForm.strName;

                sgsClientForm.ShowDialog();
            }
        }




        private void 标签分发ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRfidCheck_Write frmW = new FrmRfidCheck_Write();
            frmW.ShowDialog();
        }

        private void 考勤学生端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRfidCheck_Client fc = new FrmRfidCheck_Client();
            fc.Show();
        }

        private void tsmi地图的操作实验_Click(object sender, EventArgs e)
        {
            //MapMainForm mmf = new MapMainForm();
            //mmf.Show();
        }

        private void 串口参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerialPortConfig frmSPC = new SerialPortConfig();
            frmSPC.ShowDialog();

        }

        private void 学生信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRfidCheck_StudentManage frmStudentManage = new FrmRfidCheck_StudentManage();
            frmStudentManage.ShowDialog();
        }

        private void 考勤服务端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRfidCheck_Server KQFWQ = new FrmRfidCheck_Server();
            KQFWQ.Text = "考勤服务器";
            //KQFWQ.ShowDialog();
            KQFWQ.Show();
        }

        private void 考勤信息统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmCheckStatistics fcs = new FrmCheckStatistics();
            //fcs.ShowDialog();
        }

        private void 建立TCPIP服务器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SGSserverForm frmSTCPIP = new SGSserverForm();
            frmSTCPIP.Show();
        }

        private void 建立TCPIP客户端ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();

            loginForm.ShowDialog();
            if (loginForm.DialogResult == DialogResult.OK)
            {
                SGSClient sgsClientForm = new SGSClient();
                sgsClientForm.clientSocket = loginForm.clientSocket;
                sgsClientForm.strName = loginForm.strName;

                sgsClientForm.ShowDialog();
            }
        }

        private void 地图操作实验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MapMainForm mmf = new MapMainForm();
            //mmf.Show();
        }

        private void zigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmZigbeeGraph fzigbee = new frmZigbeeGraph();
            fzigbee.ShowDialog();
        }

        private void 协议分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerialPortConfigItem spci =
    ConfigManager.GetConfigItem(SerialPortConfigItemName.Zigbee模块串口设置);
            FrmSerialPort frmSP = new FrmSerialPort(spci);
            frmSP.SetShowDataStyle(SerialPortDataStyle.Hex);
            //frmSP.flag = 0;//串口基本实验
            frmSP.Text = "Zigbee协议分析实验";
            frmSP.ShowDialog();
        }

        private void tsmiGPS数据采集实验_Click(object sender, EventArgs e)
        {

        }

        private void MIGPRS应用实验_Click(object sender, EventArgs e)
        {

        }

        private void tsmi条码识别实验_Click(object sender, EventArgs e)
        {
            SerialPortConfigItem spci =
ConfigManager.GetConfigItem(SerialPortConfigItemName.条码模块);
            BarcodeCommandItem item = new BarcodeCommandItem();
            FrmSerialPort frmSP = new FrmSerialPort(item, spci);
            frmSP.Text = "条码模块协议分析实验";
            frmSP.ShowDialog();
        }

        private void 条码读取实验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReadBar frm = new frmReadBar();
            frm.ShowDialog();
        }

        private void 高频RFID协议实验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerialPortConfigItem spci =
ConfigManager.GetConfigItem(SerialPortConfigItemName.高频RFID串口设置);
            HFCommandItem item = new HFCommandItem();
            FrmSerialPort frmSP = new FrmSerialPort(item, spci);
            frmSP.Text = "高频RFID协议分析实验";
            frmSP.ShowDialog();
        }

        private void 高频RFIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHFRead frm = new frmHFRead();
            frm.ShowDialog();
        }

        private void tsmi二维条码实验_Click(object sender, EventArgs e)
        {
            frm2DBarcodeEncode frm = new frm2DBarcodeEncode();
            frm.ShowDialog();
        }

        private void 二维条码解码实验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm2DBarcodeDecode frm = new frm2DBarcodeDecode();
            frm.ShowDialog();
        }

        private void 一维条形码编码实验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBarcodeTest bt = new frmBarcodeTest();
            bt.Show();
        }

        private void 条码模块协议分析实验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerialPortConfigItem spci =
ConfigManager.GetConfigItem(SerialPortConfigItemName.条码模块);
            BarcodeCommandItem item = new BarcodeCommandItem();
            FrmSerialPort frmSP = new FrmSerialPort(item, spci);
            frmSP.Text = "条码模块协议分析实验";
            frmSP.ShowDialog();
        }

        private void 一维条码读取实验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReadBar frm = new frmReadBar();
            frm.ShowDialog();
        }

        private void 二维条码编码实验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm2DBarcodeEncode frm = new frm2DBarcodeEncode();
            frm.ShowDialog();
        }

        private void 二维条码解码实验ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm2DBarcodeDecode frm = new frm2DBarcodeDecode();
            frm.ShowDialog();
        }

        private void gPRS实验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerialPortConfigItem spci =
ConfigManager.GetConfigItem(SerialPortConfigItemName.GSM模块串口设置);
            GPRSCommandItem ci = new GPRSCommandItem();
            FrmSerialPort frmSP = new FrmSerialPort(ci, spci);
            frmSP.Text = "GSM/GPRS模块协议分析实验";
            //frmSP.flag = 1;//上位机控制GSM/GPRS模块基本实验
            frmSP.ShowDialog();
        }

        private void gPS数据分析实验ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GPSA GPSA = new GPSA();
            GPSA.Text = "GPS数据分析实验";
            GPSA.ShowDialog();
        }

        private void 地图操作实验ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //frmGPSExperiment frmGps = new frmGPSExperiment();
            frmGPSOnMap frmGps = new frmGPSOnMap();
            frmGps.ShowDialog();
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        private void 系统设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSysSettings frm = new frmSysSettings();
            frm.ShowDialog();
        }

        private void gPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGPSReceiver frm = new frmGPSReceiver();
            frm.ShowDialog();
        }

        private void 退出QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 

        private void gISGPS数据采集与分析管理系统GToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGPSReceiver frm = new frmGPSReceiver();
            frm.ShowDialog();
        }

        private void gPSGPRSGIS物流运输监控管理系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmGPSMonitoring frm = new frmGPSMonitoring();
            //frm.ShowDialog();
        }

        private void 仓库环境监测管理系统MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEnvironmentMonitoring frm = new frmEnvironmentMonitoring();
            frm.ShowDialog();
        }




    }
}
