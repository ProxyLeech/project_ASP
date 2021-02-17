using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;
using System.Drawing;
using TouristHelp.DAL;
using System.Data.SqlClient;

namespace TouristHelp
{
    public partial class Shop : System.Web.UI.Page
    {
        int voucherCost;

        List<ShopVoucher> shopList;

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







            Session["user_id"] = Session["tourist_id"];

            string user_id = Session["user_id"].ToString();

            //int userId = Convert.ToInt32(user_id);
            //// Retrieve TDMaster records by account
            //Reward td = new Reward();
            //td = td.GetRewardById(user_id);



            //DateTime dateNow = DateTime.Now;



            ////DateTime NextDayDate = dateNow.AddHours(24);

            //if (td.loggedInLog == true && td.loggedInDate.Date != DateTime.Now.Date)
            //{

            //    int loginCount = td.loginCount;
            //    int loginStreak = td.loginStreak;
            //    int creditBalance = td.creditBalance;
            //    bool renewLogIn = false;
            //    DateTime loggedInDate = td.loggedInDate;
            //    bool newDateCheck = false;
            //    int remainBonusDays = td.remainBonusDays;

            //    td.updateLoggedIn(userId, loginCount, loginStreak, creditBalance, remainBonusDays, renewLogIn, loggedInDate, newDateCheck);

            //}


            //if (td.loggedInLog == false)
            //{

            //    int timeDifference = DateTime.Compare(td.loggedInDate, dateNow);

            //    if (dateNow.Subtract(td.loggedInDate) <= TimeSpan.FromHours(24))
            //    {
            //        int loginCount = td.loginCount + 1;
            //        int loginStreak = td.loginStreak + 1;
            //        int creditBalance = td.creditBalance + 5;
            //        bool loggedInLog = true;
            //        DateTime loggedInDate = DateTime.Now;
            //        bool newDateCheck = true;
            //        int remainBonusDays = td.remainBonusDays - 1;

            //        td.updateLoggedIn(userId, loginCount, loginStreak, creditBalance, remainBonusDays, loggedInLog, loggedInDate, newDateCheck);

            //        if (loginStreak % 10 == 0)
            //        {
            //            creditBalance = td.creditBalance + td.bonusCredits + 5;
            //            remainBonusDays = td.remainBonusDays + 9;


            //            td.updateBonus(userId, loginStreak, creditBalance, remainBonusDays);
            //        }

            //    }

            //    else if (dateNow.Subtract(td.loggedInDate) > TimeSpan.FromHours(24))
            //    {
            //        int loginCount = td.loginCount + 1;
            //        int loginStreak = 0;
            //        int creditBalance = td.creditBalance + 5;
            //        bool loggedInLog = true;
            //        DateTime loggedInDate = DateTime.Now;
            //        bool newDateCheck = true;
            //        int remainBonusDays = 10;

            //        td.updateLoggedIn(userId, loginCount, loginStreak, creditBalance, remainBonusDays, loggedInLog, loggedInDate, newDateCheck);

            //    }


            //}

            //if (td.loginCount == 100)
            //{
            //    string loyaltyTier = "Gold";
            //    int bonuscredits = 15;

            //    td.updateLoyaltyBonus(userId, loyaltyTier, bonuscredits);
            //}



            //if (td.loginCount == 200)
            //{
            //    string loyaltyTier = "Diamond";
            //    int bonuscredits = 20;

            //    td.updateLoyaltyBonus(userId, loyaltyTier, bonuscredits);
            //}














            //if (!Page.IsPostBack)

            //{

            //    filterRepeater();

            //    if (Session["labelSuccess"] != null)
            //    {
            //        notifyLabel.Text = Session["labelSuccess"].ToString();
            //        notifyLabel.Visible = true;
            //        notifyLabel.ForeColor = Color.Green;
            //    }



