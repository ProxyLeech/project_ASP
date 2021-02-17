using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.BLL;
using System.Drawing;
using System.IO;

namespace TouristHelp
{
    public partial class AdminPageShop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPageRewardSystem.aspx");

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

        protected void BtnAdd_Click(object sender, EventArgs e)
        {

            int voucherQty;
            string voucherType;
            string voucherStatus;
            bool membershipCategory;
            bool foodCategory;
            string nameFilter;
            int voucherPrice = 0;
            string attImage = LbImage.Text;
            string shopDesc;
            string voucherName;
            int voucherPopularity = 0;

            if (TbVoucherStock.Text != "" && TbVoucherType.Text != "" && CBVoucherCategory.SelectedIndex != -1 && TbPrice.Text != "0" && TbName.Text != "")
            {

                voucherQty = Convert.ToInt32(TbVoucherStock.Text);
                voucherType = TbVoucherType.Text;
                voucherStatus = "Available";
                shopDesc = TbVoucherDesc.Text;
                voucherName = TbName.Text;
                nameFilter = "";
                voucherPrice = Convert.ToInt32(TbPrice.Text);

                if (CBVoucherCategory.Items[0].Selected && CBVoucherCategory.Items[1].Selected)
                {
                    membershipCategory = true;
                    foodCategory = true;

                    ShopVoucher shop = new ShopVoucher(voucherQty, voucherType, voucherStatus, membershipCategory, foodCategory, nameFilter, voucherPrice, attImage, shopDesc, voucherName, voucherPopularity);
                    shop.addShopVoucher(shop);
                    Response.Redirect("AdminPageRewardSystem.aspx");

                }


                else if (CBVoucherCategory.Items[0].Selected)
                {
                    foodCategory = false;
                    membershipCategory = true;

                    ShopVoucher shop = new ShopVoucher(voucherQty, voucherType, voucherStatus, membershipCategory, foodCategory, nameFilter, voucherPrice, attImage, shopDesc, voucherName, voucherPopularity);
                    shop.addShopVoucher(shop);
                    Response.Redirect("AdminPageRewardSystem.aspx");
                }

                else if (CBVoucherCategory.Items[1].Selected)
                {
                    foodCategory = true;
                    membershipCategory = false;

                    ShopVoucher shop = new ShopVoucher(voucherQty, voucherType, voucherStatus, membershipCategory, foodCategory, nameFilter, voucherPrice, attImage, shopDesc, voucherName, voucherPopularity);
                    shop.addShopVoucher(shop);
                    Response.Redirect("AdminPageRewardSystem.aspx");
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

                if (TbVoucherStock.Text != "")
                {
                    LblMsgQty.Visible = false;
                    LblMsgQty.Text = "";
                }


                if (TbVoucherType.Text != "")
                {
                    LblMsgVoucherType.Visible = false;
                    LblMsgVoucherType.Text = "";
                }

                if (CBVoucherCategory.SelectedIndex != -1)
                {
                    LblMsgVoucherCategory.Visible = false;
                    LblMsgVoucherType.Text = "";
                }

                if (TbName.Text == "")
                {
                    LblMsgName.Visible = true;
                    LblMsgName.ForeColor = Color.Red;
                    LblMsgName.Text = "Voucher Name cannot be empty" + Environment.NewLine;
                }

                if (TbPrice.Text == "0")
                {

                    LblMsgPrice.Visible = true;
                    LblMsgPrice.ForeColor = Color.Red;
                    LblMsgPrice.Text = "Voucher Price cannot be 0" + Environment.NewLine;
                }

                if (TbVoucherStock.Text == "")
                {
                    LblMsgQty.Visible = true;
                    LblMsgQty.ForeColor = Color.Red;
                    LblMsgQty.Text = "Voucher quantity cannot be empty" + Environment.NewLine;
                }


                if (TbVoucherType.Text == "")
                {
                    LblMsgVoucherType.Visible = true;
                    LblMsgVoucherType.ForeColor = Color.Red;
                    LblMsgVoucherType.Text = "Voucher type cannot be empty" + Environment.NewLine;

                }

                if (CBVoucherCategory.SelectedIndex == -1)
                {
                    LblMsgVoucherCategory.Visible = true;
                    LblMsgVoucherCategory.ForeColor = Color.Red;
                    LblMsgVoucherCategory.Text = "Please select at least one of the voucher category" + Environment.NewLine;
                }

            }






            


        }
    }
}