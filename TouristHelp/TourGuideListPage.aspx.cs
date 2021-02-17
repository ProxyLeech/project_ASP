using System;
using System.Collections.Generic;
using TouristHelp.Models;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;

namespace TouristHelp
{
    public partial class TourGuideListPage : System.Web.UI.Page
    {
        List<TourGuide> tourguideList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["tourist_id"] == null && Session["tourguide_id"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    if (Session["LanguageSelect"] == null)
                    {
                        loadRepeater("All");
                    }
                    else
                    {
                        DropDownListLanguage.SelectedValue = Session["LanguageSelect"].ToString();
                        loadRepeater(Session["LanguageSelect"].ToString());
                    }
                }


            }




            ////Michaels daily reward check, remove if causing error

            //Session["user_id"] = Session["tourist_id"];

            //string user_id = Session["user_id"].ToString();

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




            ////Michaels daily reward check, remove if causing error
        }

        private void loadRepeater(string language)
        {
            tourguideList = TourGuide.GetAllTourGuidesByLanguage(language);


            if (language == "All")
            {
                tourguideList = TourGuide.GetAllTourGuide();

            }
            else
            {
                tourguideList = TourGuide.GetAllTourGuidesByLanguage(language);
            }

            Repeater1.DataSource = tourguideList;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            RepeaterItem item1 = e.Item;
            Label theName = (Label)item1.FindControl("LbName");
            Label theuserId = (Label)item1.FindControl("LbuserId");
            Label thetourguideId = (Label)item1.FindControl("LbtourguideId");

            Label theEmail = (Label)item1.FindControl("LbEmail");
            Label thePassword = (Label)item1.FindControl("LbPassword");
            Label theTours = (Label)item1.FindControl("LbTours");
            Label theDescription = (Label)item1.FindControl("LbDescription");
            Label theLanguages = (Label)item1.FindControl("LbLanguages");
            Label theCredentials = (Label)item1.FindControl("LbCredentials");
            Label theTourDescription = (Label)item1.FindControl("Lbtourdescription");
            Label theTourDetails = (Label)item1.FindControl("Lbtourdetails");
            Label theTourPrice = (Label)item1.FindControl("Lbtourprice");


            Session["SSName"] = theName.Text;
            Session["SSEmail"] = theEmail.Text;
            Session["SSUserId"] = theuserId.Text;
            Session["SSTourGuideId"] = thetourguideId.Text;
            Session["SSPassword"] = thePassword.Text;
            Session["SSDescription"] = theDescription.Text;
            Session["SSLanguages"] = theLanguages.Text;
            Session["SSCredentials"] = theCredentials.Text;

            Response.Redirect("TourGuideDetails.aspx");
        }

        protected void FilterButton_Click(object sender, EventArgs e)
        {
            Session["LanguageSelect"] = DropDownListLanguage.SelectedValue;
            Response.Redirect("TourGuideListPage.aspx");
        }
    }
}