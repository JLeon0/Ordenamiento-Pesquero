using System;
using System.Windows.Forms;
using Logica;

namespace OrdenamientoPesquero.Pantallas_Menu
{
    public partial class Menu1 : Form
    {
        Procedimientos proc = new Procedimientos();
        Validaciones val = new Validaciones();
        string Nombre, Usuario;
        int Nivel;
        public Menu1(string user, string nombre,int nivel)
        {
            InitializeComponent();
            Usuario = user;
            Nombre = nombre;
            Nivel = nivel;
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
            NombreUsuario.Text += Nombre;
            if(Nivel != 0)
            {
                this.Height = 460;
                panel1.Height = 450;
            }
        }

        private void CerrarPanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    

        #region CrearLoggin
        private void RegistrarLoggin_Click(object sender, EventArgs e)
        {
            if (PassLogin.Text == RepetirPassLogin.Text)
            {
                if (proc.CrearLoggin(UsuarioLogin.Text, val.Encriptar(PassLogin.Text), NombreUsuarioLogin.Text, Convert.ToInt32(NivelUsuarioLogin.Value)) > 0)
                {
                    MessageBox.Show("Usuario Creado con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("El Usuario ya Existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show( "Las contraseñas son incorrectas", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PassLogin.Focus();
            }
        }
        private void RegUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelRegUser.Visible = true;
            CerrarPanel.Enabled = false;
            Ordenamiento.Enabled = false;
            Solicitudes.Enabled = false;
            RegUsuario.Enabled = false;
            RegPrograma.Enabled = false;
        }

        private void CerrarPanelUsuario_Click(object sender, EventArgs e)
        {
            PanelRegUser.Visible = false;
            CerrarPanel.Enabled = true;
            Ordenamiento.Enabled = true;
            Solicitudes.Enabled = true;
            RegUsuario.Enabled = true;
            RegPrograma.Enabled = true;
        }
        #endregion


    }
}

