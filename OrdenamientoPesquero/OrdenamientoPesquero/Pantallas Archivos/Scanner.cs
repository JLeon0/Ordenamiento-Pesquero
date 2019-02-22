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
            oDevice = dlg.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, true, false);
        }
    }
    public string Scann(int x)
    {
        ImageFile imageFile = dlg.ShowAcquireImage(oDevice.Type, WiaImageIntent.GrayscaleIntent, WiaImageBias.MaximizeQuality,
            "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}", false, true, false);
        WIA.Vector vector = imageFile.FileData;
        System.Drawing.Image i = System.Drawing.Image.FromStream(new System.IO.MemoryStream((byte[])vector.get_BinaryData()));

        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string folder = path + "/PDF/";
        string fullFilePath = folder + x + "-.pdf";
        string fullFilePath2 = folder + x + "-2.pdf";

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

        DialogResult result = MessageBox.Show("Desea anexar otra página?", "¿?", MessageBoxButtons.YesNoCancel);
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
