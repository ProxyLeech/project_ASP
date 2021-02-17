using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace TouristHelp
{
    public partial class SendMailToTourGuide : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtTo.Text = (string)Session["SSEmail"];

        }

        protected void Sendbtn_Click(object sender, EventArgs e)
        {
            

          
        }
    }
}