using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;


namespace TouristHelp
{
    public partial class AdminPageHotel : System.Web.UI.Page
    {
        List<HotelBook> hotelList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                hotelRepeater();
            }



        }


        private void hotelRepeater()
        {
            HotelBook hotel = new HotelBook();
            hotelList = hotel.GetAllHotel();

            repeatHotel.DataSource = hotelList;
            repeatHotel.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPageHotel2.aspx");
        }
    }
}