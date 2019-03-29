using Logica;
using OrdenamientoPesquero.Pantallas_Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenamientoPesquero
{
    public partial class Pantalla_Regitro_permiso : Form
    {
        Validaciones val = new Validaciones();
        Scanner scan;
        string uni, Rnpa, Municipio;
        Permiso perm;
        Embarcacion Emb;
        int exito = 0, NIVEL = 0;
        Procedimientos proc = new Procedimientos();
        DataSet ds = new DataSet();
        DataTable dt = null, permisos = null;

        public Pantalla_Regitro_permiso(string rnpa, string muni, string unidad, int nivel)
        {
            InitializeComponent();
            //this.Height = Convert.ToInt32(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height * .96);
            this.Width = 1308;
            Rnpa = rnpa;
            Municipio = muni;
            uni = unidad;
            NIVEL = nivel;
        }
        private void Pantalla_Regitro_permiso_Load(object sender, EventArgs e)
        {
            CargarPermisos();
            Unid.Text = uni;
            dt = proc.ObtenerCertMatrXUnidad(Rnpa);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["NOMBREEMBARCACION"].ToString() != "NO APLICA")
                    Nombre.Items.Add(dt.Rows[i]["NOMBREEMBARCACION"].ToString());
                else { dt.Rows.RemoveAt(i); i--; }
            }
            CargarPesquerias();
            dgvArchivos.RowCount = 1;
            dgvArchivos[0, 0].Value = "Permiso Escaneado";
            if (NIVEL == 0 || NIVEL == 4)
            {
                gbDatos.Enabled = true;
                gbBotones.Visible = true;
                limpiar.Visible = true;
                SubirPDF.Visible = true;
                label35.Visible = true;
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
            dgvEmbarcacionesPerm[1, row.Index].Value = dt.Rows[combo.SelectedIndex]["MATRICULA"].ToString();
            dgvEmbarcacionesPerm[2, row.Index].Value = dt.Rows[combo.SelectedIndex]["MOTORMARCA"].ToString();
            dgvEmbarcacionesPerm[3, row.Index].Value = dt.Rows[combo.SelectedIndex]["MOTORHP"].ToString();
            dgvEmbarcacionesPerm[0, row.Index].Value = dt.Rows[combo.SelectedIndex]["NOMBREEMBARCACION"].ToString();
        }
        private void CargarPermisos()
        {
            permisos = proc.ObtenerNoPermisos(Rnpa);
            ListaPermisos.DataSource = permisos;
            ListaPermisos.ValueMember = "NPERMISO";
            ListaPermisos.DisplayMember = "PESQUERIA";
        }

        private void CargarPesquerias()
        {
            DataTable pesq = new DataTable();
            pesq = proc.ObtenerPesquerias();
            foreach (DataRow item in pesq.Rows)
            {
                PesqueriaPer.Items.Add(item["PESQUERIA"].ToString());
            }
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
            foreach (TextBox item in gbDatos.Controls.OfType<TextBox>())
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
            foreach (ComboBox item in gbDatos.Controls.OfType<ComboBox>())
            {
                item.Text = "";
            }
            numericUpDown1.Value = numericUpDown2.Value = 0;
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
            int tipoperm = 0;
            if (Acuicola.Checked == true) { tipoperm = 1; }
            else if (Deportiva.Checked == true) { tipoperm = 2; }
            perm = new Permiso(FolioPer.Text, Rnpa, nPer.Text, PesqueriaPer.Text, LugarExpPer.Text, diaExp, finVig, ZonaPescaPerm.Text, SitiosDesemPer.Text,tipoperm);
            if (registrar)
            { return proc.Registrar_Permiso(perm); }
            else { return proc.Actualizar_Permiso(perm); }
        }
        public void todosconguion()
        {
            dt = proc.p();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                nPer.Text = dt.Rows[i]["NPERMISO"].ToString();
                FolioPer.Text = dt.Rows[i]["FOLIO"].ToString();
                PesqueriaPer.Text = dt.Rows[i]["PESQUERIA"].ToString();
                LugarExpPer.Text = dt.Rows[i]["LUGAREXPEDICION"].ToString();
                diaExpPer.Text = dt.Rows[i]["DIAEXPEDICION"].ToString();
                finVigenciaPer.Text = dt.Rows[i]["FINVIGENCIA"].ToString();
                ZonaPescaPerm.Text = dt.Rows[i]["ZONAPESCA"].ToString();
                SitiosDesemPer.Text = dt.Rows[i]["SITIOSDESEMBARQUE"].ToString();
                string[] Hoy = diaExpPer.Value.ToShortDateString().Split('/');
                string diaExp = "";
                int C = 2;
                while (C >= 0)
                {
                    diaExp += Hoy[C];
                    if (C > 0) { diaExp += "/"; }
                    C--;
                }
                string[] Hasta = finVigenciaPer.Value.ToShortDateString().Split('/');
                string finVig = "";
                C = 2;
                while (C >= 0)
                {
                    finVig += Hasta[C];
                    if (C > 0) { finVig += "/"; }
                    C--;
                }

                perm = new Permiso(FolioPer.Text, dt.Rows[i]["RNPA"].ToString(), nPer.Text, PesqueriaPer.Text, LugarExpPer.Text, diaExp, finVig, ZonaPescaPerm.Text, SitiosDesemPer.Text, 0);
                
                proc.Actualizar_Permiso(perm);
            }
        }
        private void pictureBox13_Click_1(object sender, EventArgs e)
        {
            
        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            exito = AccionesPermiso(true);
            bool pesqueriacorrecta = true;
            if (exito > 0)
            {
                if (!PesqueriaPer.Items.Contains(PesqueriaPer.Text))
                {
                    pesqueriacorrecta = false;
                    DialogResult result = MessageBox.Show("La pesquería no existe... Desea agregarla como nueva?", "NO EXISTE LA PESQUERÍA", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        proc.RegistrarPesqueria(PesqueriaPer.Text);
                        pesqueriacorrecta = true;
                    }
                    else { MessageBox.Show("La pesquería no existe y ha decidido no agregarla"); }
                }
                if (pesqueriacorrecta)
                {
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
                                Emb = new Embarcacion(a, b, c, d, Municipio, Rnpa);
                                exito += proc.registrar_perm_emb(Emb, nPer.Text);
                            }
                        }
                    }
                }
            }
            val.Exito(exito);
            CargarPermisos();
            CargarPesquerias();
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            bool pesqueriacorrecta = true;
            if (!PesqueriaPer.Items.Contains(PesqueriaPer.Text))
            {
                pesqueriacorrecta = false;
                DialogResult result = MessageBox.Show("La pesquería no existe... Desea agregarla como nueva?", "NO EXISTE LA PESQUERÍA", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    proc.RegistrarPesqueria(PesqueriaPer.Text);
                    pesqueriacorrecta = true;
                }
            }
            if (pesqueriacorrecta)
            {
                exito = AccionesPermiso(false);
                proc.Borrar_equipo(nPer.Text);
                equiposdepesca();
                proc.EliminarRelac(nPer.Text);
                int exitosembarcaciones = 0;
                for (int i = 0; i < dgvEmbarcacionesPerm.RowCount; i++)
                {
                    if (dgvEmbarcacionesPerm[0, i].Value != null)
                    {
                        Emb = new Embarcacion(dgvEmbarcacionesPerm[0, i].Value.ToString(), dgvEmbarcacionesPerm[1, i].Value.ToString(), dgvEmbarcacionesPerm[3, i].Value.ToString(), dgvEmbarcacionesPerm[2, i].Value.ToString(), Municipio, Rnpa);
                        exitosembarcaciones += proc.registrar_perm_emb(Emb, nPer.Text);
                    }
                }
                val.Exito(exito);
                if (exitosembarcaciones == dgvEmbarcacionesPerm.RowCount) { val.Exito(-31); } else { val.Exito(-32); }
                CargarPesquerias();
            }
            else { MessageBox.Show("La pesquería no existe y ha decidido no agregarla"); }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            DialogResult Si = MessageBox.Show("¿Desea eliminar este Permiso?", "ADVERTENCIA", MessageBoxButtons.YesNo);
            if (Si == DialogResult.Yes)
            {
                exito = proc.Eliminar_Permiso(nPer.Text);
                if(exito > 0)
                {
                    MessageBox.Show("Permiso Eliminado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                limpiarpermiso();
                CargarPermisos();
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

        private void nPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                pictureBox13_Click_1(sender, e);
            }
        }

        private void ListaPermisos_DoubleClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (ListaPermisos.SelectedIndex > -1)
            {
                string per = ListaPermisos.SelectedValue.ToString();
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
                    string tp = dt.Rows[0]["TIPOPERMISO"].ToString();
                    int tipoperm = 0;
                    if (tp != "") { tipoperm = Convert.ToInt32(tp); }
                    if (tipoperm == 1) { Acuicola.Checked = true; } else if (tipoperm == 2) { Deportiva.Checked = true; } else { Comercial.Checked = true; }
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
                        // Nombre.Items.Add(dt.Rows[i]["NOMBREEMBARCACION"].ToString());
                        dgvEmbarcacionesPerm[0, i].Value = dt.Rows[i]["NOMBREEMBARCACION"].ToString();
                        dgvEmbarcacionesPerm[1, i].Value = dt.Rows[i]["MATRICULA"].ToString();
                        dgvEmbarcacionesPerm[2, i].Value = dt.Rows[i]["MOTORMARCA"].ToString();
                        dgvEmbarcacionesPerm[3, i].Value = dt.Rows[i]["MOTORHP"].ToString();

                    }
                }
            }
            dt = proc.ObtenerCertMatrXUnidad(Rnpa);
            CargarExpediente();
            dgvArchivos.ClearSelection();
            this.Cursor = Cursors.Default;
        }
        private void CargarExpediente()
        {
            string per = ListaPermisos.SelectedValue.ToString(); 
            DataTable exp = proc.ObtenerPermiso(per);
            if (exp.Rows[0]["APERMISO"].ToString() != "") { dgvArchivos[1, 0].Value = true; dgvArchivos[1, 0].Style.BackColor = Color.Green; }
            else { dgvArchivos[1, 0].Value = false; dgvArchivos[1, 0].Style.BackColor = Color.Red   ; }

        }

        private void SubirPDF_Click(object sender, EventArgs e)
        {
            if (dgvArchivos.CurrentCell.Selected != false)
            {
                DialogResult result = MessageBox.Show("Desea escanear un nuevo documento?", "¿?", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    scan = new Scanner(true);
                    if (scan.oDevice != null)
                    {
                        openFileDialog1.FileName = scan.Scann(0);
                        Stream myStream = openFileDialog1.OpenFile();
                        MemoryStream pdf = new MemoryStream();
                        myStream.CopyTo(pdf);
                        exito = proc.InsertarPDFPermiso(nPer.Text, pdf.GetBuffer());
                        val.Exito(exito);
                        CargarExpediente();
                    }
                    this.Cursor = Cursors.Default;
                }
                else if (result == DialogResult.No)
                {
                    result = MessageBox.Show("Desea subir un archivo desde su computadora?", "¿?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        openFileDialog1.InitialDirectory = "C:\\";
                        openFileDialog1.Filter = "Todos los archivos (*.*)|*.*";
                        openFileDialog1.FilterIndex = 1;
                        openFileDialog1.RestoreDirectory = true;

                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            Stream myStream = openFileDialog1.OpenFile();

                            MemoryStream pdf = new MemoryStream();
                            myStream.CopyTo(pdf);

                            string n = openFileDialog1.FileName;
                            string x = n[n.Length - 4].ToString() + n[n.Length - 3].ToString() + n[n.Length - 2].ToString() + n[n.Length - 1].ToString();
                            if (x != ".pdf")
                            {
                                scan = new Scanner(false);
                                openFileDialog1.FileName = scan.ConvertToPDF(pdf);
                                myStream = openFileDialog1.OpenFile();
                                pdf = new MemoryStream();
                                myStream.CopyTo(pdf);
                            }

                            exito = proc.InsertarPDFPermiso(nPer.Text, pdf.GetBuffer());
                            val.Exito(exito);
                        }
                        CargarExpediente();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            else { MessageBox.Show("Debe seleccionar la fila correspondiente al archivo que desea subir", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void AbrirPDF_Click(object sender, EventArgs e)
        {
            if (dgvArchivos.CurrentCell.Selected != false)
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable oDocument = proc.ObtenerPermiso(nPer.Text);
                if (oDocument.Rows.Count > 0)
                {
                    if (oDocument.Rows[0]["APERMISO"].ToString() != "")
                    {
                        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        string folder = path + "/PDF/";
                        string fullFilePath = folder + nPer.Text + "-APERMISO.pdf";


                        if (!Directory.Exists(folder)) { try { Directory.CreateDirectory(folder); } catch (Exception ms) { } }

                        if (File.Exists(fullFilePath)) { try { Directory.Delete(fullFilePath); } catch (Exception ms) { } }


                        byte[] file = (byte[])oDocument.Rows[0]["APERMISO"];
                        File.WriteAllBytes(fullFilePath, file);
                        Process.Start(fullFilePath);
                    }
                }

                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Debe seleccionar la fila correspondiente al archivo que desea visualizar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }



}
