using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using TouristHelp.DAL;
using TouristHelp.BLL;
using TouristHelp.Models;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace TouristHelp
{
    public partial class ForgotPasswordPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(DBConnect))
            {
                SqlCommand cmd = new SqlCommand("spResetPassword", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramUsername = new SqlParameter("@Email", tbEmailUser.Text);

                cmd.Parameters.Add(paramUsername);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                var regexitem = new Regex("^[a-zA-Z0-9@.]*$");

                if (!ReCaptchaPassed(Request.Form["g-recaptcha-response"]))
                {
                    string errorMsg = "You have failed the CAPTCHA";
                    ModelState.AddModelError(string.Empty, "You failed the CAPTCHA.");
                    System.Diagnostics.Debug.WriteLine("This is a log");
                    //Response.Redirect("Login.aspx");
                    btnResetPassword.Enabled = false;
                }


                if (regexitem.IsMatch(tbEmailUser.Text))
                {
                    while (rdr.Read())
                    {
                        SendPasswordResetEmail(tbEmailUser.Text, rdr["UniqueId"].ToString());
                        lblMessage.Text = "An email has been sent to the provided account.";
                        illegalCharLabel.Text = "";
                        btnResetPassword.Enabled = false;
                        Session["UserEmailChange"] = tbEmailUser.Text;
                    }
                }
                else
                {
                    illegalCharLabel.Text = "Illegal characters found, please try again.";
                }
            }

        }

        private void SendPasswordResetEmail(string ToEmail, string UniqueId)
        {

            string getEmailCredentials = Environment.GetEnvironmentVariable("NETWORK_CREDENTIAL_EMAIL");
            string getPWCredentials = Environment.GetEnvironmentVariable("NETWORK_CREDENTIAL_PW");

            // MailMessage class is present is System.Net.Mail namespace
            MailMessage mailMessage = new MailMessage("YourEmail@gmail.com", ToEmail);


            // StringBuilder class is present in System.Text namespace
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Please click on the following link to reset your password");
            sbEmailBody.Append("<br/>"); sbEmailBody.Append("https://localhost:44385/ResetPasswordPage.aspx?uid=" + UniqueId);
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<b>TouristHelp</b>");

            mailMessage.IsBodyHtml = true;

            mailMessage.Body = sbEmailBody.ToString();
            mailMessage.Subject = "Reset Your Password";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = getEmailCredentials,
                Password = getPWCredentials
            };

            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);

            
            

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