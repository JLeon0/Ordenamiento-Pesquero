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
        private void Vistas_Load(object sender, EventArgs e)
        {
            ReportDataSource datos = new ReportDataSource();

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
                    this.vista_permTableAdapter.Fill(permisos_lista.vista_perm, rnpa);
                    reportViewer1.LocalReport.SetParameters(new ReportParameter("Unidad", unidad));
                    this.reportViewer1.RefreshReport();
                    break;
                case 3:
                    this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Embarcaciones.rdlc");
                    this.vista_permTableAdapter.Fill(permisos_lista.vista_perm, rnpa);
                    datos.Name = "DataSet1";
                    datos.Value = permisos_lista.vista_perm;
                    reportViewer1.LocalReport.SetParameters(new ReportParameter("Unidad", unidad));
                    this.reportViewer1.RefreshReport();
                    break;
                default:
                    break;
            }
        }
    }
}
