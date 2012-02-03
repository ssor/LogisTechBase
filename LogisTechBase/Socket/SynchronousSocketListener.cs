using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class SynchronousSocketListener
{

    // Incoming data from the client.
    public static string data = null;
    public static string Info1;
    public static string Info2;
    public static string ReceivedInfo = null;
    public static Socket listener;
    public static void StartListening(int iPort)
    {
        // Data buffer for incoming data.
        byte[] bytes = new Byte[1024];

        // Establish the local endpoint for the socket.
        // Dns.GetHostName returns the name of the 
        // host running the application.
        IPHostEntry ipHostInfo = Dns.GetHostEntry (Dns.GetHostName());
        IPAddress ipAddress = null;
        for (int i = 0; i < ipHostInfo.AddressList.Length;i++ )
        {
            ipAddress = ipHostInfo.AddressList[i];
            if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
            {
                break;
            }
            else
            {
                ipAddress = null;
            }
        }
        if (null == ipAddress)
        {
            return;
        }
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, iPort);

        // Create a TCP/IP socket.
         listener = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);

        // Bind the socket to the local endpoint and 
        // listen for incoming connections.
        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(10);

            // Start listening for connections.
            //while (true)
            //{
                Info1=string .Format ( "Waiting for a connection...");
                // Program is suspended while waiting for an incoming connection.
                Socket handler = listener.Accept();
                data = null;

                // An incoming connection needs to be processed.
                while (true)
                {
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("<EOF>") > -1)
                    {
                        break;
                    }
                }

                // Show the data on the console.
                Info2 =string .Format ( "Text received : {0}", data);

                // Echo the data back to the client.
                byte[] msg = Encoding.ASCII.GetBytes(data);

                handler.Send(msg);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
                ReceivedInfo = data;
            //}

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        Console.WriteLine("\nPress ENTER to continue...");
        Console.Read();
        CloseSocket();

    }
    public static void CloseSocket()
    {
        //listener.Shutdown(SocketShutdown.Receive);
        listener.Close();
    }

    //public static int Main(String[] args)
    //{
    //    StartListening();
    //    return 0;
    //}
}
