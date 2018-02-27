using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Microsoft.VisualBasic;


namespace OrdenamientoPesquero
{
    public partial class Pantalla_Registro_UnidadEconomica : Form
    {
        bool escondido = false;
        Unidad_Economica ue;
        Procedimientos proc = new Procedimientos();

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
                pbActualizar.Location = new Point(pbActualizar.Location.X, pbActualizar.Location.Y - 300);
                pbRegistrar.Location = new Point(pbRegistrar.Location.X, pbRegistrar.Location.Y - 300);
                escondido = true;
                pBReubicar.BackgroundImage = Properties.Resources.flechaabajo;
                toolTip1.SetToolTip(pBReubicar, "Mostrar Información");
            }
            else
            {
                gbOrgPes.Height += 312;
                pBReubicar.Location = new Point(pBReubicar.Location.X, pBReubicar.Location.Y + 300);
                tabControl1.Location = new Point(tabControl1.Location.X, tabControl1.Location.Y + 300);
                pbActualizar.Location = new Point(pbActualizar.Location.X, pbActualizar.Location.Y + 300);
                pbRegistrar.Location = new Point(pbRegistrar.Location.X, pbRegistrar.Location.Y + 300);
                escondido = false;
                pBReubicar.BackgroundImage = Properties.Resources.flechaarriba;
                toolTip1.SetToolTip(pBReubicar, "Esconder Información");
            }
        }

        private void pbRegistrar_Click(object sender, EventArgs e)
        {
            int exito = 0;
            if (radioButton0.Checked)
            {
                ue = new Unidad_Economica(cbRNPA.Text, txtNombre.Text, "0", txtCalleNum.Text, txtRFC.Text, txtColonia.Text, txtLocalidad.Text, txtMunicipio.Text, mtbCP.Text, txtCorreo.Text, mtbTelefono.Text, txtPresidente.Text, txtTesor.Text, txtSecre.Text, mtbTelPres.Text, mtbTelTeso.Text, mtbTelSec.Text);
                exito = proc.Registrar_Unidad(ue);
            }
            else if (radioButton1.Checked)
            {
                ue = new Unidad_Economica(cbRNPA.Text, txtNombre.Text, "0", txtCalleNum.Text, txtRFC.Text, txtColonia.Text, txtLocalidad.Text, txtMunicipio.Text, mtbCP.Text, txtCorreo.Text, mtbTelefono.Text, txtPresidente.Text, txtTesor.Text, txtSecre.Text, mtbTelPres.Text, mtbTelTeso.Text, mtbTelSec.Text);
                exito = proc.Registrar_Unidad(ue);
            }
            if (exito == 1)
            {
                (new System.Threading.Thread(CloseIt)).Start();
                MessageBox.Show("HI"); /* 1 segundo = 1000 */
            }
        }

        private void pbActualizar_Click(object sender, EventArgs e)
        {

        }
        public void CloseIt()
        {
            System.Threading.Thread.Sleep(2000);
            System.Windows.Forms.SendKeys.SendWait(" ");
        }

        private void mtbCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (mtbCP.Text.Length != 5)
                {

                }
            }
        }
    }
}
