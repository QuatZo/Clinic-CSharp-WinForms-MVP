using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient
{
    public interface IMenuPanelView
    {
        #region Properties

        #endregion

        #region Events
        event Action LogOut;
        #endregion
    }
}
