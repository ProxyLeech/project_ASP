using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TouristHelp.Models;

namespace TouristHelp.DAL
{
    public static class DirectionDAO
    {
        private static string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public static List<Direction> GetRandomPoI() //get all places of interest for random selection
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select attractionId, attractionName, attractionPrice, " +
                "attractionDesc, attractionLocation, attractionType " +
                "From Attraction";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Direction> list = new List<Direction>();
            List<int> arr = new List<int>();
            Random random = new Random();

            int rec_cnt = ds.Tables[0].Rows.Count;
            if(rec_cnt == 0)
            {
                return list;
            }

            for (int i = 0; i < 3; i++)
            {
                int rand = random.Next(rec_cnt);
                if (arr.Contains(rand))
                {
                    i--;
                }
                else
                {
                    arr.Add(rand);
                }
            }

            foreach (int i in arr)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int id = int.Parse(row["attractionId"].ToString());
                string name = row["attractionName"].ToString();
                decimal price = decimal.Parse(row["attractionPrice"].ToString());
                string desc = row["attractionDesc"].ToString();
                string location = row["attractionLocation"].ToString();
                string type = row["attractionType"].ToString();
                Direction obj = new Direction(id, name, price, desc, location, type);
                list.Add(obj);
            }

            return list;
        }

        public static List<GeoJson> ParseGeoJsonFromList(List<Direction> directions) //to be used with random PoI method
        {
            List<int> ids = new List<int>();
            List<GeoJson> geoJsons = new List<GeoJson>();
            if(directions.Count == 0)
            {
                return geoJsons;
            }

            foreach (Direction dir in directions)
            {
                ids.Add(dir.Id);
            }

            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select Attraction.attractionName, Attraction.attractionDesc, Attraction.attractionLatitude, Attraction.attractionLongitude " +
                "From Attraction " +
                "Where attractionId in (@paraOne, @paraTwo, @paraThree)";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraOne", ids[0]);
            da.SelectCommand.Parameters.AddWithValue("@paraTwo", ids[1]);
            da.SelectCommand.Parameters.AddWithValue("@paraThree", ids[2]);

            DataSet ds = new DataSet();
            da.Fill(ds);

            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                string name = row["attractionName"].ToString();
                string desc = row["attractionDesc"].ToString();
                double lat = double.Parse(row["attractionLatitude"].ToString());
                double log = double.Parse(row["attractionLongitude"].ToString());
                GeoJson obj = new GeoJson(name, desc, lat, log);
                geoJsons.Add(obj);
            }
            return geoJsons;
        }

        public static List<Direction> GetDirByUser(int tourist)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select Attraction.attractionId, Attraction.attractionName, Attraction.attractionPrice, " +
                "Attraction.attractionDesc, Attraction.attractionLocation, Attraction.attractionType " +
                "From Directions Inner Join Attraction On Attraction.attractionId = Directions.attraction_id " +
                "Where tourist_id = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", tourist);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Direction> list = new List<Direction>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int id = int.Parse(row["attractionId"].ToString());
                string name = row["attractionName"].ToString();
                decimal price = decimal.Parse(row["attractionPrice"].ToString());
                string desc = row["attractionDesc"].ToString();
                string location = row["attractionLocation"].ToString();
                string type = row["attractionType"].ToString();
                Direction obj = new Direction(id, name, price, desc, location, type);
                list.Add(obj);
            }

            return list;
        }

        public static List<GeoJson> GetGeoJsonsByUser(int tourist)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select Attraction.attractionName, Attraction.attractionDesc, Attraction.attractionLatitude, Attraction.attractionLongitude " +
                "From Directions Inner Join Attraction On Attraction.attractionId = Directions.attraction_id " +
                "Where tourist_id = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("paraId", tourist);

            DataSet ds = new DataSet();

            da.Fill(ds);

            List<GeoJson> list = new List<GeoJson>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                string name = row["attractionName"].ToString();
                string desc = row["attractionDesc"].ToString();
                double lat = double.Parse(row["attractionLatitude"].ToString());
                double log = double.Parse(row["attractionLongitude"].ToString());
                GeoJson obj = new GeoJson(name, desc, lat, log);
                list.Add(obj);
            }

            return list;
        }

        public static void AddDirToUser(int attraction, int tourist)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlstmt = "Insert Into Directions (attraction_id, tourist_id) Values (@paraAttraction, @paraTourist);";
            SqlCommand cmd = new SqlCommand(sqlstmt, myConn);
            cmd.Parameters.AddWithValue("@paraAttraction", attraction);
            cmd.Parameters.AddWithValue("@paraTourist", tourist);

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

        public static void RemoveOneDirByUser(int attraction, int tourist)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlstmt = "Delete From Directions Where attraction_id = @paraAttraction And tourist_id = @paraTourist";
            SqlCommand cmd = new SqlCommand(sqlstmt, myConn);
            cmd.Parameters.AddWithValue("@paraAttraction", attraction);
            cmd.Parameters.AddWithValue("@paraTourist", tourist);

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

        public static void RemovAllDirByUser(int tourist)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlstmt = "Delete From Directions Where tourist_id = @paraTourist";
            SqlCommand cmd = new SqlCommand(sqlstmt, myConn);
            cmd.Parameters.AddWithValue("@paraTourist", tourist);

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

        public static double[] GetCoordByName(string name)
        {
            return null;
        }
    }
}