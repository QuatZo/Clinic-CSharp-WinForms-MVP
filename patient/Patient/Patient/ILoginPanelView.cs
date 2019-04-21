using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient
{
    public interface ILoginPanelView
    {
        #region Properties
        string CurrentPesel { get;  }
        string CurrentSurname { get; }
        string CurrentID { get; }
        bool ButtonStatus { get; set; }
        #endregion

        #region Events
        event Action PeselChanged;
        event Action LoginButtonClicked;
        #endregion
    }
}
