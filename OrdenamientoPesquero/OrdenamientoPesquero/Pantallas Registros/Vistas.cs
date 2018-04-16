using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenamientoPesquero.Pantallas_Registros
{
    public partial class Vistas : Form
    {
        public Vistas( string parametro)
        {
            InitializeComponent();
            rnpa = parametro;
        }
        string rnpa;
        private void Vistas_Load(object sender, EventArgs e)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            try
            {
                this.pescadoresTableAdapter1.Fill(this.ordPesqueroDataSet41.pescadores, rnpa);
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ordPesqueroDataSet41"));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception asd)
            {
                throw;
            }
        }
    }
}
