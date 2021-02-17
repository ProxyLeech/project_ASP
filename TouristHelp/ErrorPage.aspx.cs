using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TouristHelp
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonHome_Click(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("IndexLO.aspx");
            }
            else
            {
                Response.Redirect("IndexAdmin.aspx");
            }
        }
    }
}