            //    if (Session["labelFail"] != null)
            //    {
            //        notifyLabel.Text = Session["labelFail"].ToString();
            //        notifyLabel.Visible = true;
            //        notifyLabel.ForeColor = Color.Red;
            //    }



            //}


            //else if (Page.IsPostBack)

            //{

            //    filterRepeater();


            //    if (Session["labelFail"] != null)
            //    {
            //        notifyLabel.Text = null;
            //        notifyLabel.Visible = false;
            //        notifyLabel.ForeColor = Color.Red;
            //    }

            //}




            //Session["user_id"] = Label1.Text;


            //// Retrieve Reward records by account
            //td = td.GetRewardById(user_id);

            //creditBalance.Text = td.creditBalance.ToString();
            //membershipTier.Text = td.membershipTier.ToString();
            //totalDiscount.Text = td.totalDiscount.ToString();
            //loginCount.Text = td.loginCount.ToString();
            //loginStreak.Text = td.loginCount.ToString();
            //loyaltyTier.Text = td.loyaltyTier.ToString();
            //remainBonusDays.Text = td.remainBonusDays.ToString();
            //bonusCredits.Text = td.bonusCredits.ToString();




        }







        //private void filterRepeater()
        //{

        //    if (filterSearch.SelectedItem.Value == "Search By Category")
        //    {
        //        ShopVoucher shop = new ShopVoucher();
        //        shopList = shop.GetAllShop();

        //        Repeat1.DataSource = shopList;
        //        Repeat1.DataBind();
        //    }
        //    else if (filterSearch.SelectedItem.Value == "Popular")
        //    {
        //        ShopVoucher filter = new ShopVoucher();
        //        shopList = filter.getPopularFilter();

        //        Repeat1.DataSource = shopList;
        //        Repeat1.DataBind();

        //    }
        //    else if (filterSearch.SelectedItem.Value == "Newest")
        //    {
        //        ShopVoucher filter = new ShopVoucher();
        //        shopList = filter.getNewFilter();

        //        Repeat1.DataSource = shopList;
        //        Repeat1.DataBind();

        //    }
        //    else if (filterSearch.SelectedItem.Value == "Low Price")
        //    {
        //        ShopVoucher filter = new ShopVoucher();
        //        shopList = filter.getLowFilter();

        //        Repeat1.DataSource = shopList;
        //        Repeat1.DataBind();

        //    }

        //    else if (filterSearch.SelectedItem.Value == "High Price")
        //    {
        //        ShopVoucher filter = new ShopVoucher();
        //        shopList = filter.getHighFilter();

        //        Repeat1.DataSource = shopList;
        //        Repeat1.DataBind();
        //    }
        //}



        //private void loadRepeater()
        //{
        //    ShopVoucher shop = new ShopVoucher();
        //    shopList = shop.GetAllShop();

        //    Repeat1.DataSource = shopList;
        //    Repeat1.DataBind();
        //}


        protected void NextPage(object sender, EventArgs e)
        {
            Session["user_id"] = "7"; // change to name we have the actual name here arady
        }



        protected void NextPage(object source, RepeaterCommandEventArgs e)
        {
            RepeaterItem item1 = e.Item;
            Label voucherQuantity = (Label)item1.FindControl("voucher_Qty");

            Session["voucher_Qty"] = voucherQuantity.Text;
            Response.Redirect("Reservation_Food.aspx");
        }

