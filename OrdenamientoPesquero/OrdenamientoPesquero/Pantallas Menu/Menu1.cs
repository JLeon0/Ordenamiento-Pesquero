using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Logica;

namespace OrdenamientoPesquero.Pantallas_Menu
{
    public partial class Menu1 : Form
    {
        Procedimientos proc = new Procedimientos();
        Validaciones val = new Validaciones();
        string NombreUsuario, Usuario;
        DataTable datalogin,dataprograma;
        int Nivel;
        public Menu1(string user, string nombre,int nivel)
        {
            InitializeComponent();
            Usuario = user;
            NombreUsuario = nombre;
            Nivel = nivel;
        }


        private void Solicitudes_Click(object sender, EventArgs e)
        {
            Pantalla_Registro_Usuario pantalla = new Pantalla_Registro_Usuario("", "",2,Usuario,NombreUsuario,Nivel,"OrdPesquero");
            this.Hide();
            pantalla.Show(this);
        }

        private void Ordenamiento_Click(object sender, EventArgs e)
        {
            Pantalla_Registro_UnidadEconomica unidad = new Pantalla_Registro_UnidadEconomica(Usuario,NombreUsuario,Nivel);
            this.Hide();
            unidad.Show(this);
        }

        private void Menu1_Load(object sender, EventArgs e)
        {
            Bienvenido.Text += NombreUsuario;
            if (Nivel != 0)
            {
                RegUsuario.Visible = false;
                RegPrograma.Visible = false;
                ActLogo.Visible = false;
            }
            else
            {
                ObtenerLogins();
                ObtenerProgramas();
                limpiartodo();
            }
        }

        private void CerrarPanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    

