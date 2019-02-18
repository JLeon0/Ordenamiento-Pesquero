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
using System.Threading;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using OrdenamientoPesquero.Pantallas_Registros;
using System.Data.SqlClient;
using CapaDatos;

namespace OrdenamientoPesquero
{
    public partial class Pantalla_Registro_UnidadEconomica : Form
    {
        bool cargado = false;
        Unidad_Economica ue;
        int exito = 0;
        Validaciones val = new Validaciones();
        Procedimientos proc = new Procedimientos();
        DataSet ds = new DataSet();
        DataTable dt = null;
        DataTable RNPA,NOMBRES = null;
        string[,] unidad = { { "0", "RFC" }, { "0", "Codigo Postal" }, { "0", "Correo Electronico" }, { "0", "Telefono de la Cooperativa" },{"0","RNPA" } };
        string[,] pescador = { { "0", "CURP" }, { "0", "RFC" }, { "0", "Codigo postal" }, { "0", "Telefono" } , { "0","Correo Electronico"} };
        string[] Municipios;
        public Pantalla_Registro_UnidadEconomica()
        {
            InitializeComponent();
            val.ajustarResolucion(this);
            this.Height = Convert.ToInt32(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height * .96);
            this.Width = Convert.ToInt32(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width);
        }

        private void Pantalla_Registro_UnidadEconomica_Load(object sender, EventArgs e)
        {
            cargando = false;
            txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            CargarRNPA();
            cbRNPA.Focus();
            CargarMunicipios();
            CargarFederaciones();

        }

