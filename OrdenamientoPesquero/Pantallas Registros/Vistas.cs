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
        public Vistas( string parametro, string uni, int tipo)
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
            ReportDataSource datos = new ReportDataSource();
            if (unidad=="")
            {
                unidad = rnpa;
            }
            switch (tip)
            {
                case 1:
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    this.reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Report3.rdlc");
                    this.pescadoresTableAdapter.Fill(ordPesqueroDataSet1.pescadores, rnpa);
                    datos.Name = "pescadores";
                    datos.Value = ordPesqueroDataSet1.pescadores;
                    this.reportViewer1.LocalReport.DataSources.Add(datos);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter("Unidad", unidad));
                    this.reportViewer1.RefreshReport();
                    break;
                case 2:
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Permisos.rdlc");
                    this.vista_permTableAdapter1.Fill(dataSetPermisos.vista_perm, rnpa);
                    datos.Name = "vista_perm";
                    datos.Value = dataSetPermisos.vista_perm;
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
                    string na = n[6].ToString()+ n[7].ToString();
                    int nac= Convert.ToInt32(na);
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
                default:
                    break;
            }
        }
    }
}
