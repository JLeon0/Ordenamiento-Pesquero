﻿using Logica;
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
using System.Windows.Forms;

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
        string rnpa;
        string unidad;
        int tip;
        Procedimientos proc = new Procedimientos();
        private void Vistas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ordPesqueroDataSet7.Mulege' Puede moverla o quitarla según sea necesario.
            this.mulegeTableAdapter.Fill(this.ordPesqueroDataSet7.Mulege);
            // TODO: esta línea de código carga datos en la tabla 'ordPesqueroDataSet6.LosCabos' Puede moverla o quitarla según sea necesario.
            this.losCabosTableAdapter.Fill(this.ordPesqueroDataSet6.LosCabos);
            // TODO: esta línea de código carga datos en la tabla 'ordPesqueroDataSet5.Loreto' Puede moverla o quitarla según sea necesario.
            this.loretoTableAdapter.Fill(this.ordPesqueroDataSet5.Loreto);
            // TODO: esta línea de código carga datos en la tabla 'ordPesqueroDataSet4.LaPaz' Puede moverla o quitarla según sea necesario.
            this.laPazTableAdapter.Fill(this.ordPesqueroDataSet4.LaPaz);
            // TODO: esta línea de código carga datos en la tabla 'ordPesqueroDataSet3.Comondu' Puede moverla o quitarla según sea necesario.
            this.comonduTableAdapter.Fill(this.ordPesqueroDataSet3.Comondu);
            // TODO: esta línea de código carga datos en la tabla 'todospes.todos' Puede moverla o quitarla según sea necesario.
            this.todosTableAdapter.Fill(this.todospes.todos);
            ReportDataSource datos = new ReportDataSource();
            ReportDataSource datos2 = new ReportDataSource();
            ReportDataSource datos3 = new ReportDataSource();
            ReportDataSource datos4 = new ReportDataSource();
            ReportDataSource datos5 = new ReportDataSource();
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
                    datos.Name = "pescadores";
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
                    this.obtenerImagenTableAdapter.Fill(obtenerImagen._ObtenerImagen, rnpa);
                    ReportParameter[] para1 = new ReportParameter[9];
                    para1[0] = new ReportParameter("NOMBRE", dt1.Rows[0]["NOMBRE"].ToString()+" "+ dt1.Rows[0]["AP_PAT"].ToString()+" "+ dt1.Rows[0]["AP_MAT"].ToString());
                    para1[1] = new ReportParameter("CURP", dt1.Rows[0]["CURP"].ToString());
                    para1[2] = new ReportParameter("SANGRE", dt1.Rows[0]["TIPO_SANGRE"].ToString());
                    para1[3] = new ReportParameter("MATRICULA", dt1.Rows[0]["MATRICULA"].ToString());
                    dt1 = proc.Obtener_unidades(unidad);
                    para1[4] = new ReportParameter("RNPA", unidad);
                    para1[5] = new ReportParameter("TITULAR", unidad);
                    para1[6] = new ReportParameter("FOLIO", unidad);
                    para1[7] = new ReportParameter("DIRECCION", unidad);
                    string ruta = Application.StartupPath.ToString();
                    ruta = ruta.Replace("\\", "*");
                    ruta = ruta.Replace("*", "/");
                    para1[8] = new ReportParameter("RutaImagen", ruta + "perfil.jpg");
                    reportViewer1.LocalReport.SetParameters(para1);
                    this.reportViewer1.RefreshReport();
                    break;
                case 5:
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Pescadores.rdlc");
                    this.todosTableAdapter.Fill(todospes.todos);
                    datos.Name = "vista_perm";
                    datos.Value = todospes.todos;
                    this.reportViewer1.LocalReport.DataSources.Add(datos);
                    this.reportViewer1.RefreshReport();
                    break;
                case 6:
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "ReporteXUnidad.rdlc");
                    this.vista_permTableAdapter.Fill(permisos_lista.vista_perm, rnpa);
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

                    ReportParameter[] para2 = new ReportParameter[4];
                    para2[0]= new ReportParameter("Unidad", "unidad");
                    para2[1] = new ReportParameter("Fed", "unidad");
                    para2[2] = new ReportParameter("Municipio", "unidad");
                    para2[3] = new ReportParameter("Localidad", "unidad");
                    reportViewer1.LocalReport.SetParameters(para2);
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

                    ReportParameter[] para3 = new ReportParameter[5];
                    int x = 0;
                    if (ordPesqueroDataSet7.Mulege.Rows.Count.ToString()==null)
                    {
                        para3[0] = new ReportParameter("totM", "0");
                    }
                    else
                    {
                        para3[0] = new ReportParameter("totM", ordPesqueroDataSet7.Mulege.Rows.Count.ToString());
                    }

                    if (ordPesqueroDataSet3.Comondu.Rows.Count.ToString() == null)
                    {
                        para3[1] = new ReportParameter("totC", "0");
                    }
                    else
                    {
                        para3[1] = new ReportParameter("totC", ordPesqueroDataSet3.Comondu.Rows.Count.ToString());
                    }

                    if (ordPesqueroDataSet4.LaPaz.Rows.Count.ToString() == null)
                    {
                        para3[2] = new ReportParameter("totP", "0");
                    }
                    else
                    {
                        para3[2] = new ReportParameter("totP", ordPesqueroDataSet4.LaPaz.Rows.Count.ToString());
                    }

                    if (ordPesqueroDataSet5.Loreto.Rows.Count.ToString() == null)
                    {
                        para3[2] = new ReportParameter("totL", "0");
                    }
                    else
                    {
                        para3[3] = new ReportParameter("totL", ordPesqueroDataSet5.Loreto.Rows.Count.ToString());
                    }

                    if (ordPesqueroDataSet6.LosCabos.Rows.Count.ToString() == null)
                    {
                        para3[4] = new ReportParameter("totL", "0");
                    }
                    else
                    {
                        para3[4] = new ReportParameter("totCA", ordPesqueroDataSet6.LosCabos.Rows.Count.ToString());
                    }
                    reportViewer1.LocalReport.SetParameters(para3);

                    this.reportViewer1.RefreshReport();
                    break;
                default:
                    break;
            }
        }
    }
}
