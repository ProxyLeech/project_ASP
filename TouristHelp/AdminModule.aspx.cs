using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;
using TouristHelp.DAL;
using System.IO;
using TouristHelp.Models;
using System.Net.Mail;
using System.Text;



namespace TouristHelp
{
    public partial class AdminModule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                User user = UserDAO.SelectUserByEmail(tbEmail.Text);
                Session["name"] = user.Name.ToString();
                Session["email"] = user.Email.ToString();
                Session["lastLoggedIn"] = user.LastLoggedIn.ToString();
                Session["user_id"] = user.UserId.ToString();
                TextBoxName.Text = (string)Session["name"];
                TextBoxEmail.Text = (string)Session["email"];
                TextBoxlastloggedin.Text = (string)Session["lastLoggedIn"];
                TextBoxUserId.Text = (string)Session["user_id"];
                lblMessage.Text = "";
            }
            catch
            {
                lblMessage.Text = "No user found with that email.";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            User user = new User(int.Parse(TextBoxUserId.Text), "");
            UserDAO.UpdateUser(user);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            User user = new User(int.Parse(TextBoxUserId.Text), "Locked");
            UserDAO.UpdateUser(user);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SendPasswordResetEmail(tbEmail.Text);
        }

        private void SendPasswordResetEmail(string ToEmail)
        {

            string getEmailCredentials = Environment.GetEnvironmentVariable("NETWORK_CREDENTIAL_EMAIL");
            string getPWCredentials = Environment.GetEnvironmentVariable("NETWORK_CREDENTIAL_PW");


            // MailMessage class is present is System.Net.Mail namespace
            MailMessage mailMessage = new MailMessage("YourEmail@gmail.com", ToEmail);


            // StringBuilder class is present in System.Text namespace
            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Please login within the next week or your account will be locked.");
            sbEmailBody.Append("<br/><br/>");
            sbEmailBody.Append("<b>TouristHelp</b>");

            mailMessage.IsBodyHtml = true;

            mailMessage.Body = sbEmailBody.ToString();
            mailMessage.Subject = "Login to your account";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = getEmailCredentials,
                Password = getPWCredentials
            };

            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);


            


        }
    }
}