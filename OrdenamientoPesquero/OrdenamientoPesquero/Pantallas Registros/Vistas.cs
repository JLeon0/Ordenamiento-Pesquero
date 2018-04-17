﻿using Microsoft.Reporting.WinForms;
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
        public Vistas( string parametro, string uni)
        {
            InitializeComponent();
            rnpa = parametro;
            unidad = uni;
        }
        string rnpa;
        string unidad;
        private void Vistas_Load(object sender, EventArgs e)
        {
            this.pescadoresTableAdapter.Fill(ordPesqueroDataSet1.pescadores, rnpa);
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Unidad", unidad));
            this.reportViewer1.RefreshReport();
        }
    }
}
