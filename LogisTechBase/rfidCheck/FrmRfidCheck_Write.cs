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
using RfidReader;
using Config;

namespace LogisTechBase.rfidCheck
{

    public partial class FrmRfidCheck_Write : Form, IRFIDHelperSubscriber
    {
        /*
         标签初始化过程：
         * 1 获取标签
         * 2 读取密码区域数据
         * 3 检查是否已经使用
         * 4 与数据库字段相关联
         */
        bool bInitiallizing = false;
        Rmu900RFIDHelper rmu900Helper = null;
        IDataTransfer dataTransfer = null;
        SerialPort comport = null;
        ISerialPortConfigItem ispc =
          ConfigManager.GetConfigItem(SerialPortConfigItemName.超高频RFID串口设置);
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


            dataTransfer = new SerialPortDataTransfer();
            try
            {

                comport = new SerialPort(ispc.GetItemValue(enumSerialPortConfigItem.串口名称), int.Parse(ispc.GetItemValue(enumSerialPortConfigItem.波特率)), Parity.None, 8, StopBits.One);
                ((SerialPortDataTransfer)dataTransfer).Comport = comport;
                rmu900Helper = new Rmu900RFIDHelper(dataTransfer);
                rmu900Helper.Subscribe(this);
                dataTransfer.AddParser(rmu900Helper);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "异常提示");
            }
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

        }

        void FrmRfidCheck_Write_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (comport != null && comport.IsOpen)
            {
                comport.Close();
            }
        }
        void UpdateStatus(string value)
        {

        }

        private void LintEPC2Person(string xh, string epc)
        {
            //将EPC与学生相关联
            rfidCheck_CheckOn.UpdatePersonEPC(xh, epc);
            foreach (Person p in this.personList)
            {
                if (p.id_num == xh)
                {
                    bool bUpdated = false;
                    bUpdated = nsConfigDB.ConfigDB.saveConfig(Program.personTableName, xh,
                       new string[] { p.name,
                                            p.nj,
                                            p.bj,
                                            p.telephone,
                                            p.email,
                                            epc});
                    break;
                }
            }
            this.ShowPerson();
        }
        bool bEpcDisposed = false;//标识是否已经处理过标签，防止多次重复处理

        /// <summary>
        /// 查看该标签是否已经使用，如果尚未使用，则开始锁定
        /// </summary>
        private void CheckIfEPCUsed(string tagEpc)
        {
            if (bInitiallizing)
            {
                return;
            }
            bInitiallizing = true;
            bool result = false;
            foreach (Person p in this.personList)
            {
                if (p.epc == tagEpc)
                {
                    result = true;
                    break;
                }
            }
            //result = rfidCheck_CheckOn.CheckEPCUsed(tagEpc);
            if (result == false)
            {
                // not used
                //_RFIDHelper.RmuLockTagReserverdEpcTid(txtSecret.Text, tagUII);
                //_RFIDHelper.RmuLockTagReserverdEpcTid("00000000", tagUII);
                this.LintEPC2Person(txtId.Text, tagEpc);
            }
            else
            {
                MessageBox.Show("该标签已经被使用！");
            }
            bInitiallizing = false;
        }
        void UpdateButton2(string value)
        {
            //this.button2.Text = value;
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

        List<Person> personList;

        public void ShowPerson()
        {
            this.personList = rfidCheck_CheckOn.GetPersonList();


            DataTable table = null;
            if (this.dataGridView1.DataSource == null)
            {
                table = new DataTable();
                table.Columns.Add("学号", typeof(string));
                table.Columns.Add("姓名", typeof(string));
                table.Columns.Add("班级", typeof(string));
                table.Columns.Add("年级", typeof(string));
                table.Columns.Add("电话", typeof(string));
                table.Columns.Add("邮件", typeof(string));
                table.Columns.Add("卡号", typeof(string));
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
                    this.personList[j].bj,
                    this.personList[j].nj,
                    this.personList[j].telephone,
                    this.personList[j].email,
                    this.personList[j].epc
                });
            }
            dataGridView1.DataSource = table;
            this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            int headerW = this.dataGridView1.RowHeadersWidth;
            int columnsW = 0;
            DataGridViewColumnCollection columns = this.dataGridView1.Columns;
            columns[0].Width = 100;
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

        //RFID_EPCWriter _EPCWriter = null;
        // 写卡之前首先检测环境是否设置完毕，比如设备连接状态，读卡器周围是否有卡等等
        private void button1_Click(object sender, EventArgs e)
        {
            string strID = txtId.Text;
            if (strID == null)
            {
                MessageBox.Show("请先选择要与标签关联的学生！");
            }
            bEpcDisposed = false;

            //if (strID.Length < 0 || strID.Length > 6 || !Regex.IsMatch(strID, "[0-9]{6,12}"))
            //{
            //    MessageBox.Show("学号应为六位数字！");
            //    return;
            //}
            //strID = RFIDHelper.GetFormatEPC(strID);


            rmu900Helper.StartInventoryOnce();

        }
        void UpdateEpcList(object o)
        {
            if (bEpcDisposed == true)
            {
                return;
            }
            bEpcDisposed = true;//标签已经处理过
            deleControlInvoke dele = delegate(object oEpc)
            {
                //operateMessage msg = (operateMessage)oOperateMessage;
                //if (msg.status == "fail")
                //{
                //    MessageBox.Show("出现错误：" + msg.message);
                //    return;
                //}
                //string value = msg.message;
                string value = oEpc as string;
                CheckIfEPCUsed(value);
            };
            this.Invoke(dele, o);
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

        #region IRFIDHelperSubscriber 成员

        public void NewMessageArrived()
        {
            string r1 = rmu900Helper.ChekcInventoryOnce();
            if (r1 != string.Empty)
            {
                Debug.WriteLine("读取到标签 " + r1);
                AudioAlert.PlayAlert();
                this.UpdateEpcList(r1);
            }
        }

        #endregion
    }


}
