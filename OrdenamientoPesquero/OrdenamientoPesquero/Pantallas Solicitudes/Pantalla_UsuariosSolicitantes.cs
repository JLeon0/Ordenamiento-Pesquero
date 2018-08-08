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

namespace OrdenamientoPesquero.Pantallas_Solicitudes
{
    public partial class Pantalla_UsuariosSolicitantes : Form
    {
        Procedimientos proc = new Procedimientos();
        DataTable dt, Nombres;
        byte[] imagenBuffer;
        public Pantalla_UsuariosSolicitantes()
        {
            InitializeComponent();
        }


        private void Pantalla_UsuariosSolicitantes_Load(object sender, EventArgs e)
        {
            CargarPescadores();
        }

        private void CargarPescadores()
        {
            Nombres = proc.BuscarNombre("", "");
            ListaNombres.Items.Clear();
            foreach (DataRow fila in Nombres.Rows)
            {
                ListaNombres.Items.Add(fila["NOMBRE"].ToString());
            }
        }

        private void ListaNombres_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LlenarDatos(Nombres.Rows[ListaNombres.SelectedIndex]["CURP"].ToString());
        }
        public void LlenarDatos(string curp)
        {
            this.Cursor = Cursors.WaitCursor;
            string c = curp;
            dt = proc.Obtener_Pescador(c);
            limpiarpescador();
            int ord = 0;
            foreach (DataRow filas in dt.Rows)
            {
                NombrePesc.Text = filas["NOMBRE"].ToString();
                ApePatPescador.Text = filas["AP_PAT"].ToString();
                ApeMatPescador.Text = filas["AP_MAT"].ToString();
                LocalidadPesc.Text = "Baja California Sur";
                LugarNacPesc.Text = filas["LUGAR_NACIMIENTO"].ToString();
                ColoniaPesc.Text = filas["COLONIA"].ToString();
                CalleYNumPesc.Text = filas["CALLENUM"].ToString();
                MunicipioPesc.Text = filas["MUNICIPIO"].ToString();
                CPPesc.Text = filas["CODIGO_POSTAL"].ToString();
                TelefonoPesc.Text = filas["TELEFONO"].ToString();
                LocalidadPesc.Text = filas["LOCALIDAD"].ToString();
                ord = Convert.ToInt32(filas["ORDENAMIENTO"].ToString());
            }
            if (ord == 1) { si.Checked = true; }
            else { no.Checked = true; }
            CURPPesc.Text = c;
            ObtenerImagen();
            dt = proc.Obtener_todas_unidades(Nombres.Rows[ListaNombres.SelectedIndex]["RNPTITULAR"].ToString());
            NombreUnidad.Text = dt.Rows[0]["NOMBRE"].ToString();
            this.Cursor = Cursors.Default;
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
            NombreUnidad.Text = "Sin Unidad";
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            limpiarpescador();
        }

        private void Solicitud_Click(object sender, EventArgs e)
        {
            Pantallas_Registros.Pantalla_Solicitudes pantalla = new Pantallas_Registros.Pantalla_Solicitudes(ListaNombres.Text, CURPPesc.Text);
            pantalla.ShowDialog();
        }

        private void ObtenerImagen()
        {
            Imagen.BackgroundImage = null;
            dt = proc.ObtenerImagen(CURPPesc.Text);
            if (dt.Rows.Count > 0)
            {
                Imagen.BackColor = Color.White;
                Imagen.BackgroundImage = null;
                imagenBuffer = (byte[])dt.Rows[0]["IMAGEN"];
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
                Imagen.BackgroundImage = (Image.FromStream(ms));
                Imagen.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }
    }
}
