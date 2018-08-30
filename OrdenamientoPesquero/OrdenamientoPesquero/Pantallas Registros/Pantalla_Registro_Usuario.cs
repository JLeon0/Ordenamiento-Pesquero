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
using OrdenamientoPesquero.Pantallas_Registros;
using System.IO;
//using FlexCodeSDK;

namespace OrdenamientoPesquero
{
    public partial class Pantalla_Registro_Usuario : Form
    {
        string[,] pescador = { { "0", "CURP" }, { "0", "RFC" }, { "0", "Codigo postal" }, { "0", "Telefono" }, { "0", "Correo Electronico" } };
        int exito = 0;
        bool cargando = true;
        Pescador pes;
        Procedimientos proc = new Procedimientos();
        Validaciones val = new Validaciones();
        DataTable dt, NoOrdenados;
        string RNPA = "", NombreUnidad = "";
        string[] Municipios;
        byte[] imagenBuffer;
        //FlexCodeSDK.FinFPReg reg;
        string template = "";

        public Pantalla_Registro_Usuario(string rnpa, string nombre)
        {
            InitializeComponent();
            this.Height = Convert.ToInt32(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height * .96);
            RNPA = rnpa;
            NombreUnidad = nombre;
        }

        private void Pantalla_Registro_Usuario_Load(object sender, EventArgs e)
        {
            //val.ajustarResolucion(this);
            BloquearControles();
            CargarPescadores();
            CargarNoPescadores();
            CargarMatriculas();
            CargarMunicipios();
            ObtenerImagen();
            limpiarpescador();
            cargando = false;
            Unid.Text = NombreUnidad;
        }

