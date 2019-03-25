using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using System.IO;
using System.Diagnostics;

namespace OrdenamientoPesquero.Pantallas_Archivos
{
    public partial class Expediente_Pescador : Form
    {
        Procedimientos proc = new Procedimientos();
        string CURPPesc = "";
        int NIVEL = 0;
        Scanner scan;
        Validaciones val = new Validaciones();
        public Expediente_Pescador(string curp, string nombre, int nivel)
        {
            InitializeComponent();
            CURPPesc = curp;
            Nombre.Text = nombre;
            NIVEL = nivel;
        }

        private void SubirPDF_Click(object sender, EventArgs e)
        {
            if (dgvArchivos.CurrentCell.Selected != false)
            {
                DialogResult result = MessageBox.Show("Desea escanear un nuevo documento?", "¿?", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;
                    scan = new Scanner(true);
                    if (scan.oDevice != null)
                    {
                        openFileDialog1.FileName = scan.Scann(0);
                        Stream myStream = openFileDialog1.OpenFile();
                        MemoryStream pdf = new MemoryStream();
                        myStream.CopyTo(pdf);
                        GuardarEnBD(pdf);
                        CargarExpediente();
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
                        CargarExpediente();
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            else { MessageBox.Show("Debe seleccionar la fila correspondiente al archivo que desea subir", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void AbrirPDF_Click(object sender, EventArgs e)
        {
            if (dgvArchivos.CurrentCell.Selected != false)
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable oDocument = proc.ObtenerExpedientePescador(CURPPesc);
                if (oDocument.Rows.Count > 0)
                {
                    string archivo = "";
                    if (dgvArchivos.SelectedCells[0].RowIndex == 0)
                        archivo = "ACTANAC";
                    else if (dgvArchivos.SelectedCells[0].RowIndex == 1)
                        archivo = "ACURP";
                    else if (dgvArchivos.SelectedCells[0].RowIndex == 2)
                        archivo = "AINE";
                    else if (dgvArchivos.SelectedCells[0].RowIndex == 3)
                        archivo = "ACOMPDOM";

                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string folder = path + "/PDF/";
                    string fullFilePath = folder + CURPPesc + "-" + archivo + ".pdf";

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
            else { MessageBox.Show("Debe seleccionar la fila correspondiente al archivo que desea subir", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void GuardarEnBD(MemoryStream pdf)
        {
            int exito = 0;
            if (dgvArchivos.SelectedCells[0].RowIndex == 0)
                exito = proc.InsertarPDFPescador(CURPPesc, pdf.GetBuffer(), new byte[0], new byte[0], new byte[0]);
            else if (dgvArchivos.SelectedCells[0].RowIndex == 1)
                exito = proc.InsertarPDFPescador(CURPPesc, new byte[0], pdf.GetBuffer(), new byte[0], new byte[0]);
            else if (dgvArchivos.SelectedCells[0].RowIndex == 2)
                exito = proc.InsertarPDFPescador(CURPPesc, new byte[0], new byte[0], pdf.GetBuffer(), new byte[0]);
            else if (dgvArchivos.SelectedCells[0].RowIndex == 3)
                exito = proc.InsertarPDFPescador(CURPPesc, new byte[0], new byte[0], new byte[0], pdf.GetBuffer());

            val.Exito(exito);
        }

        private void Expediente_Pescador_Load(object sender, EventArgs e)
        {
            CargarExpediente();
            dgvArchivos.ClearSelection();
            if (NIVEL == 0 || NIVEL == 4)
            {
                SubirPDF.Visible = true;
                label2.Visible = true;
            }
        }

        private void CargarExpediente()
        {
            DataTable exp = proc.ObtenerExpedientePescador(CURPPesc);
            dgvArchivos.RowCount = 4;
            dgvArchivos[0, 0].Value = "Acta de Nacimiento";
            dgvArchivos[0, 1].Value = "CURP";
            dgvArchivos[0, 2].Value = "INE (Identificación Oficial)";
            dgvArchivos[0, 3].Value = "Comprobante de domicilio";
            if (exp.Rows.Count > 0)
            {
                if (exp.Rows[0]["ACTANAC"].ToString() != "") { dgvArchivos[1, 0].Value = true; dgvArchivos[1, 0].Style.BackColor = Color.Green; }
                if (exp.Rows[0]["ACURP"].ToString() != "") { dgvArchivos[1, 1].Value = true; dgvArchivos[1, 1].Style.BackColor = Color.Green; }
                if (exp.Rows[0]["AINE"].ToString() != "") { dgvArchivos[1, 2].Value = true; dgvArchivos[1, 2].Style.BackColor = Color.Green; }
                if (exp.Rows[0]["ACOMPDOM"].ToString() != "") { dgvArchivos[1, 3].Value = true; dgvArchivos[1, 3].Style.BackColor = Color.Green; }
            }
        }
    }
}
