using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient
{
    public partial class Form1 : Form, IView
    {
        public Form1()
        {
            InitializeComponent();
        }

        //public IxdPanelView nazwa{
        //    get{
        //        return nazwa_panelu_z_form1
        //    }
        //    set{ (prawdopodobnie)
        //        nazwa_panelu_z_form1.visible=True;
        //        nazwa_panelu_z_form1.enabled=True;
        //    }
        //}

        public ILoginPanelView LoginView
        {
            get
            {
                return loginPanel1;
            }
        }

        // public event [...] - to co w IView

        // inne metody, jesli beda potrzebne
    }
}
