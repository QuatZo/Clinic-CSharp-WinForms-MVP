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
        // prywatne pola klasy, zeby nikt nie odczytal
        private readonly MySqlConnection connection;
        private readonly string server;
        private readonly string database;
        private readonly string userID;
        private readonly string passwd;

        public DatabaseConnection()
        {
            // dane do bazy
            server = "localhost";
            database = "clinic";
            userID = "clinic";
            passwd = "ZZZxxxCCCvvvBBBnnnMMM";

            // utworzenie polaczenia
            connection = new MySqlConnection
            {
                ConnectionString = String.Format($"server={server};database={database};uid={userID};password={passwd}")
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
                    Patient pat = new Patient(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), Double.Parse(reader[3].ToString()), sex, DateTime.Parse(reader[5].ToString()), reader[6].ToString(), reader[7].ToString());

                    // dodanie pacjenta do listy pacjentow
                    patients.Add(pat);
                }
                return patients;
            }
        }

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

        // metoda aktualizujaca dane (update)
        public bool UpdateInfo(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                if (cmd.ExecuteNonQuery() > 0) { return true; }
                else { return false; }
            }
        }
    }
}
