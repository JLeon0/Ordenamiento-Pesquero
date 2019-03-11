using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WIA;
public class Scanner
{
    Device oDevice;
    WIA.CommonDialog dlg;
    bool varias = false; PdfDocument doc;
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
        ImageFile imageFile;
        try
        {
            imageFile = dlg.ShowAcquireImage(oDevice.Type, WiaImageIntent.GrayscaleIntent, WiaImageBias.MaximizeQuality,
            "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}", false, false, false);
        }
        catch (Exception ms)
        {
            MessageBox.Show("Error, vuelva a la pantalla anterior y reintente");
            return "";
        }
        WIA.Vector vector = imageFile.FileData;
        System.Drawing.Image i = System.Drawing.Image.FromStream(new System.IO.MemoryStream((byte[])vector.get_BinaryData()));

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


        if (!varias) { doc = new PdfDocument(); }
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
        string fullFilePath = folder + "TEMPORAL.pdf";
        string fullFilePath2 = folder + "TEMPORAL2.pdf";

        if (!Directory.Exists(folder)) { try { Directory.CreateDirectory(folder); } catch (Exception ms) { } }

        if (File.Exists(fullFilePath)) { try { File.Delete(fullFilePath); } catch (Exception ms) { } }
        if (File.Exists(fullFilePath2)) { try { File.Delete(fullFilePath2); } catch (Exception ms) { } }

        byte[] file = (byte[])pdf.GetBuffer();
        File.WriteAllBytes(fullFilePath, file);

        PdfDocument doc = new PdfDocument();
        doc.Pages.Add(new PdfPage());
        XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]);
        XImage img = XImage.FromFile(fullFilePath);

        xgr.DrawImage(img, 0, 0);
        doc.Save(fullFilePath2);
        doc.Close();

        return fullFilePath2;
    }
}
