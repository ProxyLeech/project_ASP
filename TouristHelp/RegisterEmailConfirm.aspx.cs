using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;
using TouristHelp.DAL;

namespace TouristHelp
{
    public partial class RegisterEmailConfirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string code = Request.QueryString["confirm"];
            EmailVerification current = new EmailVerification();
            bool confirmedCode = current.GetVerificationCode(code);
            DateTime codeExpiry = current.GetExpiry(code);

            if(confirmedCode == true)
            {
                if (codeExpiry.AddMinutes(1) < DateTime.Now)
                {
                    confirmedCode = false;
                    current.UpdateExpireCode(code);
                    lblMessageHeader.Text = "Verification Failed!";
                    lblMessage.Text = "Your code is invalid or has expired. Try logging in again to resend a new link";
                }
                else
                {
                    string currentEmail = current.GetEmail(code);
                    current.UpdateConfirmVerification(code);

                    UserDAO.UpdateEmailVerification(currentEmail);

                    //change user verify to true
                }

            }
            else
            {
                lblMessageHeader.Text = "Verification Failed!";
                lblMessage.Text = "Your code is invalid or has expired. Try logging in again to resend a new link";
                //change text on page to invalid code or expired code
            }
            //receive the email

        }

        protected void btnRedirLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}