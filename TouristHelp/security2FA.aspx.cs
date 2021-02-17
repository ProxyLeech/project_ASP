using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using TouristHelp.Models;
using TouristHelp.BLL;
using TouristHelp.DAL;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;

namespace TouristHelp
{
    public partial class settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tourist_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            else
            {

                try
                {
                    string phone = "";
                    string email = "";
                    int? userId;
                    userId = TouristDAO.SelectTouristById(int.Parse(Session["tourist_id"].ToString())).UserId;
                    phone = TouristDAO.checkPhone(userId).ToString();

                    if (phone == "")
                    {
                        confirmedPhone.Text = "";
                    }
                    else
                    {
                        confirmedPhone.Text = "****" + phone.Substring(4);

                    }


                    string getStatus2FA = TouristDAO.selectStatus2FAbyID(userId).ToString();

                    status2FALbl.Text = getStatus2FA;

                    if (status2FALbl.Text == "OFF")
                    {
                        status2FALbl.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        status2FALbl.ForeColor = System.Drawing.Color.Green;
                    }
                    email = TouristDAO.selectEmailbyID(userId).ToString();
                    email2FALbl.Text = "*****" + email.Substring(6);

                    string checkEmail2FA = TouristDAO.checkEmail2FAON(userId);

                    if (checkEmail2FA == "False")
                    {
                        checkEmail2FABtn.Text = "Inactive";
                    }
                    else
                    {
                        checkEmail2FABtn.Text = "Active";

                    }

                    string checkPhone2FA = TouristDAO.checkPhone2FAON(userId);

                    if (checkPhone2FA == "False")
                    {
                        CheckPhone2FABtn.Text = "Inactive";
                    }
                    else
                    {
                        CheckPhone2FABtn.Text = "Active";

                    }


                    string checkPhone = TouristDAO.checkPhone(userId);

                    if (checkPhone == "" || checkPhone == "NULL")
                    {
                        CheckPhone2FABtn.Enabled = false;
                    }
                    else

                    {
                        CheckPhone2FABtn.Enabled = true;
                    }






                }
                catch (NullReferenceException)
                {
                }



            }
        }

        protected void confirmPhoneBtn_Click(object sender, EventArgs e)
        {

            int? userId;

            userId = TouristDAO.SelectTouristById(int.Parse(Session["tourist_id"].ToString())).UserId;

            string phoneCode = Guid.NewGuid().ToString("n").Substring(0, 8);

            //Random r = new Random();
            //string phoneCode = r.Next().ToString();
            //string token = get_unique_string(50);
            string token = Guid.NewGuid().ToString("n").Substring(0, 15);

            string test = Request.Form["g-recaptcha-response"];
            if (Page.IsValid)
            {
                if (!ReCaptchaPassed(Request.Form["g-recaptcha-response"]))
                {
                    string errorMsg = "You have failed the CAPTCHA";
                    ModelState.AddModelError(string.Empty, "You failed the CAPTCHA.");
                    System.Diagnostics.Debug.WriteLine("This is a log");
                    //Response.Redirect("Login.aspx");
                    confirmPhoneBtn.Enabled = false;
                }

                else
                {

                    var accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
                    var authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
                    var fromPhoneNumber = Environment.GetEnvironmentVariable("FROM_PHONE_NUMBER");

                    

                    TwilioClient.Init(accountSid, authToken);

                    string phone = phoneTB.Text;

                    try
                    {
                        var sms = MessageResource.Create(
                       body: "Your one-time verification code is " + phoneCode +
                       " Do not share this code with anyone",
                       from: new Twilio.Types.PhoneNumber("+18" + fromPhoneNumber),
                       to: new Twilio.Types.PhoneNumber("+65" + phone)
                   );

                        Console.WriteLine(sms.Sid);



                        DateTime timeGenerated = DateTime.Now.AddMinutes(1);

                        TouristDAO.updatePhone2FACode(userId, phoneCode);

                        TouristDAO.update2FAToken(userId, token, timeGenerated);

                        Session["phone"] = phoneTB.Text.Trim();

                        Session["tourist_id"] = Session["tourist_id"];

                        Response.Redirect("confirmPhone.aspx?verify2FA=" + token);

                    }


                    catch (Twilio.Exceptions.ApiException)
                    {
                        invalidPhone.Visible = true;
                    }
                   

                }
            }

        }

        protected void checkEmail2FABtn_Click(object sender, EventArgs e)
        {
            int? userId;
            userId = TouristDAO.SelectTouristById(int.Parse(Session["tourist_id"].ToString())).UserId;
            string checkEmail2FA = TouristDAO.checkEmail2FAON(userId);

            if (checkEmail2FA == "False")
            {
                TouristDAO.activateEmail2FA(userId);
                Response.Redirect("security2FA.aspx");


            }
            else
            {
                TouristDAO.deactivateEmail2FA(userId);
                Response.Redirect("security2FA.aspx");

            }


        }

        protected void CheckPhone2FABtn_Click(object sender, EventArgs e)
        {
            int? userId;
            userId = TouristDAO.SelectTouristById(int.Parse(Session["tourist_id"].ToString())).UserId;
            string checkPhone2FA = TouristDAO.checkPhone2FAON(userId);

            if (checkPhone2FA == "False")
            {
                TouristDAO.activatePhone2FA(userId);
                Response.Redirect("security2FA.aspx");


            }
            else
            {
                TouristDAO.deactivatePhone2FA(userId);
                Response.Redirect("security2FA.aspx");

            }
        }

        protected void authGetCode_Click(object sender, EventArgs e)
        {
            int? userId;
            userId = TouristDAO.SelectTouristById(int.Parse(Session["tourist_id"].ToString())).UserId;

            //int? getID = int.Parse((Session["tourist_id"].ToString()));
            string getEmail = TouristDAO.selectEmailbyID(userId);
            string token = Guid.NewGuid().ToString("n").Substring(0, 15);
            DateTime timeGenerated = DateTime.Now.AddMinutes(1);

            TouristDAO.update2FAToken(userId, token, timeGenerated);

            string getToken = TouristDAO.getTokenById(userId);


            Response.Redirect("getAuthCode.aspx?" + "verify2FA=" + getToken);

        }

        protected void clearSession_Click(object sender, EventArgs e)
        {
            Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
            Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);

            Response.Cookies["AuthToken"].Value = string.Empty;
            Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);

            Response.Redirect("Index.aspx");
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

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(phoneTB.Text))
            {
                args.IsValid = false;
            }

            else
            {

            }
        }




        //public static bool UserWithEmailExists(string email)
        //{
        //    SqlConnection myConn = new SqlConnection(DBConnect);

        //    string sqlStmt = "Select * From Users Where email = @paraEmail";

        //    SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
        //    da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

        //    DataSet ds = new DataSet();
        //    da.Fill(ds);

        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        return true;
        //    }

        //    return false;
        //}






    }
}