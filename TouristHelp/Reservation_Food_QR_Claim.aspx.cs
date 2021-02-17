using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;

namespace TouristHelp
{
    public partial class Reservation_Food_QR_Claim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string resId = Request.QueryString["ResId"];
            Food_Reservation res = new Food_Reservation();
            res.CancelReservation(int.Parse(resId));
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Guidebook.aspx");
        }
    }
}