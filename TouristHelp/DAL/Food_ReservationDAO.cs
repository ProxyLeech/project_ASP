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
    public class Food_ReservationDAO
    {
        public void InsertReservation(string Name, string Date, string Time, int Pax, int UserId, string qr, string image) //Insert the reservation details into db
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO ReservationFood (reservationName, reservationDate, reservationTime, reservationPax, reservationState, userId, reservationQR, reservationImage)" +
                             "VALUES (@paraName, @paraDate, @paraTime, @paraPax, @paraStatus ,@paraId, @paraQR, @paraImage)";


            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraName", Name);
            sqlCmd.Parameters.AddWithValue("@paraDate", Date);
            sqlCmd.Parameters.AddWithValue("@paraTime", Time);
            sqlCmd.Parameters.AddWithValue("@paraPax", Pax);
            sqlCmd.Parameters.AddWithValue("@paraStatus", "Active");
            sqlCmd.Parameters.AddWithValue("@paraId", UserId);
            sqlCmd.Parameters.AddWithValue("@paraQR", qr);
            sqlCmd.Parameters.AddWithValue("@paraImage", image);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();
            myConn.Close();
        }


        public List<Food_Reservation> SelectById(int resId) //get all reservations under an id from Reservation db and put into list
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            
            string sqlStmt = "Select * from ReservationFood where userId = @paraId and reservationState = 'Active'";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", resId);

            DataSet ds = new DataSet();

            da.Fill(ds);

            List<Food_Reservation> empList = new List<Food_Reservation>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int id = int.Parse(row["reservationId"].ToString());
                string name = row["reservationName"].ToString();
                string date = row["reservationDate"].ToString();
                string time = row["reservationTime"].ToString();
                int pax = int.Parse(row["reservationPax"].ToString());
                string state = row["reservationState"].ToString();
                string qr = row["reservationQR"].ToString();
                string image = row["reservationImage"].ToString();
                Food_Reservation obj = new Food_Reservation(id, name, date, time, pax, state, qr, image);
                empList.Add(obj);
            }
            return empList;
        }

        public Food_Reservation SelectByIdSingle(int resId) //get all reservations under an id from Reservation db and put into list
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);


            string sqlStmt = "Select * from ReservationFood where reservationId = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", resId);

            DataSet ds = new DataSet();

            da.Fill(ds);
            
            DataRow row = ds.Tables[0].Rows[0];
            int id = int.Parse(row["reservationId"].ToString());
            string name = row["reservationName"].ToString();
            string date = row["reservationDate"].ToString();
            string time = row["reservationTime"].ToString();
            int pax = int.Parse(row["reservationPax"].ToString());
            string state = row["reservationState"].ToString();
            string qr = row["reservationQR"].ToString();
            string image = row["reservationImage"].ToString();
            Food_Reservation obj = new Food_Reservation(id, name, date, time, pax, state, qr, image);

            return obj;
        }

        public List<string> GetAllCode()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            String sqlstmt = "SELECT reservationQR From ReservationFood";

            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);


            DataSet ds = new DataSet();
            da.Fill(ds);

            List<String> codeList = new List<String>();

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 0)
            {
                codeList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string QRCode = row["reservationQR"].ToString();

                    codeList.Add(QRCode);
                }
            }
            return codeList;
        }

        public void ReservationStatusDisable(int resId) //set status to disabled
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE ReservationFood SET reservationState = 'Inactive' WHERE reservationId = @paraId";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraId", resId);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();
            myConn.Close();
        }
    }
}