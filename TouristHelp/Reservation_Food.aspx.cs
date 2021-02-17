using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;

namespace TouristHelp
{
    public partial class Reservation_Food : System.Web.UI.Page
    {
        void Page_PreInit(Object sender, EventArgs e)
        {
            if (Session["tourist_id"] == null && Session["tourguide_id"] == null)
            {
                this.MasterPageFile = "~/Default.master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AttractionId"] != null)
            {
                string attractId = Session["AttractionId"].ToString();

                // Retrieve TDMaster records by Id
                Attraction td = new Attraction();
                td = td.GetAttractionDataById(attractId);

                lbName.Text = td.Name;
                lbDesc.Text = td.Description;
                lbPlace.Text = td.Location;
                LbImg.Text = td.Image;
            }
            else
            {
                Response.Redirect("Guidebook.aspx");
            }
            if (Session["tourist_id"] == null && Session["tourguide_id"] == null)
            {
                BtnConfirm.Text = "Login to reserve";
                BtnConfirm.CausesValidation = false;
            }
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
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
                Session["ResName"] = lbName.Text.ToString();
                Session["ResLoc"] = lbPlace.Text.ToString();
                Session["ResDate"] = tbDate.Text.ToString();
                Session["ResTime"] = TbTime.Text.ToString();
                Session["ResPax"] = TbPax.Text.ToString();

                Random random = new Random();

                //check whether a code exists already
                string code = random.Next(1000000, 9999999).ToString();
                Food_Reservation res = new Food_Reservation();
                List<String> codeList = res.GetQRCodesList();
                while (true && codeList != null)
                {
                    if (codeList.Contains(code))
                    {
                        code = random.Next(1000000, 9999999).ToString();
                    }
                    else
                    {
                        break;
                    }
                }

                Food_Reservation td = new Food_Reservation();
                td.InsertReservation(lbName.Text, tbDate.Text, TbTime.Text, int.Parse(TbPax.Text), int.Parse(Session["tourist_id"].ToString()), code, LbImg.Text);
                Response.Redirect("Reservation_Food_Confirmed.aspx");
            }
            
        }

        protected void Calendar1_SelectionChanged2(object sender, EventArgs e)
        {
            tbDate_PopupControlExtender.Commit(Calendar1.SelectedDate.ToShortDateString());
        }
    }
}