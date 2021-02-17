using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TouristHelp.BLL;

namespace TouristHelp.DAL
{
    public class HotelBookDAO
    {


        public HotelBook selectByHotel(string shopId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from HotelBook where hotelId = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", shopId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            HotelBook td = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
              

                int hotelId = Convert.ToInt32(row["hotelId"]);
                decimal hotelPrice = Convert.ToDecimal(row["hotelPrice"]);
                string hotelImage = row["hotelImage"].ToString();
                bool centralFilter = Convert.ToBoolean(row["centralFilter"]);
                bool northFilter = Convert.ToBoolean(row["northFilter"]);
                bool southFilter = Convert.ToBoolean(row["southFilter"]);
                bool westFilter = Convert.ToBoolean(row["westFilter"]);
                bool eastFilter = Convert.ToBoolean(row["eastFilter"]);
                string hotelName = row["hotelName"].ToString();
          



                td = new HotelBook(hotelId, hotelPrice, hotelImage, centralFilter, northFilter, southFilter, westFilter, eastFilter, hotelName);
            }
            return td;
        }



        public List<HotelBook> SelectAllHotel()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from HotelBook";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<HotelBook> empList = new List<HotelBook>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                int hotelId = Convert.ToInt32(row["hotelId"]);
                decimal hotelPrice = Convert.ToDecimal(row["hotelPrice"]);
                string hotelImage = row["hotelImage"].ToString();
                bool centralFilter = Convert.ToBoolean(row["centralFilter"]);
                bool northFilter = Convert.ToBoolean(row["northFilter"]);
                bool southFilter = Convert.ToBoolean(row["southFilter"]);
                bool westFilter = Convert.ToBoolean(row["westFilter"]);
                bool eastFilter = Convert.ToBoolean(row["eastFilter"]);
                string hotelName = row["hotelName"].ToString();
                

