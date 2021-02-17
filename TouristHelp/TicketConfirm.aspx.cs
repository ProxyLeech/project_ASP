using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;

namespace TouristHelp
{
    public partial class TicketConfirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string resId = Request.QueryString["ResId"];
            Food_Reservation ticket = new Food_Reservation();
            ticket.CancelReservation(int.Parse(resId));
        }
    }
}