        #region CrearLoggin
        private void RegistrarLoggin_Click(object sender, EventArgs e)
        {
            if (UsuarioLogin.Text != "" && PassLogin.Text != "" && NombreUsuarioLogin.Text != "")
            {
                if (PassLogin.Text == RepetirPassLogin.Text)
                {
                    if (proc.CrearLoggin(UsuarioLogin.Text, val.Encriptar(PassLogin.Text), NombreUsuarioLogin.Text, Convert.ToInt32(NivelUsuarioLogin.Value)) > 0)
                    {
                        MessageBox.Show("Usuario Creado con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        ObtenerLogins();
                        limpiartodo();
                    }
                    else
                    {
                        MessageBox.Show("El Usuario ya Existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas son incorrectas", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PassLogin.Focus();
                }
            }
            else { MessageBox.Show("Debe llenar todos los campos del usuario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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


        private void ActualizarLoggin_Click(object sender, EventArgs e)
        {
            if (UsuarioLogin.Text != "" && PassLogin.Text != "" && NombreUsuarioLogin.Text != "")
            {
                if (PassLogin.Text == RepetirPassLogin.Text)
                {
                    if (proc.AutenticarLogin(UsuarioLogin.Text, val.Encriptar(PassLogin.Text)).Rows.Count > 0)
                    {
                        if (proc.ActualizarLogin(UsuarioLogin.Text, val.Encriptar(PassLogin.Text), NombreUsuarioLogin.Text, Convert.ToInt32(NivelUsuarioLogin.Value)) > 0)
                        {
                            MessageBox.Show("Datos Actualizados Correctamente", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else { MessageBox.Show("Usuario y/o Contraseña Incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {
                    MessageBox.Show("Las contraseñas son incorrectas", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PassLogin.Focus();
                }
            }
            else { MessageBox.Show("Debe llenar todos los campos del usuario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void EliminarLoggin_Click(object sender, EventArgs e)
        {
            if (UsuarioLogin.Text != "Admin")
            {
                DialogResult dialogResult = MessageBox.Show("Desea eliminar el Usuario " + NombreUsuarioLogin.Text, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    if (PassLogin.Text != "" && PassLogin.Text == RepetirPassLogin.Text)
                    {
                        if (proc.AutenticarLogin(UsuarioLogin.Text, val.Encriptar(PassLogin.Text)).Rows.Count > 0)
                        {
                            if (proc.EliminarLogin(UsuarioLogin.Text) > 0)
                            {
                                MessageBox.Show("Datos Eliminados Correctamente", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                ObtenerLogins();
                                limpiartodo();
                            }
                        }
                        else { MessageBox.Show("Usuario y/o Contraseña Incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas son incorrectas", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PassLogin.Focus();
                    }
                }
            }
            else { MessageBox.Show("No se puede borrar al Administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region CrearPrograma
        private void RegistrarPrograma_Click(object sender, EventArgs e)
        {
            if (NombrePrograma.Text != "" && DirectorPrograma.Text != "" && ResponsablePrograma.Text != "" && ClavePrograma.Text != "")
            {
                if (proc.Registrar_Programa(NombrePrograma.Text, DirectorPrograma.Text, ResponsablePrograma.Text, UsuarioPrograma.SelectedValue.ToString(), ClavePrograma.Text) > 0)
                {
                    MessageBox.Show("Programa Creado con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ObtenerProgramas();
                    limpiartodo();
                }
                else
                {
                    MessageBox.Show("El Programa ya Existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else { MessageBox.Show("Debe llenar todos los campos del Programa", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void EliminarPrograma_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Desea eliminar el Programa " + NombrePrograma.Text, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                if (proc.Eliminar_Programa(NombrePrograma.Text) > 0)
                {
                    MessageBox.Show("Programa Eliminado con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ObtenerProgramas();
                }
                else
                {
                    MessageBox.Show("Hubo un problema al Eliminar el Programa", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ActualizarPrograma_Click(object sender, EventArgs e)
        {
            if (NombrePrograma.Text != "" && DirectorPrograma.Text != "" && ResponsablePrograma.Text != "" && ClavePrograma.Text != "")
            {
                if (proc.Actualizar_Programa(NombrePrograma.Text, DirectorPrograma.Text, ResponsablePrograma.Text, UsuarioPrograma.SelectedValue.ToString(), ClavePrograma.Text) > 0)
                {
                    MessageBox.Show("Programa Actualizado con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ObtenerProgramas();
                    limpiartodo();
                }
                else
                {
                    MessageBox.Show("Hubo un problema al Actualizar el Programa", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else { MessageBox.Show("Debe llenar todos los campos del Programa", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void RegPrograma_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelRegProgram.Visible = true;
            CerrarPanel.Enabled = false;
            Ordenamiento.Enabled = false;
            Solicitudes.Enabled = false;
            RegUsuario.Enabled = false;
            RegPrograma.Enabled = false;
        }
        #endregion


     

        private void limpiar_Click(object sender, EventArgs e)
        {
            limpiartodo();
        }

        void limpiartodo()
        {
            PanelRegUser.Controls.OfType<TextBox>().ToList().ForEach(item => item.Text = "");
            PanelRegUser.Controls.OfType<ComboBox>().ToList().ForEach(item => item.Text = "");

            PanelRegProgram.Controls.OfType<TextBox>().ToList().ForEach(item => item.Text = "");
            PanelRegProgram.Controls.OfType<ComboBox>().ToList().ForEach(item => item.Text = "");
        }

        private void CerrarPanelPrograma_Click(object sender, EventArgs e)
        {
            PanelRegProgram.Visible = false;
            CerrarPanel.Enabled = true;
            Ordenamiento.Enabled = true;
            Solicitudes.Enabled = true;
            RegUsuario.Enabled = true;
            RegPrograma.Enabled = true;
            limpiartodo();
        }
        private void CerrarPanelUsuario_Click(object sender, EventArgs e)
        {
            PanelRegUser.Visible = false;
            CerrarPanel.Enabled = true;
            Ordenamiento.Enabled = true;
            Solicitudes.Enabled = true;
            RegUsuario.Enabled = true;
            RegPrograma.Enabled = true;
            limpiartodo();
        }


        private void NombrePrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NombrePrograma.SelectedIndex > -1)
            {
                DirectorPrograma.Text = dataprograma.Rows[NombrePrograma.SelectedIndex]["DIRECTOR"].ToString();
                //ResponsablePrograma.Text = dataprograma.Rows[NombrePrograma.SelectedIndex]["RESPONSABLE"].ToString();
                foreach (DataRow item in datalogin.Rows)
                {
                    if (item[0].ToString() == dataprograma.Rows[NombrePrograma.SelectedIndex]["USUARIO"].ToString())
                    {
                        UsuarioPrograma.Text = item[1].ToString();
                        break;
                    }
                }
                ClavePrograma.Text = dataprograma.Rows[NombrePrograma.SelectedIndex]["CLAVE"].ToString();
            }
        }
        private void UsuarioLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UsuarioLogin.SelectedIndex > -1)
            {
                NombreUsuarioLogin.Text = datalogin.Rows[UsuarioLogin.SelectedIndex]["NOMBRE"].ToString();
                NivelUsuarioLogin.Value = Convert.ToInt32(datalogin.Rows[UsuarioLogin.SelectedIndex]["NIVEL"].ToString());
            }
        }

        private void Menu1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Show();
        }

        private void UsuarioPrograma_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ResponsablePrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = ResponsablePrograma.SelectedIndex;
            if (i == 0 || i == 1) { DirectorPrograma.SelectedIndex = 0; }
            else if (i == 2 || i == 3) { DirectorPrograma.SelectedIndex = 1; }
            else if (i == 4 || i == 5 || i == 6 || i == 7) { DirectorPrograma.SelectedIndex = 2; }
            else if (i == 8) { DirectorPrograma.SelectedIndex = 3; }
        }

        private void VerPass_MouseDown(object sender, MouseEventArgs e)
        {
            PassLogin.UseSystemPasswordChar = PassLogin.UseSystemPasswordChar == true ? false : true;
        }

        private void VerPass_MouseUp(object sender, MouseEventArgs e)
        {
            PassLogin.UseSystemPasswordChar = PassLogin.UseSystemPasswordChar == true ? false : true;
        }

        private void VerPass2_MouseDown(object sender, MouseEventArgs e)
        {
            RepetirPassLogin.UseSystemPasswordChar = RepetirPassLogin.UseSystemPasswordChar == true ? false : true;
        }

        private void VerPass2_MouseUp(object sender, MouseEventArgs e)
        {
            RepetirPassLogin.UseSystemPasswordChar = RepetirPassLogin.UseSystemPasswordChar == true ? false : true;
        }

        private void ActLogo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Desea regresar al logo anterior?", "Actualizar Logo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Delete(Path.Combine(Application.StartupPath, "Logo2.png"));
                        File.Copy(Path.Combine(Application.StartupPath, "Logo.png"), Path.Combine(Application.StartupPath, "Logo2.png"));
                        File.Delete(Path.Combine(Application.StartupPath, "Logo.png"));
                        File.Copy(openFileDialog1.FileName, Path.Combine(Application.StartupPath, "Logo.png"));
                        MessageBox.Show("Logos cambiados con exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Hubo un problema al cambiar de imagen...\n Cierre el programa y vuelva a intentarlo.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                try
                {
                    File.Copy(Path.Combine(Application.StartupPath, "Logo.png"), Path.Combine(Application.StartupPath, "Logo3.png"));
                    File.Delete(Path.Combine(Application.StartupPath, "Logo.png"));
                    File.Copy(Path.Combine(Application.StartupPath, "Logo2.png"), Path.Combine(Application.StartupPath, "Logo.png"));
                    File.Delete(Path.Combine(Application.StartupPath, "Logo2.png"));
                    File.Copy(Path.Combine(Application.StartupPath, "Logo3.png"), Path.Combine(Application.StartupPath, "Logo2.png"));
                    File.Delete(Path.Combine(Application.StartupPath, "Logo3.png"));
                    MessageBox.Show("Logos cambiados con exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un problema al cambiar de imagen...\n Cierre el programa y vuelva a intentarlo.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ObtenerLogins()
        {
            datalogin = proc.ObtenerLogins();
            UsuarioLogin.DataSource = datalogin;
            UsuarioLogin.DisplayMember = "USERS";
            UsuarioLogin.ValueMember = "USERS";
            UsuarioLogin.SelectedIndex = -1;
            NivelUsuarioLogin.Value = 1;

            UsuarioPrograma.DataSource = datalogin;
            UsuarioPrograma.DisplayMember = "NOMBRE";
            UsuarioPrograma.ValueMember = "USERS";
            UsuarioPrograma.SelectedIndex = -1;
        }
        private void ObtenerProgramas()
        {
            dataprograma = proc.Obtener_Programa();
            NombrePrograma.DataSource = dataprograma;
            NombrePrograma.DisplayMember = "PROGRAMA";
            NombrePrograma.ValueMember = "PROGRAMA";
            NombrePrograma.SelectedIndex = -1;
            ResponsablePrograma.SelectedIndex = -1;
            DirectorPrograma.SelectedIndex = -1;
            UsuarioPrograma.SelectedIndex = -1;
        }
    }
}

