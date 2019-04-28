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
    public partial class EditPanel : UserControl, IEditPanelView
    {
        #region Properties
        public string Address
        {
            get
            {
                return textBoxAddress.Text;
            }
            set
            {
                textBoxAddress.Text = value;
            }
        }
        public string Phone
        {
            get
            {
                return textBoxPhone.Text;
            }
            set
            {
                textBoxPhone.Text = value;
            }
        }
        public string Sex
        {
            get
            {
                return comboBoxSex.SelectedItem.ToString();
            }
        }
        #endregion

        #region Events
        #endregion

        public EditPanel()
        {
            InitializeComponent();
        }
    }
}
