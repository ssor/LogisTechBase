namespace LogisTechBase
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ClientList = new System.Windows.Forms.ListBox();
            this.StateMsg = new System.Windows.Forms.StatusStrip();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btn_stopserver = new System.Windows.Forms.Button();
            this.btn_startserver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ClientList
            // 
            this.ClientList.FormattingEnabled = true;
            this.ClientList.ItemHeight = 12;
            this.ClientList.Location = new System.Drawing.Point(12, 12);
            this.ClientList.Name = "ClientList";
            this.ClientList.Size = new System.Drawing.Size(341, 100);
            this.ClientList.TabIndex = 14;
            this.ClientList.SelectedIndexChanged += new System.EventHandler(this.ClientList_SelectedIndexChanged);
            // 
            // StateMsg
            // 
            this.StateMsg.Location = new System.Drawing.Point(0, 286);
            this.StateMsg.Name = "StateMsg";
            this.StateMsg.Size = new System.Drawing.Size(368, 22);
            this.StateMsg.TabIndex = 13;
            this.StateMsg.Text = "statusStrip1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 163);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(341, 101);
            this.textBox2.TabIndex = 12;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged_1);
            // 
            // btn_stopserver
            // 
            this.btn_stopserver.Location = new System.Drawing.Point(208, 134);
            this.btn_stopserver.Name = "btn_stopserver";
            this.btn_stopserver.Size = new System.Drawing.Size(75, 23);
            this.btn_stopserver.TabIndex = 11;
            this.btn_stopserver.Text = "停止服务";
            this.btn_stopserver.UseVisualStyleBackColor = true;
            this.btn_stopserver.Click += new System.EventHandler(this.btn_stopserver_Click_1);
            // 
            // btn_startserver
            // 
            this.btn_startserver.Location = new System.Drawing.Point(31, 134);
            this.btn_startserver.Name = "btn_startserver";
            this.btn_startserver.Size = new System.Drawing.Size(75, 23);
            this.btn_startserver.TabIndex = 10;
            this.btn_startserver.Text = "启动服务";
            this.btn_startserver.UseVisualStyleBackColor = true;
            this.btn_startserver.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 308);
            this.Controls.Add(this.ClientList);
            this.Controls.Add(this.StateMsg);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btn_stopserver);
            this.Controls.Add(this.btn_startserver);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ClientList;
        private System.Windows.Forms.StatusStrip StateMsg;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn_stopserver;
        private System.Windows.Forms.Button btn_startserver;
    }
}