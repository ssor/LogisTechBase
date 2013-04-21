using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Config;

namespace LogisTechBase
{
    public partial class frmSysSettings : Form
    {
        ISysSettingItem settingItem = null;
        public frmSysSettings()
        {
            InitializeComponent();
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("常用设置");
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("高频RFID");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("超高频RFID");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("GPS模块");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("GSM模块");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Zigbee模块");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("条码模块");

            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("串口设置", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode1,
            treeNode2,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            treeNode1.Name = "高频RFID";
            treeNode1.Text = "高频RFID";
            treeNode2.Name = "超高频RFID";
            treeNode2.Text = "超高频RFID";
            treeNode3.Name = "串口设置";
            treeNode3.Text = "串口设置";
            treeNode4.Name = "GPS模块";
            treeNode4.Text = "GPS模块";
            treeNode5.Name = "GSM模块";
            treeNode5.Text = "GSM模块";
            treeNode6.Name = "Zigbee模块";
            treeNode6.Text = "Zigbee模块";
            treeNode7.Name = "条码模块";
            treeNode7.Text = "条码模块";
            treeNode8.Name = "常用设置";
            treeNode8.Text = "常用设置";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});

            this.treeView1.ExpandAll();

            this.Shown += new EventHandler(frmSysSettings_Shown);
        }

        void frmSysSettings_Shown(object sender, EventArgs e)
        {
            ISerialPortConfigItem ispci = ConfigManager.GetConfigItem(SerialPortConfigItemName.常用串口设置);

            this.settingItem = new sysSettingSerialPortBase(this.Controls, "常用参数设置", ispci, frmSysSettings_Click);
            this.settingItem.addControls();
            return;
        }

        void frmSysSettings_Click(object sender, EventArgs e)
        {
            if (this.settingItem != null)
            {
                if (this.settingItem.isChanged() == true)
                {
                    this.btnOk.Enabled = true;
                }
                else
                {
                    this.btnOk.Enabled = false;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeViewAction action = e.Action;
            if (action == TreeViewAction.ByMouse)
            {
                //需要首先清楚之前添加的控件
                if (this.settingItem != null)
                {
                    this.settingItem.removeControls();
                }
                this.btnOk.Enabled = false;
                TreeNode node = e.Node;
                if (node.Name == "超高频RFID")
                {
                    ISerialPortConfigItem ispci = ConfigManager.GetConfigItem(SerialPortConfigItemName.超高频RFID串口设置);
                    this.settingItem = new sysSettingSerialPortBase(this.Controls, "超高频RFID串口参数设置", ispci, frmSysSettings_Click);
                    this.settingItem.addControls();
                    return;
                }
                if (node.Name == "高频RFID")
                {
                    ISerialPortConfigItem ispci = ConfigManager.GetConfigItem(SerialPortConfigItemName.高频RFID串口设置);

                    this.settingItem = new sysSettingSerialPortBase(this.Controls, "高频RFID串口参数设置", ispci, frmSysSettings_Click);
                    this.settingItem.addControls();
                    return;
                }
                if (node.Name == "GPS模块")
                {
                    ISerialPortConfigItem ispci = ConfigManager.GetConfigItem(SerialPortConfigItemName.GPS串口设置);

                    this.settingItem = new sysSettingSerialPortBase(this.Controls, "GPS模块串口参数设置", ispci, frmSysSettings_Click);
                    this.settingItem.addControls();
                    return;
                }
                if (node.Name == "GSM模块")
                {
                    ISerialPortConfigItem ispci = ConfigManager.GetConfigItem(SerialPortConfigItemName.GSM模块串口设置);

                    this.settingItem = new sysSettingSerialPortBase(this.Controls, "GSM模块串口参数设置", ispci, frmSysSettings_Click);
                    this.settingItem.addControls();
                    return;
                }
                if (node.Name == "Zigbee模块")
                {
                    ISerialPortConfigItem ispci = ConfigManager.GetConfigItem(SerialPortConfigItemName.Zigbee模块串口设置);

                    this.settingItem = new sysSettingSerialPortBase(this.Controls, "Zigbee模块串口参数设置", ispci, frmSysSettings_Click);
                    this.settingItem.addControls();
                    return;
                }
                if (node.Name == "条码模块")
                {
                    ISerialPortConfigItem ispci = ConfigManager.GetConfigItem(SerialPortConfigItemName.条码模块);

                    this.settingItem = new sysSettingSerialPortBase(this.Controls, "条码模块串口参数设置", ispci, frmSysSettings_Click);
                    this.settingItem.addControls();
                    return;
                }
                if (node.Name == "常用设置")
                {
                    ISerialPortConfigItem ispci = ConfigManager.GetConfigItem(SerialPortConfigItemName.常用串口设置);

                    this.settingItem = new sysSettingSerialPortBase(this.Controls, "常用参数设置", ispci, frmSysSettings_Click);
                    this.settingItem.addControls();
                    return;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.settingItem != null)
            {
                this.settingItem.saveChanges();
                this.btnOk.Enabled = false;
            }
        }

        private void frmSysSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
