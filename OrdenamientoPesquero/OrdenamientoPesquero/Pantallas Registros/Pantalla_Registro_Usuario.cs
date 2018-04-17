﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using OrdenamientoPesquero.Pantallas_Registros;

namespace OrdenamientoPesquero
{
    public partial class Pantalla_Registro_Usuario : Form
    {
        string[,] pescador = { { "0", "CURP" }, { "0", "RFC" }, { "0", "Codigo postal" }, { "0", "Telefono" }, { "0", "Correo Electronico" } };
        int exito = 0;
        Pescador pes;
        Procedimientos proc = new Procedimientos();
        Validaciones val = new Validaciones();
        DataTable dt;
        string RNPA = "", NombreUnidad = "";

        public Pantalla_Registro_Usuario(string rnpa, string nombre)
        {
            InitializeComponent();
            RNPA = rnpa;
            NombreUnidad = nombre;
        }

        private void Pantalla_Registro_Usuario_Load(object sender, EventArgs e) {
            limpiarpescador();
            CargarPescadores();
            CargarMatriculas();
        }


        public int AccionesPescador(bool registrar)
        {
            string sexo = "";
            string tipo_pes = "";
            string ocupacion = "";
            string cuerpo = "";
            foreach (RadioButton item in groupBox7.Controls.OfType<RadioButton>())
            {
                if (item.Checked)
                {
                    sexo = item.Text;
                    break;
                }
            }
            foreach (RadioButton item in TipoPesc.Controls.OfType<RadioButton>())
            {
                if (item.Checked)
                {
                    tipo_pes = item.Text;
                    break;
                }
            }
            foreach (RadioButton item in OcupacionEnEmbarPesc.Controls.OfType<RadioButton>())
            {
                if (item.Checked)
                {
                    ocupacion = item.Text;
                    break;
                }
            }
            foreach (RadioButton item in CuerpoDeAguaPesc.Controls.OfType<RadioButton>())
            {
                if (item.Checked)
                {
                    cuerpo = item.Text;
                    break;
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
            pes = new Pescador(NombrePesc.Text, ApePatPescador.Text, ApeMatPescador.Text, CURPPesc.Text, RFCPesc.Text, EscolaridadPesc.Text, TSangrePesc.Text, sexo, LugarNacPesc.Text, fechaNac, CalleYNumPesc.Text, ColoniaPesc.Text, MunicipioPesc.Text, CPPesc.Text, TelefonoPesc.Text, tipo_pes, ocupacion, cuerpo, MatriculaPesc.Text, CorreoPesc.Text);
            if (registrar)
            {
                return proc.Registrar_Pescador(pes);
            }
            else
            {
                return proc.Actualizar_Pescador(pes);
            }
        }

        private void RegistrarUnidad_Click(object sender, EventArgs e)
        {
            if (!val.validaralgo(pescador))
            {
            }
            else
            {
                exito = AccionesPescador(true);
            }
            val.Exito(exito);
            exito = 0;
        }

        private void ActualizarUnidad_Click(object sender, EventArgs e)
        {
            if (!val.validaralgo(pescador))
            {
            }
            else
            {
                exito = AccionesPescador(false);
            }
            val.Exito(exito);
            exito = 0;
        }

        private void CURPPesc_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            dt = proc.Obtener_Pescador(CURPPesc.Text);
            limpiarpescador();
            string tipopescador = "", ocupacion = "", cuerpoagua = "";
            foreach (DataRow filas in dt.Rows)
            {
                NombrePesc.Text = filas["NOMBRE"].ToString();
                ApePatPescador.Text = filas["AP_PAT"].ToString();
                ApeMatPescador.Text = filas["AP_MAT"].ToString();
                RFCPesc.Text = filas["RFC"].ToString();
                EscolaridadPesc.Text = filas["ESCOLARIDAD"].ToString();
                EstadoPesc.Text = "Baja California Sur";
                TSangrePesc.Text = filas["TIPO_SANGRE"].ToString();
                LugarNacPesc.Text = filas["LUGAR_NACIMIENTO"].ToString();
                ColoniaPesc.Text = filas["COLONIA"].ToString();
                CalleYNumPesc.Text = filas["CALLENUM"].ToString();
                MunicipioPesc.Text = filas["MUNICIPIO"].ToString();
                CPPesc.Text = filas["CODIGO_POSTAL"].ToString();
                TelefonoPesc.Text = filas["TELEFONO"].ToString();
                tipopescador = filas["TIPO_PESCADOR"].ToString();
                ocupacion = filas["OCUPACION_LABORAL"].ToString();
                cuerpoagua = filas["CUERPO_DE_AGUA"].ToString();
                MatriculaPesc.Text = filas["MATRICULA"].ToString();
                CorreoPesc.Text = filas["CORREO"].ToString();
            }
            foreach (RadioButton boton in TipoPesc.Controls)
            {
                if (boton.Text == tipopescador)
                {
                    boton.Checked = true;
                }
            }
            foreach (RadioButton boton in CuerpoDeAguaPesc.Controls)
            {
                if (boton.Text == cuerpoagua)
                {
                    boton.Checked = true;
                }
            }
            foreach (RadioButton boton in OcupacionEnEmbarPesc.Controls)
            {
                if (boton.Text == ocupacion)
                {
                    boton.Checked = true;
                }
            }
        }

        public void limpiarpescador()
        {
            foreach (TextBox item in groupBox7.Controls.OfType<TextBox>())
            {
                item.Text = "";
            }
            foreach (MaskedTextBox item in groupBox7.Controls.OfType<MaskedTextBox>())
            {
                item.Text = "";
            }
            foreach (ComboBox item in groupBox7.Controls.OfType<ComboBox>())
            {
                item.Text = "";
            }
        }

        private void CURPPesc_TextChanged(object sender, EventArgs e)
        {
            if (val.validarcurp(CURPPesc.Text))
            {
                pictureBox9.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
                pescador[0, 0] = "1";
                FechaNacPesc.Value = val.Fechanac(CURPPesc.Text);
                if (CURPPesc.Text[10] == 'H')
                {
                    MasculinoPesc.Checked = true;
                }
                else
                {
                    FemeninoPesc.Checked = true;
                }
            }
            else
            {
                pictureBox9.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
                pescador[0, 0] = "0";
            }
        }

        private void RFCPesc_TextChanged(object sender, EventArgs e)
        {
            if (val.validarrfc(RFCPesc.Text))
            {
                pictureBox7.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
                pescador[1, 0] = "1";

            }
            else
            {
                pictureBox7.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
                pescador[1, 0] = "0";
            }
        }

        private void CPPesc_TextChanged(object sender, EventArgs e)
        {
            if (CPPesc.Text.Contains(' ') || CPPesc.Text.Length != 5)
            {
                pictureBox8.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
                pescador[2, 0] = "0";
            }
            else
            {
                pictureBox8.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
                pescador[2, 0] = "1";
            }
        }

        private void TelefonoPesc_TextChanged(object sender, EventArgs e)
        {
            if (TelefonoPesc.Text.Contains(' ') || TelefonoPesc.Text.Length != 12)
            {
                pictureBox5.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
                pescador[3, 0] = "0";
            }
            else
            {
                pictureBox5.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
                pescador[3, 0] = "1";
            }
        }

        private void CorreoPesc_TextChanged(object sender, EventArgs e)
        {
            if (val.validarCorreo(CorreoPesc.Text))
            {
                pictureBox6.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
                pescador[4, 0] = "1";
            }
            else
            {
                pictureBox6.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
                pescador[4, 0] = "0";
            }
        }

        private void EliminarUnidad_Click(object sender, EventArgs e)
        {
            DialogResult Si = MessageBox.Show("¿Desea eliminar este Pescador?", "ADVERTENCIA", MessageBoxButtons.YesNo);
            if (Si == DialogResult.Yes)
            {
                exito = proc.Eliminar_Pescador(CURPPesc.Text);
                if (exito > 0) { limpiarpescador(); exito = 0; }
            }
        }

        private void CargarPescadores()
        {
            dt = proc.Obtener_curp(RNPA);
            CURPPesc.DataSource = dt;
            CURPPesc.DisplayMember = "CURP";
            CURPPesc.ValueMember = "CURP";
            CURPPesc.Text = "";
        }

        private void CargarMatriculas()
        {
            dt = proc.ObtenerCertMatrXUnidad(RNPA);
            MatriculaPesc.DataSource = dt;
            MatriculaPesc.DisplayMember = "MATRICULA";
            MatriculaPesc.ValueMember = "MATRICULA";
            MatriculaPesc.Text = "";
        }

        private void CURPPesc_SelectedValueChanged(object sender, EventArgs e)
        {
            dt = proc.Obtener_Pescador(CURPPesc.Text);
            limpiarpescador();
            string tipopescador = "", ocupacion = "", cuerpoagua = "";
            foreach (DataRow filas in dt.Rows)
            {
                NombrePesc.Text = filas["NOMBRE"].ToString();
                ApePatPescador.Text = filas["AP_PAT"].ToString();
                ApeMatPescador.Text = filas["AP_MAT"].ToString();
                RFCPesc.Text = filas["RFC"].ToString();
                EscolaridadPesc.Text = filas["ESCOLARIDAD"].ToString();
                EstadoPesc.Text = "Baja California Sur";
                TSangrePesc.Text = filas["TIPO_SANGRE"].ToString();
                LugarNacPesc.Text = filas["LUGAR_NACIMIENTO"].ToString();
                ColoniaPesc.Text = filas["COLONIA"].ToString();
                CalleYNumPesc.Text = filas["CALLENUM"].ToString();
                MunicipioPesc.Text = filas["MUNICIPIO"].ToString();
                CPPesc.Text = filas["CODIGO_POSTAL"].ToString();
                TelefonoPesc.Text = filas["TELEFONO"].ToString();
                tipopescador = filas["TIPO_PESCADOR"].ToString();
                ocupacion = filas["OCUPACION_LABORAL"].ToString();
                cuerpoagua = filas["CUERPO_DE_AGUA"].ToString();
                MatriculaPesc.Text = filas["MATRICULA"].ToString();
                CorreoPesc.Text = filas["CORREO"].ToString();
            }
            foreach (RadioButton boton in TipoPesc.Controls)
            {
                if (boton.Text == tipopescador)
                {
                    boton.Checked = true;
                }
            }
            foreach (RadioButton boton in CuerpoDeAguaPesc.Controls)
            {
                if (boton.Text == cuerpoagua)
                {
                    boton.Checked = true;
                }
            }
            foreach (RadioButton boton in OcupacionEnEmbarPesc.Controls)
            {
                if (boton.Text == ocupacion)
                {
                    boton.Checked = true;
                }
            }
        }

        private void Ver_Click(object sender, EventArgs e)
        {
            Vistas vista = new Vistas(RNPA, NombreUnidad);
            vista.ShowDialog();
        }
    }
}
