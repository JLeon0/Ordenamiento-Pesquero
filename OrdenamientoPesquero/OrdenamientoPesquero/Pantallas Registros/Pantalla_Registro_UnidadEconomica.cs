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
        bool escondido = false;
        
        public Pantalla_Registro_UnidadEconomica()
        {
            InitializeComponent();
            this.Height = Convert.ToInt32(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height * .96);
        }

        private void Pantalla_Registro_UnidadEconomica_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            cbRNPA.Focus();
        }

        private void pBReubicar_Click(object sender, EventArgs e)
        {
            if (!escondido)
            {
                gbOrgPes.Height -= 312;
                pBReubicar.Location = new Point(pBReubicar.Location.X, pBReubicar.Location.Y - 300);
                tabControl1.Location = new Point(tabControl1.Location.X, tabControl1.Location.Y - 300);
                escondido = true;
                pBReubicar.BackgroundImage = Properties.Resources.flechaabajo;
                toolTip1.SetToolTip(pBReubicar, "Mostrar Información");
            }
            else
            {
                gbOrgPes.Height += 312;
                pBReubicar.Location = new Point(pBReubicar.Location.X, pBReubicar.Location.Y + 300);
                tabControl1.Location = new Point(tabControl1.Location.X, tabControl1.Location.Y + 300);
                escondido = false;
                pBReubicar.BackgroundImage = Properties.Resources.flechaarriba;
                toolTip1.SetToolTip(pBReubicar, "Esconder Información");
            }
        }
    }
}
