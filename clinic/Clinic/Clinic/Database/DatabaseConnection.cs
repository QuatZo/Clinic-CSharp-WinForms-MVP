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
        public Patient GetPatientInfo(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                MySqlDataReader reader = cmd.ExecuteReader(); // czytnik 

                Patient patient = new Patient(-1, "", "", 0, Sexs.kobieta, DateTime.Now, "", "");

                // poki sa jakies wyniki (chociaz zawsze zakladamy, ze jest 1 wynik, bo PESEL jest unikalny)
                if (reader.Read())
                {
                    // czytanie enuma z bazy do zmiennej enum aplikacji
                    Sexs sex;
                    if(reader[4].ToString() == "Kobieta") { sex=Sexs.kobieta; }
                    else { sex = Sexs.mezczyzna; }

                    // tworzenie pacjenta
                    patient = new Patient(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), double.Parse(reader[3].ToString()), sex, DateTime.Parse(reader[5].ToString()), reader[6].ToString(), reader[7].ToString());
                }
                return patient;
            }
        }
        #endregion

        #region Doctor methods
        // metoda pobierajaca dane nt. lekarza
        public Doctor GetDoctorInfo(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                MySqlDataReader reader = cmd.ExecuteReader(); // czytnik

                Doctor doctor = new Doctor(-1, "", "", 0, "", 0, Hours.poranne); 

                // poki sa jakies wyniki (chociaz zawsze zakladamy, ze jest 1 wynik, bo PESEL jest unikalny)
                if (reader.Read())
                {
                    // czytanie enuma z bazy do zmiennej enum aplikacji
                    Hours hours;
                    if (reader[6].ToString() == "poranne") { hours=Hours.poranne; }
                    else if (reader[6].ToString() == "popoludniowe") { hours = Hours.popoludniowe; }
                    else { hours = Hours.wieczorowe; }

                    // tworzenie lekarza
                    doctor = new Doctor(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), double.Parse(reader[3].ToString()), reader[4].ToString(), int.Parse(reader[5].ToString()), hours);

                }
                return doctor;
            }
        }

        // metoda pobierajaca doktorow danej specjalizacji wraz z ID
        public List<string> GetDoctors(string name)
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
        public string GetDoctorHours(string name)
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

        // metoda usuwajaca wartosci z bazy
        public bool DeleteInfo(string name)
        {
            {
                using (var cmd = new MySqlCommand(name, connection))
                {
                    if (cmd.ExecuteNonQuery() > 0) { return true; }
                    else { return false; }
                }
            }
        }

        // zwraca wartość dla poleceń pobierających tylko COUNT
        public int SelectCount(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                return int.Parse(cmd.ExecuteScalar().ToString());
            }
        }
        #endregion

        #region Other methods
        // metoda pobierajaca liste wizyt
        public List<Appointment> GetAppointments(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                MySqlDataReader reader = cmd.ExecuteReader(); // czytnik

                List<Appointment> appointments = new List<Appointment>(); // lista wizyt

                while (reader.Read())
                {
                    string sex = reader["plec"].ToString();
                    Sexs sexs;
                    if ( sex == "kobieta") { sexs = Sexs.kobieta; }
                    else { sexs = Sexs.mezczyzna; }

                    string hour = reader["godziny"].ToString();
                    Hours hours;
                    if (hour == "poranne") { hours = Hours.poranne; }
                    else if(hour == "popoludniowe") { hours = Hours.popoludniowe; }
                    else { hours = Hours.wieczorowe; }


                    List<(string, string)> medicines = new List<(string, string)>();
                    medicines.Add(("", ""));

                    //idp imie nazwisko pesel plec data_urodzenia adres telefon idd imie nazwisko pesel telefon gabinet godziny idw data opis
                    appointments.Add(
                        new Appointment(
                            int.Parse(reader["idw"].ToString()),
                            new Patient(
                                int.Parse(reader["idp"].ToString()),
                                reader["pImie"].ToString(),
                                reader["pNazwisko"].ToString(),
                                double.Parse(reader["pPesel"].ToString()),
                                sexs,
                                DateTime.Parse(reader["data_urodzenia"].ToString()),
                                reader["adres"].ToString(),
                                reader["pTelefon"].ToString()
                            ),
                            new Doctor(
                                int.Parse(reader["idd"].ToString()),
                                reader["dImie"].ToString(),
                                reader["dNazwisko"].ToString(),
                                double.Parse(reader["dPesel"].ToString()),
                                reader["dTelefon"].ToString(),
                                int.Parse(reader["gabinet"].ToString()),
                                hours
                            ),
                            DateTime.Parse(reader["data"].ToString()),
                            reader["opis"].ToString(),
                            medicines
                        )
                    );
                }

                return appointments;
            }
        }

        // metoda pobierajaca informacje nt. danej wizyty
        public List<string> GetAppointment(string name)
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
        public List<int> GetAppointmentToEdit(string name)
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
        public List<string> GetPrescription(string name)
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
        public List<string> GetSpecializations(string name)
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
