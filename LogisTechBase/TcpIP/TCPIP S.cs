using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml;

namespace LogisTechBase
{
    public partial class Form2 : Form
    {
        private int GetPort()
        {
            try
            {
                XmlDocument TDoc = new XmlDocument();
                TDoc.Load("Settings.xml");
                string TPort = TDoc.GetElementsByTagName("ServerPort")[0].InnerXml;
                return Convert.ToInt32(TPort);

            }
            catch { return 6600; }//默认是6600
        }
        private IPEndPoint ServerInfo;//存放服务器的IP和端口信息
        private Socket ServerSocket;//服务端运行的SOCKET
        private Thread ServerThread;//服务端运行的线程
        private Socket[] ClientSocket;//为客户端建立的SOCKET连接
        private int ClientNumb;//存放客户端数量
        private byte[] MsgBuffer;//存放消息数据
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //提供一个 IP 地址，指示服务器应侦听所有网络接口上的客户端活动
            IPAddress ip = IPAddress.Any;
            ServerInfo = new IPEndPoint(ip, this.GetPort());
            ServerSocket.Bind(ServerInfo);//将SOCKET接口和IP端口绑定
            ServerSocket.Listen(10);//开始监听，并且挂起数为10

            ClientSocket = new Socket[65535];//为客户端提供连接个数
            MsgBuffer = new byte[65535];//消息数据大小
            ClientNumb = 0;//数量从0开始统计

            ServerThread = new Thread(new ThreadStart(RecieveAccept));//将接受客户端连接的方法委托给线程
            ServerThread.Start();//线程开始运行

            CheckForIllegalCrossThreadCalls = false;//不捕获对错误线程的调用

            this.btn_startserver.Enabled = false;
            this.btn_stopserver.Enabled = true;
            this.StateMsg.Text = "服务正在运行..." + " 运行端口：" + this.GetPort().ToString();
            this.ClientList.Items.Add("服务于 " + DateTime.Now.ToString() + " 开始运行.");


        }

        //接受客户端连接的方法
        private void RecieveAccept()
        {
            while (true)
            {
                //Accept 以同步方式从侦听套接字的连接请求队列中提取第一个挂起的连接请求，然后创建并返回新的 Socket。
                //在阻止模式中，Accept 将一直处于阻止状态，直到传入的连接尝试排入队列。连接被接受后，原来的 Socket 继续将传入的连接请求排入队列，直到您关闭它。
                ClientSocket[ClientNumb] = ServerSocket.Accept();
                ClientSocket[ClientNumb].BeginReceive(MsgBuffer, 0, MsgBuffer.Length, SocketFlags.None,
                    new AsyncCallback(RecieveCallBack), ClientSocket[ClientNumb]);
                lock (this.ClientList)
                {
                    this.ClientList.Items.Add(ClientSocket[ClientNumb].RemoteEndPoint.ToString() + " 成功连接服务器.");
                }
                ClientNumb++;
            }
        }

        //回发数据给客户端
        private void RecieveCallBack(IAsyncResult AR)
        {
            try
            {
                Socket RSocket = (Socket)AR.AsyncState;
                int REnd = RSocket.EndReceive(AR);
                //对每一个侦听的客户端端口信息进行接收和回发
                for (int i = 0; i < ClientNumb; i++)
                {
                    if (ClientSocket[i].Connected)
                    {
                        //回发数据到客户端
                        ClientSocket[i].Send(MsgBuffer, 0, REnd, SocketFlags.None);
                    }
                    //同时接收客户端回发的数据，用于回发
                    RSocket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length, 0, new AsyncCallback(RecieveCallBack), RSocket);
                }
            }
            catch { }

        }


        private void ClientList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StateMsg_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btn_stopserver_Click_1(object sender, EventArgs e)
        {
            ServerThread.Abort();//线程终止
            ServerSocket.Close();//关闭socket

            this.btn_startserver.Enabled = true;
            this.btn_stopserver.Enabled = false;
            this.StateMsg.Text = "等待运行...";
            this.ClientList.Items.Add("服务于 " + DateTime.Now.ToString() + " 停止运行.");
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            while (true)
            {
                //Accept 以同步方式从侦听套接字的连接请求队列中提取第一个挂起的连接请求，然后创建并返回新的 Socket。
                //在阻止模式中，Accept 将一直处于阻止状态，直到传入的连接尝试排入队列。连接被接受后，原来的 Socket 继续将传入的连接请求排入队列，直到您关闭它。
                ClientSocket[ClientNumb] = ServerSocket.Accept();
                ClientSocket[ClientNumb].BeginReceive(MsgBuffer, 0, MsgBuffer.Length, SocketFlags.None,
                    new AsyncCallback(RecieveCallBack), ClientSocket[ClientNumb]);
                lock (this.ClientList)
                {
                    this.ClientList.Items.Add(ClientSocket[ClientNumb].RemoteEndPoint.ToString() + " 成功连接服务器.");
                }
                ClientNumb++;
            }
        }



    }
}

