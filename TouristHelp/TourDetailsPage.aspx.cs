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
    public partial class TourDetailsPage : System.Web.UI.Page
    {
        decimal fxRate = 0;
        decimal convert = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["tourist_id"] == null)
                {
                    Response.Redirect("TourGuideDetails.aspx");
                }
                else
                {
                    Tours smth = ToursDAO.SelectTourByTourGuideId(int.Parse(Session["SSTourGuideId"].ToString()));
                    tourguidetitleLabel.Text = smth.Title;
                    tourdescriptionLabel.Text = smth.Description;
                    tourdetailsLabel.Text = smth.Details;
                    tourpriceLabel.Text = smth.Price.ToString();

                    gettouristid.Text = Session["tourist_id"].ToString();
                    gettourguidename.Text = Session["SSName"].ToString();
                    gettourguideid.Text = Session["SSTourGuideId"].ToString();
                }
            }
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (DateTime.Parse(TourDate.Text) < DateTime.Now)
            {
                Response.Write("Date Is Not Valid!");
            }
            else
            {

                string timeanddate = TourDate.Text + " " + TourTime.Text;
                string statuscheck = "-";

                TouristBooking obj = new TouristBooking(int.Parse(gettouristid.Text), gettourguidename.Text, tourguidetitleLabel.Text, timeanddate, statuscheck, int.Parse(gettourguideid.Text));
                TouristBookingDAO.InsertBooking(obj);
            }
        }

        protected void DropDownListCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ConvertCurrency_Click(object sender, EventArgs e)
        {
            string selectedCurrency = DropDownListCurrency.SelectedItem.ToString();
            if (selectedCurrency == "USD")
            {
                fxRate = 0.72m;
                convert = Math.Round(decimal.Parse(tourpriceLabel.Text) * fxRate, 2);
                convertedtourpriceLabel.Text = convert.ToString();
            }
            else if (selectedCurrency == "AUS")
            {
                fxRate = 1.07m;
                convert = Math.Round(decimal.Parse(tourpriceLabel.Text) * fxRate, 2);
                convertedtourpriceLabel.Text = convert.ToString();
            }
            else if (selectedCurrency == "CAD")
            {
                fxRate = 0.96m;
                convert = Math.Round(decimal.Parse(tourpriceLabel.Text) * fxRate, 2);
                convertedtourpriceLabel.Text = convert.ToString();
            }
            else if (selectedCurrency == "EUR")
            {
                fxRate = 0.66m;
                convert = Math.Round(decimal.Parse(tourpriceLabel.Text) * fxRate, 2);
                convertedtourpriceLabel.Text = convert.ToString();
            }
            else if (selectedCurrency == "JPY")
            {
                fxRate = 79.22m;
                convert = Math.Round(decimal.Parse(tourpriceLabel.Text) * fxRate, 2);
                convertedtourpriceLabel.Text = convert.ToString();
            }
        }



        protected void Calendar1_SelectionChanged2(object sender, EventArgs e)
        {
            TourDate_PopupControlExtender.Commit(Calendar1.SelectedDate.ToShortDateString());
        }
    }
}