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

namespace OrdenamientoPesquero.Pantallas_Registros
{
    public partial class Pantalla_Federaciones : Form
    {
        string NF = "";
        public Pantalla_Federaciones(string name)
        {
            InitializeComponent();
            NF = name;
        }
        Procedimientos proc = new Procedimientos();
        DataTable dt = new DataTable();
        int Folio = 0;
        private void Registrar_Click(object sender, EventArgs e)
        {
            ObtenerFolio();
            if(proc.Registar_Federacion(Nombre.Text, Presidente.Text, Telefono.Text, Correo.Text) > 0)
            {
                MessageBox.Show("Registrado Correctamente");
            }
            else
            {
                MessageBox.Show("Error al Registrar");
            }
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            ObtenerFolio();
            if(proc.Actualizar_Federacion(Nombre.Text, Presidente.Text, Telefono.Text, Correo.Text, Folio) > 0)
            {
                MessageBox.Show("Registrado Correctamente");
            }
            else
            {
                MessageBox.Show("Error al Registrar");
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            ObtenerFolio();
            proc.Eliminar_Federacion(Folio);
        }
        private void CargarFederacion()
        {
            dt = proc.Obtener_Federaciones();
            Nombre.DataSource = dt;
            Nombre.DisplayMember = "NOMBRE";
            //Nombre.ValueMember = "NOMBRE";
            Nombre.Text = "Seleccione una Federación";
        }

        private void Pantalla_Federaciones_Load(object sender, EventArgs e)
        {
            CargarFederacion();
            CargarDatos();
        }

        private void ObtenerFolio()
        {
            foreach (DataRow filas in dt.Rows)
            {
                string n = filas["NOMBRE"].ToString();
                if (n == Nombre.Text)
                {
                    Folio = Convert.ToInt32(filas["FOLIO"].ToString());
                }
            }
        }

        private void CargarDatos()
        {
            foreach (DataRow filas in dt.Rows)
            {
                if(NF == filas["NOMBRE"].ToString())
                {
                    Presidente.Text = filas["PRESIDENTE"].ToString();
                    Telefono.Text = filas["TELEFONO"].ToString();
                    Correo.Text = filas["CORREO"].ToString();
                    break;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            NF = Nombre.Text;
            CargarDatos();
        }
    }
}
