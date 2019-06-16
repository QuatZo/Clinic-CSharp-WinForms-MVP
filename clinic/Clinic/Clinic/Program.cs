using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DialogResult loginResult = FormLogin.Instance.ShowDialog(); // logowanie

            // poki uzytkownik sie nie zaloguje (brak peselu w bazie) LUB nie wylaczy programu ORAZ jest polaczenie z baza
            while(loginResult != DialogResult.OK && loginResult != DialogResult.Cancel && loginResult != DialogResult.Abort)
            {
                FormRegister.Instance.ShowDialog();
                loginResult = FormLogin.Instance.ShowDialog();
            }

            // Jesli wynik logowania jest "OK" to odpal formę z programem
            if ( loginResult == DialogResult.OK)
            {
                Model model = new Model();
                IView view = new FormMain();

                Presenter presenter = new Presenter(view, model);

                Application.Run((Form)view);
            }

        }
    }
}
