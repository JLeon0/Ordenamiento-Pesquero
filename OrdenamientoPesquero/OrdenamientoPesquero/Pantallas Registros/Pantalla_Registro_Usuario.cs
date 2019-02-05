﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Logica;
using OrdenamientoPesquero.Pantallas_Registros;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;
using DPUruNet;

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
            limpiarpescador();
            cargando = false;
            if (NombreUnidad != "NO APLICA")
            {
                Unid.Text = NombreUnidad;
            }
            //CargarFinger();
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
            if (Unid.Text != "NO APLICA")
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
                pes = new Pescador(NombrePesc.Text, ApePatPescador.Text, ApeMatPescador.Text, CURPPesc.Text.Replace(" ", ""), RFCPesc.Text.Replace(" ", ""), EscolaridadPesc.Text, TSangrePesc.Text, sexo, LugarNacPesc.Text, fechaNac, CalleYNumPesc.Text, ColoniaPesc.Text, MunicipioPesc.Text, CPPesc.Text, TelefonoPesc.Text, tipo_pes, ocupacion, cuerpo, row[0].ToString().Replace(" ", ""), CorreoPesc.Text, LocalidadPesc.Text, o, RNPA.Replace(" ", ""), Seguro.Text, FolioCred.Text, fechaVenF, fechaExpF);
                dt = proc.ChecarCapitan(RNPA, row[0].ToString());
                if (ocupacion != "Capitan" || dt.Rows.Count <= 0 || ocupacion == "Capitan" && dt.Rows[0]["CURP"].ToString() == CURPPesc.Text)
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
                string R = "NO APLICA";
                if (ListaNombres.SelectedIndex > -1) { NOMBRES = proc.BuscarNombre(ListaNombres.SelectedItem.ToString(), ""); R = NOMBRES.Rows[0]["RNPTITULAR"].ToString(); }
                pes = new Pescador(NombrePesc.Text, ApePatPescador.Text, ApeMatPescador.Text, CURPPesc.Text.Replace(" ", ""), RFCPesc.Text.Replace(" ", ""), EscolaridadPesc.Text, TSangrePesc.Text, sexo, LugarNacPesc.Text, fechaNac, CalleYNumPesc.Text, ColoniaPesc.Text, MunicipioPesc.Text, CPPesc.Text, TelefonoPesc.Text, tipo_pes, ocupacion, cuerpo, "NO APLICA", CorreoPesc.Text, LocalidadPesc.Text, o, R, Seguro.Text, FolioCred.Text, fechaVenF, fechaExpF);
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
            }
            lblP.Text = "PESCADORES  " + ListaNombres.Items.Count;
        }

        private void CargarNoPescadores()
        {
            NoOrdenados = proc.BuscarNombre("", "NO APLICA");
            ListaNombres2.Items.Clear();
            foreach (DataRow fila in NoOrdenados.Rows)
            {
                ListaNombres2.Items.Add(fila["NOMBRE"].ToString());
            }
            lblNo.Text = "NO ORDENADOS  " + ListaNombres2.Items.Count;
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
                if (dt.Rows.Count <= I || I == 0)
                {
                    if (dt.Rows.Count > I) { dt.Rows.RemoveAt(I); }

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
                    NOMBRES = proc.BuscarNombre(ListaNombres.SelectedItem.ToString(), RNPA);
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
                EliminarUnidad.Visible = false;
                label4.Visible = false;
                TipoPesc.Visible = false;
                OcupacionEnEmbarPesc.Visible = false;
                CuerpoDeAguaPesc.Visible = false;
                Solicitud.Visible = true;
                Apoyo.Visible = true;
                MatriculaPesc.Enabled = false;
                Credencial.Visible = false;
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
                pictureBox9.BackgroundImage = OrdenamientoPesquero.Properties.Resources.Equis;
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
                pictureBox7.BackgroundImage = OrdenamientoPesquero.Properties.Resources.Equis;
                pescador[1, 0] = "0";
            }
        }

        private void CPPesc_TextChanged(object sender, EventArgs e)
        {
            if (CPPesc.Text.Contains(' ') || CPPesc.Text.Length != 5)
            {
                pictureBox8.BackgroundImage = OrdenamientoPesquero.Properties.Resources.Equis;
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
                pictureBox5.BackgroundImage = OrdenamientoPesquero.Properties.Resources.Equis;
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
                pictureBox6.BackgroundImage = OrdenamientoPesquero.Properties.Resources.Equis;
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
            DialogResult Si = MessageBox.Show("¿Desea eliminar este Pescador de la Unidad?", "ADVERTENCIA", MessageBoxButtons.YesNo);
            if (Si == DialogResult.Yes)
            {
                exito = proc.Eliminar_Pescador(CURPPesc.Text, 1);
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
                    Pantalla_Fotografia pf = new Pantalla_Fotografia(CURPPesc.Text,Firma.BackgroundImage,Huella.BackgroundImage);
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
                        catch (Exception)
                        {
                            MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        if (Imagen.BackgroundImage == null)
                        { Imagen.BackgroundImage = OrdenamientoPesquero.Properties.Resources.perfil; }
                    }
                }
               
            }
        }

        private void ObtenerImagen()
        {
            Imagen.BackgroundImage = null;
            Firma.BackgroundImage = null;
            Huella.BackgroundImage = null;
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
            dt = proc.ObtenerFirma(CURPPesc.Text);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    Firma.BackColor = Color.White;
                    Firma.BackgroundImage = null;
                    imagenBuffer = (byte[])dt.Rows[0]["FIRMA"];
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
                    Firma.BackgroundImage = (Image.FromStream(ms));
                    Firma.BackgroundImageLayout = ImageLayout.Zoom;

                    Huella.BackColor = Color.White;
                    Huella.BackgroundImage = null;
                    imagenBuffer = (byte[])dt.Rows[0]["HUELLA"];
                    ms = new System.IO.MemoryStream(imagenBuffer);
                    Huella.BackgroundImage = (Image.FromStream(ms));
                }
                catch (Exception MS) { }
            }
        }

        private void RegistrarImagen()
        {
            if (Imagen.BackgroundImage != null)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                Imagen.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                System.IO.MemoryStream firma = new MemoryStream();
                if (Firma.BackgroundImage != null)
                { Firma.BackgroundImage.Save(firma, System.Drawing.Imaging.ImageFormat.Jpeg); }

                System.IO.MemoryStream huella = new MemoryStream();
                if(Huella.BackgroundImage != null)
                { Huella.BackgroundImage.Save(huella, System.Drawing.Imaging.ImageFormat.Jpeg); }

                //System.Drawing.Image fullsizeImage = System.Drawing.Image.FromStream(ms);
                //System.Drawing.Image newImage = fullsizeImage.GetThumbnailImage(131, 182, null, IntPtr.Zero);
                //System.IO.MemoryStream myResult = new System.IO.MemoryStream();
                //newImage.Save(myResult, System.Drawing.Imaging.ImageFormat.Gif);

                int exito = proc.InsertarImagen(CURPPesc.Text, ms.GetBuffer(), firma.GetBuffer(), huella.GetBuffer());
                if (exito > 0)
                {
                    MessageBox.Show("Imagen Insertada correctamente");
                }
            }
        }

        private void CargarFirma_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea capturar la firma del usuario?", "¿?", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                Process.Start("C:\\Windows\\SigPlus\\DemoOCX.exe");
                result = MessageBox.Show("Ya ha capturado la firma del usuario?", "¿?", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    Bitmap bmp = new Bitmap(Image.FromFile(mdoc + "\\FIRMA\\FIRMA.PNG"));
                    Firma.BackgroundImage = bmp;
                    Firma.BackgroundImageLayout = ImageLayout.Zoom;
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
                NOMBRES = proc.BuscarNombre(ListaNombres.SelectedItem.ToString(), RNPA);
                LlenarDatos(NOMBRES.Rows[0]["CURP"].ToString());
                CargarSolApo();
            }
        }

        private void Credencial_Click(object sender, EventArgs e)
        {
            Vistas v = new Vistas(CURPPesc.Text, NombreUnidad, 4);
            v.Show(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult Si = MessageBox.Show("¿Desea eliminar este Pescador de forma definitiva?", "ADVERTENCIA", MessageBoxButtons.YesNo);
            if (Si == DialogResult.Yes)
            {
                exito = proc.Eliminar_Pescador(CURPPesc.Text, 0);
                if (exito > 0)
                { val.Exito(-21); limpiarpescador(); exito = 0; }
                CargarPescadores();
                CargarNoPescadores();
            }
        }
        

        private void ListaNombres2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ListaNombres2.SelectedIndex != -1)
            {
                Ord = 0;
                ListaNombres.SelectedIndex = -1;
                LlenarDatos(NoOrdenados.Rows[ListaNombres2.SelectedIndex]["CURP"].ToString());
            }

        }

        private void BuscarNombre2_TextChanged(object sender, EventArgs e)
        {
            string x = BuscarNombre2.Text;
            NoOrdenados = proc.BuscarNombre(x, "NO APLICA");
            ListaNombres2.Items.Clear();
            foreach (DataRow fila in NoOrdenados.Rows)
            {
                ListaNombres2.Items.Add(fila["NOMBRE"].ToString());
            }
        }
        #endregion



        #region Lector de Huellas
        private Reader currentReader;
        public Reader CurrentReader
        {
            get { return currentReader; }
            set { currentReader = value; }
        }

        public bool streamingOn;

        private void CargarHuella_Click(object sender, EventArgs e)
        {
            ReaderCollection _readers;
            try
            {
                _readers = ReaderCollection.GetReaders();
                foreach (Reader Reader in _readers)
                {
                    CurrentReader = _readers[0];
                    Huella.BackColor = Color.LightGreen;
                }
                CARGAR();
                MessageBox.Show("Coloque el dedo sobre el sensor");
            }
            catch (Exception) { MessageBox.Show("Hubo un problema con el sensor, retirelo y vuelva a insertarlo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private bool backEnabled = false;

        private bool reset = false;

        private bool threadHandle_lock = false;

        private Thread threadHandle;
        private void CARGAR()
        {        
            

            Constants.ResultCode result = Constants.ResultCode.DP_DEVICE_FAILURE;

            result = CurrentReader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE);

            if (result != Constants.ResultCode.DP_SUCCESS)
            {
                MessageBox.Show("Error:  " + result.ToString());
                if (CurrentReader != null)
                {
                    CurrentReader.Dispose();
                    CurrentReader = null;
                }
                return;
            }
            Huella.BackgroundImage = null;

            this.Text = "Capture";
            threadHandle = new Thread(CaptureThread);
            threadHandle.IsBackground = true;
            threadHandle.Start();
        }

        private void CaptureThread()
        {
            reset = false;
            while (!reset)
            {
                Fid fid = null;

                if (!CaptureFinger(ref fid))
                {
                    break;
                }

                if (fid == null)
                {
                    continue;
                }

                foreach (Fid.Fiv fiv in fid.Views)
                {
                    SendMessage(CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height));
                }
            }

            if (CurrentReader != null)
                CurrentReader.Dispose();
        }

        public Bitmap CreateBitmap(byte[] bytes, int width, int height)
        {
            byte[] rgbBytes = new byte[bytes.Length * 3];

            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                rgbBytes[(i)] = bytes[i];
                rgbBytes[(i) + 1] = bytes[i];
                rgbBytes[(i) + 2] = bytes[i];
            }
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            for (int i = 0; i <= bmp.Height - 1; i++)
            {
                IntPtr p = new IntPtr(data.Scan0.ToInt32() + data.Stride * i);
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3);
            }

            bmp.UnlockBits(data);

            return bmp;
        }

        private delegate void SendMessageCallback(object payload);

        private void SendMessage(object payload)
        {
            try
            {
                if (this.Huella.InvokeRequired)
                {
                    SendMessageCallback d = new SendMessageCallback(SendMessage);
                    this.Invoke(d, new object[] { payload });
                }
                else
                {
                    Huella.BackgroundImage = (Bitmap)payload;
                    Huella.Refresh();
                }
            }
            catch (Exception)
            {
            }
        }

        public bool CaptureFinger(ref Fid fid)
        {
            try
            {
                Constants.ResultCode result = currentReader.GetStatus();

                if ((result != Constants.ResultCode.DP_SUCCESS))
                {
                    MessageBox.Show("Get Status Error:  " + result);
                    if (CurrentReader != null)
                    {
                        CurrentReader.Dispose();
                        CurrentReader = null;
                    }
                    return false;
                }

                if ((currentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_BUSY))
                {
                    Thread.Sleep(50);
                    return true;
                }
                else if ((currentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_NEED_CALIBRATION))
                {
                    currentReader.Calibrate();
                }
                else if ((currentReader.Status.Status != Constants.ReaderStatuses.DP_STATUS_READY))
                {
                    MessageBox.Show("Get Status:  " + currentReader.Status.Status);
                    if (CurrentReader != null)
                    {
                        CurrentReader.Dispose();
                        CurrentReader = null;
                    }
                    return false;
                }

                CaptureResult captureResult = currentReader.Capture(Constants.Formats.Fid.ANSI, Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT, 5000, currentReader.Capabilities.Resolutions[0]);

                if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    MessageBox.Show("Error:  " + captureResult.ResultCode);
                    if (CurrentReader != null)
                    {
                        CurrentReader.Dispose();
                        CurrentReader = null;
                    }
                    return false;
                }

                if (captureResult.Quality == Constants.CaptureQuality.DP_QUALITY_CANCELED)
                {
                    return false;
                }

                if ((captureResult.Quality == Constants.CaptureQuality.DP_QUALITY_NO_FINGER || captureResult.Quality == Constants.CaptureQuality.DP_QUALITY_TIMED_OUT))
                {
                    return true;
                }

                if ((captureResult.Quality == Constants.CaptureQuality.DP_QUALITY_FAKE_FINGER))
                {
                    MessageBox.Show("Quality Error:  " + captureResult.Quality);
                    return true;
                }

                fid = captureResult.Data;

                return true;
            }
            catch
            {
                MessageBox.Show("An error has occurred.");
                if (CurrentReader != null)
                {
                    CurrentReader.Dispose();
                    CurrentReader = null;
                }
                return false;
            }
        }

        #endregion
    }
}
