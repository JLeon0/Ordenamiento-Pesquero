using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.IO;
using WIA;
public class Scanner
{
    Device oDevice;
    CommonDialog dlg;
    public Scanner(bool activado)
    {
        if (activado)
        {
            dlg = new CommonDialog();
            oDevice = dlg.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, true, false);
        }
    }
    public void Scann(string archivo)
    {
        var x = oDevice.Properties.Count;
        ImageFile imageFile = dlg.ShowAcquireImage(oDevice.Type, WiaImageIntent.GrayscaleIntent, WiaImageBias.MaximizeQuality,
            "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}", false, true, false);
        WIA.Vector vector = imageFile.FileData;
        System.Drawing.Image i = System.Drawing.Image.FromStream(new System.IO.MemoryStream((byte[])vector.get_BinaryData()));

        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string folder = path + "/PDF/";
        string fullFilePath = folder + "-" + archivo + ".pdf";
        string fullFilePath2 = folder + "-" + archivo + "2.pdf";

        if (!Directory.Exists(folder)) { try { Directory.CreateDirectory(folder); } catch (Exception ms) { } }

        if (File.Exists(fullFilePath)) { try { Directory.Delete(fullFilePath); } catch (Exception ms) { } }
        if (File.Exists(fullFilePath2)) { try { Directory.Delete(fullFilePath2); } catch (Exception ms) { } }

        byte[] file = (byte[])vector.get_BinaryData();
        File.WriteAllBytes(fullFilePath, file);


        PdfDocument doc = new PdfDocument();
        doc.Pages.Add(new PdfPage());
        XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]);
        XImage img = XImage.FromFile(fullFilePath);

        xgr.DrawImage(img, 0, 0);
        doc.Save(fullFilePath2);
        doc.Close();
    }


    public string ConvertToPDF(MemoryStream pdf)
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string folder = path + "/PDF/";
        string fullFilePath = folder + "TEMPORAL.pdf";
        string fullFilePath2 = folder + "TEMPORAL2.pdf";

        if (!Directory.Exists(folder)) { try { Directory.CreateDirectory(folder); } catch (Exception ms) { } }

        if (File.Exists(fullFilePath)) { try { Directory.Delete(fullFilePath); } catch (Exception ms) { } }
        if (File.Exists(fullFilePath2)) { try { Directory.Delete(fullFilePath2); } catch (Exception ms) { } }

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
