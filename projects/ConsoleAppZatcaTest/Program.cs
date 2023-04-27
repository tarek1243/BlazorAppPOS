using System;
using System.Text;
using System.Drawing;
using QRCoder;

public class ZATCASimpleInvoiceQRGenerator
{

    public static void Main()
    {
        var saudiConvertion = new SaudiConvertion();

       //string  qrStringx = saudiConvertion.getTest();
       string  qrStringx = saudiConvertion.getBase64( "sellerName" , "vat" , DateTime.Now.ToString() , 100.ToString(), 15.ToString());

        // Generate QR code bitmap
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrStringx.ToString(), QRCodeGenerator.ECCLevel.Q);
        QRCode qrCode = new QRCode(qrCodeData);
        Bitmap qrCodeBitmap = qrCode.GetGraphic(10);

        // Save QR code image
        qrCodeBitmap.Save("ZATCA_Simple_Invoice_QR.png", System.Drawing.Imaging.ImageFormat.Png);

    }
}
