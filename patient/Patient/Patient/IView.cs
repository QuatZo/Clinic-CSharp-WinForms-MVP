using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient
{
    interface IView
    {
        // wszystkie panele, np.
        #region Properties
        ILoginPanelView LoginView { get;}
        IEditPanelView EditView { get; }
        bool LoginActive { set; }
        bool EditActive { set; }
        #endregion
        // eventy z formy (prawdopodobnie przelaczanie aktywnego okna w zaleznosci od przycisku main)
        #region Events
        event Action EditPanelVisibilityChanged;
        #endregion
    }
}
