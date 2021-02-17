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
    public class TicketDAO
    {
        public void AddTicket(Ticket tk)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO Ticket (attractionName, attractionDesc, price, " +
                                    "dateExpire, ticketCode, paid, user_id, cartId, ticketImage)" +
                             "VALUES (@paraAttName,@paraAttDesc,@paraPrice,@paraDateExpire," +
                                    "@paraTicketCode,@paraPaid,@paraUserId,@paraCartId,@paraTicketImage)";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraAttName", tk.attractionName);
            sqlCmd.Parameters.AddWithValue("@paraAttDesc", tk.attractionDesc);
            sqlCmd.Parameters.AddWithValue("@paraPrice", tk.price);
            sqlCmd.Parameters.AddWithValue("@paraDateExpire", tk.dateExpire);
            sqlCmd.Parameters.AddWithValue("@paraTicketCode", tk.ticketCode);
            sqlCmd.Parameters.AddWithValue("@paraPaid", tk.paid);
            sqlCmd.Parameters.AddWithValue("@paraUserId", tk.userId);
            sqlCmd.Parameters.AddWithValue("@paraCartId", tk.cartId);
            sqlCmd.Parameters.AddWithValue("@paraTicketImage", tk.ticketImage);


            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            myConn.Close();

        }

        public List<Ticket> SelectTicketByUser(int userId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            String sqlstmt = "SELECT * From Ticket " +
                             "where user_id = @paraUserId AND paid = 'paid'";

            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraUserId", userId);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Ticket> ticketList = new List<Ticket>();

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 0)
            {
                ticketList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int ticketId = Convert.ToInt32(row["ticketId"].ToString());
                    string ticketName = row["attractionName"].ToString();
                    string ticketDesc = row["attractionDesc"].ToString();
                    string ticketCode = row["ticketCode"].ToString();
                    DateTime dateExpire = Convert.ToDateTime(row["dateExpire"]);
                    string ticketImg = row["ticketImage"].ToString();
                    Ticket tix = new Ticket(ticketId, ticketName, ticketDesc, dateExpire, ticketCode, ticketImg);
                    ticketList.Add(tix);
                }
            }
            return ticketList;
        }

        public List<string> GetAllCode()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            String sqlstmt = "SELECT ticketCode From Ticket";

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
                    string ticketCode = row["ticketCode"].ToString();

                    codeList.Add(ticketCode);
                }
            }
            return codeList;
        }

        public Ticket GetTicketItem(int cartId, int userId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "SELECT * From Ticket where user_id = @paraUserId " +
                            "and cartId = @paraCartId and paid = 'paid'";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraCartId", cartId);
            da.SelectCommand.Parameters.AddWithValue("@paraUserId", userId);

            DataSet ds = new DataSet();
            da.Fill(ds);

            Ticket ti = null;

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                //int ticketId = Convert.ToInt32(row["ticketId"].ToString());
                string attractionName = row["attractionName"].ToString();
                string attractionDesc = row["attractionDesc"].ToString();
                double price = Convert.ToDouble(row["price"].ToString());
                DateTime dateExpire = Convert.ToDateTime(row["dateExpire"].ToString());
                int user_id = Convert.ToInt32(row["user_id"].ToString());
                string ticketImg = row["ticketImage"].ToString();
                ti = new Ticket(attractionName, attractionDesc, price, dateExpire, user_id, ticketImg);
            }   
            return ti;
        }

        public void UpdateTicket(int cartId, int userId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Ticket SET paid = 'paid' where user_id = @paraUserId AND cartId = @paraCartId ";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);


            sqlCmd = new SqlCommand(sqlStmt.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraUserId", userId);
            sqlCmd.Parameters.AddWithValue("@paraCartId", cartId);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            myConn.Close();


        }

        public Ticket GetTicketById(int ticket_id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "SELECT * From Ticket where ticketId = @paraTicketId " +
                            "and paid = 'paid'";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraTicketId", ticket_id);

            DataSet ds = new DataSet();
            da.Fill(ds);

            Ticket ti = null;

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int ticketId = Convert.ToInt32(row["ticketId"].ToString());
                string attractionName = row["attractionName"].ToString();
                string attractionDesc = row["attractionDesc"].ToString();
                DateTime dateExpire = Convert.ToDateTime(row["dateExpire"].ToString());
                string ticketCode = row["ticketCode"].ToString();

                string ticketImg = row["ticketImage"].ToString();
                ti = new Ticket(ticketId, attractionName, attractionDesc, dateExpire, ticketCode, ticketImg);
            }
            return ti;
        }

        public void ClaimTicket(string code)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Ticket SET paid = 'claimed' where ticketCode = @paraTicketCode ";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);


            sqlCmd = new SqlCommand(sqlStmt.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraTicketCode", code);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            myConn.Close();


        }

        public void TicketExp(int ticketId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Ticket SET paid = 'expired' where ticketId = @paraTicketId ";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);


            sqlCmd = new SqlCommand(sqlStmt.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraTicketId", ticketId);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            myConn.Close();


        }
    }
}