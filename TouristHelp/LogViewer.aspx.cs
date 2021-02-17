using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;

namespace TouristHelp
{
    public partial class LogViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!Page.IsPostBack)
            {
                Logs log = new Logs();
                LoadRepeater(log.GetAllLogs(true));
            }
        }

        private void LoadRepeater(List<Logs> source)
        {
            RepeaterLog.DataSource = source;
            RepeaterLog.DataBind();
        }

        protected void ButtonFilterExpand_Click(object sender, EventArgs e)
        {
            if (PanelFilter.Visible == false)
            {
                ButtonFilterExpand.Text = "Collapse Filter";
                PanelFilter.Visible = true;
            }
            else
            {
                ButtonFilterExpand.Text = "Expand Filter";
                PanelFilter.Visible = false;
            }
        }

        protected void ButtonFilterSend_Click(object sender, EventArgs e)
        {
            string target = "";
            string type = "";
            DateTime? time1 = null;
            DateTime? time2 = null;
            string key = "";
            bool filter = false;

            // make the filter sql statment
            if (!string.IsNullOrWhiteSpace(TextBoxTarget.Text))
            {
                target = TextBoxTarget.Text;
                filter = true;
            }
            if (DropDownListType.SelectedIndex != 0)
            {
                type = DropDownListType.SelectedValue;
                filter = true;
            }
            if (!string.IsNullOrWhiteSpace(TextBoxKeyword.Text))
            {
                key = TextBoxKeyword.Text;
                filter = true;
            }
            if (!string.IsNullOrWhiteSpace(TextBoxDateTime1.Text) && !string.IsNullOrWhiteSpace(TextBoxDateTime2.Text))
            {
                time1 = DateTime.Parse(TextBoxDateTime1.Text + ":00");
                time2 = DateTime.Parse(TextBoxDateTime2.Text + ":59");
                if (time1 > time2)
                {
                    time1 = DateTime.Parse(TextBoxDateTime2.Text + ":00");
                    time2 = DateTime.Parse(TextBoxDateTime1.Text + ":59");
                }
                filter = true;
            }
            else if (!string.IsNullOrWhiteSpace(TextBoxDateTime1.Text))
            {
                time1 = DateTime.Parse(TextBoxDateTime1.Text + ":00");
                time2 = DateTime.Parse(TextBoxDateTime1.Text + ":59");
                filter = true;
            }
            else if (!string.IsNullOrWhiteSpace(TextBoxDateTime2.Text))
            {
                time1 = DateTime.Parse(TextBoxDateTime2.Text + ":00");
                time2 = DateTime.Parse(TextBoxDateTime2.Text + ":59");
                filter = true;
            }


            //if filter is empty send as getAll or, else send to getFiltered (and check if its earliest/latest first)
            bool newFirst = true;
            if (RadioButtonListOrder.SelectedIndex == 1)
            {
                newFirst = false;
            }
            Logs logs = new Logs();
            if (!filter)
            {
                //getall
                LoadRepeater(logs.GetAllLogs(newFirst));
            }
            else
            {
                //getFiltered
                LoadRepeater(logs.GetFilteredLogs(target, type, time1, time2, key, newFirst));
            }

        }

        protected void ButtonFilterClear_Click(object sender, EventArgs e)
        {
            RadioButtonListOrder.SelectedIndex = 0;
            TextBoxTarget.Text = "";
            DropDownListType.SelectedIndex = 0;
            TextBoxDateTime1.Text = "";
            TextBoxDateTime2.Text = "";
            TextBoxKeyword.Text = "";
            Logs logs = new Logs();
            LoadRepeater(logs.GetAllLogs(true));
        }
    }
}