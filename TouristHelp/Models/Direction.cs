using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TouristHelp.Models
{
    public class Direction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public Direction(int id, string name, decimal price, string desc, string location, string type)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = desc;
            Location = location;
            Type = type;
        }
    }
    public class GeoJson
    {
        public string type { get; set; }
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }

        public GeoJson(string title, string desc, double lat, double longitude)
        {
            type = "Feature";
            properties = new Properties(title, desc);
            geometry = new Geometry(lat, longitude, "Point");
        }
    }

    public class Properties
    {
        public string title { get; set; }
        public string description { get; set; }
        public Properties(string title, string desc)
        {
            this.title = title;
            description = desc;
        }
    }
    public class Geometry
    {
        public double[] coordinates { get; set; }
        public string type { get; set; }

        public Geometry(double latitude, double longitude, string type)
        {
            coordinates = new double[] { longitude, latitude };
            this.type = type;
        }
    }
}