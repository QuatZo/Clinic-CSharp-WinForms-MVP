﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public interface IMenuPanelView
    {
        #region Properties

        #endregion

        #region Events
        event Action LogOut; // zamkniecie programu
        event Action EditPanelClicked; // wejscie do panelu edycji
        #endregion
    }
}