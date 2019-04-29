using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic
{
    public partial class Form1 : Form, IView
    {
        string position;
        #region Properties
        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public IEditPanelView EditView
        {
            get
            {
                return editPanel1;
            }
        }
        public IMenuPanelView MenuView
        {
            get
            {
                return menuPanel1;
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
        public string WelcomeLabel
        {
            get
            {
                return labelInfo.Text;
            }
            set
            {
                labelInfo.Text = value;
            }
        }
        #endregion

        // public event [...] - to co w IView
        #region Events
        public event Action EditPanelVisibilityChanged;
        public event Action FormLoaded;
        #endregion

        public Form1(string position)
        {
            InitializeComponent();
            this.position = position;
        }

        private void editPanel1_VisibleChanged(object sender, EventArgs e)
        {
            if (EditPanelVisibilityChanged != null)
                EditPanelVisibilityChanged();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(FormLoaded != null)
                FormLoaded();
        }



        // inne metody, jesli beda potrzebne
    }
}
