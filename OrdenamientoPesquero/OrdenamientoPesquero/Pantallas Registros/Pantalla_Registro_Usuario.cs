using System;
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
        int exito = 0, NIVEL;
        bool cargando = true, img = false, hue = false, firm = false;
        Pescador pes;
        Procedimientos proc = new Procedimientos();
        Validaciones val = new Validaciones();
        DataTable dt, NoOrdenados, Embarcaciones;
        string RNPA = "", NombreUnidad = "", Usuario = "", NombreUsuario = "", BD="";
        string[] Municipios;
        byte[] imagenBuffer;
        string matricula = "";
        Bitmap huell;

        public Pantalla_Registro_Usuario(string rnpa, string nombre, int tipo, string user, string nombreuser, int nivel, string bdd)
        {
            InitializeComponent();
            //this.Height = Convert.ToInt32(System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height * .96);
            RNPA = rnpa;
            if (RNPA == "")
            { uni.Visible = true; uni2.Visible = true; }
            NombreUnidad = nombre;
            if (tipo == 1)
            { TipoSocio.Enabled = false; TipoExtra.Enabled = false; }
            else if(tipo== 0) { TipoTitular.Enabled = false; TipoEventual.Enabled = false; }
            Usuario = user;
            NombreUsuario = nombreuser;
            NIVEL = nivel;
            CargarLogos();
            BD = bdd;
        }
        private void CargarLogos()
        {
            //Logo.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Logo.png"));
            //Logo1.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Logo.png"));
        }

        private void Pantalla_Registro_Usuario_Load(object sender, EventArgs e)
        {
            proc.bdd = BD;
            proc.cambiarbd(proc.bdd);
            //val.ajustarResolucion(this);
            if (NIVEL == 0 || NIVEL == 4)
            {
                ActivarPanelCURP.Visible = true;
                gbBotones.Visible = true;
                limpiar.Visible = true;
                CargarFirma.Enabled = true;
                CargarHuella.Enabled = true;
                CargarImagen.Enabled = true;
            }
            if (NIVEL == 0)
            {
                EliminarRegistro.Visible = true;
                label12.Visible = true;
            }
            Bienvenido.Text += NombreUsuario;
            BloquearControles();
            CargarNoPescadores();
            CargarPescadores();
            CargarMatriculas();
            CargarMunicipios();
            limpiarpescador(); 
            cargando = false;
            if (NombreUnidad != "NO APLICA")
            {
                Unid.Text = NombreUnidad;
            }
        }
        private void BloquearControles()
        {
            if (RNPA == "")
            {
                btnEntregar.Visible = true;
                EliminarUnidad.Visible = false;
                label4.Visible = false;
                TipoPesc.Visible = false;
                OcupacionEnEmbarPesc.Visible = false;
                CuerpoDeAguaPesc.Visible = false;
                Solicitud.Visible = true;
                Apoyo.Visible = true;
                MatriculaPesc.Enabled = false;
                Credencial.Visible = false;
                gbRelacion.Height = gbRelacion.Height - 100;
                gbOtros.Location = new Point(gbOtros.Location.X, gbOtros.Location.Y - 50);
                gbBotones.Location = new Point(gbBotones.Location.X, gbBotones.Location.Y - 50);
                this.Text = "Apoyos y Solicitudes";
            }
            else
            {
                Solicitud.Visible = false;
                Apoyo.Visible = false;
            }
        }


        public int AccionesPescador(bool registrar)
        {
            string sexo = "";
            string tipo_pes = "";
            string ocupacion = "";
            string cuerpo = "";
            foreach (RadioButton item in gbDatosGenerales.Controls.OfType<RadioButton>())
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
                if (MatriculaPesc.Text == "NO APLICA") { ocupacion = "Sin Actividad"; }
                pes = new Pescador(NombrePesc.Text, ApePatPescador.Text, ApeMatPescador.Text, CURPPesc.Text.Replace(" ", ""), RFCPesc.Text.Replace(" ", ""), EscolaridadPesc.Text, TSangrePesc.Text, sexo, LugarNacPesc.Text, fechaNac, CalleYNumPesc.Text, ColoniaPesc.Text, MunicipioPesc.Text, CPPesc.Text, TelefonoPesc.Text, tipo_pes, ocupacion, cuerpo, row[0].ToString().Replace(" ", ""), CorreoPesc.Text, LocalidadPesc.Text, o, RNPA.Replace(" ", ""), Seguro.Text, fechaVenF, fechaExpF);
                int ret=0;
                if (ChecarBuzosXEquipoBuceo(ocupacion,row,ref ret))
                {
                    if (ChecarCapitan(ocupacion, row, ref ret) && ChecarMarineros(ocupacion, row, ref ret) && ChecarBuzo(ocupacion, row, ref ret) || MatriculaPesc.Text == "NO APLICA")
                    {
                        if (registrar)
                        {
                            RegistrarImagen();
                            proc.reg_uni(pes.CURP, uni2.Text);
                            exito = proc.Registrar_Pescador(pes);
                            if (exito > 0)
                            {
                                LlenarDatos(pes.CURP);
                                return 1;
                            }
                            else return exito;
                        }
                        else
                        {
                            RegistrarImagen();
                            proc.act_uni(pes.CURP, uni2.Text);
                            return proc.Actualizar_Pescador(pes);
                        }
                    }
                }
                return ret;
            }
            else
            {
                string R = "NO APLICA";
                if (ListaNombres.SelectedIndex > -1 && RNPA != "") { NOMBRES = proc.BuscarNombre(ListaNombres.SelectedItem.ToString(), ""); R = NOMBRES.Rows[0]["RNPTITULAR"].ToString(); }
                string matricula = "";
                if(MatriculaPesc.Text == "NO APLICA") { matricula = "NO APLICA"; } else { matricula = MatriculaRelacion.Text; }
                pes = new Pescador(NombrePesc.Text, ApePatPescador.Text, ApeMatPescador.Text, CURPPesc.Text.Replace(" ", ""), RFCPesc.Text.Replace(" ", ""), EscolaridadPesc.Text, TSangrePesc.Text, sexo, LugarNacPesc.Text, fechaNac, CalleYNumPesc.Text, ColoniaPesc.Text, MunicipioPesc.Text, CPPesc.Text, TelefonoPesc.Text, "", "Sin Actividad", "", matricula, CorreoPesc.Text, LocalidadPesc.Text, 0, R, Seguro.Text, fechaVenF, fechaExpF);
                if (registrar)
                {
                    RegistrarImagen();
                    proc.reg_uni(pes.CURP, uni2.Text);
                    exito = proc.Registrar_Pescador(pes);
                    if (exito > 0)
                    {
                        LlenarDatos(pes.CURP);
                        return 1;
                    }
                    else return exito;
                }
                else
                {
                    RegistrarImagen();
                    proc.act_uni(pes.CURP, uni2.Text);
                    return proc.Actualizar_Pescador(pes);
                }
            }
        }

        private bool ChecarCapitan(string ocupacion, DataRowView row,ref int ret)
        {
            dt = proc.ChecarCapitan(RNPA, row[0].ToString());
            if (ocupacion != "Capitan" || dt.Rows.Count <= 0 || ocupacion == "Capitan" && dt.Rows[0]["CURP"].ToString() == CURPPesc.Text)
            { return true; }
            else { ret = -10; return false; }
        }
        private bool ChecarMarineros(string ocupacion, DataRowView row,ref int ret)
        {
            dt = proc.ChecarMarineros(RNPA, row[0].ToString());
            if (ocupacion == "Marinero")
            {
                if (dt.Rows.Count <= 2 && Ribereño.Checked == true || dt.Rows.Count <= 5 && FlotasCos.Checked == true)
                {
                    if (dt.Rows.Count == 2 && Ribereño.Checked == true || dt.Rows.Count == 5 && FlotasCos.Checked == true)
                    {
                        foreach (DataRow fila in dt.Rows)
                        {
                            if (fila[0].ToString() == CURPPesc.Text)
                            {
                                return true;
                            }
                        }
                    }
                    else { return true; }

                    ret = -13;
                    return false;
                }
                else { ret = -13; return false; }
            }
            else { return true; }
        }
        private bool ChecarBuzo(string ocupacion, DataRowView row, ref int ret)
        {
            dt = proc.ChecarBuzo(RNPA, row[0].ToString());
            DataTable embarcaciones = proc.EmbarcaXPermisosBuceo(RNPA);
            if(ocupacion == "Buzo")
            {
                bool acceso = false;
                foreach (DataRow fila in embarcaciones.Rows)
                {
                    if (fila[0].ToString() == MatriculaPesc.SelectedValue.ToString()) { acceso = true; break; }
                }
                if (acceso)
                {
                    if (dt.Rows.Count <= 1)
                    {
                        if (dt.Rows.Count == 0) { return true; }
                        foreach (DataRow fila in dt.Rows)
                        {
                            if (fila[0].ToString() == CURPPesc.Text)
                            {
                                return true;
                            }
                        }
                        ret = -14;
                        return false;
                    }
                    else { ret = -14; return false; }
                }
                else { ret = -15; return false; }
            }
            else { return true; }
        }
        private bool ChecarBuzosXEquipoBuceo(string ocupacion, DataRowView row, ref int ret)
        {
            DataTable buzos = proc.ChecarBuzosXEquipoBuceo(RNPA);
            if (ocupacion == "Buzo")
            {
                if (buzos.Rows.Count == 0) { return true; }
                if (buzos.Rows.Count >= Convert.ToInt32(buzos.Rows[0][0].ToString()))
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        if (fila[0].ToString() == CURPPesc.Text)
                        {
                            return true;
                        }
                    }
                    ret = -16; return false;
                }
                return true;
            }
            else
            { return true; }
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
                dt = proc.BuscarNombre("", "");
                NoOrdenados = proc.BuscarNombre("", "NO APLICA");
                lblP.Text = "TOTAL PESCADORES  " + dt.Rows.Count;
                lblNo.Text = "POR ASIGNAR A UNA U.E. " + NoOrdenados.Rows.Count;
                dt.Merge(NoOrdenados);
                NoOrdenados = dt;
                DataView view = new DataView(dt)
                { Sort = "CURP" };
                ListaNombres.DataSource = view;
                ListaNombres.ValueMember = "CURP";
                ListaNombres.DisplayMember = "CURP";

                ListaNombres2.DataSource = dt;
                ListaNombres2.ValueMember = "CURP";
                ListaNombres2.DisplayMember = "NOMBRE";
                ListaNombres2.ClearSelected();
            }
            else
            {
                dt = proc.BuscarNombre("", RNPA);
                ListaNombres.DataSource = dt;
                ListaNombres.ValueMember = "CURP";
                ListaNombres.DisplayMember = "NOMBRE";
                lblP.Text = "PESCADORES  " + ListaNombres.Items.Count;
            }
            ListaNombres.ClearSelected();
        }

        private void CargarNoPescadores()
        {
            if (RNPA != "")
            {
                NoOrdenados = proc.BuscarNombre("", "NO APLICA");
                ListaNombres2.DataSource = NoOrdenados;
                ListaNombres2.ValueMember = "CURP";
                ListaNombres2.DisplayMember = "NOMBRE";
                lblNo.Text = "POR ASIGNAR A UNA U.E. " + ListaNombres2.Items.Count;
                ListaNombres2.ClearSelected();
            }
        }

        private void CargarMatriculas()
        {
            if (RNPA != "")
            {
                Embarcaciones = proc.ObtenerCertMatrXUnidad(RNPA);
                int I = 0;
                foreach (DataRow filas in Embarcaciones.Rows)
                {
                    if (filas["MATRICULA"].ToString() == RNPA) { break; }
                    I++;
                }
                if (Embarcaciones.Rows.Count <= I || I == 0)
                {
                    if (Embarcaciones.Rows.Count > I) { Embarcaciones.Rows.RemoveAt(I); }

                    DataRow na = Embarcaciones.NewRow();
                    na["MATRICULA"] = RNPA;
                    na["NOMBREEMBARCACION"] = "NO APLICA";
                    Embarcaciones.Rows.Add(na);
                }
                MatriculaPesc.DataSource = Embarcaciones;
                MatriculaPesc.DisplayMember = "NOMBREEMBARCACION";
                MatriculaPesc.ValueMember = "MATRICULA";
                MatriculaPesc.Text = "";
                MatriculaRelacion.Text = "-----";
            }
            else
            {
                Embarcaciones = proc.ObtenerTodasEmbarcaciones();
                MatriculaPesc.DataSource = Embarcaciones;
                MatriculaPesc.DisplayMember = "NOMBREEMBARCACION";
                MatriculaPesc.ValueMember = "MATRICULA";
                MatriculaPesc.Text = "NO APLICA";
                MatriculaRelacion.Text = "-----";
            }
        }

        private void LlenarDatos(string curp)
        {
            if (!cargando)
            {
                this.Cursor = Cursors.WaitCursor;
                string c = curp;
                dt = proc.Obtener_Pescador(c);
                DataTable dt2 = proc.obt_uni(c);
                limpiarpescador();
                if (dt2.Rows.Count != 0)
                {
                    uni2.Text = dt2.Rows[0]["UNIDAD"].ToString();
                }
                string tipopescador = "", ocupacion = "", cuerpoagua = "";
                matricula = "";
                int ord = 0;
                foreach (DataRow filas in dt.Rows)
                {
                    NombrePesc.Text = filas["NOMBRE"].ToString();
                    ApePatPescador.Text = filas["AP_PAT"].ToString();
                    ApeMatPescador.Text = filas["AP_MAT"].ToString();
                    RFCPesc.Text = filas["RFC"].ToString();
                    EscolaridadPesc.Text = filas["ESCOLARIDAD"].ToString();
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
                    FechaVencFolio.Text = filas["FECHAVEN_FOLIO"].ToString();
                }
                if (matricula == RNPA)
                {
                    MatriculaPesc.Text = "NO APLICA";
                }
                else
                {
                    if (matricula != "NO APLICA")
                    {
                        for (int i = 0; i < MatriculaPesc.Items.Count; i++)
                        {
                            DataRowView row = (DataRowView)MatriculaPesc.Items[i];
                            if (row[0].ToString() == matricula)
                            {
                                MatriculaPesc.Text = row[1].ToString();
                                break;
                            }
                        }
                        if (matricula != "NO APLICA") { MatriculaRelacion.Text = matricula; }
                        else { MatriculaRelacion.Text = "-----"; }
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
                { NOMBRES = proc.BuscarNombre(ListaNombres.Text, RNPA); }
                else if (ListaNombres2.SelectedIndex != -1)
                { NOMBRES = proc.BuscarNombre(ListaNombres2.Text, RNPA); }
                if (NOMBRES.Rows.Count > 0 && NOMBRES.Rows[0][2].ToString() != "NO APLICA")
                {
                    dt = proc.Obtener_todas_unidades(NOMBRES.Rows[0][2].ToString());
                    Unid.Text = dt.Rows[0]["NOMBRE"].ToString();
                }


                this.Cursor = Cursors.Default;
            }
        }

        private void limpiarpescador()
        {
            Imagen.BackgroundImage = null;
            Firma.BackgroundImage = null;
            Huella.BackgroundImage = null;
            no.Checked = true;
            foreach (TextBox item in gbDatosGenerales.Controls.OfType<TextBox>())
            {
                item.Text = "";
            }
            foreach (MaskedTextBox item in gbDatosGenerales.Controls.OfType<MaskedTextBox>())
            {
                item.Text = "";
            }
            foreach (ComboBox item in gbDatosGenerales.Controls.OfType<ComboBox>())
            {
                item.Text = "";
            }
            ActaNac.ForeColor = Color.Red;
            ACurp.ForeColor = Color.Red;
            AIne.ForeColor = Color.Red;
            AComp.ForeColor = Color.Red;
            apoyos.Text = "0";
            solicitudes.Text = "0";
            MatriculaPesc.Text = "NO APLICA";
            MatriculaRelacion.Text = "-----";
            Unid.Text = "";
        }

        private void CargarSolApo()
        {
            dt = proc.ObtenerSolicitudes(CURPPesc.Text,"");
            solicitudes.Text = dt.Rows.Count.ToString();

            dt = proc.ObtenerApoyos(CURPPesc.Text,"");
            apoyos.Text = dt.Rows.Count.ToString();

        }

        private void CargarResumenExpedientes()
        {
            DataTable expediente = proc.ObtenerExpedientePescador(CURPPesc.Text);
            if (expediente.Rows.Count > 0)
            {
                if (expediente.Rows[0]["ACTANAC"].ToString() == "") { ActaNac.ForeColor = Color.Red; } else { ActaNac.ForeColor = Color.Green; }
                if (expediente.Rows[0]["ACURP"].ToString() == "") { ACurp.ForeColor = Color.Red; } else { ACurp.ForeColor = Color.Green; }
                if (expediente.Rows[0]["AINE"].ToString() == "") { AIne.ForeColor = Color.Red; } else { AIne.ForeColor = Color.Green; }
                if (expediente.Rows[0]["ACOMPDOM"].ToString() == "") { AComp.ForeColor = Color.Red; } else { AComp.ForeColor = Color.Green; }
            }
            else
            {
                ActaNac.ForeColor = Color.Red;
                ACurp.ForeColor = Color.Red;
                AIne.ForeColor = Color.Red;
                AComp.ForeColor = Color.Red;
            }

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
                if(CURPPesc.TextLength >= 9 && RFCPesc.Text == "") { RFCPesc.Text = CURPPesc.Text.Substring(0,10); }
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

        //private void MatriculaPesc_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (RNPA != "")
        //    {
        //        MatriculaRelacion.Text = MatriculaPesc.SelectedValue.ToString();
        //    }
        //}

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
                    if (Embarcaciones.Rows[MatriculaPesc.SelectedIndex]["NUMCHIP"].ToString() != "   *   *")
                    {
                        exito = AccionesPescador(true);
                    }
                    else { exito = -12; }
                }
                val.Exito(exito);
                exito = 0;
                CargarPescadores();
                CargarNoPescadores();
               // if (threadHandle.IsAlive) { threadHandle.Abort(); }
            }
            else { MessageBox.Show("No se puede registrar un pescador sin CURP"); }
        }

        private void ActivarPanelCURP_Click(object sender, EventArgs e)
        {
            if (CURPPesc.Text != "")
            {
                CurpMal.Text = CURPPesc.Text;
                gbBotones.Enabled = false;
                gbBusqueda.Enabled = false;
                gbDatosGenerales.Enabled = false;
                gbInformacion.Enabled = false;
                gbRelacion.Enabled = false;
                PanelCURP.Visible = true;
                PanelCURP.Enabled = true;
                PanelCURP.BringToFront();
            }
        }

        private void CerrarPanel_Click(object sender, EventArgs e)
        {
            gbBotones.Enabled = true;
            gbBusqueda.Enabled = true;
            gbDatosGenerales.Enabled = true;
            gbInformacion.Enabled = true;
            gbRelacion.Enabled = true;
            PanelCURP.Visible = false;
            PanelCURP.Enabled = false;
            PanelCURP.SendToBack();
        }
        private void AbrirExpediente_Click(object sender, EventArgs e)
        {
            if (CURPPesc.Text != "")
            {
                Pantallas_Archivos.Expediente_Pescador expesc = new Pantallas_Archivos.Expediente_Pescador(CURPPesc.Text, NombrePesc.Text + " " + ApePatPescador.Text + " " + ApeMatPescador.Text, NIVEL);
                expesc.ShowDialog();
                CargarResumenExpedientes();
            }
        }

        private void Seguro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Seguro.SelectedIndex == 3)
            {
                DialogResult result = MessageBox.Show("Ha seleccionado la opción de OCCISO. ¿Desea REMOVER el registro del Pescador por fallecimiento?", "Pescador OCCISO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    if (CURPPesc.Text != "")
                    {
                        gbBotones.Enabled = false;
                        gbBusqueda.Enabled = false;
                        gbDatosGenerales.Enabled = false;
                        gbInformacion.Enabled = false;
                        gbRelacion.Enabled = false;
                        PanelOcciso.Visible = true;
                        PanelOcciso.Enabled = true;
                        PanelOcciso.BringToFront();
                    }
                }
            }
        }

        private void RegistrarOcciso_Click(object sender, EventArgs e)
        {
            if (proc.RegistrarOcciso(CURPPesc.Text,FechaFalle.Value.ToShortDateString(),Beneficiario.Text,Parentesco.Text, NPoliza.Text, Vigencia.Value.ToShortDateString(), MontoOcciso.Text ) >= 1)
            {
                MessageBox.Show("Occiso Registrado","EXITO",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            else { MessageBox.Show("Error al Registrar Occuso","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            CargarPescadores();
            CargarNoPescadores();
        }

        private void CerrarPanelOcciso_Click(object sender, EventArgs e)
        {
            gbBotones.Enabled = true;
            gbBusqueda.Enabled = true;
            gbDatosGenerales.Enabled = true;
            gbInformacion.Enabled = true;
            gbRelacion.Enabled = true;
            PanelOcciso.Visible = false;
            PanelOcciso.Enabled = false;
            PanelOcciso.SendToBack();
        }

        private void FechaNacPesc_ValueChanged(object sender, EventArgs e)
        {
            //TimeSpan tS = new TimeSpan();
            lblEdad.Text = (DateTime.Now.Year - (FechaNacPesc.Value.Year)).ToString() + " Años";
            //lblEdad.Text = ((tS.Days) / 365).ToString() + " Años";
        }

        private void ActualizarCURP_Click(object sender, EventArgs e)
        {
            if (CurpNuevo.Text != "")
            {
                DialogResult res = MessageBox.Show("Usted está por cambiar el CURP de un Pescador.\n Desea continuar?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    if (proc.Actualizar_CURP(CurpMal.Text, CurpNuevo.Text) >= 1)
                    {
                        CURPPesc.Text = CurpNuevo.Text;
                        MessageBox.Show("CURP Actualizado");
                    }
                    else { MessageBox.Show("CURP Ya existe"); }
                    CargarPescadores();
                    CargarNoPescadores();
                }
            }
        }

        private void CurpNuevo_TextChanged(object sender, EventArgs e)
        {
            if (val.validarcurp(CurpNuevo.Text))
            {
                pictureBox11.BackgroundImage = OrdenamientoPesquero.Properties.Resources.verde;
                FechaNacPesc.Value = val.Fechanac(CurpNuevo.Text);
                if (CurpNuevo.Text[10] == 'H')
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
                pictureBox11.BackgroundImage = OrdenamientoPesquero.Properties.Resources.Equis;
            }
        }

        private void ActualizarUnidad_Click(object sender, EventArgs e)
        {
            if (!val.validaralgo(pescador))
            {
            }
            else
            {
                if (RNPA == "" || Embarcaciones.Rows[MatriculaPesc.SelectedIndex]["NUMCHIP"].ToString() != "   *   *" || MatriculaPesc.Text == "NO APLICA")
                {
                    exito = AccionesPescador(false);
                }
                else { exito = -12; }
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
                matricula= filas["MATRICULA"].ToString();
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
            Vistas vista = new Vistas(CURPPesc.Text, RNPA, 4, BD);
            vista.ShowDialog();
        }
        private void VerInforme_Click(object sender, EventArgs e)
        {
            string ord = "SI";
            if (!si.Checked) { ord = "NO"; }
            string N = NombrePesc.Text + " " + ApePatPescador.Text + " " + ApeMatPescador.Text;
            if (matricula != "NO APLICA")
            {
                DataTable d = proc.ObtenerEmbarca(MatriculaRelacion.Text);
                if (d.Rows.Count==0)
                {
                    d = proc.Obtener_unidades(matricula);
                    RNPA = matricula;
                }
                else
                {
                    RNPA = proc.ObtenerEmbarca(MatriculaRelacion.Text).Rows[0]["RNPTITULAR"].ToString();
                }
                
            }
            Vistas vistas = new Vistas(CURPPesc.Text, N, RNPA, ord, 14, proc.bdd);
            vistas.ShowDialog();
            RNPA = "";
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
                DialogResult result = MessageBox.Show("Desea capturar una nueva imagen?", "Imagen Pescador", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    Pantalla_Fotografia pf = new Pantalla_Fotografia(CURPPesc.Text,Firma.BackgroundImage,Huella.BackgroundImage,this);
                    pf.ShowDialog();
                    img = true;
                }
                else if (result == DialogResult.No)
                {
                    result = MessageBox.Show("Desea subir una nueva imagen?", "Imagen Pescador", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                Bitmap bmp = new Bitmap(Image.FromFile(openFileDialog1.FileName));
                                Bitmap bmp2 = new Bitmap(bmp, new Size(135, 182));
                                Imagen.BackgroundImage = bmp2;
                                img = true;
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

        public void ImagenBackGround(Image img)
        {
            Imagen.BackgroundImage = img;
        }

        private void ObtenerImagen()
        {
            Imagen.BackgroundImage = null;
            Firma.BackgroundImage = null;
            Huella.BackgroundImage = null;
            dt = proc.ObtenerImagen(CURPPesc.Text);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["IMAGEN"].ToString() != "")
                {
                    img = true;
                    imagenBuffer = (byte[])dt.Rows[0]["IMAGEN"];
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
                    Imagen.BackgroundImage = (Image.FromStream(ms));
                }
                else { img = false; }
            }
            dt = proc.ObtenerFirma(CURPPesc.Text);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    if (dt.Rows[0]["FIRMA"].ToString() != "")
                    {
                        firm = true;
                        imagenBuffer = (byte[])dt.Rows[0]["FIRMA"];
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
                        Firma.BackgroundImage = (Image.FromStream(ms));
                        Firma.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else { firm = false; }

                    if (dt.Rows[0]["HUELLA"].ToString() != "")
                    {
                        hue = true;
                        imagenBuffer = (byte[])dt.Rows[0]["HUELLA"];
                        huell = CreateBitmap(imagenBuffer, Huella.Width, Huella.Height);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
                        Huella.BackgroundImage = (Image.FromStream(ms));
                        Bitmap result = new Bitmap(Huella.Width, Huella.Height);
                        Huella.DrawToBitmap(result, new Rectangle(0, 0, Huella.BackgroundImage.Width, Huella.BackgroundImage.Height));
                        result.Save(Application.StartupPath.ToString() + @"\huella.jpg");
                    }
                }
                catch (Exception MS) { }
            }
        }

        private void RegistrarImagen()
        {
            if (Imagen.BackgroundImage != null)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                Imagen.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                System.IO.MemoryStream firma = new MemoryStream();
                if (Firma.BackgroundImage != null)
                { Firma.BackgroundImage.Save(firma, System.Drawing.Imaging.ImageFormat.Png); }

                System.IO.MemoryStream huella = new MemoryStream();
                if(Huella.BackgroundImage != null)
                { Huella.BackgroundImage.Save(huella, System.Drawing.Imaging.ImageFormat.Png); }

                int exito = proc.InsertarImagen(CURPPesc.Text, ms.GetBuffer(), firma.GetBuffer(), huella.GetBuffer());
                if (exito > 0)
                {
                    MessageBox.Show("Imagen, firma y huella Insertadas correctamente");
                }
            }
        }

        private void CargarFirma_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea capturar la firma del usuario?", "Firma Pescador", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Process.Start("C:\\Windows\\SigPlus\\DemoOCX.exe");
                result = MessageBox.Show("Ya ha capturado la firma del usuario?", "Firma Pescador", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    Bitmap bmp = new Bitmap(Image.FromFile(mdoc + "\\FIRMA\\FIRMA.PNG"));
                    Firma.BackgroundImage = bmp;
                    Firma.BackgroundImageLayout = ImageLayout.Zoom;
                    firm = true;
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
            if (RNPA == "")
            {
                DataView view = new DataView(NOMBRES)
                { Sort = "CURP" };
                ListaNombres.DataSource = view;
            }
            else { ListaNombres.DataSource = NOMBRES; }
            ListaNombres.ValueMember = "CURP";
            if (RNPA == "") { ListaNombres.DisplayMember = "CURP"; }
            else { ListaNombres.DisplayMember = "NOMBRE"; }
        }
        private void BuscarNombre2_TextChanged(object sender, EventArgs e)
        {
            if (RNPA == "")
            {
                string x = BuscarNombre2.Text;
                NoOrdenados = proc.BuscarNombre(x, RNPA);
                ListaNombres2.DataSource = NoOrdenados;
                ListaNombres2.ValueMember = "CURP";
                ListaNombres2.DisplayMember = "NOMBRE";
            }
            else
            {
                string x = BuscarNombre2.Text;
                NoOrdenados = proc.BuscarNombre(x, "NO APLICA");
                ListaNombres2.DataSource = NoOrdenados;
                ListaNombres2.ValueMember = "CURP";
                ListaNombres2.DisplayMember = "NOMBRE";
            }
        }


        private void Solicitud_Click(object sender, EventArgs e)
        {
            if (Ord != -1)
            {
                string Nombre = "";
                if (Ord == 1) { Nombre = ListaNombres.Text; } else { Nombre = ListaNombres2.Text; }
                Pantalla_Solicitudes pantalla = new Pantalla_Solicitudes(Nombre, CURPPesc.Text,false,Usuario, NIVEL,NombreUsuario);
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
                Pantalla_Solicitudes pantalla = new Pantalla_Solicitudes(Nombre, CURPPesc.Text, true,Usuario, NIVEL, NombreUsuario);
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
                LlenarDatos(ListaNombres.SelectedValue.ToString());
                CargarSolApo();
                CargarResumenExpedientes();
            }
        }

        private void Credencial_Click(object sender, EventArgs e)
        {
            if (img && firm && hue)
            {
                Vistas v = new Vistas(CURPPesc.Text, NombreUnidad, 4, huell, proc.bdd);
                v.Show(this);
            }
            else { MessageBox.Show("Para poder credencilizar debe tener Huella, Firma y Fotografía.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        

        private void ListaNombres2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ListaNombres2.SelectedIndex != -1)
            {
                Ord = 0;
                ListaNombres.SelectedIndex = -1;
                LlenarDatos(NoOrdenados.Rows[ListaNombres2.SelectedIndex]["CURP"].ToString());
                CargarSolApo();
                CargarResumenExpedientes();
            }

        }

        #endregion

        private void NombrePesc_Leave(object sender, EventArgs e)
        {
            NombrePesc.Text = NombrePesc.Text.Trim();
        }

        private void ApePatPescador_Leave(object sender, EventArgs e)
        {
            ApePatPescador.Text = ApePatPescador.Text.Trim();
        }

        private void ApeMatPescador_Leave(object sender, EventArgs e)
        {
            ApeMatPescador.Text = ApeMatPescador.Text.Trim();
        }

        private void BuscarNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (ListaNombres.SelectedIndex >= 0)
                {
                    ListaNombres_MouseDoubleClick(sender, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                }
            }
        }

        private void BuscarNombre2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (ListaNombres2.SelectedIndex >= 0)
                {
                    ListaNombres2_MouseDoubleClick(sender, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                }
            }
        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            Pantalla_Solicitudes pantalla = new Pantalla_Solicitudes("", "", false, Usuario, NIVEL, NombreUsuario);
            pantalla.ShowDialog();
        }

        private void EliminarRegistro_Click(object sender, EventArgs e)
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
                MessageBox.Show("Coloque el dedo sobre el sensor","Huella Pescador",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                hue = true;
            }
            catch (Exception) { MessageBox.Show("Hubo un problema con el sensor, retirelo y vuelva a insertarlo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private bool reset = false;
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
            threadHandle = new Thread(CaptureThread)
            { IsBackground = true };
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
        private void Pantalla_Registro_Usuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Show();
            Owner.Refresh();
        }
}
}