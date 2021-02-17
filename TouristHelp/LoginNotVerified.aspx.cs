using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using TouristHelp.BLL;
using TouristHelp.DAL;

namespace TouristHelp
{
    public partial class LoginNotVerified : System.Web.UI.Page
    {
        string email;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userInfo = Request.Cookies["userInfo"];
            email = userInfo["email"];
            //email = Session["email"].ToString();
            EmailVerification obj = new EmailVerification();
            bool existingCode = obj.VerifyVerification(email);
            if (existingCode)
            {
                lblMessage.Text = "You have an existing email verification, click on the button below to get a new link!";
            }

            //    EmailVerification current = new EmailVerification();
            //bool confirmedCode = current.GetVerificationCode(code);
            //DateTime codeExpiry = current.GetExpiry(code);
        }

        protected void btnResendEmail_Click(object sender, EventArgs e)
        {
            string fromEmail = Environment.GetEnvironmentVariable("FROM_EMAIL_SMTP");
            string networkCredentialEmail = Environment.GetEnvironmentVariable("NETWORK_CREDENTIAL_EMAIL");
            string networkCredentialPass = Environment.GetEnvironmentVariable("NETWORK_CREDENTIAL_PW");

            //use code generator here, put into email
            string code = generateUniqueCode();
            string url = "https://localhost:44385/RegisterEmailConfirm.aspx?confirm=" + code;
            //string urlCode = "<a href="+url+"></a>";
            string urlCode = "<a href= \"localhost:44385/RegisterEmailConfirm.aspx?confirm=\" ></a>";

            //send email here
            string to = email; //To address    
            string from = fromEmail; //From address    
            MailMessage message = new MailMessage(from, to);


            //replace stringed code with variable code
            string mailbody = "Click the following link to verify your account" + " - " + url;


            message.Subject = "TouristHelp - Email Verification";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(networkCredentialEmail, networkCredentialPass);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }






            //string to = email; //To address    
            //string from = fromEmail; //From address    
            //MailMessage message = new MailMessage(from, to);


            ////replace stringed code with variable code
            //string mailbody = "Here is your one-time code verification for your email " + " - " + emailCode;


            //message.Subject = "TouristHelp - Email Verification";
            //message.Body = mailbody;
            //message.BodyEncoding = Encoding.UTF8;
            //message.IsBodyHtml = true;
            //SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            //System.Net.NetworkCredential basicCredential1 = new
            //System.Net.NetworkCredential(networkCredentialEmail, networkCredentialPass);
            //client.EnableSsl = true;
            //client.UseDefaultCredentials = false;
            //client.Credentials = basicCredential1;
            //try
            //{
            //    client.Send(message);
            //}

            //catch (Exception ex)
            //{
            //    throw ex;
            //}


            EmailVerification obj = new EmailVerification();
            obj.ExpireCodeByEmail(email);

            //use query string so that email confirm can read the code
            bool expire = false;
            DateTime timeGenerated = DateTime.Now;
            EmailVerification emailVerification = new EmailVerification(code, email, expire, timeGenerated);
            emailVerification.InsertVerificationCode();

            lblMessageHeader.Text = "Email Sent!";
            lblMessage.Text = "Email has been sent to you, click on the link to verify your account";
            btnResendEmail.Visible = false;

            Response.Cookies["userInfo"].Value = string.Empty;
            Response.Cookies["userInfo"].Expires = DateTime.Now.AddMonths(-20);
        }

        protected string generateUniqueCode()
        {
            string code = "";
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = alphabets + small_alphabets + numbers;

            int length = 10;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                }
                while (code.IndexOf(character) != -1);
                code += character;
            }
            return code;
        }
    }
}