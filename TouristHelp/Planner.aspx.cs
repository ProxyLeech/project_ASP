using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using TouristHelp.DAL;
using TouristHelp.Models;
using TouristHelp.BLL;

namespace TouristHelp
{
    public partial class Planner : System.Web.UI.Page
    {
        private List<Direction> places;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tourist_id"] != null)
            {
                LoadData(int.Parse(Session["tourist_id"].ToString()));
                if (!Page.IsPostBack)
                {
                    AttractionDAO attractions = new AttractionDAO();
                    foreach (var i in attractions.SelectAll().OrderBy(a => a.Name).ToList())
                    {
                        DropDownListAttractions.Items.Add(new ListItem(i.Name, i.Id.ToString()));
                    }
                    DropDownListAttractions.DataBind();
                }
            }
            else if (Session["tourguide_id"] != null)
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }







            
        }

        protected void BtnAddAttraction_Click(object sender, EventArgs e)
        {
            DirectionDAO.AddDirToUser(int.Parse(DropDownListAttractions.SelectedValue), int.Parse(Session["tourist_id"].ToString()));
            LoadData(int.Parse(Session["tourist_id"].ToString()));
        }

        private void LoadData(int tourist_id)
        {
            places = DirectionDAO.GetDirByUser(tourist_id);

            if (places.Count == 0)
            {
                lblNoEntry.Visible = true;
                List<Direction> random = DirectionDAO.GetRandomPoI();
                gvDirections.DataSource = random;
                gvDirections.DataBind();
                GeoJsonHidden.Value = JsonConvert.SerializeObject(DirectionDAO.ParseGeoJsonFromList(random));
            }
            else
            {
                lblNoEntry.Visible = false;
                GeoJsonHidden.Value = JsonConvert.SerializeObject(DirectionDAO.GetGeoJsonsByUser(tourist_id));
                gvDirections.DataSource = places;
                gvDirections.DataBind();
                DropDownListSaved.Items.Clear();
                foreach (Direction i in places)
                {
                    DropDownListSaved.Items.Add(i.Name);
                }
                DropDownListSaved.DataBind();
            }
            gvDirections.Visible = true;
        }

        protected void gvDirections_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvDirections.SelectedRow;
            int attraction = int.Parse(row.Cells[0].Text);
            DirectionDAO.RemoveOneDirByUser(attraction, int.Parse(Session["tourist_id"].ToString()));
            LoadData(int.Parse(Session["tourist_id"].ToString()));
        }
    }
}