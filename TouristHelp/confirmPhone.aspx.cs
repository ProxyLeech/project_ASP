using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.DAL;

namespace TouristHelp
{
    public partial class confirmPhone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string token = Request.QueryString["verify2FA"];


            DateTime expiryToken = TouristDAO.tokenTimeValidation(token);
            if (DateTime.Now > expiryToken)

            {
                Response.Redirect("security2FA.aspx");
            }
            if (!IsPostBack)
            {

                try
                {
                    if (Session["tourist_id"] == null)
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
                catch
                {

                }

                HiddenField1.Value = Session["phone"].ToString();
                HiddenField2.Value = Session["tourist_id"].ToString();

            }

        }

        protected void verifyPhone(object sender, EventArgs e)
        {

            //int verifyPhone = int.Parse(Session["phone"].ToString());

            string verifyPhone = HiddenField1.Value.ToString();

            int userId = int.Parse(HiddenField2.Value);

            //userId = TouristDAO.SelectTouristById(int.Parse(userId).ToString()).UserId;

            userId = TouristDAO.getUserIdByTouristId(userId);


            string verifyToken = Request.QueryString["verify2FA"];
            string code = twofaphoneTB.Text;


            string test = Request.Form["g-recaptcha-response"];
            if (Page.IsValid)

            {

                if (!ReCaptchaPassed(Request.Form["g-recaptcha-response"]))
                {
                    string errorMsg = "You have failed the CAPTCHA";
                    ModelState.AddModelError(string.Empty, "You failed the CAPTCHA.");
                    System.Diagnostics.Debug.WriteLine("This is a log");
                    //Response.Redirect("Login.aspx");
                    phone2FA_Btn.Enabled = false;
                }

                else

                {
                    if (TouristDAO.validatePhoneVerification(code) == true)
                    {

                        TouristDAO.updatePhoneNo(userId, verifyPhone);



                        //Response.Redirect("security2FA.aspx");

                        Session["tourist_id"] = HiddenField2.Value;

                        Response.AddHeader("REFRESH", "3;URL=security2FA.aspx");

                        pnlThankYouMessage.Visible = true;

                    }

                }
            }
                

        }



        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string code = twofaphoneTB.Text;
            if (TouristDAO.validatePhoneVerification(code) == false)
            {
                args.IsValid = false;
            }

            else
            {

            }
        }


        public static bool ReCaptchaPassed(string gRecaptchaResponse)
        {
            HttpClient httpClient = new HttpClient();

            var res = httpClient.GetAsync($"https://www.google.com/recaptcha/api/siteverify?secret=6LeCmFcaAAAAANyX5Yu0ofFB5ohucWaPy83_vPYk&response={gRecaptchaResponse}").Result;

            if (res.StatusCode != HttpStatusCode.OK)
                return false;

            string JSONres = res.Content.ReadAsStringAsync().Result;
            dynamic JSONdata = JObject.Parse(JSONres);
            System.Diagnostics.Debug.WriteLine(res.Content.ReadAsStringAsync().Result);

            if (JSONdata.success != "true" && JSONdata.score >= 0.6)
                return false;

            return true;
        }
    }
}