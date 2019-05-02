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
                List<string> ChosenAppointmentInfo = new List<string>(listBox1.SelectedItem.ToString().Split());

                Console.WriteLine(ChosenAppointmentInfo);

                return ChosenAppointmentInfo[0];
            }
        }
        #endregion

        public AppointmentsPanel()
        {
            InitializeComponent();
        }
    }
}
