using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenamientoPesquero
{
    public partial class Pantalla_Registro_UnidadEconomica : Form
    {
        public Pantalla_Registro_UnidadEconomica()
        {
            InitializeComponent();
            this.Height = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - 21;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gbFed.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gbFed.Enabled = false;
        }

        private void btnReubicar_Click(object sender, EventArgs e)
        {

        }
    }
}
