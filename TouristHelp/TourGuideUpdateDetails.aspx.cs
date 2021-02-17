using System;
using TouristHelp.Models;
using TouristHelp.BLL;
using TouristHelp.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace TouristHelp
{
    public partial class TourGuideUpdateDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TourGuide tg = TourGuideDAO.SelectTourGuideById(int.Parse(Session["tourguide_id"].ToString()));
                tourguidenameTextBox.Text = tg.Name;
                tourguidedescriptionTextBox.Text = tg.Description;
                tourguidelanguagesTextBox.Text = tg.Languages;
                tourguidecredentialsTextBox.Text = tg.Credentials;
                tourguideemailLabel.Text = tg.Email;
                tourguideidLabel.Text = tg.TourGuideId.ToString();
                tourguideuseridLabel.Text = tg.UserId.ToString();
                tourguidepasswordLabel.Text = tg.Password.ToString();


            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string tourguideImage = LbImage.Text;

            TourGuide tg = new TourGuide(int.Parse(tourguideidLabel.Text), int.Parse(tourguideuseridLabel.Text), tourguidenameTextBox.Text, tourguideemailLabel.Text, tourguidepasswordLabel.Text, tourguidedescriptionTextBox.Text, tourguidelanguagesTextBox.Text, tourguidecredentialsTextBox.Text, tourguideImage);
            TourGuide.UpdateTourGuide(tg);


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

    }
}