using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LogisTechBase
{
    public partial class Frm_LockPara : Form
    {
        public string lockpara;//锁定参数
        List<byte> lockbuf = new List<byte>();
        byte[] buf = new byte[12];//锁定标志位
       StringBuilder taglock = new StringBuilder();
        int[] z = new int[24];
        public Frm_LockPara()
        {
            InitializeComponent();
        }

        private void Frm_LockPara_Load(object sender, EventArgs e)
        {
            lockpara = "";
            cmb_Kill.SelectedIndex = 0;
            cmb_accesspsw.SelectedIndex = 0;
            cmb_UII.SelectedIndex = 0;
            cmb_TID.SelectedIndex = 2;
            cmb_User.SelectedIndex = 0;
        }

        private void btn_createlockpara_Click(object sender, EventArgs e)
        {
            taglock.Append("0");
            taglock.Append("0");
            taglock.Append("0");
            taglock.Append("0");
            for (int i = 1; i < 11; i++)
            {
                taglock.Append("1"); ;//掩模位设置为1，执行相应状态位
            }
            if (cmb_Kill.SelectedIndex == 0)
            {
                taglock.Append("0");
                taglock.Append("0");
            }
            if (cmb_Kill.SelectedIndex == 1)
            {
                taglock.Append("1");
                taglock.Append("0");
            }
            if (cmb_Kill.SelectedIndex == 2)
            {
                taglock.Append("1");
                taglock.Append("1");
            }
            if (cmb_accesspsw.SelectedIndex == 0)
            {
                taglock.Append("0");
                taglock.Append("0");
            }
            if (cmb_accesspsw.SelectedIndex == 1)
            {
                taglock.Append("1");
                taglock.Append("0");
            }
            if (cmb_accesspsw.SelectedIndex == 2)
            {
                taglock.Append("1");
                taglock.Append("1");
            }
            if (cmb_UII.SelectedIndex == 0)
            {
                taglock.Append("0");
                taglock.Append("0");
            }
            if (cmb_UII.SelectedIndex == 1)
            {
                taglock.Append("1");
                taglock.Append("0");
            }
            if (cmb_UII.SelectedIndex == 2)
            {
                taglock.Append("1");
                taglock.Append("1");
            }
            //   if (cmb_TID.SelectedIndex == 2)
            //   {
            taglock.Append("1"); ;//TID 必须永久锁定
            taglock.Append("1"); ;
            //   }
            if (cmb_User.SelectedIndex == 0)
            {
                taglock.Append("0");
                taglock.Append("0");

            }
            if (cmb_User.SelectedIndex == 1)
            {
                taglock.Append("1");
                taglock.Append("0");

            }
            if (cmb_User.SelectedIndex == 2)
            {
                taglock.Append("1");
                taglock.Append("1");
            }
           
            int i1 = Convert.ToInt32(taglock.ToString().Substring(0, 8),2);
            lockpara = lockpara + i1.ToString("X2");
            i1 = Convert.ToInt32(taglock.ToString().Substring(8,8),2);
            lockpara = lockpara + i1.ToString("X2");
            i1 = Convert.ToInt32(taglock.ToString().Substring(16, 8),2);
            lockpara = lockpara + i1.ToString("X2");
            this.Close();

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}
