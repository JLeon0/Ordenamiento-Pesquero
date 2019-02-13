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


        public Expediente_Pescador(string curp)
        {
            InitializeComponent();
            CURPPesc = curp;
        }

        private void SubirPDF_Click(object sender, EventArgs e)
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
                proc.InsertarArchivos(CURPPesc, pdf.GetBuffer());
            }
        }

        private void AbrirPDF_Click(object sender, EventArgs e)
        {

            DataTable oDocument = proc.ObtenerExpedientePescador(CURPPesc);
            if (oDocument.Rows.Count > 0)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string folder = path + "/PDF/";
                folder = folder.Replace("\\", "/");
                string fullFilePath = folder + CURPPesc;


                if (!Directory.Exists(folder)) { try { Directory.CreateDirectory(folder); } catch (Exception ms) { } }

                if (File.Exists(fullFilePath)) { try { Directory.Delete(fullFilePath); } catch (Exception ms) { } }


                byte[] file = (byte[])oDocument.Rows[0]["ACTANAC"];
                File.WriteAllBytes(fullFilePath, file);
                Process.Start(fullFilePath);
            }
        }
    }
}
