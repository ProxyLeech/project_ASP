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
    public class AttractionDAO
    {
        public string Name { get; set; }

        public Attraction SelectById(string attId) //get the attraction info by Id
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "SELECT * FROM Attraction WHERE attractionId = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", attId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Attraction td = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int id = int.Parse(row["attractionId"].ToString());
                string name = row["attractionName"].ToString();
                string image = row["attractionImage"].ToString();
                string price = row["attractionPrice"].ToString();
                string date = row["DateTime"].ToString();
                string desc = row["attractionDesc"].ToString();
                string loc = row["attractionLocation"].ToString();
                decimal lat = decimal.Parse(row["attractionLatitude"].ToString());
                decimal lon = decimal.Parse(row["attractionLongitude"].ToString());
                string interest = row["attractionInterest"].ToString();
                string type = row["attractionType"].ToString();
                string transaction = row["attractionTransaction"].ToString();

                td = new Attraction(id, name, image, price, date, desc, loc, lat, lon, interest, type, transaction);
            }
            return td;
        }

        public List<Attraction> SelectAll() //get all from attraction db and put into list
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from Attraction";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Attraction> empList = new List<Attraction>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                int id = int.Parse(row["attractionId"].ToString());
                string name = row["attractionName"].ToString();
                string image = row["attractionImage"].ToString();
                string price = row["attractionPrice"].ToString();
                string date = row["DateTime"].ToString();
                string desc = row["attractionDesc"].ToString();
                string loc = row["attractionLocation"].ToString();
                decimal lat = decimal.Parse(row["attractionLatitude"].ToString());
                decimal lon = decimal.Parse(row["attractionLongitude"].ToString());
                string interest = row["attractionInterest"].ToString();
                string type = row["attractionType"].ToString();
                string transaction = row["attractionTransaction"].ToString();

                Attraction obj = new Attraction(id, name, image, price, date, desc, loc, lat, lon, interest, type, transaction);
                empList.Add(obj);
            }
            return empList;
        }

        public List<Attraction> SelectByType(string filterType) //get same type from attraction db and put into list
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * from Attraction where attractionType = @paraType";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraType", filterType);

            DataSet ds = new DataSet();

            da.Fill(ds);

            List<Attraction> empList = new List<Attraction>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int id = int.Parse(row["attractionId"].ToString());
                string name = row["attractionName"].ToString();
                string image = row["attractionImage"].ToString();
                string price = row["attractionPrice"].ToString();
                string date = row["DateTime"].ToString();
                string desc = row["attractionDesc"].ToString();
                string loc = row["attractionLocation"].ToString();
                decimal lat = decimal.Parse(row["attractionLatitude"].ToString());
                decimal lon = decimal.Parse(row["attractionLongitude"].ToString());
                string interest = row["attractionInterest"].ToString();
                string type = row["attractionType"].ToString();
                string transaction = row["attractionTransaction"].ToString();

                Attraction obj = new Attraction(id, name, image, price, date, desc, loc, lat, lon, interest, type, transaction);
                empList.Add(obj);
            }
            return empList;
        }

        public List<Attraction> SelectAll_Personal(string arrangeBy) //get all from attraction db arrange by user interest and put into list
        {
            
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            
            string sqlStmt = "Select * from Attraction where attractionInterest = @paraInt";
            SqlDataAdapter da1 = new SqlDataAdapter(sqlStmt, myConn);
            da1.SelectCommand.Parameters.AddWithValue("@paraInt", arrangeBy);

            sqlStmt = "Select * from Attraction where not attractionInterest = @paraInt";
            SqlDataAdapter da2 = new SqlDataAdapter(sqlStmt, myConn);
            da2.SelectCommand.Parameters.AddWithValue("@paraInt", arrangeBy);


            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();

            da1.Fill(ds1);
            da2.Fill(ds2);

            List<Attraction> empList = new List<Attraction>();
            int rec_cnt = ds1.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds1.Tables[0].Rows[i];
                int id = int.Parse(row["attractionId"].ToString());
                string name = row["attractionName"].ToString();
                string image = row["attractionImage"].ToString();
                string price = row["attractionPrice"].ToString();
                string date = row["DateTime"].ToString();
                string desc = row["attractionDesc"].ToString();
                string loc = row["attractionLocation"].ToString();
                decimal lat = decimal.Parse(row["attractionLatitude"].ToString());
                decimal lon = decimal.Parse(row["attractionLongitude"].ToString());
                string interest = row["attractionInterest"].ToString();
                string type = row["attractionType"].ToString();
                string transaction = row["attractionTransaction"].ToString();

                Attraction obj = new Attraction(id, name, image, price, date, desc, loc, lat, lon, interest, type, transaction);
                empList.Add(obj);
            }

            rec_cnt = ds2.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds2.Tables[0].Rows[i];
                int id = int.Parse(row["attractionId"].ToString());
                string name = row["attractionName"].ToString();
                string image = row["attractionImage"].ToString();
                string price = row["attractionPrice"].ToString();
                string date = row["DateTime"].ToString();
                string desc = row["attractionDesc"].ToString();
                string loc = row["attractionLocation"].ToString();
                decimal lat = decimal.Parse(row["attractionLatitude"].ToString());
                decimal lon = decimal.Parse(row["attractionLongitude"].ToString());
                string interest = row["attractionInterest"].ToString();
                string type = row["attractionType"].ToString();
                string transaction = row["attractionTransaction"].ToString();

                Attraction obj = new Attraction(id, name, image, price, date, desc, loc, lat, lon, interest, type, transaction);
                empList.Add(obj);
            }
            return empList;
        }

        public List<Attraction> SelectByType_Personal(string filterType, string arrangeBy) //get same type from attraction db arrange by user interest and put into list
        {

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            
            string sqlStmt = "Select * from Attraction where attractionType = @paraType and attractionInterest = @paraInt";
            SqlDataAdapter da1 = new SqlDataAdapter(sqlStmt, myConn);
            da1.SelectCommand.Parameters.AddWithValue("@paraType", filterType);
            da1.SelectCommand.Parameters.AddWithValue("@paraInt", arrangeBy);

            sqlStmt = "Select * from Attraction where attractionType = @paraType and not attractionInterest = @paraInt";
            SqlDataAdapter da2 = new SqlDataAdapter(sqlStmt, myConn);
            da2.SelectCommand.Parameters.AddWithValue("@paraType", filterType);
            da2.SelectCommand.Parameters.AddWithValue("@paraInt", arrangeBy);


            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();

            da1.Fill(ds1);
            da2.Fill(ds2);

            List<Attraction> empList = new List<Attraction>();
            int rec_cnt = ds1.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds1.Tables[0].Rows[i];
                int id = int.Parse(row["attractionId"].ToString());
                string name = row["attractionName"].ToString();
                string image = row["attractionImage"].ToString();
                string price = row["attractionPrice"].ToString();
                string date = row["DateTime"].ToString();
                string desc = row["attractionDesc"].ToString();
                string loc = row["attractionLocation"].ToString();
                decimal lat = decimal.Parse(row["attractionLatitude"].ToString());
                decimal lon = decimal.Parse(row["attractionLongitude"].ToString());
                string interest = row["attractionInterest"].ToString();
                string type = row["attractionType"].ToString();
                string transaction = row["attractionTransaction"].ToString();

                Attraction obj = new Attraction(id, name, image, price, date, desc, loc, lat, lon, interest, type, transaction);
                empList.Add(obj);
            }

            rec_cnt = ds2.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds2.Tables[0].Rows[i];
                int id = int.Parse(row["attractionId"].ToString());
                string name = row["attractionName"].ToString();
                string image = row["attractionImage"].ToString();
                string price = row["attractionPrice"].ToString();
                string date = row["DateTime"].ToString();
                string desc = row["attractionDesc"].ToString();
                string loc = row["attractionLocation"].ToString();
                decimal lat = decimal.Parse(row["attractionLatitude"].ToString());
                decimal lon = decimal.Parse(row["attractionLongitude"].ToString());
                string interest = row["attractionInterest"].ToString();
                string type = row["attractionType"].ToString();
                string transaction = row["attractionTransaction"].ToString();

                Attraction obj = new Attraction(id, name, image, price, date, desc, loc, lat, lon, interest, type, transaction);
                empList.Add(obj);
            }
            return empList;
        }

        public void InsertNewAttraction(Attraction att) //Insert the attraction details into db
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO Attraction (attractionName, attractionPrice, dateTime, attractionDesc, attractionLocation, attractionLatitude, attractionLongitude, attractionInterest, attractionType, attractionTransaction, attractionImage)" +
                             "VALUES (@paraName, @paraPrice, @paraDate, @paraDesc, @paraLoc, @paraLat, @paraLong, @paraInt, @paraType, @paraTran, @paraImage)";


            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraName", att.Name);
            sqlCmd.Parameters.AddWithValue("@paraPrice", att.Price);
            sqlCmd.Parameters.AddWithValue("@paraDate", att.DateTime);
            sqlCmd.Parameters.AddWithValue("@paraDesc", att.Description);
            sqlCmd.Parameters.AddWithValue("@paraLoc", att.Location);
            sqlCmd.Parameters.AddWithValue("@paraLat", att.Latitude);
            sqlCmd.Parameters.AddWithValue("@paraLong", att.Longitude);
            sqlCmd.Parameters.AddWithValue("@paraInt", att.Interest);
            sqlCmd.Parameters.AddWithValue("@paraType", att.Type);
            sqlCmd.Parameters.AddWithValue("@paraTran", att.Transaction);
            sqlCmd.Parameters.AddWithValue("@paraImage", att.Image);


            myConn.Open();
            sqlCmd.ExecuteNonQuery();
            myConn.Close();
        }

        public void UpdateAttraction(Attraction att) //Update the attraction details into db
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Attraction SET attractionName = @paraName, attractionPrice = @paraPrice, dateTime = @paraDate, attractionDesc = @paraDesc, attractionLocation = @paraLoc, attractionLatitude = @paraLat, attractionLongitude = @paraLong, attractionInterest = @paraInt, attractionType = @paraType, attractionTransaction = @paraTran, attractionImage = @paraImage WHERE attractionId = @paraId";
                             
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraId", att.Id);
            sqlCmd.Parameters.AddWithValue("@paraName", att.Name);
            sqlCmd.Parameters.AddWithValue("@paraPrice", att.Price);
            sqlCmd.Parameters.AddWithValue("@paraDate", att.DateTime);
            sqlCmd.Parameters.AddWithValue("@paraDesc", att.Description);
            sqlCmd.Parameters.AddWithValue("@paraLoc", att.Location);
            sqlCmd.Parameters.AddWithValue("@paraLat", att.Latitude);
            sqlCmd.Parameters.AddWithValue("@paraLong", att.Longitude);
            sqlCmd.Parameters.AddWithValue("@paraInt", att.Interest);
            sqlCmd.Parameters.AddWithValue("@paraType", att.Type);
            sqlCmd.Parameters.AddWithValue("@paraTran", att.Transaction);
            sqlCmd.Parameters.AddWithValue("@paraImage", att.Image);


            myConn.Open();
            sqlCmd.ExecuteNonQuery();
            myConn.Close();
        }
    }
}