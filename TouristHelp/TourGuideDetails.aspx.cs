using System;
using System.Collections.Generic;
using System.Linq;
using TouristHelp.Models;
using TouristHelp.DAL;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TouristHelp
{
    public partial class TourGuideDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["tourist_id"] == null && Session["tourguide_id"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    tourguidenameLabel2.Text = (string)Session["SSName"];
                    tourguidedescriptionLabel2.Text = (string)Session["SSDescription"];
                    tourguidelanguagesLabel2.Text = (string)Session["SSLanguages"];
                    tourguideidLabel2.Text = (string)Session["SSTourGuideId"];
                    tourguidecredentialsLabel2.Text = (string)Session["SSCredentials"];
                    tourguideuserid.Text = (string)Session["SSUserId"];
                }
            }
        }

        protected void RedirectBtn_Click(object sender, EventArgs e)
        {

            Response.Redirect("TourDetailsPage.aspx");
        }

        protected void ContactButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SendMailToTourGuide.aspx");
        }
    }
}