using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace OrdenamientoPesquero
{
    public partial class Pantalla_Certificado_Mat : Form
    {
        Procedimientos proc = new Procedimientos();
        DataTable dt;
        string RNPA;
        int exito = 0, NIVEL = 0;
        Embarcacion Emb;
        Validaciones val = new Validaciones();
        public Pantalla_Certificado_Mat(string rnpa, int nivel)
        {
            InitializeComponent();
            RNPA = rnpa;
            NIVEL = nivel;
            CargarLogos();
        }
        private void CargarLogos()
        {
            Logo.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Logo.png"));
            Logo1.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Logo.png"));
        }

        private void Pantalla_Certificado_Mat_Load(object sender, EventArgs e)
        {
            val.ajustarResolucion(this);
            CertMatXUnidad();
            if(NIVEL == 0 || NIVEL == 4)
            {
                gbBotones.Visible = true;
                limpiar.Visible = true;
                ActivarPanelMATRICULA.Visible = true;
            }
            if(NIVEL == 0)
            {
                EliminarUnidad.Visible = true;
                label4.Visible = true;
            }
        }
        void CertMatXUnidad()
        {
            dt = proc.ObtenerCertMatrXUnidad(RNPA);
            DataTable embarcaciones = new DataTable();
            embarcaciones.Columns.Add("MATRICULA");
            embarcaciones.Columns.Add("NOMBREEMBARCACION");
            foreach (DataRow fila in dt.Rows)
            {
                if (fila["NOMBREEMBARCACION"].ToString() != "NO APLICA")
                {
                    embarcaciones.Rows.Add(fila["MATRICULA"].ToString(), fila["NOMBREEMBARCACION"].ToString());
                }
                //ListaMatriculas.Items.Add(fila["MATRICULA"].ToString());
            }
            ListaMatriculas.DataSource = embarcaciones;
            ListaMatriculas.DisplayMember = "NOMBREEMBARCACION";
            ListaMatriculas.ValueMember = "MATRICULA";
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            limpiarcertmat();
            dt = proc.ObtenerCertMatrXUnidad(RNPA);
            int i = dt.Rows.Count;
            foreach (DataRow filas in dt.Rows)
            {
                string mat = filas["MATRICULA"].ToString();
                if (mat == MatriculaCertMat.Text)
                {
                    NombreEmbCerMat.Text = filas["NOMBREEMBARCACION"].ToString();
                    ArqBrutoCertMat.Text = filas["ARQUEOBRUTO"].ToString();
                    ArqNetoCertMat.Text = filas["ARQUEONETO"].ToString();
                    EsloraCertMat.Text = filas["ESLORA"].ToString();
                    MangaCertMat.Text = filas["MANGA"].ToString();
                    NMotoresCertMat.Text = filas["NMOTORES"].ToString();
                    PesoMCertMat.Text = filas["TONELAJE"].ToString();
                    PotenciaMotorCertMat.Text = filas["MOTORHP"].ToString();
                    PuntalCertMat.Text = filas["PUNTAL"].ToString();
                    ServicioCertMat.Text = filas["SERVICIO"].ToString();
                    TraficoCertMat.Text = filas["TRAFICO"].ToString();
                    NChipCertMat.Text = filas["NUMCHIP"].ToString();
                    ResponsableChip.Text = filas["RESPONSABLECHIP"].ToString();
                    FechaChip.Text = filas["FECHACHIPEADO"].ToString();
                    RegNum.Text = filas["REGISTRONUM"].ToString();
                    FechaExped.Text = filas["FECHAEXP"].ToString();
                    Marca.Text = filas["MOTORMARCA"].ToString();
                }
                i--;
            }
            this.Cursor = Cursors.Default;
        }

        public int AccionesCertificado(bool Registro)
        {
            if (Registro)
            {
                Emb = new Embarcacion(NombreEmbCerMat.Text, MatriculaCertMat.Text.Replace(" ",""), RNPA.Replace(" ", ""), PotenciaMotorCertMat.Text, EsloraCertMat.Text, MangaCertMat.Text, PuntalCertMat.Text, ArqBrutoCertMat.Text, ArqNetoCertMat.Text, PesoMCertMat.Text, ServicioCertMat.Text, TraficoCertMat.Text, NMotoresCertMat.Value.ToString(), NChipCertMat.Text, FechaChip.Value.ToShortDateString(), ResponsableChip.Text, RegNum.Text, FechaExped.Value.ToShortDateString(),"", Marca.Text);
                return proc.Registrar_Embarcacion(Emb);
            }
            else
            {
                Emb = new Embarcacion(NombreEmbCerMat.Text, MatriculaCertMat.Text.Replace(" ", ""), RNPA.Replace(" ", ""), PotenciaMotorCertMat.Text, EsloraCertMat.Text, MangaCertMat.Text, PuntalCertMat.Text, ArqBrutoCertMat.Text, ArqNetoCertMat.Text, PesoMCertMat.Text, ServicioCertMat.Text, TraficoCertMat.Text, NMotoresCertMat.Value.ToString(), NChipCertMat.Text, FechaChip.Value.ToShortDateString(), ResponsableChip.Text, RegNum.Text, FechaExped.Value.ToShortDateString(), "", Marca.Text);
                return proc.Actualizar_Embarcacion(Emb);
            }
        }
        public void limpiarcertmat()
        {
            foreach (TextBox item in gbCertificado.Controls.OfType<TextBox>())
            { 
                item.Text = "";
            }
            foreach (ComboBox item in gbVerificacion.Controls.OfType<ComboBox>())
            {
                item.Text = "";
            }
            foreach (MaskedTextBox item in gbVerificacion.Controls.OfType<MaskedTextBox>())
            {
                item.Text = "";
            }
            ServicioCertMat.Text = "PESCA";
            TraficoCertMat.Text = "INTERIOR";
            NMotoresCertMat.Value = 1;
            ArqBrutoCertMat.Text = "1.200";
            ArqNetoCertMat.Text = "0.840";
            PesoMCertMat.Text = "0.000";
        }

        private void CargarExpediente()
        {
            DataTable exp = proc.ObtenerExpedienteEmbarcacion(MatriculaCertMat.Text);
            if (exp.Rows.Count > 0)
            {
                if (exp.Rows[0]["CERTMATRICULA"].ToString() != "") { CertMatr.ForeColor = Color.Green; } else { CertMatr.ForeColor = Color.Red; }
                if (exp.Rows[0]["CERTSEGURIDAD"].ToString() != "") { CertSeg.ForeColor = Color.Green; } else { CertSeg.ForeColor = Color.Red; }
                if (exp.Rows[0]["FACTARTESPESCA"].ToString() != "") { FactArtes.ForeColor = Color.Green; } else { FactArtes.ForeColor = Color.Red; }
                if (exp.Rows[0]["FACTMOTOR"].ToString() != "") { FactMotor.ForeColor = Color.Green; } else { FactMotor.ForeColor = Color.Red; }
                if (exp.Rows[0]["FACTEMBARCACION"].ToString() != "") { FactEmb.ForeColor = Color.Green; } else { FactEmb.ForeColor = Color.Red; }
                if (exp.Rows[0]["PAPELETACHIPEO"].ToString() != "") { PapChip.ForeColor = Color.Green; } else { PapChip.ForeColor = Color.Red; }
                if (exp.Rows[0]["FOTOEMB"].ToString() != "") { FotoEmb.ForeColor = Color.Green; } else { FotoEmb.ForeColor = Color.Red; }
            }
            else
            {
                CertMatr.ForeColor = Color.Red;
                CertSeg.ForeColor = Color.Red;
                FactArtes.ForeColor = Color.Red;
                FactMotor.ForeColor = Color.Red;
                FactEmb.ForeColor = Color.Red;
                PapChip.ForeColor = Color.Red;
                FotoEmb.ForeColor = Color.Red;
            }
        }

        private void RegistrarUnidad_Click(object sender, EventArgs e)
        {
            if (NChipCertMat.Text == "   *   *" || ValidarChip())
            {
                exito = AccionesCertificado(true);
                val.Exito(exito);
                exito = 0;
                CertMatXUnidad();
                MatriculaCertMat.Focus();
            }
        }

        private void ActualizarUnidad_Click(object sender, EventArgs e)
        {
            if (NChipCertMat.Text == "   *   *" || ValidarChip())
            {
                exito = AccionesCertificado(false);
                val.Exito(exito);
                exito = 0;
                CertMatXUnidad();
                MatriculaCertMat.Focus();
            }
        }

        private void EliminarUnidad_Click(object sender, EventArgs e)
        {
            DialogResult Si = MessageBox.Show("¿Desea eliminar esta embarcación?", "ADVERTENCIA", MessageBoxButtons.YesNo);
            if (Si == DialogResult.Yes)
            {
                exito = proc.Eliminar_Embarcacion(MatriculaCertMat.Text);
                if (exito > 0)
                {
                    MessageBox.Show("La embarcación ha sido eliminada exitosamente.", "ELIMINADA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    CertMatXUnidad(); limpiarcertmat(); exito = 0;
                }
            }
            MatriculaCertMat.Focus();
        }

        bool ValidarChip()
        {
            DataTable chip = proc.ValidarChip(NChipCertMat.Text, MatriculaCertMat.Text);
            if (chip.Rows.Count > 0)
            {
                string embarcaciones = "";
                foreach (DataRow row in chip.Rows)
                {
                    embarcaciones += row["NOMBREEMBARCACION"].ToString() +"   con Matricula   "+ row["MATRICULA"].ToString() + "\n";
                }
                MessageBox.Show("El Numero de Chip está siendo usado por la Embarcación: \n" + embarcaciones,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            limpiarcertmat();
        }


        private void MatriculaCertMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                pictureBox14_Click(sender, e);
            }
        }

        private void ListaMatriculas_DoubleClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            limpiarcertmat();
            dt = proc.ObtenerCertMatrXUnidad(RNPA);
            int i = dt.Rows.Count;
            foreach (DataRow filas in dt.Rows)
            {
                string mat = filas["MATRICULA"].ToString();
                if (mat == ListaMatriculas.SelectedValue.ToString())
                {
                    MatriculaCertMat.Text = ListaMatriculas.SelectedValue.ToString();
                    NombreEmbCerMat.Text = filas["NOMBREEMBARCACION"].ToString();
                    ArqBrutoCertMat.Text = filas["ARQUEOBRUTO"].ToString();
                    ArqNetoCertMat.Text = filas["ARQUEONETO"].ToString();
                    EsloraCertMat.Text = filas["ESLORA"].ToString();
                    MangaCertMat.Text = filas["MANGA"].ToString();
                    NMotoresCertMat.Text = filas["NMOTORES"].ToString();
                    PesoMCertMat.Text = filas["TONELAJE"].ToString();
                    PotenciaMotorCertMat.Text = filas["MOTORHP"].ToString();
                    PuntalCertMat.Text = filas["PUNTAL"].ToString();
                    ServicioCertMat.Text = filas["SERVICIO"].ToString();
                    TraficoCertMat.Text = filas["TRAFICO"].ToString();
                    NChipCertMat.Text = filas["NUMCHIP"].ToString();
                    ResponsableChip.Text = filas["RESPONSABLECHIP"].ToString();
                    FechaChip.Text = filas["FECHACHIPEADO"].ToString();
                    RegNum.Text = filas["REGISTRONUM"].ToString();
                    FechaExped.Text = filas["FECHAEXP"].ToString();
                    Marca.Text = filas["MOTORMARCA"].ToString();
                }
                i--;
            }

            dgvPescadores.Rows.Clear();
            dt = proc.ChecarCapitan(RNPA, MatriculaCertMat.Text);
            if (dt.Rows.Count > 0)
            {
                string Nombre = dt.Rows[0]["NOMBRE"].ToString() + " " + dt.Rows[0]["AP_PAT"].ToString() + " " + dt.Rows[0]["AP_MAT"].ToString();
                dgvPescadores.Rows.Add("Capitan", Nombre);
            }
            dt = proc.ChecarMarineros(RNPA, MatriculaCertMat.Text);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    string Nombre = r["NOMBRE"].ToString() + " " + r["AP_PAT"].ToString() + " " + r["AP_MAT"].ToString();
                    dgvPescadores.Rows.Add("Marinero", Nombre);
                }
            }
            dt = proc.ChecarBuzo(RNPA, MatriculaCertMat.Text);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    string Nombre = r["NOMBRE"].ToString() + " " + r["AP_PAT"].ToString() + " " + r["AP_MAT"].ToString();
                    dgvPescadores.Rows.Add("Buzo", Nombre);
                }
            }
            dgvPescadores.ClearSelection();

            CargarExpediente();
            this.Cursor = Cursors.Default;
        }
        private void ActivarPanelMATRICULA_Click(object sender, EventArgs e)
        {
            MatriculaMal.Text = ListaMatriculas.SelectedValue.ToString();
            gbBotones.Enabled = false;
            gbBusqueda.Enabled = false;
            gbCertificado.Enabled = false;
            gbVerificacion.Enabled = false;
            PanelMATRICULA.Visible = true;
            PanelMATRICULA.Enabled = true;
        }

        private void CerrarPanel_Click(object sender, EventArgs e)
        {
            gbBotones.Enabled = true;
            gbBusqueda.Enabled = true;
            gbCertificado.Enabled = true;
            gbVerificacion.Enabled = true;
            PanelMATRICULA.Visible = false;
            PanelMATRICULA.Enabled = false;
            MatriculaNueva.Text = "";
        }

        private void ActualizarMATRICULA_Click(object sender, EventArgs e)
        {
            if (MatriculaNueva.Text != "")
            {
                DialogResult res = MessageBox.Show("Usted está por cambiar la MATRICULA de una Embarcación, en todos sus PERMISOS, PESCADORES.\n Desea continuar?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    if (proc.Actualizar_MATRICULA(MatriculaMal.Text, MatriculaNueva.Text) >= 1)
                    {
                        MatriculaCertMat.Text = MatriculaNueva.Text;
                        MessageBox.Show("MATRICULA Actualizada");
                    }
                    else { MessageBox.Show("MATRICULA Ya existe"); }
                    CertMatXUnidad();
                }
            }
        }

        private void AbrirExpediente_Click(object sender, EventArgs e)
        {
            if (MatriculaCertMat.Text != "")
            {
                Pantallas_Archivos.Expediente_Embarcacion expem = new Pantallas_Archivos.Expediente_Embarcacion(MatriculaCertMat.Text, NombreEmbCerMat.Text, NIVEL);
                expem.ShowDialog();
                CargarExpediente();
            }
        }
    }
}
