using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristHelp.DAL;
using TouristHelp.BLL;

namespace TouristHelp.BLL
{
    public class HotelBook
    {
        public int hotelId { get; set; }
        public decimal hotelPrice { get; set; }
        public string hotelImage { get; set; }
        public bool centralFilter { get; set; }
        public bool northFilter { get; set; }
        public bool southFilter { get; set; }
        public bool westFilter { get; set; }
        public bool eastFilter { get; set; }
        public string hotelName { get; set; }
        public int minPriceFilter { get; set; }
        public int maxPriceFilter { get; set; }

        public HotelBook()
        {
        }

        public HotelBook(int hotelid, decimal hotelprice, string hotelimage, bool centralfilter, bool northfilter, bool southfilter, bool westfilter, bool eastfilter, string hotelname  )
        {
            this.hotelId = hotelid;
            this.hotelPrice = hotelprice;
            this.hotelImage = hotelimage;
            this.centralFilter = centralfilter;
            this.northFilter = northfilter;
            this.southFilter = southfilter;
            this.westFilter = westfilter;
            this.eastFilter = eastfilter;
            this.hotelName = hotelname;
          
        }
        public HotelBook(int minpricefilter, int maxpricefilter)
        {
            this.minPriceFilter = minpricefilter;
            this.maxPriceFilter = maxpricefilter;
        }

        public HotelBook(decimal hotelprice, string hotelimage, bool centralfilter, bool northfilter, bool southfilter, bool westfilter, bool eastfilter, string hotelname)
        {
            this.hotelPrice = hotelprice;
            this.hotelImage = hotelimage;
            this.centralFilter = centralfilter;
            this.northFilter = northfilter;
            this.southFilter = southfilter;
            this.westFilter = westfilter;
            this.eastFilter = eastfilter;
            this.hotelName = hotelname;
        }

        public HotelBook getHotelById(string hotelId)
        {
            HotelBookDAO dao = new HotelBookDAO();
            return dao.selectByHotel(hotelId);


        }

        public List<HotelBook> GetAllHotel()
        {
            HotelBookDAO dao = new HotelBookDAO();
            return dao.SelectAllHotel();
        }


        public List<HotelBook> getCentralHotels()
        {
            HotelBookDAO dao = new HotelBookDAO();
            return dao.getCentralHotels();
        }

        public List<HotelBook> getNorthHotels()
        {
            HotelBookDAO dao = new HotelBookDAO();
            return dao.getNorthHotels();
        }


        public List<HotelBook> getSouthHotels()
        {
            HotelBookDAO dao = new HotelBookDAO();
            return dao.getSouthHotels();
        }

        public List<HotelBook> getWestHotels()
        {
            HotelBookDAO dao = new HotelBookDAO();
            return dao.getWestHotels();
        }

        public List<HotelBook> getEastHotels()
        {
            HotelBookDAO dao = new HotelBookDAO();
            return dao.getEastHotels();
        }


        public List<HotelBook> getHotelsByPrice()
        {
            HotelBookDAO dao = new HotelBookDAO();
            return dao.getHotelsByPrice(minPriceFilter, maxPriceFilter);
        }

        public void addHotel(HotelBook hotel)
        {
            HotelBookDAO attDao = new HotelBookDAO();
            attDao.addNewHotel(hotel);
        }


        public HotelBook getHotelById(int hotelId)
        {
            HotelBookDAO dao = new HotelBookDAO();
            return dao.selectByHotelId(hotelId);


        }
    }
}