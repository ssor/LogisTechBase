using System;
using System.Collections.Generic;
using System.Text;
using RfidReader;

namespace LogisTechBase
{
    public class UhfCommandItem : IProcessItem
    {
        Dictionary<string, string> _ItemDic = new Dictionary<string, string>();
        List<string> _keyWordsList = new List<string>();
        List<string> _StringList = new List<string>();
        public UhfCommandItem()
        {
            _ItemDic.Add("询问状态", Rmu900RFIDHelper.RFIDCommand_RMU_GetStatus);
            _ItemDic.Add("读取功率设置", Rmu900RFIDHelper.RFIDCommand_RMU_GetPower);
            _ItemDic.Add("识别标签(单标签识别)", Rmu900RFIDHelper.RFIDCommand_RMU_Inventory);
            _ItemDic.Add("识别标签(防碰撞识别)", Rmu900RFIDHelper.RFIDCommand_RMU_InventoryAnti3);
            _ItemDic.Add("单步识别", Rmu900RFIDHelper.RFIDCommand_RMU_InventorySingle);
            _ItemDic.Add("读取标签数据(指定UII模式)", Rmu900RFIDHelper.RFIDCommand_RMU_ReadData);
            _ItemDic.Add("读取标签数据(不指定UII模式)", Rmu900RFIDHelper.RFIDCommand_RMU_ReadDataSingle);
            _ItemDic.Add("写入标签数据(指定UII模式)", Rmu900RFIDHelper.RFIDCommand_RMU_WriteData);
            _ItemDic.Add("写入标签数据(不指定UII模式)", Rmu900RFIDHelper.RFIDCommand_RMU_WriteDataSingle);
            _ItemDic.Add("擦除标签数据", Rmu900RFIDHelper.RFIDCommand_RMU_EraseData);
            _ItemDic.Add("锁定标签", Rmu900RFIDHelper.RFIDCommand_RMU_LockMem);
            _ItemDic.Add("销毁标签", Rmu900RFIDHelper.RFIDCommand_RMU_KillTag);
            _ItemDic.Add("读取RFID模块信息", Rmu900RFIDHelper.RFIDCommand_RMU_GetVersion);
            _ItemDic.Add("停止识别", Rmu900RFIDHelper.RFIDCommand_RMU_StopGet);


            _keyWordsList.Add("55");
            _keyWordsList.Add("aa");
            _keyWordsList.Add("AA");
            //_StringList.Add("标签UII");
            //_StringList.Add("数据");
        }
        public List<string> GetItemNames()
        {
            List<string> itemListR = new List<string>();
            Dictionary<string, string>.KeyCollection keys = _ItemDic.Keys;
            foreach (string s in keys)
            {
                itemListR.Add(s);
            }
            return itemListR;
        }
        public string GetItemText(string itemName)
        {

            return _ItemDic[itemName];
        }
        public List<string> GetKeywords()
        {
            return _keyWordsList;
        }
        public List<string> GetStrings()
        {
            return _StringList;
        }
    }
}
