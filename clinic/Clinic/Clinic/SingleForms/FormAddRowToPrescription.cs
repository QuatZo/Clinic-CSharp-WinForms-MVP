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
        private int AppointmentID { get; set; }

        private List<int> RowsID
        {
            get
            {
                List<int> rowsID = new List<int>();
                foreach(var el in listBoxRows.SelectedItems)
                {
                    rowsID.Add(int.Parse(el.ToString().Split()[0]));
                    Console.WriteLine(int.Parse(el.ToString().Split()[0]));
                }
                return rowsID;
            }
        }
        private List<string> Rows
        {
            set
            {
                if(listBoxRows.Items.Count > 0) { listBoxRows.Items.Clear(); }
                foreach(var el in value)
                {
                    listBoxRows.Items.Add(el);
                }
            }
        }
        
        public FormAddRowToPrescription(int id)
        {
            InitializeComponent();
            AppointmentID = id;
        }

        private List<string> GetPrescriptions()
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    return connection.GetPrescription($"SELECT dawki_i_leki.iddl, leki.nazwa, dawki.ile FROM dawki_i_leki JOIN leki ON leki.idl=dawki_i_leki.idl JOIN dawki ON dawki.idd=dawki_i_leki.idd WHERE iddl NOT IN (SELECT iddl FROM wiz_i_dawki_i_leki WHERE idw={AppointmentID}) ORDER BY 2");
                }
                else
                {
                    MessageBox.Show("Błąd z połaczeniem!");
                    List<string> vs = new List<string>();
                    return vs;

                }
            }
        }

        private void FormAddRowToPrescription_Load(object sender, EventArgs e)
        {
            Rows = GetPrescriptions();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            FormConnectMedDose connectMedDose = new FormConnectMedDose();
            // dodajemy event zamykania powyzszej formy, wtedy tak jakby wczytujemy na nowo nasza forme (czyli uzupelniamy liste)
            connectMedDose.FormClosing += new FormClosingEventHandler(FormAddRowToPrescription_Load);
            connectMedDose.Show();
        }
        private void FormConnectMedDose_FormClosing(object sender, FormClosingEventArgs e)
        {
            Rows = GetPrescriptions();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    bool status = true;
                    foreach(var id in RowsID)
                    {
                        if (!connection.InsertInfo($"INSERT INTO wiz_i_dawki_i_leki(idw, iddl) VALUES({AppointmentID}, {id})")) { status = false; }
                    }
                    if (status) { MessageBox.Show("Leki zostały poprawnie dodane do recepty!", "Pozytywnie dodano!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    else { MessageBox.Show("Błąd podpisania leku do recepty! Zgłoś się do administratora!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {
                    MessageBox.Show("Błąd z połaczeniem!");
                }
            }
            
        }
    }
}
