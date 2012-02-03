using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace LogisTechBase
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private IPEndPoint ServerInfo;
        private Socket ClientSocket;
        //信息接收缓存
        private Byte[] MsgBuffer;
        //信息发送存储
        private Byte[] MsgSend;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.btn_sendmsg.Enabled = false;
            this.btn_disconnect.Enabled = false;
            //定义一个IPV4，TCP模式的Socket
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            MsgBuffer = new Byte[65535];
            MsgSend = new Byte[65535];
            //允许子线程刷新数据
            CheckForIllegalCrossThreadCalls = false;
            this.UserName.Text = Environment.MachineName;
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            //服务端IP和端口信息设定,这里的IP可以是127.0.0.1，可以是本机局域网IP，也可以是本机网络IP
            ServerInfo = new IPEndPoint(IPAddress.Parse(this.ServerIP.Text), Convert.ToInt32(this.ServerPort.Text));

            try
            {
                //客户端连接服务端指定IP端口，Sockket
                ClientSocket.Connect(ServerInfo);
                //将用户登录信息发送至服务器，由此可以让其他客户端获知
                ClientSocket.Send(Encoding.Unicode.GetBytes("用户： " + this.UserName.Text + " 进入系统！\n"));
                //开始从连接的Socket异步读取数据。接收来自服务器，其他客户端转发来的信息
                //AsyncCallback引用在异步操作完成时调用的回调方法
                ClientSocket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), null);

                this.SysMsg.Text += "登录服务器成功！\n";
                this.btn_sendmsg.Enabled = true;
                this.btn_connect.Enabled = false;
                this.btn_disconnect.Enabled = true;
            }
            catch
            {
                MessageBox.Show("登录服务器失败，请确认服务器是否正常工作！");
            }
        }
        private void ReceiveCallBack(IAsyncResult AR)
        {
            try
            {
                //结束挂起的异步读取，返回接收到的字节数。 AR，它存储此异步操作的状态信息以及所有用户定义数据
                int REnd = ClientSocket.EndReceive(AR);

                lock (this.RecieveMsg)
                {
                    this.RecieveMsg.AppendText(Encoding.Unicode.GetString(MsgBuffer, 0, REnd));
                }
                ClientSocket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length, 0, new AsyncCallback(ReceiveCallBack), null);

            }
            catch
            {
                MessageBox.Show("已经与服务器断开连接！");
                this.Close();
            }

        }

        private void btn_sendmsg_Click(object sender, EventArgs e)
        {
            MsgSend = Encoding.Unicode.GetBytes(this.UserName.Text + "说：\n" + this.SendMsg.Text + "\n");
            if (ClientSocket.Connected)
            {
                //将数据发送到连接的 System.Net.Sockets.Socket。
                ClientSocket.Send(MsgSend);
                this.SendMsg.Text = "";

            }
            else
            {
                MessageBox.Show("当前与服务器断开连接，无法发送信息！");
            }

        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            if (ClientSocket.Connected)
            {
                ClientSocket.Send(Encoding.Unicode.GetBytes(this.UserName.Text + "离开了房间！\n"));
                //禁用发送和接受
                ClientSocket.Shutdown(SocketShutdown.Both);
                //关闭套接字，不允许重用
                ClientSocket.Disconnect(false);
            }
            ClientSocket.Close();

            this.btn_sendmsg.Enabled = false;
            this.btn_connect.Enabled = true;
            this.btn_disconnect.Enabled = false;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.RecieveMsg.ScrollToCaret();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 13)
            {
                e.Handled = true;
                this.btn_sendmsg_Click(this, null);
            }

        }

        private void SendMsg_TextChanged(object sender, EventArgs e)
        {

        }

        private void SysMsg_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserName_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
