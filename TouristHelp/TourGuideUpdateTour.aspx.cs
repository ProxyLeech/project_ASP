using System;
using System.Collections.Generic;
using System.Linq;
using TouristHelp.Models;

using System.Web;
using TouristHelp.DAL;

using System.Web.UI;
using System.Web.UI.WebControls;

namespace TouristHelp
{
    public partial class TourGuideUpdateTour : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TourGuide tg = TourGuideDAO.SelectTourGuideById(int.Parse(Session["tourguide_id"].ToString()));
            tourguideidLabel.Text = tg.TourGuideId.ToString();
            tourguideuseridLabel.Text = tg.UserId.ToString();
        }


        protected void BtnSubmit1_Click(object sender, EventArgs e)
        {
            ToursDAO.InsertTour(int.Parse(tourguideuseridLabel.Text), int.Parse(tourguideidLabel.Text), tourstitleTextBox.Text, tourdescriptionTextBox.Text, tourdetailsTextBox.Text, tourpriceTextBox.Text);

        }
    }
}