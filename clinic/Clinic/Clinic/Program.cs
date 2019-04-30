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

            // Forma logowania
            FormLogin loginForm = new FormLogin();

            // Pokaz forme z logowaniem, wynik logowania dopisz do zmiennej
            DialogResult result = loginForm.ShowDialog();

            // Jesli wynik jest "OK" to odpal formę z programem
            if (result == DialogResult.OK)
            {
                Model model = new Model();
                IView view = new Form1();

                Presenter presenter = new Presenter(view, model);

                Application.Run((Form)view);
            }

        }
    }
}
