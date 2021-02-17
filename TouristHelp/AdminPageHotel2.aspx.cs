using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;
using System.Drawing;


namespace TouristHelp
{
    public partial class AdminPageHotel2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(regionSelect.SelectedItem.Value);


        }


        protected void BtnAdd_Click(object sender, EventArgs e)
        {

            decimal hotelPrice = 0;
            //string hotelImage = "Images/" + FileUpload1.FileName;

            string attImage = LbImage.Text;
            bool centralFilter;
            bool northFilter;
            bool southFilter;
            bool westFilter;
            bool eastFilter;
            string hotelName = TbName.Text;

            if (regionSelect.SelectedItem.Value == "Central")
            {


                if (TbName.Text != "" && TbPrice.Text != "0" && regionSelect.SelectedItem.Value != "Region")
                {
                    hotelPrice = Convert.ToDecimal(TbPrice.Text);
                    northFilter = false;
                    centralFilter = true;
                    southFilter = false;
                    westFilter = false;
                    eastFilter = false;

                    HotelBook addHotel = new HotelBook(hotelPrice, attImage, centralFilter, northFilter, southFilter, westFilter, eastFilter, hotelName);
                    addHotel.addHotel(addHotel);
                    Response.Redirect("AdminPageHotel.aspx");





                }



            }
            if (regionSelect.SelectedItem.Value == "North")
            {
               

                if (TbName.Text != "" && TbPrice.Text != "0" && regionSelect.SelectedItem.Value != "Region")
                {
                    hotelPrice = Convert.ToDecimal(TbPrice.Text);
                    northFilter = true;
                    centralFilter = false;
                    southFilter = false;
                    westFilter = false;
                    eastFilter = false;

                    HotelBook addHotel = new HotelBook(hotelPrice, attImage, centralFilter, northFilter, southFilter, westFilter, eastFilter, hotelName);
                    addHotel.addHotel(addHotel);
                    Response.Redirect("AdminPageHotel.aspx");





                }
               
            }
            if (regionSelect.SelectedItem.Value == "South")
            {
               



                if (TbName.Text != "" && TbPrice.Text != "0" && regionSelect.SelectedItem.Value != "Region")
                {
                    hotelPrice = Convert.ToDecimal(TbPrice.Text);

                    southFilter = true;
                    northFilter = false;
                    centralFilter = false;
                    westFilter = false;
                    eastFilter = false;

                    HotelBook addHotel = new HotelBook(hotelPrice, attImage, centralFilter, northFilter, southFilter, westFilter, eastFilter, hotelName);
                    addHotel.addHotel(addHotel);
                    Response.Redirect("AdminPageHotel.aspx");








                }
                
            }
             if (regionSelect.SelectedItem.Value == "West")
            {
           

                if (TbName.Text != "" && TbPrice.Text != "0" && regionSelect.SelectedItem.Value != "Region")
                {
                    hotelPrice = Convert.ToDecimal(TbPrice.Text);

                    westFilter = true;
                    southFilter = false;
                    northFilter = false;
                    centralFilter = false;
                    eastFilter = false;

                    HotelBook addHotel = new HotelBook(hotelPrice, attImage, centralFilter, northFilter, southFilter, westFilter, eastFilter, hotelName);
                    addHotel.addHotel(addHotel);
                    Response.Redirect("AdminPageHotel.aspx");

                    

                }
               

            }
            if (regionSelect.SelectedItem.Value == "East")
            {
                
                

                if (TbName.Text != "" && TbPrice.Text != "0" && regionSelect.SelectedItem.Value != "Region")
                {
                    hotelPrice = Convert.ToDecimal(TbPrice.Text);

                    eastFilter = true;
                    westFilter = false;
                    southFilter = false;
                    northFilter = false;
                    centralFilter = false;

                    HotelBook addHotel = new HotelBook(hotelPrice, attImage, centralFilter, northFilter, southFilter, westFilter, eastFilter, hotelName);
                    addHotel.addHotel(addHotel);
                    Response.Redirect("AdminPageHotel.aspx");




                }
              
            }

            else
            {

                if (TbName.Text != "")
                {
                    LblMsgName.Visible = false;
                    LblMsgName.Text = "";
                }

                if (TbPrice.Text != "0")
                {

                    LblMsgPrice.Visible = false;
                    LblMsgPrice.Text = "";
                }

                if (regionSelect.SelectedItem.Value != "Region")
                {
                    LblMsgRegion.Visible = false;
                    LblMsgRegion.Text = "" ;
                }

                if (TbName.Text == "")
                {
                    LblMsgName.Visible = true;
                    LblMsgName.ForeColor = Color.Red;
                    LblMsgName.Text = "Hotel Name cannot be empty" + Environment.NewLine ;
                }

                 if (TbPrice.Text == "0")
                {

                    LblMsgPrice.Visible = true;
                    LblMsgPrice.ForeColor = Color.Red;
                    LblMsgPrice.Text = "Hotel Price cannot be 0" + Environment.NewLine;
                }

                  if (regionSelect.SelectedItem.Value == "Region")
                {
                    LblMsgRegion.Visible = true;
                    LblMsgRegion.ForeColor = Color.Red;
                    LblMsgRegion.Text = "Please select a region" + Environment.NewLine;
                }
               
            }


           
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPageHotel.aspx");
        }

        protected void UploadFile(object sender, EventArgs e)
        {


            //string folderPath = Server.MapPath("~/Images/");

            ////Save the file to dictionary (Folder)
            //FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName).ToString());

            ////Display the Picture in Image Control

            //Image1.ImageUrl = "~/Images/" + Path.GetFileName(FileUpload1.FileName).ToString();



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