                HotelBook obj = new HotelBook(hotelId, hotelPrice, hotelImage, centralFilter, northFilter, southFilter, westFilter, eastFilter, hotelName);
                empList.Add(obj);
            }

            return empList;
        }



        public List<HotelBook> getCentralHotels()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from HotelBook " +
                                "WHERE centralFilter = 1 ";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<HotelBook> empList = new List<HotelBook>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                int hotelId = Convert.ToInt32(row["hotelId"]);
                decimal hotelPrice = Convert.ToDecimal(row["hotelPrice"]);
                string hotelImage = row["hotelImage"].ToString();
                bool centralFilter = Convert.ToBoolean(row["centralFilter"]);
                bool northFilter = Convert.ToBoolean(row["northFilter"]);
                bool southFilter = Convert.ToBoolean(row["southFilter"]);
                bool westFilter = Convert.ToBoolean(row["westFilter"]);
                bool eastFilter = Convert.ToBoolean(row["eastFilter"]);
                string hotelName = row["hotelName"].ToString();
              

                HotelBook obj = new HotelBook(hotelId, hotelPrice, hotelImage, centralFilter, northFilter, southFilter, westFilter, eastFilter, hotelName);
                empList.Add(obj);
            }

            return empList;
        }


        public List<HotelBook> getNorthHotels()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from HotelBook " +
                                "WHERE northFilter = 1 ";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<HotelBook> empList = new List<HotelBook>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                int hotelId = Convert.ToInt32(row["hotelId"]);
                decimal hotelPrice = Convert.ToDecimal(row["hotelPrice"]);
                string hotelImage = row["hotelImage"].ToString();
                bool centralFilter = Convert.ToBoolean(row["centralFilter"]);
                bool northFilter = Convert.ToBoolean(row["northFilter"]);
                bool southFilter = Convert.ToBoolean(row["southFilter"]);
                bool westFilter = Convert.ToBoolean(row["westFilter"]);
                bool eastFilter = Convert.ToBoolean(row["eastFilter"]);
                string hotelName = row["hotelName"].ToString();
                

                HotelBook obj = new HotelBook(hotelId, hotelPrice, hotelImage, centralFilter, northFilter, southFilter, westFilter, eastFilter, hotelName);
                empList.Add(obj);
            }

            return empList;
        }




        public List<HotelBook> getSouthHotels()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from HotelBook " +
                                "WHERE southFilter = 1 ";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<HotelBook> empList = new List<HotelBook>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                int hotelId = Convert.ToInt32(row["hotelId"]);
                decimal hotelPrice = Convert.ToDecimal(row["hotelPrice"]);
                string hotelImage = row["hotelImage"].ToString();
                bool centralFilter = Convert.ToBoolean(row["centralFilter"]);
                bool northFilter = Convert.ToBoolean(row["northFilter"]);
                bool southFilter = Convert.ToBoolean(row["southFilter"]);
                bool westFilter = Convert.ToBoolean(row["westFilter"]);
                bool eastFilter = Convert.ToBoolean(row["eastFilter"]);
                string hotelName = row["hotelName"].ToString();
              

                HotelBook obj = new HotelBook(hotelId, hotelPrice, hotelImage, centralFilter, northFilter, southFilter, westFilter, eastFilter, hotelName);
                empList.Add(obj);
            }

            return empList;
        }


        public List<HotelBook> getWestHotels()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from HotelBook " +
                                "WHERE westFilter = 1 ";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<HotelBook> empList = new List<HotelBook>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                int hotelId = Convert.ToInt32(row["hotelId"]);
                decimal hotelPrice = Convert.ToDecimal(row["hotelPrice"]);
                string hotelImage = row["hotelImage"].ToString();
                bool centralFilter = Convert.ToBoolean(row["centralFilter"]);
                bool northFilter = Convert.ToBoolean(row["northFilter"]);
                bool southFilter = Convert.ToBoolean(row["southFilter"]);
                bool westFilter = Convert.ToBoolean(row["westFilter"]);
                bool eastFilter = Convert.ToBoolean(row["eastFilter"]);
                string hotelName = row["hotelName"].ToString();
              

                HotelBook obj = new HotelBook(hotelId, hotelPrice, hotelImage, centralFilter, northFilter, southFilter, westFilter, eastFilter, hotelName);
                empList.Add(obj);
            }

            return empList;
        }


        public List<HotelBook> getEastHotels()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from HotelBook " +
                                "WHERE eastFilter = 1 ";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<HotelBook> empList = new List<HotelBook>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                int hotelId = Convert.ToInt32(row["hotelId"]);
                decimal hotelPrice = Convert.ToDecimal(row["hotelPrice"]);
                string hotelImage = row["hotelImage"].ToString();
                bool centralFilter = Convert.ToBoolean(row["centralFilter"]);
                bool northFilter = Convert.ToBoolean(row["northFilter"]);
                bool southFilter = Convert.ToBoolean(row["southFilter"]);
                bool westFilter = Convert.ToBoolean(row["westFilter"]);
                bool eastFilter = Convert.ToBoolean(row["eastFilter"]);
                string hotelName = row["hotelName"].ToString();
               

                HotelBook obj = new HotelBook(hotelId, hotelPrice, hotelImage, centralFilter, northFilter, southFilter, westFilter, eastFilter, hotelName);
                empList.Add(obj);
            }

            return empList;
        }





        public List<HotelBook> getHotelsByPrice(int minPriceFilter, int maxPriceFilter)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from HotelBook " +
                                "WHERE hotelPrice >= @paraMinPriceFilter AND  " +
                                "hotelPrice <= @paraMaxPriceFilter";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraMinPriceFilter", minPriceFilter);

            da.SelectCommand.Parameters.AddWithValue("@paraMaxPriceFilter", maxPriceFilter);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<HotelBook> empList = new List<HotelBook>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                int hotelId = Convert.ToInt32(row["hotelId"]);
                decimal hotelPrice = Convert.ToDecimal(row["hotelPrice"]);
                string hotelImage = row["hotelImage"].ToString();
                bool centralFilter = Convert.ToBoolean(row["centralFilter"]);
                bool northFilter = Convert.ToBoolean(row["northFilter"]);
                bool southFilter = Convert.ToBoolean(row["southFilter"]);
                bool westFilter = Convert.ToBoolean(row["westFilter"]);
                bool eastFilter = Convert.ToBoolean(row["eastFilter"]);
                string hotelName = row["hotelName"].ToString();
                

                HotelBook obj = new HotelBook(hotelId, hotelPrice, hotelImage, centralFilter, northFilter, southFilter, westFilter, eastFilter, hotelName);
                empList.Add(obj);
            }

            return empList;
        }




        public void addNewHotel(HotelBook hotel) //Insert the hotel details into db
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO HotelBook (hotelPrice, hotelImage, centralFilter, northFilter, southFilter, westFilter, eastFilter, hotelName)" +
                             "VALUES (@parahotelprice, @parahotelimage, @paracentralfilter, @paranorthfilter, @parasouthfilter, @parawestfilter, @paraeastfilter, @parahotelname)";


            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@parahotelprice", hotel.hotelPrice);
            sqlCmd.Parameters.AddWithValue("@parahotelimage", hotel.hotelImage);
            sqlCmd.Parameters.AddWithValue("@paracentralfilter", hotel.centralFilter);
            sqlCmd.Parameters.AddWithValue("@paranorthfilter", hotel.northFilter);
            sqlCmd.Parameters.AddWithValue("@parasouthfilter", hotel.southFilter);
            sqlCmd.Parameters.AddWithValue("@parawestfilter", hotel.westFilter);
            sqlCmd.Parameters.AddWithValue("@paraeastfilter", hotel.eastFilter);
            sqlCmd.Parameters.AddWithValue("@parahotelname", hotel.hotelName);


            myConn.Open();
            sqlCmd.ExecuteNonQuery();
            myConn.Close();
        }







        public HotelBook selectByHotelId(int hotelId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from HotelBook where hotelId = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", hotelId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            HotelBook td = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                decimal hotelPrice = Convert.ToDecimal(row["hotelPrice"]);
                string hotelImage = row["hotelImage"].ToString();
                bool centralFilter = Convert.ToBoolean(row["centralFilter"]);
                bool northFilter = Convert.ToBoolean(row["northFilter"]);
                bool southFilter = Convert.ToBoolean(row["southFilter"]);
                bool westFilter = Convert.ToBoolean(row["westFilter"]);
                bool eastFilter = Convert.ToBoolean(row["eastFilter"]);
                string hotelName = row["hotelName"].ToString();


                td = new HotelBook(hotelId, hotelPrice, hotelImage, centralFilter, northFilter, southFilter, westFilter, eastFilter, hotelName);
            }
            return td;
        }


    }
}