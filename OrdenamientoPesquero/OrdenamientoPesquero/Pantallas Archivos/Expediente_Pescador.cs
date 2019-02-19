﻿using System;
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


        public Expediente_Pescador(string curp,string nombre)
        {
            InitializeComponent();
            CURPPesc = curp;
            Nombre.Text = nombre;
        }

        private void SubirPDF_Click(object sender, EventArgs e)
        {
            if (dgvArchivos.CurrentCell.Selected != false)
            {
                openFileDialog1.InitialDirectory = "C:\\";
                openFileDialog1.Filter = "Todos los archivos (*.pdf)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Stream myStream = openFileDialog1.OpenFile();

                    MemoryStream pdf = new MemoryStream();
                    myStream.CopyTo(pdf);
                    if (dgvArchivos.SelectedCells[0].RowIndex == 0)
                        proc.InsertarPDFPescador(CURPPesc, pdf.GetBuffer(), new byte[0], new byte[0], new byte[0]);
                    if (dgvArchivos.SelectedCells[0].RowIndex == 1)
                        proc.InsertarPDFPescador(CURPPesc, new byte[0], pdf.GetBuffer(), new byte[0], new byte[0]);
                    if (dgvArchivos.SelectedCells[0].RowIndex == 2)
                        proc.InsertarPDFPescador(CURPPesc, new byte[0], new byte[0], pdf.GetBuffer(), new byte[0]);
                    if (dgvArchivos.SelectedCells[0].RowIndex == 3)
                        proc.InsertarPDFPescador(CURPPesc, new byte[0], new byte[0], new byte[0], pdf.GetBuffer());
                }
                CargarExpediente();
            }
            else { MessageBox.Show("Debe seleccionar la fila correspondiente al archivo que desea subir", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }        }

        private void AbrirPDF_Click(object sender, EventArgs e)
        {
            if (dgvArchivos.CurrentCell.Selected != false)
            {
                DataTable oDocument = proc.ObtenerExpedientePescador(CURPPesc);
                if (oDocument.Rows.Count > 0)
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string folder = path + "/PDF/";
                    string fullFilePath = folder + CURPPesc + ".pdf";


                    if (!Directory.Exists(folder)) { try { Directory.CreateDirectory(folder); } catch (Exception ms) { } }

                    if (File.Exists(fullFilePath)) { try { Directory.Delete(fullFilePath); } catch (Exception ms) { } }


                    string archivo = "";
                    if (dgvArchivos.SelectedCells[0].RowIndex == 0)
                        archivo = "ACTANAC";
                    else if (dgvArchivos.SelectedCells[0].RowIndex == 1)
                        archivo = "ACURP";
                    else if (dgvArchivos.SelectedCells[0].RowIndex == 2)
                        archivo = "AINE";
                    else if (dgvArchivos.SelectedCells[0].RowIndex == 3)
                        archivo = "ACOMPDOM";

                    if (archivo != "")
                    {
                        byte[] file = (byte[])oDocument.Rows[0][archivo];
                        File.WriteAllBytes(fullFilePath, file);
                        Process.Start(fullFilePath);
                    }
                }
            }
            else { MessageBox.Show("Debe seleccionar la fila correspondiente al archivo que desea subir", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Expediente_Pescador_Load(object sender, EventArgs e)
        {
            CargarExpediente();
            dgvArchivos.ClearSelection();
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
