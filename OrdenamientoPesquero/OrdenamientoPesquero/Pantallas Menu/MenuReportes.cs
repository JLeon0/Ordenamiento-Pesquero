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
        public MenuReportes(string rnpa, string tip)
        {
            InitializeComponent();
            r = rnpa;
            t = tip;
        }
        string r;
        string t;
        private void button1_Click(object sender, EventArgs e)
        {
            Vistas v = new Vistas("", "", 7);
            v.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vistas v = new Vistas(r, t, 6);
            v.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Vistas v = new Vistas(r, "", 8);
            v.ShowDialog(this);
        }

        private void MenuReportes_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Vistas v = new Vistas(r, "", 9);
            v.ShowDialog(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Vistas v = new Vistas(r, "", 10);
            v.ShowDialog(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Vistas v = new Vistas(r, "", 11);
            v.ShowDialog(this);
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
