﻿using Logica;
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
        public Pantalla_Regitro_permiso(string rnpa, string muni)
        {
            InitializeComponent();
            Rnpa = rnpa;
            Municipio = muni;
        }
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
            dt = proc.ObtenerCertMatrXUnidad(Rnpa);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Matricula.Items.Add(dt.Rows[i]["MATRICULA"].ToString());
                Nombre.Items.Add(dt.Rows[i]["NOMBREEMBARCACION"].ToString());
            }
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
            if (nPer.Text != "")
            {
                dt = proc.ObtenerPermiso(Convert.ToInt32(nPer.Text));
                limpiarpermiso();
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
                    dt = proc.NumeroEmbarcaciones(Convert.ToInt32(nPer.Text));
                    numericUpDown1.Value = dt.Rows.Count;
                    dt = proc.EmbarcacionesxPermiso(Convert.ToInt32(nPer.Text));
                    dgvEmbarcacionesPerm.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvEmbarcacionesPerm.RowCount = dt.Rows.Count;
                        Matricula.Items.Add(dt.Rows[i]["MATRICULA"].ToString());
                        Marcamotor.Items.Add(dt.Rows[i]["MOTORMARCA"].ToString());
                        dgvEmbarcacionesPerm[0, i].Value = dt.Rows[i]["NOMBREEMBARCACION"].ToString();
                        dgvEmbarcacionesPerm[1, i].Value = dt.Rows[i]["MATRICULA"].ToString();
                        dgvEmbarcacionesPerm[2, i].Value = dt.Rows[i]["MOTORMARCA"].ToString();
                        dgvEmbarcacionesPerm[3, i].Value = dt.Rows[i]["MOTORHP"].ToString();

                    }
                    dt = proc.EquiposxPermiso(Convert.ToInt32(nPer.Text));
                    numericUpDown2.Value = dt.Rows.Count;
                    dgvEquiposPescaPerm.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Tipo.Items.Add(dt.Rows[i]["TIPO"].ToString());
                        dgvEquiposPescaPerm[0, i].Value = dt.Rows[i]["CANTIDAD"].ToString();
                        dgvEquiposPescaPerm[1, i].Value = dt.Rows[i]["TIPO"].ToString();
                        dgvEquiposPescaPerm[2, i].Value = dt.Rows[i]["CARACTERISTICAS"].ToString();
                    }

                }
            }
        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            exito = AccionesPermiso(true);
            proc.Borrar_equipo(nPer.Text);
            equiposdepesca();
            if (exito == 1)
            {
                for (int i = 0; i < dgvEmbarcacionesPerm.RowCount; i++)
                {
                    if (dgvEmbarcacionesPerm[0, i].Value != null)
                    {
                        Emb = new Embarcacion(dgvEmbarcacionesPerm[0, i].Value.ToString(), dgvEmbarcacionesPerm[1, i].Value.ToString(), dgvEmbarcacionesPerm[3, i].Value.ToString(), dgvEmbarcacionesPerm[2, i].Value.ToString(), Municipio, Rnpa);
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
            DataGridView dgv = (DataGridView)sender;
            ComboBox cbx = (ComboBox)e.Control;
            if (dgv.CurrentCell.ColumnIndex == dgv.Columns["Nombre"].Index || dgv.CurrentCell.ColumnIndex == dgv.Columns["Matricula"].Index || dgv.CurrentCell.ColumnIndex == dgv.Columns["Marcamotor"].Index)
            {
                cbx.DropDownStyle = ComboBoxStyle.DropDown;
                cbx.AutoCompleteSource = AutoCompleteSource.ListItems;
                cbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                cbx.Validating += new CancelEventHandler(cbx_Validating);
            }
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

        }

        private void dgvEmbarcacionesPerm_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmbarcacionesPerm.Columns[e.ColumnIndex].Name == "Nombre")
            {
                DataGridViewComboBoxCell combo = dgvEmbarcacionesPerm.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                int x = Convert.ToInt32(combo.RowIndex);

                //DataGridViewComboBoxEditingControl cbx = sender as DataGridViewComboBoxEditingControl;

                //DataGridView grid = cbx.EditingControlDataGridView;
                //DataGridViewComboBoxCell cboCol = (DataGridViewComboBoxCell)grid[1, e.RowIndex];
                //cboCol.Value = x;
                //DataGridViewComboBoxEditingControl cbx = sender as DataGridViewComboBoxEditingControl;

                //dgvEmbarcacionesPerm.Rows[e.RowIndex].Cells[1]. = x;
            }
        }

        private void dgvEmbarcacionesPerm_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }
    }
}
