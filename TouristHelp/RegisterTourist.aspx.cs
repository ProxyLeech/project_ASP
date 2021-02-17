using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI.WebControls;
using TouristHelp.DAL;
using TouristHelp.BLL;
using TouristHelp.Models;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace TouristHelp
{
    public partial class RegisterTourist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ddlNation.DataSource = CountryList();
                ddlNation.DataBind();
                ddlNation.Items.Insert(0, "-- Select --");
            }
        }

        protected void btnSignupTourist_Click(object sender, EventArgs e)
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
                    btnSignupTourist.Enabled = false;
                }
                else
                {
                    string finalHash;
                    string salt;
                    byte[] Key;
                    byte[] IV;

                    string name = tbNameTourist.Text;
                    string email = tbEmailTourist.Text.ToLower();
                    string pass1 = tbPasswordTourist.Text;
                    string pass2 = tbRepeatPassTourist.Text;
                    string nation = ddlNation.SelectedValue;
                    if (pass1 == pass2 && name != "" && email != "" && pass1 != "" && nation != "-- Select --")
                    {
                        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                        byte[] saltByte = new byte[8];
                        rng.GetBytes(saltByte);
                        salt = Convert.ToBase64String(saltByte);

                        SHA512Managed hashing = new SHA512Managed();
                        string pwdWithSalt = pass1 + salt;
                        byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));
                        finalHash = Convert.ToBase64String(hashWithSalt);

                        Tourist obj = new Tourist(name, email, finalHash, salt, nation);
                        TouristDAO.InsertTourist(obj);

                        PasswordHistory PH = new PasswordHistory(email, finalHash, salt, DateTime.Now);
                        PH.insertPasswordHistory(); 

                        //audit log
                        Tourist user = TouristDAO.SelectTouristByEmail(email);
                        Logs log = new Logs(user.UserId.ToString(), "Login", "User successfully registered as tourist", DateTime.Now);
                        log.AddLogs(log);

                        



                        //Michaels Reward insert table stuff (dont touch)
                        int id = Convert.ToInt32(TouristDAO.SelectTouristByEmail(email).UserId);

                        int logincount = 0;
                        int loginstreak = 0;
                        string loyaltytier = "none";
                        int totaldiscount = 0;
                        int bonuscredits = 10;
                        string membershiptier = "normal";
                        int creditbalance = 0;
                        int remainbonusdays = 10;
                        bool loggedInLog = false;
                        DateTime loggedInDate = DateTime.Now;
                        bool newDateCheck = true;

                        Reward insertReward = new Reward(id, logincount, loginstreak, loyaltytier, totaldiscount, bonuscredits, membershiptier, creditbalance, remainbonusdays, loggedInLog, loggedInDate, newDateCheck);

                        insertReward.insertNewReward();




                        Session["touristEmail"] = email;


                        Response.Redirect("RegisterEmailVerify.aspx");


                    }
                }
                
            }
        }

        protected void CustomValidatorEmailExists_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string pattern = "^[a-zA-Z0-9@.]*$";
            if (UserDAO.UserWithEmailExists(args.Value.ToLower()) && Regex.IsMatch(tbPasswordTourist.Text, pattern))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        private static List<string> CountryList()
        {
            List<string> list = new List<string>();

            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo getCulture in getCultureInfo)
            {
                RegionInfo regionInfo = new RegionInfo(getCulture.LCID);
                if (!(list.Contains(regionInfo.EnglishName)))
                {
                    list.Add(regionInfo.EnglishName);
                }
            }

            list.Sort();
            return list;
        }

        protected void CustomValidatorPasswordLength_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //string patternPassword = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,24}$";
            //if (!Regex.IsMatch(tbPasswordTourist.Text, patternPassword))
            if(tbPasswordTourist.Text.Length >= 8 && tbPasswordTourist.Text.Length <= 24)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidatorPasswordUpper_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string input = tbPasswordTourist.Text;
            bool confirmed = false;
            foreach(char var in input)
            {
                if(var.ToString() == char.ToUpper(var).ToString())
                {
                    confirmed = true;
                    break;
                }
            }
            if (confirmed)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidatorPasswordSpecial_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string input = tbPasswordTourist.Text;  
            char[] chars = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')' };
            //string specialCharacters = ["\", "!", "#", "$", "%", "&", "/", "(", ")", "=", "?", "»", "«", "@", "£", "€", "{", "}", ".", "-", ";", "'", "<", ">", "_", ","];
            if (input.IndexOfAny(chars) >= 0)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void CustomValidatorPasswordHistory_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string input = tbPasswordTourist.Text;
            char[] chars = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            //string specialCharacters = ["\", "!", "#", "$", "%", "&", "/", "(", ")", "=", "?", "»", "«", "@", "£", "€", "{", "}", ".", "-", ";", "'", "<", ">", "_", ","];
            if (input.IndexOfAny(chars) >= 0)
            {
                args.IsValid = true;
            }
            else
            {
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