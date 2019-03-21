using Logica;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Windows.Forms;
using System.Reflection;

namespace OrdenamientoPesquero.Pantallas_Registros
{
    public partial class Vistas : Form
    {
        public Vistas(string parametro, string uni, int tipo)
        {
            InitializeComponent();
            rnpa = parametro;
            unidad = uni;
            tip = tipo;
        }
        public Vistas(string curp, string NombrePesc, string RNPA,string ordenado, int tipo){
            InitializeComponent();
            rnpa = RNPA;
            CURP = curp;
            unidad = NombrePesc;
            Ordenado = ordenado;
            tip = tipo;
        }
        string CURP;
        string Ordenado;
        string rnpa;
        string unidad;
        int tip;
        Procedimientos proc = new Procedimientos();
        Conexion c;
        private void Vistas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'pesTodospes.PESCADOR' Puede moverla o quitarla según sea necesario.
            //this.pESCADORTableAdapter.Fill(this.pesTodospes.PESCADOR);
            // TODO: esta línea de código carga datos en la tabla 'ordPesqueroDataSet12.pesembarca' Puede moverla o quitarla según sea necesario.
            //this.pesembarcaTableAdapter.Fill(this.ordPesqueroDataSet12.pesembarca);
            // TODO: esta línea de código carga datos en la tabla 'seguro.MULEGE_SEGURO' Puede moverla o quitarla según sea necesario.
            //this.mULEGE_SEGUROTableAdapter.Fill(this.seguro.MULEGE_SEGURO);
            //// TODO: esta línea de código carga datos en la tabla 'seguro.LOSCABOS_SEGURO' Puede moverla o quitarla según sea necesario.
            //this.lOSCABOS_SEGUROTableAdapter.Fill(this.seguro.LOSCABOS_SEGURO);
            //// TODO: esta línea de código carga datos en la tabla 'seguro.LORETO_SEGURO' Puede moverla o quitarla según sea necesario.
            //this.lORETO_SEGUROTableAdapter.Fill(this.seguro.LORETO_SEGURO);
            //// TODO: esta línea de código carga datos en la tabla 'seguro.LAPAZ_SEGURO' Puede moverla o quitarla según sea necesario.
            //this.lAPAZ_SEGUROTableAdapter.Fill(this.seguro.LAPAZ_SEGURO);
            //// TODO: esta línea de código carga datos en la tabla 'seguro.COMONDU_SEGURO' Puede moverla o quitarla según sea necesario.
            //this.cOMONDU_SEGUROTableAdapter.Fill(this.seguro.COMONDU_SEGURO);
            // TODO: esta línea de código carga datos en la tabla 'vencidos.PermisosVencidos' Puede moverla o quitarla según sea necesario.
            //this.permisosVencidosTableAdapter.Fill(this.vencidos.PermisosVencidos);
            //// TODO: esta línea de código carga datos en la tabla 'ordPesqueroDataSet9.permi2' Puede moverla o quitarla según sea necesario.
            //this.permi2TableAdapter.Fill(this.ordPesqueroDataSet9.permi2);
            //this.obtenerFirmaTableAdapter.Fill(this.ordPesqueroDataSet10.ObtenerFirma, rnpa);
            ////TODO: esta línea de código carga datos en la tabla 'ordPesqueroDataSet9.permi' Puede moverla o quitarla según sea necesario.
            //this.permiTableAdapter1.Fill(this.ordPesqueroDataSet9.permi);
            //// TODO: esta línea de código carga datos en la tabla 'ordPesqueroDataSet8.permi' Puede moverla o quitarla según sea necesario.
            //this.permiTableAdapter.Fill(this.ordPesqueroDataSet8.permi);
            //// TODO: esta línea de código carga datos en la tabla 'ordPesqueroDataSet7.Mulege' Puede moverla o quitarla según sea necesario.
            //this.mulegeTableAdapter.Fill(this.ordPesqueroDataSet7.Mulege);
            //// TODO: esta línea de código carga datos en la tabla 'ordPesqueroDataSet6.LosCabos' Puede moverla o quitarla según sea necesario.
            //this.losCabosTableAdapter.Fill(this.ordPesqueroDataSet6.LosCabos);
            //// TODO: esta línea de código carga datos en la tabla 'ordPesqueroDataSet5.Loreto' Puede moverla o quitarla según sea necesario.
            //this.loretoTableAdapter.Fill(this.ordPesqueroDataSet5.Loreto);
            //// TODO: esta línea de código carga datos en la tabla 'ordPesqueroDataSet4.LaPaz' Puede moverla o quitarla según sea necesario.
            //this.laPazTableAdapter.Fill(this.ordPesqueroDataSet4.LaPaz);
            //// TODO: esta línea de código carga datos en la tabla 'ordPesqueroDataSet3.Comondu' Puede moverla o quitarla según sea necesario.
            //this.comonduTableAdapter.Fill(this.ordPesqueroDataSet3.Comondu);
            // TODO: esta línea de código carga datos en la tabla 'todospes.todos' Puede moverla o quitarla según sea necesario.
            this.todosTableAdapter.Fill(this.todospes.todos);
            ReportDataSource datos = new ReportDataSource();
            ReportDataSource datos2 = new ReportDataSource();
            ReportDataSource datos3 = new ReportDataSource();
            ReportDataSource datos4 = new ReportDataSource();
            ReportDataSource datos5 = new ReportDataSource();
            ReportDataSource datos8 = new ReportDataSource();
            ReportDataSource datos9 = new ReportDataSource();
            ReportDataSource datos10 = new ReportDataSource();
            if (unidad == "")
            {
                unidad = rnpa;
            }
            switch (tip)
            {
                case 1:
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    this.reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Report3.rdlc");
                    this.pescadoresTableAdapter.Fill(ordPesqueroDataSetpescadores1.pescadores, rnpa);
                    datos.Name = "lispes";
                    datos.Value = ordPesqueroDataSetpescadores1.pescadores;
                    this.reportViewer1.LocalReport.DataSources.Add(datos);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter("Unidad", unidad));
                    this.reportViewer1.RefreshReport();
                    break;
                case 2:
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Permisos.rdlc");
                    this.vista_permTableAdapter.Fill(permisos_lista.vista_perm, rnpa);
                    datos.Name = "vista_perm";
                    datos.Value = permisos_lista.vista_perm;
                    this.reportViewer1.LocalReport.DataSources.Add(datos);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter("Unidad", unidad));
                    this.reportViewer1.RefreshReport();
                    break;
                case 3:
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Anexo3.rdlc");
                    DataTable dt = proc.Obtener_Pescador(rnpa);
                    ReportParameter[] para = new ReportParameter[28];
                    para[0] = new ReportParameter("NombrePescador", dt.Rows[0]["NOMBRE"].ToString());
                    para[26] = new ReportParameter("Appat", dt.Rows[0]["AP_PAT"].ToString());
                    para[27] = new ReportParameter("Apmat", dt.Rows[0]["AP_MAT"].ToString());
                    para[1] = new ReportParameter("LugarNacimiento", dt.Rows[0]["LUGAR_NACIMIENTO"].ToString());
                    para[2] = new ReportParameter("FechaNacimiento", dt.Rows[0]["FECHA_NACIMIENTO"].ToString());
                    para[3] = new ReportParameter("CURP", dt.Rows[0]["CURP"].ToString());
                    para[4] = new ReportParameter("RFC", dt.Rows[0]["RFC"].ToString());
                    para[5] = new ReportParameter("SEXO", dt.Rows[0]["SEXO"].ToString());
                    para[6] = new ReportParameter("SANGRE", dt.Rows[0]["TIPO_SANGRE"].ToString());
                    string n = dt.Rows[0]["FECHA_NACIMIENTO"].ToString();
                    string na = n[6].ToString() + n[7].ToString();
                    int nac = Convert.ToInt32(na);
                    int actual = DateTime.Today.Year;
                    if ((nac + 2000) > actual)
                    {
                        nac = nac + 1900;
                    }
                    else { nac = nac + 2000; }
                    int años = actual - nac;
                    para[7] = new ReportParameter("EDAD", años.ToString());
                    para[8] = new ReportParameter("CALLE", dt.Rows[0]["CALLENUM"].ToString());
                    para[9] = new ReportParameter("COLONIA", dt.Rows[0]["COLONIA"].ToString());
                    para[10] = new ReportParameter("LOCALIDAD", dt.Rows[0]["LOCALIDAD"].ToString());
                    para[11] = new ReportParameter("Municipio", dt.Rows[0]["MUNICIPIO"].ToString());
                    para[12] = new ReportParameter("Estado", "BAJA CALIFORNIA SUR");
                    para[13] = new ReportParameter("Telefono", dt.Rows[0]["TELEFONO"].ToString());
                    para[14] = new ReportParameter("Escolaridad", dt.Rows[0]["ESCOLARIDAD"].ToString());
                    para[25] = new ReportParameter("CP", dt.Rows[0]["CODIGO_POSTAL"].ToString());
                    para[22] = new ReportParameter("Matricula", dt.Rows[0]["MATRICULA"].ToString());
                    para[18] = new ReportParameter("Tipo", dt.Rows[0]["TIPO_PESCADOR"].ToString());
                    para[19] = new ReportParameter("Ocupacion", dt.Rows[0]["OCUPACION_LABORAL"].ToString());
                    para[20] = new ReportParameter("Cuerpo", dt.Rows[0]["CUERPO_DE_AGUA"].ToString());
                    string matricula = dt.Rows[0]["MATRICULA"].ToString();
                    dt = proc.Obtener_unidades(unidad);

