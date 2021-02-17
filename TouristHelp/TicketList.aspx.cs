using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;

namespace TouristHelp
{
    public partial class TicketList : System.Web.UI.Page
    {
        List<Ticket> tixList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tourist_id"] == null && Session["tourguide_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            else
            {

                try
                {
                    Label1.Text = Session["tourist_id"].ToString();
                }
                catch (NullReferenceException)
                {
                    Label1.Text = Session["tourguide_id"].ToString();
                }

            }
            if (!Page.IsPostBack)
            {
                int user_id = Convert.ToInt32(Session["tourist_id"]);
                Ticket ticket = new Ticket();
                tixList = ticket.GetAllTicket(user_id);

                Repeater1.DataSource = tixList;
                Repeater1.DataBind();

                List<Ticket> TicketList = new List<Ticket>();
                Ticket tix = new Ticket();
                TicketList = tix.GetAllTicket(user_id);
                if(TicketList == null)
                {
                    Response.Redirect("Guidebook.aspx");
                }
                for(int i = 0; i < TicketList.Count; i++)
                {
                    DateTime currentDate = DateTime.Today;
                    if (TicketList[i].dateExpire < currentDate)
                    {
                        tix.TicketExpire(TicketList[i].ticketId);
                    }
                }
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            RepeaterItem selTix = e.Item;

            Label ticketId = (Label)selTix.FindControl("lbTixId");
            Ticket tix = new Ticket();
            tix = tix.getTicketById(Convert.ToInt32(ticketId.Text));
            string code = tix.ticketCode;
            string url = "TicketDetail.aspx?Code="+code;
            Response.Redirect(url);
        }
    }
}