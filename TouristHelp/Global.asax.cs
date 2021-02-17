using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using TouristHelp.BLL;
using TouristHelp.DAL;
using TouristHelp.Models;

namespace TouristHelp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            try
            {
                if (Session["tourist_id"] != null)
                {
                    Tourist user = TouristDAO.SelectTouristById(int.Parse(Session["tourist_id"].ToString()));
                    Logs log = new Logs(user.UserId.ToString(), "Error", (exc.InnerException.GetBaseException()).ToString(), DateTime.Now);
                    log.AddLogs(log);
                }
                else if (Session["tourguide_id"] != null)
                {
                    TourGuide user = TourGuideDAO.SelectTourGuideById(int.Parse(Session["tourguide_id"].ToString()));
                    Logs log = new Logs(user.UserId.ToString(), "Error", (exc.InnerException.GetBaseException()).ToString(), DateTime.Now);
                    log.AddLogs(log);
                }
                else
                {
                    Logs log = new Logs("Unknown", "Error", (exc.InnerException.GetBaseException()).ToString(), DateTime.Now);
                    log.AddLogs(log);
                }
            }
            catch (Exception)
            {
                //Logs log = new Logs("Unknown", "Error", exc.InnerException.GetBaseException().ToString(), DateTime.Now);
                //log.AddLogs(log);
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("X-Frame-Options", "DENY");
        }


    }
}