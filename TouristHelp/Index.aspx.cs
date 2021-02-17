using System;
using TouristHelp.DAL;
using TouristHelp.BLL;

namespace TouristHelp
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["tourist_id"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {

                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Response.Redirect("Login.aspx", false);
                }

                else
                {

                    string name = "";
                    try
                    {
                        name = TouristDAO.SelectTouristById(int.Parse(Session["tourist_id"].ToString())).Name;
                    }
                    catch
                    {
                        //causing error
                        //name = TourGuideDAO.SelectTourGuideById(int.Parse(Session["tourguide_id"].ToString())).Name;
                    }
                    finally
                    {
                        LblName.Text = name;
                    }

                }


            }
            else
            {
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

                Response.Redirect("Login.aspx");
            }
        }


    }
}