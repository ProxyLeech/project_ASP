using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;

namespace TouristHelp
{
    public partial class Reservation_Food_QR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ResId"] != null)
            {
                string ResId = Session["ResId"].ToString();

                // Retrieve TDMaster records by Id
                Food_Reservation td = new Food_Reservation();
                td = td.GetReservationByIdSingle(int.Parse(ResId));

                lbName.Text = td.Name;
                lbTiming.Text = td.Date + " | " + td.Time;
                lbPax.Text = td.Pax.ToString();

                int reservationId = td.Id;
                string code = "touristhelp20200208080154.azurewebsites.net/Reservation_Food_QR_Claim.aspx?ResId=" + reservationId;
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                //QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
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
            else
            {
                Response.Redirect("List_Reservation_Food.aspx");
            }
            if (Session["tourist_id"] == null && Session["tourguide_id"] == null)
            {
                BtnConfirm.Text = "Login to reserve";
                BtnConfirm.CausesValidation = false;
            }
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            Food_Reservation res = new Food_Reservation();
            res = res.GetReservationByIdSingle(int.Parse(Session["ResId"].ToString()));
            res.CancelReservation(res.Id);

            Response.Redirect("List_Reservation_Food.aspx");
        }
    }
}