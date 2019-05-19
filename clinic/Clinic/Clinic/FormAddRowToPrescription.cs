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
    public partial class FormAddRowToPrescription : Form
    {
        #region Properties
        private List<string> Medicines
        {
            get
            {
                List<string> medicines = new List<string>();
                foreach(var el in comboBoxMedicine.Items)
                {
                    medicines.Add(el.ToString());
                }
                return medicines;
            }
            set
            {
                if(comboBoxMedicine.Items.Count > 0) { comboBoxMedicine.Items.Clear(); }
                foreach(var el in value)
                {
                    comboBoxMedicine.Items.Add(el);
                }
            }
        }
        private List<string> Doses
        {
            get
            {
                List<string> doses = new List<string>();
                foreach (var el in comboBoxDose.Items)
                {
                    doses.Add(el.ToString());
                }
                return doses;                    
            }
            set
            {
                if (comboBoxDose.Items.Count > 0) { comboBoxDose.Items.Clear(); }
                foreach (var el in value)
                {
                    comboBoxDose.Items.Add(el);
                }
            }
        }

        private int AppointmentID;
        private int SelectedMedicine
        {
            get
            {
                return int.Parse(comboBoxMedicine.SelectedItem.ToString().Split()[0]);
            }
        }
        private int SelectedDose
        {
            get
            {
                return int.Parse(comboBoxDose.SelectedItem.ToString().Split()[0]);
            }
        }
        #endregion

        public FormAddRowToPrescription(int id)
        {
            InitializeComponent();
            AppointmentID = id;
        }

        #region Methods
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (SelectedMedicine > -1 && SelectedDose > -1)
            {
                using (var connection = new DatabaseConnection())
                {
                    if (connection.Open())
                    {
                        Console.WriteLine($"INSERT INTO dawki_i_leki(idd, idl) VALUES({SelectedDose}, {SelectedMedicine})");
                        if (connection.InsertInfo($"INSERT INTO dawki_i_leki(idd, idl) VALUES({SelectedDose}, {SelectedMedicine})")){
                            Console.WriteLine($"SELECT iddl FROM dawki_i_leki WHERE idd={SelectedDose} AND idl={SelectedMedicine}");
                            int id = int.Parse(connection.Prescription($"SELECT iddl FROM dawki_i_leki WHERE idd={SelectedDose} AND idl={SelectedMedicine}")[0].Split()[0]);
                            Console.WriteLine(id);
                            Console.WriteLine($"INSERT INTO wiz_i_dawki_i_leki(idw, iddl) VALUES({AppointmentID}, {id})");
                            if (connection.InsertInfo($"INSERT INTO wiz_i_dawki_i_leki(idw, iddl) VALUES({AppointmentID}, {id})")) { MessageBox.Show("Poprawnie dodano!"); }
                            else{ MessageBox.Show("Błąd podpisania leku do recepty! Zgłoś się do administratora!"); }
                        }
                        else { MessageBox.Show("Błąd z przypisywaniem dawki do leku! Zgłoś się do administratora!"); }
                    }
                    else
                    {
                        MessageBox.Show("Błąd z połaczeniem!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Wybierz coś!");
            }
        }

        private void FormAddRowToPrescription_Load(object sender, EventArgs e)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    List<string> medicines = new List<string>();

                    foreach (var el in connection.Prescription("SELECT idl, nazwa FROM leki ORDER BY 2"))
                    {
                        medicines.Add(el);
                    }

                    List<string> doses = new List<string>();

                    foreach (var el in connection.Prescription("SELECT idd, ile FROM dawki ORDER BY 2"))
                    {
                        doses.Add(el);
                    }

                    Medicines = medicines;
                    Doses = doses;
                }
                else
                {
                    MessageBox.Show("Błąd z połaczeniem!");
                }
            }
        }
        #endregion
    }
}
