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

        BackgroundWorker bw = new BackgroundWorker();
        private void Menu1_Load(object sender, EventArgs e)
        {
            //ServiceController service = new ServiceController("MSSQL$SQLEXPRESS");
            //if (service != null && service.Status != ServiceControllerStatus.Running)
            //{
            //    service.Start();
            //    service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(5000));
            //}
            bw.DoWork += (obj, ea) => TaskAsync();
            bw.RunWorkerAsync();
        }
        private async void TaskAsync()
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

        private void Menu1_Activated(object sender, EventArgs e)
        {
            if (!bw.WorkerReportsProgress)
            {
                this.Ordenamiento.Visible = true;
                this.Solicitudes.Visible = true;
            }
        }
    }
}

