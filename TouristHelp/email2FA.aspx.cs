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
    public partial class email2FA : System.Web.UI.Page
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
                    Response.Redirect("index.aspx");
                }
            }




        }




        protected void verifyEmail(object sender, EventArgs e)
        {


            string test = Request.Form["g-recaptcha-response"];

            string verifyToken = Request.QueryString["verify2FA"];

            string emailID = TouristDAO.getEmailByToken(verifyToken);


            string userID = TouristDAO.userIDFromEmail(emailID);

            string code = twofaemailTB.Text;

            if (Page.IsValid)
            {
                if (!ReCaptchaPassed(Request.Form["g-recaptcha-response"]))
                {
                    string errorMsg = "You have failed the CAPTCHA";
                    ModelState.AddModelError(string.Empty, "You failed the CAPTCHA.");
                    System.Diagnostics.Debug.WriteLine("This is a log");
                    //Response.Redirect("Login.aspx");
                    email2FA_Btn.Enabled = false;
                }

                else if (TouristDAO.Email2FAValidation(code) == true)
                {



                    Tourist user = TouristDAO.SelectTouristByEmail(emailID);
                    Session["tourist_id"] = user.TouristId.ToString();

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

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string code = twofaemailTB.Text;
            if (TouristDAO.Email2FAValidation(code) == false)
            {
                args.IsValid = false;
            }

            else
            {

            }
        }

        protected void authRedirect(object sender, EventArgs e)
        {
            string token = Request.QueryString["verify2FA"];

            string emailID = TouristDAO.getEmailByToken(token);


            int userID = int.Parse(TouristDAO.userIDFromEmail(emailID));

            string getEmail = TouristDAO.selectEmailbyID(userID);
            Response.Redirect("Auth2FA.aspx?" + "verify2FA=" + token);
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