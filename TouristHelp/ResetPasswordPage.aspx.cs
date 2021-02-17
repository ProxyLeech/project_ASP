using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Security.Cryptography;
using TouristHelp.BLL;
using TouristHelp.DAL;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net;

namespace TouristHelp
{
    public partial class ResetPasswordPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPasswordResetLinkValid())
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Password Reset link has expired or is invalid";
                }
            }
        }






        private bool ExecuteSP(string SPName, List<SqlParameter> SPParameters)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(DBConnect))
            {
                SqlCommand cmd = new SqlCommand(SPName, con);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter parameter in SPParameters)
                {
                    cmd.Parameters.Add(parameter);
                }

                con.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }



        private bool IsPasswordResetLinkValid()
        {
            List<SqlParameter> paramList = new List<SqlParameter>()
    {
        new SqlParameter()
        {
            ParameterName = "@GUID",
            Value = Request.QueryString["uid"]
        }
    };

            return ExecuteSP("spIsPasswordResetLinkValid", paramList);
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
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
                    btnResetPassword.Enabled = false;
                }
                if (ChangeUserPassword())
                {
                    lblMessage.Text = "Password Changed Successfully!";
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Password reset link has expired or is invalid";
                }
            }
        }


        private bool ChangeUserPassword()
        {
            string pass1 = tbNameTG.Text;
            SHA512Managed hashing = new SHA512Managed();

            //plug in the email from SP to here
            string email = (string)Session["UserEmailChange"];

            string dbSalt = UserDAO.GetDBPasswordSalt(email);
            string passwordSalt = pass1 + dbSalt;
            byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(passwordSalt));
            string hash = Convert.ToBase64String(hashWithSalt);

            //clear oldest password
            clearOldestPassword(email);
            //input the new password into history
            PasswordHistory PH = new PasswordHistory(email, hash, dbSalt, DateTime.Now);
            PH.insertPasswordHistory();
            //delete oldest password here if possible
            clearOldestPassword(email);

            List<SqlParameter> paramList = new List<SqlParameter>()
    {
        new SqlParameter()
        {
            ParameterName = "@GUID",
            Value = Request.QueryString["uid"]
        },
        new SqlParameter()
        {
            ParameterName = "@Password",
            Value = hash
        }
    };

            return ExecuteSP("spChangePassword", paramList);
        }







        protected void clearOldestPassword(string email)
        {
            DateTime oldestTime = DateTime.Now;
            string oldestHash = "";
            int count = 0;
            PasswordHistory passHist = new PasswordHistory();
            List<PasswordHistory> pastPasswords = passHist.getAllPasswordByEmail(email);
            List<string> listPass = new List<string>();
            foreach (PasswordHistory entry in pastPasswords)
            {
                count += 1;
                if(entry.timeGenerated < oldestTime)
                {
                    oldestTime = entry.timeGenerated;
                    oldestHash = entry.passwordHash;
                }
            }
            //delete the oldest password here
            if(count == 3)
            {
                passHist.deletePassword(oldestHash);
            }
        }

        protected void CustomValidatorPasswordLength_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (tbEmailTG.Text.Length >= 8 && tbEmailTG.Text.Length <= 24)
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
            string input = tbEmailTG.Text;
            bool confirmed = false;
            foreach (char var in input)
            {
                if (var.ToString() == char.ToUpper(var).ToString())
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
            string input = tbEmailTG.Text;
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
            string input = tbEmailTG.Text;
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


        protected void CustomValidatorCheckHistory_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SHA512Managed hashing = new SHA512Managed();
            string email = (string)Session["UserEmailChange"];
            string passwordInput = tbEmailTG.Text;

            string dbHash = UserDAO.GetDBPasswordHash(email);
            string dbSalt = UserDAO.GetDBPasswordSalt(email);

            PasswordHistory passHist = new PasswordHistory();
            List<PasswordHistory> pastPasswords = passHist.getAllPasswordByEmail(email);
            List<string> listPass = new List<string>();
            foreach (PasswordHistory entry in pastPasswords)
            {
                listPass.Add(entry.passwordHash);
            }
            string passwordSalt = passwordInput + dbSalt;
            byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(passwordSalt));
            string userHash = Convert.ToBase64String(hashWithSalt);
            if (listPass.Contains(userHash))
            {
                    args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
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

        //protected void CustomValidatorPasswordHistory_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    SHA512Managed hashing = new SHA512Managed();
        //    string email = tbEmailTourist.Text;
        //    string passwordInput = tbPasswordTourist.Text;

        //    string dbHash = UserDAO.GetDBPasswordHash(email);
        //    string dbSalt = UserDAO.GetDBPasswordSalt(email);

        //    PasswordHistory passHist = new PasswordHistory();
        //    List<PasswordHistory> pastPasswords = passHist.getAllPasswordByEmail(email);
        //    List<string> listPass = new List<string>();
        //    foreach (PasswordHistory entry in pastPasswords)
        //    {
        //        listPass.Add(entry.passwordHash);
        //    }
        //    string passwordSalt = passwordInput + dbSalt;
        //    byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(passwordSalt));
        //    string userHash = Convert.ToBase64String(hashWithSalt);

        //    if (listPass.Contains(userHash))
        //    {
        //        args.IsValid = false;
        //    }
        //    else
        //    {
        //        args.IsValid = true;
        //    }
        //}
    }
}