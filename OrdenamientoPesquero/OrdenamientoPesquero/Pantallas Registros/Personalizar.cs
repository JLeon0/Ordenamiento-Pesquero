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
        public Personalizar(string bdd)
        {
            InitializeComponent();
            BD = bdd;
        }
        Procedimientos proc = new Procedimientos();
        ReportDataSource ds = new ReportDataSource();
        ReportDataSource ds2 = new ReportDataSource();
        ReportDataSource ds3 = new ReportDataSource();
        DataTable dt;
        DataTable dt3;
        string[] Municipios;
        string BD;
        private void Personalizar_Load(object sender, EventArgs e)
        {
            proc.bdd = BD;
            proc.cambiarbd(proc.bdd);
            dt3 = proc.ObtenerMunicipios();
            this.reportViewer1.RefreshReport();
            ds.Name = "Consulta";
            DataTable dt2 = proc.Obtener_Programa();
            comboBox7.DataSource = dt2;
            comboBox7.DisplayMember = "PROGRAMA";
            comboBox7.ValueMember = "PROGRAMA";
            dt = proc.Obtener_todos_los_nombres("");
            comboBox14.DataSource = dt;
            comboBox14.ValueMember = "Nombre";
            comboBox14.DisplayMember = "Nombre";
            comboBox11.DataSource = dt;
            comboBox11.ValueMember = "Nombre";
            comboBox11.DisplayMember = "Nombre";
            comboBox19.DataSource = dt;
            comboBox19.ValueMember = "Nombre";
            comboBox19.DisplayMember = "Nombre";
            comboBox5.DataSource = dt;
            comboBox5.ValueMember = "Nombre";
            comboBox5.DisplayMember = "Nombre";
            comboBox13.DataSource = proc.ObtenerPesquerias();
            comboBox13.ValueMember = "PESQUERIA";
            comboBox13.DisplayMember = "PESQUERIA";
            if (dt3.Rows.Count != 0)
            {
                Municipios = dt3.Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray();
                comboBox22.DataSource = dt3;
                comboBox22.DisplayMember = "NombreM";
                comboBox22.ValueMember = "NombreM";
                comboBox22.Text = "Seleccione un Municipio";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Pescador_Personal.rdlc");
            bool[] column = new bool[18];
            string[] dato = new string[18];
            int i = 0;
            foreach (CheckBox a in ColumasPescador.Controls)
            {
                if (a.Text != "TODOS")
                {
                    column[i] = a.Checked;
                    dato[i] = a.Text.Replace(" ", "_");
                    dato[i] = dato[i].ToLower();
                    i++;
                }
            }
            ReportParameter[] para = new ReportParameter[18];
            for (int c = 0; c < 18; c++)
            {
                para[c] = new ReportParameter(dato[c], column[c].ToString());
            }
            reportViewer1.LocalReport.SetParameters(para);
            string consulta = "Select FOLIO, PESCADOR.NOMBRE + ' '+PESCADOR.AP_PAT +' '+ PESCADOR.AP_MAT AS 'NOMBRE',PESCADOR.FECHA_NACIMIENTO,SEGURO, CURP, PESCADOR.MUNICIPIO, PESCADOR.LOCALIDAD, TIPO_PESCADOR, OCUPACION_LABORAL, TELEFONO, CORREO, CALLENUM+', Col. '+COLONIA AS 'DIRECCION', ESCOLARIDAD,RFC, ORDENAMIENTO, PESCADOR.MATRICULA, NOMBREEMBARCACION AS EMBARCACION, (SELECT NOMBRE FROM UNIDAD_ECONOMICA WHERE RNPTITULAR=RNPA) As Unidad, (SELECT CASE WHEN CURP IN(SELECT CURP FROM ARCHIVOSPESCADOR WHERE IMAGEN IS NOT NULL AND FIRMA IS NOT NULL AND FIRMA != '')THEN 'Si'ELSE 'No' END) as Credencializados from PESCADOR, EMBARCACIONES WHERE PESCADOR.MATRICULA = EMBARCACIONES.MATRICULA";
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
                            if (a.Text == "U.E.")
                            {
                                consulta += "'" + dt.Rows[comboBox14.SelectedIndex]["RNPA"] + "'";
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
            consulta += " Order by " + OrdenaPescador.Text.Replace(" ", "_");
            ds.Value = proc.ObtenerTablaConsulta(consulta);
            this.reportViewer1.LocalReport.DataSources.Add(ds);
            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Unidad_Personal.rdlc");
            bool[] column = new bool[13];
            string[] dato = new string[13];
            int i = 0;
            foreach (CheckBox a in ColumasUnidad.Controls)
            {
                if (a.Text != "TODOS")
                {
                    column[i] = a.Checked;
                    dato[i] = a.Text.Replace(" ", "_");
                    dato[i] = dato[i].ToLower();
                    i++;
                }
            }
            ReportParameter[] para = new ReportParameter[13];
            for (int c = 0; c < 13; c++)
            {
                para[c] = new ReportParameter(dato[c], column[c].ToString());
            }
            reportViewer1.LocalReport.SetParameters(para);
            string consulta = "SELECT UNIDAD_ECONOMICA.RNPA,UNIDAD_ECONOMICA.NOMBRE,RFC,MUNICIO, LOCALIDAD,CALLEYNUM+', COL. '+COLONIA AS DIRECCION, CODIGO_POSTAL, UNIDAD_ECONOMICA.CORREO, UNIDAD_ECONOMICA.TELEFONO, (SELECT NOMBREPRESIDENTE FROM PRESIDENTEUNIDAD WHERE PRESIDENTEUNIDAD.RNPA = UNIDAD_ECONOMICA.RNPA) AS 'PRESIDENTE', (SELECT TELEFONOPRESIDENTE FROM PRESIDENTEUNIDAD WHERE PRESIDENTEUNIDAD.RNPA = UNIDAD_ECONOMICA.RNPA) AS 'TELEFONOPRESIDENTE', (SELECT TOP 1 FEDERACIONES.NOMBRE FROM FEDERACIONES_UNIDADES, FEDERACIONES WHERE FEDERACIONES_UNIDADES.FEDERACION = FEDERACIONES.FOLIO AND FEDERACIONES_UNIDADES.RNPA = UNIDAD_ECONOMICA.RNPA) AS 'FEDERACION', TIPO FROM UNIDAD_ECONOMICA WHERE NOMBRE != ''";
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
                            if (a.Text == "Tipo")
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
                if (a.Text != "TODOS")
                {
                    column[i] = a.Checked;
                    dato[i] = a.Text.Replace(" ", "");
                    dato[i] = dato[i].ToLower();
                    i++;
                }
            }
            ReportParameter[] para = new ReportParameter[13];
            for (int c = 0; c < 13; c++)
            {
                para[c] = new ReportParameter(dato[c], column[c].ToString());
            }
            reportViewer1.LocalReport.SetParameters(para);
            string consulta = "Select FOLIO, RNPA, NPERMISO, PESQUERIA, LUGARE0XPEDICION, DIAEXPEDICION, FINVIGENCIA, ZONAPESCA, SITIOSDESEMBARQUE, OBSERVACIONES, TIPOPERMISO, ((STUFF(( SELECT ', '+ CANTIDAD +' '+TIPO FROM EQUIPOSPESCA a WHERE b.NPERMISO = a.NUMPERMISO FOR XML PATH('')),1 ,1, ''))) AS 'EQUIPOSDEPESCA', ((STUFF((SELECT ', ' + NOMBREEMBARCACION FROM EMBARCACIONES a, EMBARCA_PERMIS c  WHERE b.NPERMISO = c.PERMISO and a.MATRICULA = c.MATRICULA FOR XML PATH('')),1 ,1, ''))) AS 'EMBARCACIONES' from PERMISOS b where rnpa != ''";
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
                            if (a.Text == "Tipo Permiso")
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
            if (checkBox71.Checked|| checkBox75.Checked|| checkBox94.Checked)
            {
                reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Embarca.rdlc");
                string param = "";
                if (checkBox71.Checked)
                {
                    param = chip.Text;
                }
                if (checkBox75.Checked)
                {
                    param = comboBox6.Text;
                }
                if (checkBox94.Checked)
                {
                    param = textBox1.Text;
                }
                DataTable dt4;
                dt4 = proc.Obtener_Capitan(param);
                ReportParameter[] para = new ReportParameter[1];
                if (dt4.Rows.Count > 0)
                {
                    para[0] = new ReportParameter("Capitan", dt4.Rows[0][0].ToString());
                }
                else
                {
                    para[0] = new ReportParameter("Capitan", "");
                }
                ds.Name = "marineros";
                ds.Value = proc.Obtener_Marineros(param);
                ds2.Name = "buzos";
                ds2.Value = proc.Obtener_Buzos(param);
                ds3.Name = "DataSet1";
                string consulta = "select * from EMBARCACIONES where NUMCHIP='" + chip.Text + "'";
                string consulta2 = "select * from EMBARCACIONES where nombreembarcacion='" + comboBox6.Text + "'";
                string consulta3 = "select * from EMBARCACIONES where matricula='" + textBox1.Text + "'";
                if (checkBox71.Checked)
                {
                    ds3.Value = proc.ObtenerTablaConsulta(consulta);
                }
                if (checkBox75.Checked)
                {
                    ds3.Value = proc.ObtenerTablaConsulta(consulta2);
                }
                if (checkBox74.Checked)
                {
                    ds3.Value = proc.ObtenerTablaConsulta(consulta3);
                }
                reportViewer1.LocalReport.DataSources.Add(ds);
                reportViewer1.LocalReport.DataSources.Add(ds2);
                reportViewer1.LocalReport.DataSources.Add(ds3);
                reportViewer1.LocalReport.SetParameters(para);
            }
            else
            {
                reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Embarcacion_Personal.rdlc");
                bool[] column = new bool[21];
                string[] dato = new string[21];
                int i = 0;
                foreach (CheckBox a in ColumnasEmbarca.Controls)
                {
                    if (a.Text != "TODOS")
                    {
                        column[i] = a.Checked;
                        dato[i] = a.Text.Replace(" ", "_");
                        dato[i] = dato[i].ToLower();
                        i++;
                    }
                }
                ReportParameter[] para = new ReportParameter[21];
                for (int c = 0; c < 21; c++)
                {
                    para[c] = new ReportParameter(dato[c], column[c].ToString());
                }
                reportViewer1.LocalReport.SetParameters(para);
                string consulta = "select NOMBRE AS 'UNIDAD',EMBARCACIONES.* from EMBARCACIONES, UNIDAD_ECONOMICA where nombreembarcacion!='NO APLICA' AND RNPA=RNPTITULAR" ;
                //int r = 0;
                //foreach (CheckBox it in FiltrosEmbarca.Controls.OfType<CheckBox>())
                //{
                    //if (it.Checked)
                    //{
                        if (checkBox32.Checked)
                        {
                            consulta += " AND RNPTITULAR = '" + dt.Rows[comboBox14.SelectedIndex]["RNPA"] + "'";
                        }
                        //if (it.Text=="Nombre")
                        //{
                        //    consulta += " AND nombreembarcacion =";
                        //}
                        //if (it.Text!="Nombre"&&it.Text!="Unidad Economica")
                        //{
                        //    consulta += " AND" + it.Text.ToLower();
                        //}
                //        int m = 0;
                //        foreach (ComboBox cb in FiltrosEmbarca.Controls.OfType<ComboBox>())
                //        {
                //            if (it.Text=="Unidad Economica")
                //            {
                //                break;
                //            }
                //            else
                //            {
                //                if (r==m)
                //                {
                //                    consulta += "'" + cb.Text + "'";
                //                }
                //            }
                //            m++;
                //        }
                //        r++;
                //    }
                //}
                consulta += " Order by " + OrdenaEmbarca.Text.Replace(" ", "");
                ds.Value = proc.ObtenerTablaConsulta(consulta);
                //reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(ds);
            }
            this.reportViewer1.RefreshReport();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Solicitudes_Personal.rdlc");
            bool[] column = new bool[17];
            string[] dato = new string[17];
            int i = 0;
            foreach (CheckBox a in ColumnasSolicitudes.Controls)
            {
                if (a.Text!="TODOS")
                {
                    column[i] = a.Checked;
                    dato[i] = a.Text.Replace(" ", "_");
                    i++;
                }
            }
            ReportParameter[] para = new ReportParameter[17];
            for (int c = 0; c < 17; c++)
            {
                para[c] = new ReportParameter(dato[c], column[c].ToString());
            }
            string inac = "AND (b.ESTATUS = 'Negativa' OR b.ESTATUS='Cancelada' OR b.ESTATUS='Positiva sin TP')";
            string act = "AND (b.ESTATUS = 'Pendiente'OR b.ESTATUS='Positiva con TP')";
            string apo = "AND b.ESTATUS = 'ENTREGADO'";
            string año = "AND Substring(b.FECHA,7,4) ='";
            string consulta = "SELECT b.*, (SELECT NOMBRE FROM UNIDAD_ECONOMICA WHERE RNPA IN (SELECT RNPTITULAR FROM EMBARCACIONES, PESCADOR WHERE EMBARCACIONES.MATRICULA= PESCADOR.MATRICULA And PESCADOR.CURP=b.curp)) AS Unidad FROM SOLICITUDES b WHERE b.NOMBRE!= '' ";
            int r = 0;
            reportViewer1.LocalReport.SetParameters(para);
            foreach (CheckBox a in FiltrosSolicitudes.Controls.OfType<CheckBox>())
            {
                if (a.Checked)
                {
                    if (a.Text != "Tipo"&&a.Text!="Año"&&a.Text!="Unidad")
                    {
                        consulta += " AND b." + a.Text.Replace(" ", "_").ToLower() + " = ";
                    }
                int m = 0;
                foreach (ComboBox cb in FiltrosSolicitudes.Controls.OfType<ComboBox>())
                {
                    if (a.Text == "Tipo")
                    {
                        switch (comboBox16.SelectedIndex)
                        {
                            case 0:
                                consulta += act;
                                break;
                            case 1:
                                consulta += inac;
                                break;
                            case 2:
                                consulta += apo;
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                    else
                    {
                        if (a.Text == "Prioridad")
                        {
                            consulta += "'" + numericUpDown1.Text + "'";
                            break;
                        }
                        else
                        {
                                if (a.Text=="Año")
                                {
                                    consulta += año + numericUpDown2.Text+"'";
                                    break;
                                }
                                else
                                {
                                    if (a.Text=="Unidad")
                                    {
                                        consulta += "AND (SELECT NOMBRE FROM UNIDAD_ECONOMICA WHERE RNPA IN (SELECT RNPTITULAR FROM EMBARCACIONES, PESCADOR WHERE EMBARCACIONES.MATRICULA= PESCADOR.MATRICULA And PESCADOR.CURP=b.curp))='" + comboBox11.Text + "'";
                                        break;
                                    }
                                    else
                                    {
                                        if (m == r)
                                        {
                                            consulta += "'" + cb.Text + "'";
                                            break;
                                        }
                                    }
                                }
                        }
                    }
                    m++;
                }
            }
                if (a.Text == "Año" || a.Text == "Prioridad")
                {
                    r--;
                }
                r++;
            }
            consulta += " Order by " + OrdenSoli.Text.Replace(" ", "");
             ds.Value = proc.ObtenerTablaConsulta(consulta);
            ds.Name = "Solicitudes";
            this.reportViewer1.LocalReport.DataSources.Add(ds);
            this.reportViewer1.RefreshReport();
        }

        private void checkBox100_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox100.Checked)
            {
                foreach (CheckBox item in ColumasUnidad.Controls.OfType<CheckBox>())
                {
                    item.Checked = true;
                }
            }
            else
            {
                foreach (CheckBox item in ColumasUnidad.Controls.OfType<CheckBox>())
                {
                    item.Checked = false;
                }
            }
        }

        private void checkBox99_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox99.Checked)
            {
                foreach (CheckBox item in ColumnasPermiso.Controls.OfType<CheckBox>())
                {
                    item.Checked = true;
                }
            }
            else
            {
                foreach (CheckBox item in ColumnasPermiso.Controls.OfType<CheckBox>())
                {
                    item.Checked = false;
                }
            }
        }

        private void checkBox98_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox98.Checked)
            {
                foreach (CheckBox item in ColumnasEmbarca.Controls.OfType<CheckBox>())
                {
                    item.Checked = true;
                }
            }
            else
            {
                foreach (CheckBox item in ColumnasEmbarca.Controls.OfType<CheckBox>())
                {
                    item.Checked = false;
                }
            }
        }

        private void checkBox97_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox97.Checked)
            {
                foreach (CheckBox item in ColumnasSolicitudes.Controls.OfType<CheckBox>())
                {
                    item.Checked = true;
                }
            }
            else
            {
                foreach (CheckBox item in ColumnasSolicitudes.Controls.OfType<CheckBox>())
                {
                    item.Checked = false;
                }
            }
        }

        private void checkBox101_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox101.Checked)
            {
                foreach (CheckBox item in ColumasPescador.Controls.OfType<CheckBox>())
                {
                    item.Checked = true;
                }
            }
            else
            {
                foreach (CheckBox item in ColumasPescador.Controls.OfType<CheckBox>())
                {
                    item.Checked = false;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Cred_Personal.rdlc");
            bool[] column = new bool[14];
            string[] dato = new string[14];
            int i = 0;
            foreach (CheckBox a in ColumnasCred.Controls)
            {
                if (a.Text != "TODOS")
                {
                    column[i] = a.Checked;
                    dato[i] = a.Text.Replace(" ", "_");
                    dato[i] = dato[i].ToLower();
                    i++;
                }
            }
            ReportParameter[] para = new ReportParameter[14];
            for (int c = 0; c < 14; c++)
            {
                para[c] = new ReportParameter(dato[c], column[c].ToString());
            }
            reportViewer1.LocalReport.SetParameters(para);
            string consulta = "	   Select FOLIO, PESCADOR.NOMBRE + ' '+PESCADOR.AP_PAT +' '+ PESCADOR.AP_MAT AS 'NOMBRE', CURP, PESCADOR.MUNICIPIO, PESCADOR.LOCALIDAD, TIPO_PESCADOR, OCUPACION_LABORAL, PESCADOR.MATRICULA, NOMBREEMBARCACION AS EMBARCACION, (SELECT NOMBRE FROM UNIDAD_ECONOMICA WHERE RNPTITULAR=RNPA) As Unidad, (SELECT CASE WHEN CURP IN(SELECT CURP FROM ARCHIVOSPESCADOR WHERE ACTANAC IS NOT NULL)THEN 'Si'ELSE 'No' END) AS 'ACTA_DE_NACIMIENTO', (SELECT CASE WHEN CURP IN(SELECT CURP FROM ARCHIVOSPESCADOR WHERE ACURP IS NOT NULL)THEN 'Si'ELSE 'No' END) AS 'DCURP', (SELECT CASE WHEN CURP IN(SELECT CURP FROM ARCHIVOSPESCADOR WHERE AINE IS NOT NULL)THEN 'Si'ELSE 'No' END) AS 'INE', (SELECT CASE WHEN CURP IN(SELECT CURP FROM ARCHIVOSPESCADOR WHERE ACOMPDOM IS NOT NULL)THEN 'Si'ELSE 'No' END) AS 'COMPROBANTE_DE_DOMICILIO' from PESCADOR, EMBARCACIONES WHERE PESCADOR.MATRICULA = EMBARCACIONES.MATRICULA AND (SELECT CASE WHEN CURP IN(SELECT CURP FROM ARCHIVOSPESCADOR WHERE IMAGEN IS NOT NULL AND FIRMA IS NOT NULL AND FIRMA != '')THEN 'Si'ELSE 'No' END)='Si'";
            int r = 0;
            foreach (CheckBox a in FiltrosCred.Controls.OfType<CheckBox>())
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
                    foreach (ComboBox cb in FiltrosCred.Controls.OfType<ComboBox>())
                    {
                        if (m == r)
                        {
                            if (a.Text == "U.E.")
                            {
                                consulta += "'" + dt.Rows[comboBox14.SelectedIndex]["RNPA"] + "'";
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
            consulta += " Order by " + OrdenaPescador.Text.Replace(" ", "_");
            ds.Value = proc.ObtenerTablaConsulta(consulta);
            this.reportViewer1.LocalReport.DataSources.Add(ds);
            this.reportViewer1.RefreshReport();
        }

        private void comboBox22_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt4 = proc.ObtenerLocalidades(Municipios[comboBox22.SelectedIndex]);
            comboBox21.DataSource = dt4;
            comboBox21.DisplayMember = "NombreL";
            comboBox21.ValueMember = "NombreL";
            comboBox21.Text = "";
        }

        private void checkBox111_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox111.Checked)
            {
                foreach (CheckBox item in ColumnasCred.Controls.OfType<CheckBox>())
                {
                    item.Checked = true;
                }
            }
            else
            {
                foreach (CheckBox item in ColumnasCred.Controls.OfType<CheckBox>())
                {
                    item.Checked = false;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Occisos_Personal.rdlc");
            bool[] column = new bool[18];
            string[] dato = new string[18];
            int i = 0;
            foreach (CheckBox a in ColumnasOccisos.Controls)
            {
                if (a.Text != "TODOS")
                {
                    column[i] = a.Checked;
                    dato[i] = a.Text.Replace(" ", "_");
                    dato[i] = dato[i].ToLower();
                    i++;
                }
            }
            ReportParameter[] para = new ReportParameter[24];
            for (int c = 0; c < 24; c++)
            {
                para[c] = new ReportParameter(dato[c], column[c].ToString());
            }
            reportViewer1.LocalReport.SetParameters(para);
            string consulta = "Select FOLIO, OCCISOS.NOMBRE + ' '+OCCISOS.AP_PAT +' '+ OCCISOS.AP_MAT AS 'NOMBRE',OCCISOS.FECHA_NACIMIENTO,SEGURO, CURP, OCCISOS.MUNICIPIO, OCCISOS.LOCALIDAD, TIPO_OCCISOS, OCUPACION_LABORAL, TELEFONO, CORREO, CALLENUM+', Col. '+COLONIA AS 'DIRECCION', ESCOLARIDAD,RFC, ORDENAMIENTO, OCCISOS.MATRICULA, NOMBREEMBARCACION AS EMBARCACION, (SELECT NOMBRE FROM UNIDAD_ECONOMICA WHERE RNPTITULAR=RNPA) As Unidad from OCCISOS, EMBARCACIONES WHERE OCCISOS.MATRICULA = EMBARCACIONES.MATRICULA";
            int r = 0;
            foreach (CheckBox a in FiltrosOccisos.Controls.OfType<CheckBox>())
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
                            if (a.Text == "U.E.")
                            {
                                consulta += "'" + dt.Rows[comboBox14.SelectedIndex]["RNPA"] + "'";
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
            consulta += " Order by " + OrdenaPescador.Text.Replace(" ", "_");
            ds.Value = proc.ObtenerTablaConsulta(consulta);
            this.reportViewer1.LocalReport.DataSources.Add(ds);
            this.reportViewer1.RefreshReport();
        }
    }
}

