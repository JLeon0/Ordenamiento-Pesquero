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
    public partial class Pantalla_Registro_Usuario : Form
    {
        string[,] pescador = { { "0", "CURP" }, { "0", "RFC" }, { "0", "Codigo postal" }, { "0", "Telefono" }, { "0", "Correo Electronico" } };
        int exito = 0;
        Pescador pes;
        Procedimientos proc = new Procedimientos();
        Validaciones val = new Validaciones();

        public Pantalla_Registro_Usuario()
        {
            InitializeComponent();

        }

        private void Pantalla_Registro_Usuario_Load(object sender, EventArgs e) {

        }

        public int AccionesPescador(bool registrar)
        {
            string sexo = "";
            string tipo_pes = "";
            string ocupacion = "";
            string cuerpo = "";
            foreach (CheckBox item in groupBox7.Controls.OfType<CheckBox>())
            {
                if (item.Checked)
                {
                    sexo = item.Text;
                }
            }
            foreach (CheckBox item in TipoPesc.Controls.OfType<CheckBox>())
            {
                if (item.Checked)
                {
                    tipo_pes = item.Text;
                }
            }
            foreach (CheckBox item in OcupacionEnEmbarPesc.Controls.OfType<CheckBox>())
            {
                if (item.Checked)
                {
                    ocupacion = item.Text;
                }
            }
            foreach (CheckBox item in CuerpoDeAguaPesc.Controls.OfType<CheckBox>())
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

        private void RegistrarUnidad_Click(object sender, EventArgs e)
        {
            bool errordatos = false;
            if (!val.validaralgo(pescador))
            {
                errordatos = true;
            }
            else
            {
                exito = AccionesPescador(true);
            }
        }
    }
}
