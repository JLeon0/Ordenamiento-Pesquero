﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaDatos;
using Logica;

namespace OrdenamientoPesquero.Pantallas_Menu
{
    public partial class Login : Form
    {
        BackgroundWorker bw = new BackgroundWorker();
        Conexion c;
        Procedimientos proc = new Procedimientos();
        Validaciones val = new Validaciones();
        public Login()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "Usuario")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.Black;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "Usuario";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Contraseña")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.Black;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Contraseña";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bw.DoWork += (obj, ea) => Task();
            bw.RunWorkerAsync();
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
        private void Task()
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
        private void btnlogin_Click(object sender, EventArgs e)
        {
            DataTable data = proc.AutenticarLogin(txtuser.Text, val.Encriptar(txtpass.Text));
            if(data.Rows.Count > 0)
            {
                string Usuario = data.Rows[0]["USERS"].ToString();
                string NombreUsuario = data.Rows[0]["NOMBRE"].ToString();
                int Nivel = Convert.ToInt32(data.Rows[0]["NIVEL"].ToString());
                if (Nivel == 0 || Nivel == 1)
                {
                    Menu1 menu1 = new Menu1(Usuario, NombreUsuario, Nivel);
                    this.Hide();
                    menu1.Show(this);
                }
                else if(Nivel == 2)
                {
                    Pantalla_Registro_Usuario usu = new Pantalla_Registro_Usuario("","",2,Usuario,NombreUsuario,Nivel);
                    this.Hide();
                    usu.Show(this);
                }
                else if(Nivel == 3)
                {
                    Pantalla_Registro_UnidadEconomica ue = new Pantalla_Registro_UnidadEconomica(Usuario, NombreUsuario, Nivel);
                    this.Hide();
                    ue.Show(this);
                }
                LimpiarDatos();
                //this.Show();
            }
            else { MessageBox.Show("Usuario y/o Contraseña Incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);}
        }
        private void LimpiarDatos()
        {
            txtuser.Text = "Usuario";
            txtuser.ForeColor = Color.DimGray;
            txtpass.Text = "Contraseña";
            txtpass.ForeColor = Color.DimGray;
            txtpass.UseSystemPasswordChar = false;
            txtuser.Focus();
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                btnlogin.PerformClick();
            }
        }
    }
}