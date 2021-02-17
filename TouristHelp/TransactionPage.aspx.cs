using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;
using System.Drawing;
using TouristHelp.DAL;

namespace TouristHelp
{
    public partial class Transaction : System.Web.UI.Page
    {
        List<Transactions> transList;

        protected void Page_Load(object sender, EventArgs e)
        {



            if (Session["tourist_id"] == null && Session["tourguide_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            else
            {

                try
                {
                    Label1.Text = Session["tourist_id"].ToString();
                }
                catch (NullReferenceException)
                {
                    Label1.Text = Session["tourguide_id"].ToString();
                }

            }

            //Session["user_id"] = "2";

            //string user_id = Session["user_id"].ToString();


            //int userId = 1;
            //Transactions inter = new Transactions();
            //List<Transactions> IntList = inter.getTransaction(userId);


            transFilter();

            // Retrieve Reward records by account
            //Reward td = new Reward();
            //td = td.GetRewardById(user_id);




            //voucherGen_id.Text = trans.voucherGen_id.ToString();

            //voucherStats.Text = trans.voucherStats.ToString();

            //voucherExpiry.Text = trans.voucherExpiry.ToString();

            //confirmCode.Text = trans.confirmCode.ToString();

            //voucherDate.Text = trans.voucherDate.ToString();

            //voucherTotalCost.Text = trans.voucherTotalCost.ToString();




        }

     



        private void transFilter()
        {

            int userId = Convert.ToInt32(Session["tourist_id"]);
           













            if (filterTrans.SelectedItem.Value == "Newest")
            {
                Transactions getHotel = new Transactions();
                List<Transactions> transList = getHotel.getTransaction(userId);



                // using gridview to bind to the list of employee objects
                repeatTrans.Visible = true;
                repeatTrans.DataSource = transList;
                repeatTrans.DataBind();

                repeatTrans.DataSource = transList;
                repeatTrans.DataBind();



            }

            else if (filterTrans.SelectedItem.Value == "Oldest")
            {
                Transactions getHotel = new Transactions();
                List<Transactions> transList = getHotel.getTransactionOldest(userId);



                // using gridview to bind to the list of employee objects
                repeatTrans.Visible = true;
                repeatTrans.DataSource = transList;
                repeatTrans.DataBind();

                repeatTrans.DataSource = transList;
                repeatTrans.DataBind();

            }
        }


        protected void repeatTrans_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            RepeaterItem transList = e.Item;

            HiddenField getCode = (HiddenField)transList.FindControl("confirmCode");
            Session["code"] = getCode.Value;
            int code = Convert.ToInt32(getCode.Value);

            Label getShopStatus = (Label)transList.FindControl("voucherStats");
            Session["hotelStatus"] = getShopStatus.Text;
            string shopStatus = getShopStatus.Text;

            Button getButton = (Button)transList.FindControl("getQRcode");
            Session["getButton"] = getButton;

            if (shopStatus == "Expired" || shopStatus.ToString() == "Used")
            {
                Label2.Visible = true;
                Label2.Text = "This hotel reservation has been active or used";
                getButton.Enabled = false;
                Response.Redirect("TransactionPage.aspx");
            }

            else
            {
                Response.Redirect("/TransactionDetail.aspx?code=" + code);
            }

        }
    }
}