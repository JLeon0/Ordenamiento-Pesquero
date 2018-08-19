using OrdenamientoPesquero.Pantallas_Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenamientoPesquero.Pantallas_Menu
{
    public partial class MenuReportes : Form
    {
        public MenuReportes(string rnpa)
        {
            InitializeComponent();
            r = rnpa;
        }
        string r;
        private void button1_Click(object sender, EventArgs e)
        {
            Vistas v = new Vistas("", "", 7);
            v.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vistas v = new Vistas(r, "", 6);
            v.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Vistas v = new Vistas(r, "", 8);
            v.ShowDialog(this);
        }
    }
}
