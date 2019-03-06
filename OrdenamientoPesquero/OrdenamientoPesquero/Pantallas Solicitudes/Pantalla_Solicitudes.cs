﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace OrdenamientoPesquero
{
    public partial class Pantalla_Solicitudes : Form
    {
        string Curp;
        Procedimientos proc = new Procedimientos();
        Solicitud soli; DataTable solicitudes;
        Validaciones val = new Validaciones();
        bool Ap = false;
        int mE, mF, mP;

        public Pantalla_Solicitudes(string nombre, string curp, bool ap)
        {
            InitializeComponent();
            NombrePesc.Text = nombre;
            Curp = curp;
            Ap = ap;
        }

        private void Pantalla_Solicitudes_Load(object sender, EventArgs e)
        {
            CargarSolicitudes();
            if (Ap)
            {
                Apoyo.Visible = true;
                Entrega.Text = "Regresar";
                Entregar.BackgroundImage = Properties.Resources.x;
                txt.Text = "Apoyos";
            }
        }


        private void Registrar_Click(object sender, EventArgs e)
        {
            if (!Ap)
            {
                soli = new Solicitud(NombrePesc.Text, Curp, folio.Text, fecha.Text, prioridad.Text, concepto.Text, estatus.Text, monto.Text, responsable.Text, director.Text, observaciones.Text);
                if (proc.Registrar_Solicitud(soli) > 0) { MessageBox.Show("Solicitud ingresada con éxito"); }
                else { MessageBox.Show("Error al ingresar solicitud"); }
            }
            else
            {
                soli = new Solicitud(NombrePesc.Text, Curp, folio.Text, fecha.Text, concepto.Text, observaciones.Text, montoF.Text, montoE.Text, montoP.Text, programa.Text, Total.Text,1);
                if (proc.Registrar_Apoyo(soli) > 0) { MessageBox.Show("Apoyo ingresado con éxito"); }
                else { MessageBox.Show("Error al ingresar apoyo"); }
            }
            CargarSolicitudes();
        }

        private void ListaSolicitudes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (DataRow filas in solicitudes.Rows)
            {
                if (Lista.Text == filas["FOLIO"].ToString())
                {
                    folio.Text = filas["FOLIO"].ToString();
                    fecha.Text = filas["FECHA"].ToString();
                    prioridad.Text = filas["PRIORIDAD"].ToString();
                    concepto.Text = filas["CONCEPTO"].ToString();
                    estatus.Text = filas["ESTATUS"].ToString();
                    monto.Text = filas["MONTO"].ToString();
                    responsable.Text = filas["RESPONSABLE"].ToString();
                    director.Text = filas["DIRECTOR"].ToString();
                    observaciones.Text = filas["OBSERVACIONES"].ToString();
                    montoE.Text = filas["MONTOE"].ToString();
                    montoF.Text = filas["MONTOF"].ToString();
                    montoP.Text = filas["MONTOP"].ToString();
                    programa.Text = filas["PROGRAMA"].ToString();
                }
            }
        }

        void CargarSolicitudes()
        {
            if (!Ap)
            { solicitudes = proc.ObtenerSolicitudes(Curp); }
            else { solicitudes = proc.ObtenerApoyos(Curp); }
            Lista.Items.Clear();
            foreach (DataRow fila in solicitudes.Rows)
            {
                Lista.Items.Add(fila["FOLIO"].ToString());
            }
            FolioMayor.Text += proc.ObtenerMayor().Rows[0][0].ToString();
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            if (!Ap)
            {
                soli = new Solicitud(NombrePesc.Text, Curp, folio.Text, fecha.Text, prioridad.Text, concepto.Text, estatus.Text, monto.Text, responsable.Text, director.Text, observaciones.Text);
                if (proc.Actualizar_Solicitud(soli) > 0) { MessageBox.Show("Solicitud actualizada con éxito"); }
                else { MessageBox.Show("Error al actualizar solicitud"); }
            }
            else
            {
                soli = new Solicitud(NombrePesc.Text, Curp, folio.Text, fecha.Text, concepto.Text, observaciones.Text, montoF.Text, montoE.Text, montoP.Text, programa.Text, Total.Text,1);
                if (proc.Actualizar_Apoyo(soli) > 0) { MessageBox.Show("Apoyo actualizado con éxito"); }
                else { MessageBox.Show("Error al actualizar apoyo"); }

            }
            CargarSolicitudes();
        }

        private void monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }


        private void Entregar_Click(object sender, EventArgs e)
        {
            if (!Ap)
            {
                int exito = proc.Entregar_Solicitud(folio.Text);
                if (exito == 1) { MessageBox.Show("Se ha aprovado la solicitud con exito", "Apoyo registrado.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); } else { MessageBox.Show("HUBO UN ERROR"); }
            }
            else
            {
                int exito = proc.RegresarApoyoSoli(folio.Text);
                if (exito == 1) { MessageBox.Show("Se ha cancelado el apoyo con exito, volvió a ser solicitud", "Apoyo Cancelado.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); } else { MessageBox.Show("HUBO UN ERROR"); }

            }
            CargarSolicitudes();
            LimpiarPantalla();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if(folio.Text != "")
            {
                DialogResult result = MessageBox.Show("Desea eliminar el registro?", "¿?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if(result == DialogResult.Yes)
                {
                    if (proc.EliminarSoliApo(folio.Text) > 0) { MessageBox.Show("Registro Eliminado con éxito", "Eliminado"); } 
                    CargarSolicitudes();
                }
            }
        }

        private void montoE_TextChanged(object sender, EventArgs e)
        {
            if (montoE.Text == "") { mE = 0; } else { mE = Convert.ToInt32(montoE.Text); }
            if (montoF.Text == "") { mF = 0; } else { mF = Convert.ToInt32(montoF.Text); }
            if (montoP.Text == "") { mP = 0; } else { mP = Convert.ToInt32(montoP.Text); }

            Total.Text = (mE + mF + mP).ToString();
        }

        private void LimpiarPantalla()
        {
            foreach (TextBox p in this.Controls.OfType<TextBox>())
            {
                p.Text = "";
            }
        }
    }
}