        #region Registros
        private void RegistrarUnidad_Click(object sender, EventArgs e)
        {
            string r = cbRNPA.Text.Replace(" ", "");
            if (r != "")
            {
                if (validaralgo(unidad))
                {
                    if (!existe(cbRNPA.Text))
                    {
                        if (Social.Checked)
                        {
                            ue = new Unidad_Economica(r, txtNombre.Text, "0", txtCalleNum.Text, txtRFC.Text, txtColonia.Text, txtLocalidad.Text, txtMunicipio.Text, mtbCP.Text, txtCorreo.Text, mtbTelefono.Text);
                            exito = proc.Registrar_Unidad(ue);
                        }
                        else if (Privado.Checked)
                        {
                            ue = new Unidad_Economica(r, txtNombre.Text, "1", txtCalleNum.Text, txtRFC.Text, txtColonia.Text, txtLocalidad.Text, txtMunicipio.Text, mtbCP.Text, txtCorreo.Text, mtbTelefono.Text);
                            exito = proc.Registrar_Unidad(ue);
                        }
                        int Folio = ObtenerFolio();
                        exito = proc.AsignarFederacion(Folio, cbRNPA.Text);
                        CargarRNPA();
                        val.Exito(exito);
                        cargado = true;

                    }
                    else
                    {
                        MessageBox.Show("Ya esta registrado este RNPA", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion


        #region Actualizaciones
        private void ActualizarUnidad_Click(object sender, EventArgs e)
        {
            if (validaralgo(unidad))
            {

                if (Social.Checked)
                {
                    ue = new Unidad_Economica(cbRNPA.Text, txtNombre.Text, "0", txtCalleNum.Text, txtRFC.Text, txtColonia.Text, txtLocalidad.Text, txtMunicipio.Text, mtbCP.Text, txtCorreo.Text, mtbTelefono.Text);
                    exito = proc.Actualizar_Unidad(ue);
                }
                else if (Privado.Checked)
                {
                    ue = new Unidad_Economica(cbRNPA.Text, txtNombre.Text, "1", txtCalleNum.Text, txtRFC.Text, txtColonia.Text, txtLocalidad.Text, txtMunicipio.Text, mtbCP.Text, txtCorreo.Text, mtbTelefono.Text);
                    exito = proc.Actualizar_Unidad(ue);
                }
                int Folio = ObtenerFolio();
                exito = proc.AsignarFederacion(Folio, cbRNPA.Text);
                val.Exito(exito);


            }
            NOMBRES = proc.Obtener_todos_los_nombres("");
        }
        #endregion


        #region Eliminaciones
        private void EliminarUnidad_Click(object sender, EventArgs e)
        {
            if (existe(cbRNPA.Text))
            {
                DialogResult Si = MessageBox.Show("¿Desea eliminar esta Unidad Económica?", "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Si == DialogResult.Yes)
                {
                    if (proc.Eliminar_Unidad(cbRNPA.Text) == 1)
                    {
                        (new System.Threading.Thread(val.CloseIt)).Start();
                        MessageBox.Show("Eliminado exitosamente"); /* 1 segundo = 1000 */
                    }
                    else
                    {
                        (new System.Threading.Thread(val.CloseIt)).Start();
                        MessageBox.Show("Error durante eliminacion"); /* 1 segundo = 1000 */
                    }
                    int Folio = ObtenerFolio();
                    exito = proc.Eliminar_Federacion(Folio);
                    CargarRNPA();
                    cbRNPA.Text = "";
                }
            }
        }
        #endregion


        #region Cargar Datos
        bool cargando = true;
        private void CargarRNPA()
        {
            RNPA = proc.Obtener_todas_unidades(BuscarR.Text);
            if (RNPA.Rows.Count == 0)
            {
                RNPA = proc.Obtener_todas_unidades(BuscarR.Text);
            }
            ListaRNPA.Items.Clear();
            foreach (DataRow fila in RNPA.Rows)
            {
                ListaRNPA.Items.Add(fila["RNPA"].ToString());
            }
            NOMBRES = proc.Obtener_todos_los_nombres("");
            ListaNombres.Items.Clear();
            foreach (DataRow fila in NOMBRES.Rows)
            {
                ListaNombres.Items.Add(fila["NOMBRE"].ToString());
            }
            cbRNPA.Focus();
        }

        private void CargarMunicipios()
        {
            dt = proc.ObtenerMunicipios();
            if (dt.Rows.Count != 0)
            {
                Municipios = dt.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();
                txtMunicipio.DataSource = dt;
                txtMunicipio.DisplayMember = "NombreM";
                txtMunicipio.ValueMember = "NombreM";
                txtMunicipio.Text = "Seleccione un Municipio";
            }
        }
        public void limpiartodo()
        {
            foreach (TextBox item in gbOrgPes.Controls.OfType<TextBox>())
            {
                item.Text = "";
            }
            foreach (MaskedTextBox item in gbOrgPes.Controls.OfType<MaskedTextBox>())
            {
                item.Text = "";
            }
            foreach (ComboBox item in gbOrgPes.Controls.OfType<ComboBox>())
            {
                item.Text = "";
            }
            TotalEsfuerzos.Text = "0";
            TotalPermisos.Text = "0";
            TotalSocios.Text = "0";
            DataResumen.RowCount = 0;
            NombreResumen.Text = "0";
            cbRNPA.Enabled = true;
        }
        private void BuscarNombreOrg_Click(object sender, EventArgs e)
        {
          
        }
        

        private void LlenarCampos()
        {
            if (!cargando)
            {
                dt = proc.Obtener_todas_unidades(ListaRNPA.Text);
                if (dt.Rows.Count != 0)
                {
                    cargado = true;
                }
                else { cargado = false; }
                int tipo = 0;
                foreach (DataRow fila in dt.Rows)
                {
                    cbRNPA.Text = ListaRNPA.Text;
                    txtNombre.Text = fila["NOMBRE"].ToString();
                    txtRFC.Text = fila["RFC"].ToString();
                    txtCalleNum.Text = fila["CALLEYNUM"].ToString();
                    txtColonia.Text = fila["COLONIA"].ToString();
                    txtLocalidad.Text = fila["LOCALIDAD"].ToString();
                    txtMunicipio.Text = fila["MUNICIO"].ToString();
                    mtbCP.Text = fila["CODIGO_POSTAL"].ToString();
                    txtCorreo.Text = fila["CORREO"].ToString();
                    mtbTelefono.Text = fila["TELEFONO"].ToString();
                    string x = fila["TIPO"].ToString();
                    if (x != "") { tipo = Convert.ToInt32(fila["TIPO"]); }
                }
                if (tipo == 0)
                { Social.Checked = true; }
                else { Privado.Checked = true; }
            }
        }

        private void LlenarCamposNombre()
        {
            if (ListaNombres.SelectedIndex >= 0)
            {
                NOMBRES = proc.Obtener_todos_los_nombres(ListaNombres.Text);
                int tipo = 0;
                DataRow fila = NOMBRES.Rows[0];

                cbRNPA.Text = fila["RNPA"].ToString();
                txtNombre.Text = fila["NOMBRE"].ToString();
                txtRFC.Text = fila["RFC"].ToString();
                txtCalleNum.Text = fila["CALLEYNUM"].ToString();
                txtColonia.Text = fila["COLONIA"].ToString();
                txtLocalidad.Text = fila["LOCALIDAD"].ToString();
                txtMunicipio.Text = fila["MUNICIO"].ToString();
                mtbCP.Text = fila["CODIGO_POSTAL"].ToString();
                txtCorreo.Text = fila["CORREO"].ToString();
                mtbTelefono.Text = fila["TELEFONO"].ToString();
                string x = fila["TIPO"].ToString();
                if (x != "") { tipo = Convert.ToInt32(fila["TIPO"]); }

                if (tipo == 0)
                { Social.Checked = true; }
                else { Privado.Checked = true; }
            }
        }
        #endregion


        #region Validaciones
        
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
            return true;
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

        private void cbRNPA_TextChanged(object sender, EventArgs e)
        {
            if (cbRNPA.Text!="")
            {
                unidad[4, 0] = "1";
            }
            else
            {
                unidad[4, 0] = "0";
            }
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
        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            if (val.validarCorreo(txtCorreo.Text))
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
        private void txtRFC_TextChanged(object sender, EventArgs e)
        {
            if (val.validarrfc(txtRFC.Text))
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
        #endregion


        #region Resumenes
        public void Resumenes(string RNPA)
        {
            NombreResumen.Text = txtNombre.Text;
            dt = proc.Resumen(cbRNPA.Text);
            if (dt.Rows.Count != 0)
            {
                if (Privado.Checked)
                {
                    linkLabel1.Visible = true;
                    Titular.Visible = true;
                    if (dt.Rows[0]["SOCIOS"].ToString()=="0")
                    {
                        linkLabel1.Text = "0";
                        TotalSocios.Text = dt.Rows[0]["SOCIOS"].ToString();     
                    }
                    else
                    {
                        int soc= Convert.ToInt32(dt.Rows[0]["SOCIOS"].ToString());
                        soc--;
                        TotalSocios.Text = soc.ToString();
                    }     
                }
                else
                {
                    Titular.Visible = false;
                    linkLabel1.Visible = false;
                    TotalSocios.Text=dt.Rows[0]["SOCIOS"].ToString();
                }
                TotalPermisos.Text = dt.Rows[0]["PERMISOS"].ToString();
                TotalEsfuerzos.Text = dt.Rows[0]["ESFUERZOS PESQUEROS"].ToString();
                chipeados.Text = dt.Rows[0]["ESFUERZOS CHIPEADOS"].ToString();

                dt = proc.ResumenPesqueria(cbRNPA.Text);
                if (dt.Rows.Count > 0)
                {
                    DataResumen.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataResumen[0, i].Value = dt.Rows[i]["PESQUERIA"].ToString();
                        DataResumen[1, i].Value = dt.Rows[i][2].ToString();
                        if (val.DiferenciaFechas(Convert.ToDateTime(dt.Rows[i][4].ToString()), DateTime.Today) == "Fecha Invalida")
                        {
                            DataResumen[2, i].Value = "VENCIDO";
                            DataResumen[2, i].Style.ForeColor = Color.Red;
                            Font a = new Font(DataResumen.Font, FontStyle.Bold);
                            DataResumen[2, i].Style.Font=a;
                        }
                        else
                        {
                            DataResumen[2, i].Value = val.DiferenciaFechas(Convert.ToDateTime(dt.Rows[i][4].ToString()), DateTime.Today);
                            DataResumen[2, i].Style.ForeColor = Color.Black;
                            Font a = new Font(DataResumen.Font, FontStyle.Regular);
                            DataResumen[2, i].Style.Font = a;
                        }
                    }
                }
                else
                {
                    DataResumen.Rows.Clear();
                    DataResumen.Refresh();
                }
                DataResumen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                TotalPermisos.Text = "0";
                TotalSocios.Text = "0";
                TotalEsfuerzos.Text = "0";
            }
        }
        public void ResumenSocios(string RNPA)
        {
            dt = proc.ResumenSocios(cbRNPA.Text);
            if (dt.Rows.Count != 0)
            {
                Capitanes.Text = dt.Rows[0]["CAPITANES"].ToString();
                Marineros.Text = dt.Rows[0]["MARINEROS"].ToString();
                SinActividad.Text = dt.Rows[0]["SINACTIVIDAD"].ToString();
                Ordenados.Text = dt.Rows[0]["ORDENADOS"].ToString();
                Asegurados.Text = dt.Rows[0]["ASEGURADOS"].ToString();
                Acuacultores.Text = dt.Rows[0]["ACUACULTORES"].ToString();
                Credencializados.Text = dt.Rows[0]["CREDENCIALIZADOS"].ToString();
            }
            else
            {
                Capitanes.Text = "0";
                Marineros.Text = "0";
                SinActividad.Text = "0";
                Ordenados.Text = "0";
                Asegurados.Text = "0";
                Acuacultores.Text = "0";
                Credencializados.Text = "0";
            }
        }
        #endregion


        private void CargarFederaciones()
        {
            dt = proc.Obtener_Federaciones();
            NomFed.DataSource = dt;
            NomFed.DisplayMember = "NOMBRE";
            //NomFed.ValueMember = "NOMBRE";
            NomFed.Text = "Seleccione una Federación";
        }
        private int ObtenerFolio()
        {
            dt = proc.Obtener_Federaciones();
            foreach (DataRow filas in dt.Rows)
            {
                string n = filas["NOMBRE"].ToString();
                if (n == NomFed.Text)
                {
                    return Convert.ToInt32(filas["FOLIO"].ToString());
                }
            }
            return 0;
        }
        private void ObtenerFederacion()
        {
            dt = proc.ObtenerUnaFederacion(cbRNPA.Text);
            if (dt.Rows.Count > 0)
            {
                NomFed.Text = dt.Rows[0]["NOMBRE"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (existe(cbRNPA.Text))
            {
                Pantalla_Regitro_permiso perm = new Pantalla_Regitro_permiso(cbRNPA.Text, txtMunicipio.Text, txtNombre.Text);
                perm.ShowDialog();
                Resumenes(cbRNPA.Text);
            }
            else { MessageBox.Show("Debe elegir una unidad economica que esté registrada", "Error"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (existe(cbRNPA.Text))
            {
                int tipo = 0;
                if (Privado.Checked) { tipo = 1; }
                Pantalla_Registro_Usuario pesc = new Pantalla_Registro_Usuario(cbRNPA.Text, txtNombre.Text,tipo);
                pesc.ShowDialog();
                Resumenes(cbRNPA.Text);
            }
            else { MessageBox.Show("Debe elegir una unidad economica que esté registrada", "Error"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (existe(cbRNPA.Text))
            {
                Pantalla_Certificado_Mat certmat = new Pantalla_Certificado_Mat(cbRNPA.Text);
                certmat.ShowDialog();
                Resumenes(cbRNPA.Text);
            }
            else { MessageBox.Show("Debe elegir una unidad economica que esté registrada", "Error"); }
        }

        private void TotalPermisos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Vistas v = new Vistas(cbRNPA.Text, txtNombre.Text, 2);
            v.ShowDialog(this);
        }

        private void TotalSocios_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cbRNPA.Text != "" && cbRNPA.Text != null)
            {
                Vistas vista = new Vistas(cbRNPA.Text, txtNombre.Text,1);
                vista.ShowDialog();
            }
        }
              
        private void txtMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cargando)
            {
                dt = proc.ObtenerLocalidades(Municipios[txtMunicipio.SelectedIndex]);
                txtLocalidad.DataSource = dt;
                txtLocalidad.DisplayMember = "NombreL";
                txtLocalidad.ValueMember = "NombreL";
                txtLocalidad.Text = "Seleccione una Localidad";
            }
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            limpiartodo();
        }

        private void generarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                this.Cursor = Cursors.WaitCursor;
                //proc.cambiarbd("OrdPesquero2");
                //proc.limpiar();
                //proc.PasarUnidad2(cbRNPA.Text);
                //proc.PasarEmbarcaciones2(cbRNPA.Text);
                //proc.PasarPescadores2(cbRNPA.Text);
                //proc.PasarPermisos2(cbRNPA.Text);
                //proc.PasarEquipoPesca2(cbRNPA.Text);
                //proc.PasarEmbarcaPermis2(cbRNPA.Text);
                //proc.PasarDirectiva2(cbRNPA.Text);
                proc.Generar(folderBrowserDialog1.SelectedPath, cbRNPA.Text);
                //proc.cambiarbd("OrdPesquero");
                this.Cursor = Cursors.Default;
            }
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.ShowDialog();
            //this.Cursor = Cursors.WaitCursor;
            //string direccion = ofd.FileName;
            //if (proc.Cargar(direccion))
            //{
            if (cambiosToolStripMenuItem.Checked)
            {
                proc.PasarUnidad();
                proc.PasarEmbarcaciones();
                proc.PasarPescadores();
                proc.PasarPermisos();
                proc.PasarEquipoPesca();
                proc.PasarEmbarcaPermis();
                proc.PasarDirectiva();
                this.OnLoad(e);
            }
            else
            {
                MessageBox.Show("No ah seleccionado cambios para cargar");
            }
            //}
            //this.Cursor = Cursors.Default;
        }

        private void servidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            servidorToolStripMenuItem.Checked = true;
            cambiosToolStripMenuItem.Checked = false;
            proc.bdd = "OrdPesquero";
            proc.cambiarbd(proc.bdd);
            this.OnLoad(e);
            this.Cursor = Cursors.Default;
        }

        private void cambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string direccion = ofd.FileName;
                if (proc.Cargar(direccion))
                {
                    servidorToolStripMenuItem.Checked = false;
                    cambiosToolStripMenuItem.Checked = true;
                    proc.bdd = "OrdPesquero2";
                    proc.cambiarbd(proc.bdd);
                    this.OnLoad(e);
                }
                else
                {
                    cambiosToolStripMenuItem.Checked = false;
                }
            }
            else
            {
                cambiosToolStripMenuItem.Checked = false;
            }
            this.Cursor = Cursors.Default;
        }

        private void cbRNPA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else { e.Handled = true; }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BuscarNombreOrg_Click(sender, e);
            }
            //else
            //{
            //    string a = txtNombre.Text;
            //    dt = proc.Obtener_todas_unidades("");
            //    NOMBRES = proc.Obtener_todos_los_nombres(txtNombre.Text);
            //    if (dt.Rows.Count != 0)
            //    {
            //        txtNombre.DataSource = NOMBRES;
            //        txtNombre.DisplayMember = "Nombre";
            //        txtNombre.ValueMember = "Nombre";
            //        txtNombre.Text = a;
            //    }
            //}
        }

        private void RegFed_Click(object sender, EventArgs e)
        {
            Pantalla_Federaciones fede = new Pantalla_Federaciones("");
            fede.ShowDialog();
            CargarFederaciones();
        }

        private void ModFed_Click(object sender, EventArgs e)
        {
            Pantalla_Federaciones fede = new Pantalla_Federaciones(NomFed.Text);
            fede.ShowDialog();
            CargarFederaciones();
        }
        


        private void button4_Click(object sender, EventArgs e)
        {
            Vistas v = new Vistas(cbRNPA.Text, txtNombre.Text, 5);
            v.ShowDialog(this);
        }

        private void BuscarR_TextChanged(object sender, EventArgs e)
        {
            RNPA = proc.Obtener_todas_unidades(BuscarR.Text);
            ListaRNPA.Items.Clear();
            foreach (DataRow fila in RNPA.Rows)
            {
                ListaRNPA.Items.Add(fila["RNPA"].ToString());
            }

        }

        private void ListaRNPA_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ListaRNPA.SelectedIndex >= 0)
            {
                ListaNombres.SelectedIndex = -1;
                this.Cursor = Cursors.WaitCursor;
                if (existe(ListaRNPA.Text))
                {
                    LlenarCampos();
                    ObtenerFederacion();
                    Resumenes(ListaRNPA.Text);
                    ResumenSocios(ListaRNPA.Text);
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    cbRNPA.Enabled = false;
                }
                else
                {
                    limpiartodo();
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void BuscarN_TextChanged(object sender, EventArgs e)
        {
            string x = BuscarN.Text;
            NOMBRES = proc.Obtener_todos_los_nombres(x);
            ListaNombres.Items.Clear();
            foreach (DataRow fila in NOMBRES.Rows)
            {
                ListaNombres.Items.Add(fila["NOMBRE"].ToString());
            }
        }

        private void ListaNombres_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ListaNombres.SelectedIndex >=0)
            {
                ListaRNPA.SelectedIndex = -1;
                this.Cursor = Cursors.WaitCursor;
                LlenarCamposNombre();
                ObtenerFederacion();
                Resumenes(cbRNPA.Text);
                ResumenSocios(cbRNPA.Text);
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                cbRNPA.Enabled = false;
                this.Cursor = Cursors.Default;
            }
        }

