using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic
{
    public partial class MenuPanel : UserControl, IMenuPanelView
    {
        #region Properties

        #endregion

        #region Events
        public event Action LogOut;
        public event Action EditPanelClicked;
        #endregion
        public MenuPanel()
        {
            InitializeComponent();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            if (LogOut != null)
                LogOut();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (EditPanelClicked != null)
                EditPanelClicked();
        }
    }
}
