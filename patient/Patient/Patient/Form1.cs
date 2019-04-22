using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient
{
    public partial class Form1 : Form, IView
    {
        #region Properties
        public ILoginPanelView LoginView
        {
            get
            {
                return loginPanel1;
            }
        }
        public IEditPanelView EditView
        {
            get
            {
                return editPanel1;
            }
        }

        public bool LoginActive
        {
            get
            {
                return loginPanel1.Enabled && loginPanel1.Visible;
            }
            set
            {
                loginPanel1.Enabled = value;
                loginPanel1.Visible = value;
            }
        }
        public bool EditActive
        {
            get
            {
                return editPanel1.Enabled && editPanel1.Visible;
            }
            set
            {
                editPanel1.Enabled = value;
                editPanel1.Visible = value;
            }
        }
        public bool MenuActive
        {
            get
            {
                return menuPanel1.Enabled && menuPanel1.Visible;
            }
            set
            {
                menuPanel1.Enabled = value;
                menuPanel1.Visible = value;
            }
        }
        #endregion

        // public event [...] - to co w IView
        #region Events
        public event Action EditPanelVisibilityChanged;
        public event Action LoginScreenPopup;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void editPanel1_VisibleChanged(object sender, EventArgs e)
        {
            if (EditPanelVisibilityChanged != null)
                EditPanelVisibilityChanged();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (LoginScreenPopup != null)
                LoginScreenPopup();
        }


        // inne metody, jesli beda potrzebne
    }
}
