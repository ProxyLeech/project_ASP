using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;


namespace TouristHelp
{
    public partial class AdminPageRewardSystem : System.Web.UI.Page
    {
        List<ShopVoucher> shopList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                shopRepeater();
            }
            DateTime dateTime = DateTime.Now;
            this.Label1.Text = dateTime.ToString();


        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPageShop.aspx");
        }

        private void shopRepeater()
        {
            ShopVoucher shop = new ShopVoucher();
            shopList = shop.GetAllShop();

            repeatShop.DataSource = shopList;
            repeatShop.DataBind();
        }

       
    }
}