using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;
using TouristHelp.DAL;
using TouristHelp.Models;
using System.Text;
using System.Security.Cryptography;
using Google.Authenticator;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;

namespace TouristHelp
{
    public partial class Auth2FA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string token = Request.QueryString["verify2FA"];

            string emailID = TouristDAO.getEmailByToken(token);

            DateTime expiryToken = TouristDAO.tokenTimeValidation(token);
            if (DateTime.Now > expiryToken)

            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Session["tourist_id"] == null)
                {

                    if (Request.Cookies["ASP.NET_SessionId"] != null)
                    {
                        Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                        Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
                    }

                    if (Request.Cookies["AuthToken"] != null)
                    {
                        Response.Cookies["AuthToken"].Value = string.Empty;
                        Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);

                    }


                }
                else if (Session["tourist_id"] != null)
                {
                    Response.Redirect("Index.aspx");
                }







            }
        }

        protected void verifyAuth2FA(object sender, EventArgs e)
        {
            //string key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);

            string test = Request.Form["g-recaptcha-response"];


            //string code = twofaemailTB.Text;
            //if (TouristDAO.Email2FAValidation(code) == true)
            //{

            //    string StringuserId = TouristDAO.VerifyUserByToken(code).ToString();
            //    int userid = int.Parse(StringuserId);
            //    Session["tourist_id"] = userid;
            //    Response.Redirect("Index.aspx");


            //Tourist user = TouristDAO.SelectTouristByEmail(emailID);
            //Session["tourist_id"] = user.TouristId.ToString();
            //Response.Redirect("Index.aspx");

            //}
            if (Page.IsValid)

            {

                string token = Request.QueryString["verify2FA"];

                string emailID = TouristDAO.getEmailByToken(token);

                string userID = TouristDAO.userIDFromEmail(emailID);

                string getKey = TouristDAO.findSecretKey(int.Parse(userID));

                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                var setupInfo = tfa.GenerateSetupCode("TouristHelp", emailID, getKey, false, 3);


                string authInput = authTestTB.Text.Trim();



                bool isCorrectPIN = tfa.ValidateTwoFactorPIN(getKey, authInput);


                string verifyToken = Request.QueryString["verify2FA"];

                if (!ReCaptchaPassed(Request.Form["g-recaptcha-response"]))
                {
                    string errorMsg = "You have failed the CAPTCHA";
                    ModelState.AddModelError(string.Empty, "You failed the CAPTCHA.");
                    System.Diagnostics.Debug.WriteLine("This is a log");
                    //Response.Redirect("Login.aspx");
                    auth2FABtn.Enabled = false;
                }


                else
                {
                    if (isCorrectPIN == true)
                    {


                        Tourist user = TouristDAO.SelectTouristByEmail(emailID);
                        Session["tourist_id"] = user.TouristId.ToString();

                        //string StringuserId = TouristDAO.userIDFromEmail(emailID);
                        //int userid = int.Parse(StringuserId);
                        //Session["tourist_id"] = userid;

                        //create a new GUID and save into the session
                        string guid = Guid.NewGuid().ToString();
                        Session["AuthToken"] = guid;

                        //now create a new cookie with this guid value
                        Response.Cookies.Add(new HttpCookie("AuthToken", guid));


                        Response.Redirect("Index.aspx");

                    }
                    else
                    {


                        //Response.Redirect(Request.RawUrl);
                    }


                }
            }




        }





        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {



            string token = Request.QueryString["verify2FA"];

            string emailID = TouristDAO.getEmailByToken(token);

            string userID = TouristDAO.userIDFromEmail(emailID);

            string getKey = TouristDAO.findSecretKey(int.Parse(userID));


            if (string.IsNullOrEmpty(authTestTB.Text))
            {



                CustomValidator1.Text = "Input cannot be empty!";
                args.IsValid = false;

            }
            else
            {



                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
                var setupInfo = tfa.GenerateSetupCode("TouristHelp", emailID, getKey, false, 3);
                string authInput = authTestTB.Text.Trim();

                bool isCorrectPIN = tfa.ValidateTwoFactorPIN(getKey, authInput);

                if (isCorrectPIN == false)
                {
                    CustomValidator1.Text = "Incorrect input, please try again";
                    args.IsValid = false;
                }
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