        public int AccionesPescador(bool registrar)
        {
            string sexo = "";
            string tipo_pes = "";
            string ocupacion = "";
            string cuerpo = "";
            foreach (RadioButton item in groupBox7.Controls.OfType<RadioButton>())
            {
                if (item.Checked)
                {
                    sexo = item.Text;
                    break;
                }
            }
            if (Unid.Text != "")
            {
                foreach (RadioButton item in TipoPesc.Controls.OfType<RadioButton>())
                {
                    if (item.Checked)
                    {
                        tipo_pes = item.Text;
                        break;
                    }
                }
                foreach (RadioButton item in OcupacionEnEmbarPesc.Controls.OfType<RadioButton>())
                {
                    if (item.Checked)
                    {
                        ocupacion = item.Text;
                        break;
                    }
                }
                foreach (RadioButton item in CuerpoDeAguaPesc.Controls.OfType<RadioButton>())
                {
                    if (item.Checked)
                    {
                        cuerpo = item.Text;
                        break;
                    }
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
            fecha = FechaVencFolio.Value.ToShortDateString().Split('/');
            string fechaVenF = "";
            i = 2;
            while (i >= 0)
            {
                fechaVenF += fecha[i];
                if (i > 0) { fechaVenF += "/"; }
                i--;
            }
            fecha = FechaExpFolio.Value.ToShortDateString().Split('/');
            string fechaExpF = "";
            i = 2;
            while (i >= 0)
            {
                fechaExpF += fecha[i];
                if (i > 0) { fechaExpF += "/"; }
                i--;
            }
            int o = 0;
            if (si.Checked)
                o = 1;
            if (RNPA != "")
            {
                DataRowView row = (DataRowView)MatriculaPesc.SelectedItem;
                pes = new Pescador(NombrePesc.Text, ApePatPescador.Text, ApeMatPescador.Text, CURPPesc.Text, RFCPesc.Text, EscolaridadPesc.Text, TSangrePesc.Text, sexo, LugarNacPesc.Text, fechaNac, CalleYNumPesc.Text, ColoniaPesc.Text, MunicipioPesc.Text, CPPesc.Text, TelefonoPesc.Text, tipo_pes, ocupacion, cuerpo, row[0].ToString(), CorreoPesc.Text, LocalidadPesc.Text, o, RNPA, Seguro.Text, FolioCred.Text, fechaVenF, fechaExpF);
                dt = proc.ChecarCapitan(RNPA, row[0].ToString());
                if (ocupacion != "Capitan" || Convert.ToInt32(dt.Rows[0]["Capitanes"].ToString()) <= 0)
                {
                    if (registrar)
                    {
                        RegistrarImagen();
                        return proc.Registrar_Pescador(pes);
                    }
                    else
                    {
                        RegistrarImagen();
                        return proc.Actualizar_Pescador(pes);
                    }
                }
                else
                {
                    return -10;
                }
            }
            else
            {
                pes = new Pescador(NombrePesc.Text, ApePatPescador.Text, ApeMatPescador.Text, CURPPesc.Text, RFCPesc.Text, EscolaridadPesc.Text, TSangrePesc.Text, sexo, LugarNacPesc.Text, fechaNac, CalleYNumPesc.Text, ColoniaPesc.Text, MunicipioPesc.Text, CPPesc.Text, TelefonoPesc.Text, tipo_pes, ocupacion, cuerpo, "NO APLICA", CorreoPesc.Text, LocalidadPesc.Text, o, "NO APLICA", Seguro.Text, FolioCred.Text, fechaVenF, fechaExpF);
                if (registrar)
                {
                    RegistrarImagen();
                    return proc.Registrar_Pescador(pes);
                }
                else
                {
                    RegistrarImagen();
                    return proc.Actualizar_Pescador(pes);
                }
            }
        }



        #region Cargar
        private void CargarMunicipios()
        {
            dt = proc.ObtenerMunicipios();
            MunicipioPesc.DataSource = dt;
            MunicipioPesc.DisplayMember = "NombreM";
            MunicipioPesc.ValueMember = "NombreM";
            MunicipioPesc.Text = "Seleccione un Municipio";
            Municipios = dt.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();
        }

        private void CargarPescadores()
        {
            if (RNPA == "")
            {
                NoOrdenados = proc.BuscarNombre("", "");
                ListaNombres.Items.Clear();
                foreach (DataRow fila in NoOrdenados.Rows)
                {
                    ListaNombres.Items.Add(fila["NOMBRE"].ToString());
                }
            }
            else
            {
                dt = proc.BuscarNombre("", RNPA);
                ListaNombres.Items.Clear();
                foreach (DataRow fila in dt.Rows)
                {
                    ListaNombres.Items.Add(fila["NOMBRE"].ToString());
                }
                dt = proc.Obtener_curp(RNPA);
                CURPPesc.DataSource = dt;
                CURPPesc.DisplayMember = "CURP";
                CURPPesc.ValueMember = "CURP";
                CURPPesc.Text = "";
            }
        }

        private void CargarNoPescadores()
        {
            NoOrdenados = proc.BuscarNombre("", "NO APLICA");
            ListaNombres2.Items.Clear();
            foreach (DataRow fila in NoOrdenados.Rows)
            {
                ListaNombres2.Items.Add(fila["NOMBRE"].ToString());
            }
        }

        private void CargarMatriculas()
        {
            if (RNPA != ""){
                dt = proc.ObtenerCertMatrXUnidad(RNPA);
                int I = 0;
                foreach (DataRow filas in dt.Rows)
                {
                    if (filas["MATRICULA"].ToString() == RNPA) { break; }
                    I++;
                }
                if (dt.Rows.Count < I)
                {
                    dt.Rows.RemoveAt(I);

                    DataRow na = dt.NewRow();
                    na["MATRICULA"] = RNPA;
                    na["NOMBREEMBARCACION"] = "NO APLICA";
                    dt.Rows.Add(na);
                }
                MatriculaPesc.DataSource = dt;
                MatriculaPesc.DisplayMember = "NOMBREEMBARCACION";
                MatriculaPesc.ValueMember = "MATRICULA";
                MatriculaPesc.Text = "";
            } }

        private void LlenarDatos(string curp)
        {
            if (!cargando)
            {
                this.Cursor = Cursors.WaitCursor;
                string c = curp;
                dt = proc.Obtener_Pescador(c);
                limpiarpescador();
                string tipopescador = "", ocupacion = "", cuerpoagua = "", matricula = "";
                int ord = 0;
                foreach (DataRow filas in dt.Rows)
                {
                    NombrePesc.Text = filas["NOMBRE"].ToString();
                    ApePatPescador.Text = filas["AP_PAT"].ToString();
                    ApeMatPescador.Text = filas["AP_MAT"].ToString();
                    RFCPesc.Text = filas["RFC"].ToString();
                    EscolaridadPesc.Text = filas["ESCOLARIDAD"].ToString();
                    LocalidadPesc.Text = "Baja California Sur";
                    TSangrePesc.Text = filas["TIPO_SANGRE"].ToString();
                    LugarNacPesc.Text = filas["LUGAR_NACIMIENTO"].ToString();
                    ColoniaPesc.Text = filas["COLONIA"].ToString();
                    CalleYNumPesc.Text = filas["CALLENUM"].ToString();
                    MunicipioPesc.Text = filas["MUNICIPIO"].ToString();
                    CPPesc.Text = filas["CODIGO_POSTAL"].ToString();
                    TelefonoPesc.Text = filas["TELEFONO"].ToString();
                    tipopescador = filas["TIPO_PESCADOR"].ToString();
                    ocupacion = filas["OCUPACION_LABORAL"].ToString();
                    cuerpoagua = filas["CUERPO_DE_AGUA"].ToString();
                    matricula = filas["MATRICULA"].ToString();
                    CorreoPesc.Text = filas["CORREO"].ToString();
                    LocalidadPesc.Text = filas["LOCALIDAD"].ToString();
                    ord = Convert.ToInt32(filas["ORDENAMIENTO"].ToString());
                    Seguro.Text = filas["SEGURO"].ToString();
                    FolioCred.Text = filas["FOLIO"].ToString();
                    FechaExpFolio.Text = filas["FECHAEXP_FOLIO"].ToString();
                    FechaVencFolio.Text = filas["FECHAVEN_FOLIO"].ToString();
                }
                if (matricula == RNPA)
                {
                    MatriculaPesc.Text = "NO APLICA";
                }
                else
                {
                    MatriculaPesc.Text = matricula;
                    for (int i = 0; i < MatriculaPesc.Items.Count; i++)
                    {
                        DataRowView row = (DataRowView)MatriculaPesc.Items[i];
                        if (row[0].ToString() == matricula)
                        {
                            MatriculaPesc.Text = row[1].ToString();
                            break;
                        }
                    }
                }

                foreach (RadioButton boton in TipoPesc.Controls)
                {
                    if (boton.Text == tipopescador)
                    {
                        boton.Checked = true;
                    }
                }
                foreach (RadioButton boton in CuerpoDeAguaPesc.Controls)
                {
                    if (boton.Text == cuerpoagua)
                    {
                        boton.Checked = true;
                    }
                }
                foreach (RadioButton boton in OcupacionEnEmbarPesc.Controls)
                {
                    if (boton.Text == ocupacion)
                    {
                        boton.Checked = true;
                    }
                }
                if (ord == 1) { si.Checked = true; }
                else { no.Checked = true; }
                CURPPesc.Text = c;
                ObtenerImagen();
                if (ListaNombres.SelectedIndex != -1)
                {
                    NOMBRES = proc.BuscarNombre(ListaNombres.SelectedItem.ToString(), "");
                    dt = proc.Obtener_todas_unidades(NOMBRES.Rows[0]["RNPTITULAR"].ToString());
                    Unid.Text = dt.Rows[0]["NOMBRE"].ToString();
                }
                
                this.Cursor = Cursors.Default;
            }
        }

        private void limpiarpescador()
        {
            Imagen.BackgroundImage = OrdenamientoPesquero.Properties.Resources.perfil;
            no.Checked = true;
            foreach (TextBox item in groupBox7.Controls.OfType<TextBox>())
            {
                item.Text = "";
            }
            foreach (MaskedTextBox item in groupBox7.Controls.OfType<MaskedTextBox>())
            {
                item.Text = "";
            }
            foreach (ComboBox item in groupBox7.Controls.OfType<ComboBox>())
            {
                item.Text = "";
            }
            MatriculaPesc.Text = "";
            Unid.Text = "";
        }

        private void BloquearControles()
        {
            if (RNPA == "")
            {
                TipoPesc.Visible = false;
                OcupacionEnEmbarPesc.Visible = false;
                CuerpoDeAguaPesc.Visible = false;
                Solicitud.Visible = true;
                Apoyo.Visible = true;
                MatriculaPesc.Enabled = false;
                groupBox4.Height = groupBox4.Height - 100;
                Botones.Location = new Point(Botones.Location.X, Botones.Location.Y - 50);
            }
        }

        private void CargarSolApo()
        {
            dt = proc.ObtenerSolicitudes(CURPPesc.Text);
            solicitudes.Text = dt.Rows.Count.ToString();

            dt = proc.ObtenerApoyos(CURPPesc.Text);
            apoyos.Text = dt.Rows.Count.ToString();

        }


        #endregion

        #region FingerPrint
        private void CargarFinger()
        {
            //Inicializar FlexCode SDK
            //reg = new FlexCodeSDK.FinFPReg();
            //reg.FPSamplesNeeded += Reg_FPSamplesNeeded;
            //reg.FPRegistrationTemplate += Reg_FPRegistrationTemplate;
            //reg.FPRegistrationImage += Reg_FPRegistrationImage;
            //reg.FPRegistrationStatus += Reg_FPRegistrationStatus;
        }
        //private void Reg_FPRegistrationStatus(RegistrationStatus Status)
        //{

        //}

        private void Reg_FPRegistrationImage()
        {

        }

        private void Reg_FPRegistrationTemplate(string FPTemplate)
        {

        }

        private void Reg_FPSamplesNeeded(short Samples)
        {

        }
        #endregion

        #region TextChanged
        private void CURPPesc_TextChanged(object sender, EventArgs e)
        {
            if (val.validarcurp(CURPPesc.Text))
            {
                pictureBox9.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
                pescador[0, 0] = "1";
                FechaNacPesc.Value = val.Fechanac(CURPPesc.Text);
                if (CURPPesc.Text[10] == 'H')
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

        private void RFCPesc_TextChanged(object sender, EventArgs e)
        {
            if (val.validarrfcPes(RFCPesc.Text))
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

        private void CPPesc_TextChanged(object sender, EventArgs e)
        {
            if (CPPesc.Text.Contains(' ') || CPPesc.Text.Length != 5)
            {
                pictureBox8.BackgroundImage = OrdenamientoPesquero.Properties.Resources.x;
                pescador[2, 0] = "0";
            }
            else
            {
                pictureBox8.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
                pescador[2, 0] = "1";
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

        private void CorreoPesc_TextChanged(object sender, EventArgs e)
        {
            if (val.validarCorreo(CorreoPesc.Text))
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

        private void CURPPesc_SelectedValueChanged(object sender, EventArgs e)
        {
            LlenarDatos(CURPPesc.Text);
        }

        private void MunicipioPesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cargando)
            {
                dt = proc.ObtenerLocalidades(Municipios[MunicipioPesc.SelectedIndex]);
                LocalidadPesc.DataSource = dt;
                LocalidadPesc.DisplayMember = "NombreL";
                LocalidadPesc.ValueMember = "NombreL";
                LocalidadPesc.Text = "Seleccione un Municipio";
            }
        }

        private void MatriculaPesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MatriculaPesc.Text == "NO APLICA")
            {
                radioButton1.Checked = true;
                radioButton4.Checked = true;
            }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            MatriculaPesc.SelectedText = "NO APLICA";
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            MatriculaPesc.SelectedText = "NO APLICA";
        }
        #endregion


        #region KeyPress
        private void CURPPesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void MatriculaPesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion


        #region Click
        private void EliminarUnidad_Click(object sender, EventArgs e)
        {
            DialogResult Si = MessageBox.Show("¿Desea eliminar este Pescador?", "ADVERTENCIA", MessageBoxButtons.YesNo);
            if (Si == DialogResult.Yes)
            {
                exito = proc.Eliminar_Pescador(CURPPesc.Text);
                if (exito > 0) { limpiarpescador(); exito = 0; }
                CargarPescadores();
                CargarNoPescadores();
            }
        }

        private void RegistrarUnidad_Click(object sender, EventArgs e)
        {
            if (CURPPesc.Text != "")
            {
                if (!val.validaralgo(pescador))
                {
                }
                else
                {
                    exito = AccionesPescador(true);
                }
                val.Exito(exito);
                exito = 0;
                CargarPescadores();
                CargarNoPescadores();
            }
            else { MessageBox.Show("No se puede registrar un pescador sin CURP"); }
        }

        private void ActualizarUnidad_Click(object sender, EventArgs e)
        {
            if (!val.validaralgo(pescador))
            {
            }
            else
            {
                exito = AccionesPescador(false);
            }
            val.Exito(exito);
            exito = 0;
            CargarPescadores();
            CargarNoPescadores();
        }

        private void CURPPesc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dt = proc.Obtener_Pescador(CURPPesc.Text);
            limpiarpescador();
            string tipopescador = "", ocupacion = "", cuerpoagua = "";
            foreach (DataRow filas in dt.Rows)
            {
                NombrePesc.Text = filas["NOMBRE"].ToString();
                ApePatPescador.Text = filas["AP_PAT"].ToString();
                ApeMatPescador.Text = filas["AP_MAT"].ToString();
                RFCPesc.Text = filas["RFC"].ToString();
                EscolaridadPesc.Text = filas["ESCOLARIDAD"].ToString();
                LocalidadPesc.Text = "Baja California Sur";
                TSangrePesc.Text = filas["TIPO_SANGRE"].ToString();
                LugarNacPesc.Text = filas["LUGAR_NACIMIENTO"].ToString();
                ColoniaPesc.Text = filas["COLONIA"].ToString();
                CalleYNumPesc.Text = filas["CALLENUM"].ToString();
                MunicipioPesc.Text = filas["MUNICIPIO"].ToString();
                CPPesc.Text = filas["CODIGO_POSTAL"].ToString();
                TelefonoPesc.Text = filas["TELEFONO"].ToString();
                tipopescador = filas["TIPO_PESCADOR"].ToString();
                ocupacion = filas["OCUPACION_LABORAL"].ToString();
                cuerpoagua = filas["CUERPO_DE_AGUA"].ToString();
                MatriculaPesc.Text = filas["MATRICULA"].ToString();
                CorreoPesc.Text = filas["CORREO"].ToString();
            }
            foreach (RadioButton boton in TipoPesc.Controls)
            {
                if (boton.Text == tipopescador)
                {
                    boton.Checked = true;
                }
            }
            foreach (RadioButton boton in CuerpoDeAguaPesc.Controls)
            {
                if (boton.Text == cuerpoagua)
                {
                    boton.Checked = true;
                }
            }
            foreach (RadioButton boton in OcupacionEnEmbarPesc.Controls)
            {
                if (boton.Text == ocupacion)
                {
                    boton.Checked = true;
                }
            }
        }

        private void Ver_Click(object sender, EventArgs e)
        {
            Vistas vista = new Vistas(CURPPesc.Text, RNPA, 4);
            vista.ShowDialog();
        }

        private void limpiar_Click(object sender, EventArgs e)
        {
            limpiarpescador();
        }
        #endregion


        #region Imagen
        private void CargarImagen_Click_1(object sender, EventArgs e)
        {
            if (CURPPesc.Text != "")
            {
                DialogResult result = MessageBox.Show("Desea capturar una nueva imagen?", "¿?", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    Pantalla_Fotografia pf = new Pantalla_Fotografia(CURPPesc.Text);
                    pf.ShowDialog();
                    ObtenerImagen();
                }
                else if (result == DialogResult.No)
                {
                    result = MessageBox.Show("Desea subir una nueva imagen?", "¿?", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                Bitmap bmp = new Bitmap(Image.FromFile(openFileDialog1.FileName));
                                Bitmap bmp2 = new Bitmap(bmp, new Size(131, 182));
                                Imagen.BackgroundImage = bmp2;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        Imagen.BackgroundImage = OrdenamientoPesquero.Properties.Resources.perfil;
                    }
                }
            }
        }

        private void ObtenerImagen()
        {
            Imagen.BackgroundImage = null;
            dt = proc.ObtenerImagen(CURPPesc.Text);
            if (dt.Rows.Count > 0)
            {
                Imagen.BackColor = Color.White;
                Imagen.BackgroundImage = null;
                imagenBuffer = (byte[])dt.Rows[0]["IMAGEN"];
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
                Imagen.BackgroundImage = (Image.FromStream(ms));
                Imagen.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        private void RegistrarImagen()
        {
            if (Imagen.BackgroundImage != null)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                Imagen.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                //System.Drawing.Image fullsizeImage = System.Drawing.Image.FromStream(ms);
                //System.Drawing.Image newImage = fullsizeImage.GetThumbnailImage(131, 182, null, IntPtr.Zero);
                //System.IO.MemoryStream myResult = new System.IO.MemoryStream();
                //newImage.Save(myResult, System.Drawing.Imaging.ImageFormat.Gif);

                int exito = proc.InsertarImagen(CURPPesc.Text, ms.GetBuffer());
                if (exito > 0)
                {
                    MessageBox.Show("Imagen Insertada correctamente");
                }
            }
        }
        #endregion


        #region Busquedas
        DataTable NOMBRES = new DataTable();

        private void BuscarNombre_TextChanged_1(object sender, EventArgs e)
        {
            string x = BuscarNombre.Text;
            NOMBRES = proc.BuscarNombre(x, RNPA);
            ListaNombres.Items.Clear();
            foreach (DataRow fila in NOMBRES.Rows)
            {
                ListaNombres.Items.Add(fila["NOMBRE"].ToString());
            }
        }

        private void BuscarNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                NOMBRES = proc.BuscarNombre("", RNPA);
                ListaNombres.Items.Clear();
                foreach (DataRow fila in NOMBRES.Rows)
                {
                    ListaNombres.Items.Add(fila["NOMBRE"].ToString());
                }
            }
        }

        private void Solicitud_Click(object sender, EventArgs e)
        {
            if (Ord != -1)
            {
                string Nombre = "";
                if (Ord == 1) { Nombre = ListaNombres.Text; } else { Nombre = ListaNombres2.Text; }
                Pantalla_Solicitudes pantalla = new Pantalla_Solicitudes(Nombre, CURPPesc.Text,false);
                pantalla.ShowDialog();
            }
            CargarSolApo();
        }
        private void Apoyo_Click(object sender, EventArgs e)
        {
            if (Ord != -1)
            {
                string Nombre = "";
                if (Ord == 1) { Nombre = ListaNombres.Text; } else { Nombre = ListaNombres2.Text; }
                Pantalla_Solicitudes pantalla = new Pantalla_Solicitudes(Nombre, CURPPesc.Text, true);
                pantalla.ShowDialog();
            }
            CargarSolApo();
        }

        int Ord = -1;
        private void ListaNombres_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ListaNombres.SelectedIndex != -1)
            {
                Ord = 1;
                ListaNombres2.SelectedIndex = -1;
                if (RNPA == "")
                {
                    NOMBRES = proc.BuscarNombre(ListaNombres.SelectedItem.ToString(), "");
                    LlenarDatos(NOMBRES.Rows[0]["CURP"].ToString());
                }
                else
                {
                    NOMBRES = proc.BuscarNombre(ListaNombres.SelectedItem.ToString(), RNPA);
                    LlenarDatos(NOMBRES.Rows[0]["CURP"].ToString());
                }
                CargarSolApo();
            }            
        }

        private void ListaNombres2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ListaNombres2.SelectedIndex != -1)
            {
                Ord = 0;
                ListaNombres.SelectedIndex = -1;
                if (RNPA == "")
                { LlenarDatos(NoOrdenados.Rows[ListaNombres2.SelectedIndex]["CURP"].ToString()); }
                else
                {
                    LlenarDatos(NoOrdenados.Rows[ListaNombres2.SelectedIndex]["CURP"].ToString());
                }
            }

        }

        private void BuscarNombre2_TextChanged(object sender, EventArgs e)
        {
            string x = BuscarNombre2.Text;
            NoOrdenados = proc.BuscarNombre(x, "");
            ListaNombres2.Items.Clear();
            foreach (DataRow fila in NoOrdenados.Rows)
            {
                ListaNombres.Items.Add(fila["NOMBRE"].ToString());
            }
        }
        #endregion


       

      
    }
}
