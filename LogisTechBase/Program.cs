//#define teacher
#define student
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LogisTechBase
{
    static class Program
    {
        public static string configTableName = "serial_port_config_table";
        public static string personTableName = "person_table";
        public static string check_info_table = "check_info_table";

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            programInitial();
#if student
            Application.Run(new LogisTechBase.frmMainStudent());
            
#endif
#if teacher
            Application.Run(new LogisTechBase.frmMain());

#endif
        }
        private static void programInitial()
        {
            nsConfigDB.ConfigItem item = new nsConfigDB.ConfigItem(configTableName);
            item.AddColumn("port_name");
            item.AddColumn("baut");
            nsConfigDB.ConfigDB.addConfigItem(item);

            nsConfigDB.ConfigItem item_check_info = new nsConfigDB.ConfigItem(check_info_table);
            item_check_info.AddColumn("time");
            //item_check_info.AddColumn("state");
            nsConfigDB.ConfigDB.addConfigItem(item_check_info);

            nsConfigDB.ConfigItem item_person = new nsConfigDB.ConfigItem(personTableName);
            //item.AddColumn("xh");
            item_person.AddColumn("xm");
            item_person.AddColumn("nj");
            item_person.AddColumn("bj");
            item_person.AddColumn("tel");
            item_person.AddColumn("email");
            item_person.AddColumn("uniqueID");
            nsConfigDB.ConfigDB.addConfigItem(item_person);

//            @"CREATE TABLE person(xh varchar(20) primary key
//                    ,xm varchar(30)
//                    ,nj char(4)
//                    ,bj char(10)
//                    ,tel varchar(20)
//                    ,email varchar(100)
//                    ,uniqueID varchar(30) unique);";
            object o = nsConfigDB.ConfigDB.getConfig("restPort");
            if (o != null)
            {
                //staticClass.restServerPort = o.ToString();
            }
            o = nsConfigDB.ConfigDB.getConfig("restIP");
            if (o != null)
            {
                //staticClass.restServerIP = o.ToString();
            }


        }
    }
}
