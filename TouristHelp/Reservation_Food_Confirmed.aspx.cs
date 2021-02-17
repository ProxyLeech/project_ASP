using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TouristHelp
{
    public partial class Reservation_Food_Confirmed1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ResName"] != null)
            {
                lbName.Text = Session["ResName"].ToString();
                lbPlace.Text = Session["ResLoc"].ToString();
                lbDateTime.Text = Session["ResDate"].ToString() + " : " + Session["ResTime"].ToString();
                lbPax.Text = Session["ResPax"].ToString();
            }
            else
            {
                Response.Redirect("Guidebook.aspx");
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Guidebook.aspx");
        }
    }
}