using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    interface IView
    {
        // wszystkie panele, np.
        #region Properties
        string Position { get; set; }

        IEditPanelView EditView { get; }
        IMenuPanelView MenuView { get; }
        bool EditActive { get; set; }
        bool MenuActive { get; set; }
        string WelcomeLabel { get; set; }
        #endregion
        // eventy z formy (prawdopodobnie przelaczanie aktywnego okna w zaleznosci od przycisku main)
        #region Events
        event Action EditPanelVisibilityChanged;
        event Action FormLoaded;
        #endregion
    }
}
