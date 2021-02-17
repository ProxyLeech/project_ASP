using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;

namespace TouristHelp
{
    public partial class Guidebook : System.Web.UI.Page
    {
        void Page_PreInit(Object sender, EventArgs e)
        {
            if (Session["tourist_id"] == null && Session["tourguide_id"] == null)
            {
                this.MasterPageFile = "~/Default.master";
            }
        }

        List<Attraction> acttList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["AttractionType"] == null && Session["AttractionInterest"] == null) //filter codes
                {
                    loadRepeater("All", "Popular");
                }
                else
                {
                    DdlType.SelectedValue = Session["AttractionType"].ToString();
                    DdlInterest.SelectedValue = Session["AttractionInterest"].ToString();
                    loadRepeater(Session["AttractionType"].ToString(), Session["AttractionInterest"].ToString());
                }
                   
            }
            
        }

        private void loadRepeater(string type, string interest)
        {
            Attraction actt = new Attraction();
            
            if (interest == "Popular")
            {
                if (type == "All")
                    {
                        acttList = actt.ListAttractionAll();
                    }
                else
                    {
                        acttList = actt.ListAttraction(type);
                    }
            }
            else if (interest == "Personalised")
            {
                if (type == "All")
                {
                    Interest i = new Interest();
                    string userInt = null;
                    try
                    {
                        userInt = i.checkInterests(int.Parse(Session["tourist_id"].ToString())).InterestName;
                    }
                    catch
                    {
                        
                    }
                    if (userInt == null)
                    {
                        acttList = actt.ListAttractionAll();
                    }
                    else
                    {
                        acttList = actt.ListAttractionAll_Personal(userInt);
                    }
                    
                }
                else
                {
                    Interest i = new Interest();
                    string userInt = null;
                    try
                    {
                        userInt = i.checkInterests(int.Parse(Session["tourist_id"].ToString())).InterestName;
                    }
                    catch
                    {
                        
                    }
                    if (userInt == null)
                    {
                        acttList = actt.ListAttraction(type);
                    }
                    else
                    {
                        acttList = actt.ListAttraction_Personal(type, userInt);
                    }
                }
            }

            RepeaterAttraction.DataSource = acttList;
            RepeaterAttraction.DataBind();
        }


        protected void GoNextPage(object source, RepeaterCommandEventArgs e)
        {
            RepeaterItem item1 = e.Item;
            Label attId = (Label)item1.FindControl("LbId");
            Label attTran = (Label)item1.FindControl("LbTran");

            Session["AttractionId"] = attId.Text;

            if (attTran.Text == "Food Reservation")
            {
                Response.Redirect("Reservation_Food.aspx");
            }
            else if (attTran.Text == "Ticket")
            {
                Response.Redirect("Ticketing.aspx");
            }
            
        }

        protected void ButtonFilter_Click(object sender, EventArgs e)
        {
            Session["AttractionType"] = DdlType.SelectedValue;
            Session["AttractionInterest"] = DdlInterest.SelectedValue;
            Response.Redirect("Guidebook.aspx");
        }
    }
}