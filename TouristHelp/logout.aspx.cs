using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;
using TouristHelp.DAL;
using TouristHelp.Models;

namespace TouristHelp
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //logout log codes
            if (Session["tourist_id"] != null)
            {
                Tourist user = TouristDAO.SelectTouristById(int.Parse(Session["tourist_id"].ToString()));
                Logs log = new Logs(user.UserId.ToString(), "Login", "User successfully logged out", DateTime.Now);
                log.AddLogs(log);
            }
            else if (Session["tourguide_id"] != null)
            {
                TourGuide user = TourGuideDAO.SelectTourGuideById(int.Parse(Session["tourguide_id"].ToString()));
                Logs log = new Logs(user.UserId.ToString(), "Login", "User successfully logged out", DateTime.Now);
                log.AddLogs(log);
            }
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("Login.aspx", false);

            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
            }

            if (Request.Cookies["AuthToken"] != null)
            {
                Response.Cookies["AuthToken"].Value = string.Empty;
                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);

            }
        }
    }
}