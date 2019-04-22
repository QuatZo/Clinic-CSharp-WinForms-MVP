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
        bool LoginActive { get; set; }
        bool EditActive { get; set; }
        bool MenuActive { get; set; }
        #endregion
        // eventy z formy (prawdopodobnie przelaczanie aktywnego okna w zaleznosci od przycisku main)
        #region Events
        event Action EditPanelVisibilityChanged;
        event Action LoginScreenPopup;
        #endregion
    }
}
