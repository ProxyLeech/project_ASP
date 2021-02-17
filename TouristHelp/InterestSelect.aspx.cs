using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;

namespace TouristHelp
{
	public partial class InterestSelect : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["tourist_id"] == null && Session["tourguide_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            //int userId = int.Parse(Session["tourist_id"].ToString());
            //Interest inter = new Interest();
            //Interest IntList = inter.checkInterests(userId);
            //if(IntList != null)
            //{
                
            //        if(IntList.InterestName == "Food")
            //        {
            //            BtnAddFood.Visible = false;
            //            BtnRemFood.Visible = true;
            //        }
            //        else if (IntList.InterestName == "Nature")
            //        {
            //            BtnAddNature.Visible = false;
            //            BtnRemNature.Visible = true;
            //        }
            //        else if (IntList.InterestName == "Amusement Park")
            //        {
            //            BtnAddAP.Visible = false;
            //            BtnRemAP.Visible = true;
            //        }
            //        else if (IntList.InterestName == "Culture")
            //        {
            //            BtnAddAP.Visible = false;
            //            BtnRemAP.Visible = true;
            //        }
            //        else if (IntList.InterestName == "Shopping")
            //        {
            //            BtnAddAP.Visible = false;
            //            BtnRemAP.Visible = true;
            //        }

            //}



            //Michaels daily reward check, remove if causing error

            Session["user_id"] = Session["tourist_id"];

        //    string user_id = Session["user_id"].ToString();

        //    int userid = Convert.ToInt32(user_id);
        //    // Retrieve TDMaster records by account
        //    Reward td = new Reward();
        //    td = td.GetRewardById(user_id);



        //    DateTime dateNow = DateTime.Now;



        //    //DateTime NextDayDate = dateNow.AddHours(24);

        //    if (td.loggedInLog == true && td.loggedInDate.Date != DateTime.Now.Date)
        //    {

        //        int loginCount = td.loginCount;
        //        int loginStreak = td.loginStreak;
        //        int creditBalance = td.creditBalance;
        //        bool renewLogIn = false;
        //        DateTime loggedInDate = td.loggedInDate;
        //        bool newDateCheck = false;
        //        int remainBonusDays = td.remainBonusDays;

        //        td.updateLoggedIn(userid, loginCount, loginStreak, creditBalance, remainBonusDays, renewLogIn, loggedInDate, newDateCheck);

        //    }


        //    if (td.loggedInLog == false)
        //    {

        //        int timeDifference = DateTime.Compare(td.loggedInDate, dateNow);

        //        if (dateNow.Subtract(td.loggedInDate) <= TimeSpan.FromHours(24))
        //        {
        //            int loginCount = td.loginCount + 1;
        //            int loginStreak = td.loginStreak + 1;
        //            int creditBalance = td.creditBalance + 5;
        //            bool loggedInLog = true;
        //            DateTime loggedInDate = DateTime.Now;
        //            bool newDateCheck = true;
        //            int remainBonusDays = td.remainBonusDays - 1;

        //            td.updateLoggedIn(userid, loginCount, loginStreak, creditBalance, remainBonusDays, loggedInLog, loggedInDate, newDateCheck);

        //            if (loginStreak % 10 == 0)
        //            {
        //                creditBalance = td.creditBalance + td.bonusCredits + 5;
        //                remainBonusDays = td.remainBonusDays + 9;


        //                td.updateBonus(userid, loginStreak, creditBalance, remainBonusDays);
        //            }

        //        }

        //        else if (dateNow.Subtract(td.loggedInDate) > TimeSpan.FromHours(24))
        //        {
        //            int loginCount = td.loginCount + 1;
        //            int loginStreak = 0;
        //            int creditBalance = td.creditBalance + 5;
        //            bool loggedInLog = true;
        //            DateTime loggedInDate = DateTime.Now;
        //            bool newDateCheck = true;
        //            int remainBonusDays = 10;

        //            td.updateLoggedIn(userid, loginCount, loginStreak, creditBalance, remainBonusDays, loggedInLog, loggedInDate, newDateCheck);

        //        }


        //    }

        //    if (td.loginCount == 100)
        //    {
        //        string loyaltyTier = "Gold";
        //        int bonuscredits = 15;

        //        td.updateLoyaltyBonus(userid, loyaltyTier, bonuscredits);
        //    }



        //    if (td.loginCount == 200)
        //    {
        //        string loyaltyTier = "Diamond";
        //        int bonuscredits = 20;

        //        td.updateLoyaltyBonus(userid, loyaltyTier, bonuscredits);
        //    }




        //    //Michaels daily reward check, remove if causing error

        //}
        //protected void Btn_AddInt(object sender, EventArgs e)
        //{
        //    Button b = (Button)sender;
        //    int userId = int.Parse(Session["tourist_id"].ToString());
        //    if (b.ID == "BtnAddFood")
        //    {
        //        string interestName = "Food";

        //        Interest inter = new Interest(interestName, userId);
        //        inter.AddInterest();
        //        BtnAddFood.Visible = false;
        //        BtnRemFood.Visible = true;
        //        BtnAddNature.Visible = true;
        //        BtnRemNature.Visible = false;
        //        BtnAddAP.Visible = true;
        //        BtnRemAP.Visible = false;
        //        BtnAddCulture.Visible = true;
        //        BtnRemCulture.Visible = false;
        //        BtnAddShopping.Visible = true;
        //        BtnRemShopping.Visible = false;
        //    }

        //    if(b.ID == "BtnAddNature")
        //    {
        //        string interestName = "Nature";

        //        Interest inter = new Interest(interestName, userId);
        //        inter.AddInterest();
        //        BtnAddNature.Visible = false;
        //        BtnRemNature.Visible = true;
        //        BtnAddFood.Visible = true;
        //        BtnRemFood.Visible = false;
        //        BtnAddAP.Visible = true;
        //        BtnRemAP.Visible = false;
        //        BtnAddCulture.Visible = true;
        //        BtnRemCulture.Visible = false;
        //        BtnAddShopping.Visible = true;
        //        BtnRemShopping.Visible = false;
        //    }

        //    if (b.ID == "BtnAddAP")
        //    {
        //        string interestName = "Amusement";

        //        Interest inter = new Interest(interestName, userId);
        //        inter.AddInterest();
        //        BtnAddAP.Visible = false;
        //        BtnRemAP.Visible = true;
        //        BtnAddNature.Visible = true;
        //        BtnRemNature.Visible = false;
        //        BtnAddFood.Visible = true;
        //        BtnRemFood.Visible = false;
        //        BtnAddCulture.Visible = true;
        //        BtnRemCulture.Visible = false;
        //        BtnAddShopping.Visible = true;
        //        BtnRemShopping.Visible = false;
        //    }

        //    if (b.ID == "BtnAddCulture")
        //    {
        //        string interestName = "Culture";

        //        Interest inter = new Interest(interestName, userId);
        //        inter.AddInterest();
        //        BtnAddCulture.Visible = false;
        //        BtnRemCulture.Visible = true;
        //        BtnAddAP.Visible = true;
        //        BtnRemAP.Visible = false;
        //        BtnAddNature.Visible = true;
        //        BtnRemNature.Visible = false;
        //        BtnAddFood.Visible = true;
        //        BtnRemFood.Visible = false;
        //        BtnAddShopping.Visible = true;
        //        BtnRemShopping.Visible = false;
        //    }

        //    if (b.ID == "BtnAddShopping")
        //    {
        //        string interestName = "Shopping";

        //        Interest inter = new Interest(interestName, userId);
        //        inter.AddInterest();
        //        BtnAddShopping.Visible = false;
        //        BtnRemShopping.Visible = true;
        //        BtnAddAP.Visible = true;
        //        BtnRemAP.Visible = false;
        //        BtnAddNature.Visible = true;
        //        BtnRemNature.Visible = false;
        //        BtnAddFood.Visible = true;
        //        BtnRemFood.Visible = false;
        //        BtnAddCulture.Visible = true;
        //        BtnRemCulture.Visible = false;
        //    }
        //}
        //protected void Btn_RemoveInt(object sender, EventArgs e)
        //{
        //    Button b = (Button)sender;
        //    int userId = int.Parse(Session["tourist_id"].ToString());
        //    if (b.ID == "BtnRemFood")
        //    {
        //        string interestName = "Food";

        //        Interest inter = new Interest();
        //        inter.RemoveInterest(interestName, userId);
        //        BtnAddFood.Visible = true;
        //        BtnRemFood.Visible = false;
        //    }

        //    if (b.ID == "BtnRemNature")
        //    {
        //        string interestName = "Nature";

        //        Interest inter = new Interest();
        //        inter.RemoveInterest(interestName, userId);
        //        BtnAddNature.Visible = true;
        //        BtnRemNature.Visible = false;
        //    }

        //    if (b.ID == "BtnRemAP")
        //    {
        //        string interestName = "Amusement";

        //        Interest inter = new Interest();
        //        inter.RemoveInterest(interestName, userId);
        //        BtnAddAP.Visible = true;
        //        BtnRemAP.Visible = false;
        //    }

        //    if (b.ID == "BtnRemCulture")
        //    {
        //        string interestName = "Culture";

        //        Interest inter = new Interest();
        //        inter.RemoveInterest(interestName, userId);
        //        BtnAddCulture.Visible = true;
        //        BtnRemCulture.Visible = false;
        //    }

        //    if (b.ID == "BtnRemShopping")
        //    {
        //        string interestName = "Shopping";

        //        Interest inter = new Interest();
        //        inter.RemoveInterest(interestName, userId);
        //        BtnAddShopping.Visible = true;
        //        BtnRemShopping.Visible = false;
        //    }
        }
    }
}