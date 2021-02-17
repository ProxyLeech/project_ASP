using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TouristHelp
{
    public partial class RegisterMobileVerify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void emailVerifyBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterEmailVerify.aspx");
        }

        protected void btnRedirLogin_Click(object sender, EventArgs e)
        {

        }
    }
}