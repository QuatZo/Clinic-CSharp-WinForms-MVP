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

            // Jesli wynik logowania jest "OK" to odpal formę z programem
            if (new FormLogin().ShowDialog() == DialogResult.OK)
            {
                Model model = new Model();
                IView view = new FormMain();

                Presenter presenter = new Presenter(view, model);

                Application.Run((Form)view);
            }

        }
    }
}
