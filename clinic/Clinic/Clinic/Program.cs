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


            FormLogin loginForm = new FormLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Model model = new Model();
                IView view = new Form1("pacjent");

                Presenter presenter = new Presenter(view, model);

                Application.Run((Form)view);
            }
            else if (loginForm.ShowDialog() == DialogResult.Yes)
            {
                Model model = new Model();
                IView view = new Form1("lekarz");

                Presenter presenter = new Presenter(view, model);

                Application.Run((Form)view);
            }

        }
    }
}
