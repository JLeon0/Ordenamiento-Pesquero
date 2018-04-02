using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace OrdenamientoPesquero
{
    public partial class Pantalla_Registro_UnidadEconomica : Form
    {
        bool cargado = false;
        bool escondido = false;
        Unidad_Economica ue;
        Permiso perm;
        Pescador pes;
        Embarcacion Emb;
        Directiva dir;
        int exito = 0;
        Procedimientos proc = new Procedimientos();
        DataSet ds = new DataSet();
        DataTable dt = null;
        string[,] unidad = { { "0", "RFC" }, { "0", "Codigo Postal" }, { "0", "Correo Electronico" }, { "0", "Telefono de la Cooperativa" },{"0","RNPA" } };
        string[,] pescador = { { "0", "CURP" }, { "0", "RFC" }, { "0", "Codigo postal" }, { "0", "Telefono" } , { "0","Correo Electronico"} };
        public Pantalla_Registro_UnidadEconomica()
        {
            InitializeComponent();
            this.Height = Convert.ToInt32(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height * .96);
            this.Width = Convert.ToInt32(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width);

        }

        private void Pantalla_Registro_UnidadEconomica_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            cbRNPA.Focus();
            PintarGroupBox();
            CargarRNPA();
        }
        


        private void pBReubicar_Click(object sender, EventArgs e)
        {
            if (!escondido)
            {
                gbOrgPes.Height -= 312;
                Resumen.Height -= 300;
                pBReubicar.Location = new Point(pBReubicar.Location.X, pBReubicar.Location.Y - 300);
                tabControl1.Location = new Point(tabControl1.Location.X, tabControl1.Location.Y - 300);
                ActualizarUnidad.Location = new Point(ActualizarUnidad.Location.X, ActualizarUnidad.Location.Y - 300);
                EliminarUnidad.Location = new Point(EliminarUnidad.Location.X, EliminarUnidad.Location.Y - 300);
                RegistrarUnidad.Location = new Point(RegistrarUnidad.Location.X, RegistrarUnidad.Location.Y - 300);
                label65.Location = new Point(label65.Location.X + 200, label65.Location.Y - 190);
                TotalPesquerias.Location = new Point(TotalPesquerias.Location.X + 200, TotalPesquerias.Location.Y - 190);
                escondido = true;
                pBReubicar.BackgroundImage = Properties.Resources.flechaabajo;
                toolTip1.SetToolTip(pBReubicar, "Mostrar Información");
                Registrar.Location = new Point(Registrar.Location.X, Registrar.Location.Y - 300);
                Actualizar.Location = new Point(Actualizar.Location.X, Actualizar.Location.Y - 300);
                Ver.Location = new Point(Ver.Location.X, Ver.Location.Y - 300);
                Eliminar.Location = new Point(Eliminar.Location.X, Eliminar.Location.Y - 300);
            }
            else
            {
                gbOrgPes.Height += 312;
                Resumen.Height += 300;
                pBReubicar.Location = new Point(pBReubicar.Location.X, pBReubicar.Location.Y + 300);
                tabControl1.Location = new Point(tabControl1.Location.X, tabControl1.Location.Y + 300);
                ActualizarUnidad.Location = new Point(ActualizarUnidad.Location.X, ActualizarUnidad.Location.Y + 300);
                EliminarUnidad.Location = new Point(EliminarUnidad.Location.X, EliminarUnidad.Location.Y + 300);
                RegistrarUnidad.Location = new Point(RegistrarUnidad.Location.X, RegistrarUnidad.Location.Y + 300);
                label65.Location = new Point(label65.Location.X - 200, label65.Location.Y + 190);
                TotalPesquerias.Location = new Point(TotalPesquerias.Location.X - 200, TotalPesquerias.Location.Y + 190);
                escondido = false;
                pBReubicar.BackgroundImage = Properties.Resources.flechaarriba;
                toolTip1.SetToolTip(pBReubicar, "Esconder Información");
                Registrar.Location = new Point(Registrar.Location.X, Registrar.Location.Y + 300);
                Actualizar.Location = new Point(Actualizar.Location.X, Actualizar.Location.Y + 300);
                Ver.Location = new Point(Ver.Location.X, Ver.Location.Y + 300);
                Eliminar.Location = new Point(Eliminar.Location.X, Eliminar.Location.Y + 300);
            }
        }

     

        #region Registros
        private void RegistrarUnidad_Click(object sender, EventArgs e)
        {
            if (validaralgo(unidad))
            {
                if (!existe(cbRNPA.Text))
                {
                    if (!cargado)
                    {
                        if (radioButton0.Checked)
                        {
                            ue = new Unidad_Economica(cbRNPA.Text, txtNombre.Text, "0", txtCalleNum.Text, txtRFC.Text, txtColonia.Text, txtLocalidad.Text, txtMunicipio.Text, mtbCP.Text, txtCorreo.Text, mtbTelefono.Text);
                            exito = proc.Registrar_Unidad(ue);
                        }
                        else if (radioButton1.Checked)
                        {
                            ue = new Unidad_Economica(cbRNPA.Text, txtNombre.Text, "1", txtCalleNum.Text, txtRFC.Text, txtColonia.Text, txtLocalidad.Text, txtMunicipio.Text, mtbCP.Text, txtCorreo.Text, mtbTelefono.Text);
                            exito = proc.Registrar_Unidad(ue);
                        }
                        if (exito != 0)
                        {
                            tabControl1.Enabled = true;
                        }
                        CargarRNPA();
                        Exito(exito);
                        cargado = true;
                    }
                }
                else
                {
                    MessageBox.Show("Ya esta registrado este RNPA","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            bool errordatos = false;
            if (tabControl1.SelectedTab.Name=="Pescadores")
            {
                if (!validaralgo(pescador))
                {
                    errordatos = true;
                }
                else
                {
                    exito = AccionesPescador(true);
                }
            }
            else if (tabControl1.SelectedTab.Name == "Permisos")
            {
                exito = AccionesPermiso(true);
                proc.Borrar_equipo(nPer.Text);
                equiposdepesca();
                for (int i = 0; i < dgvEmbarcacionesPerm.RowCount; i++)
                {
                    if (dgvEmbarcacionesPerm[0, i].Value != null)
                    {
                        Emb = new Embarcacion(dgvEmbarcacionesPerm[0, i].Value.ToString(), dgvEmbarcacionesPerm[1, i].Value.ToString(), dgvEmbarcacionesPerm[3, i].Value.ToString(), dgvEmbarcacionesPerm[2, i].Value.ToString(), txtMunicipio.Text, cbRNPA.Text);
                        proc.registrar_perm_emb(Emb, nPer.Text);
                    }
                }
            }
            else if (tabControl1.SelectedTab.Name=="Directiva")
            {
                exito = AccionesDirectiva();
            }
            else if (tabControl1.SelectedTab.Name=="CertMatri")
            {
                exito = AccionesCertificado(true);
            }
            if (!errordatos)
            {
                Exito(exito);
            }
            Resumenes(cbRNPA.Text);
        }
        #endregion


        #region Objetos
        public int AccionesPescador(bool registrar)
        {
            string sexo = "";
            string tipo_pes = "";
            string ocupacion = "";
            string cuerpo = "";
            foreach (CheckBox item in groupBox7.Controls.OfType<CheckBox>())
            {
                if (item.Checked)
                {
                    sexo = item.Text;
                }
            }
            foreach (CheckBox item in TipoPesc.Controls.OfType<CheckBox>())
            {
                if (item.Checked)
                {
                    tipo_pes = item.Text;
                }
            }
            foreach (CheckBox item in OcupacionEnEmbarPesc.Controls.OfType<CheckBox>())
            {
                if (item.Checked)
                {
                    ocupacion = item.Text;
                }
            }
            foreach (CheckBox item in CuerpoDeAguaPesc.Controls.OfType<CheckBox>())
            {
                if (item.Checked)
                {
                    cuerpo = item.Text;
                }
            }
            string[] fecha = FechaNacPesc.Value.ToShortDateString().Split('/');
            string fechaNac = "";
            int i = 2;
            while (i >= 0)
            {
                fechaNac += fecha[i];
                if (i > 0) { fechaNac += "/"; }
                i--;
            }
            pes = new Pescador(NombrePesc.Text, ApePatPescador.Text, ApeMatPescador.Text, CURPPesc.Text, RFCPesc.Text, EscolaridadPesc.Text, TSangrePesc.Text, sexo, LugarNacPesc.Text, fechaNac, CalleYNumPesc.Text, ColoniaPesc.Text, LocalidadPesc.Text, MunicipioPesc.Text, CPPesc.Text, TelefonoPesc.Text, tipo_pes, ocupacion, cuerpo, MatriculaPesc.Text);
            if (registrar)
            {
                return proc.Registrar_Pescador(pes);
            }
            else
            {
                return proc.Actualizar_Pescador(pes);
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
            perm = new Permiso(FolioPer.Text, cbRNPA.Text, nPer.Text, PesqueriaPer.Text, LugarExpPer.Text, diaExp, finVig, ZonaPescaPerm.Text, SitiosDesemPer.Text, ObservacionesPem.Text);
            if (registrar)
            { return proc.Registrar_Permiso(perm); }
            else { return proc.Actualizar_Permiso(perm); }
        }

        public int AccionesDirectiva()
        {
            int reg = 0;
            for (int i = 0; i < dgvDirectiva.RowCount; i++)
            {
                if (dgvDirectiva[0, i].Value != null && dgvDirectiva[1,i].Value!= null && dgvDirectiva[2, i].Value != null && dgvDirectiva[3, i].Value != null)
                {
                    string nombre = dgvDirectiva[0, i].Value.ToString();
                    string cargo = dgvDirectiva[1, i].Value.ToString();
                    string fechaing = dgvDirectiva[2, i].Value.ToString();
                    string telefono = dgvDirectiva[3, i].Value.ToString();

                    dir = new Directiva(cbRNPA.Text, nombre, cargo, fechaing, telefono);
                    reg += proc.Registrar_Directiva(dir);
                }
            }
            return reg;
        }

        public int AccionesCertificado(bool Registro)
        {
            if (Registro)
            {
                Emb = new Embarcacion(NombreEmbCerMat.Text, MatriculaCertMat.Text, cbRNPA.Text, PotenciaMotorCertMat.Text, EsloraCertMat.Text, MangaCertMat.Text, PuntalCertMat.Text, ArqBrutoCertMat.Text, ArqNetoCertMat.Text, PesoMCertMat.Text);
                return proc.Registrar_Embarcacion(Emb);
            }
            else
            {
                Emb = new Embarcacion(NombreEmbCerMat.Text, MatriculaCertMat.Text, cbRNPA.Text, PotenciaMotorCertMat.Text, EsloraCertMat.Text, MangaCertMat.Text, PuntalCertMat.Text, ArqBrutoCertMat.Text, ArqNetoCertMat.Text, PesoMCertMat.Text);
                return proc.Actualizar_Embarcacion(Emb);
            }
        }
        #endregion


        #region Actualizaciones
        private void ActualizarUnidad_Click(object sender, EventArgs e)
        {
            if (validaralgo(unidad))
            {
                if (cargado)
                {
                    if (radioButton0.Checked)
                    {
                        ue = new Unidad_Economica(cbRNPA.Text, txtNombre.Text, "0", txtCalleNum.Text, txtRFC.Text, txtColonia.Text, txtLocalidad.Text, txtMunicipio.Text, mtbCP.Text, txtCorreo.Text, mtbTelefono.Text);
                        exito = proc.Actualizar_Unidad(ue);
                    }
                    else if (radioButton1.Checked)
                    {
                        ue = new Unidad_Economica(cbRNPA.Text, txtNombre.Text, "0", txtCalleNum.Text, txtRFC.Text, txtColonia.Text, txtLocalidad.Text, txtMunicipio.Text, mtbCP.Text, txtCorreo.Text, mtbTelefono.Text);
                        exito = proc.Actualizar_Unidad(ue);
                    }
                    Exito(exito);
                }
            }
        }
        private void Actualizar_Click(object sender, EventArgs e)
        {
            bool errordatos = false;
            if (tabControl1.SelectedTab.Name == "Pescadores")
            {
                if (!validaralgo(pescador))
                {
                    errordatos = true;
                }
                else
                {
                    exito = AccionesPescador(false);
                }
            }
            else if (tabControl1.SelectedTab.Name == "Permisos")
            {
                exito = AccionesPermiso(false);
                proc.Borrar_equipo(nPer.Text);
                equiposdepesca();
            }
            else if (tabControl1.SelectedTab.Name == "Directiva")
            {

            }
            else if (tabControl1.SelectedTab.Name == "CertMatri")
            {

            }
            if (!errordatos)
            {
                Exito(exito);
            }
       }
        #endregion


        #region Eliminaciones
        private void EliminarUnidad_Click(object sender, EventArgs e)
        {
            if (existe(cbRNPA.Text))
            {
                DialogResult Si = MessageBox.Show("¿Desea eliminar esta Unidad Económica?", "ADVERTENCIA", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (Si == DialogResult.Yes)
                {
                    if (proc.Eliminar_Unidad(cbRNPA.Text) == 1)
                    {
                        (new System.Threading.Thread(CloseIt)).Start();
                        MessageBox.Show("Eliminado exitosamente"); /* 1 segundo = 1000 */
                    }
                    else
                    {
                        (new System.Threading.Thread(CloseIt)).Start();
                        MessageBox.Show("Error durante eliminacion"); /* 1 segundo = 1000 */
                    }
                    CargarRNPA();
                }
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (Pescadores.Focused)
            {
                DialogResult Si = MessageBox.Show("¿Desea eliminar este Pescador?", "ADVERTENCIA", MessageBoxButtons.YesNo);
                if (Si == DialogResult.Yes)
                {
                    exito = proc.Eliminar_Pescador(CURPPesc.Text);
                }
            }
            else if (Permisos.Focused)
            {
                DialogResult Si = MessageBox.Show("¿Desea eliminar este Permiso?", "ADVERTENCIA", MessageBoxButtons.YesNo);
                if (Si == DialogResult.Yes)
                {
                    exito = proc.Eliminar_Permiso(nPer.Text);
                }
            }
            else if (Directiva.Focused)
            {

            }
            else if (CertMatri.Focused)
            {

            }
            if (exito == 1)
            {
                (new System.Threading.Thread(CloseIt)).Start();
                MessageBox.Show("Eliminado exitosamente"); /* 1 segundo = 1000 */
            }
            else
            {
                (new System.Threading.Thread(CloseIt)).Start();
                MessageBox.Show("Error durante eliminacion"); /* 1 segundo = 1000 */
            }
        }
        #endregion


        #region Cargar Datos
        bool cargando = true;
        private void CargarRNPA()
        {
            string a = cbRNPA.Text;
            dt = proc.Obtener_todas_unidades("");
            cbRNPA.DataSource = dt;
            cbRNPA.DisplayMember = "RNPA";
            cbRNPA.ValueMember = "RNPA";            
            cbRNPA.Text = a;
            txtNombre.Focus();
            cargando = false;
            tabControl1.Enabled = true;
        }
        private void CargarPermisos()
        {
            string a = nPer.Text;
            nPer.DataSource = dt;
            dt = proc.ObtenerNoPermisos(cbRNPA.Text);
            nPer.DataSource = dt;
            nPer.DisplayMember = "NPERMISO";
            nPer.ValueMember = "NPERMISO";
            nPer.Text = a;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            LlenarCampos();
            Resumenes(cbRNPA.Text);
            CargarPermisos();

            CertMatXUnidad(cbRNPA.Text);
        }

        public void CertMatXUnidad(string RNPA)
        {
            string a = cbRNPA.Text;
            dt = proc.ObtenerCertMatrXUnidad(a);
            MatriculaCertMat.DataSource = dt;
            MatriculaCertMat.DisplayMember = "MATRICULA";
            MatriculaCertMat.ValueMember = "MATRICULA";
        }

        private void LlenarCampos()
        {
            if (!cargando)
            {
                dt = proc.Obtener_todas_unidades(cbRNPA.Text);
                if (dt.Rows.Count != 0) { cargado = true;
                    tabControl1.Enabled = true;
                }
                else { cargado = false; }
                int tipo = 0;
                foreach (DataRow fila in dt.Rows)
                {
                    txtNombre.Text = fila["NOMBRE"].ToString();
                    txtRFC.Text = fila["RFC"].ToString();
                    txtCalleNum.Text = fila["CALLEYNUM"].ToString();
                    txtColonia.Text = fila["COLONIA"].ToString();
                    txtLocalidad.Text = fila["LOCALIDAD"].ToString();
                    txtMunicipio.Text = fila["MUNICIO"].ToString();
                    mtbCP.Text = fila["CODIGO_POSTAL"].ToString();
                    txtCorreo.Text = fila["CORREO"].ToString();
                    mtbTelefono.Text = fila["TELEFONO"].ToString();
                    //tipo = Convert.ToInt32(fila["TIPO"]);
                }
                if (tipo == 0)
                { radioButton0.Checked = true; }
                else { radioButton1.Checked = true; }

                dt = proc.Obtener_Directiva(cbRNPA.Text);
                numericUpDown3.Value = dgvDirectiva.RowCount = dt.Rows.Count;
                int i = 0;
                foreach (DataRow fila in dt.Rows)
                {                    
                    dgvDirectiva[0,i].Value = fila["NOMBRE"].ToString();
                    dgvDirectiva[1, i].Value = fila["CARGO"].ToString();
                    dgvDirectiva[2, i].Value = fila["FECHA_ING"].ToString();
                    dgvDirectiva[3, i].Value = fila["TELEFONO"].ToString();
                    i++;

                }

            }
        }
        #endregion


        #region Validaciones
        //Escribir en data
        public bool existe(string rnpa)
        {
            dt = proc.Obtener_unidades(rnpa);
            if (dt.Rows.Count==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public DateTime Fechanac(string curp)
        {
            string an = curp[4].ToString() + curp[5].ToString();
            int año = 0, mes = 0, dia = 0;
            año = Convert.ToInt32(an)+1900;
            if (año<1930)
            {
                año += 100;
            }
            an = curp[6].ToString() + curp[7].ToString();
            mes = Convert.ToInt32(an);
            an = curp[8].ToString() + curp[9].ToString();
            dia = Convert.ToInt32(an);
            DateTime dti = new DateTime(año, mes, dia);
            return dti;
        }

        public bool validaralgo(string[,] arre)
        {
            bool estabien = true;
            string msg = "Los siguientes campos estan mal o incompletos: \n";
            for (int i = 0; i < arre.Length/2; i++)
            {
                if (arre[i,0]=="0")
                {
                    estabien = false;
                    msg += "----"+arre[i, 1]+"\n";
                }
            }
            if (!estabien)
            {
                MessageBox.Show(msg,"Error en los datos",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return estabien;
        }
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
            if (dgv.CurrentCell.ColumnIndex == dgv.Columns["Matricula"].Index || dgv.CurrentCell.ColumnIndex == dgv.Columns["Marcamotor"].Index)
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
        }

        private void ArqBrutoCertMat_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' && !txt.Text.Contains("."))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dgvEmbarcacionesPerm.RowCount = (int)numericUpDown1.Value;
        }

        private void cbRNPA_TextChanged(object sender, EventArgs e)
        {
            cargado = false;
            tabControl1.Enabled = false;
            if (cbRNPA.Text!="")
            {
                unidad[4, 0] = "1";
            }
            else
            {
                unidad[4, 0] = "0";
            }
            //foreach (TextBox item in gbOrgPes.Controls.OfType<TextBox>())
            //{
            //    item.Text = "";
            //}
            //foreach (MaskedTextBox item in gbOrgPes.Controls.OfType<MaskedTextBox>())
            //{
            //    item.Text = "";
            //}
        }


        private void Exito(int ok)
        {
            if (ok == 1)
            {
                (new System.Threading.Thread(CloseIt)).Start();
                MessageBox.Show("Registrado exitosamente"); /* 1 segundo = 1000 */
            }
            else
            {
                (new System.Threading.Thread(CloseIt)).Start();
                MessageBox.Show("Error durante el registro"); /* 1 segundo = 1000 */
            }
            exito = 0;
        }


        private String DiferenciaFechas(DateTime newdt, DateTime olddt)
        {
            Int32 anios;
            Int32 meses;
            Int32 dias;
            String str = "";

            anios = (newdt.Year - olddt.Year);
            meses = (newdt.Month - olddt.Month);
            dias = (newdt.Day - olddt.Day);

            if (dias < 0)
            {
                meses -= 1;
                dias += DateTime.DaysInMonth(newdt.Year, newdt.Month);
            }
            if (meses < 0)
            {
                anios -= 1;
                meses += 12;
            }
            if (anios < 0)
            {
                return "Fecha Invalida";
            }
            if (anios > 0)
                str = str + anios.ToString() + " años ";
            if (meses > 0)
                str = str + meses.ToString() + " meses ";
            if (dias > 0)
                str = str + dias.ToString() + " dias ";

            return str;
        }

        public void CloseIt()
        {
            System.Threading.Thread.Sleep(2000);
            System.Windows.Forms.SendKeys.SendWait(" ");
        }

        private void diaExpPer_ValueChanged(object sender, EventArgs e)
        {
            VigenciaPerm.Text = DiferenciaFechas(finVigenciaPer.Value, diaExpPer.Value);
        }

        private void mtbCP_TextChanged(object sender, EventArgs e)
        {
            if (mtbCP.Text.Contains(' ') || mtbCP.Text.Length != 5)
            {
                pictureBox2.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
                unidad[1, 0] = "0";
            }
            else
            {
                pictureBox2.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
                unidad[1, 0] = "1";
            }
        }

        private void CPPesc_TextChanged(object sender, EventArgs e)
        {
            if (CPPesc.Text.Contains(' ') || CPPesc.Text.Length != 5)
            {
                pictureBox8.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
                pescador[2, 0] = "1";
            }
            else
            {
                pictureBox8.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
                pescador[2, 0] = "0";
            }
        }
        private void TelefonoPesc_TextChanged(object sender, EventArgs e)
        {
            if (TelefonoPesc.Text.Contains(' ') || TelefonoPesc.Text.Length != 12)
            {
                pictureBox5.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
                pescador[3, 0] = "0";
            }
            else
            {
                pictureBox5.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
                pescador[3, 0] = "1";
            }
        }

        private void mtbTelefono_TextChanged(object sender, EventArgs e)
        {
            if (mtbTelefono.Text.Contains(' ') || mtbTelefono.Text.Length != 12)
            {
                pictureBox10.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
                unidad[3, 0] = "0";
            }
            else
            {
                pictureBox10.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
                unidad[3, 0] = "1";
            }
        }
        private void CorreoPesc_TextChanged(object sender, EventArgs e)
        {
            if (validarCorreo(CorreoPesc.Text))
            {
                pictureBox6.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
                pescador[4, 0] = "1";
            }
            else
            {
                pictureBox6.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
                pescador[4, 0] = "0";
            }
        }
        private void mtbTelRepFed_TextChanged(object sender, EventArgs e)
        {
            if (mtbTelRepFed.Text.Contains(' ') || mtbTelRepFed.Text.Length != 12)
            {
                pictureBox11.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
            }
            else
            {
                pictureBox11.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
            }
        }
        private void CURPPesc_TextChanged(object sender, EventArgs e)
        {
            if (validarcurp(CURPPesc.Text))
            {
                pictureBox9.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
                pescador[0, 0] = "1";
                FechaNacPesc.Value = Fechanac(CURPPesc.Text);
                if (CURPPesc.Text[10]=='H')
                {
                    MasculinoPesc.Checked = true;
                }
                else
                {
                    FemeninoPesc.Checked = true;
                }
            }
            else
            {
                pictureBox9.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
                pescador[0, 0] = "0";
            }
        }
        public bool validarcurp(string rfc)
        {
            if (Regex.IsMatch(rfc, @"^([A-Z\s]{4})\d{6}([A-Z\w]{6})([0-9A-Z]{1})([0-9]{1})$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool validarCorreo(string correo)
        {
            if (Regex.IsMatch(correo, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtRFC_TextChanged(object sender, EventArgs e)
        {
            if (validarrfc(txtRFC.Text))
            {
                pictureBox3.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
                unidad[0, 0] = "1";
            }
            else
            {
                pictureBox3.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
                unidad[0, 0] = "0";
            }

        }
        private void RFCPesc_TextChanged(object sender, EventArgs e)
        {
            if (validarrfc(RFCPesc.Text))
            {
                pictureBox7.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
                pescador[1, 0] = "1";

            }
            else
            {
                pictureBox7.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
                pescador[1, 0] = "0";
            }
        }
        public bool validarrfc(string rfc)
        {
            if (Regex.IsMatch(rfc, @"^([A-Z\s]{4})\d{6}([A-Z\w]{3})$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            dgvDirectiva.RowCount = (int)numericUpDown3.Value;
        }
        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            if (validarCorreo(txtCorreo.Text))
            {
                pictureBox4.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
                unidad[2, 0] = "1";
            }
            else
            {
                pictureBox4.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
                unidad[2, 0] = "0";
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "Pescadores")
            {
                toolTip1.SetToolTip(Registrar, "Registrar Pescador");
                toolTip1.SetToolTip(Actualizar, "Actualizar Pescador");
                toolTip1.SetToolTip(Eliminar, "Eliminar Pescador");
                toolTip1.SetToolTip(Ver, "Ver Pescadores");
            }
            else if (tabControl1.SelectedTab.Name == "Permisos")
            {
                toolTip1.SetToolTip(Registrar, "Registrar Permiso");
                toolTip1.SetToolTip(Actualizar, "Actualizar Permiso");
                toolTip1.SetToolTip(Eliminar, "Eliminar Permiso");
                toolTip1.SetToolTip(Ver, "Ver Permisos");
            }
            else if (tabControl1.SelectedTab.Name == "Directiva")
            {
                toolTip1.SetToolTip(Registrar, "Registrar Directiva");
                toolTip1.SetToolTip(Eliminar, "Eliminar Directiva");
                toolTip1.SetToolTip(Actualizar, "Actualizar Directiva");
            }
            else if (tabControl1.SelectedTab.Name == "CertMatri")
            {
                toolTip1.SetToolTip(Registrar, "Registrar Certificado de Mátricula");
                toolTip1.SetToolTip(Eliminar, "Eliminar Certificado de Mátricula");
                toolTip1.SetToolTip(Actualizar, "Actualizar Certificado de Mátricula");
                toolTip1.SetToolTip(Ver, "Ver Certificados de Mátriculas");
            }
        }
        #endregion


        #region Resumenes
        public void Resumenes(string RNPA)
        {
            dt = proc.Resumen(cbRNPA.Text);
            if (dt.Rows.Count != 0)
            {
                TotalPermisos.Text = dt.Rows[0]["PERMISOS"].ToString();
                TotalSocios.Text = dt.Rows[0]["SOCIOS"].ToString();
                TotalEsfuerzos.Text = dt.Rows[0]["ESFUERZOS PESQUEROS"].ToString();

                dt = proc.ResumenPesqueria(cbRNPA.Text);
                TotalPesquerias.Items.Clear();
                foreach (DataRow fila in dt.Rows)
                {
                    TotalPesquerias.Items.Add(fila["PESQUERIA"].ToString());
                }
            }
        }
        #endregion

        //Pintar los groupBox
        private void PintarGroupBox()
        {
            this.BackColor = Color.FromArgb(36, 50, 61);
            Resumen.BackColor = Color.FromArgb(118, 50, 63);

            tabControl1.Width = Convert.ToInt32(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width * .985);
            Resumen.Width = Convert.ToInt32(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width * .296);

            foreach (TextBox ctr in gbOrgPes.Controls.OfType<TextBox>())
            {
                gbOrgPes.Controls[gbOrgPes.Controls.IndexOf(ctr)].ForeColor = Color.FromArgb(160, 160, 160);
                gbOrgPes.Controls[gbOrgPes.Controls.IndexOf(ctr)].BackColor = Color.FromArgb(36, 50, 61);

            }
            foreach (MaskedTextBox ctr in gbOrgPes.Controls.OfType<MaskedTextBox>())
            {
                gbOrgPes.Controls[gbOrgPes.Controls.IndexOf(ctr)].ForeColor = Color.FromArgb(160, 160, 160);
                gbOrgPes.Controls[gbOrgPes.Controls.IndexOf(ctr)].BackColor = Color.FromArgb(36, 50, 61);

            }
        }

        private void BuscarPermiso_Click(object sender, EventArgs e)
        {
            dt = proc.ObtenerPermiso(Convert.ToInt32(nPer.Text));
            if (dt.Rows.Count != 0)
            {
                FolioPer.Text = dt.Rows[0]["FOLIO"].ToString();
                PesqueriaPer.Text = dt.Rows[0]["PESQUERIA"].ToString();
                LugarExpPer.Text = dt.Rows[0]["LUGAREXPEDICION"].ToString();
                VigenciaPerm.Text = dt.Rows[0]["FOLIO"].ToString();
                diaExpPer.Text = dt.Rows[0]["DIAEXPEDICION"].ToString();
                finVigenciaPer.Text = dt.Rows[0]["FINVIGENCIA"].ToString();
                ZonaPescaPerm.Text = dt.Rows[0]["ZONAPESCA"].ToString();
                SitiosDesemPer.Text = dt.Rows[0]["SITIOSDESEMBARQUE"].ToString();
                ObservacionesPem.Text = dt.Rows[0]["OBSERVACIONES"].ToString();
                dt = proc.NumeroEmbarcaciones(Convert.ToInt32(nPer.Text));
                numericUpDown1.Value = dt.Rows.Count;
                dt = proc.EmbarcacionesxPermiso(Convert.ToInt32(nPer.Text));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvEmbarcacionesPerm[0, i].Value = dt.Rows[i]["NOMBREEMBARCACION"].ToString();
                    dgvEmbarcacionesPerm[1, i].Value = dt.Rows[i]["MATRICULA"].ToString();
                    dgvEmbarcacionesPerm[2, i].Value = dt.Rows[i]["MOTORMARCA"].ToString();
                    dgvEmbarcacionesPerm[3, i].Value = dt.Rows[i]["MOTORHP"].ToString();

                }

            }
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            dgvEquiposPescaPerm.RowCount = (int)numericUpDown2.Value;
        }
        public void equiposdepesca()
        {
            for (int i = 0; i < dgvEquiposPescaPerm.RowCount; i++)
            {
                proc.Registrar_Equipo(nPer.Text, dgvEquiposPescaPerm[0, i].Value.ToString(), dgvEquiposPescaPerm[1, i].Value.ToString(), dgvEquiposPescaPerm[2, i].Value.ToString());
            }
        }

        private void cbRNPA_TabStopChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            dt = proc.ObtenerPermiso(Convert.ToInt32(nPer.Text));
            if (dt.Rows.Count != 0)
            {
                FolioPer.Text = dt.Rows[0]["FOLIO"].ToString();
                PesqueriaPer.Text = dt.Rows[0]["PESQUERIA"].ToString();
                LugarExpPer.Text = dt.Rows[0]["LUGAREXPEDICION"].ToString();
                VigenciaPerm.Text = dt.Rows[0]["FOLIO"].ToString();
                diaExpPer.Text = dt.Rows[0]["DIAEXPEDICION"].ToString();
                finVigenciaPer.Text = dt.Rows[0]["FINVIGENCIA"].ToString();
                ZonaPescaPerm.Text = dt.Rows[0]["ZONAPESCA"].ToString();
                SitiosDesemPer.Text = dt.Rows[0]["SITIOSDESEMBARQUE"].ToString();
                ObservacionesPem.Text = dt.Rows[0]["OBSERVACIONES"].ToString();
                dt = proc.NumeroEmbarcaciones(Convert.ToInt32(nPer.Text));
                numericUpDown1.Value = dt.Rows.Count;
                dt = proc.EmbarcacionesxPermiso(Convert.ToInt32(nPer.Text));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvEmbarcacionesPerm[0, i].Value = dt.Rows[i]["NOMBREEMBARCACION"].ToString();
                    dgvEmbarcacionesPerm[1, i].Value = dt.Rows[i]["MATRICULA"].ToString();
                    dgvEmbarcacionesPerm[2, i].Value = dt.Rows[i]["MOTORMARCA"].ToString();
                    dgvEmbarcacionesPerm[3, i].Value = dt.Rows[i]["MOTORHP"].ToString();

                }

            }
        }
    }
}
