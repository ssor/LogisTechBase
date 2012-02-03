namespace LogisTechBase
{
    partial class Form3
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.RecieveMsg = new System.Windows.Forms.TextBox();
            this.SendMsg = new System.Windows.Forms.TextBox();
            this.btn_sendmsg = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.UserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ServerPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ServerIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SysMsg = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RecieveMsg
            // 
            this.RecieveMsg.Location = new System.Drawing.Point(12, 12);
            this.RecieveMsg.Multiline = true;
            this.RecieveMsg.Name = "RecieveMsg";
            this.RecieveMsg.Size = new System.Drawing.Size(320, 126);
            this.RecieveMsg.TabIndex = 0;
            this.RecieveMsg.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // SendMsg
            // 
            this.SendMsg.Location = new System.Drawing.Point(12, 168);
            this.SendMsg.Multiline = true;
            this.SendMsg.Name = "SendMsg";
            this.SendMsg.Size = new System.Drawing.Size(320, 128);
            this.SendMsg.TabIndex = 1;
            this.SendMsg.TextChanged += new System.EventHandler(this.SendMsg_TextChanged);
            this.SendMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // btn_sendmsg
            // 
            this.btn_sendmsg.Location = new System.Drawing.Point(257, 313);
            this.btn_sendmsg.Name = "btn_sendmsg";
            this.btn_sendmsg.Size = new System.Drawing.Size(75, 23);
            this.btn_sendmsg.TabIndex = 2;
            this.btn_sendmsg.Text = "发送消息";
            this.btn_sendmsg.UseVisualStyleBackColor = true;
            this.btn_sendmsg.Click += new System.EventHandler(this.btn_sendmsg_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_disconnect);
            this.groupBox1.Controls.Add(this.btn_connect);
            this.groupBox1.Controls.Add(this.UserName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ServerPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ServerIP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(338, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 157);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登陆信息";
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(118, 118);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(75, 23);
            this.btn_disconnect.TabIndex = 10;
            this.btn_disconnect.Text = "断开服务器";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(6, 118);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 9;
            this.btn_connect.Text = "连接服务器";
            this.btn_connect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(53, 75);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(164, 21);
            this.UserName.TabIndex = 8;
            this.UserName.TextChanged += new System.EventHandler(this.UserName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "你的昵称";
            // 
            // ServerPort
            // 
            this.ServerPort.Location = new System.Drawing.Point(52, 48);
            this.ServerPort.Name = "ServerPort";
            this.ServerPort.Size = new System.Drawing.Size(164, 21);
            this.ServerPort.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "监听端口";
            // 
            // ServerIP
            // 
            this.ServerIP.Location = new System.Drawing.Point(50, 17);
            this.ServerIP.Name = "ServerIP";
            this.ServerIP.Size = new System.Drawing.Size(164, 21);
            this.ServerIP.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "登陆IP";
            // 
            // SysMsg
            // 
            this.SysMsg.Enabled = false;
            this.SysMsg.Location = new System.Drawing.Point(341, 175);
            this.SysMsg.Multiline = true;
            this.SysMsg.Name = "SysMsg";
            this.SysMsg.Size = new System.Drawing.Size(213, 161);
            this.SysMsg.TabIndex = 11;
            this.SysMsg.TextChanged += new System.EventHandler(this.SysMsg_TextChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 357);
            this.Controls.Add(this.SysMsg);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_sendmsg);
            this.Controls.Add(this.SendMsg);
            this.Controls.Add(this.RecieveMsg);
            this.Name = "Form3";
            this.Text = "客户端程序";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RecieveMsg;
        private System.Windows.Forms.TextBox SendMsg;
        private System.Windows.Forms.Button btn_sendmsg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ServerPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ServerIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SysMsg;
    }
}

