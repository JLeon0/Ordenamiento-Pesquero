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
                }
                i--;
            }
        }
        public int AccionesCertificado(bool Registro)
        {
            if (Registro)
            {
                Emb = new Embarcacion(NombreEmbCerMat.Text, MatriculaCertMat.Text, RNPA, PotenciaMotorCertMat.Text, EsloraCertMat.Text, MangaCertMat.Text, PuntalCertMat.Text, ArqBrutoCertMat.Text, ArqNetoCertMat.Text, PesoMCertMat.Text, ServicioCertMat.Text, TraficoCertMat.Text, NMotoresCertMat.Value.ToString());
                return proc.Registrar_Embarcacion(Emb);
            }
            else
            {
                Emb = new Embarcacion(NombreEmbCerMat.Text, MatriculaCertMat.Text, RNPA, PotenciaMotorCertMat.Text, EsloraCertMat.Text, MangaCertMat.Text, PuntalCertMat.Text, ArqBrutoCertMat.Text, ArqNetoCertMat.Text, PesoMCertMat.Text, ServicioCertMat.Text, TraficoCertMat.Text, NMotoresCertMat.Value.ToString());
                return proc.Actualizar_Embarcacion(Emb);
            }
        }
        public void limpiarcertmat()
        {
            foreach (TextBox item in Controls.OfType<TextBox>())
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
        }

        private void ActualizarUnidad_Click(object sender, EventArgs e)
        {
            exito = AccionesCertificado(false);
            val.Exito(exito);
            exito = 0;
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
        }

        private void Pantalla_Certificado_Mat_Load(object sender, EventArgs e)
        {
            CertMatXUnidad();
        }

        public void CertMatXUnidad()
        {
            dt = proc.ObtenerCertMatrXUnidad(RNPA);
            MatriculaCertMat.DataSource = dt;
            MatriculaCertMat.DisplayMember = "MATRICULA";
            MatriculaCertMat.ValueMember = "MATRICULA";
            MatriculaCertMat.Text = "";
        }
    }
}
