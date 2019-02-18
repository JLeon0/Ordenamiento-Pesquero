using CapaDatos;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenamientoPesquero.Pantallas_Registros
{
    public partial class Personalizar : Form
    {
        public Personalizar()
        {
            InitializeComponent();
        }
        Procedimientos proc = new Procedimientos();

        private void Personalizar_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool[] column = new bool[15];
            int i = 0;
            foreach (CheckBox a in ColumasPescador.Controls)
            {
                column[i] = a.Checked;
                i++;
            }
        }
    }
}
