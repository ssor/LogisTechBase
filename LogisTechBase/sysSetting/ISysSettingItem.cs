using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LogisTechBase
{
    public interface ISysSettingItem
    {
        //添加和清除控件
        void addControls(Control.ControlCollection controlCollection);
        void removeControls(Control.ControlCollection controlCollection);


    }
}
