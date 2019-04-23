using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace OrdenamientoPesquero
{
    public partial class Pantalla_Solicitudes : Form
    {
        string Curp, Usuario, NombreUsuario;
        Procedimientos proc = new Procedimientos();
        Solicitud soli; DataTable solicitudes;
        Validaciones val = new Validaciones();
        bool Ap = false, ApTemp = false;
        double mE, mF, mP, ot;
        int NIVEL, exito;

        public Pantalla_Solicitudes(string nombre, string curp, bool ap, string usuario, int nivel, string nombreuser)
        {
            InitializeComponent();
            NombrePesc.Text = nombre;
            Usuario = usuario;
            NombreUsuario = nombreuser;
            Curp = curp;
            Ap = ap;
            NIVEL = nivel;
            CargarLogos();
        }
        private void CargarLogos()
        {
            Logo.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Logo.png"));
        }

        private void Pantalla_Solicitudes_Load(object sender, EventArgs e)
        {
            Bienvenido.Text += NombreUsuario;
            CargarClaves();
            CargarSolicitudes();
            if (Ap)
            {
                solicitud.Enabled = false;
                solicitud.Visible = false;
                Apoyo.Visible = true;
                Apoyo.Enabled = true;
                Entrega.Text = "Regresar";
                Entregar.BackgroundImage = Properties.Resources.x;
                txt.Text = "Apoyos";
                this.Text = "Apoyos";
            }
            else { this.Text = "Solicitudes"; responsable.SelectedIndex = 0; }
            if (NIVEL == 0 || NIVEL == 3)
            {
                gbBotones.Visible = true;
            }
        }

        void CargarSolicitudes()
        {
            if (!Ap)
            {
                if (NIVEL == 0)
                {
                    solicitudes = proc.ObtenerSolicitudes(Curp, "");
                    solicitudes.Merge(proc.ObtenerSolicitudesCN(Curp, ""));
                }
                else
                {
                    solicitudes = null;
                    foreach (DataRowView item in ClavePrograma.Items)
                    {
                        if (solicitudes == null)
                        { solicitudes = (proc.ObtenerSolicitudes(Curp, item[3].ToString())); }
                        else { solicitudes.Merge(proc.ObtenerSolicitudes(Curp, item[3].ToString())); }
                        solicitudes.Merge(proc.ObtenerSolicitudesCN(Curp, item[3].ToString()));
                    }
                }
            }
            else
            {
                if (NIVEL == 0)
                {
                    solicitudes = proc.ObtenerApoyos(Curp, "");
                }
                else
                {
                    solicitudes = null;
                    foreach (DataRowView item in ClavePrograma.Items)
                    {
                        if (solicitudes == null)
                        { solicitudes = (proc.ObtenerApoyos(Curp, item[3].ToString())); }
                        else
                        { solicitudes.Merge(proc.ObtenerApoyos(Curp, item[3].ToString())); }
                    }
                }
            }
            Lista.Items.Clear();
            foreach (DataRow fila in solicitudes.Rows)
            {
                Lista.Items.Add(fila["FOLIO"].ToString());
            }
            DataTable folio = proc.ObtenerMayor();
            if (folio.Rows.Count > 0)
            { FolioMayor.Text = "Folio Mayor: " + folio.Rows[0][0].ToString(); }
        }
        void CargarClaves()
        {
            DataTable pro = proc.ObtenerClaveXUsuario(Usuario, "");
            ClavePrograma.DataSource = pro;
            ClavePrograma.DisplayMember = "CLAVE";
            ClavePrograma.ValueMember = "CLAVE";

            programa.DataSource = pro;
            programa.DisplayMember = "PROGRAMA";
            programa.ValueMember = "PROGRAMA";
            programa.Text = "";

        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            if (!Ap)
            {
                int x = monto.Text[0].ToString() == "$" ? 1 : 0;
                string montocrack = (Convert.ToDouble(monto.Text.Substring(x, monto.Text.Length - x))).ToString();
                soli = new Solicitud(NombrePesc.Text, Curp, folio.Text + "-" + AñoFolio.Value.ToString() + "-" + ClavePrograma.Text, fecha.Text, prioridad.Text, concepto.Text, estatus.Text, montocrack, responsable.Text, director.Text, observaciones.Text);
                exito = proc.Registrar_Solicitud(soli);
                if (exito > 0) { MessageBox.Show("Solicitud ingresada con éxito"); }
                else { MessageBox.Show("Error al ingresar solicitud"); val.Exito(exito); }
            }
            else
            {
                int x = montoE.Text[0].ToString() == "$" ? 1 : 0;
                string montoEcrack = (Convert.ToDouble(montoE.Text.Substring(x, montoE.Text.Length - x))).ToString();
                x = montoF.Text[0].ToString() == "$" ? 1 : 0;
                string montoFcrack = (Convert.ToDouble(montoF.Text.Substring(x, montoF.Text.Length - x))).ToString();
                x = montoP.Text[0].ToString() == "$" ? 1 : 0;
                string montoPcrack = (Convert.ToDouble(montoP.Text.Substring(x, montoP.Text.Length - x))).ToString();
                x = otro.Text[0].ToString() == "$" ? 1 : 0;
                string otrocrack = (Convert.ToDouble(otro.Text.Substring(x, otro.Text.Length - x))).ToString();
                x = Total.Text[0].ToString() == "$" ? 1 : 0;
                string totalcrack = (Convert.ToDouble(Total.Text.Substring(x, Total.Text.Length - x))).ToString();
                soli = new Solicitud(NombrePesc.Text, Curp, folio.Text + "-" + AñoFolio.Value.ToString() + "-" + ClavePrograma.Text, fecha.Text, concepto.Text, observaciones.Text, montoFcrack, montoEcrack, montoPcrack, otrocrack, programa.Text, totalcrack, 1);
                exito = proc.Registrar_Apoyo(soli);
                if (exito > 0) { MessageBox.Show("Apoyo ingresado con éxito"); }
                else { MessageBox.Show("Error al ingresar apoyo"); val.Exito(exito); }
            }
            CargarSolicitudes();
        }

        private void ListaSolicitudes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (DataRow filas in solicitudes.Rows)
            {
                if (Lista.Text == filas["FOLIO"].ToString())
                {
                    if (!Ap)
                    {
                        solicitud.Visible = true;
                        Apoyo.Visible = false;
                        ApTemp = false;
                    }
                    else
                    {
                        solicitud.Visible = false;
                        Apoyo.Visible = true;
                    }
                    string x = filas["FOLIO"].ToString();
                    NombrePesc.Text = filas["NOMBRE"].ToString();
                    folio.Text = "";
                    int i = 0;
                    for (i = 0; x[i] != '-'; i++)
                    {
                        folio.Text += x[i];
                    }
                    i++;
                    string temp = x.Substring(i, 2);
                    AñoFolio.Value = Convert.ToInt32(temp);
                    i = i + 3;
                    if (i < x.Length - 1) { ClavePrograma.Text = x.Substring(i, x.Length - i); }
                    else { ClavePrograma.Text = ""; }
                    fecha.Text = filas["FECHA"].ToString();
                    prioridad.Text = filas["PRIORIDAD"].ToString();
                    concepto.Text = filas["CONCEPTO"].ToString();
                    estatus.Text = filas["ESTATUS"].ToString();
                    monto.Text = "$" + (Convert.ToDouble(filas["MONTO"].ToString().Substring(0, filas["MONTO"].ToString().Length))).ToString("N2");
                    responsable.Text = filas["RESPONSABLE"].ToString();
                    director.Text = filas["DIRECTOR"].ToString();
                    observaciones.Text = filas["OBSERVACIONES"].ToString();
                    montoE.Text = "$" + (Convert.ToDouble(filas["MONTOE"].ToString().Substring(0, filas["MONTOE"].ToString().Length))).ToString("N2");
                    montoF.Text = "$" + (Convert.ToDouble(filas["MONTOF"].ToString().Substring(0, filas["MONTOF"].ToString().Length))).ToString("N2");
                    montoP.Text = "$" + (Convert.ToDouble(filas["MONTOP"].ToString().Substring(0, filas["MONTOP"].ToString().Length))).ToString("N2");
                    otro.Text = "$" + (Convert.ToDouble(filas["MONTOO"].ToString().Substring(0, filas["MONTOO"].ToString().Length))).ToString("N2");
                    programa.Text = filas["PROGRAMA"].ToString();
                }
            }
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            if (!Ap && !ApTemp)
            {
                int x = monto.Text[0].ToString() == "$" ? 1 : 0;
                string montocrack = (Convert.ToDouble(monto.Text.Substring(x, monto.Text.Length - x))).ToString();
                soli = new Solicitud(NombrePesc.Text, Curp, folio.Text + "-" + AñoFolio.Value.ToString() + "-" + ClavePrograma.Text, fecha.Text, prioridad.Text, concepto.Text, estatus.Text, montocrack, responsable.Text, director.Text, observaciones.Text);
                if (proc.Actualizar_Solicitud(soli) > 0) { MessageBox.Show("Solicitud actualizada con éxito"); }
                else { MessageBox.Show("Error al actualizar solicitud"); }
            }
            else
            {
                int x = montoE.Text[0].ToString() == "$" ? 1 : 0;
                string montoEcrack = (Convert.ToDouble(montoE.Text.Substring(x, montoE.Text.Length - x))).ToString();
                x = montoF.Text[0].ToString() == "$" ? 1 : 0;
                string montoFcrack = (Convert.ToDouble(montoF.Text.Substring(x, montoF.Text.Length - x))).ToString();
                x = montoP.Text[0].ToString() == "$" ? 1 : 0;
                string montoPcrack = (Convert.ToDouble(montoP.Text.Substring(x, montoP.Text.Length - x))).ToString();
                x = otro.Text[0].ToString() == "$" ? 1 : 0;
                string otrocrack = (Convert.ToDouble(otro.Text.Substring(x, otro.Text.Length - x))).ToString();
                x = Total.Text[0].ToString() == "$" ? 1 : 0;
                string totalcrack = (Convert.ToDouble(Total.Text.Substring(x, Total.Text.Length - x))).ToString();
                soli = new Solicitud(NombrePesc.Text, Curp, folio.Text + "-" + AñoFolio.Value.ToString() + "-" + ClavePrograma.Text, fecha.Text, concepto.Text, observaciones.Text, montoFcrack, montoEcrack, montoPcrack, otrocrack, programa.Text, totalcrack, 1);
                if (proc.Actualizar_Apoyo(soli) > 0) { MessageBox.Show("Apoyo actualizado con éxito"); }
                else { MessageBox.Show("Error al actualizar apoyo"); }

            }
            CargarSolicitudes();
        }

        private void monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.') { if (monto.Text.Contains('.')) { e.Handled = true; } }
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void ClavePrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            programa.SelectedIndex = ClavePrograma.SelectedIndex;
        }

        private void montoE_Leave(object sender, EventArgs e)
        {
            double numero;
            if (montoE.Text != "")
            {
                int x = montoE.Text[0].ToString() == "$" ? 1 : 0;
                if (montoE.Text != "$")
                { numero = Convert.ToDouble(montoE.Text.Substring(x, montoE.Text.Length - x)); }
                else { numero = 0; }
            }
            else { numero = 0; }
            montoE.Text = "$" + numero.ToString("N2");
        }

        private void montoF_Leave(object sender, EventArgs e)
        {
            double numero;
            if (montoF.Text != "")
            {
                int x = montoF.Text[0].ToString() == "$" ? 1 : 0;
                if (montoF.Text != "$")
                { numero = Convert.ToDouble(montoF.Text.Substring(x, montoF.Text.Length - x)); }
                else { numero = 0; }
            }
            else { numero = 0; }
            montoF.Text = "$" + numero.ToString("N2");
        }

        private void montoP_Leave(object sender, EventArgs e)
        {
            double numero;
            if (montoE.Text != "")
            {
                int x = montoP.Text[0].ToString() == "$" ? 1 : 0;
                if (montoP.Text != "$")
                { numero = Convert.ToDouble(montoP.Text.Substring(x, montoP.Text.Length - x)); }
                else { numero = 0; }
            }
            else { numero = 0; }
            montoP.Text = "$" + numero.ToString("N2");
        }

        private void otro_Leave(object sender, EventArgs e)
        {
            double numero;
            if (otro.Text != "")
            {
                int x = otro.Text[0].ToString() == "$" ? 1 : 0;
                if (otro.Text != "$")
                { numero = Convert.ToDouble(otro.Text.Substring(x, otro.Text.Length - x)); }
                else { numero = 0; }
            }
            else { numero = 0; }
            otro.Text = "$" + numero.ToString("N2");
        }

        private void responsable_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = responsable.SelectedIndex;
            if (i == 0 || i == 1) { director.SelectedIndex = 0; }
            else if (i == 2 || i == 3) { director.SelectedIndex = 1; }
            else if (i == 4 || i == 5 || i == 6 || i == 7) { director.SelectedIndex = 2; }
            else if (i == 8) { director.SelectedIndex = 3; }

            DataTable pro = proc.ObtenerClaveXUsuario(Usuario, responsable.Text);
            ClavePrograma.DataSource = pro;
            ClavePrograma.DisplayMember = "CLAVE";
            ClavePrograma.ValueMember = "CLAVE";
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();
        }

        private void monto_Leave(object sender, EventArgs e)
        {
            double numero;
            if (monto.Text != "")
            {
                int x = monto.Text[0].ToString() == "$" ? 1 : 0;
                if (monto.Text != "$")
                { numero = Convert.ToDouble(monto.Text.Substring(x, monto.Text.Length - x)); }
                else { numero = 0; }
            }
            else { numero = 0; }
            monto.Text = "$" + numero.ToString("N2");
        }

        private void Entregar_Click(object sender, EventArgs e)
        {
            if (!Ap)
            {
                int exito = proc.Entregar_Solicitud(folio.Text + "-" + AñoFolio.Value.ToString() + "-" + ClavePrograma.Text);
                if (exito == 1) { MessageBox.Show("Se ha aprovado la solicitud con exito", "Apoyo registrado.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); solicitud.Visible = false; Apoyo.Visible = true; Apoyo.Enabled = true; ApTemp = true; } else { MessageBox.Show("HUBO UN ERROR"); }
            }
            else
            {
                int exito = proc.RegresarApoyoSoli(folio.Text + "-" + AñoFolio.Value.ToString() + "-" + ClavePrograma.Text);
                if (exito == 1) { MessageBox.Show("Se ha cancelado el apoyo con exito, volvió a ser solicitud", "Apoyo Cancelado.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);  } else { MessageBox.Show("HUBO UN ERROR"); }

            }
            CargarSolicitudes();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if(folio.Text != "")
            {
                DialogResult result = MessageBox.Show("Desea eliminar el registro?", "¿?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if(result == DialogResult.Yes)
                {
                    if (proc.EliminarSoliApo(folio.Text + "-" + AñoFolio.Value.ToString() + "-" + ClavePrograma.Text) > 0) { MessageBox.Show("Registro Eliminado con éxito", "Eliminado"); } 
                    CargarSolicitudes();
                }
            }
        }

        private void montoE_TextChanged(object sender, EventArgs e)
        {
            if (montoE.Text == "") { mE = 0; }
            else
            {
                int x = montoE.Text[0].ToString() == "$" ? 1 : 0;
                double numero = Convert.ToDouble(montoE.Text.Substring(x, montoE.Text.Length - x));
                mE = numero;
            }
            if (montoF.Text == "") { mF = 0; }
            else
            {
                int x = montoF.Text[0].ToString() == "$" ? 1 : 0;
                double numero = Convert.ToDouble(montoF.Text.Substring(x, montoF.Text.Length - x));
                mF = numero;
            }
            if (montoP.Text == "") { mP = 0; }
            else
            {
                int x = montoP.Text[0].ToString() == "$" ? 1 : 0;
                double numero = Convert.ToDouble(montoP.Text.Substring(x, montoP.Text.Length - x));
                mP = numero;
            }
            if (otro.Text == "") { ot = 0; }
            else
            {
                int x = otro.Text[0].ToString() == "$" ? 1 : 0;
                double numero = Convert.ToDouble(otro.Text.Substring(x, otro.Text.Length - x));
                ot = numero;
            }
            string total = "$" + (mE + mF + mP + ot).ToString("N2");
            Total.Text = total;
        }

        private void LimpiarPantalla()
        {
            foreach (TextBox p in this.Controls.OfType<TextBox>())
            {
                p.Text = "";
            }
            foreach (ComboBox p in this.Controls.OfType<ComboBox>())
            {
                p.Text = "";
                if(p.Name == "estatus") { p.Text = "Pendiente"; }
            }
            responsable.SelectedIndex = 0;
        }
    }
}
