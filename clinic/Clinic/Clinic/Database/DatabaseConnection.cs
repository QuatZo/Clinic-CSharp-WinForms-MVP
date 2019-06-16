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
    class DatabaseConnection
    {
        #region Singleton
        private static DatabaseConnection instance;

        public static DatabaseConnection Instance
        {
            get
            {
                return instance ?? (instance = new DatabaseConnection());
            }
        }

        private DatabaseConnection() {
            connection = new MySqlConnection
            {
                ConnectionString = string.Format($"server={DBInfo.server};database={DBInfo.database};uid={DBInfo.user};password={DBInfo.passwd}")
            };
        }
        #endregion

        #region Fields
        private readonly MySqlConnection connection;
        #endregion

        #region Main methods
        // metoda otwierajaca polaczenie
        public bool Open()
        {
            try
            {
                if(connection.State != ConnectionState.Open) { connection.Open(); }
                
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
        #endregion

        #region Patient methods
        // metoda pobierajaca dane nt. pacjenta
        public Patient GetPatientInfo(string name, Dictionary<string, string> parameters)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                foreach (KeyValuePair<string, string> parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                MySqlDataReader reader = cmd.ExecuteReader(); // czytnik 

                Patient patient = new Patient(-1, "", "", 0, Sexs.kobieta, DateTime.Now, "", "");

                if (reader.Read())
                {
                    // czytanie enuma z bazy do zmiennej enum aplikacji
                    Sexs sex;
                    if (reader["plec"].ToString() == "Kobieta") { sex = Sexs.kobieta; }
                    else { sex = Sexs.mezczyzna; }

                    // tworzenie pacjenta
                    patient = new Patient(
                        int.Parse(reader["idp"].ToString()), 
                        reader["imie"].ToString(), 
                        reader["nazwisko"].ToString(), 
                        double.Parse(reader["pesel"].ToString()), 
                        sex, 
                        DateTime.Parse(reader["data_urodzenia"].ToString()), 
                        reader["adres"].ToString(),
                        reader["telefon"].ToString()
                    );
                }
                return patient;
            }
        }
        #endregion

        #region Doctor methods
        // metoda pobierajaca dane nt. lekarza
        public Doctor GetDoctorInfo(string name, Dictionary<string, string> parameters)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                foreach (KeyValuePair<string, string> parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                MySqlDataReader reader = cmd.ExecuteReader(); // czytnik

                Doctor doctor = new Doctor(-1, "", "", 0, "", 0, Hours.poranne);

                if (reader.Read())
                {
                    // czytanie enuma z bazy do zmiennej enum aplikacji
                    Hours hours;
                    if (reader["godziny"].ToString() == "poranne") { hours = Hours.poranne; }
                    else if (reader["godziny"].ToString() == "popoludniowe") { hours = Hours.popoludniowe; }
                    else { hours = Hours.wieczorowe; }

                    // tworzenie lekarza
                    doctor = new Doctor(
                        int.Parse(reader["idd"].ToString()), 
                        reader["imie"].ToString(), 
                        reader["nazwisko"].ToString(), 
                        double.Parse(reader["pesel"].ToString()), 
                        reader["telefon"].ToString(), 
                        int.Parse(reader["gabinet"].ToString()), 
                        hours
                    );

                }
                return doctor;
            }
        }

        // metoda pobierajaca doktorow danej specjalizacji wraz z ID
        public List<string> GetDoctors(string name, Dictionary<string, string> parameters)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                foreach (KeyValuePair<string, string> parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                MySqlDataReader reader = cmd.ExecuteReader(); // czytnik

                List<string> records = new List<string>(); // lista wynikow

                // poki sa jakies wyniki
                while (reader.Read())
                {
                    records.Add($"{reader["idd"].ToString()} <=> {reader["imie"].ToString()} {reader["nazwisko"].ToString()}");
                }

                return records;
            }
        }

        // metoda pobierajaca godziny przyjmowania danego doktora
        public string GetDoctorHours(string name, Dictionary<string, string> parameters)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                foreach (KeyValuePair<string, string> parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                MySqlDataReader reader = cmd.ExecuteReader(); // czytnik

                if (reader.Read()) { return reader["godziny"].ToString(); }
                else { return ""; }
            }
        }
        #endregion

        #region Database activity methods
        // metoda aktualizujaca dane (update)
        public bool UpdateInfo(string name, Dictionary<string, string> parameters)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                foreach (KeyValuePair<string, string> parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                if (cmd.ExecuteNonQuery() > 0) { return true; }
                else { return false; }
            }
        }

        // metoda wpisujaca wartosc do bazy
        public bool InsertInfo(string name, Dictionary<string, string> parameters)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                foreach (KeyValuePair<string, string> parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if ( rowsAffected > 0) { return true; }
                    return false;
                }
                catch (MySqlException)
                {
                    return false;
                }
            }
        }

        // metoda usuwajaca wartosci z bazy
        public bool DeleteInfo(string name, Dictionary<string, string> parameters)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                foreach (KeyValuePair<string, string> parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
                if (cmd.ExecuteNonQuery() > 0) { return true; }
                else { return false; }
            }
        }
        #endregion

        #region Count methods
        // zwraca czy ktoś/coś z takimi danymi istnieje
        public int SelectCount(string name, Dictionary<string, string> parameters)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                foreach(KeyValuePair<string, string> parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
                

                return int.Parse(cmd.ExecuteScalar().ToString());
            }
        }
        #endregion

        #region Other methods
        // metoda pobierajaca liste wizyt
        public List<Appointment> GetAppointments(string name, Dictionary<string, string> parameters)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {

                foreach (KeyValuePair<string, string> parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

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

                    List<(int, string, string)> medicines = new List<(int, string, string)>();
                    string[] medicinesToClean = reader["medicines"].ToString().Split(',');
                    foreach(var medicineToClean in medicinesToClean)
                    {
                        string[] medicineAlmostClean = medicineToClean.Split('-');
                        if (medicineAlmostClean.Length >= 3) { medicines.Add((int.Parse(medicineAlmostClean[0]), medicineAlmostClean[1], medicineAlmostClean[2])); }
                        else { medicines.Add((-1, "", "")); }
                    }

                    //idp imie nazwisko pesel plec data_urodzenia adres telefon idd imie nazwisko pesel telefon gabinet godziny idw data opis
                    appointments.Add(
                        new Appointment(
                            int.Parse(reader["idWizyty"].ToString()),
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
        public List<string> GetAppointment(string name, Dictionary<string, string> parameters)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                foreach (KeyValuePair<string, string> parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                MySqlDataReader reader = cmd.ExecuteReader(); // czytnik

                List<string> records = new List<string>(); // lista wynikow

                // poki sa jakies wyniki
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

        // metoda pobierajaca recepte
        public List<string> GetPrescription(string name, Dictionary<string, string> parameters)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                foreach (KeyValuePair<string, string> parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                MySqlDataReader reader = cmd.ExecuteReader(); // czytnik

                List<string> records = new List<string>(); // lista wynikow

                while (reader.Read())
                {
                    string rdr = "";
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        rdr += reader[i].ToString();

                        if (i < reader.FieldCount - 1) { rdr += " <=> "; }
                    }
                    records.Add(rdr);
                }

                return records;
            }
        }

        // metoda pobierajaca specjalizacje
        public List<string> GetSpecializations(string name, Dictionary<string, string> parameters)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                foreach (KeyValuePair<string, string> parameter in parameters)
                {
                    cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }

                MySqlDataReader reader = cmd.ExecuteReader(); // czytnik

                List<string> records = new List<string>(); // lista wynikow, ktora bedzie przerobiona na daną wizytę

                // poki sa jakies wyniki
                while (reader.Read())
                {
                    records.Add(reader["nazwa"].ToString());
                }

                return records;
            }
        }
        #endregion
    }
}