        protected bool validatePurchase()
        {
            Session["user_id"] = Session["tourist_id"];


            string user_id = Session["user_id"].ToString();

            // Retrieve Reward records by account
            Reward td = new Reward();
            td = td.GetRewardById(user_id);

            int creditBalance = td.creditBalance;

       

            // Retrieve ShopVoucher records by account
            ShopVoucher ts = new ShopVoucher();





            bool result;
            if (creditBalance > voucherCost)
            {

                result = true;
            }
            else
            {
                result = false;

            }
            return result;

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

            //string ProductSelected;


            //Session["user_id"] = "1";
            //string user_id = Session["user_id"].ToString();
            //// Retrieve ShopVoucher records by account

            //Reward td = new Reward();
            //td = td.GetRewardById(user_id);

            //int creditBalance = Convert.ToInt32(td.creditBalance);



            //Session["voucher_id"] = "1";

            //string shop_id = Session["voucher_id"].ToString();
            //// Retrieve ShopVoucher records by account
            //ShopVoucher ts = new ShopVoucher();

            //ts = ts.GetShopById(shop_id);

            //string voucherName = ts.voucherName;
            //int cost = Convert.ToInt32(ts.voucherCost);





            ////int quantity = Convert.ToInt32(DDLquantity);

            ////int quantity = Convert.ToInt32(voucherQty.SelectedValue);

            //int quantity;

            //if (validatePurchase() == true)
            //{
            //    foreach (RepeaterItem dataItem in Repeat1.Items)
            //    {
            //        ProductSelected = ((DropDownList)dataItem.FindControl("voucher_Qty")).SelectedItem.Text; //No error

            //        quantity = Convert.ToInt32(ProductSelected);


            //        int totalcost = cost * quantity;


            //        int credit = creditBalance - totalcost;



            //        Reward emp = new Reward(1, credit);
            //        int result = emp.UpdateAccount(emp);


            //        //Insert transaction into Transation Table





            //        int genId = new Random().Next(100000, 999999);

            //        string stats = "Available";

            //        DateTime date = DateTime.Now;
            //        TimeSpan duration = new TimeSpan(30, 0, 0, 0);
            //        DateTime expiry = date.Add(duration);

            //        int confirmcode = new Random().Next(100000, 999999);

            //        int userId = Convert.ToInt32(user_id);

            //        string name = voucherName;

            //        Transactions trans = new Transactions(genId, stats, expiry, confirmcode, userId, date, totalcost, quantity, name);


            //        trans.insertTrans();


            //        Response.Redirect("Shop.aspx");
            //        return;
            //    }






            //    Response.Redirect("Shop.aspx");
            //    notifyLabel.Text = "Purchase successful";
            //    notifyLabel.Visible = true;
            //    notifyLabel.ForeColor = Color.Green;
            //}

            //else
            //{
            //    notifyLabel.Text = "Insufficent credits";
            //    notifyLabel.Visible = true;
            //    notifyLabel.ForeColor = Color.Red;
            //}
        }

        //protected void addCreditBtn_Click(object sender, EventArgs e)
        //{
        //    Session["user_id"] = Session["tourist_id"].ToString();

        //    string user_id = Session["user_id"].ToString();

        //    int user_idInt = Convert.ToInt32(user_id);
        //    // Retrieve Reward records by account
        //    Reward td = new Reward();
        //    td = td.GetRewardById(user_id);

        //    int creditBalance = Convert.ToInt32(td.creditBalance);

        //    int credit = creditBalance + 1000;


        //    Reward emp = new Reward(user_idInt, credit);
        //    int result = emp.UpdateAccount(emp);



        //    Response.Redirect("Shop.Aspx", false);


        //}


        //protected void GvEmployee_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DropDownList quantity = (DropDownList)sender;
        //    quantity.DataSource = shopList;
        //    quantity.DataBind();
        //}

        //protected void Repeat1_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{

        //    RepeaterItem item1 = e.Item;

        //    int voucher_id;

        //    int quantity;

        //    int voucherStock;

        //    string voucherStatus;


        //    string voucherName;

        //    int genId;


            //DropDownList filterSearch = (DropDownList)item1.FindControl("filterSearch");

            //if (filterSearch.SelectedItem.Value == "Popular")
            //{
            //    ShopVoucher filter = new ShopVoucher();
            //    shopList = filter.getPopularFilter();

            //    Repeat1.DataSource = shopList;
            //    Repeat1.DataBind();

            //}
            //else if (filterSearch.SelectedItem.Value == "Newest")
            //{
            //    ShopVoucher filter = new ShopVoucher();
            //    shopList = filter.getNewFilter();

