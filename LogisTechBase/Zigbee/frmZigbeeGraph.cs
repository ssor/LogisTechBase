using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using ZedGraph;
using System.Threading;
using System.Diagnostics;
using Config;

namespace LogisTechBase
{
    public partial class frmZigbeeGraph : Form
    {
        SerialPort comport = new SerialPort();
        ZigbeeHelper helper = new ZigbeeHelper();
        private ZedGraphControl zedGraphControl1;
        private PointPairList pointPairList = new PointPairList();
        //CurveInfo humiCurveInfo = new CurveInfo("湿度", Color.Red);
        //CurveInfo tempCurveInfo = new CurveInfo("温度", Color.Blue);
        CurveInfoList humiCurveInfoList = new CurveInfoList();
        CurveInfoList tempetureCurveInfoList = new CurveInfoList();

        ISerialPortConfigItem ispci =
            ConfigManager.GetConfigItem(SerialPortConfigItemName.Zigbee模块串口设置);
        //SerialPortConfigItem.GetConfigItem(SerialPortConfigItemName.WSNSerialPortConfig);

        InvokeDic _InvokeList = new InvokeDic();
        bool bStopListening = false;
        public frmZigbeeGraph()
        {
            InitializeComponent();

            this.btnClosePort.Enabled = false;
            comport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            this.Shown += new EventHandler(frmZigbeeGraph_Shown);
            this.FormClosing += new FormClosingEventHandler(frmZigbeeGraph_FormClosing);

        }

        void frmZigbeeGraph_FormClosing(object sender, FormClosingEventArgs e)
        {
            button2_Click(sender, e);
        }

