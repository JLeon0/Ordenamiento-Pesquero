﻿using Logica;
using OrdenamientoPesquero.Pantallas_Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenamientoPesquero
{
    public partial class Pantalla_Regitro_permiso : Form
    {
        Validaciones val = new Validaciones();
        public Pantalla_Regitro_permiso(string rnpa, string muni, string unidad)
        {
            InitializeComponent();
            Rnpa = rnpa;
            Municipio = muni;
            uni = unidad;
        }
        string uni;
        string Rnpa;
        string Municipio;
        Permiso perm;
        Embarcacion Emb;
        int exito = 0;
        Procedimientos proc = new Procedimientos();
        DataSet ds = new DataSet();
        DataTable dt = null;
        private void Pantalla_Regitro_permiso_Load(object sender, EventArgs e)
        {
            CargarRNPA();
            Unid.Text = uni;
            dt = proc.ObtenerCertMatrXUnidad(Rnpa);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Nombre.Items.Add(dt.Rows[i]["NOMBREEMBARCACION"].ToString());
            }
        }
        private void dvgCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            // se recupera el valor del combo
            // a modo de ejemplo se escribe en consola el valor seleccionado
            //
            ComboBox combo = sender as ComboBox;
            //
            // se accede a la fila actual, para trabajr con otor de sus campos
            // en este caso se marca el check si se cambia la seleccion
            //
            DataGridViewRow row = dgvEmbarcacionesPerm.CurrentRow;
            dgvEmbarcacionesPerm[1,row.Index].Value=dt.Rows[combo.SelectedIndex]["MATRICULA"].ToString();
            dgvEmbarcacionesPerm[2, row.Index].Value = dt.Rows[combo.SelectedIndex]["MOTORMARCA"].ToString();
            dgvEmbarcacionesPerm[3, row.Index].Value = dt.Rows[combo.SelectedIndex]["MOTORHP"].ToString();
        }
        private void CargarRNPA()
        {
            string a = nPer.Text;
            dt = proc.ObtenerNoPermisos(Rnpa);
            nPer.DataSource = dt;
            nPer.DisplayMember = "NPERMISO";
            nPer.ValueMember = "NPERMISO";
            nPer.Text = a;
        }
        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void diaExpPer_ValueChanged(object sender, EventArgs e)
        {
            VigenciaPerm.Text = val.DiferenciaFechas(finVigenciaPer.Value, diaExpPer.Value);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dgvEmbarcacionesPerm.RowCount = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            dgvEquiposPescaPerm.RowCount = (int)numericUpDown2.Value;
        }
        public void limpiarpermiso()
        {
            foreach (TextBox item in this.Controls.OfType<TextBox>())
            {
                item.Text = "";
            }
            foreach (TextBox item in groupBox3.Controls.OfType<TextBox>())
            {
                item.Text = "";
            }
            foreach (MaskedTextBox item in this.Controls.OfType<MaskedTextBox>())
            {
                item.Text = "";
            }
            foreach (DataGridView item in this.Controls.OfType<DataGridView>())
            {
                item.RowCount = 0;
            }
            foreach (ComboBox item in this.Controls.OfType<ComboBox>())
            {
                item.Text = "";
            }
            foreach (ComboBox item in groupBox3.Controls.OfType<ComboBox>())
            {
                item.Text = "";
            }
        }

        public void equiposdepesca()
        {
            for (int i = 0; i < dgvEquiposPescaPerm.RowCount; i++)
            {
                proc.Registrar_Equipo(nPer.Text, dgvEquiposPescaPerm[0, i].Value.ToString(), dgvEquiposPescaPerm[1, i].Value.ToString(), dgvEquiposPescaPerm[2, i].Value.ToString());
            }
        }
        public int AccionesPermiso(bool registrar)
        {
            string[] Hoy = diaExpPer.Value.ToShortDateString().Split('/');
            string diaExp = "";
            int i = 2;
            while (i >= 0)
            {
                diaExp += Hoy[i];
                if (i > 0) { diaExp += "/"; }
                i--;
            }
            string[] Hasta = finVigenciaPer.Value.ToShortDateString().Split('/');
            string finVig = "";
            i = 2;
            while (i >= 0)
            {
                finVig += Hasta[i];
                if (i > 0) { finVig += "/"; }
                i--;
            }
            perm = new Permiso(FolioPer.Text, Rnpa, nPer.Text, PesqueriaPer.Text, LugarExpPer.Text, diaExp, finVig, ZonaPescaPerm.Text, SitiosDesemPer.Text, ObservacionesPem.Text);
            if (registrar)
            { return proc.Registrar_Permiso(perm); }
            else { return proc.Actualizar_Permiso(perm); }
        }
        private void pictureBox13_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (nPer.Text != "")
            {
                string per = nPer.Text;
                dt = proc.ObtenerPermiso(per);
                limpiarpermiso();
                nPer.Text = per;
                if (dt.Rows.Count != 0)
                {
                    FolioPer.Text = dt.Rows[0]["FOLIO"].ToString();
                    PesqueriaPer.Text = dt.Rows[0]["PESQUERIA"].ToString();
                    LugarExpPer.Text = dt.Rows[0]["LUGAREXPEDICION"].ToString();
                    diaExpPer.Text = dt.Rows[0]["DIAEXPEDICION"].ToString();
                    finVigenciaPer.Text = dt.Rows[0]["FINVIGENCIA"].ToString();
                    ZonaPescaPerm.Text = dt.Rows[0]["ZONAPESCA"].ToString();
                    SitiosDesemPer.Text = dt.Rows[0]["SITIOSDESEMBARQUE"].ToString();
                    ObservacionesPem.Text = dt.Rows[0]["OBSERVACIONES"].ToString();
                    dt = proc.EquiposxPermiso(per);
                    numericUpDown2.Value = dt.Rows.Count;
                    dgvEquiposPescaPerm.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Tipo.Items.Add(dt.Rows[i]["TIPO"].ToString());
                        dgvEquiposPescaPerm[0, i].Value = dt.Rows[i]["CANTIDAD"].ToString();
                        dgvEquiposPescaPerm[1, i].Value = dt.Rows[i]["TIPO"].ToString();
                        dgvEquiposPescaPerm[2, i].Value = dt.Rows[i]["CARACTERISTICAS"].ToString();
                    }
                    dt = proc.NumeroEmbarcaciones(per);
                    numericUpDown1.Value = dt.Rows.Count;
                    dt = proc.EmbarcacionesxPermiso(per);
                    dgvEmbarcacionesPerm.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvEmbarcacionesPerm.RowCount = dt.Rows.Count;
                        Nombre.Items.Add(dt.Rows[i]["NOMBREEMBARCACION"].ToString());
                        dgvEmbarcacionesPerm[0, i].Value = dt.Rows[i]["NOMBREEMBARCACION"].ToString();
                        dgvEmbarcacionesPerm[1, i].Value = dt.Rows[i]["MATRICULA"].ToString();
                        dgvEmbarcacionesPerm[2, i].Value = dt.Rows[i]["MOTORMARCA"].ToString();
                        dgvEmbarcacionesPerm[3, i].Value = dt.Rows[i]["MOTORHP"].ToString();

                    }

                }
            }
            this.Cursor = Cursors.Default;
        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            exito = AccionesPermiso(true);
            string a = "";
            string b = "";
            string c = "";
            string d = "";
            proc.Borrar_equipo(nPer.Text);
            equiposdepesca();
            if (exito == 1)
            {
                for (int i = 0; i < dgvEmbarcacionesPerm.RowCount; i++)
                {
                    if (dgvEmbarcacionesPerm[0, i].Value != null)
                    {
                        a = dgvEmbarcacionesPerm[0, i].Value.ToString();
                        b = dgvEmbarcacionesPerm[1, i].Value.ToString();
                        c = dgvEmbarcacionesPerm[3, i].Value.ToString();
                        d = dgvEmbarcacionesPerm[2, i].Value.ToString();
                        Emb = new Embarcacion(a,b,c,d, Municipio,Rnpa);
                        exito += proc.registrar_perm_emb(Emb, nPer.Text);
                    }
                }
            }
            val.Exito(exito);
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            exito = AccionesPermiso(false);
            proc.Borrar_equipo(nPer.Text);
            equiposdepesca();
            for (int i = 0; i < dgvEmbarcacionesPerm.RowCount; i++)
            {
                if (dgvEmbarcacionesPerm[0, i].Value != null)
                {
                    Emb = new Embarcacion(dgvEmbarcacionesPerm[0, i].Value.ToString(), dgvEmbarcacionesPerm[1, i].Value.ToString(), dgvEmbarcacionesPerm[3, i].Value.ToString(), dgvEmbarcacionesPerm[2, i].Value.ToString(), Municipio, Rnpa);
                    exito += proc.registrar_perm_emb(Emb, nPer.Text);
                }
            }
            val.Exito(exito);
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            DialogResult Si = MessageBox.Show("¿Desea eliminar este Permiso?", "ADVERTENCIA", MessageBoxButtons.YesNo);
            if (Si == DialogResult.Yes)
            {
                exito = proc.Eliminar_Permiso(nPer.Text);
                limpiarpermiso();
            }
        }

        //Escribir en data----------------------------------------------------------------------------
        private void datagridview1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.CurrentCell.ColumnIndex == dgv.Columns["Tipo"].Index)
            {
                ComboBox cbx = (ComboBox)e.Control;
                cbx.DropDownStyle = ComboBoxStyle.DropDown;
                cbx.AutoCompleteSource = AutoCompleteSource.ListItems;
                cbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                cbx.Validating += new CancelEventHandler(cbx_Validating);
            }
        }

        private void datagridview_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        void cbx_Validating(object sender, CancelEventArgs e)
        {

            DataGridViewComboBoxEditingControl cbx = sender as DataGridViewComboBoxEditingControl;

            DataGridView grid = cbx.EditingControlDataGridView;

            object value = cbx.Text;

            // Add value to list if not there

            if (cbx.Items.IndexOf(value) == -1)
            {
                DataGridViewComboBoxCell cboCol = (DataGridViewComboBoxCell)grid.CurrentCell;

                // Must add to both the current combobox as well as the template, to avoid duplicate entries...

                cbx.Items.Add(value);

                cboCol.Items.Add(value);

                grid.CurrentCell.Value = value;
            }
            else
            {
                //cbx.SelectedIndex = 
            }
        } //-----------------------------------------------------------------------------------------

        private void Ver_Click(object sender, EventArgs e)
        {
            Vistas v = new Vistas(Rnpa, uni, 2);
            v.ShowDialog(this);
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            limpiarpermiso();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
             DataGridViewComboBoxEditingControl dgvCombo = e.Control as DataGridViewComboBoxEditingControl;

            if (dgvCombo != null)
            {
                //
                // se remueve el handler previo que pudiera tener asociado, a causa ediciones previas de la celda
                // evitando asi que se ejecuten varias veces el evento
                //
                dgvCombo.SelectedIndexChanged -= new EventHandler(dvgCombo_SelectedIndexChanged);

                dgvCombo.SelectedIndexChanged += new EventHandler(dvgCombo_SelectedIndexChanged);
            }
        }
    }



}
