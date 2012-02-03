using System;
using System.Collections.Generic;
using System.Text;

namespace LogisTechBase
{
    public class BarcodeCommandItem : IProcessItem
    {
        Dictionary<string, string> _ItemDic = new Dictionary<string, string>();
        List<string> _keyWordsList = new List<string>();

        public BarcodeCommandItem()
        {
            _ItemDic.Add("初始化条码模块", "ff 55 55 af 11 11 11 11 11");
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
    }
}