        void frmZigbeeGraph_Shown(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 0;
            CreateGraph_jingzhi(this.zedGraphControl1);
            this.helper.eventZigInfo += new delZigbeeCallback(helper_eventZigInfo);
        }
        //delegate void deleInvokeZigbeeGraph(int index, int nodeID, int humi, int temp);
        void helper_eventZigInfo(int index, int nodeID, int humi, int temp)
        {
            HandleZigbeeData(index, nodeID, humi, temp);
            HandletxtLog(index, nodeID, humi, temp);
            //if (this.zedGraphControl1.InvokeRequired)
            //{
            //    this.zedGraphControl1.Invoke(
            //        new delZigbeeCallback(HelperInvoke), index, nodeID, humi, temp);
            //}
            //else
            //{
            //    HelperInvoke(index, nodeID, humi, temp);
            //}
            //if (this.txtLog.InvokeRequired)
            //{
            //    this.txtLog.Invoke(
            //            new delZigbeeCallback(txtLogInvoke), index, nodeID, humi, temp);
            //}
            //else
            //{
            //    txtLogInvoke(index, nodeID, humi, temp);
            //}
        }
        void HandletxtLog(int index, int nodeID, int humi, int temp)
        {
            if (!_InvokeList.CheckItem("UpdatetxtLog"))
            {
                return;
            }
            _InvokeList.SetItem("UpdatetxtLog", false);
            Debug.WriteLine(
             string.Format("frmZigbeeGraph.HandletxtLog  ->  = {0}"
             , "false"));
            this.txtLog.Invoke(new delZigbeeCallback(UpdatetxtLog), index, nodeID, humi, temp);

        }
        void UpdatetxtLog(int index, int nodeID, int humi, int temp)
        {
            txtLogInvoke(index, nodeID, humi, temp);

            _InvokeList.SetItem("UpdatetxtLog", true);
            Debug.WriteLine(
                string.Format("frmZigbeeGraph.UpdatetxtLog  ->  = {0}"
                , "true"));
        }
        void HandleZigbeeData(int index, int nodeID, int humi, int temp)
        {
            if (!_InvokeList.CheckItem("UpdateZigbeeData"))
            {
                return;
            }
            _InvokeList.SetItem("UpdateZigbeeData", false);
            Debug.WriteLine(
            	string.Format("frmZigbeeGraph.HandleZigbeeData  ->  = {0}"
            	, "false"));
            this.zedGraphControl1.Invoke(
                new delZigbeeCallback(UpdateZigbeeData), index, nodeID, humi, temp);

        }
        void UpdateZigbeeData(int index, int nodeID, int humi, int temp)
        {
            HelperInvoke(index, nodeID, humi, temp);
            _InvokeList.SetItem("UpdateZigbeeData", true);
            Debug.WriteLine(
            	string.Format("frmZigbeeGraph.UpdateZigbeeData  ->  = {0}"
            	, "true"));
        }
        void txtLogInvoke(int index, int nodeID, int humi, int temp)
        {
            //this.txtLog.Text +=
            //    string.Format("数据包号：{0} 节点ID：{1} 湿度：{2} 温度：{3}\r\n"
            //                    , index.ToString(), nodeID.ToString(), humi.ToString(), temp.ToString());
            this.txtLog.Text =
                    string.Format(" {0}  数据包号：{1} 节点ID：{2} 湿度：{3} 温度：{4}\r\n"
                    , DateTime.Now.ToShortTimeString() + ":" + DateTime.Now.Second.ToString(),
                    index.ToString(),
                    nodeID.ToString(),
                    humi.ToString(),
                    temp.ToString()) + txtLog.Text;
            //txtLog.SelectionStart = this.txtLog.Text.Length;
            //txtLog.ScrollToCaret();
        }
        void HelperInvoke(int index, int nodeID, int humi, int temp)
        {
            //CurveInfo tempInfo = humiCurveInfo;
            CurveInfo tempInfo = null;
            CurveInfoList tempList = null;
            this.zedGraphControl1.GraphPane.XAxis.Scale.MaxAuto = true;
            //this.zedGraphControl1.GraphPane.XAxis.Scale.Max
            double y = humi;
            switch (comboBox1.SelectedIndex)
            {
                case 0://湿度
                    y = humi;
                    //tempInfo = humiCurveInfo;
                    tempList = humiCurveInfoList;
                    tempInfo = humiCurveInfoList.getCurveInfoByNodeID(nodeID);
                    if (tempInfo == null)
                    //如果当前节点尚未建立
                    {
                        Color color = CurveInfoList.GetRadomColor(humiCurveInfoList);
                        CurveInfo ciNew = new CurveInfo(nodeID, "节点" + nodeID.ToString(), color);
                        humiCurveInfoList.addNode(ciNew);
                        this.AddHumidityCurve();
                        tempInfo = ciNew;
                    }
                    break;
                case 1://温度
                    y = temp;
                    tempList = tempetureCurveInfoList;
                    //tempInfo = tempCurveInfo;
                    tempInfo = tempetureCurveInfoList.getCurveInfoByNodeID(nodeID);
                    if (tempInfo == null)
                    {
                        Color color = CurveInfoList.GetRadomColor(tempetureCurveInfoList);
                        CurveInfo ciNew = new CurveInfo(nodeID, "节点" + nodeID.ToString(), color);
                        tempetureCurveInfoList.addNode(ciNew);
                        this.AddTemperatureCurve();
                        tempInfo = ciNew;
                    }
                    break;
            }
            double x = (double)new XDate(DateTime.Now);
            //pointPairList.Add(x, y);
            tempInfo.AddPoint(x, y);
            this.zedGraphControl1.AxisChange();
            this.zedGraphControl1.Refresh();
            int maxPoint = 20;
            foreach (CurveInfo ci in tempList)
            {
                ci.AddPoint(x, double.MaxValue);
                if (ci.PointPairList.Count > maxPoint)
                {
                    //ci.PointPairList.RemoveAt(0);
                    int sub = ci.PointPairList.Count - maxPoint;
                    if (sub > 0)
                    {
                        ci.PointPairList.RemoveRange(0, sub);
                    }
                }
            }
            //if (tempInfo.PointPairList.Count >= 10)
            //{
            //tempInfo.PointPairList.RemoveAt(0);
            //}
            //if (pointPairList.Count >= 50)
            //{
            //    pointPairList.RemoveAt(0);
            //}
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comport == null)
            {
                return;
            }
            try
            {
                if (!comport.IsOpen)
                {
                    if (ConfigManager.SetSerialPort(ref comport, ispci))
                    {
                        comport.Open();

                        this.btnClosePort.Enabled = true;
                        this.btnOpenPort.Enabled = false;
                        this.btnPortConfig.Enabled = false;
                        bStopListening = false;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //ZigbeeHelper zh = new ZigbeeHelper();
            //byte[] bt = new byte[] { 0, 0x37, 0, 0x15, 0x8D, 0, 0, 0xA, 0xE2, 0x3A, 0, 0x1, 0, 0x4A, 0, 0x1E, 0xA, 0xD9, 0, 0x73, 0, 0xE, 0xFF, 0xFF };
            //zh.Parse(bt);
        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (bStopListening == true)
            {
                return;
            }
            try
            {
                int n = comport.BytesToRead;//n为返回的字节数
                byte[] buf = new byte[n];//初始化buf 长度为n
                comport.Read(buf, 0, n);//读取返回数据并赋值到数组
                //_RFIDHelper.Parse(buf,true);
                helper.Parse(buf);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comport != null)
            {
                bStopListening = true;
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

                this.btnOpenPort.Enabled = true;
                this.btnClosePort.Enabled = false;
                this.btnPortConfig.Enabled = true;
            }
        }
        private void CreateGraph_jingzhi(ZedGraphControl zg1)
        {
            #region 现实特征设置
            // get a reference to the GraphPane
            GraphPane myPane = zg1.GraphPane;

            // Change the color of the title
            myPane.Title.FontSpec.FontColor = Color.Green;

            // Add gridlines to the plot, and make them gray
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.Color = Color.LightGray;
            myPane.YAxis.MajorGrid.Color = Color.LightGray;

            myPane.XAxis.Type = ZedGraph.AxisType.DateAsOrdinal;
            //myPane.XAxis.Type = ZedGraph.AxisType.Date; 

            myPane.XAxis.Scale.Format = "HH:mm:ss";   //DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") 
            myPane.XAxis.Scale.MajorUnit = DateUnit.Second;
            myPane.XAxis.Scale.MinorUnit = DateUnit.Second;
            myPane.XAxis.Scale.MajorStep = 1;
            myPane.XAxis.Scale.MinorStep = 1;

            //myPane.XAxis.Scale.MinAuto = false;
            //myPane.XAxis.Scale.MaxAuto = false;
            //myPane.XAxis.Scale.MajorStepAuto = false;

            //myPane.XAxis.Scale.Max = 10;   
            //myPane.XAxis.Scale.Format = "MM-dd  HH:mm:ss";   //DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") 

            myPane.XAxis.Scale.FontSpec.Angle = 0;
            //myPane.XAxis.Scale.FontSpec.Size = 14;  //字号 ,最好不要设置
            //myPane.XAxis.Scale.FontSpec.IsBold = true;
            myPane.XAxis.Scale.FontSpec.Border.Style = System.Drawing.Drawing2D.DashStyle.Solid;

            // Move the legend location
            //myPane.Legend.Position = ZedGraph.LegendPos.InsideBotRight;
            myPane.Legend.Position = ZedGraph.LegendPos.Bottom;

            // Make both curves thicker
            //myCurve.Line.Width = 2.0F;
            //myCurve2.Line.Width = 2.0F;

            #endregion

            //LineItem myCurve;

            //zg1.GraphPane.Title.Text = "湿度曲线图";
            //zg1.GraphPane.XAxis.Title.Text = "时间";
            //zg1.GraphPane.YAxis.Title.Text = "湿度值";
            //zg1.GraphPane.XAxis.Type = ZedGraph.AxisType.DateAsOrdinal; ;



            ////zg1.GraphPane.XAxis.MajorTic.PenWidth = 8.0F;


            //myCurve = zg1.GraphPane.AddCurve("湿度", list, Color.DarkGreen, SymbolType.None);
            //zg1.AxisChange();
            //zg1.Refresh();

        }
        void AddTemperatureCurve()
        {
            LineItem myCurve;
            //if (tempetureCurveInfoList.HasNodes())
            {
                this.zedGraphControl1.GraphPane.Title.Text = "温度曲线图";
                zedGraphControl1.GraphPane.XAxis.Title.Text = "时间";
                zedGraphControl1.GraphPane.YAxis.Title.Text = "温度值";
                //zedGraphControl1.GraphPane.XAxis.Type = ZedGraph.AxisType.Date; ;
                //zedGraphControl1.GraphPane.XAxis.Type = ZedGraph.AxisType.DateAsOrdinal; ;

                //zg1.GraphPane.XAxis.MajorTic.PenWidth = 8.0F;
                foreach (CurveInfo ci in tempetureCurveInfoList)
                {
                    zedGraphControl1.GraphPane.AddCurve(
                            ci.CurveName,
                            ci.PointPairList, ci.CurveColor, SymbolType.Diamond);
                }

                //zedGraphControl1.GraphPane.AddCurve(
                //            tempCurveInfo.CurveName,
                //            tempCurveInfo.PointPairList,
                //           tempCurveInfo.CurveColor, SymbolType.None);
                //myCurve = zedGraphControl1.GraphPane.AddCurve("温度", this.pointPairList, Color.DarkGreen, SymbolType.None);
                zedGraphControl1.AxisChange();
                zedGraphControl1.Refresh();

            }
        }
        void AddHumidityCurve()
        {
            LineItem myCurve;
            //if (humiCurveInfoList.HasNodes())
            {
                this.zedGraphControl1.GraphPane.Title.Text = "湿度曲线图";
                zedGraphControl1.GraphPane.XAxis.Title.Text = "时间";
                zedGraphControl1.GraphPane.YAxis.Title.Text = "湿度值";
                //zedGraphControl1.GraphPane.XAxis.Type = ZedGraph.AxisType.Date;
                //zedGraphControl1.GraphPane.XAxis.Type = ZedGraph.AxisType.DateAsOrdinal; ;

                //zg1.GraphPane.XAxis.MajorTic.PenWidth = 8.0F;

                foreach (CurveInfo ci in humiCurveInfoList)
                {
                    myCurve = zedGraphControl1.GraphPane.AddCurve(
                             ci.CurveName,
                             ci.PointPairList, ci.CurveColor, SymbolType.Diamond);
                }
                //zedGraphControl1.GraphPane.AddCurve(
                //        humiCurveInfo.CurveName,
                //        humiCurveInfo.PointPairList, humiCurveInfo.CurveColor, SymbolType.Diamond);
                //myCurve = zedGraphControl1.GraphPane.AddCurve("湿度", pointPairList, Color.DarkGreen, SymbolType.None);
                zedGraphControl1.AxisChange();
                zedGraphControl1.Refresh();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    this.zedGraphControl1.GraphPane.RemoveAllCurve();
                    //this.humiCurveInfo.PointPairList.Clear();
                    humiCurveInfoList.RemoveAllNodes();
                    this.AddHumidityCurve();
                    break;
                case 1:
                    this.zedGraphControl1.GraphPane.RemoveAllCurve();
                    //this.pointPairList.Clear();
                    //tempCurveInfo.PointPairList.Clear();
                    tempetureCurveInfoList.RemoveAllNodes();
                    this.AddTemperatureCurve();
                    break;
            }
        }

        private void btnPortConfig_Click(object sender, EventArgs e)
        {
            SerialPortConfig fsp = new SerialPortConfig(ispci, "Zigbee串口设置");
            fsp.ShowDialog();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.button2_Click(sender, e);
            this.Close();
        }
    }
}
