using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using TouristHelp.BLL;

namespace TouristHelp
{
    public partial class StatisticsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            GetChartData();
        }

        private void GetChartData()
        {
            Series series = Chart1.Series["Series1"];

            Logs logs = new Logs();
            series.Points.AddXY("Login Success", logs.GetChartData("Login", "successfully logged in"));
            series.Points.AddXY("Login Fail", logs.GetChartData("Login", "failed log in"));
            series.Points.AddXY("Email Wrong", logs.GetChartData("Login", "An incorrect or missing email was input"));
            series.Points.AddXY("Accounts Locked", logs.GetChartData("Login", "User account has been locked"));
            series.Points.AddXY("Registration", logs.GetChartData("Login", "User successfully registered"));
            series.Points.AddXY("Errors", logs.GetChartData("Error", ""));
        }

    }
}