using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace OrdenamientoPesquero.Pantallas_Archivos
{
    public partial class Expediente_UE : Form
    {
        Procedimientos proc = new Procedimientos();
        Validaciones val = new Validaciones();
        string RNPA = "";
        int exito = 0, TIPO = 0;
        Scanner scan;

        public Expediente_UE(string rnpa, string nombre,int tipo)
        {
            InitializeComponent();
            RNPA = rnpa;
            Nombre.Text = nombre;
            TIPO = tipo;
        }

        private void Expediente_UE_Load(object sender, EventArgs e)
        {
            CargarExpedienteUnidad();
            dgvUnidad.ClearSelection();
            CargarExpedienteEmbarcacion();
            CargarExpedientePescador();
            CargarExpedientePermisos();
        }
        private void CargarExpedienteUnidad()
        {
            DataTable expediente = proc.ObtenerExpedienteUnidad(RNPA);
            if (TIPO == 0)
            {
                dgvUnidad.RowCount = 6;
                dgvUnidad[0, 0].Value = "Acta Constitutiva";
                dgvUnidad[0, 1].Value = "Acta de Asamblea";
                dgvUnidad[0, 2].Value = "RFC UE";
                dgvUnidad[0, 3].Value = "Comp Domicilio";
                dgvUnidad[0, 4].Value = "Cedula Insc UE";
                dgvUnidad[0, 5].Value = "Cedula Insc Embarcas";
                if (expediente.Rows.Count > 0)
                {
                    if (expediente.Rows[0]["ACTACONS"].ToString() != "") { dgvUnidad[1, 0].Value = true; dgvUnidad[1, 0].Style.BackColor = Color.Green; }
                    if (expediente.Rows[0]["ACTAASAMBLEA"].ToString() != "") { dgvUnidad[1, 1].Value = true; dgvUnidad[1, 1].Style.BackColor = Color.Green; }
                    if (expediente.Rows[0]["RFCUE"].ToString() != "") { dgvUnidad[1, 2].Value = true; dgvUnidad[1, 2].Style.BackColor = Color.Green; }
                    if (expediente.Rows[0]["COMPDOM"].ToString() != "") { dgvUnidad[1, 3].Value = true; dgvUnidad[1, 3].Style.BackColor = Color.Green; }
                    if (expediente.Rows[0]["CEDINSCRUE"].ToString() != "") { dgvUnidad[1, 4].Value = true; dgvUnidad[1, 4].Style.BackColor = Color.Green; }
                    if (expediente.Rows[0]["CEDINSCREMBARCA"].ToString() != "") { dgvUnidad[1, 5].Value = true; dgvUnidad[1, 5].Style.BackColor = Color.Green; }
                }
            }
            else
            {
                dgvUnidad.RowCount = 4;
                dgvUnidad[0, 0].Value = "RFC UE";
                dgvUnidad[0, 1].Value = "Comp Domicilio";
                dgvUnidad[0, 2].Value = "Cedula Insc UE";
                dgvUnidad[0, 3].Value = "Cedula Insc Embarcas";
                if (expediente.Rows.Count > 0)
                {
                    if (expediente.Rows[0]["RFCUE"].ToString() != "") { dgvUnidad[1, 0].Value = true; dgvUnidad[1, 0].Style.BackColor = Color.Green; }
                    if (expediente.Rows[0]["COMPDOM"].ToString() != "") { dgvUnidad[1, 1].Value = true; dgvUnidad[1, 1].Style.BackColor = Color.Green; }
                    if (expediente.Rows[0]["CEDINSCRUE"].ToString() != "") { dgvUnidad[1, 2].Value = true; dgvUnidad[1, 2].Style.BackColor = Color.Green; }
                    if (expediente.Rows[0]["CEDINSCREMBARCA"].ToString() != "") { dgvUnidad[1, 3].Value = true; dgvUnidad[1, 3].Style.BackColor = Color.Green; }
                }
            }
        }

        private void CargarExpedientePescador()
        {
            DataTable expediente = proc.ObtenerExpedientePescadorXUnidad(RNPA);
            DataTable pescadores = proc.PescadoresXUnidad(RNPA);
            int acta = 0, aine = 0, acurp = 0, acompdom = 0;
            dgvPescadores.RowCount = 4;
            dgvPescadores[0, 0].Value = "Actas de Nacimiento";
            dgvPescadores[0, 1].Value = "CURP";
            dgvPescadores[0, 2].Value = "INE (Identificacion Oficial)";
            dgvPescadores[0, 3].Value = "Comprobante de Domicilio";

            foreach (DataRow fila in expediente.Rows)
            {
                if (fila["ACTANAC"].ToString() != "") { acta++; }
                if (fila["ACURP"].ToString() != "") { acurp++; }
                if (fila["AINE"].ToString() != "") { aine++; }
                if (fila["ACOMPDOM"].ToString() != "") { acompdom++; }
            }
            dgvPescadores[2,0].Value = acta + "/" + pescadores.Rows.Count;
            if (acta == pescadores.Rows.Count) { dgvPescadores[1, 0].Value = true; dgvPescadores[1, 0].Style.BackColor = Color.Green; }
            dgvPescadores[2, 1].Value = acurp + "/" + pescadores.Rows.Count;
            if (acurp == pescadores.Rows.Count) { dgvPescadores[1, 1].Value = true; dgvPescadores[1, 1].Style.BackColor = Color.Green; }
            dgvPescadores[2, 2].Value = aine + "/" + pescadores.Rows.Count;
            if (aine == pescadores.Rows.Count) { dgvPescadores[1, 2].Value = true; dgvPescadores[1, 2].Style.BackColor = Color.Green; }
            dgvPescadores[2, 3].Value = acompdom + "/" + pescadores.Rows.Count;
            if (acompdom == pescadores.Rows.Count) { dgvPescadores[1, 3].Value = true; dgvPescadores[1, 3].Style.BackColor = Color.Green; }
            dgvPescadores.ClearSelection();
        }

        private void CargarExpedienteEmbarcacion()
        {
            DataTable expediente = proc.ObtenerExpedienteEmbarcacionXUnidad(RNPA);
            DataTable embarcaciones = proc.ObtenerCertMatrXUnidad(RNPA);
            foreach (DataRow fila in embarcaciones.Rows)
            {
                if (fila["NOMBREEMBARCACION"].ToString() == "NO APLICA") { embarcaciones.Rows.Remove(fila); break; }
            }
            int certmat = 0, certsegu = 0, factartes = 0, factmotor = 0, factembarca = 0, papelchipeo = 0, fotoemb = 0 ;
            dgvEmbarcacion.RowCount = 7;
            dgvEmbarcacion[0, 0].Value = "Certif. Matricula";
            dgvEmbarcacion[0, 1].Value = "Certif. Seguridad";
            dgvEmbarcacion[0, 2].Value = "Factura Artes de Pesca";
            dgvEmbarcacion[0, 3].Value = "Factura Motor";
            dgvEmbarcacion[0, 4].Value = "Factura Embarcacion";
            dgvEmbarcacion[0, 5].Value = "Papeleta de Chipeo";
            dgvEmbarcacion[0, 6].Value = "Foto Embarcacion";

            foreach (DataRow fila in expediente.Rows)
            {
                if (fila["CERTMATRICULA"].ToString() != "") { certmat++; }
                if (fila["CERTSEGURIDAD"].ToString() != "") { certsegu++; }
                if (fila["FACTARTESPESCA"].ToString() != "") { factartes++; }
                if (fila["FACTMOTOR"].ToString() != "") { factmotor++; }
                if (fila["FACTEMBARCACION"].ToString() != "") { factembarca++; }
                if (fila["PAPELETACHIPEO"].ToString() != "") { papelchipeo++; }
                if (fila["FOTOEMB"].ToString() != "") { fotoemb++; }
            }
            dgvEmbarcacion[2, 0].Value = certmat + "/" + embarcaciones.Rows.Count;
            if (certmat == embarcaciones.Rows.Count) { dgvEmbarcacion[1, 0].Value = true; dgvEmbarcacion[1, 0].Style.BackColor = Color.Green; }
            dgvEmbarcacion[2, 1].Value = certsegu + "/" + embarcaciones.Rows.Count;
            if (certsegu == embarcaciones.Rows.Count) { dgvEmbarcacion[1, 1].Value = true; dgvEmbarcacion[1, 1].Style.BackColor = Color.Green; }
            dgvEmbarcacion[2, 2].Value = factartes + "/" + embarcaciones.Rows.Count;
            if (factartes == embarcaciones.Rows.Count) { dgvEmbarcacion[1, 2].Value = true; dgvEmbarcacion[1, 2].Style.BackColor = Color.Green; }
            dgvEmbarcacion[2, 3].Value = factmotor + "/" + embarcaciones.Rows.Count;
            if (factmotor == embarcaciones.Rows.Count) { dgvEmbarcacion[1, 3].Value = true; dgvEmbarcacion[1, 3].Style.BackColor = Color.Green; }
            dgvEmbarcacion[2, 4].Value = factembarca + "/" + embarcaciones.Rows.Count;
            if (factembarca == embarcaciones.Rows.Count) { dgvEmbarcacion[1, 4].Value = true; dgvEmbarcacion[1, 4].Style.BackColor = Color.Green; }
            dgvEmbarcacion[2, 5].Value = papelchipeo + "/" + embarcaciones.Rows.Count;
            if (papelchipeo == embarcaciones.Rows.Count) { dgvEmbarcacion[1, 5].Value = true; dgvEmbarcacion[1, 5].Style.BackColor = Color.Green; }
            dgvEmbarcacion[2, 6].Value = fotoemb + "/" + embarcaciones.Rows.Count;
            if (fotoemb == embarcaciones.Rows.Count) { dgvEmbarcacion[1, 6].Value = true; dgvEmbarcacion[1, 6].Style.BackColor = Color.Green; }
            dgvEmbarcacion.ClearSelection();
        }

        private void CargarExpedientePermisos()
        {
            DataTable expediente = proc.ObtenerNoPermisos(RNPA);
            dgvPermisos.RowCount = 1;
            dgvPermisos[0, 0].Value = "Permisos Escaneados";

            int aperm = 0;
            foreach (DataRow fila in expediente.Rows)
            {
                if (fila["APERMISO"].ToString() != "") { aperm++; }
            }
            dgvPermisos[2, 0].Value = aperm + "/" + expediente.Rows.Count;
            if (aperm == expediente.Rows.Count) { dgvPermisos[1, 0].Value = true; dgvPermisos[1, 0].Style.BackColor = Color.Green; }
            dgvPermisos.ClearSelection();
        }

        private void SubirPDF_Click(object sender, EventArgs e)
        {
            if (dgvUnidad.CurrentCell.Selected != false)
            {
                DialogResult result = MessageBox.Show("Desea escanear un nuevo documento?", "¿?", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    scan = new Scanner(true);
                    if (scan.oDevice!=null)
                    {
                        openFileDialog1.FileName = scan.Scann(0);
                        Stream myStream = openFileDialog1.OpenFile();
                        MemoryStream pdf = new MemoryStream();
                        myStream.CopyTo(pdf);
                        GuardarEnBD(pdf);
                        CargarExpedienteUnidad();
                    }
                    this.Cursor = Cursors.Default;
                }
                else if (result == DialogResult.No)
                {
                    result = MessageBox.Show("Desea subir un archivo desde su computadora?", "¿?", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        openFileDialog1.InitialDirectory = "C:\\";
                        openFileDialog1.Filter = "Todos los archivos (*.*)|*.*";
                        openFileDialog1.FilterIndex = 1;
                        openFileDialog1.RestoreDirectory = true;

                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            Stream myStream = openFileDialog1.OpenFile();

                            MemoryStream pdf = new MemoryStream();
                            myStream.CopyTo(pdf);

                            string n = openFileDialog1.FileName;
                            string x = n[n.Length - 4].ToString() + n[n.Length - 3].ToString() + n[n.Length - 2].ToString() + n[n.Length - 1].ToString();
                            if (x != ".pdf")
                            {
                                scan = new Scanner(false);
                                openFileDialog1.FileName = scan.ConvertToPDF(pdf);
                                myStream = openFileDialog1.OpenFile();
                                pdf = new MemoryStream();
                                myStream.CopyTo(pdf);
                            }
                            GuardarEnBD(pdf);
                        }
                        CargarExpedienteUnidad();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            else { MessageBox.Show("Debe seleccionar la fila correspondiente al archivo que desea subir", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void AbrirPDF_Click(object sender, EventArgs e)
        {
            if (dgvUnidad.CurrentCell.Selected != false)
            {
                DataTable oDocument = proc.ObtenerExpedienteUnidad(RNPA);
                if (oDocument.Rows.Count > 0)
                {
                    string archivo = "";
                    if (TIPO == 0)
                    {
                        if (dgvUnidad.SelectedCells[0].RowIndex == 0)
                            archivo = "ACTACONS";
                        else if (dgvUnidad.SelectedCells[0].RowIndex == 1)
                            archivo = "ACTAASAMBLEA";
                        else if (dgvUnidad.SelectedCells[0].RowIndex == 2)
                            archivo = "RFCUE";
                        else if (dgvUnidad.SelectedCells[0].RowIndex == 3)
                            archivo = "COMPDOM";
                        else if (dgvUnidad.SelectedCells[0].RowIndex == 4)
                            archivo = "CEDINSCRUE";
                        else if (dgvUnidad.SelectedCells[0].RowIndex == 5)
                            archivo = "CEDINSCREMBARCA";
                    }
                    else
                    {
                        if (dgvUnidad.SelectedCells[0].RowIndex == 0)
                            archivo = "RFCUE";
                        else if (dgvUnidad.SelectedCells[0].RowIndex == 1)
                            archivo = "COMPDOM";
                        else if (dgvUnidad.SelectedCells[0].RowIndex == 2)
                            archivo = "CEDINSCRUE";
                        else if (dgvUnidad.SelectedCells[0].RowIndex == 3)
                            archivo = "CEDINSCREMBARCA";
                    }
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string folder = path + "/PDF/";
                    string fullFilePath = folder + RNPA + "-" + archivo + ".pdf";


                    if (!Directory.Exists(folder)) { try { Directory.CreateDirectory(folder); } catch (Exception ms) { } }

                    if (File.Exists(fullFilePath)) { try { Directory.Delete(fullFilePath); } catch (Exception ms) { } }


                 
                    if (archivo != "")
                    {
                        byte[] file = (byte[])oDocument.Rows[0][archivo];
                        File.WriteAllBytes(fullFilePath, file);
                        Process.Start(fullFilePath);
                    }
                }
            }
            else { MessageBox.Show("Debe seleccionar la fila correspondiente al archivo que desea visualizar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void GuardarEnBD(MemoryStream pdf)
        {
            if (TIPO == 0)
            {
                if (dgvUnidad.SelectedCells[0].RowIndex == 0)
                    exito = proc.InsertarPDFUnidad(RNPA, pdf.GetBuffer(), new byte[0], new byte[0], new byte[0], new byte[0], new byte[0]);
                else if (dgvUnidad.SelectedCells[0].RowIndex == 1)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], pdf.GetBuffer(), new byte[0], new byte[0], new byte[0], new byte[0]);
                else if (dgvUnidad.SelectedCells[0].RowIndex == 2)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], new byte[0], pdf.GetBuffer(), new byte[0], new byte[0], new byte[0]);
                else if (dgvUnidad.SelectedCells[0].RowIndex == 3)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], new byte[0], new byte[0], pdf.GetBuffer(), new byte[0], new byte[0]);
                else if (dgvUnidad.SelectedCells[0].RowIndex == 4)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], new byte[0], new byte[0], new byte[0], pdf.GetBuffer(), new byte[0]);
                else if (dgvUnidad.SelectedCells[0].RowIndex == 5)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], new byte[0], new byte[0], new byte[0], new byte[0], pdf.GetBuffer());
            }
            else
            {
                if (dgvUnidad.SelectedCells[0].RowIndex == 0)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], new byte[0], pdf.GetBuffer(), new byte[0], new byte[0], new byte[0]);
                else if (dgvUnidad.SelectedCells[0].RowIndex == 1)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], new byte[0], new byte[0], pdf.GetBuffer(), new byte[0], new byte[0]);
                else if (dgvUnidad.SelectedCells[0].RowIndex == 2)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], new byte[0], new byte[0], new byte[0], pdf.GetBuffer(), new byte[0]);
                else if (dgvUnidad.SelectedCells[0].RowIndex == 3)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], new byte[0], new byte[0], new byte[0], new byte[0], pdf.GetBuffer());
            }
            val.Exito(exito);
        }
    }
}
