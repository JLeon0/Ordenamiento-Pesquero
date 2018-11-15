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

namespace OrdenamientoPesquero
{
    public partial class Pantalla_Certificado_Mat : Form
    {
        Procedimientos proc = new Procedimientos();
        DataTable dt;
        string RNPA;
        int exito = 0;
        Embarcacion Emb;
        Validaciones val = new Validaciones();

        public Pantalla_Certificado_Mat(string rnpa)
        {
            InitializeComponent();
            RNPA = rnpa;
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
                    Capitan.Text = filas["CAPITAN"].ToString();
                    Marinero.Text = filas["MARINERO"].ToString();
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
                Emb = new Embarcacion(NombreEmbCerMat.Text, MatriculaCertMat.Text.Replace(" ",""), RNPA.Replace(" ", ""), PotenciaMotorCertMat.Text, EsloraCertMat.Text, MangaCertMat.Text, PuntalCertMat.Text, ArqBrutoCertMat.Text, ArqNetoCertMat.Text, PesoMCertMat.Text, ServicioCertMat.Text, TraficoCertMat.Text, NMotoresCertMat.Value.ToString(), NChipCertMat.Text, FechaChip.Value.ToShortDateString(), ResponsableChip.Text, RegNum.Text, FechaExped.Value.ToShortDateString(),Capitan.Text, Marinero.Text, Marca.Text);
                return proc.Registrar_Embarcacion(Emb);
            }
            else
            {
                Emb = new Embarcacion(NombreEmbCerMat.Text, MatriculaCertMat.Text.Replace(" ", ""), RNPA.Replace(" ", ""), PotenciaMotorCertMat.Text, EsloraCertMat.Text, MangaCertMat.Text, PuntalCertMat.Text, ArqBrutoCertMat.Text, ArqNetoCertMat.Text, PesoMCertMat.Text, ServicioCertMat.Text, TraficoCertMat.Text, NMotoresCertMat.Value.ToString(), NChipCertMat.Text, FechaChip.Value.ToShortDateString(), ResponsableChip.Text, RegNum.Text, FechaExped.Value.ToShortDateString(), Capitan.Text, Marinero.Text, Marca.Text);
                return proc.Actualizar_Embarcacion(Emb);
            }
        }
        public void limpiarcertmat()
        {
            foreach (TextBox item in groupBox1.Controls.OfType<TextBox>())
            { 
                item.Text = "";
            }
            foreach (ComboBox item in groupBox2.Controls.OfType<ComboBox>())
            {
                item.Text = "";
            }
            foreach (MaskedTextBox item in groupBox2.Controls.OfType<MaskedTextBox>())
            {
                item.Text = "";
            }
            NMotoresCertMat.Value = 0;
        }

        private void RegistrarUnidad_Click(object sender, EventArgs e)
        {
            exito = AccionesCertificado(true);
            val.Exito(exito);
            exito = 0;
            CertMatXUnidad();
            MatriculaCertMat.Focus();
        }

        private void ActualizarUnidad_Click(object sender, EventArgs e)
        {
            exito = AccionesCertificado(false);
            val.Exito(exito);
            exito = 0;
            MatriculaCertMat.Focus();
        }

        private void EliminarUnidad_Click(object sender, EventArgs e)
        {
            DialogResult Si = MessageBox.Show("¿Desea eliminar esta embarcación?", "ADVERTENCIA", MessageBoxButtons.YesNo);
            if (Si == DialogResult.Yes)
            {
                exito = proc.Eliminar_Embarcacion(MatriculaCertMat.Text);
                val.Exito(exito);
                if (exito > 0)
                { CertMatXUnidad(); limpiarcertmat(); exito = 0; }   
            }
            MatriculaCertMat.Focus();
        }

        private void Pantalla_Certificado_Mat_Load(object sender, EventArgs e)
        {
            val.ajustarResolucion(this);
            CertMatXUnidad();
        }

        public void CertMatXUnidad()
        {
            dt = proc.ObtenerCertMatrXUnidad(RNPA);
            DataTable embarcaciones = new DataTable();
            ListaMatriculas.DataSource = embarcaciones;
            embarcaciones.Columns.Add("MATRICULA");
            embarcaciones.Columns.Add("NOMBREEMBARCACION");
            foreach (DataRow fila in dt.Rows)
            {
                if (fila["MATRICULA"].ToString() != RNPA)
                {
                    embarcaciones.Rows.Add(fila["MATRICULA"].ToString(), fila["NOMBREEMBARCACION"].ToString());
                }
                //ListaMatriculas.Items.Add(fila["MATRICULA"].ToString());
            }
            ListaMatriculas.DataSource = embarcaciones;
            ListaMatriculas.DisplayMember = "NOMBREEMBARCACION";
            ListaMatriculas.ValueMember = "MATRICULA";
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
                    Capitan.Text = filas["CAPITAN"].ToString();
                    Marinero.Text = filas["MARINERO"].ToString();
                    Marca.Text = filas["MOTORMARCA"].ToString();
                }
                i--;
            }
            this.Cursor = Cursors.Default;
        }
    }
}
