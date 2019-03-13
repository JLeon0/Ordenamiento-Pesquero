using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using CapaDatos;
using System.ServiceProcess;
using System.Threading;

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
            Pantalla_Registro_Usuario pantalla = new Pantalla_Registro_Usuario("", "",2);
            pantalla.ShowDialog();
        }

        private void Ordenamiento_Click(object sender, EventArgs e)
        {
            Pantalla_Registro_UnidadEconomica unidad = new Pantalla_Registro_UnidadEconomica();
            unidad.ShowDialog();
        }



        private void Menu1_Load(object sender, EventArgs e)
        {
        }




        private void CerrarPanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

