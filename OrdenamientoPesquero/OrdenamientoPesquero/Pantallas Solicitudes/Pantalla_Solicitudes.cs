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
    public partial class Pantalla_Solicitudes : Form
    {
        string Curp;
        Procedimientos proc = new Procedimientos();
        Solicitud soli = new Solicitud();
        public Pantalla_Solicitudes(string nombre, string curp)
        {
            InitializeComponent();
            NombrePesc.Text = nombre;
            Curp = curp;
        }

        private void Pantalla_Solicitudes_Load(object sender, EventArgs e)
        {

        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
