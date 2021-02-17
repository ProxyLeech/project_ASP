using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristHelp.DAL;

namespace TouristHelp.BLL
{
    public class Attraction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public string DateTime { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Interest { get; set; }
        public string Type { get; set; }
        public string Transaction { get; set; }

        public Attraction()
        {
        }

        public Attraction(string name, string image, string price, string date, string desc, string location, decimal latitude, decimal longitude, string interest, string type, string transaction)// for adding
        {
            Name = name;
            Image = image;
            Price = price;
            DateTime = date;
            Description = desc;
            Location = location;
            Latitude = latitude;
            Longitude = longitude;
            Interest = interest;
            Type = type;
            Transaction = transaction;
        }

        public Attraction(int id, string name, string image, string price, string date, string desc, string location, decimal latitude, decimal longitude, string interest, string type, string transaction)// for displaying
        {
            Id = id;
            Name = name;
            Image = image;
            Price = price;
            DateTime = date;
            Description = desc;
            Location = location;
            Latitude = latitude;
            Longitude = longitude;
            Interest = interest;
            Type = type;
            Transaction = transaction;
        }

        public Attraction GetAttractionDataById(string attId)
        {
            AttractionDAO dao = new AttractionDAO();
            return dao.SelectById(attId);
        }

        //
        public List<Attraction> ListAttractionAll()// un-filter, popular arrange
        {
            AttractionDAO dao = new AttractionDAO();
            return dao.SelectAll();
        }

        public List<Attraction> ListAttraction(string type)// filtered, popular arrange
        {
            AttractionDAO dao = new AttractionDAO();
            return dao.SelectByType(type);
        }

        ///////// breaker /////////

        public List<Attraction> ListAttractionAll_Personal(string arrange)// un-filter, personal arrange
        {
            AttractionDAO dao = new AttractionDAO();
            return dao.SelectAll_Personal(arrange);
        }

        public List<Attraction> ListAttraction_Personal(string type, string arrange)// filtered, personal arrange
        {
            AttractionDAO dao = new AttractionDAO();
            return dao.SelectByType_Personal(type, arrange);
        }

        //

        public void AddAttraction(Attraction att)
        {
            AttractionDAO attDao = new AttractionDAO();
            attDao.InsertNewAttraction(att);
        }

        public void UpdateAttraction(Attraction att)
        {
            AttractionDAO attDao = new AttractionDAO();
            attDao.UpdateAttraction(att);
        }

    }
}