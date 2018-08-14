using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenamientoPesquero.Pantallas_Menu
{
    public partial class Menu1 : Form
    {
        public Menu1()
        {
            InitializeComponent();
        }

        private void Solicitudes_Click(object sender, EventArgs e)
        {
            //Process.Start("C:\\Windows\\SigPlus\\DemoOCX.exe");
            Pantalla_Registro_Usuario pantalla = new Pantalla_Registro_Usuario("","");
            pantalla.ShowDialog();
        }

        private void Ordenamiento_Click(object sender, EventArgs e)
        {
            Pantalla_Registro_UnidadEconomica unidad = new Pantalla_Registro_UnidadEconomica();
            unidad.ShowDialog();
        }
    }
}
