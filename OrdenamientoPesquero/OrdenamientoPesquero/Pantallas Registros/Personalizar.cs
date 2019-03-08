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
        DataTable dt;

        private void Personalizar_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            ds.Name = "Consulta";
            dt = proc.Obtener_todos_los_nombres("");
            comboBox14.DataSource = dt;
            comboBox14.ValueMember = "Nombre";
            comboBox14.DisplayMember = "Nombre";
            comboBox5.DataSource = dt;
            comboBox5.ValueMember = "Nombre";
            comboBox5.DisplayMember = "Nombre";
            comboBox13.DataSource = proc.ObtenerPesquerias();
            comboBox13.ValueMember="PESQUERIA";
            comboBox13.DisplayMember = "PESQUERIA";
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
                dato[i] = a.Text.Replace(" ", "_");
                dato[i] = dato[i].ToLower();
                i++;
            }
            ReportParameter[] para = new ReportParameter[17];
            for (int c = 0; c < 17; c++)
            {
                para[c] = new ReportParameter(dato[c], column[c].ToString());
            }
            reportViewer1.LocalReport.SetParameters(para);
            string consulta = "Select FOLIO, PESCADOR.NOMBRE + PESCADOR.AP_PAT + PESCADOR.AP_MAT AS 'NOMBRE',PESCADOR.FECHA_NACIMIENTO,SEGURO, CURP, PESCADOR.MUNICIPIO, PESCADOR.LOCALIDAD, TIPO_PESCADOR, OCUPACION_LABORAL, TELEFONO, CORREO, CALLENUM+', Col. '+COLONIA AS 'DIRECCION', ESCOLARIDAD,RFC, ORDENAMIENTO, PESCADOR.MATRICULA, NOMBREEMBARCACION AS EMBARCACION from PESCADOR, EMBARCACIONES WHERE PESCADOR.MATRICULA = EMBARCACIONES.MATRICULA";
            int r = 0;
            foreach (CheckBox a in FiltrosPescador.Controls.OfType<CheckBox>())
            {
                if (a.Checked)
                {
                    if (a.Text == "Municipio")
                    {
                        consulta += " AND PESCADOR." + a.Text.Replace(" ", "_").ToLower() + " = ";
                    }
                    else
                    {
                        if (a.Text == "U.E.")
                        {
                            consulta += " AND RNPTITULAR = ";
                        }
                        else
                        {
                            consulta += " AND " + a.Text.Replace(" ", "_").ToLower() + " = ";
                        }
                    }
                    int m = 0;
                    foreach (ComboBox cb in FiltrosPescador.Controls.OfType<ComboBox>())
                    {
                        if (m == r)
                        {
                            if (a.Text=="U.E.")
                            {
                                consulta += "'" + dt.Rows[comboBox14.SelectedIndex]["RNPA"] + "'";
                            }
                            else
                            {
                                consulta += "'" + cb.Text + "'";
                            }
                            break;
                        }
                        m++;
                    }
                }
                r++;
            }
            consulta += " Order by " + OrdenaPescador.Text.Replace(" ", "_");
            ds.Value = proc.ObtenerTablaConsulta(consulta);
            this.reportViewer1.LocalReport.DataSources.Add(ds);
            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Unidad_Personal.rdlc");
            bool[] column = new bool[10];
            string[] dato = new string[10];
            int i = 0;
            foreach (CheckBox a in ColumasUnidad.Controls)
            {
                column[i] = a.Checked;
                dato[i] = a.Text.Replace(" ", "_");
                dato[i] = dato[i].ToLower();
                i++;
            }
            ReportParameter[] para = new ReportParameter[10];
            for (int c = 0; c < 10; c++)
            {
                para[c] = new ReportParameter(dato[c], column[c].ToString());
            }
            reportViewer1.LocalReport.SetParameters(para);
            string consulta = "SELECT RNPA,NOMBRE,RFC,MUNICIO, LOCALIDAD,CALLEYNUM+', COL. '+COLONIA AS DIRECCION, CODIGO_POSTAL, CORREO, TELEFONO, TIPO FROM UNIDAD_ECONOMICA WHERE NOMBRE!=''";
            int r = 0;
            foreach (CheckBox a in FiltrosUnidad.Controls.OfType<CheckBox>())
            {
                if (a.Checked)
                {
                    if (a.Text == "Municipio")
                    {
                        consulta += " AND MUNICIO" + " = ";
                    }
                    else
                    {
                        consulta += " AND " + a.Text.Replace(" ", "_").ToLower() + " = ";
                    }
                    int m = 0;
                    foreach (ComboBox cb in FiltrosUnidad.Controls.OfType<ComboBox>())
                    {
                        if (m == r)
                        {
                            if (a.Text=="Tipo")
                            {
                                consulta += "'" + cb.SelectedIndex + "'";
                                break;
                            }
                            else
                            {
                                consulta += "'" + cb.Text + "'";
                                break;
                            }
                        }
                        m++;
                    }
                }
                r++;
            }
            consulta += " Order by " + OrdenaUnidad.Text.Replace(" ", "_");
            ds.Value = proc.ObtenerTablaConsulta(consulta);
            this.reportViewer1.LocalReport.DataSources.Add(ds);
            this.reportViewer1.RefreshReport();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Permiso_Personal.rdlc");
            bool[] column = new bool[13];
            string[] dato = new string[13];
            int i = 0;
            foreach (CheckBox a in ColumnasPermiso.Controls)
            {
                column[i] = a.Checked;
                dato[i] = a.Text.Replace(" ", "");
                dato[i] = dato[i].ToLower();
                i++;
            }
            ReportParameter[] para = new ReportParameter[13];
            for (int c = 0; c < 13; c++)
            {
                para[c] = new ReportParameter(dato[c], column[c].ToString());
            }
            reportViewer1.LocalReport.SetParameters(para);
            string consulta = "Select FOLIO, RNPA, NPERMISO, PESQUERIA, LUGAREXPEDICION, DIAEXPEDICION, FINVIGENCIA, ZONAPESCA, SITIOSDESEMBARQUE, OBSERVACIONES, TIPOPERMISO, ((STUFF(( SELECT ', '+ CANTIDAD +' '+TIPO FROM EQUIPOSPESCA a WHERE b.NPERMISO = a.NUMPERMISO FOR XML PATH('')),1 ,1, ''))) AS 'EQUIPOSDEPESCA', ((STUFF((SELECT ', ' + NOMBREEMBARCACION FROM EMBARCACIONES a, EMBARCA_PERMIS c  WHERE b.NPERMISO = c.PERMISO and a.MATRICULA = c.MATRICULA FOR XML PATH('')),1 ,1, ''))) AS 'EMBARCACIONES' from PERMISOS b where rnpa != ''";
            int r = 0;
            foreach (CheckBox a in FiltrosPermiso.Controls.OfType<CheckBox>())
            {
                if (a.Checked)
                {
                    if (a.Text == "Municipio")
                    {
                        consulta += " AND PESCADOR." + a.Text.Replace(" ", "").ToLower() + " = ";
                    }
                    else
                    {
                        consulta += " AND " + a.Text.Replace(" ", "").ToLower() + " = ";
                    }
                    int m = 0;
                    foreach (ComboBox cb in FiltrosPermiso.Controls.OfType<ComboBox>())
                    {
                        if (m == r)
                        {
                            if (a.Text=="Tipo Permiso")
                            {
                                consulta += "'" + cb.SelectedIndex.ToString() + "'";
                                break;
                            }
                            consulta += "'" + cb.Text + "'";
                            break;
                        }
                        m++;
                    }
                }
                r++;
            }
            consulta += " Order by " + OrdenaPermiso.Text.Replace(" ", "");
            ds.Value = proc.ObtenerTablaConsulta(consulta);
            this.reportViewer1.LocalReport.DataSources.Add(ds);
            this.reportViewer1.RefreshReport();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Embarcacion_Personal.rdlc");
            bool[] column = new bool[20];
            string[] dato = new string[20];
            int i = 0;
            foreach (CheckBox a in ColumnasEmbarca.Controls)
            {
                column[i] = a.Checked;
                dato[i] = a.Text.Replace(" ", "_");
                dato[i] = dato[i].ToLower();
                i++;
            }
            ReportParameter[] para = new ReportParameter[20];
            for (int c = 0; c < 20; c++)
            {
                para[c] = new ReportParameter(dato[c], column[c].ToString());
            }
            reportViewer1.LocalReport.SetParameters(para);
            string consulta = "select * from EMBARCACIONES where nombreembarcacion!='NO APLICA'";
            if (checkBox32.Checked)
            {
                consulta += " AND RNPTITULAR = '" + dt.Rows[comboBox14.SelectedIndex]["RNPA"]+"'";
            }
            if (checkBox71.Checked)
            {
                consulta += " AND NUMCHIP = '" + chip.Text + "'";
            }
            consulta += " Order by " + OrdenaEmbarca.Text.Replace(" ", "");
            ds.Value = proc.ObtenerTablaConsulta(consulta);
            this.reportViewer1.LocalReport.DataSources.Add(ds);
            this.reportViewer1.RefreshReport();
        }
    }
}

