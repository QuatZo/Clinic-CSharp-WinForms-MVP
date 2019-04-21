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
        public string CurrentSurname
        {
            get
            {
                return textBoxSurname.Text;
            }
        }
        public string CurrentID
        {
            get
            {
                if (Int32.TryParse(textBoxID.Text, out int temp)) { return textBoxID.Text; }
                else { return (-1).ToString(); }
            }
        }
        public bool ButtonStatus{
            get
            {
                return buttonLogin.Enabled;
            }
            set
            {
                buttonLogin.Enabled = value;
            }
        }
        #endregion

        #region Events
        public event Action PeselChanged;
        public event Action LoginButtonClicked;
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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (LoginButtonClicked != null)
                LoginButtonClicked();
        }
    }
}