            //    Repeat1.DataSource = shopList;
            //    Repeat1.DataBind();

            //}
            //else if (filterSearch.SelectedItem.Value == "Low Price")
            //{
            //    ShopVoucher filter = new ShopVoucher();
            //    shopList = filter.getLowFilter();

            //    Repeat1.DataSource = shopList;
            //    Repeat1.DataBind();

            //}

            //else if (filterSearch.SelectedItem.Value == "High Price")
            //{
            //    ShopVoucher filter = new ShopVoucher();
            //    shopList = filter.getHighFilter();

            //    Repeat1.DataSource = shopList;
            //    Repeat1.DataBind();

            //}

        //    Session["user_id"] = Session["tourist_id"].ToString();
        //    string user_id = Session["user_id"].ToString();
        //    int user_idInt = Convert.ToInt32(user_id);

        //    // Retrieve ShopVoucher records by account

        //    Reward td = new Reward();
        //    td = td.GetRewardById(user_id);

        //    int creditBalance = Convert.ToInt32(td.creditBalance);

        //    HiddenField getId = (HiddenField)item1.FindControl("voucher_id");
        //    Session["voucher_id"] = getId.Value;
        //    voucher_id = Convert.ToInt32(getId.Value);


        //    HiddenField getMembershipCategory = (HiddenField)item1.FindControl("membershipCategory");
        //    Session["getMembershipCategory"] = getMembershipCategory.Value;
        //    string MembershipCategory = getMembershipCategory.Value;


        //    HiddenField getFoodCategory = (HiddenField)item1.FindControl("foodCategory");
        //    Session["getFoodCategory"] = getFoodCategory.Value;
        //    string foodCategory = getFoodCategory.Value;


        //    DropDownList getDropDown = (DropDownList)item1.FindControl("voucherQuantity");
        //    Session["voucherQuantity"] = getDropDown.SelectedValue;
        //    quantity = Convert.ToInt32(getDropDown.SelectedValue);

        //    Label getVoucherCost = (Label)item1.FindControl("voucherCost");
        //    Session["voucherCost"] = getVoucherCost.Text;
        //    voucherCost = Convert.ToInt32(getVoucherCost.Text);

        //    Label getVoucherName = (Label)item1.FindControl("voucherName");
        //    Session["voucherName"] = getVoucherName.Text;
        //    voucherName = getVoucherName.Text;



        //    Label getVoucherStock = (Label)item1.FindControl("voucherQty");
        //    Session["voucherName"] = getVoucherStock.Text;
        //    voucherStock = Convert.ToInt32(getVoucherStock.Text);

        //    HiddenField getVoucherPopularity = (HiddenField)item1.FindControl("voucherPopularity");
        //    Session["voucherPopularity"] = getVoucherPopularity.Value;
        //    int voucherPopularity = Convert.ToInt32(getVoucherPopularity.Value);

        //    Label getVoucherStatus = (Label)item1.FindControl("voucherStatus");
        //    Session["voucherStatus"] = getVoucherStatus.Text;
        //    voucherStatus = getVoucherStatus.Text;


        //    if (td.creditBalance < (voucherCost * quantity) || voucherStatus != "Available" || voucherStock < quantity )
        //    {




        //        string labelF = "Purchase Failed";
        //        Session["labelFail"] = labelF;

        //        Response.Redirect("Shop.aspx");






        //    }

        //    else
        //    {



        //        Label1.Visible = false;






        //        int totalcost = voucherCost * quantity;


        //        int credit = creditBalance - totalcost;



        //        Reward emp = new Reward(user_idInt, credit);
        //        int result = emp.UpdateAccount(emp);


        //        //Insert transaction into Transation Table





        //        genId = new Random().Next(100000, 999999);





        //        string stats = "Available";

