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
    public partial class Pantalla_Regitro_permiso : Form
    {
        public Pantalla_Regitro_permiso()
        {
            InitializeComponent();
        }

        private void Pantalla_Regitro_permiso_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void diaExpPer_ValueChanged(object sender, EventArgs e)
        {
            //VigenciaPerm.Text = DiferenciaFechas(finVigenciaPer.Value, diaExpPer.Value);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dgvEmbarcacionesPerm.RowCount = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            dgvEquiposPescaPerm.RowCount = (int)numericUpDown2.Value;
        }
    }
}
