using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Config;

namespace LogisTechBase
{
    public partial class SerialPortConfig : Form
    {
        ISerialPortConfigItem serialPortConfigItem = null;
        public SerialPortConfig()
        {
            InitializeComponent();
        }

        public SerialPortConfig(ISerialPortConfigItem configItem,string caption):this()
        {
            this.serialPortConfigItem = configItem;
            if (null != caption)
            {
                this.Text = caption;
            }
            else
            {
                this.Text = ((SerialPortConfigItem)configItem).ConfigName;
            }
        }

        private void SerialPortConfig_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            cmbPortName.Items.AddRange(ports);
            //cmbPortName.SelectedIndex = cmbPortName.Items.Count > 0 ? 0 : -1;
            //cmbBaudRate.SelectedIndex = cmbBaudRate.Items.IndexOf("57600");
            //cmbParity.SelectedIndex = cmbParity.Items.IndexOf("None");
            //cmbDataBits.SelectedIndex = cmbDataBits.Items.IndexOf("8");
            //cmbStopBits.SelectedIndex = cmbStopBits.Items.IndexOf("1");

            LoadConfig();

        }
        void LoadConfig()
        {
            try
            {
                string portname = serialPortConfigItem.GetItemValue(enumSerialPortConfigItem.串口名称);
                //string portname = ConfigManager.GetItemValue("PortName");
                if (null == portname)
                {
                    cmbPortName.SelectedIndex = -1;
                }
                else
                {

                    cmbPortName.SelectedIndex = cmbPortName.Items.IndexOf(portname);
                }
                string baudRate = serialPortConfigItem.GetItemValue(enumSerialPortConfigItem.波特率);
                //string baudRate = ConfigManager.GetItemValue("BaudRate");
                if (null != baudRate)
                {
                    cmbBaudRate.SelectedIndex = cmbBaudRate.Items.IndexOf(baudRate);
                }
                else
                {
                    cmbBaudRate.SelectedIndex = -1;
                }
                cmbParity.SelectedIndex = 0;
                cmbStopBits.SelectedIndex = 0;
                cmbDataBits.SelectedIndex = 1;
                //string parity = serialPortConfigItem.GetItemValue("Parity");
                ////string parity = ConfigManager.GetItemValue("Parity");
                //if (null != parity)
                //{
                //    cmbParity.SelectedIndex = cmbParity.Items.IndexOf(parity);
                //}else
                //{
                //    cmbParity.SelectedIndex = -1;
                //}
                //string stopbites = serialPortConfigItem.GetItemValue("StopBits");
                ////string stopbites = ConfigManager.GetItemValue("StopBits");
                //if (null != stopbites)
                //{
                //    cmbStopBits.SelectedIndex = cmbStopBits.Items.IndexOf(stopbites);
                //}else
                //{
                //    cmbStopBits.SelectedIndex = -1;
                //}
                //string databits = serialPortConfigItem.GetItemValue("DataBits");
                ////string databits = ConfigManager.GetItemValue("DataBits");
                //if (null != databits)
                //{
                //    cmbDataBits.SelectedIndex = cmbDataBits.Items.IndexOf(databits);
                //}else
                //{
                //    cmbDataBits.SelectedIndex = -1;
                //}
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            //ConfigManager.SaveSerialPortConfigurnation(cmbPortName.Text,
            //                                 cmbBaudRate.Text,
            //                                 cmbParity.Text,
            //                                 cmbDataBits.Text,
            //                                 cmbStopBits.Text);
            ((SerialPortConfigItem)(this.serialPortConfigItem)).SpName = cmbPortName.Text;
            ((SerialPortConfigItem)(this.serialPortConfigItem)).SpBaudRate = cmbBaudRate.Text;

            ConfigManager.SaveConfigItem(serialPortConfigItem);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