        private void CerrarPanel_Click(object sender, EventArgs e)
        {
            gbBotones.Enabled = true;
            gbBusqueda.Enabled = true;
            gbOrgPes.Enabled = true;
            PanelRNPA.Visible = false;
            PanelRNPA.Enabled = false;
            RnpaNuevo.Text = "";
        }

        private void ActivarPanelRNPA_Click(object sender, EventArgs e)
        {
            if (cbRNPA.Text != "")
            {
                RnpaMal.Text = cbRNPA.Text;
                gbBotones.Enabled = false;
                gbBusqueda.Enabled = false;
                gbOrgPes.Enabled = false;
                Resumen.Enabled = false;
                PanelRNPA.Visible = true;
                PanelRNPA.Enabled = true;
            }
        }

        private void ActualizarRNPA_Click(object sender, EventArgs e)
        {
            if (RnpaNuevo.Text != "")
            {
                DialogResult res = MessageBox.Show("Usted está por cambiar el RNPA de una Unidad, con todas sus EMBARCACIONES, PERMISOS, PESCADORES, FEDERACIÓN.\n Desea continuar?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    if (proc.Actualizar_RNPA(RnpaMal.Text, RnpaNuevo.Text) >= 1)
                    {
                        cbRNPA.Text = RnpaNuevo.Text;
                        MessageBox.Show("RNPA Actualizada");
                    }
                    else { MessageBox.Show("RNPA Ya existe"); }
                    CargarRNPA();
                }
            }
        }


        private void Expediente_Click(object sender, EventArgs e)
        {
            if (cbRNPA.Text != "")
            {
                Pantallas_Archivos.Expediente_UE expue = new Pantallas_Archivos.Expediente_UE(cbRNPA.Text,txtNombre.Text);
                expue.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Social.Checked)
            {
                Pantallas_Menu.MenuReportes mr = new Pantallas_Menu.MenuReportes(cbRNPA.Text, "ReporteXUnidad.rdlc"); mr.Show(this);
            }
            else
            {
                Pantallas_Menu.MenuReportes mr = new Pantallas_Menu.MenuReportes(cbRNPA.Text, "ReporteXPermicionario.rdlc"); mr.Show(this);
            }
        }
    }
}
