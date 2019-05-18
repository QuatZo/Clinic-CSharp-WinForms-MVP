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
    public partial class AppointmentsPanel : UserControl, IAppointmentsPanelView
    {
        #region Properties
        public List<string> Content
        {
            set
            {
                if (listBox1.Items.Count != 0)
                    listBox1.Items.Clear();
                foreach (var d in value)
                {
                    listBox1.Items.Add(d);
                }
            }
        }

        public string ChosenAppointment
        {
            get
            {
                if (listBox1.SelectedIndex > -1)
                {
                    List<string> ChosenAppointmentInfo = new List<string>(listBox1.SelectedItem.ToString().Split());

                    return ChosenAppointmentInfo[0];
                }
                return "-1";
            }
        }
        #endregion

        #region Events
        public event Action ChosenAppointmentClick;
        #endregion

        public AppointmentsPanel()
        {
            InitializeComponent();
        }

        #region Methods
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChosenAppointmentClick != null)
                ChosenAppointmentClick();
        }
        #endregion
    }
}
