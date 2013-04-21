using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LogisTechBase.rfidCheck
{
    public partial class FrmRfidCheck_StudentManage : Form
    {
        public FrmRfidCheck_StudentManage()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(FrmRfidCheck_StudentManage_FormClosed);
        }

        void FrmRfidCheck_StudentManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.bRefreshParentForm)
            {
                if (null != this.parentForm)
                {
                    this.parentForm.ShowPerson();
                }
            }
        }
        FrmRfidCheck_Write parentForm = null;
        Boolean bRefreshParentForm = false;
        public DialogResult ShowDialog(FrmRfidCheck_Write frm)
        {
            this.parentForm = frm;
            return this.ShowDialog();
        }
        List<Person> personList;

        private void ShowPerson()
        {
            this.personList = rfidCheck_CheckOn.GetPersonList();
            int iNumberofStudents = personList.Count;
            this.groupBox2.Text = "学生列表 共有学生" + iNumberofStudents.ToString() + "名";


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
            //DataSet myDataSet = rfidCheck_CheckOn.GetPersonDataSet();
            //if (null==myDataSet)
            //{
            //    return;
            //}
            //dataGridView1.DataSource = myDataSet.Tables[0];
            //DataTable dt = nsConfigDB.ConfigDB.getTable(Program.personTableName);
            //this.dataGridView1.DataSource = dt;

            //this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            //int headerW = this.dataGridView1.RowHeadersWidth;
            //int columnsW = 0;
            //DataGridViewColumnCollection columns = this.dataGridView1.Columns;
            //for (int i = 0; i < columns.Count; i++)
            //{
            //    columnsW += columns[i].Width;
            //}
            //if (columnsW + headerW < this.dataGridView1.Width)
            //{
            //    int leftTotalWidht = this.dataGridView1.Width - columnsW - headerW;
            //    int eachColumnAddedWidth = leftTotalWidht / columns.Count;
            //    for (int i = 0; i < columns.Count; i++)
            //    {
            //        columns[i].Width += eachColumnAddedWidth;
            //    }
            //}
            /* 
            
            dataGridView1.Columns[0].HeaderText = "学号";
            dataGridView1.Columns[1].HeaderText = "姓名";
            dataGridView1.Columns[2].HeaderText = "电话";
            dataGridView1.Columns[3].HeaderText = "邮箱";
            */

        }

        private void FrmRfidCheck_StudentManage_Load(object sender, EventArgs e)
        {
            ShowPerson();
            SetLabelContent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string strID = txtId.Text;
            if (strID.Length < 0 || strID.Length > 6 || !Regex.IsMatch(strID, "[0-9]{6}"))
            {
                MessageBox.Show("学号应为六位数字！");
                return;
            }
            //DataSet myDataSet = new DataSet();
            //myDataSet.ReadXml("Person.xml");
            bool writeData = true;
            if (rfidCheck_CheckOn.PersonExist(new Person(strID)))
            {
                writeData = false;
                MessageBox.Show
                    ("已存在学号为" + strID + "的学生!");
                return;
            }

            if (writeData)
            {
                //rfidCheck_CheckOn.PersonAdd(new Person(txtId.Text,
                //                                        txtName.Text,
                //                                        txtTel.Text,
                //                                        txtMail.Text,
                //                                        txtbj.Text,
                //                                        txtnj.Text,
                //                                        null));
                nsConfigDB.ConfigDB.saveConfig(Program.personTableName, txtId.Text,
                            new string[] { txtName.Text,
                                            txtnj.Text,
                                            txtbj.Text,
                                            txtTel.Text,
                                            txtMail.Text,
                                            string.Empty});


                MessageBox.Show("学号为" + txtId.Text +
                    "的学生新增完成!");

                this.bRefreshParentForm = true;
            }
            //dataGridView1.DataSource = myDataSet.Tables["student"];
            ShowPerson();
            SetLabelContent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataSet myDataSet = new DataSet();
            bool bUpdated = false;
            bUpdated = nsConfigDB.ConfigDB.saveConfig(Program.personTableName, txtId.Text,
               new string[] { txtName.Text,
                                            txtnj.Text,
                                            txtbj.Text,
                                            txtTel.Text,
                                            txtMail.Text,
                                            string.Empty});
            //bUpdated = rfidCheck_CheckOn.PersonUpdate(new Person(txtId.Text,
            //                                                     txtName.Text,
            //                                                     txtTel.Text,
            //                                                     txtMail.Text,
            //                                                     txtbj.Text,
            //                                                     txtnj.Text,
            //                                                     null));
            this.bRefreshParentForm = true;
            if (bUpdated)
            {
                ShowPerson();
                SetLabelContent();
                MessageBox.Show("学号" + txtId.Text +
                "已经修改完成!!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "确定要删除学号为【" + txtId.Text + "】的学生记录吗？";
            string caption = "删除确认";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                this.bRefreshParentForm = true;

                bool bDeleted = false;
                bDeleted = nsConfigDB.ConfigDB.deleConfig(Program.personTableName, this.txtId.Text);
                //bDeleted = rfidCheck_CheckOn.PersonDelete(new Person(txtId.Text,
                //                                                    txtName.Text,
                //                                                    txtTel.Text,
                //                                                    txtMail.Text,
                //                                                    txtbj.Text,
                //                                                    txtnj.Text,
                //                                                    null));
                if (bDeleted)
                {
                    ShowPerson();
                    MessageBox.Show("学号" + txtId.Text +"已经删除完成!!");
                    SetLabelContent();
                }
            }

        }
        void SetLabelContent()
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            if (tb != null && tb.Rows.Count > 0)
            {
                txtId.Text = tb.Rows[0][0].ToString();
                txtName.Text = tb.Rows[0][1].ToString();
                //txtTel.Text = tb.Rows[0][2].ToString();
                //txtMail.Text = tb.Rows[0][3].ToString();
                txtnj.Text = tb.Rows[0][2].ToString();
                txtbj.Text = tb.Rows[0][3].ToString();
                txtTel.Text = tb.Rows[0][4].ToString();
                txtMail.Text = tb.Rows[0][5].ToString();
                txtEPC.Text = tb.Rows[0][6].ToString();
            }
            else
            {
                txtId.Text = null;
                txtName.Text = null;
                txtTel.Text = null;
                txtMail.Text = null;
                txtnj.Text = null;
                txtbj.Text = null;
                txtEPC.Text = null;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtnj.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtbj.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtTel.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtMail.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtEPC.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