        //        DateTime date = DateTime.Now;
        //        TimeSpan duration = new TimeSpan(30, 0, 0, 0);
        //        DateTime expiry = date.Add(duration);

        //        int confirmcode = new Random().Next(100000, 999999);

        //        int userId = Convert.ToInt32(user_id);

        //        string name = voucherName;

        //        string voucherCategory;

                    
        //        ShopVoucher ts = new ShopVoucher();

        //        if (MembershipCategory == "True")
        //        {
        //            voucherCategory = "Membership";
        //            int totalDiscount = 5;
        //            string membershipTier = "Silver";
        //            Transactions trans = new Transactions(genId, stats, expiry, confirmcode, userId, date, totalcost, quantity, name, voucherCategory);
        //            trans.insertTrans();
        //            td.membershipSubscription(userId, totalDiscount, membershipTier);


        //        }
        //        else if (foodCategory == "True")
        //        {
        //            voucherCategory = "Food";
        //            Transactions trans = new Transactions(genId, stats, expiry, confirmcode, userId, date, totalcost, quantity, name, voucherCategory);
        //            trans.insertTrans();
        //        }

        //        else
        //        {
        //            voucherCategory = "Others";
        //            Transactions trans = new Transactions(genId, stats, expiry, confirmcode, userId, date, totalcost, quantity, name, voucherCategory);
        //            trans.insertTrans();
        //        }

        //        int newVoucherQty = voucherStock - quantity;

        //        int newVoucherPopularity = voucherPopularity + 1;


        //        ShopVoucher updateShopVoucher = new ShopVoucher();

        //        if ( newVoucherQty <= 0)
        //        {
        //            voucherStatus = "Not Available";

        //            updateShopVoucher.updateVoucherStatus(voucher_id, newVoucherQty, voucherStatus, newVoucherPopularity);

        //        }

        //        else if (newVoucherQty > 0)
        //        {
        //            voucherStatus = "Available";

        //            updateShopVoucher.updateVoucherStatus(voucher_id, newVoucherQty, voucherStatus, newVoucherPopularity);
        //        }


        //        string labelS = "Purchase successful";
        //        Session["labelSuccess"] = labelS;

        //        Response.Redirect("Shop.aspx");
        //        return;



        //    }







        //    Response.Redirect("Shop.aspx");
        //}

        //protected void dailyReward_Click(object sender, EventArgs e)
        //{
        //    Session["user_id"] = Session["tourist_id"];

        //    string user_id = Session["user_id"].ToString();

        //    int userId = Convert.ToInt32(user_id);
        //    // Retrieve TDMaster records by account
        //    Reward td = new Reward();
        //    td = td.GetRewardById(user_id);

        //    int loginCount = td.loginCount + 1;
        //    int loginStreak = td.loginStreak + 1;
        //    int creditBalance = td.creditBalance + 5;
        //    bool loggedInLog = true;
        //    DateTime loggedInDate = DateTime.Now;
        //    bool newDateCheck = true;
        //    int remainBonusDays = td.remainBonusDays - 1;

        //    td.updateLoggedIn(userId, loginCount, loginStreak, creditBalance, remainBonusDays, loggedInLog, loggedInDate, newDateCheck);

        //    if (loginStreak % 10 == 0)
        //    {
        //        creditBalance = td.creditBalance + td.bonusCredits + 5;
        //        remainBonusDays = td.remainBonusDays + 9;


        //        td.updateBonus(userId, loginStreak, creditBalance, remainBonusDays);
        //    }

        //    if (td.loginCount == 100)
        //    {
        //        string loyaltyTier = "Gold";
        //        int bonuscredits = 15;

        //        td.updateLoyaltyBonus(userId, loyaltyTier, bonuscredits);
        //    }



        //    if (td.loginCount == 200)
        //    {
        //        string loyaltyTier = "Diamond";
        //        int bonuscredits = 20;

        //        td.updateLoyaltyBonus(userId, loyaltyTier, bonuscredits);
        //    }

        //}
    }
}