                    para[15] = new ReportParameter("Unidad", dt.Rows[0]["NOMBRE"].ToString());
                    para[16] = new ReportParameter("RNPA", unidad);


                    dt = proc.ObtenerEmbarca(matricula);
                    para[21] = new ReportParameter("NombreEmbarcacion", dt.Rows[0]["NOMBREEMBARCACION"].ToString());
                    dt = proc.PermisosxEmbarca(matricula);
                    if (dt.Rows.Count > 0)
                    {
                        para[23] = new ReportParameter("Sitio", dt.Rows[0]["SITIOSDESEMBARQUE"].ToString());
                        para[24] = new ReportParameter("Campo", dt.Rows[0]["ZONAPESCA"].ToString());
                    }
                    else
                    {
                        para[23] = new ReportParameter("Sitio", "");
                        para[24] = new ReportParameter("Campo", "");
                    }

                    dt = proc.NpermisoxEmbarca(matricula);
                    para[17] = new ReportParameter("Permisos", dt.Rows[0][0].ToString());
                    reportViewer1.LocalReport.SetParameters(para);
                    this.reportViewer1.RefreshReport();
                    break;
                case 4:
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Credencial.rdlc");
                    DataTable dt1 = proc.Obtener_Pescador(rnpa);
                    this.obtenerFirmaTableAdapter.Fill(ordPesqueroDataSet10.ObtenerFirma, rnpa);
                    datos2.Name = "DataSet2";
                    datos2.Value = ordPesqueroDataSet10.ObtenerFirma;
                    this.obtenerImagenTableAdapter.Fill(ordPesqueroDataSet10.ObtenerImagen, rnpa);
                    datos.Name = "ima";
                    datos.Value = ordPesqueroDataSet10.ObtenerImagen;
                    ReportParameter[] para1 = new ReportParameter[12];
                    para1[0] = new ReportParameter("NOMBRE", dt1.Rows[0]["NOMBRE"].ToString() + " " + dt1.Rows[0]["AP_PAT"].ToString() + " " + dt1.Rows[0]["AP_MAT"].ToString());
                    para1[1] = new ReportParameter("CURP", dt1.Rows[0]["CURP"].ToString());
                    para1[2] = new ReportParameter("SANGRE", dt1.Rows[0]["TIPO_SANGRE"].ToString());
                    para1[3] = new ReportParameter("MATRICULA", dt1.Rows[0]["MATRICULA"].ToString());
                    para1[9] = new ReportParameter("EXPEDICION", dt1.Rows[0]["FECHAEXP_FOLIO"].ToString());
                    para1[10] = new ReportParameter("VENCE", dt1.Rows[0]["FECHAVEN_FOLIO"].ToString());
                    para1[6] = new ReportParameter("FOLIO", dt1.Rows[0]["FOLIO"].ToString());
                    para1[11] = new ReportParameter("OCUPACION", dt1.Rows[0]["OCUPACION_LABORAL"].ToString().ToUpper());
                    para1[7] = new ReportParameter("DIRECCION", dt1.Rows[0]["CALLENUM"].ToString() + ", COL." + dt1.Rows[0]["COLONIA"].ToString());
                    dt1 = proc.Obtener_unidad(unidad);
                    para1[4] = new ReportParameter("RNPA", dt1.Rows[0]["RNPA"].ToString());
                    para1[5] = new ReportParameter("TITULAR", unidad);
                    string ruta = Application.StartupPath.ToString();
                    ruta = ruta.Replace("\\", "*");
                    ruta = ruta.Replace("*", "/");
                    para1[8] = new ReportParameter("RutaImagen", ruta + "perfil.jpg");
                    reportViewer1.LocalReport.SetParameters(para1);
                    this.reportViewer1.LocalReport.DataSources.Add(datos);
                    this.reportViewer1.LocalReport.DataSources.Add(datos2);
                    this.reportViewer1.RefreshReport();
                    break;
                case 5:
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Pescadores.rdlc");
                    this.todosTableAdapter.Fill(todospes.todos);
                    datos.Name = "pes";
                    datos.Value = todospes.todos;
                    this.reportViewer1.LocalReport.DataSources.Add(datos);
                    this.reportViewer1.RefreshReport();
                    break;
                case 6:
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, unidad);

                    try
                    {
                        this.vista_permTableAdapter.Fill(permisos_lista.vista_perm, rnpa);
                    }
                    catch (Exception)
                    {

                        //throw;
                    }
                    datos.Name = "DataSet2";
                    datos.Value = permisos_lista.vista_perm;
                    this.reportViewer1.LocalReport.DataSources.Add(datos);
                    this.embarcacionesxUnidadTableAdapter.Fill(embarcacionesSet.EmbarcacionesxUnidad, rnpa);

                    datos10.Name = "DataSet10";
                    datos10.Value = obtenerAtendidasxRnpaTableAdapter.GetData(rnpa);
                    this.reportViewer1.LocalReport.DataSources.Add(datos10);

                    datos2.Name = "DataSet3";
                    datos2.Value = embarcacionesSet.EmbarcacionesxUnidad;
                    this.reportViewer1.LocalReport.DataSources.Add(datos2);
                    this.pescadoresTableAdapter.Fill(ordPesqueroDataSetpescadores1.pescadores, rnpa);
                    datos3.Name = "DataSet5";
                    datos3.Value = ordPesqueroDataSetpescadores1.pescadores;
                    this.reportViewer1.LocalReport.DataSources.Add(datos3);

                    datos8.Name = "DataSet8";
                    datos8.Value = obtenerSolicitudesxRnpaTableAdapter.GetData( rnpa);
                    this.reportViewer1.LocalReport.DataSources.Add(datos8);

                    datos9.Name = "DataSet9";
                    datos9.Value = obtenerApoyosxRnpaTableAdapter.GetData( rnpa);
                    this.reportViewer1.LocalReport.DataSources.Add(datos9);

                    datos10.Name = "DataSet10";
                    datos10.Value = obtenerAtendidasxRnpaTableAdapter.GetData(rnpa);
                    this.reportViewer1.LocalReport.DataSources.Add(datos10);

                    try
                    {
                        this.vista_perm2TableAdapter.Fill(permisos_lista.vista_perm2, rnpa);
                    }
                    catch (Exception)
                    {
                        //throw;
                    }
                    datos4.Name = "DataSet11";
                    datos4.Value = permisos_lista.vista_perm2;
                    this.reportViewer1.LocalReport.DataSources.Add(datos4);

                    try
                    {
                        this.vista_perm3TableAdapter.Fill(permisos_lista.vista_perm3, rnpa);
                    }
                    catch (Exception)
                    {
                        //throw;
                    }
                    datos5.Name = "DataSet4";
                    datos5.Value = permisos_lista.vista_perm3;
                    this.reportViewer1.LocalReport.DataSources.Add(datos5);
                    ReportParameter[] para3 = new ReportParameter[15];
                    dt = proc.ObtenerUnaFederacion(rnpa);
                    if (dt.Rows.Count != 0)
                    {
                        para3[1] = new ReportParameter("Fed", dt.Rows[0]["NOMBRE"].ToString());
                    }
                    else
                    {
                        para3[1] = new ReportParameter("Fed", "");
                    }
                    dt = proc.Obtener_unidades(rnpa);
                    if (dt.Rows.Count != 0)
                    {
                        para3[0] = new ReportParameter("Unidad", dt.Rows[0]["NOMBRE"].ToString());
                        reportViewer1.LocalReport.DisplayName = dt.Rows[0]["NOMBRE"].ToString();
                        reportViewer1.LocalReport.DisplayName = reportViewer1.LocalReport.DisplayName.Replace("\"", "");
                        para3[2] = new ReportParameter("Municipio", dt.Rows[0]["MUNICIO"].ToString());
                        para3[3] = new ReportParameter("Localidad", dt.Rows[0]["LOCALIDAD"].ToString());
                    }
                    else
                    {
                        para3[0] = new ReportParameter("Unidad", "");
                        para3[2] = new ReportParameter("Municipio", "");
                        para3[3] = new ReportParameter("Localidad", "");
                    }
                    dt = proc.ResumenSocios(rnpa);
                    if (dt.Rows.Count != 0)
                    {
                        para3[7] = new ReportParameter("naseg", dt.Rows[0]["ASEGURADOS"].ToString());
                        para3[8] = new ReportParameter("nord", dt.Rows[0]["ORDENADOS"].ToString());
                        para3[9] = new ReportParameter("ncap", dt.Rows[0]["CAPITANES"].ToString());
                        para3[10] = new ReportParameter("nmar", dt.Rows[0]["MARINEROS"].ToString());
                        para3[11] = new ReportParameter("nacu", dt.Rows[0]["ACUACULTORES"].ToString());
                        para3[12] = new ReportParameter("nsin", dt.Rows[0]["SINACTIVIDAD"].ToString());
                        para3[13] = new ReportParameter("ncred", dt.Rows[0]["CREDENCIALIZADOS"].ToString());
                    }
                    else
                    {
                        para3[7] = new ReportParameter("naseg", "0");
                        para3[8] = new ReportParameter("nord", "0");
                        para3[9] = new ReportParameter("ncap", "0");
                        para3[10] = new ReportParameter("nmar", "0");
                        para3[11] = new ReportParameter("nacu", "0");
                        para3[12] = new ReportParameter("nsin", "0");
                        para3[13] = new ReportParameter("ncred", "0");
                    }
                    dt = proc.Resumen(rnpa);
                    para3[14] = new ReportParameter("schip", dt.Rows[0]["ESFUERZOS CHIPEADOS"].ToString());
                    para3[4] = new ReportParameter("nper", permisos_lista.vista_perm.Count.ToString());
                    para3[5] = new ReportParameter("nsoc", ordPesqueroDataSetpescadores1.pescadores.Count.ToString());
                    para3[6] = new ReportParameter("nemb", embarcacionesSet.EmbarcacionesxUnidad.Count.ToString());
                    reportViewer1.LocalReport.SetParameters(para3);
                    this.reportViewer1.RefreshReport();
                    break;
                case 7:
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "xMunicipio.rdlc");
                    this.comonduTableAdapter.Fill(ordPesqueroDataSet3.Comondu);
                    datos.Name = "Comondu";
                    datos.Value = ordPesqueroDataSet3.Comondu;
                    this.reportViewer1.LocalReport.DataSources.Add(datos);

                    this.mulegeTableAdapter.Fill(ordPesqueroDataSet7.Mulege);
                    datos2.Name = "Mulege";
                    datos2.Value = ordPesqueroDataSet7.Mulege;
                    this.reportViewer1.LocalReport.DataSources.Add(datos2);

                    this.laPazTableAdapter.Fill(ordPesqueroDataSet4.LaPaz);
                    datos3.Name = "LaPaz";
                    datos3.Value = ordPesqueroDataSet4.LaPaz;
                    this.reportViewer1.LocalReport.DataSources.Add(datos3);

                    this.losCabosTableAdapter.Fill(ordPesqueroDataSet6.LosCabos);
                    datos4.Name = "LosCabos";
                    datos4.Value = ordPesqueroDataSet6.LosCabos;
                    this.reportViewer1.LocalReport.DataSources.Add(datos4);

                    this.loretoTableAdapter.Fill(ordPesqueroDataSet5.Loreto);
                    datos5.Name = "Loreto";
                    datos5.Value = ordPesqueroDataSet5.Loreto;
                    this.reportViewer1.LocalReport.DataSources.Add(datos5);

                    ReportParameter[] para7 = new ReportParameter[5];
                    int x = 0;
                    if (ordPesqueroDataSet7.Mulege.Rows.Count.ToString() == null)
                    {
                        para7[0] = new ReportParameter("totM", "0");
                    }
                    else
                    {
                        para7[0] = new ReportParameter("totM", ordPesqueroDataSet7.Mulege.Rows.Count.ToString());
                    }

                    if (ordPesqueroDataSet3.Comondu.Rows.Count.ToString() == null)
                    {
                        para7[1] = new ReportParameter("totC", "0");
                    }
                    else
                    {
                        para7[1] = new ReportParameter("totC", ordPesqueroDataSet3.Comondu.Rows.Count.ToString());
                    }

                    if (ordPesqueroDataSet4.LaPaz.Rows.Count.ToString() == null)
                    {
                        para7[2] = new ReportParameter("totP", "0");
                    }
                    else
                    {
                        para7[2] = new ReportParameter("totP", ordPesqueroDataSet4.LaPaz.Rows.Count.ToString());
                    }

                    if (ordPesqueroDataSet5.Loreto.Rows.Count.ToString() == null)
                    {
                        para7[2] = new ReportParameter("totL", "0");
                    }
                    else
                    {
                        para7[3] = new ReportParameter("totL", ordPesqueroDataSet5.Loreto.Rows.Count.ToString());
                    }

                    if (ordPesqueroDataSet6.LosCabos.Rows.Count.ToString() == null)
                    {
                        para7[4] = new ReportParameter("totL", "0");
                    }
                    else
                    {
                        para7[4] = new ReportParameter("totCA", ordPesqueroDataSet6.LosCabos.Rows.Count.ToString());
                    }
                    reportViewer1.LocalReport.SetParameters(para7);

                    this.reportViewer1.RefreshReport();
                    break;
                case 8:
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Resumen_permisos.rdlc");
                    this.permiTableAdapter1.Fill(ordPesqueroDataSet9.permi);
                    datos.Name = "permi";
                    datos.Value = ordPesqueroDataSet9.permi;
                    this.reportViewer1.LocalReport.DataSources.Add(datos);

                    this.permi2TableAdapter.Fill(ordPesqueroDataSet9.permi2);
                    datos2.Name = "permi2";
                    datos2.Value = ordPesqueroDataSet9.permi2;
                    this.reportViewer1.LocalReport.DataSources.Add(datos2);
                    DataSet ds = proc.t();
                    ReportParameter[] para4 = new ReportParameter[6];
                    para4[0] = new ReportParameter("totu", ds.Tables[0].Rows[0][0].ToString());
                    para4[1] = new ReportParameter("totp", ds.Tables[1].Rows[0][0].ToString());
                    para4[2] = new ReportParameter("toto", ds.Tables[2].Rows[0][0].ToString());
                    para4[3] = new ReportParameter("totn", ds.Tables[3].Rows[0][0].ToString());
                    para4[4] = new ReportParameter("totm", ds.Tables[4].Rows[0][0].ToString());
                    para4[5] = new ReportParameter("totc", ds.Tables[5].Rows[0][0].ToString());
                    reportViewer1.LocalReport.SetParameters(para4);
                    this.reportViewer1.RefreshReport();
                    break;
                case 9:
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "PermisosVencidos.rdlc");
                    this.permisosVencidosTableAdapter.Fill(vencidos.PermisosVencidos);
                    datos.Name = "Vencidos";
                    datos.Value = vencidos.PermisosVencidos;
                    this.reportViewer1.LocalReport.DataSources.Add(datos);
                    this.reportViewer1.RefreshReport();
                    break;
                case 10:
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "xMunicipio_seguro.rdlc");
                    this.cOMONDU_SEGUROTableAdapter.Fill(seguro.COMONDU_SEGURO);
                    datos.Name = "comondu";
                    datos.Value = seguro.COMONDU_SEGURO;
                    this.reportViewer1.LocalReport.DataSources.Add(datos);

                    this.mULEGE_SEGUROTableAdapter.Fill(seguro.MULEGE_SEGURO);
                    datos2.Name = "mulege";
                    datos2.Value = seguro.MULEGE_SEGURO;
                    this.reportViewer1.LocalReport.DataSources.Add(datos2);

                    this.lAPAZ_SEGUROTableAdapter.Fill(seguro.LAPAZ_SEGURO);
                    datos3.Name = "la_paz";
                    datos3.Value = seguro.LAPAZ_SEGURO;
                    this.reportViewer1.LocalReport.DataSources.Add(datos3);

                    this.lOSCABOS_SEGUROTableAdapter.Fill(seguro.LOSCABOS_SEGURO);
                    datos4.Name = "los_cabos";
                    datos4.Value = seguro.LOSCABOS_SEGURO;
                    this.reportViewer1.LocalReport.DataSources.Add(datos4);

                    this.lORETO_SEGUROTableAdapter.Fill(seguro.LORETO_SEGURO);
                    datos5.Name = "loreto";
                    datos5.Value = seguro.LORETO_SEGURO;
                    this.reportViewer1.LocalReport.DataSources.Add(datos5);
                    this.reportViewer1.RefreshReport();
                    break;
                case 11:
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "reportepescadores.rdlc");
                    this.pesembarcaTableAdapter.Fill(ordPesqueroDataSet12.pesembarca);
                    datos.Name = "DataSet2";
                    datos.Value = ordPesqueroDataSet12.pesembarca;
                    this.reportViewer1.LocalReport.DataSources.Add(datos);
                    this.reportViewer1.RefreshReport();
                    break;
                case 12:
                    DataTable dtx = proc.RNPAXMunicipio(rnpa);
                    string muni = rnpa;
                    string nombre = "";
                    for (int i = 0; i < dtx.Rows.Count; i++)
                    {
                        this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                        rnpa = dtx.Rows[i][0].ToString();
                        reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, unidad);
                        try
                        {
                            this.vista_permTableAdapter.Fill(permisos_lista.vista_perm, rnpa);
                        }
                        catch (Exception)
                        {

                            //throw;
                        }

                        datos8.Name = "DataSet8";
                        datos8.Value = obtenerSolicitudesxRnpaTableAdapter.GetData(rnpa);
                        this.reportViewer1.LocalReport.DataSources.Add(datos8);

                        datos9.Name = "DataSet9";
                        datos9.Value = obtenerApoyosxRnpaTableAdapter.GetData( rnpa);
                        this.reportViewer1.LocalReport.DataSources.Add(datos9);

                        datos10.Name = "DataSet10";
                        datos10.Value = obtenerAtendidasxRnpaTableAdapter.GetData(rnpa);
                        this.reportViewer1.LocalReport.DataSources.Add(datos10);

                        datos.Name = "DataSet2";
                        datos.Value = permisos_lista.vista_perm;
                        this.reportViewer1.LocalReport.DataSources.Add(datos);
                        this.embarcacionesxUnidadTableAdapter.Fill(embarcacionesSet.EmbarcacionesxUnidad, rnpa);
                        datos2.Name = "DataSet3";
                        datos2.Value = embarcacionesSet.EmbarcacionesxUnidad;
                        this.reportViewer1.LocalReport.DataSources.Add(datos2);
                        this.pescadoresTableAdapter.Fill(ordPesqueroDataSetpescadores1.pescadores, rnpa);
                        datos3.Name = "DataSet5";
                        datos3.Value = ordPesqueroDataSetpescadores1.pescadores;
                        this.reportViewer1.LocalReport.DataSources.Add(datos3);

                        try
                        {
                            this.vista_perm2TableAdapter.Fill(permisos_lista.vista_perm2, rnpa);
                        }
                        catch (Exception)
                        {
                            //throw;
                        }
                        datos4.Name = "DataSet11";
                        datos4.Value = permisos_lista.vista_perm2;
                        this.reportViewer1.LocalReport.DataSources.Add(datos4);

                        try
                        {
                            this.vista_perm3TableAdapter.Fill(permisos_lista.vista_perm3, rnpa);
                        }
                        catch (Exception)
                        {
                            //throw;
                        }
                        datos5.Name = "DataSet4";
                        datos5.Value = permisos_lista.vista_perm3;
                        this.reportViewer1.LocalReport.DataSources.Add(datos5);
                        para3 = new ReportParameter[15];
                        dt = proc.ObtenerUnaFederacion(rnpa);
                        if (dt.Rows.Count != 0)
                        {
                            para3[1] = new ReportParameter("Fed", dt.Rows[0]["NOMBRE"].ToString());
                        }
                        else
                        {
                            para3[1] = new ReportParameter("Fed", "");
                        }
                        dt = proc.Obtener_unidades(rnpa);
                        if (dt.Rows.Count != 0)
                        {
                            para3[0] = new ReportParameter("Unidad", dt.Rows[0]["NOMBRE"].ToString());
                            nombre = dt.Rows[0]["NOMBRE"].ToString();
                            para3[2] = new ReportParameter("Municipio", dt.Rows[0]["MUNICIO"].ToString());
                            para3[3] = new ReportParameter("Localidad", dt.Rows[0]["LOCALIDAD"].ToString());
                        }
                        else
                        {
                            para3[0] = new ReportParameter("Unidad", "");
                            para3[2] = new ReportParameter("Municipio", "");
                            para3[3] = new ReportParameter("Localidad", "");
                        }
                        dt = proc.ResumenSocios(rnpa);
                        if (dt.Rows.Count != 0)
                        {
                            para3[7] = new ReportParameter("naseg", dt.Rows[0]["ASEGURADOS"].ToString());
                            para3[8] = new ReportParameter("nord", dt.Rows[0]["ORDENADOS"].ToString());
                            para3[9] = new ReportParameter("ncap", dt.Rows[0]["CAPITANES"].ToString());
                            para3[10] = new ReportParameter("nmar", dt.Rows[0]["MARINEROS"].ToString());
                            para3[11] = new ReportParameter("nacu", dt.Rows[0]["ACUACULTORES"].ToString());
                            para3[12] = new ReportParameter("nsin", dt.Rows[0]["SINACTIVIDAD"].ToString());
                            para3[13] = new ReportParameter("ncred", dt.Rows[0]["CREDENCIALIZADOS"].ToString());
                        }
                        else
                        {
                            para3[7] = new ReportParameter("naseg", "0");
                            para3[8] = new ReportParameter("nord", "0");
                            para3[9] = new ReportParameter("ncap", "0");
                            para3[10] = new ReportParameter("nmar", "0");
                            para3[11] = new ReportParameter("nacu", "0");
                            para3[12] = new ReportParameter("nsin", "0");
                            para3[13] = new ReportParameter("ncred", "0");
                        }
                        dt = proc.Resumen(rnpa);
                        para3[14] = new ReportParameter("schip", dt.Rows[0]["ESFUERZOS CHIPEADOS"].ToString());
                        para3[4] = new ReportParameter("nper", permisos_lista.vista_perm.Count.ToString());
                        para3[5] = new ReportParameter("nsoc", ordPesqueroDataSetpescadores1.pescadores.Count.ToString());
                        para3[6] = new ReportParameter("nemb", embarcacionesSet.EmbarcacionesxUnidad.Count.ToString());
                        reportViewer1.LocalReport.SetParameters(para3);
                        this.reportViewer1.RefreshReport();
                        nombre = nombre.Replace("\"", "");
                        if (!Directory.Exists(@"C:\FICHAS\" + muni + @"\" + nombre + @"\"))
                        {
                            DirectoryInfo di = Directory.CreateDirectory(@"C:\FICHAS\" + muni + @"\" + nombre + @"\");
                        }
                        File.WriteAllBytes(@"C:\FICHAS\" + muni + @"\" + nombre + @"\Ficha Informativa.pdf", reportViewer1.LocalReport.Render("PDF"));
                    }
                    this.Close();
                    break;
                case 13:
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "reportepescadores2.rdlc");
                    this.pESCADORTableAdapter.Fill(pesTodospes.PESCADOR);
                    datos.Name = "DataSet1";
                    datos.Value = pesTodospes.PESCADOR;
                    this.reportViewer1.LocalReport.DataSources.Add(datos);
                    this.reportViewer1.RefreshReport();
                    break;
                case 14:
                    reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "SolicitudesApoyosXPescador.rdlc");
                    reportViewer1.LocalReport.DataSources.Clear();
                    datos.Name = "ApoyosXCurp";
                    obtenerApoyosxCurpTableAdapter.Fill(solicitudesApoyosXCurp.ObtenerApoyosxCurp, CURP);
                    datos.Value = solicitudesApoyosXCurp.ObtenerApoyosxCurp;
                    datos2.Name = "SolicitudesXCurp";
                    obtenerSolicitudesxCurpTableAdapter.Fill(solicitudesApoyosXCurp.ObtenerSolicitudesxCurp, CURP);
                    datos2.Value = obtenerSolicitudesxCurpTableAdapter.GetData(CURP);
                    datos3.Name = "Atendidas";
                    obtenerAtendidasxCurpTableAdapter.Fill(solicitudesApoyosXCurp.ObtenerAtendidasxCurp, CURP);
                    datos3.Value = obtenerAtendidasxCurpTableAdapter.GetData(CURP);
                    reportViewer1.LocalReport.DataSources.Add(datos);
                    reportViewer1.LocalReport.DataSources.Add(datos2);
                    reportViewer1.LocalReport.DataSources.Add(datos3);
                    ReportParameter[] SoliApo;
                    if (rnpa!=""&&rnpa!= "NO APLICA")
                    {
                        SoliApo = new ReportParameter[6];
                        dt = proc.Obtener_unidades(rnpa);
                        SoliApo[2] = new ReportParameter("Unidad", dt.Rows[0]["NOMBRE"].ToString());
                        SoliApo[3] = new ReportParameter("Municipio", dt.Rows[0]["MUNICIO"].ToString());
                        SoliApo[4] = new ReportParameter("Localidad", dt.Rows[0]["LOCALIDAD"].ToString());
                        dt = proc.ObtenerUnaFederacion(rnpa);
                        if (dt.Rows.Count == 0)
                        { SoliApo[5] = new ReportParameter("Fed", ""); }
                        else { SoliApo[5] = new ReportParameter("Fed", dt.Rows[0]["NOMBRE"].ToString()); }
                    }
                    else
                    {
                        SoliApo = new ReportParameter[6];
                        dt = proc.Obtener_Pescador(CURP);
                        dt1 = proc.obt_uni(CURP);
                        if (dt1.Rows.Count!=0)
                        {
                            SoliApo[2] = new ReportParameter("Unidad", dt1.Rows[0]["UNIDAD"].ToString());
                        }
                        else
                        {
                            SoliApo[2] = new ReportParameter("Unidad", "");
                        }
                        SoliApo[3] = new ReportParameter("Municipio", dt.Rows[0]["MUNICIPIO"].ToString());
                        SoliApo[4] = new ReportParameter("Localidad", dt.Rows[0]["LOCALIDAD"].ToString());
                        SoliApo[5] = new ReportParameter("Fed", "");
                    }
                    SoliApo[0] = new ReportParameter("NombrePescador", unidad);
                    SoliApo[1] = new ReportParameter("Ord", Ordenado);
                    reportViewer1.LocalReport.SetParameters(SoliApo);
                    reportViewer1.RefreshReport();
                    break;
                case 15:
                    reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Credenciales.rdlc");
                    reportViewer1.LocalReport.DataSources.Clear();
                    datos.Name = "DataSet1";
                    dt= proc.Obtener_Relacion(rnpa);
                    datos.Value = dt;
                    this.reportViewer1.LocalReport.DataSources.Add(datos);
                    ReportParameter[] CRED=new ReportParameter[5];
                    CRED[0] = new ReportParameter("ue", unidad);
                    dt = proc.ObtenerPresidenteUnidad(rnpa);
                    if (dt.Rows.Count==0)
                    {
                        CRED[2] = new ReportParameter("PRESI", "____________________________________________");
                    }
                    else
                    {
                        if (dt.Rows[0]["NOMBREPRESIDENTE"].ToString()=="")
                        {
                            CRED[2] = new ReportParameter("PRESI", "____________________________________________");
                        }
                        else
                        {
                            CRED[2] = new ReportParameter("PRESI", dt.Rows[0]["NOMBREPRESIDENTE"].ToString());
                        }
                    }
                    dt = proc.Obtener_unidades(rnpa);
                    if (dt.Rows[0]["TIPO"].ToString()=="1")
                    {
                        CRED[1] = new ReportParameter("tipo", "PERMICIONARIO");
                    }
                    else
                    {
                        CRED[1] = new ReportParameter("tipo", "UNIDAD ECONOMICA");
                    }
                    CRED[4] = new ReportParameter("muni", dt.Rows[0]["MUNICIO"].ToString().ToUpper());
                    dt = proc.Obtener_Relacion(rnpa);
                    CRED[3] = new ReportParameter("num", dt.Rows.Count.ToString());
                    reportViewer1.LocalReport.SetParameters(CRED);
                    reportViewer1.RefreshReport();
                    break;
                default:
                    break;
            }
        }
        public void DisableUnwantedExportFormat(ReportViewer ReportViewerID, string strFormatName)
        {
            FieldInfo info;
            foreach (RenderingExtension extension in ReportViewerID.LocalReport.ListRenderingExtensions())
            {
                if (extension.Name == strFormatName)
                {
                    info = extension.GetType().GetField("m_isVisible", BindingFlags.Instance | BindingFlags.NonPublic);
                    info.SetValue(extension, false);
                }
            }
        }
    }
}
