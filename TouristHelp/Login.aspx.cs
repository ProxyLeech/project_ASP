using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;
using TouristHelp.DAL;
using TouristHelp.Models;
using System.Web;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;

namespace TouristHelp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

          

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
                else
                {
                    Response.Redirect("Index.aspx");
                }
            }
             


        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string test = Request.Form["g-recaptcha-response"];
            if (Page.IsValid)
            {

                if (!ReCaptchaPassed(Request.Form["g-recaptcha-response"]))
                {
                    string errorMsg = "You have failed the CAPTCHA";
                    ModelState.AddModelError(string.Empty, "You failed the CAPTCHA.");
                    System.Diagnostics.Debug.WriteLine("This is a log");
                    //Response.Redirect("Login.aspx");
                    btnLogin.Enabled = false;
                }

                else
                {
                    if (tbEmail.Text == "admin@touristhelp.com")
                    {
                        Session["admin"] = true;
                        Logs log = new Logs("Admin", "Login", "Admin successfully logged in", DateTime.Now);
                        log.AddLogs(log);
                        Response.Redirect("IndexAdmin.aspx");
                        return;
                    }

                if(tbEmail.Text == "adminaccount@gmail.com")
                {
                    Session["admin"] = true;
                    Logs log = new Logs("Admin", "Login", "Admin successfully logged in", DateTime.Now);
                    log.AddLogs(log);
                    Response.Redirect("IndexAdmin.aspx");
                }

                    try
                    {
                        TourGuide user = TourGuideDAO.SelectTourGuideByEmail(tbEmail.Text);
                        Session["tourguide_id"] = user.TourGuideId.ToString();
                        Logs log = new Logs(user.UserId.ToString(), "Login", "Tourguide successfully logged in", DateTime.Now);
                        log.AddLogs(log);
                    }
                    catch (Exception)
                    {
                        Tourist user = TouristDAO.SelectTouristByEmail(tbEmail.Text);
                        Session["tourist_id"] = user.TouristId.ToString();
                        Logs log = new Logs(user.UserId.ToString(), "Login", "User successfully logged in", DateTime.Now);
                        log.AddLogs(log);
                    }
                    finally
                    {
                        if (Session["tourguide_id"] != null)
                        {
                            Response.Redirect("TourGuideRequestsPage.aspx");
                        }
                        else if (Session["tourist_id"] != null)
                        {


                            //Michaels first login


                            //Response.Redirect("Index.aspx");
                            int? userId;

                            userId = TouristDAO.SelectTouristById(int.Parse(Session["tourist_id"].ToString())).UserId;
                            TouristDAO.firstLoginCheck(userId);

                            //create a new GUID and save into the session
                            string guid = Guid.NewGuid().ToString();
                            Session["AuthToken"] = guid;

                            //now create a new cookie with this guid value
                            Response.Cookies.Add(new HttpCookie("AuthToken", guid));



                            if (TouristDAO.firstLoginCheck(userId) == true)
                            {
                                bool userVerified = UserDAO.GetUserVerification(userId);


                                if (!userVerified)
                                {
                                    HttpCookie userInfo = new HttpCookie("userInfo");
                                    userInfo["email"] = tbEmail.Text;
                                    userInfo.Expires = DateTime.Now.AddMinutes(1);
                                    Response.Cookies.Add(userInfo);

                                    Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                                    Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);

                                    Response.Cookies["AuthToken"].Value = string.Empty;
                                    Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);

                                    //Session["email"] = tbEmail.Text;
                                    Response.Redirect("LoginNotVerified.aspx");
                                }

                                else
                                {
                                    TouristDAO.updateFirstLoginCheck(userId);
                                    Response.Redirect("firstLoginPage.aspx");
                                }


                            }

                            // Email 2FA 
                            else if (TouristDAO.Email2FAON(userId) == true)
                            {





                                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);

                                Response.Cookies["AuthToken"].Value = string.Empty;
                                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);

                                string res = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 8);

                                string email = tbEmail.Text;

                                string get_unique_string(int string_length)
                                {
                                    using (var rng = new RNGCryptoServiceProvider())
                                    {
                                        var bit_count = (string_length * 6);
                                        var byte_count = ((bit_count + 7) / 8); // rounded up
                                        var bytes = new byte[byte_count];
                                        rng.GetBytes(bytes);
                                        return Convert.ToBase64String(bytes);
                                    }
                                }
                                string emailCode = Guid.NewGuid().ToString("n").Substring(0, 8);
                                //string token = get_unique_string(50);
                                string token = Guid.NewGuid().ToString("n").Substring(0, 15);

                                string fromEmail = Environment.GetEnvironmentVariable("FROM_EMAIL_SMTP");
                                string networkCredentialEmail = Environment.GetEnvironmentVariable("NETWORK_CREDENTIAL_EMAIL");
                                string networkCredentialPass = Environment.GetEnvironmentVariable("NETWORK_CREDENTIAL_PW");

                                string to = email; //To address    
                                string from = fromEmail; //From address    
                                MailMessage message = new MailMessage(from, to);


                                //replace stringed code with variable code
                                string mailbody = "Here is your one-time code verification for your email " + " - " + emailCode;


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

                                DateTime timeGenerated = DateTime.Now.AddMinutes(1);

                                TouristDAO.updateEmail2FACode(userId, emailCode);

                                TouristDAO.update2FAToken(userId, token, timeGenerated);





                                Session["emailID"] = tbEmail.Text.Trim();


                                Response.Redirect("Email2FA.aspx?" + "verify2FA=" + token);
                            }


                            else if (TouristDAO.Phone2FAON(userId) == true)
                            {


                                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);

                                Response.Cookies["AuthToken"].Value = string.Empty;
                                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);

                                string res = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 8);

                                string email = tbEmail.Text;

                                string get_unique_string(int string_length)
                                {
                                    using (var rng = new RNGCryptoServiceProvider())
                                    {
                                        var bit_count = (string_length * 6);
                                        var byte_count = ((bit_count + 7) / 8); // rounded up
                                        var bytes = new byte[byte_count];
                                        rng.GetBytes(bytes);
                                        return Convert.ToBase64String(bytes);
                                    }
                                }
                                string phoneCode = Guid.NewGuid().ToString("n").Substring(0, 8);


                                string token = Guid.NewGuid().ToString("n").Substring(0, 15);




                                var accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
                                var authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
                                var fromPhoneNumber = Environment.GetEnvironmentVariable("FROM_PHONE_NUMBER");



                                TwilioClient.Init(accountSid, authToken);

                                string phone = TouristDAO.checkPhone(userId);

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

                                Session["emailID"] = tbEmail.Text.Trim();


                                Response.Redirect("Phone2FA.aspx?" + "verify2FA=" + token);
                            }

                            else
                            {





                                Response.Redirect("Index.aspx");
                            }




                        }
                    }

                }






            }
           
        }


        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //var regexValid = new Regex("^[a-zA-Z0-9@]*$");

            //if (regexValid.IsMatch(tbEmail.Text) || regexValid.IsMatch(tbPassword.Text))
            //{
            //    args.IsValid = false;

            //}

            //else
            //{
            //    // code for if user excced allowed login attempts 
            //    Response.Redirect("ErrorPage.aspx");//placeholder
            //    args.IsValid = false;
            //}
        }


        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SHA512Managed hashing = new SHA512Managed();
            string email = tbEmail.Text.ToLower();
            string emailforcheck = tbEmail.Text;
            string password = tbPassword.Text;
            string dbHash = UserDAO.GetDBPasswordHash(email);
            string dbSalt = UserDAO.GetDBPasswordSalt(email);

            string passwordSalt = password + dbSalt;
            byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(passwordSalt));
            string userHash = Convert.ToBase64String(hashWithSalt);

            User test = UserDAO.CheckUserLocked(emailforcheck);

            User user = UserDAO.GetCountInfo(email);
            try
            {
                string logstatus = test.logStatus;

                int count = user.Count;
                DateTime currentdatetime = user.LastLoggedIn;
                DateTime timelocked = user.AccountLockedUntil;
                DateTime timenow = DateTime.Now;
                if (timenow >= timelocked)
                {
                    count = 0;
                    User u = new User((int)user.UserId, user.Name, count, timenow);
                    UserDAO.CounterUpdate(u);
                }

                if (logstatus == "")
                {
                    if (count < 3)
                    {
                        if (dbHash == userHash)
                        {
                            count = 0;
                            currentdatetime = DateTime.Now;
                            User u = new User((int)user.UserId, user.Name, count, user.AccountLockedUntil);
                            UserDAO.CounterUpdate(u);

                            User uwu = new User((int)user.UserId, currentdatetime);
                            UserDAO.UpdateUserLastLogin(uwu);
                            args.IsValid = true;
                        }
                        else //if password wrong
                        {
                            count = count + 1;
                            timelocked = timenow.AddMinutes(1.25);
                            User u = new User((int)user.UserId, user.Name, count, timelocked);
                            UserDAO.CounterUpdate(u);
                            Logs log = new Logs(user.UserId.ToString(), "Login", "User failed log in", DateTime.Now);
                            log.AddLogs(log);
                            if (count >= 3)
                            {
                                log = new Logs(user.UserId.ToString(), "Login", "User account has been locked", DateTime.Now);
                                log.AddLogs(log);
                            }
                            args.IsValid = false;
                        }
                    }
                    else
                    {
                        // code for if user excced allowed login attempts 
                        labelAccountLocked.Text = "Account has been temporarily locked. Try again later.";
                        args.IsValid = false;
                    }


                }



                else {
                    labelAccountLocked.Text = "Account has been locked.";
                    args.IsValid = false;
                }
            }

            catch (NullReferenceException)
            {
                // no or wrong email is input (try to get their ip)
                Logs log = new Logs("No Target", "Login", "An incorrect or missing email was input", DateTime.Now);
                log.AddLogs(log);
                args.IsValid = false;
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