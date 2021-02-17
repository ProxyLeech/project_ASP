using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System;
using System.Data.SqlClient;
using TouristHelp.Models;

namespace TouristHelp.DAL
{
    public static class ToursDAO
    {
        private static string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public static List<Tours> SelectAllTours()
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select * From Tours";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Tours> arr = new List<Tours>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int id = int.Parse(row["id"].ToString());
                int tg = int.Parse(row["tourguide_id"].ToString());
                string title = row["title"].ToString();
                string desc = row["description"].ToString();
                string details = row["details"].ToString();
                string price = row["price"].ToString();
                Tours obj = new Tours(id, tg, title, desc, details, price);
                arr.Add(obj);
            }
            return arr;
        }


        public static Tours SelectTourByTourGuideId(int id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select Tours.Id, Tours.tourguide_id, Tours.title, Tours.description, Tours.details, Tours.price " +
                "From Tours " +
                "Inner Join TourGuides On Tours.Id = TourGuides.user_id Where Tours.tourguide_id = @paraId";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id.ToString());

            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int tourguide_id = int.Parse(row["tourguide_id"].ToString());
                string title = row["title"].ToString();
                string desc = row["description"].ToString();
                string details = row["details"].ToString();
                string price = row["price"].ToString();
                Tours obj = new Tours(id, tourguide_id, title, desc, details, price);
                return obj;
            }
            else
            {
                return null;
            }
        }

        public static void InsertTour(int Id, int TouristId, string Title, string Description, string Details, string Price)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO Tours (Id, tourguide_id, title, " +
                        "description, details, price) " +
                 "VALUES (@paraId, @paraTourGuideId,@paraTourTitle, @paraTourDescription," +
                        "@paraTourDetails, @paraTourPrice)";



            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraId", Id);
            sqlCmd.Parameters.AddWithValue("@paraTourGuideId", TouristId);
            sqlCmd.Parameters.AddWithValue("@paraTourTitle", Title);
            sqlCmd.Parameters.AddWithValue("@paraTourDescription", Description);
            sqlCmd.Parameters.AddWithValue("@paraTourDetails", Details);
            sqlCmd.Parameters.AddWithValue("@paraTourPrice", Price);



            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            myConn.Close();
        }

    }

    public static class TouristBookingDAO
    {
      


        public static List<TouristBooking> SelectTourByTouristId(int id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * from TouristBooking where tourist_id = @paraId";


            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<TouristBooking> personalTourList = new List<TouristBooking>();
            int rec_cnt = ds.Tables[0].Rows.Count;


            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int tourist_id = int.Parse(row["tourist_id"].ToString());
                string name = row["name"].ToString();
                int tour_id = int.Parse(row["tour_id"].ToString());
                string tourtitle = row["tourtitle"].ToString();
                string timing = row["timing"].ToString();
                string status = row["status"].ToString();
                int tourguide_id = int.Parse(row["tourguide_id"].ToString());

                TouristBooking obj = new TouristBooking(tourist_id, name, tour_id, tourtitle, timing, status, tourguide_id);
                personalTourList.Add(obj);
            }
            return personalTourList;
        }



        public static List<TouristBooking> SelectTourByTourGuideId(int id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * from TouristBooking where tourguide_id = @paraId and status = '-'";


            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<TouristBooking> personalTourList = new List<TouristBooking>();
            int rec_cnt = ds.Tables[0].Rows.Count;


            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int tourist_id = int.Parse(row["tourist_id"].ToString());
                string name = row["name"].ToString();
                int tour_id = int.Parse(row["tour_id"].ToString());
                string tourtitle = row["tourtitle"].ToString();
                string timing = row["timing"].ToString();
                string status = row["status"].ToString();
                int tourguide_id = int.Parse(row["tourguide_id"].ToString());


                TouristBooking obj = new TouristBooking(tourist_id, name, tour_id, tourtitle, timing, status, tourguide_id);
                personalTourList.Add(obj);
            }
            return personalTourList;
        }


        public static void UpdateTourBooking(TouristBooking tg)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Update TouristBooking Set status = @paraStatus Where tour_id = @paraId;"; 

            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);
            cmd.Parameters.AddWithValue("@paraStatus", tg.Status);
            cmd.Parameters.AddWithValue("@paraId", tg.TourId);
            try
            {
                myConn.Open();
                cmd.ExecuteNonQuery();
                myConn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        public static void InsertBooking(TouristBooking tb)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO TouristBooking (tourist_id, name, tourtitle, timing, status, tourguide_id)" +
                             "VALUES (@paraTouristId, @paraName, @paraTourTitle, @paraTiming, @paraStatus, @paraTourGuideId)";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraTouristId", tb.TouristId);
            sqlCmd.Parameters.AddWithValue("@paraName", tb.Name);
            sqlCmd.Parameters.AddWithValue("@paraTourTitle", tb.TourTitle);
            sqlCmd.Parameters.AddWithValue("@paraTiming", tb.Timing);
            sqlCmd.Parameters.AddWithValue("@paraStatus", tb.Status);
            sqlCmd.Parameters.AddWithValue("@paraTourGuideId", tb.TourGuideId);


            myConn.Open();
            sqlCmd.ExecuteNonQuery();
            myConn.Close();
        }
    }
}