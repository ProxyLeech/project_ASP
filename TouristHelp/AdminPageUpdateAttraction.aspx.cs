using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;

namespace TouristHelp
{
    public partial class AdminPageUpdateAttraction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["AttractionId"] != null)
                {
                    string attractId = Session["AttractionId"].ToString();

                    // Retrieve TDMaster records by Id
                    Attraction td = new Attraction();
                    td = td.GetAttractionDataById(attractId);

                    LbImage.Text = td.Image;
                    Image1.ImageUrl = td.Image;
                    TbName.Text = td.Name;
                    TbDesc.Text = td.Description;
                    TbPrice.Text = td.Price;
                    TbLocation.Text = td.Location;
                    TbDate.Text = td.DateTime;
                    TbLat.Text = td.Latitude.ToString();
                    TbLong.Text = td.Longitude.ToString();
                    DdlInterest.SelectedValue = td.Interest;
                    DdlType.SelectedValue = td.Type;
                    DdlTran.SelectedValue = td.Transaction;
                }
                else
                {
                    Response.Redirect("AdminPageAddAttraction.aspx");
                }
            }
        }

        protected void UploadFile(object sender, EventArgs e)
        {
            string folderPath = Server.MapPath("~/Images/");

            //save file name to invisible label
            LbImage.Text = "Images/" + FileUpload1.FileName;

            //Save the file to dictionary (Folder)
            FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName).ToString());

            //Display the Picture in Image Control
            Image1.ImageUrl = "~/Images/" + Path.GetFileName(FileUpload1.FileName).ToString();

        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string attImage = LbImage.Text;
            Attraction att = new Attraction(int.Parse(Session["AttractionId"].ToString()), TbName.Text, attImage, TbPrice.Text, TbDate.Text, TbDesc.Text, TbLocation.Text, decimal.Parse(TbLat.Text), decimal.Parse(TbLong.Text), DdlInterest.SelectedValue, DdlType.SelectedValue, DdlTran.SelectedValue);
            att.UpdateAttraction(att);
            Logs log = new Logs("Admin", "Maintenance", "Admin successfully updated an attraction", DateTime.Now);
            log.AddLogs(log);
            Response.Redirect("AdminPageAddAttraction.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPageAddAttraction.aspx");
        }
    }
}