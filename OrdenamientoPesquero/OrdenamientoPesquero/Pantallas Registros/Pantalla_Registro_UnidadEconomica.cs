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
using System.Text.RegularExpressions;

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

            foreach (TextBox ctr in gbOrgPes.Controls.OfType<TextBox>())
            {
                gbOrgPes.Controls[gbOrgPes.Controls.IndexOf(ctr)].ForeColor = Color.FromArgb(123, 133, 142);
                gbOrgPes.Controls[gbOrgPes.Controls.IndexOf(ctr)].BackColor = Color.FromArgb(36, 50, 61);

            }
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
                e.Handled = true;
            }
        }

        private void mtbCP_TextChanged(object sender, EventArgs e)
        {
            if (mtbCP.Text.Length != 5)
            {
                pictureBox2.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
            }
            else
            {
                pictureBox2.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
            }
        }

        private void txtRFC_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.txtRFC.Text, @"^([A-Z\s]{4})\d{6}([A-Z\w]{3})$"))
            {
                pictureBox3.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
            }
            else
            {
                pictureBox3.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
            }
            
        }

        private void Pantalla_Registro_UnidadEconomica_Load_1(object sender, EventArgs e)
        {
          

            Permisos.BackColor = Color.FromArgb(26, 177, 136);
            this.BackColor = Color.FromArgb(36, 50, 61);
            Resumen.BackColor = Color.FromArgb(118, 50, 63);
            txtNombre.ForeColor = Color.FromArgb(123,133,142);
            txtNombre.BackColor = Color.FromArgb(36, 50, 61);
        }

        private void cbRNPA_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            if(Regex.IsMatch(txtCorreo.Text,    @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"))
            {
                pictureBox4.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
            }
            else
            {
                pictureBox4.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
            }
        }
    }
}
