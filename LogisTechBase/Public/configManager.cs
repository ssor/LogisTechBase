using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.IO.Ports;
using LogisTechBase.rfidCheck;
using LogisTechBase.Public;
using System.Diagnostics;

namespace LogisTechBase
{
    /// <summary>
    /// 提取，更新，设置各个设置选项
    /// </summary>
    public class ConfigManager
    {
        static string SqlSelectItem =
            @"SELECT value FROM tbConfig where key = @key;";
        static string SqlInsertItem =
            @"insert into tbConfig(key,value) values(@key,@value);";
        static string SqlUpdateItem =
            @"update tbConfig set value = @value where key = @key";

        static string sqlSelectConfigItem =
            @"select PortName,BaudRate,Parity,StopBits,DataBits from tbSerialPortConfigs where name = @name;";
        static string sqlInsertConfigItem =
            @"insert into tbSerialPortConfigs(name,PortName,BaudRate,Parity,StopBits,DataBits) 
                values(@name,@portName,@baudRate,@parity,@stopBits,@dataBits)";
        static string sqlUpdateConfigItem =
            @"update tbSerialPortConfigs set PortName = @portName,BaudRate = @baudRate,Parity = @parity,
                StopBits = @stopBits,DataBits = @dataBits where name  = @name";


        public static string ConfigFilePath = "baseConfig.xml";
        public static void SetSerialPort(ref SerialPort sp)
        {
            try
            {
                sp.PortName = ConfigManager.GetItemValue("PortName");
                sp.BaudRate = int.Parse(ConfigManager.GetItemValue("BaudRate"));
                sp.DataBits = int.Parse(ConfigManager.GetItemValue("DataBits"));
                sp.StopBits = (StopBits)Enum.Parse(typeof(StopBits), ConfigManager.GetItemValue("StopBits"));
                sp.Parity = (Parity)Enum.Parse(typeof(Parity), ConfigManager.GetItemValue("Parity"));

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("配置文件出现错误！" + ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="spci"></param>
        /// <returns></returns>
        public static bool SetSerialPort(ref SerialPort sp, ISerialPortConfigItem spci)
        {
            if (null == spci)
            {
                return false;
            }
            
            try
            {
                if (null == spci.GetItemValue("PortName"))//尚未初始化设置/
                {
                    MessageBox.Show("请先设置串口参数");
                    return false;
                }
                sp.PortName = spci.GetItemValue("PortName");
                sp.BaudRate = int.Parse(spci.GetItemValue("BaudRate"));
                sp.DataBits = int.Parse(spci.GetItemValue("DataBits"));
                sp.StopBits = (StopBits)Enum.Parse(typeof(StopBits), spci.GetItemValue("StopBits"));
                sp.Parity = (Parity)Enum.Parse(typeof(Parity), spci.GetItemValue("Parity"));

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("配置文件出现错误！" + ex.Message);
                return false;
            }
            return true;
        }
        public static string GetLockMemSecret()
        {
            string strR = null;
            string secret =ConfigManager.GetItemValue("secret");
            if (null != secret)
            {
                strR = Encrypter.GetDecryptString(secret, Encrypter.PublicEncryptKey);
            }
            return strR;
        }
        public static bool SaveLockMemSecret(string secret)
        {
            if (null != secret)
            {
                string encryptSecret = Encrypter.GetEncryptString(secret, Encrypter.PublicEncryptKey);
                return SaveConfigItem("secret", encryptSecret);
            }
            return false;
        }
        public static bool SaveSerialPortConfigurnation(SerialPortConfigItem spci)
        {
            Debug.WriteLine(string.Format(
            			"SaveSerialPortConfigurnation -> {0}"
            			,spci.toString()));
            bool bR = false;
            DataSet dsAppSettings = new DataSet();
            try
            {
                if (rfidCheck_CheckOn.InitialDB())
                {
                    object returnO = null;
                    returnO = SQLiteHelper.ExecuteScalar(rfidCheck_CheckOn.dbPath
                                                           , sqlSelectConfigItem
                                                           , new object[1] { spci.ConfigName });
                    if (returnO != null)
                    {
                        // update
                        SQLiteHelper.ExecuteScalar(rfidCheck_CheckOn.dbPath
                                                    , sqlUpdateConfigItem
                                                    , new object[6]
                                                    {
                                                        spci.SpName,
                                                        spci.SpBaudRate,spci.SpParity
                                                        ,spci.SpStopBits,spci.SpDataBits,
                                                        spci.ConfigName
                                                    });
                    }
                    else
                    {
                        SQLiteHelper.ExecuteScalar(rfidCheck_CheckOn.dbPath
                            , sqlInsertConfigItem
                            , new object[6]
                                                    {
                                                        spci.ConfigName,
                                                        spci.SpName,
                                                        spci.SpBaudRate,spci.SpParity
                                                        ,spci.SpStopBits,spci.SpDataBits
                                                    }
                                                    );
                    }
                }
                bR = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("配置文件出现错误！" + ex.Message);
                bR = false;
            }
            return bR;
        }
        public static void SetSerialPortConfigurnation(ref SerialPortConfigItem spci)
        {
            if(null == spci)
            {
                return;
            }
            DataSet ds = null;
            try
            {
                if (rfidCheck_CheckOn.InitialDB())
                {
                    ds = SQLiteHelper.ExecuteDataSet(rfidCheck_CheckOn.dbPath, sqlSelectConfigItem
                                                    , new object[1]
                                                    {
                                                        spci.ConfigName,
                                                    }
                                                    );
                }
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        spci.SpName = dr["PortName"].ToString();
                        spci.SpBaudRate = dr["BaudRate"].ToString();
                        spci.SpParity = dr["Parity"].ToString();
                        spci.SpStopBits = dr["StopBits"].ToString();
                        spci.SpDataBits = dr["DataBits"].ToString();
                        Debug.WriteLine(string.Format(
                                    "SetSerialPortConfigurnation -> {0}"
                                    , spci.toString()));
                    }
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("读取配置数据时出现错误！" + ex.Message);
            }
            return;
        }
        public static void SaveSerialPortConfigurnation(string portName,string baudRate,string parity,string dataBits,string stopBits)
        {
            //DataSet dsAppSettings = new DataSet();
            try
            {
                if (portName != null)
                {
                    SaveConfigItem("PortName", portName);
                }
                if (baudRate != null)
                {
                    SaveConfigItem("BaudRate", baudRate);
                }
                if (parity != null)
                {
                    SaveConfigItem("Parity", parity);
                }
                if (dataBits != null)
                {
                    SaveConfigItem("DataBits", dataBits);
                }
                if (stopBits != null)
                {
                    SaveConfigItem("StopBits", stopBits);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("配置文件出现错误！" + ex.Message);
            }
        }
        public static bool SaveConfigItem(string itemName,string value)
        {
            bool bR = false;
            DataSet dsAppSettings = new DataSet();
            try
            {
                if (rfidCheck_CheckOn.InitialDB())
                {
                    object returnO = null;
                    returnO = SQLiteHelper.ExecuteScalar(rfidCheck_CheckOn.dbPath
                                                           , SqlSelectItem
                                                           , new object[1] { itemName });
                    if (returnO != null)
                    {
                        // update
                        SQLiteHelper.ExecuteScalar(rfidCheck_CheckOn.dbPath
                                                    , SqlUpdateItem
                                                    , new object[2]
                                                    {
                                                        value,
                                                        itemName
                                                    });
                    }
                    else
                    {
                        SQLiteHelper.ExecuteScalar(rfidCheck_CheckOn.dbPath
                            , SqlInsertItem
                            , new object[2]
                                                    {
                                                        itemName
                                                        ,value
                                                    });
                    }
                }
                bR = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("配置文件出现错误！" + ex.Message);
                bR = false;
            }
            return bR;
        }
        //public static void InitialConfigurnation()
        //{
        //    try
        //    {

        //        if (!File.Exists(ConfigFilePath))
        //        {
        //            DataSet dsNewSettings = new DataSet("ConfigSettings");
        //            DataTable table = new DataTable("ConfigSetting");
        //            DataColumn KeyColumn = new DataColumn("key");
        //            DataColumn ValueColumn = new DataColumn("value");
        //            table.Columns.Add(KeyColumn);
        //            table.Columns.Add(ValueColumn);
        //            dsNewSettings.Tables.Add(table);

        //            DataColumn[] keys = new DataColumn[1];
        //            keys[0] = KeyColumn;
        //            table.PrimaryKey = keys;

        //            DataRow myRow = table.NewRow();
        //            myRow["key"] = "Version";
        //            myRow["value"] = "1.0";
        //            table.Rows.Add(myRow);

        //            //DataRow myRow = table.NewRow();
        //            //myRow["key"] = "PortName";
        //            //myRow["value"] = "COM1";
        //            //table.Rows.Add(myRow);

        //            //myRow = table.NewRow();
        //            //myRow["key"] = "BaudRate";
        //            //myRow["value"] = "57600";
        //            //table.Rows.Add(myRow);

        //            //myRow = table.NewRow();
        //            //myRow["key"] = "Parity";
        //            //myRow["value"] = "None";
        //            //table.Rows.Add(myRow);

        //            //myRow = table.NewRow();
        //            //myRow["key"] = "DataBits";
        //            //myRow["value"] = "8";
        //            //table.Rows.Add(myRow);

        //            //myRow = table.NewRow();
        //            //myRow["key"] = "StopBits";
        //            //myRow["value"] = "1";
        //            //table.Rows.Add(myRow);

        //            dsNewSettings.WriteXml(ConfigFilePath);
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show("配置文件出现错误！" + ex.Message);
        //    }
        //}
        public static string GetItemValue(string itemName)
        {
            if (itemName == null)
            {
                return null;
            }
            string strValue = string.Empty;
            DataSet dsAppSettings = new DataSet();
            try
            {
                if (rfidCheck_CheckOn.InitialDB())
                {

                    strValue = (string)SQLiteHelper.ExecuteScalar(rfidCheck_CheckOn.dbPath, SqlSelectItem, new object[1] { itemName });
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("配置文件出现错误！" + ex.Message);
            }
            return strValue;
        }
    }
}
