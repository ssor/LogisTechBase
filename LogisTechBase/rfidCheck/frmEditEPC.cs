using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Config;
using RfidReader;

namespace LogisTechBase.rfidCheck
{
    public partial class frmEditEPC : Form, IRFIDHelperSubscriber
    {
        InvokeDic _UpdateList = new InvokeDic();
        //RFIDHelper _RFIDHelper = new RFIDHelper();
        ISerialPortConfigItem ispc =
              ConfigManager.GetConfigItem(SerialPortConfigItemName.超高频RFID串口设置);
        SerialPort comport = null;
        IDataTransfer dataTransfer = null;
        Rmu900RFIDHelper rmu900Helper = null;
        //bool bEPCOK = false;
        // 记录当前返回写入数据成功提示时的操作意图，区分写入EPC还是密码成功
        // 0 为epc，1 为密码
        string tagUII = string.Empty;

        public frmEditEPC()
        {
            InitializeComponent();
            this.lblSecretConfirm.Text = "";
            this.statusLabel.Text = "";
            //string secret = ConfigManager.GetLockMemSecret();
            //if (null == secret)
            //{
            //    secret = "12345678";
            //}
            //this.txtSecret.Text = secret;
            //this.txtSecretAgain.Text = secret;

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

            this.lblTip.Text = "";
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
                    ConfigManager.SetSerialPort(ref comport,this.ispc);
                    comport.Open();

                }
                comport.Write(value, 0, value.Length);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string Value = string.Empty;
            string txtContent = textBox1.Text;
            if (txtContent == null)
            {
                Value = "未输入EPC";
                lblTip.ForeColor = Color.Red;
            }else
                if (txtContent.Length >= 0 && txtContent.Length < 24)
                {
                    Value = "当前EPC长度为 " + txtContent.Length.ToString();
                    lblTip.ForeColor = Color.Red;

                }
                else
                    if (txtContent.Length == 24)
                    {
                        Value = "当前EPC长度为 " + txtContent.Length.ToString();
                        lblTip.ForeColor = Color.Red;
                        if (Regex.IsMatch(txtContent, "[0-9a-fA-F]{24}"))
                        {
                            Value = "当前EPC符合要求";
                            lblTip.ForeColor = Color.Black;
                        }
                    }
                    else
                        if (txtContent.Length > 24)
                        {
                            Value = "当前EPC长度为 " + txtContent.Length.ToString();
                            lblTip.ForeColor = Color.Red;
                        }
            this.lblTip.Text = Value;
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
        void UpdateEPCtxtBox(object o)
        {
            deleControlInvoke dele = delegate(object oEpc)
            {
                string value = oEpc as string;
                this.textBox1.Text = value;
            };
            this.Invoke(dele, o);
        }
        // read tag epc
        private void button2_Click(object sender, EventArgs e)
        {
            rmu900Helper.StartInventoryOnce();
            //_RFIDHelper.StartCallback();
            //_RFIDHelper.SendCommand(RFIDHelper.RFIDCommand_RMU_GetStatus, RFIDEventType.RMU_CardIsReady);

        }
        // write EPC to Tag
        private void button1_Click(object sender, EventArgs e)
        {
            string strID = textBox1.Text;
            if (strID.Length < 0 || strID.Length > 24 || !Regex.IsMatch(strID, "[0-9a-fA-F]{24}"))
            {
                MessageBox.Show("EPC长度应为24位，且不能包含除 a-f 和 A-F之外的字母！");
                return;
            }
            //List<string> CommandWriteData = RFIDHelper.RmuWriteDataCommandCompose(RMU_CommandType.RMU_SingleWriteData,
            //                                                        null,
            //                                                        1,
            //                                                        2,
            //                                                        strID,
            //                                                        null);
            //this.nSingleWriteDataState = 0;
            //_RFIDHelper.StartCallback();
            //_RFIDHelper.SendCommand(CommandWriteData, RFIDEventType.RMU_SingleWriteData,false);
            this.rmu900Helper.StartWriteEpc(this.textBox1.Text);

        }

        private void button6_Click(object sender, EventArgs e)
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
            this.Close();
        }

        private void txtSecretAgain_TextChanged(object sender, EventArgs e)
        {
            if (this.txtSecret.Text == this.txtSecretAgain.Text)
            {
                this.lblSecretConfirm.Text = "密码一致";
                this.lblSecretConfirm.ForeColor = Color.Black;
                btnLockTag.Enabled = true;
            }
            else
            {
                this.lblSecretConfirm.Text = "密码不一致";
                this.lblSecretConfirm.ForeColor = Color.Red;
                btnLockTag.Enabled = false;
            }
        }

        private void btnLockTag_Click(object sender, EventArgs e)
        {
            //_RFIDHelper.SendCommand(RFIDHelper.RFIDCommand_RMU_Inventory,
            //                        RFIDEventType.RMU_Inventory);
        }
        void UpdateStatusLable(string value)
        {
            this.statusLabel.Text = value;
        }

        private void btnSerialPortConfig_Click(object sender, EventArgs e)
        {
            SerialPortConfig spc = new SerialPortConfig(this.ispc,null);
            spc.ShowDialog();
        }

        private void btnSaveSecret_Click(object sender, EventArgs e)
        {
            if (this.txtSecret.Text != this.txtSecretAgain.Text)
            {
                MessageBox.Show("两次输入的密码不一致！");
                return;
            }
            string secret = "12345678";
            if (null!=this.txtSecret)
            {
                secret = this.txtSecret.Text;
                secret += "00000000";
                secret = secret.Substring(0, 8);
            }
            //ConfigManager.SaveConfigItem("secret", secret);
            if (ConfigManager.SaveLockMemSecret(secret))
           {
               MessageBox.Show("密码保存成功！");
           }
            else
            {
               MessageBox.Show("密码保存失败！");
            }
        }

        private void txtSecret_TextChanged(object sender, EventArgs e)
        {
            if (this.txtSecret.Text == this.txtSecretAgain.Text)
            {
                this.lblSecretConfirm.Text = "密码一致";
                this.lblSecretConfirm.ForeColor = Color.Black;
                this.btnLockTag.Enabled = true;
            }
            else
            {
                this.lblSecretConfirm.Text = "密码不一致";
                this.lblSecretConfirm.ForeColor = Color.Red;
                btnLockTag.Enabled = false;
            }
        }

        public  void NewMessageArrived()
        {
            string r1 = rmu900Helper.ChekcInventoryOnce();
            if (r1 != string.Empty)
            {
                Debug.WriteLine("读取到标签 " + r1);
                AudioAlert.PlayAlert();
                this.UpdateEPCtxtBox(r1);
            }
        }
    }
}
