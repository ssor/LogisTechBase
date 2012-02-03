using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;

namespace LogisTechBase.rfidCheck
{

    public partial class FrmRfidCheck_Write : Form
    {
        /*
         标签初始化过程：
         * 1 获取标签
         * 2 读取密码区域数据
         * 3 检查是否已经使用
         * 4 与数据库字段相关联
         */
        bool bInitiallizing = false;
        SerialPort comport = new SerialPort();
        RFIDHelper _RFIDHelper = new RFIDHelper();
        ISerialPortConfigItem ispc =
          SerialPortConfigItem.GetConfigItem(SerialPortConfigItemName.超高频RFID串口设置);
        string tagEpc = string.Empty;
        string tagUII = string.Empty;
        public FrmRfidCheck_Write()
        {
            InitializeComponent();
            //this.lblSecretConfirm.Text = "";
            this.button1.Enabled = false;
            this.txtId.TextChanged += new EventHandler(txtId_TextChanged);
            label7.Text = "未选中学生";


            toolTip1.SetToolTip(this.button1, "学生信息与rfid标签关联");
            toolTip1.SetToolTip(this.btnPersonManage, "管理学生信息");
            toolTip1.SetToolTip(this.EditTag, "编辑rfid标签");

        }

        void txtId_TextChanged(object sender, EventArgs e)
        {
            if (null == txtId.Text || txtId.Text.Trim().Length <= 0)
            {
                this.button1.Enabled = false;
            }
            else
            {
                this.button1.Enabled = true;
            }
        }
        void FrmRfidCheck_Write_Shown(object sender, System.EventArgs e)
        {
        }
        private void FrmRfidCheck_Write_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(FrmRfidCheck_Write_FormClosing);
            this.ShowPerson();

            this.statusLabel.Text = "";

            // 将串口数据输入到Helper类
            comport.DataReceived += new SerialDataReceivedEventHandler(comport_DataReceived);
            //使得Helper类可以向串口中写入数据
            _RFIDHelper.evtWriteToSerialPort += new deleVoid_Byte_Func(RFIDHelper_evtWriteToSerialPort);
            // 处理当前操作的状态
            _RFIDHelper.evtCardState += new deleVoid_RFIDEventType_Object_Func(_RFIDHelper_evtCardState);
            //启动时检查设备状态
            //_RFIDHelper.SendCommand(RFIDHelper.RFIDCommand_RMU_GetStatus, RFIDEventType.RMU_CardIsReady);

        }

