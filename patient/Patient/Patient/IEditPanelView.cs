using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient
{
    public interface IEditPanelView
    {

        #region Properties
        string Address { get; set; }
        string Phone { get; set; }
        string Sex { get; }
        #endregion

        #region Events
        #endregion
    }
}
