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
        Permiso perm;
        Pescador pes;
        int exito = 0;
        Procedimientos proc = new Procedimientos();
        DataSet ds = new DataSet();
        DataTable dt = null;

        public Pantalla_Registro_UnidadEconomica()
        {
            InitializeComponent();
            this.Height = Convert.ToInt32(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height * .96);
            this.Width = Convert.ToInt32(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width);

        }  

        private void Pantalla_Registro_UnidadEconomica_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            cbRNPA.Focus();
            PintarGroupBox();
            CargarRNPA();
        }

        private void pBReubicar_Click(object sender, EventArgs e)
        {
            if (!escondido)
            {
                gbOrgPes.Height -= 312;
                pBReubicar.Location = new Point(pBReubicar.Location.X, pBReubicar.Location.Y - 300);
                tabControl1.Location = new Point(tabControl1.Location.X, tabControl1.Location.Y - 300);
                ActualizarUnidad.Location = new Point(ActualizarUnidad.Location.X, ActualizarUnidad.Location.Y - 300);
                RegistrarUnidad.Location = new Point(RegistrarUnidad.Location.X, RegistrarUnidad.Location.Y - 300);
                escondido = true;
                pBReubicar.BackgroundImage = Properties.Resources.flechaabajo;
                toolTip1.SetToolTip(pBReubicar, "Mostrar Información");
            }
            else
            {
                gbOrgPes.Height += 312;
                pBReubicar.Location = new Point(pBReubicar.Location.X, pBReubicar.Location.Y + 300);
                tabControl1.Location = new Point(tabControl1.Location.X, tabControl1.Location.Y + 300);
                ActualizarUnidad.Location = new Point(ActualizarUnidad.Location.X, ActualizarUnidad.Location.Y + 300);
                RegistrarUnidad.Location = new Point(RegistrarUnidad.Location.X, RegistrarUnidad.Location.Y + 300);
                escondido = false;
                pBReubicar.BackgroundImage = Properties.Resources.flechaarriba;
                toolTip1.SetToolTip(pBReubicar, "Esconder Información");
            }
        }

     

        #region Registros
        private void RegistrarUnidad_Click(object sender, EventArgs e)
        {
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
            CargarRNPA();
            Exito(exito);
        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            if (Pescadores.Focused)
            {
                exito = AccionesPescador(true);
            }
            else if (Permisos.Focused)
            {
                exito = AccionesPermiso(true);
            }
            else if (Directiva.Focused)
            {

            }
            else if (CertMatri.Focused)
            {

            }
            Exito(exito);
        }
        #endregion


        #region Objetos
        public int AccionesPescador(bool registrar)
        {
            string sexo = "";
            string tipo_pes = "";
            string ocupacion = "";
            string cuerpo = "";
            foreach (CheckBox item in groupBox7.Controls)
            {
                if (item.Checked)
                {
                    sexo = item.Text;
                }
            }
            foreach (CheckBox item in TipoPesc.Controls)
            {
                if (item.Checked)
                {
                    tipo_pes = item.Text;
                }
            }
            foreach (CheckBox item in OcupacionEnEmbarPesc.Controls)
            {
                if (item.Checked)
                {
                    ocupacion = item.Text;
                }
            }
            foreach (CheckBox item in CuerpoDeAguaPesc.Controls)
            {
                if (item.Checked)
                {
                    cuerpo = item.Text;
                }
            }
            string[] fecha = FechaNacPesc.Value.ToShortDateString().Split('/');
            string fechaNac = "";
            int i = 2;
            while (i >= 0)
            {
                fechaNac += fecha[i];
                if (i > 0) { fechaNac += "/"; }
                i--;
            }
            pes = new Pescador(NombrePesc.Text, ApePatPescador.Text, ApeMatPescador.Text, CURPPesc.Text, RFCPesc.Text, EscolaridadPesc.Text, TSangrePesc.Text, sexo, LugarNacPesc.Text, fechaNac, CalleYNumPesc.Text, ColoniaPesc.Text, LocalidadPesc.Text, MunicipioPesc.Text, CPPesc.Text, TelefonoPesc.Text, tipo_pes, ocupacion, cuerpo, MatriculaPesc.Text);
            if (registrar)
            {
                return proc.Registrar_Pescador(pes);
            }
            else
            {
                return proc.Actualizar_Pescador(pes);
            }
        }

        public int AccionesPermiso(bool registrar)
        {
            string[] Hoy = diaExpPer.Value.ToShortDateString().Split('/');
            string diaExp = "";
            int i = 2;
            while (i >= 0)
            {
                diaExp += Hoy[i];
                if (i > 0) { diaExp += "/"; }
                i--;
            }
            string[] Hasta = finVigenciaPer.Value.ToShortDateString().Split('/');
            string finVig = "";
            i = 2;
            while (i >= 0)
            {
                finVig += Hasta[i];
                if (i > 0) { finVig += "/"; }
                i--;
            }
            perm = new Permiso(FolioPer.Text, cbRNPA.Text, nPer.Text, PesqueriaPer.Text, LugarExpPer.Text, diaExp, finVig, ZonaPescaPerm.Text, SitiosDesemPer.Text, ObservacionesPem.Text);
            if (registrar)
            { return proc.Registrar_Permiso(perm); }
            else { return proc.Actualizar_Permiso(perm); }

        }
        #endregion


        #region Actualizaciones
        private void ActualizarUnidad_Click(object sender, EventArgs e)
        {
            if (radioButton0.Checked)
            {
                ue = new Unidad_Economica(cbRNPA.Text, txtNombre.Text, "0", txtCalleNum.Text, txtRFC.Text, txtColonia.Text, txtLocalidad.Text, txtMunicipio.Text, mtbCP.Text, txtCorreo.Text, mtbTelefono.Text, txtPresidente.Text, txtTesor.Text, txtSecre.Text, mtbTelPres.Text, mtbTelTeso.Text, mtbTelSec.Text);
                exito = proc.Actualizar_Unidad(ue);
            }
            else if (radioButton1.Checked)
            {
                ue = new Unidad_Economica(cbRNPA.Text, txtNombre.Text, "0", txtCalleNum.Text, txtRFC.Text, txtColonia.Text, txtLocalidad.Text, txtMunicipio.Text, mtbCP.Text, txtCorreo.Text, mtbTelefono.Text, txtPresidente.Text, txtTesor.Text, txtSecre.Text, mtbTelPres.Text, mtbTelTeso.Text, mtbTelSec.Text);
                exito = proc.Actualizar_Unidad(ue);
            }
            Exito(exito);
        }
        private void Actualizar_Click(object sender, EventArgs e)
        {
            if (Pescadores.Focused)
            {
                exito = AccionesPescador(false);
            }
            else if (Permisos.Focused)
            {
                exito = AccionesPermiso(false);
            }
            else if (Directiva.Focused)
            {

            }
            else if (CertMatri.Focused)
            {

            }
            Exito(exito);
        }
        #endregion


        #region Cargar Datos
        bool cargando = true;
        private void CargarRNPA()
        {
            cbRNPA.DataSource = dt;
            dt = proc.Obtener_todas_unidades("");
            cbRNPA.DataSource = dt;
            cbRNPA.DisplayMember = "RNPA";
            cbRNPA.ValueMember = "RNPA";            
            cbRNPA.Text = "";
            cargando = false;
        }

        private void LlenarCampos()
        {
            if (!cargando)
            {
                dt = proc.Obtener_todas_unidades(cbRNPA.Text);
                int tipo = 0;
                foreach (DataRow fila in dt.Rows)
                {
                    txtNombre.Text = fila["NOMBRE"].ToString();
                    txtRFC.Text = fila["RFC"].ToString();
                    txtCalleNum.Text = fila["CALLEYNUM"].ToString();
                    txtColonia.Text = fila["COLONIA"].ToString();
                    txtLocalidad.Text = fila["LOCALIDAD"].ToString();
                    txtMunicipio.Text = fila["MUNICIO"].ToString();
                    mtbCP.Text = fila["CODIGO_POSTAL"].ToString();
                    txtCorreo.Text = fila["CORREO"].ToString();
                    mtbTelefono.Text = fila["TELEFONO"].ToString();
                    txtPresidente.Text = fila["PRESIDENTE"].ToString();
                    txtSecre.Text = fila["SECRETARIO"].ToString();
                    txtTesor.Text = fila["TESORERO"].ToString();
                    mtbTelPres.Text = fila["TEL_PRES"].ToString();
                    mtbTelSec.Text = fila["TEL_SECRE"].ToString();
                    mtbTelTeso.Text = fila["TEL_TESOR"].ToString();
                    //tipo = Convert.ToInt32(fila["TIPO"]);
                }
                if (tipo == 0)
                { radioButton0.Checked = true; }
                else { radioButton1.Checked = true; }
            }
        }
        #endregion


        #region Validaciones
        private void Exito(int ok)
        {
            if (ok == 1)
            {
                (new System.Threading.Thread(CloseIt)).Start();
                MessageBox.Show("Registrado exitosamente"); /* 1 segundo = 1000 */
            }
            else
            {
                (new System.Threading.Thread(CloseIt)).Start();
                MessageBox.Show("Error durante el registro"); /* 1 segundo = 1000 */
            }
            exito = 0;
        }
        private void cbRNPA_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarCampos();
        }

        private String DiferenciaFechas(DateTime newdt, DateTime olddt)
        {
            Int32 anios;
            Int32 meses;
            Int32 dias;
            String str = "";

            anios = (newdt.Year - olddt.Year);
            meses = (newdt.Month - olddt.Month);
            dias = (newdt.Day - olddt.Day);

            if (dias < 0)
            {
                meses -= 1;
                dias += DateTime.DaysInMonth(newdt.Year, newdt.Month);
            }
            if (meses < 0)
            {
                anios -= 1;
                meses += 12;
            }
            if (anios < 0)
            {
                return "Fecha Invalida";
            }
            if (anios > 0)
                str = str + anios.ToString() + " años ";
            if (meses > 0)
                str = str + meses.ToString() + " meses ";
            if (dias > 0)
                str = str + dias.ToString() + " dias ";

            return str;
        }

        public void CloseIt()
        {
            System.Threading.Thread.Sleep(2000);
            System.Windows.Forms.SendKeys.SendWait(" ");
        }

        private void diaExpPer_ValueChanged(object sender, EventArgs e)
        {
            VigenciaPerm.Text = DiferenciaFechas(finVigenciaPer.Value, diaExpPer.Value);
        }

        private void mtbCP_TextChanged(object sender, EventArgs e)
        {
            if (mtbCP.Text.Contains(' ') || mtbCP.Text.Length != 5)
            {
                pictureBox2.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
            }
            else
            {
                pictureBox2.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
            }
        }

        private void CPPesc_TextChanged(object sender, EventArgs e)
        {
            if (CPPesc.Text.Contains(' ') || CPPesc.Text.Length != 5)
            {
                pictureBox8.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
            }
            else
            {
                pictureBox8.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
            }
        }

        private void CURPPesc_TextChanged(object sender, EventArgs e)
        {
            if (validarcurp(CURPPesc.Text))
            {
                pictureBox9.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
            }
            else
            {
                pictureBox9.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
            }
        }
        public bool validarcurp(string rfc)
        {
            if (Regex.IsMatch(rfc, @"^([A - Z][AEIOUX][A - Z]{ 2}\d{ 2} (?: 0[1 - 9] | 1[0 - 2])(?:0[1 - 9][12]\d | 3[01])[HM](?:AS | B[CS] | C[CLMSH] | D[FG] | G[TR] | HG | JC | M[CNS] | N[ETL] | OC | PL | Q[TR] | S[PLR] | T[CSL] | VZ | YN | ZS)[B - DF - HJ - NP - TV - Z]{ 3}[A-Z\d])(\d)$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool validarCorreo(string correo)
        {
            if (Regex.IsMatch(correo, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtRFC_TextChanged(object sender, EventArgs e)
        {
            if (validarrfc(txtRFC.Text))
            {
                pictureBox3.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
            }
            else
            {
                pictureBox3.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
            }

        }
        private void RFCPesc_TextChanged(object sender, EventArgs e)
        {
            if (validarrfc(RFCPesc.Text))
            {
                pictureBox7.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
            }
            else
            {
                pictureBox7.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
            }
        }
        public bool validarrfc(string rfc)
        {
            if (Regex.IsMatch(rfc, @"^([A-Z\s]{4})\d{6}([A-Z\w]{3})$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            if (validarCorreo(txtCorreo.Text))
            {
                pictureBox4.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
            }
            else
            {
                pictureBox4.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
            }
        }

        #endregion

        //Pintar los groupBox
        private void PintarGroupBox()
        {
            this.BackColor = Color.FromArgb(36, 50, 61);
            Resumen.BackColor = Color.FromArgb(118, 50, 63);

            tabControl1.Width = Convert.ToInt32(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width * .985);
            Resumen.Width = Convert.ToInt32(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width * .296);

            foreach (TextBox ctr in gbOrgPes.Controls.OfType<TextBox>())
            {
                gbOrgPes.Controls[gbOrgPes.Controls.IndexOf(ctr)].ForeColor = Color.FromArgb(160, 160, 160);
                gbOrgPes.Controls[gbOrgPes.Controls.IndexOf(ctr)].BackColor = Color.FromArgb(36, 50, 61);

            }
            foreach (MaskedTextBox ctr in gbOrgPes.Controls.OfType<MaskedTextBox>())
            {
                gbOrgPes.Controls[gbOrgPes.Controls.IndexOf(ctr)].ForeColor = Color.FromArgb(160, 160, 160);
                gbOrgPes.Controls[gbOrgPes.Controls.IndexOf(ctr)].BackColor = Color.FromArgb(36, 50, 61);

            }
        }

        private void EliminarUnidad_Click(object sender, EventArgs e)
        {
            DialogResult Si = MessageBox.Show("¿Desea eliminar esta Unidad Económica?", "ADVERTENCIA", MessageBoxButtons.YesNo);
            if (Si == DialogResult.Yes)
            {
                if (proc.Eliminar_Unidad(cbRNPA.Text) == 1)
                {
                    (new System.Threading.Thread(CloseIt)).Start();
                    MessageBox.Show("Eliminado exitosamente"); /* 1 segundo = 1000 */
                }
                else
                {
                    (new System.Threading.Thread(CloseIt)).Start();
                    MessageBox.Show("Error durante eliminacion"); /* 1 segundo = 1000 */
                }
                CargarRNPA();
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (Pescadores.Focused)
            {
                DialogResult Si = MessageBox.Show("¿Desea eliminar este Pescador?", "ADVERTENCIA", MessageBoxButtons.YesNo);
                if (Si == DialogResult.Yes)
                {
                    exito = proc.Eliminar_Pescador(CURPPesc.Text);
                }
            }
            else if (Permisos.Focused)
            {
                DialogResult Si = MessageBox.Show("¿Desea eliminar este Permiso?", "ADVERTENCIA", MessageBoxButtons.YesNo);
                if (Si == DialogResult.Yes)
                {
                    //exito = proc.Eliminar_Permiso(nPer.Text);
                }
            }
            else if (Directiva.Focused)
            {

            }
            else if (CertMatri.Focused)
            {

            }
            if (exito == 1)
            {
                (new System.Threading.Thread(CloseIt)).Start();
                MessageBox.Show("Eliminado exitosamente"); /* 1 segundo = 1000 */
            }
            else
            {
                (new System.Threading.Thread(CloseIt)).Start();
                MessageBox.Show("Error durante eliminacion"); /* 1 segundo = 1000 */
            }
        }

        private void CorreoPesc_TextChanged(object sender, EventArgs e)
        {
            if (validarCorreo(CorreoPesc.Text))
            {
                pictureBox6.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
            }
            else
            {
                pictureBox6.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
            }
        }
    }
}
