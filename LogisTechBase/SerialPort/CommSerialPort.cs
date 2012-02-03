using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace LogisTechBase
{
    //public class CommSerialPort
    //{
    //    private SerialPort comport = null;
    //    private bool bClose = true;//默认是关闭的
    //    public event SerialDataReceivedEventHandler event_DataReceived;
    //    public CommSerialPort()
    //    {
    //        this.comport = new SerialPort();
    //        this.comport.DataReceived += new SerialDataReceivedEventHandler(comport_DataReceived);

    //    }
    //    void RaiseException(Exception ex)
    //    {

    //    }
    //    void comport_DataReceived(object sender, SerialDataReceivedEventArgs e)
    //    {
    //        if (this.bClose == true)
    //        {
    //            if (this.comport.IsOpen)
    //            {
    //                this.comport.Close();
    //            }
    //            return;
    //        }
    //        if (this.event_DataReceived != null && this.bClose == false)
    //        {
    //            this.event_DataReceived(sender, e);
    //        }
    //    }
    //    public void SetProperties(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
    //    {
    //        this.comport.PortName = portName;
    //        this.comport.BaudRate = baudRate;
    //        this.comport.Parity = parity;
    //        this.comport.DataBits = dataBits;
    //        this.comport.StopBits = stopBits;
    //    }
    //    public void OpenPort(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
    //    {
    //        this.SetProperties(portName, baudRate, parity, dataBits, stopBits);
    //        this.OpenPort();
    //    }
    //    public void OpenPort()
    //    {
    //        try
    //        {
    //            this.comport.Open();
    //            bClose = false;
    //        }
    //        catch (System.Exception ex)
    //        {
    //            this.RaiseException(ex);
    //        }
    //    }
    //    public void ClosePort()
    //    {
    //        try
    //        {
    //            if (this.comport.IsOpen)
    //            {
    //                this.comport.Close();
    //                this.bClose = true;
    //            }
    //        }
    //        catch (System.Exception ex)
    //        {
    //            this.RaiseException(ex);
    //        }
    //    }
    //}
}
