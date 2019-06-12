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
using WIA;
namespace OrdenamientoPesquero.Pantallas_Archivos
{
    public partial class Expediente_UE : Form
    {
        Procedimientos proc = new Procedimientos();
        Validaciones val = new Validaciones();
        string RNPA = "";
        int exito = 0, TIPO = 0, NIVEL = 0;
        Scanner scan;

        public Expediente_UE(string rnpa, string nombre,int tipo, int nivel)
        {
            InitializeComponent();
            RNPA = rnpa;
            Nombre.Text = nombre;
            TIPO = tipo;
            NIVEL = nivel;
            CargarLogos();
        }
        private void CargarLogos()
        {
            Logo.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, "Logo.png"));
        }

        private void Expediente_UE_Load(object sender, EventArgs e)
        {
            CargarExpedienteUnidad();
            dgvUnidad.ClearSelection();
            CargarExpedienteEmbarcacion();
            CargarExpedientePescador();
            CargarExpedientePermisos();
            if(NIVEL == 0 || NIVEL == 4)
            {
                SubirPDF.Visible = true;
                label4.Visible = true;
            }
        }

        private void CargarExpedienteUnidad()
        {
            DataTable expediente = proc.ObtenerExpedienteUnidad(RNPA);
            if (TIPO == 0)
            {
                dgvUnidad.RowCount = 7;
                dgvUnidad[0, 0].Value = "Acta Constitutiva";
                dgvUnidad[0, 1].Value = "Acta de Asamblea";
                dgvUnidad[0, 2].Value = "RFC UE";
                dgvUnidad[0, 3].Value = "Comp Domicilio";
                dgvUnidad[0, 4].Value = "Cedula Insc UE";
                dgvUnidad[0, 5].Value = "Cedula Insc Embarcas";
                dgvUnidad[0, 6].Value = "Otro";
                if (expediente.Rows.Count > 0)
                {
                    if (expediente.Rows[0]["ACTACONS"].ToString() != "") { dgvUnidad[1, 0].Value = true; dgvUnidad[1, 0].Style.BackColor = Color.Green; } else { dgvUnidad[1, 0].Value = false; dgvUnidad[1, 0].Style.BackColor = Color.Red; }
                    if (expediente.Rows[0]["ACTAASAMBLEA"].ToString() != "") { dgvUnidad[1, 1].Value = true; dgvUnidad[1, 1].Style.BackColor = Color.Green; } else { dgvUnidad[1, 1].Value = false; dgvUnidad[1, 1].Style.BackColor = Color.Red; }
                    if (expediente.Rows[0]["RFCUE"].ToString() != "") { dgvUnidad[1, 2].Value = true; dgvUnidad[1, 2].Style.BackColor = Color.Green; } else { dgvUnidad[1, 2].Value = false; dgvUnidad[1, 2].Style.BackColor = Color.Red; }
                    if (expediente.Rows[0]["COMPDOM"].ToString() != "") { dgvUnidad[1, 3].Value = true; dgvUnidad[1, 3].Style.BackColor = Color.Green; } else { dgvUnidad[1, 3].Value = false; dgvUnidad[1, 3].Style.BackColor = Color.Red; }
                    if (expediente.Rows[0]["CEDINSCRUE"].ToString() != "") { dgvUnidad[1, 4].Value = true; dgvUnidad[1, 4].Style.BackColor = Color.Green; } else { dgvUnidad[1, 4].Value = false; dgvUnidad[1, 4].Style.BackColor = Color.Red; }
                    if (expediente.Rows[0]["CEDINSCREMBARCA"].ToString() != "") { dgvUnidad[1, 5].Value = true; dgvUnidad[1, 5].Style.BackColor = Color.Green; } else { dgvUnidad[1, 5].Value = false; dgvUnidad[1, 5].Style.BackColor = Color.Red; }
                    if (expediente.Rows[0]["OTRO"].ToString() != "") { dgvUnidad[1, 6].Value = true; dgvUnidad[1, 6].Style.BackColor = Color.Green; } else { dgvUnidad[1, 6].Value = false; dgvUnidad[1, 6].Style.BackColor = Color.Red; }
                }
            }
            else
            {
                dgvUnidad.RowCount = 5;
                dgvUnidad[0, 0].Value = "RFC UE";
                dgvUnidad[0, 1].Value = "Comp Domicilio";
                dgvUnidad[0, 2].Value = "Cedula Insc UE";
                dgvUnidad[0, 3].Value = "Cedula Insc Embarcas";
                dgvUnidad[0, 4].Value = "Otro";
                if (expediente.Rows.Count > 0)
                {
                    if (expediente.Rows[0]["RFCUE"].ToString() != "") { dgvUnidad[1, 0].Value = true; dgvUnidad[1, 0].Style.BackColor = Color.Green; } else { dgvUnidad[1, 0].Value = false; dgvUnidad[1, 0].Style.BackColor = Color.Red; }
                    if (expediente.Rows[0]["COMPDOM"].ToString() != "") { dgvUnidad[1, 1].Value = true; dgvUnidad[1, 1].Style.BackColor = Color.Green; } else { dgvUnidad[1, 1].Value = false; dgvUnidad[1, 1].Style.BackColor = Color.Red; }
                    if (expediente.Rows[0]["CEDINSCRUE"].ToString() != "") { dgvUnidad[1, 2].Value = true; dgvUnidad[1, 2].Style.BackColor = Color.Green; } else { dgvUnidad[1, 2].Value = false; dgvUnidad[1, 2].Style.BackColor = Color.Red; }
                    if (expediente.Rows[0]["CEDINSCREMBARCA"].ToString() != "") { dgvUnidad[1, 3].Value = true; dgvUnidad[1, 3].Style.BackColor = Color.Green; } else { dgvUnidad[1, 3].Value = false; dgvUnidad[1, 3].Style.BackColor = Color.Red; }
                    if (expediente.Rows[0]["OTRO"].ToString() != "") { dgvUnidad[1, 4].Value = true; dgvUnidad[1, 4].Style.BackColor = Color.Green; } else { dgvUnidad[1, 4].Value = false; dgvUnidad[1, 4].Style.BackColor = Color.Red; }
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
            if (pescadores.Rows.Count > 0 && acta == pescadores.Rows.Count) { dgvPescadores[1, 0].Value = true; dgvPescadores[1, 0].Style.BackColor = Color.Green; }
            else if(acta > 0) { dgvPescadores[1, 0].Style.BackColor = Color.Yellow; }

            dgvPescadores[2, 1].Value = acurp + "/" + pescadores.Rows.Count;
            if (pescadores.Rows.Count > 0 && acurp == pescadores.Rows.Count) { dgvPescadores[1, 1].Value = true; dgvPescadores[1, 1].Style.BackColor = Color.Green; }
            else if (acurp > 0) { dgvPescadores[1, 1].Style.BackColor = Color.Yellow; }

            dgvPescadores[2, 2].Value = aine + "/" + pescadores.Rows.Count;

            if (pescadores.Rows.Count > 0 && aine == pescadores.Rows.Count) { dgvPescadores[1, 2].Value = true; dgvPescadores[1, 2].Style.BackColor = Color.Green; }
            else if (aine > 0) { dgvPescadores[1, 2].Style.BackColor = Color.Yellow; }

            dgvPescadores[2, 3].Value = acompdom + "/" + pescadores.Rows.Count;
            if (pescadores.Rows.Count > 0 && acompdom == pescadores.Rows.Count) { dgvPescadores[1, 3].Value = true; dgvPescadores[1, 3].Style.BackColor = Color.Green; }
            else if (acompdom > 0) { dgvPescadores[1, 3].Style.BackColor = Color.Yellow; }

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
            if (embarcaciones.Rows.Count > 0 && certmat == embarcaciones.Rows.Count) { dgvEmbarcacion[1, 0].Value = true; dgvEmbarcacion[1, 0].Style.BackColor = Color.Green; }
            else if (certmat > 0) { dgvEmbarcacion[1, 0].Style.BackColor = Color.Yellow; }

            dgvEmbarcacion[2, 1].Value = certsegu + "/" + embarcaciones.Rows.Count;
            if (embarcaciones.Rows.Count > 0 && certsegu == embarcaciones.Rows.Count) { dgvEmbarcacion[1, 1].Value = true; dgvEmbarcacion[1, 1].Style.BackColor = Color.Green; }
            else if (certsegu > 0) { dgvEmbarcacion[1, 1].Style.BackColor = Color.Yellow; }

            dgvEmbarcacion[2, 2].Value = factartes;
            if (embarcaciones.Rows.Count > 0 && factartes > 0) { dgvEmbarcacion[1, 2].Value = true; dgvEmbarcacion[1, 2].Style.BackColor = Color.Green; }

            dgvEmbarcacion[2, 3].Value = factmotor + "/" + embarcaciones.Rows.Count;
            if (embarcaciones.Rows.Count > 0 && factmotor == embarcaciones.Rows.Count) { dgvEmbarcacion[1, 3].Value = true; dgvEmbarcacion[1, 3].Style.BackColor = Color.Green; }
            else if (factmotor > 0) { dgvEmbarcacion[1, 3].Style.BackColor = Color.Yellow; }

            dgvEmbarcacion[2, 4].Value = factembarca + "/" + embarcaciones.Rows.Count;
            if (embarcaciones.Rows.Count > 0 && factembarca == embarcaciones.Rows.Count) { dgvEmbarcacion[1, 4].Value = true; dgvEmbarcacion[1, 4].Style.BackColor = Color.Green; }
            else if (factembarca > 0) { dgvEmbarcacion[1, 4].Style.BackColor = Color.Yellow; }

            dgvEmbarcacion[2, 5].Value = papelchipeo + "/" + embarcaciones.Rows.Count;
            if (embarcaciones.Rows.Count > 0 && papelchipeo == embarcaciones.Rows.Count) { dgvEmbarcacion[1, 5].Value = true; dgvEmbarcacion[1, 5].Style.BackColor = Color.Green; }
            else if (papelchipeo > 0) { dgvEmbarcacion[1, 5].Style.BackColor = Color.Yellow; }

            dgvEmbarcacion[2, 6].Value = fotoemb + "/" + embarcaciones.Rows.Count;
            if (embarcaciones.Rows.Count > 0 && fotoemb == embarcaciones.Rows.Count) { dgvEmbarcacion[1, 6].Value = true; dgvEmbarcacion[1, 6].Style.BackColor = Color.Green; }
            else if (fotoemb > 0) { dgvEmbarcacion[1, 6].Style.BackColor = Color.Yellow; }

            dgvEmbarcacion.ClearSelection();
        }

        private void CargarExpedientePermisos()
        {
            DataTable expediente = proc.ObtenerNoPermisos(RNPA);
            dgvPermisos.RowCount = 1;
            dgvPermisos[0, 0].Value = "Permisos Escaneados";
            List<List<string>> folios = new List<List<string>>();
            int aperm = 0;
            foreach (DataRow fila in expediente.Rows)
            {
                bool contains = false;
                foreach (var item in folios)
                {
                    if (item.Contains(fila["FOLIO"].ToString()))
                    { contains = true; break; }
                }
                if (!contains)
                {
                    List<string> add = new List<string>();
                    add.Add(fila["FOLIO"].ToString());
                    if (fila["APERMISO"].ToString() != "")
                    { add.Add("Y"); aperm++; }
                    folios.Add(add);
                }
                else
                {
                    foreach (var item in folios)
                    {
                        if (item.Contains(fila["FOLIO"].ToString()) && item.Contains("Y")) { break; }
                        else if (item.Contains(fila["FOLIO"].ToString()) && fila["APERMISO"].ToString() != "") { item.Add("Y"); aperm++; }
                    }
                }
            }
            dgvPermisos[2, 0].Value = aperm + "/" + folios.Count;
            if (folios.Count > 0 && aperm == folios.Count) { dgvPermisos[1, 0].Value = true; dgvPermisos[1, 0].Style.BackColor = Color.Green; }
            else if (aperm > 0)
            { dgvPermisos[1, 0].Style.BackColor = Color.Yellow; }

            dgvPermisos.ClearSelection();
        }

        private void SubirPDF_Click(object sender, EventArgs e)
        {
            if (dgvUnidad.CurrentCell.Selected != false)
            {
                //DialogResult result = MessageBox.Show("Desea escanear un nuevo documento?", "¿?", MessageBoxButtons.YesNoCancel);
                //if (result == DialogResult.Yes)
                //{
                //    this.Cursor = Cursors.WaitCursor;
                //    scan = new Scanner(true);
                //    if (scan.oDevice!=null)
                //    {
                //        openFileDialog1.FileName = scan.Scann(0);
                //        Stream myStream = openFileDialog1.OpenFile();
                //        MemoryStream pdf = new MemoryStream();
                //        myStream.CopyTo(pdf);
                //        GuardarEnBD(pdf);
                //        CargarExpedienteUnidad();
                //    }
                //    this.Cursor = Cursors.Default;
                //}
                //else if (result == DialogResult.No)
                //{
                DialogResult result = MessageBox.Show("Desea subir un archivo desde su computadora?", "¿?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    openFileDialog1.Filter = "Todos los archivos (*.png, pdf, jpg, jpeg)| *.pdf; *.png; *.jpg; *.jpeg|PDF|*.pdf|Imagenes|*.png; *.jpg; *.jpeg;";
                    openFileDialog1.FilterIndex = 1;

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        Stream myStream = openFileDialog1.OpenFile();

                        MemoryStream pdf = new MemoryStream();
                        myStream.CopyTo(pdf);

                        string n = openFileDialog1.FileName;
                        string x = n[n.Length - 4].ToString() + n[n.Length - 3].ToString() + n[n.Length - 2].ToString() + n[n.Length - 1].ToString();

                        scan = new Scanner(false);
                        if (x != ".pdf")
                        { openFileDialog1.FileName = scan.ConvertToPDF(pdf, n, false); }
                        else
                        { openFileDialog1.FileName = scan.ConvertToPDF(pdf, n, true); }
                        myStream = openFileDialog1.OpenFile();
                        pdf = new MemoryStream();
                        myStream.CopyTo(pdf);

                        GuardarEnBD(pdf);
                        this.Cursor = Cursors.Default;
                    }
                    CargarExpedienteUnidad();
                    this.Cursor = Cursors.Default;
                }
            }
            else { MessageBox.Show("Debe seleccionar la fila correspondiente al archivo que desea subir", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void EliminarPDF_Click(object sender, EventArgs e)
        {
            if (dgvUnidad.CurrentCell.Selected != false)
            {
                if (DialogResult.Yes == MessageBox.Show("Desea ELIMINAR el archivo seleccionado?", "ELIMINAR", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
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
                        else if (dgvUnidad.SelectedCells[0].RowIndex == 6)
                            archivo = "OTRO";
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
                        else if (dgvUnidad.SelectedCells[0].RowIndex == 4)
                            archivo = "OTRO";
                    }
                    if (proc.EliminarPDF(RNPA, "", "", "", archivo) > 0)
                    {
                        MessageBox.Show("Archivo Eliminado con Exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    CargarExpedienteUnidad();
                }
            }
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
                        else if (dgvUnidad.SelectedCells[0].RowIndex == 6)
                            archivo = "OTRO";
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
                        else if (dgvUnidad.SelectedCells[0].RowIndex == 4)
                            archivo = "OTRO";
                    }
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string folder = path + "/PDF/";
                    string fullFilePath = folder + RNPA + "-" + archivo + ".pdf";


                    if (!Directory.Exists(folder)) { try { Directory.CreateDirectory(folder); } catch (Exception ms) { } }

                    if (File.Exists(fullFilePath)) { try { Directory.Delete(fullFilePath); } catch (Exception ms) { } }

                    if (archivo != "")
                    {
                        //Stream resFilestream=; //' this will be the source of file to writ
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
                    exito = proc.InsertarPDFUnidad(RNPA, pdf.GetBuffer(), new byte[0], new byte[0], new byte[0], new byte[0], new byte[0], new byte[0]);
                else if (dgvUnidad.SelectedCells[0].RowIndex == 1)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], pdf.GetBuffer(), new byte[0], new byte[0], new byte[0], new byte[0], new byte[0]);
                else if (dgvUnidad.SelectedCells[0].RowIndex == 2)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], new byte[0], pdf.GetBuffer(), new byte[0], new byte[0], new byte[0], new byte[0]);
                else if (dgvUnidad.SelectedCells[0].RowIndex == 3)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], new byte[0], new byte[0], pdf.GetBuffer(), new byte[0], new byte[0], new byte[0]);
                else if (dgvUnidad.SelectedCells[0].RowIndex == 4)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], new byte[0], new byte[0], new byte[0], pdf.GetBuffer(), new byte[0], new byte[0]);
                else if (dgvUnidad.SelectedCells[0].RowIndex == 5)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], new byte[0], new byte[0], new byte[0], new byte[0], pdf.GetBuffer(), new byte[0]);
                else if (dgvUnidad.SelectedCells[0].RowIndex == 6)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], new byte[0], new byte[0], new byte[0], new byte[0], new byte[0], pdf.GetBuffer());
            }
            else
            {
                if (dgvUnidad.SelectedCells[0].RowIndex == 0)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], new byte[0], pdf.GetBuffer(), new byte[0], new byte[0], new byte[0], new byte[0]);
                else if (dgvUnidad.SelectedCells[0].RowIndex == 1)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], new byte[0], new byte[0], pdf.GetBuffer(), new byte[0], new byte[0], new byte[0]);
                else if (dgvUnidad.SelectedCells[0].RowIndex == 2)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], new byte[0], new byte[0], new byte[0], pdf.GetBuffer(), new byte[0], new byte[0]);
                else if (dgvUnidad.SelectedCells[0].RowIndex == 3)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], new byte[0], new byte[0], new byte[0], new byte[0], pdf.GetBuffer(), new byte[0]);
                else if (dgvUnidad.SelectedCells[0].RowIndex == 4)
                    exito = proc.InsertarPDFUnidad(RNPA, new byte[0], new byte[0], new byte[0], new byte[0], new byte[0], new byte[0], pdf.GetBuffer());
            }
            val.Exito(exito);
        }

        private void CerrarPanel_Click(object sender, EventArgs e)
        {
            MostrarPanel(false);
        }

        private void FALTANTES_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool Completo = false;
            string archivo = "";
            int entidad = 0;
            if (dgvEmbarcacion == sender) { dgvPermisos.ClearSelection(); dgvPescadores.ClearSelection(); }
            else if (dgvPescadores == sender) { dgvEmbarcacion.ClearSelection(); dgvPermisos.ClearSelection(); }
            else if (dgvPermisos == sender) { dgvEmbarcacion.ClearSelection(); dgvPescadores.ClearSelection(); }
            if (dgvEmbarcacion.SelectedCells.Count > 0)
            {
                if (dgvEmbarcacion[1, dgvEmbarcacion.SelectedCells[0].RowIndex].Value == null)
                {
                    switch (dgvEmbarcacion.SelectedCells[0].RowIndex)
                    {
                        case 0: archivo = "CERTMATRICULA"; break;
                        case 1: archivo = "CERTSEGURIDAD"; break;
                        case 2: archivo = "FACTARTESPESCA"; break;
                        case 3: archivo = "FACTMOTOR"; break;
                        case 4: archivo = "FACTEMBARCACION"; break;
                        case 5: archivo = "PAPELETACHIPEO"; break;
                        case 6: archivo = "FOTOEMB"; break;
                    }
                    entidad = 0;
                }
                else { Completo = true; }
            }
            else if (dgvPescadores.SelectedCells.Count > 0)
            {
                if (dgvPescadores[1, dgvPescadores.SelectedCells[0].RowIndex].Value == null)
                {
                    switch (dgvPescadores.SelectedCells[0].RowIndex)
                    {
                        case 0: archivo = "ACTANAC"; break;
                        case 1: archivo = "ACURP"; break;
                        case 2: archivo = "AINE"; break;
                        case 3: archivo = "ACOMPDOM"; break;
                    }
                    entidad = 1;
                }
                else { Completo = true; }
            }
            else if (dgvPermisos.SelectedCells.Count > 0)
            {
                if (dgvPermisos[1, dgvPermisos.SelectedCells[0].RowIndex].Value == null)
                {
                    switch (dgvPermisos.SelectedCells[0].RowIndex)
                    {
                        case 0: archivo = "APERMISO"; break;
                    }
                    entidad = 2;
                }
                else { Completo = true; }
            }
            if (!Completo && archivo != "") { AbrirVerificacion(archivo, entidad); }

        }

        private void AbrirVerificacion(string archivo, int entidad)
        {
            string a = "", b = "";
            DataTable expediente = null;
            if (entidad == 0)
            {
                expediente = proc.ObtenerExpedienteEmbarcacionXUnidad(RNPA);
                DataTable embarcaciones = proc.ObtenerCertMatrXUnidad(RNPA);
                dgvFaltantes.ColumnCount = 0;
                dgvFaltantes.Columns.Add("Matricula", "Matricula");
                dgvFaltantes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                a = "MATRICULA";
                dgvFaltantes.Columns.Add("Nombre", "Nombre");
                b = "NOMBREEMBARCACION";
                dgvFaltantes.Rows.Clear();
                bool TieneArchivo = false;
                foreach (DataRow fila1 in embarcaciones.Rows)
                {
                    TieneArchivo = false;
                    foreach (DataRow fila in expediente.Rows)
                    {
                        if (fila[b].ToString() != "NO APLICA")
                        {
                            if (fila1[a].ToString() == fila[a].ToString())
                            {
                                if (fila[archivo].ToString() != "" && fila[archivo] != null)
                                { TieneArchivo = true; }
                                else
                                { TieneArchivo = false; }
                                break;
                            }
                        }
                    }
                    if (!TieneArchivo && fila1[b].ToString() != "NO APLICA") { dgvFaltantes.Rows.Add(fila1[a].ToString(), fila1[b].ToString()); }
                }
            }
            else if (entidad == 1)
            {
                expediente = proc.ObtenerExpedientePescadorXUnidad(RNPA);
                DataTable pescadores = proc.BuscarNombre("", RNPA);
                dgvFaltantes.ColumnCount = 0;
                dgvFaltantes.Columns.Add("CURP", "CURP");
                dgvFaltantes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                a = "CURP";
                dgvFaltantes.Columns.Add("Nombre Pescador", "Nombre Pescador");
                b = "NOMBRE";
                dgvFaltantes.Rows.Clear();
                bool TieneArchivo = false;
                foreach (DataRow fila1 in pescadores.Rows)
                {
                    TieneArchivo = false;
                    foreach (DataRow fila in expediente.Rows)
                    {
                        if (fila1[a].ToString() == fila[a].ToString())
                        {
                            if (fila[archivo].ToString() != "" && fila[archivo] != null)
                            { TieneArchivo = true; }
                            else { TieneArchivo = false; }
                        }
                    }
                    if (!TieneArchivo) { dgvFaltantes.Rows.Add(fila1[a].ToString(), fila1[b].ToString()); }

                }
            }
            else if (entidad == 2)
            {
                expediente = proc.ObtenerNoPermisos(RNPA);
                dgvFaltantes.ColumnCount = 0;
                dgvFaltantes.Columns.Add("NoPermiso", "NoPermiso");
                dgvFaltantes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                a = "NPERMISO";
                dgvFaltantes.Columns.Add("Pesqueria", "Pesqueria");
                b = "PESQUERIA";
                List<List<string>> folios = new List<List<string>>();
                foreach (DataRow fila in expediente.Rows)
                {
                    bool contains = false;
                    foreach (var item in folios)
                    {
                        if (item.Contains(fila["FOLIO"].ToString()))
                        { contains = true; break; }
                    }
                    if (!contains)
                    {
                        List<string> add = new List<string>();
                        add.Add(fila["FOLIO"].ToString());
                        if (fila["APERMISO"].ToString() != "")
                        { add.Add("Y"); }
                        else { add.Add(fila[a].ToString()); add.Add(fila[b].ToString()); }
                        folios.Add(add);
                    }
                    else
                    {
                        foreach (var item in folios)
                        {
                            if (item.Contains(fila["FOLIO"].ToString()) && item.Contains("Y")) { break; }
                            else if (item.Contains(fila["FOLIO"].ToString()) && fila["APERMISO"].ToString() != "") { item.Add("Y"); }
                        }
                    }
                }
                foreach (List<string> item in folios)
                {
                    if(item.Count == 3) 
                        dgvFaltantes.Rows.Add(item[1], item[2]);
                }

            }

            dgvFaltantes.ClearSelection();
            bool x = panel1.Visible ? true : false;
            MostrarPanel(x);
        }

        void MostrarPanel(bool Data)
        {
            if (!Data)
            {
                if (!panel1.Visible)
                {
                    panel1.Visible = true;
                    SubirPDF.Enabled = false;
                    AbrirPDF.Enabled = false;
                    EliminarPDF.Enabled = false;
                }
                else
                {
                    panel1.Visible = false;
                    SubirPDF.Enabled = true;
                    AbrirPDF.Enabled = true;
                    EliminarPDF.Enabled = true;
                }
            }
        }
    }
}
