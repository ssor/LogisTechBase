using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace LogisTechBase
{
    public class SynchronousSocketClient
    {

        public static string ConnInfo;
        public static string InfoRec;
        public static  string HostName;
        public static int ServerPort;

        public static void StartClient(string hostName,int iPort)
        {
            HostName = hostName;
            ServerPort = iPort;
            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];
            //HostName = "ssor-PC";
            if (null == HostName)
            {
                return;
            }
            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // This example uses port 11000 on the local computer.
                //IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPHostEntry ipHostInfo = Dns.GetHostEntry(HostName);

                IPAddress ipAddress = null;
                for (int i = 0; i < ipHostInfo.AddressList.Length; i++)
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
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, ServerPort);

                // Create a TCP/IP  socket.
                Socket sender = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    sender.Connect(remoteEP);

                    ConnInfo = "Socket connected to " + sender.RemoteEndPoint.ToString();

                    // Encode the data string into a byte array.
                    byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");

                    // Send the data through the socket.
                    int bytesSent = sender.Send(msg);

                    // Receive the response from the remote device.
                    int bytesRec = sender.Receive(bytes);
                    InfoRec = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    //Console.WriteLine("Echoed test = {0}",
                    //    Encoding.ASCII.GetString(bytes,0,bytesRec));

                    // Release the socket.
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public static void StartClient(IPAddress ipAddress, int ServerPort,string sendData)
        {
                // Data buffer for incoming data.
                byte[] bytes = new byte[1024];
                //HostName = "ssor-PC";
                // Connect to a remote device.
                try {
                    // Establish the remote endpoint for the socket.

                    if (null == ipAddress)
                    {
                        return;
                    }
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress,ServerPort);

                    // Create a TCP/IP  socket.
                    Socket sender = new Socket(AddressFamily.InterNetwork, 
                        SocketType.Stream, ProtocolType.Tcp );

                    // Connect the socket to the remote endpoint. Catch any errors.
                    try {
                        sender.Connect(remoteEP);

                        ConnInfo ="Socket connected to "+ sender.RemoteEndPoint.ToString();

                        // Encode the data string into a byte array.
                        if(null == sendData)
                        {
                            sendData = "this is a test<EOF>";
                        }
                        else
                        {
                            sendData += "<EOF>";
                        }
                        byte[] msg = Encoding.ASCII.GetBytes(sendData);

                        // Send the data through the socket.
                        int bytesSent = sender.Send(msg);

                        // Receive the response from the remote device.
                        //int bytesRec = sender.Receive(bytes);
                        //InfoRec =Encoding.ASCII.GetString(bytes,0,bytesRec);
                        //Console.WriteLine("Echoed test = {0}",
                        //    Encoding.ASCII.GetString(bytes,0,bytesRec));

                        // Release the socket.
                        sender.Shutdown(SocketShutdown.Both);
                        sender.Close();
                        
                    } catch (ArgumentNullException ane) {
                        Console.WriteLine("ArgumentNullException : {0}",ane.ToString());
                    } catch (SocketException se) {
                        Console.WriteLine("SocketException : {0}",se.ToString());
                    } catch (Exception e) {
                        Console.WriteLine("Unexpected exception : {0}", e.ToString());
                    }

                } catch (Exception e) {
                    Console.WriteLine( e.ToString());
                }
        }

        //public static int Main(String[] args)
        //{
        //    StartClient();
        //    return 0;
        //}

            //internal void StartClient()
            //{
            //    throw new Exception("The method or operation is not implemented.");
            //}
        }
}
