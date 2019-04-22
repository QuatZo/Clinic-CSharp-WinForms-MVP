using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient
{
    public partial class MenuPanel : UserControl, IMenuPanelView
    {
        #region Properties

        #endregion

        #region Events
        public event Action LogOut;
        #endregion
        public MenuPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LogOut != null)
                LogOut();
        }
    }
}
