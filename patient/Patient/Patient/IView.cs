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
        ILoginPanelView LoginView { get;}

        // eventy z formy (prawdopodobnie przelaczanie aktywnego okna w zaleznosci od przycisku main)
    }
}
