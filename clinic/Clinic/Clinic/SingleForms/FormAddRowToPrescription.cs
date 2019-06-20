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
        #region Fields
        private readonly DatabaseConnection connection = DatabaseConnection.Instance;
        #endregion

        #region Properties
        private int AppointmentID { get; set; }
        private List<int> RowsID
        {
            get
            {
                List<int> rowsID = new List<int>();
                foreach(var el in listBoxRows.SelectedItems)
                {
                    rowsID.Add(int.Parse(el.ToString().Split()[0]));
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
        #endregion

        public FormAddRowToPrescription(int id)
        {
            InitializeComponent();
            AppointmentID = id;
        }

        #region Methods
        private void FormAddRowToPrescription_Load(object sender, EventArgs e)
        {
            try
            {
                Rows = GetPrescriptions();
            }
            catch (CustomExceptions.DatabaseConnectionFailedException)
            {
                MessageBox.Show("Błąd z połączeniem!");
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            FormConnectMedDose connectMedDose = new FormConnectMedDose();
            // dodajemy event zamykania powyzszej formy, wtedy tak jakby wczytujemy na nowo nasza forme (czyli uzupelniamy liste)
            connectMedDose.FormClosing += new FormClosingEventHandler(FormAddRowToPrescription_Load);
            connectMedDose.Show();
        }

        // metoda pobierająca aktualne leki wraz z dawkami na recepcie
        private List<string> GetPrescriptions()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>()
            {
                {"@appointment", AppointmentID.ToString() }
            };

            if (connection.Open())
            {
                return connection.GetPrescription($"SELECT dawki_i_leki.iddl, leki.nazwa, dawki.ile FROM dawki_i_leki JOIN leki ON leki.idl=dawki_i_leki.idl JOIN dawki ON dawki.idd=dawki_i_leki.idd WHERE iddl NOT IN (SELECT iddl FROM wiz_i_dawki_i_leki WHERE idw=@appointment) ORDER BY 2", parameters);
            }
            else
            {
                throw new CustomExceptions.DatabaseConnectionFailedException();
            }
        }

        // jak najniższa forma (łączenie leku z dawkami) zostanie wyłączona, przeładuj listę
        private void FormConnectMedDose_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Rows = GetPrescriptions();
            }
            catch (CustomExceptions.DatabaseConnectionFailedException)
            {
                MessageBox.Show("Błąd z połączeniem!");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (connection.Open())
            {
                bool status = true;
                if(RowsID.Count > 0)
                {
                    foreach(var id in RowsID)
                    {
                        Dictionary<string, string> parameters = new Dictionary<string, string>()
                        {
                            {"@appointment", AppointmentID.ToString() },
                            {"@id", id.ToString() }
                        };

                        if (!connection.InsertInfo($"INSERT INTO wiz_i_dawki_i_leki(idw, iddl) VALUES(@appointment, @id)", parameters)) { status = false; }
                    }
                }
                else { status = false; }
                    
                if (status) { MessageBox.Show("Leki zostały poprawnie dodane do recepty!", "Pozytywnie dodano!", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Błąd podpisania leku do recepty! Upewnij się, że cokolwiek zostało wybrane." +
                    "Możliwe jest, że próbujesz dodać duplikat. Uruchom te okno ponownie.", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                MessageBox.Show("Błąd z połaczeniem!");
            }
        }
        #endregion
    }
}
