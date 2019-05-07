using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WIA;
public class Scanner
{
    public Device oDevice;
    WIA.CommonDialog dlg;
    bool varias = false;
    PdfSharp.Pdf.PdfDocument doc;
    public Scanner(bool activado)
    {
        if (activado)
        {
            dlg = new WIA.CommonDialog();
            try
            { oDevice = dlg.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, true, false); }
            catch (Exception)
            { MessageBox.Show("Error al intentar conexion con el escaner. \nRevise si está conectado y encendido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
    public string Scann(int x)
    {
        ImageFile imageFile = dlg.ShowAcquireImage(oDevice.Type, WiaImageIntent.GrayscaleIntent, WiaImageBias.MaximizeQuality,
            "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}", false, false, false);
        WIA.Vector vector = imageFile.FileData;

        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string folder = path + "/PDF/";
        string seg = DateTime.Now.ToString("hhmmss");
        string fullFilePath = folder + seg + "-.pdf";
        string fullFilePath2 = folder + seg + "-2.pdf";

        if (!Directory.Exists(folder)) { try { Directory.CreateDirectory(folder); } catch (Exception ms) { } }

        if (File.Exists(fullFilePath)) { try { File.Delete(fullFilePath); } catch (Exception ms) { } }
        if (File.Exists(fullFilePath2)) { try { File.Delete(fullFilePath2); } catch (Exception ms) { } }

        byte[] file = (byte[])vector.get_BinaryData();
        File.WriteAllBytes(fullFilePath, file);


        if (!varias) { doc = new PdfSharp.Pdf.PdfDocument(); }
        doc.Pages.Add(new PdfPage());

        XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[x]);
        XImage img = XImage.FromFile(fullFilePath);
        xgr.DrawImage(img, 0, 0);

        DialogResult result = MessageBox.Show("Desea anexar otra página?", "¿?", MessageBoxButtons.YesNo);
        if (result == DialogResult.Yes)
        {
            varias = true;
            x = x + 1;
            Scann(x);
        }

        doc.Save(fullFilePath2);
        doc.Close();

        return fullFilePath2;
    }


    public string ConvertToPDF(MemoryStream pdf)
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string folder = path + "/PDF/";
        string seg = DateTime.Now.ToString("hhmmss");
        string fullFilePath = folder + "TEMPORAL" + seg + ".pdf";
        string fullFilePath2 = folder + "TEMPORAL" + seg + "-2.pdf";

        if (!Directory.Exists(folder)) { try { Directory.CreateDirectory(folder); } catch (Exception ms) { } }

        if (File.Exists(fullFilePath)) { try { File.Delete(fullFilePath); } catch (Exception ms) { } }
        if (File.Exists(fullFilePath2)) { try { File.Delete(fullFilePath2); } catch (Exception ms) { } }

        byte[] file = (byte[])pdf.GetBuffer();
        File.WriteAllBytes(fullFilePath, file);

        PdfDocument doc = new PdfDocument();
        //Separar(rutaFicheroPDFOrigenDividir);
        doc.Pages.Add(new PdfPage());
        XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]);
        XImage img = XImage.FromFile(fullFilePath);
        xgr.DrawImage(img, 0, 0);
        doc.Save(fullFilePath2);
        doc.Close();

        return fullFilePath2;
    }

    //void Separar(string rutaFicheroPDFOrigenDividir)
    //{
    //    PdfDocument ficheroPDFOrigenDividir =
    //                       PdfReader.Open(rutaFicheroPDFOrigenDividir, PdfDocumentOpenMode.Import);

    //    for (int paginaPDFActual = 0;
    //        paginaPDFActual < ficheroPDFOrigenDividir.PageCount;
    //        paginaPDFActual++)
    //    {

    //        // Crear el documento PDF destino de la página extraida
    //        PdfDocument ficheroPDFPaginaDestino = new PdfDocument();
    //        /*
    //         ficheroPDFPaginaDestino.Info.Title =
    //            String.Format("Página {0} de {1}", paginaPDFActual + 1,
    //            ficheroPDFOrigenDividir.PageCount);
    //        */

    //        // Añadir la página y guardar el fichero PDF creado
    //        ficheroPDFPaginaDestino.AddPage(ficheroPDFOrigenDividir.Pages[paginaPDFActual]);
    //        string nombreFicheroPDFDestino = Path.Combine(txtCarpetaDestinoPDF.Text,nombreFicheroDestinoPaginasPDF + " - Página " +Convert.ToString(paginaPDFActual + 1)) + ".pdf";
    //        ficheroPDFPaginaDestino.Save(nombreFicheroPDFDestino);
    //        lsFicherosPDFDivididos.Items.Add(nombreFicheroPDFDestino);
    //        bp.Value = paginaPDFActual + 1;
    //    }
    //    lInfoProgreso.Text = "Fichero dividido en páginas correctamente: se han generado " +
    //        Convert.ToString(ficheroPDFOrigenDividir.PageCount) + " ficheros PDF";
    //    lInfoProgreso.Refresh();
    //}
}
