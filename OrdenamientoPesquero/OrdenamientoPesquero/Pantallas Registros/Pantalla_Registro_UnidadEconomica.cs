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
        }

        private void Pantalla_Registro_UnidadEconomica_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }
    }
}
