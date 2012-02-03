using System;
using System.Collections.Generic;
using System.Text;

namespace LogisTechBase
{
    public class GPRSCommandItem:IProcessItem
    {
        Dictionary<string, string> _ItemDic = new Dictionary<string, string>();
        List<string> _keyWordsList = new List<string>();
        List<string> _StringList = new List<string>();
        public GPRSCommandItem()
        {
            _ItemDic.Add("测试SIM卡是否存在", "AT%TSIM");
            _ItemDic.Add("查询制造商名称", "AT+CGMI");
            _ItemDic.Add("查询设备型号", "AT+CGMM");
            _ItemDic.Add("拨打电话", "ATD[电话号码];");
            //_ItemDic.Add("通话前设置1", "AT%snfs=1");
            //_ItemDic.Add("通话前设置2", "AT%nfv=4");
            //_ItemDic.Add("通话前设置3", "AT%vlb=1");
            //_ItemDic.Add("通话前设置4", "AT%ring=1");
            _ItemDic.Add("挂断电话", "ATH");
            _ItemDic.Add("接通电话", "ATA");

            _keyWordsList.Add("AT");
            _keyWordsList.Add("ATD");

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
