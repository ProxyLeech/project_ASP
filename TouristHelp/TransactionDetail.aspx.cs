using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using QRCoder;


namespace TouristHelp
{
    public partial class TransactionDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string shopCode = Request.QueryString["Code"];
            //string code = "touristhelp20200208080154.azurewebsites.net/TransactionConfirm.aspx?Code=" + shopCode;
            //QRCodeGenerator qrGenerator = new QRCodeGenerator();

            //// changed library code, therefore error occurs
            ////https://tutorialslink.com/Articles/How-to-Implementing-Two-Factor-Authentication-in-Aspnet-MVC-with-Google-Authenticator/26
            ////QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            //System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            //imgBarCode.Height = 150;
            //imgBarCode.Width = 150;
            //using (Bitmap bitMap = qrCode.GetGraphic(20))
            //{
            //    using (MemoryStream ms = new MemoryStream())
            //    {
            //        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            //        byte[] byteImage = ms.ToArray();
            //        imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
            //    }
            //    PlaceHolder1.Controls.Add(imgBarCode);
            //}
        }
    }
}