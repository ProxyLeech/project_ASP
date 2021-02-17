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

namespace TouristHelp
{
    public partial class getAuthCode : System.Web.UI.Page
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

                    Response.Redirect("Login.aspx");
                }




                string sessionEmail = emailID;

                TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();



                string key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);

                TouristDAO.updateSecretKeyEmail(sessionEmail, key);


                var setupInfo = tfa.GenerateSetupCode("TouristHelp", sessionEmail, key, false, 3);

                string qrCodeImageUrl = setupInfo.QrCodeSetupImageUrl;
                string manualEntrySetupCode = setupInfo.ManualEntryKey;

               
                    imgQRCode.ImageUrl = qrCodeImageUrl;

                
                





            }
        }
    }
}