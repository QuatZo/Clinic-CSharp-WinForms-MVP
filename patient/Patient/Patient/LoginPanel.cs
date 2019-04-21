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
    public partial class LoginPanel : UserControl, ILoginPanelView
    {
        #region Properties
        public string CurrentPesel
        {
            get
            {
                return textBoxPesel.Text;
            }
        }
        #endregion

        #region Events
        public event Action PeselChanged;
        #endregion

        public LoginPanel()
        {
            InitializeComponent();
        }

        private void textBoxPesel_TextChanged(object sender, EventArgs e)
        {
            if (PeselChanged != null)
                PeselChanged();
        }
    }
}