        void FrmRfidCheck_Write_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (comport.IsOpen)
            {
                comport.Close();
            }
        }
        void UpdateStatus(string value)
        {
            if (this.statusLabel.InvokeRequired)
            {
                this.statusLabel.Invoke(new deleUpdateContorl(UpdateStatusLable), value);
            }
            else
            {
                UpdateStatusLable(value);
            }
        }
        void _RFIDHelper_evtCardState(RFIDEventType eventType, object o)
        {
            string value = "设备初始化失败";
            switch ((int)eventType)
            {
                case (int)RFIDEventType.RMU_CardIsReady:
                    value = "设备初始化成功";
                    //if (o!=null)
                    //{
                    //    if ((string)o == true.ToString())
                    //    {
                    //        value = "设备初始化成功";
                    //    }
                    //}
                    UpdateStatus(value);
                    break;
                case (int)RFIDEventType.RMU_Exception:
                    if (null != o)
                    {

                    }
                    bInitiallizing = false;
                    value = "设备尚未准备就绪！";
                    UpdateStatus(value);
                    break;
                case (int)RFIDEventType.RMU_Inventory:
                    if (null == o)
                    {
                        value = "正在检测周围标签...";
                    }
                    else
                    {
                        _RFIDHelper.SendCommand(RFIDHelper.RFIDCommand_RMU_StopGet
                                                , RFIDEventType.RMU_StopGet);
                        tagUII = (string)o;
                        tagEpc = RFIDHelper.GetEPCFormUII(tagUII);
                        value = "检测到标签：" + tagUII;
                        //this.CheckIfEPCUsed();
                    }

                    UpdateStatus(value);
                    break;
                case (int)RFIDEventType.RMU_InventorySingle:
                    //如果获取都周围标签的EPC，查询数据库检查是否该标签已经使用
                    if (o == null)
                    {
                        MessageBox.Show("周围没有标签可读！");
                    }
                    else
                    {
                        tagUII = (string)o;
                        tagEpc = RFIDHelper.GetEPCFormUII(tagUII);
                        this.CheckIfEPCUsed();
                    }
                    break;
                case (int)RFIDEventType.RMU_InventoryAnti:
                    if (null == o)
                    {
                        value = "正在检测周围标签...";
                    }
                    else
                    {
                        value = "读取到标签：" + (string)o;
                    }

                    UpdateStatus(value);
                    break;
                case (int)RFIDEventType.RMU_StopGet:
                    //this.CheckIfEPCUsed();
                    string readCommand =
                            RFIDHelper.RmuReadDataCommandComposer(
                                RMU_CommandType.RMU_SingleReadData
                                   , "12345678",
                                   0,
                                   2,
                                   2,
                                   null);
                    _RFIDHelper.SendCommand(readCommand, RFIDEventType.RMU_SingleReadData);
                    value = "检查标签是否可以使用...";
                    UpdateStatus(value);
                    break;
                case (int)RFIDEventType.RMU_SingleReadData:
                    if (null != o)
                    {
                        string data = (string)o;
                        int n = data.IndexOf("&");//data + & + uii
                        tagUII = data.Substring(n + 1);
                        tagEpc = RFIDHelper.GetEPCFormUII(tagUII);
                        value = "读取到标签：" + tagUII;

                        this.CheckIfEPCUsed();

                    }
                    else
                    {
                        value = "标签未经锁定，不能应用于考勤系统！";
                        MessageBox.Show(value);
                        value = "";
                    }
                    UpdateStatus(value);
                    break;
                case (int)RFIDEventType.RMU_ReadData:
                    if (null != o)
                    {
                        value = "读到数据：" + (string)o;
                    }
                    else
                    {
                        value = "标签读取失败，将卡放在读卡器范围内！";
                    }
                    if (this.statusLabel.InvokeRequired)
                    {
                        this.statusLabel.Invoke(new deleUpdateContorl(UpdateStatusLable), value);
                    }
                    else
                    {
                        this.statusLabel.Text = value;
                    }
                    break;
                case (int)RFIDEventType.RMU_SingleWriteData:
                    bInitiallizing = false;
                    if (null != o)
                    {
                        value = "标签( " + (string)o + " )初始化成功 ";
                        this.LintEPC2Person(txtId.Text, RFIDHelper.GetEPCFormUII((string)o));
                        bInitiallizing = false;
                    }
                    else
                    {
                        value = "标签写入失败，将标签放在读卡器范围内！";
                    }
                    if (this.statusLabel.InvokeRequired)
                    {
                        this.statusLabel.Invoke(new deleUpdateContorl(UpdateStatusLable), value);
                    }
                    else
                    {
                        this.statusLabel.Text = value;
                    }
                    break;
                case (int)RFIDEventType.RMU_WriteData:
                    if (null != o)
                    {
                        value = "标签写入数据成功 ";
                    }
                    else
                    {
                        value = "标签写入失败，标签未放在读卡器范围内或者UII错误！";
                    }
                    if (this.statusLabel.InvokeRequired)
                    {
                        this.statusLabel.Invoke(new deleUpdateContorl(UpdateStatusLable), value);
                    }
                    else
                    {
                        this.statusLabel.Text = value;
                    }
                    break;
                case (int)RFIDEventType.RMU_LockMem:
                    {
                        //if (null == o)
                        //{
                        //    bInitiallizing = false;
                        //    MessageBox.Show("标签锁定失败 ");
                        //}
                        //else if ((string)o == "ok")//写入密码
                        //{
                        //    Debug.WriteLine(string.Format(" 写入密码->RMU_LockMem {0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.Millisecond.ToString()));
                        //    string _initialPwd = RFIDHelper.PwdCheck(null);
                        //    List<string> commands = new List<string>();
                        //    string strPwdT = RFIDHelper.PwdCheck(txtSecret.Text);
                        //    string pwdTH4 = strPwdT.Substring(0, 4);//前四位 
                        //    string pwdTT4 = strPwdT.Substring(4, 4);//后四位 
                        //    List<string> commandSetSecret1 = RFIDHelper.RmuWriteDataCommandCompose(RMU_CommandType.RMU_SingleWriteData, _initialPwd, 0, 2, pwdTH4, null);
                        //    List<string> commandSetSecret2 = RFIDHelper.RmuWriteDataCommandCompose(RMU_CommandType.RMU_SingleWriteData, pwdTH4 + _initialPwd, 0, 3, pwdTT4, null);
                        //    commands.AddRange(commandSetSecret1);
                        //    commands.AddRange(commandSetSecret2);
                        //    _RFIDHelper.SendCommand(commands, RFIDEventType.RMU_SingleWriteData, false);
                        //}
                    }
                    break;
            }
        }

        private void LintEPC2Person(string xh, string epc)
        {
            //将EPC与学生相关联
            rfidCheck_CheckOn.UpdatePersonEPC(xh, epc);
            this.ShowPerson();
        }
        /// <summary>
        /// 查看该标签是否已经使用，如果尚未使用，则开始锁定
        /// </summary>
        private void CheckIfEPCUsed()
        {
            if (bInitiallizing)
            {
                return;
            }
            bInitiallizing = true;
            bool result = false;
            result = rfidCheck_CheckOn.CheckEPCUsed(tagEpc);
            if (result == false)
            {
                // not used
                //_RFIDHelper.RmuLockTagReserverdEpcTid(txtSecret.Text, tagUII);
                //_RFIDHelper.RmuLockTagReserverdEpcTid("00000000", tagUII);
                this.LintEPC2Person(txtId.Text, tagEpc);

            }
            else
            {
                bInitiallizing = false;
                MessageBox.Show("该标签已经被使用！");
            }
        }
        void UpdateButton2(string value)
        {
            //this.button2.Text = value;
        }
        void UpdateStatusLable(string value)
        {
            this.statusLabel.Text = value;
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
                    ConfigManager.SetSerialPort(ref comport, this.ispc);
                    comport.Open();

                }
                comport.Write(value, 0, value.Length);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void comport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int n = comport.BytesToRead;//n为返回的字节数
                byte[] buf = new byte[n];//初始化buf 长度为n
                comport.Read(buf, 0, n);//读取返回数据并赋值到数组
                //_RFIDHelper.Parse(buf,true);
                _RFIDHelper.Parse(buf);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void ShowPerson()
        {
            DataSet myDataSet = rfidCheck_CheckOn.GetPersonDataSet();
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new deleControlInvoke(ResetDataGridDataSource), (object)myDataSet);
            }
            else
            {
                ResetDataGridDataSource(myDataSet);
            }

            //myDataSet.ReadXml("Person.xml");
        }
        void ResetDataGridDataSource(object ds)
        {
            DataSet myDataSet = (DataSet)ds;
            if (myDataSet != null)
            {
                dataGridView1.DataSource = myDataSet.Tables[0];
                int iNumberofStudents = myDataSet.Tables[0].Rows.Count;
                this.groupBox2.Text = "学生列表 共有学生" + iNumberofStudents.ToString() + "名";

                this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                int headerW = this.dataGridView1.RowHeadersWidth;
                int columnsW = 0;
                DataGridViewColumnCollection columns = this.dataGridView1.Columns;
                for (int i = 0; i < columns.Count; i++)
                {
                    columnsW += columns[i].Width;
                }
                if (columnsW + headerW < this.dataGridView1.Width)
                {
                    int leftTotalWidht = this.dataGridView1.Width - columnsW - headerW;
                    int eachColumnAddedWidth = leftTotalWidht / columns.Count;
                    for (int i = 0; i < columns.Count; i++)
                    {
                        columns[i].Width += eachColumnAddedWidth;
                    }
                }


            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtTel.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtMail.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                string epc = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString().Trim();
                if (epc == null || epc.Length <= 0)
                {
                    label7.Text = string.Format(" 选中学生{0}({1}),无考勤号",
                            dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                           dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                else
                {
                    label7.Text = string.Format(" 选中学生{0}({1}),考勤号为 {2}",
                                                dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                                               dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                                              epc);
                }

            }
        }

        RFID_EPCWriter _EPCWriter = null;
        // 写卡之前首先检测环境是否设置完毕，比如设备连接状态，读卡器周围是否有卡等等
        private void button1_Click(object sender, EventArgs e)
        {
            string strID = txtId.Text;
            if (strID == null)
            {
                MessageBox.Show("请先选择要与标签关联的学生！");
            }
            //if (strID.Length < 0 || strID.Length > 6 || !Regex.IsMatch(strID, "[0-9]{6,12}"))
            //{
            //    MessageBox.Show("学号应为六位数字！");
            //    return;
            //}
            //strID = RFIDHelper.GetFormatEPC(strID);

            //_EPCWriter = new RFID_EPCWriter(_RFIDHelper);
            //_EPCWriter.InitialTag(strID, null);
            this.InitialTag(strID);
        }
        void InitialTag(string epc)
        {
            /* 
            
            _RFIDHelper.SendCommand(RFIDHelper.RFIDCommand_RMU_InventorySingle,
                                    RFIDEventType.RMU_InventorySingle);
            */
            _RFIDHelper.SendCommand(RFIDHelper.RFIDCommand_RMU_Inventory,
                        RFIDEventType.RMU_Inventory);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPersonManage_Click(object sender, EventArgs e)
        {
            FrmRfidCheck_StudentManage frm = new FrmRfidCheck_StudentManage();
            frm.ShowDialog(this);
        }
        private void EditTag_Click(object sender, EventArgs e)
        {
            if (this.comport.IsOpen)
            {
                this.comport.Close();
            }
            frmEditEPC frm = new frmEditEPC();
            frm.ShowDialog();
        }
    }


}
