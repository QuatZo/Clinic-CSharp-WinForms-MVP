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
        public int ID { get; set; }
        public int AppointmentID
        {
            get
            {
                    return int.Parse(label1.Text);
            }
            set
            {
                    label1.Text = value.ToString();
            }
        }
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
                    receipts.Add(el.ToString());
                }
                return receipts;
            }
            set
            {
                if(listBoxReceipt.Items.Count > 0) { listBoxReceipt.Items.Clear(); }
                try
                {
                    foreach (var el in value)
                    {
                        listBoxReceipt.Items.Add(el);
                    }
                }
                catch (NullReferenceException) { }
            }
        }
        #endregion

        #region Events
        public event Action AddRowButtonClicked;
        public event Action DeleteRowButtonClicked;
        public event Action SaveAppointmentButtonClicked;
        #endregion

        public EditAppointmentPanel()
        {
            InitializeComponent();
        }

        #region Methods
        // metoda wypełniająca pola danymi
        public void FullfilFields(Appointment appointment)
        {
            AppointmentID = appointment.Id;
            Content = appointment.Content;

            List<string> prescription = new List<string>();
            foreach(var medicine in appointment.Medicines)
            {
                prescription.Add($"{medicine.ID} <=> {medicine.Name} <=> {medicine.Dose}");
            }
            Prescription = prescription;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteRowButtonClicked?.Invoke();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddRowButtonClicked?.Invoke();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveAppointmentButtonClicked?.Invoke();
        }
        #endregion
    }
}
