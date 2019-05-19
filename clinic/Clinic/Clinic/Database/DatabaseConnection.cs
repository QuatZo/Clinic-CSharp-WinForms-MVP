using Clinic.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class DatabaseConnection: IDisposable
    {
        #region Fields
        private readonly MySqlConnection connection;
        #endregion

        #region Main methods
        public DatabaseConnection()
        {
            // utworzenie polaczenia
            connection = new MySqlConnection
            {
                ConnectionString = string.Format($"server={DBInfo.server};database={DBInfo.database};uid={DBInfo.user};password={DBInfo.passwd}")
            };
        }

        // metoda otwierajaca polaczenie
        public bool Open()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch(MySqlException e){
                Console.WriteLine($"Cannot connect to server: {e}");
                return false;
            }
        }

        // metoda zamykajaca polaczenie
        public void Close()
        {
            try
            {
                connection.Close();
            }
            catch(MySqlException e)
            {
                Console.WriteLine($"Cannot disconnect from the server: {e}");
            }
        }

        public void Dispose()
        {
            Close();
        }
        #endregion

        #region Patient methods
        // metoda pobierajaca dane nt. pacjenta
        public List<Patient> PatientInfo(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                MySqlDataReader reader = cmd.ExecuteReader(); // czytnik 

                List<Patient> patients = new List<Patient>(); // lista pacjentow

                List<string> record = new List<string>(); // lista wynikow, ktora bedzie przerobiona na liste pacjentow

                // poki sa jakies wyniki (chociaz zawsze zakladamy, ze jest 1 wynik, bo PESEL jest unikalny)
                while (reader.Read())
                {
                    // czytanie enuma z bazy do zmiennej enum aplikacji
                    Sexs sex;
                    if(reader[4].ToString() == "Kobieta") { sex=Sexs.kobieta; }
                    else { sex = Sexs.mezczyzna; }

                    // tworzenie pacjenta
                    Patient pat = new Patient(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), double.Parse(reader[3].ToString()), sex, DateTime.Parse(reader[5].ToString()), reader[6].ToString(), reader[7].ToString());

                    // dodanie pacjenta do listy pacjentow
                    patients.Add(pat);
                }
                return patients;
            }
        }
        #endregion

        #region Doctor methods
        // metoda pobierajaca dane nt. lekarza
        public List<Doctor> DoctorInfo(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                MySqlDataReader reader = cmd.ExecuteReader(); // czytnik

                List<Doctor> doctors = new List<Doctor>(); // lista lekarzy

                List<string> record = new List<string>(); // lista wynikow, ktora bedzie przerobiona na liste lekarzy

                // poki sa jakies wyniki (chociaz zawsze zakladamy, ze jest 1 wynik, bo PESEL jest unikalny)
                while (reader.Read())
                {
                    // czytanie enuma z bazy do zmiennej enum aplikacji
                    Hours hours;
                    if (reader[6].ToString() == "poranne") { hours=Hours.poranne; }
                    else if (reader[6].ToString() == "popoludniowe") { hours = Hours.popoludniowe; }
                    else { hours = Hours.wieczorowe; }

                    // tworzenie lekarza
                    Doctor pat = new Doctor(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), Double.Parse(reader[3].ToString()), reader[4].ToString(), Int32.Parse(reader[5].ToString()), hours);

                    // dodanie lekarza do listy lekarzy
                    doctors.Add(pat);
                }
                return doctors;
            }
        }

        // metoda pobierajaca doktorow danej specjalizacji wraz z ID
        public List<string> Doctors(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                MySqlDataReader reader = cmd.ExecuteReader(); // czytnik

                List<string> records = new List<string>(); // lista wynikow, ktora bedzie przerobiona na daną wizytę

                // poki sa jakies wyniki
                while (reader.Read())
                {
                    records.Add($"{reader[0].ToString()} <-> {reader[1].ToString()} {reader[2].ToString()}");
                }

                return records;
            }
        }

        // metoda pobierajaca godziny przyjmowania danego doktora
        public string DoctorHours(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                MySqlDataReader reader = cmd.ExecuteReader(); // czytnik

                if (reader.Read()) { return reader[0].ToString(); }
                else { return ""; }
            }
        }
        #endregion

        #region Database activity methods
        // metoda aktualizujaca dane (update)
        public bool UpdateInfo(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                if (cmd.ExecuteNonQuery() > 0) { return true; }
                else { return false; }
            }
        }

        // metoda wpisujaca wartosc do bazy
        public bool InsertInfo(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                if (cmd.ExecuteNonQuery() > 0) { return true; }
                else { return false; }
            }
        }
        #endregion

        #region Other methods
        // metoda pobierajaca liste wizyt
        public List<string> Appointments(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                MySqlDataReader reader = cmd.ExecuteReader(); // czytnik

                List<string> records = new List<string>(); // lista wynikow, ktora bedzie przerobiona na liste wizyt

                while (reader.Read())
                {
                    records.Add($"{reader[0].ToString()} {DateTime.Parse(reader[1].ToString()).ToString("yyyy-MM-dd HH:mm")} {reader[2]} {reader[3]} {reader[4].ToString()}");
                }

                return records;
            }
        }

        // metoda pobierajaca informacje nt. danej wizyty
        public List<string> Appointment(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                MySqlDataReader reader = cmd.ExecuteReader(); // czytnik

                List<string> records = new List<string>(); // lista wynikow, ktora bedzie przerobiona na daną wizytę

                // poki sa jakies wyniki (chociaz zawsze zakladamy, ze jest 1 wynik, bo ID jest unikalne)
                while (reader.Read())
                {
                    for(int i = 0; i < reader.FieldCount; i++)
                    {
                        records.Add(reader[i].ToString());
                    }
                }

                return records;
            }
        }

        // metoda pobierajaca ilosc wynikow z wyszukiwarki wizyt do edycji
        public List<int> AppointmentToEdit(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                MySqlDataReader reader = cmd.ExecuteReader(); // czytnik
                List<int> vs = new List<int> { 0 };

                // poki sa jakies wyniki (chociaz zawsze zakladamy, ze jest 1 wynik, bo ID jest unikalne)
                while (reader.Read())
                {
                    vs[0]++;
                    vs.Add(int.Parse(reader[0].ToString()));
                }
                return vs;
            }
        }

        // metoda pobierajaca recepte
        public List<string> Prescription(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                MySqlDataReader reader = cmd.ExecuteReader(); // czytnik

                List<string> records = new List<string>(); // lista wynikow, ktora bedzie przerobiona na daną wizytę

                // poki sa jakies wyniki (chociaz zawsze zakladamy, ze jest 1 wynik, bo ID jest unikalne)
                while (reader.Read())
                {
                    string rdr = "";
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        
                        rdr += reader[i].ToString();

                        if(i < reader.FieldCount - 1) { rdr += " <=> "; }
                    }
                    records.Add(rdr);
                }

                return records;
            }
        }

        // metoda pobierajaca specjalizacje
        public List<string> Specializations(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                MySqlDataReader reader = cmd.ExecuteReader(); // czytnik

                List<string> records = new List<string>(); // lista wynikow, ktora bedzie przerobiona na daną wizytę

                // poki sa jakies wyniki
                while (reader.Read())
                {
                    records.Add(reader[0].ToString());
                }

                return records;
            }
        }
        #endregion
    }
}
