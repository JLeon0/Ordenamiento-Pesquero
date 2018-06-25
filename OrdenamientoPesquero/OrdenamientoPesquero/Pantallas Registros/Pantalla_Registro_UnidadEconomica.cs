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
using OrdenamientoPesquero.Pantallas_Registros;

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
        Validaciones val = new Validaciones();        Procedimientos proc = new Procedimientos();
        DataSet ds = new DataSet();
        DataTable dt = null;
        DataTable NOMBRES = null;
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
            txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            cbRNPA.Focus();
            //PintarGroupBox();
            CargarRNPA();
            CargarMunicipios();
            CargarFederaciones();
            cargando = false;
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
                        if (!cargado)
                        {
                            if (radioButton0.Checked)
                            {
                                ue = new Unidad_Economica(r, txtNombre.Text, "0", txtCalleNum.Text, txtRFC.Text, txtColonia.Text, txtLocalidad.Text, txtMunicipio.Text, mtbCP.Text, txtCorreo.Text, mtbTelefono.Text);
                                exito = proc.Registrar_Unidad(ue);
                            }
                            else if (radioButton1.Checked)
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
                if (!cargado)
                {
                    if (radioButton0.Checked)
                    {
                        ue = new Unidad_Economica(cbRNPA.Text, txtNombre.Text, "0", txtCalleNum.Text, txtRFC.Text, txtColonia.Text, txtLocalidad.Text, txtMunicipio.Text, mtbCP.Text, txtCorreo.Text, mtbTelefono.Text);
                        exito = proc.Actualizar_Unidad(ue);
                    }
                    else if (radioButton1.Checked)
                    {
                        ue = new Unidad_Economica(cbRNPA.Text, txtNombre.Text, "1", txtCalleNum.Text, txtRFC.Text, txtColonia.Text, txtLocalidad.Text, txtMunicipio.Text, mtbCP.Text, txtCorreo.Text, mtbTelefono.Text);
                        exito = proc.Actualizar_Unidad(ue);
                    }
                    int Folio = ObtenerFolio();
                    exito = proc.AsignarFederacion(Folio, cbRNPA.Text);
                    val.Exito(exito);

                }
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
            string a = cbRNPA.Text.Replace(" ", ""); ;
            dt = proc.Obtener_todas_unidades("");
            if (dt.Rows.Count != 0)
            {
                cbRNPA.DataSource = dt;
                cbRNPA.DisplayMember = "RNPA";
                cbRNPA.ValueMember = "RNPA";
                cbRNPA.Text = a;
            }
            NOMBRES = proc.Obtener_todos_los_nombres("");
            if(dt.Rows.Count != 0)
            {
                txtNombre.DataSource = NOMBRES;
                txtNombre.DisplayMember = "Nombre";
                txtNombre.ValueMember = "Nombre";
                txtNombre.Text = "";
            }
            cbRNPA.Focus();
        }

        private void CargarMunicipios()
        {
            dt = proc.ObtenerMunicipios();
            if (dt.Rows.Count != 0)
            {
                txtMunicipio.DataSource = dt;
                txtMunicipio.DisplayMember = "NombreM";
                txtMunicipio.ValueMember = "NombreM";
                txtMunicipio.Text = "Seleccione un Municipio";
                Municipios = dt.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (existe(cbRNPA.Text))
            {
                LlenarCampos();
                ObtenerFederacion();
                Resumenes(cbRNPA.Text);
                ResumenSocios(cbRNPA.Text);
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
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
        }
        private void BuscarNombreOrg_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LlenarCamposNombre();
            ObtenerFederacion();
            Resumenes(cbRNPA.Text);
            ResumenSocios(cbRNPA.Text);
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            this.Cursor = Cursors.Default;
        }
        

        private void LlenarCampos()
        {
            if (!cargando)
            {
                dt = proc.Obtener_todas_unidades(cbRNPA.Text);
                if (dt.Rows.Count != 0)
                {
                    cargado = true;
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
                    string x = fila["TIPO"].ToString();
                    if (x != "") { tipo = Convert.ToInt32(fila["TIPO"]); }
                }
                if (tipo == 0)
                { radioButton0.Checked = true; }
                else { radioButton1.Checked = true; }
            }
        }

        private void LlenarCamposNombre()
        {
            if (txtNombre.SelectedIndex >= 0)
            {
                int tipo = 0;
                DataRow fila = NOMBRES.Rows[txtNombre.SelectedIndex];

                cbRNPA.Text = fila["RNPA"].ToString();
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
                { radioButton0.Checked = true; }
                else { radioButton1.Checked = true; }
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
            cargado = false;
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
                TotalPermisos.Text = dt.Rows[0]["PERMISOS"].ToString();
                TotalSocios.Text = dt.Rows[0]["SOCIOS"].ToString();
                TotalEsfuerzos.Text = dt.Rows[0]["ESFUERZOS PESQUEROS"].ToString();

                dt = proc.ResumenPesqueria(cbRNPA.Text);
                if (dt.Rows.Count > 0)
                {
                    DataResumen.RowCount = dt.Rows.Count;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataResumen[0, i].Value = dt.Rows[i]["PESQUERIA"].ToString();
                        DataResumen[1, i].Value = dt.Rows[i][2].ToString();
                        DataResumen[2, i].Value = val.DiferenciaFechas(Convert.ToDateTime(dt.Rows[i][4].ToString()), Convert.ToDateTime(dt.Rows[i][3].ToString()));
                    }
                }
                else
                {
                    DataResumen.Rows.Clear();
                    DataResumen.Refresh();
                }
                DataResumen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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

        private void DataResumen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                Pantalla_Registro_Usuario pesc = new Pantalla_Registro_Usuario(cbRNPA.Text, txtNombre.Text);
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
                proc.Generar(folderBrowserDialog1.SelectedPath); 
            }
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string direccion = ofd.FileName;
            if (proc.Cargar(direccion))
            {
                this.OnLoad(e);
            }
        }

        private void servidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proc.bdd = "OrdPesquero";
            proc.cambiarbd(proc.bdd);
            this.OnLoad(e);
        }

        private void cambiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //proc.bdd = "OrdPesquero2";
            //proc.cambiarbd(proc.bdd);
            this.OnLoad(e);
        }

        private void cbRNPA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                pictureBox12_Click(sender, e);
            }
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

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}
