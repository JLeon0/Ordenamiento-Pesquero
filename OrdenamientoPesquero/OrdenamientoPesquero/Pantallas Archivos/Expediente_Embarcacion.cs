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
    public partial class Expediente_Embarcacion : Form
    {
        Procedimientos proc = new Procedimientos();
        string MATRICULA = "";
        Scanner scan;
        public Expediente_Embarcacion(string matricula, string nombre)
        {
            InitializeComponent();
            MATRICULA = matricula;
            Nombre.Text = nombre;
        }

        private void Expediente_Embarcacion_Load(object sender, EventArgs e)
        {
            CargarExpediente();
            dgvArchivos.ClearSelection();
        }
        private void CargarExpediente()
        {
            DataTable exp = proc.ObtenerExpedienteEmbarcacion(MATRICULA);
            dgvArchivos.RowCount = 6;
            dgvArchivos[0, 0].Value = "Certif. Matricula";
            dgvArchivos[0, 1].Value = "Certif. Seguridad";
            dgvArchivos[0, 2].Value = "Factura Artes de Pesca";
            dgvArchivos[0, 3].Value = "Factura Motor";
            dgvArchivos[0, 4].Value = "Factura Embarcacion";
            dgvArchivos[0, 5].Value = "Papeleta de Chipeo";
            if (exp.Rows.Count > 0)
            {
                if (exp.Rows[0]["CERTMATRICULA"].ToString() != "") { dgvArchivos[1, 0].Value = true; dgvArchivos[1, 0].Style.BackColor = Color.Green; }
                if (exp.Rows[0]["CERTSEGURIDAD"].ToString() != "") { dgvArchivos[1, 1].Value = true; dgvArchivos[1, 1].Style.BackColor = Color.Green; }
                if (exp.Rows[0]["FACTARTESPESCA"].ToString() != "") { dgvArchivos[1, 2].Value = true; dgvArchivos[1, 2].Style.BackColor = Color.Green; }
                if (exp.Rows[0]["FACTMOTOR"].ToString() != "") { dgvArchivos[1, 3].Value = true; dgvArchivos[1, 3].Style.BackColor = Color.Green; }
                if (exp.Rows[0]["FACTEMBARCACION"].ToString() != "") { dgvArchivos[1, 4].Value = true; dgvArchivos[1, 4].Style.BackColor = Color.Green; }
                if (exp.Rows[0]["PAPELETACHIPEO"].ToString() != "") { dgvArchivos[1, 5].Value = true; dgvArchivos[1, 5].Style.BackColor = Color.Green; }
            }
        }
        private void SubirPDF_Click(object sender, EventArgs e)
        {
            if (dgvArchivos.CurrentCell.Selected != false)
            {
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

                    if (dgvArchivos.SelectedCells[0].RowIndex == 0)
                        proc.InsertarPDFEmbarcacion(MATRICULA, pdf.GetBuffer(), new byte[0], new byte[0], new byte[0], new byte[0], new byte[0]);
                    if (dgvArchivos.SelectedCells[0].RowIndex == 1)
                        proc.InsertarPDFEmbarcacion(MATRICULA, new byte[0], pdf.GetBuffer(), new byte[0], new byte[0], new byte[0], new byte[0]);
                    if (dgvArchivos.SelectedCells[0].RowIndex == 2)
                        proc.InsertarPDFEmbarcacion(MATRICULA, new byte[0], new byte[0], pdf.GetBuffer(), new byte[0], new byte[0], new byte[0]);
                    if (dgvArchivos.SelectedCells[0].RowIndex == 3)
                        proc.InsertarPDFEmbarcacion(MATRICULA, new byte[0], new byte[0], new byte[0], pdf.GetBuffer(), new byte[0], new byte[0]);
                    if (dgvArchivos.SelectedCells[0].RowIndex == 4)
                        proc.InsertarPDFEmbarcacion(MATRICULA, new byte[0], new byte[0], new byte[0], new byte[0], pdf.GetBuffer(), new byte[0]);
                    if (dgvArchivos.SelectedCells[0].RowIndex == 5)
                        proc.InsertarPDFEmbarcacion(MATRICULA, new byte[0], new byte[0], new byte[0], new byte[0], new byte[0], pdf.GetBuffer());
                }
                CargarExpediente();
            }
            else { MessageBox.Show("Debe seleccionar la fila correspondiente al archivo que desea subir", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void AbrirPDF_Click(object sender, EventArgs e)
        {
            if (dgvArchivos.CurrentCell.Selected != false)
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable oDocument = proc.ObtenerExpedienteEmbarcacion(MATRICULA);
                if (oDocument.Rows.Count > 0)
                {
                    string archivo = "";
                    if (dgvArchivos.SelectedCells[0].RowIndex == 0)
                        archivo = "CERTMATRICULA";
                    else if (dgvArchivos.SelectedCells[0].RowIndex == 1)
                        archivo = "CERTSEGURIDAD";
                    else if (dgvArchivos.SelectedCells[0].RowIndex == 2)
                        archivo = "CERTPROPIEDAD";
                    else if (dgvArchivos.SelectedCells[0].RowIndex == 3)
                        archivo = "FACTMOTOR";
                    else if (dgvArchivos.SelectedCells[0].RowIndex == 4)
                        archivo = "FACTEMBARCACION";
                    else if (dgvArchivos.SelectedCells[0].RowIndex == 5)
                        archivo = "PAPELETACHIPEO";

                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string folder = path + "/PDF/";
                    string fullFilePath = folder + MATRICULA + "-" + archivo + ".pdf";


                    if (!Directory.Exists(folder)) { try { Directory.CreateDirectory(folder); } catch (Exception ms) { } }

                    if (File.Exists(fullFilePath)) { try { Directory.Delete(fullFilePath); } catch (Exception ms) { } }




                    if (archivo != "")
                    {
                        byte[] file = (byte[])oDocument.Rows[0][archivo];
                        File.WriteAllBytes(fullFilePath, file);
                        Process.Start(fullFilePath);
                    }
                }
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Debe seleccionar la fila correspondiente al archivo que desea visualizar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

