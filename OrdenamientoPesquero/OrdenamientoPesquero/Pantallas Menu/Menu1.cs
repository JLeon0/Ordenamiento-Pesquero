using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using CapaDatos;

namespace OrdenamientoPesquero.Pantallas_Menu
{
    public partial class Menu1 : Form
    {
        Conexion c;
        public Menu1()
        {
            InitializeComponent();
        }

        private void Solicitudes_Click(object sender, EventArgs e)
        {
            Pantalla_Registro_Usuario pantalla = new Pantalla_Registro_Usuario("", "");
            pantalla.ShowDialog();
        }

        private void Ordenamiento_Click(object sender, EventArgs e)
        {
            Pantalla_Registro_UnidadEconomica unidad = new Pantalla_Registro_UnidadEconomica();
            unidad.ShowDialog();
        }

        private void CargarInstancia()
        {
            Microsoft.Win32.RegistryKey baseKey = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry64);
            Microsoft.Win32.RegistryKey key = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL");
            foreach (string s in key.GetValueNames())
            {
                c = new Conexion("OrdPesquero", @".\" + s);
            }
            setString(c.CONEXIONPERRONA);
        }

        private void Menu1_Load_1(object sender, EventArgs e)
        {
            CargarInstancia();
        }
        public string setString(string CONEXIONPERRONA)
        {
            Properties.Settings.Default.OrdPesqueroConnectionString = CONEXIONPERRONA;
            Properties.Settings.Default.OrdPesqueroConnectionString1 = CONEXIONPERRONA;
            Properties.Settings.Default.OrdPesqueroConnectionString2 = CONEXIONPERRONA;
            Properties.Settings.Default.OrdPesqueroConnectionString3 = CONEXIONPERRONA;
            Properties.Settings.Default.OrdPesqueroConnectionString4 = CONEXIONPERRONA;
            // modificamos el guardado
            Properties.Settings.Default.Save();

            return Properties.Settings.Default.OrdPesqueroConnectionString;
        }
    }
}

