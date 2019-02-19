using CapaDatos;
using Logica;
using Microsoft.Reporting.WinForms;
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
    public partial class Personalizar : Form
    {
        public Personalizar()
        {
            InitializeComponent();
        }
        Procedimientos proc = new Procedimientos();
        ReportDataSource ds = new ReportDataSource();

        private void Personalizar_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            ds.Name = "Consulta";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Pescador_Personal.rdlc");
            bool[] column = new bool[17];
            string[] dato = new string[17];
            int i = 0;
            foreach (CheckBox a in ColumasPescador.Controls)
            {
                column[i] = a.Checked;
                dato[i] = a.Text.Replace(" ","_");
                dato[i] = dato[i].ToLower();
                i++;
            }
            ReportParameter[] para = new ReportParameter[17];
            for (int c = 0; c < 17; c++)
            {
                para[c] = new ReportParameter(dato[c], column[c].ToString());
            }
            reportViewer1.LocalReport.SetParameters(para);
            string consulta = "Select FOLIO, PESCADOR.NOMBRE + PESCADOR.AP_PAT + PESCADOR.AP_MAT AS 'NOMBRE',PESCADOR.FECHA_NACIMIENTO,SEGURO, CURP, PESCADOR.MUNICIPIO, PESCADOR.LOCALIDAD, TIPO_PESCADOR, OCUPACION_LABORAL, TELEFONO, CORREO, CALLENUM+', Col. '+COLONIA AS 'DIRECCION', ESCOLARIDAD,RFC, ORDENAMIENTO, PESCADOR.MATRICULA, NOMBREEMBARCACION,RFC AS EMBARCACION from PESCADOR, EMBARCACIONES WHERE PESCADOR.MATRICULA = EMBARCACIONES.MATRICULA";
            int r = 0;
            foreach (CheckBox a in FiltrosPescador.Controls.OfType<CheckBox>())
            {
                if (a.Checked)
                {
                    if (a.Text== "Municipio")
                    {
                        consulta += " AND PESCADOR." + a.Text.Replace(" ", "_").ToLower() + " = ";
                    }
                    else
                    {
                        consulta += " AND " + a.Text.Replace(" ", "_").ToLower() + " = ";
                    }
                    int m = 0;
                    foreach (ComboBox cb in FiltrosPescador.Controls.OfType<ComboBox>())
                    {
                        if (m==r)
                        {
                            consulta += "'"+cb.Text+"'";
                            break;
                        }
                        m++;
                    }
                }
                r++;
            }
            consulta += " Order by "+comboBox5.Text.Replace(" ","_");
            ds.Value = proc.ObtenerTablaConsulta(consulta);
            this.reportViewer1.LocalReport.DataSources.Add(ds);
            this.reportViewer1.s
            this.reportViewer1.RefreshReport();
        }
    }
}
