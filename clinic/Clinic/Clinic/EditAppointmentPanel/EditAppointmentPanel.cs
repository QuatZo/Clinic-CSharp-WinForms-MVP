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
    public partial class EditAppointmentPanel : UserControl, IEditAppointmentPanelView
    {
        #region Properties
        public string Content
        {
            get
            {
                return textBoxContent.Text;
            }
            set
            {
                textBoxContent.Text = value;
            }
        }
        public List<string> Prescription
        {
            get
            {
                List<string> receipts = new List<string>();

                foreach(var el in listBoxReceipt.SelectedItems)
                {
                    Console.WriteLine(el.ToString());
                    receipts.Add(el.ToString());
                }
                return receipts;
            }
            set
            {
                if(listBoxReceipt.Items.Count > 0) { listBoxReceipt.Items.Clear(); }
                foreach(var el in value)
                {
                    listBoxReceipt.Items.Add(el);
                }
            }
        }
        #endregion

        public EditAppointmentPanel()
        {
            InitializeComponent();
        }
    }
}
