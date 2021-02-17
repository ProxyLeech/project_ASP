using System;
using System.Collections.Generic;
using System.Linq;
using TouristHelp.DAL;

using System.Web;

namespace TouristHelp.Models
{
    public class Tours
    {
        public int Id { get; set; }
        public int TourGuide { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string Price { get; set; }

        public Tours(int id, int tourguide, string title, string desc, string details, string price)
        {
            Id = id;
            TourGuide = tourguide;
            Title = title;
            Description = desc;
            Details = details;
            Price = price;
        }
     


    }

    public class TouristBooking
    {
        public int TouristId { get; set; }
        public string Name { get; set; }
        public int TourId { get; set; }
        public string TourTitle { get; set; }
        public string Timing { get; set; }
        public string Status { get; set; }
        public int TourGuideId { get; set; }

        public TouristBooking(int touristid, string name, int tourid, string title, string timing, string status, int tourguideid)
        {
            TouristId = touristid;
            Name = name;
            TourId = tourid;
            TourTitle = title;
            Timing = timing;
            Status = status;
            TourGuideId = tourguideid;
        }







        public TouristBooking(int touristid, string name, string title, string timing, string status, int tourguideid)
        {
            TouristId = touristid;
            Name = name;
            TourTitle = title;
            Timing = timing;
            Status = status;
            TourGuideId = tourguideid;
        }



        public TouristBooking(int id, string status)
        {
            TourId = id;
            Status = status;
        }

        public static List<TouristBooking> GetAllToursOfTourist(int id)
        {
            return TouristBookingDAO.SelectTourByTouristId(id);
        }

        public static List<TouristBooking> GetAllTourBookingsOfTourGuide(int id)
        {
            return TouristBookingDAO.SelectTourByTourGuideId(id);
        }

        public static void UpdateTourGuideBooking(TouristBooking tg)
        {
            TouristBookingDAO.UpdateTourBooking(tg);
        }
    }
}