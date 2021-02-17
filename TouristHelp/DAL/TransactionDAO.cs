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
    public class TransactionDAO
    {

        public Transactions SelectByAccount(string transId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from [Transaction] where voucherGen_id = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", transId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Transactions td = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                int voucherGen_id = Convert.ToInt32(row["voucherGen_id"]);
                string voucherStats = row["voucherStats"].ToString();
                DateTime voucherExpiry = Convert.ToDateTime(row["voucherExpiry"].ToString());
                int confirmCode = Convert.ToInt32(row["confirmCode"]);
                int user_id = Convert.ToInt32(row["user_id"]);
                DateTime voucherDate = Convert.ToDateTime(row["voucherDate"].ToString());
                int voucherTotalCost = Convert.ToInt32(row["voucherTotalCost"]);
                int voucherQuantity = Convert.ToInt32(row["voucherQuantity"]);
                string voucherName = row["voucherName"].ToString();
                string voucherCategory = row["voucherCategory"].ToString();




                td = new Transactions(voucherGen_id, voucherStats, voucherExpiry,confirmCode,user_id, voucherDate, voucherTotalCost, voucherQuantity, voucherName, voucherCategory);
            }
            return td;
        }





        public void insertTransaction(Transactions transId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO [Transaction] (voucherGen_id, voucherStats, voucherExpiry, confirmCode, user_id, voucherDate, voucherTotalCost, voucherQuantity, voucherName, voucherCategory) " +
                             "VALUES (@paraVoucherGenId, @paraVoucherStats, @paraVoucherExpiry, @paraConfirmCode, @paraUserId, @paraVoucherDate, @paraVoucherTotalCost, @paraVoucherQuantity, @paraVoucherName, @paravouchercategory)";
                            



            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraVoucherGenId", transId.voucherGen_id);
            sqlCmd.Parameters.AddWithValue("@paraVoucherStats", transId.voucherStats);
            sqlCmd.Parameters.AddWithValue("@paraVoucherExpiry", transId.voucherExpiry);
            sqlCmd.Parameters.AddWithValue("@paraConfirmCode", transId.confirmCode);
            sqlCmd.Parameters.AddWithValue("@paraUserId", transId.user_id);
            sqlCmd.Parameters.AddWithValue("@paraVoucherDate", transId.voucherDate);
            sqlCmd.Parameters.AddWithValue("@paraVoucherTotalCost", transId.voucherTotalCost);
            sqlCmd.Parameters.AddWithValue("@paraVoucherQuantity", transId.voucherQuantity);
            sqlCmd.Parameters.AddWithValue("@paraVoucherName", transId.voucherName);
            sqlCmd.Parameters.AddWithValue("@paravouchercategory", transId.voucherCategory);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();
            myConn.Close();
        }


        public List<Transactions> getTransactionById(int userId)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from [Transaction] " +
                              "WHERE user_id =  @paraUserId " +
                               "ORDER BY voucherDate DESC";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraUserId", userId);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Transactions> intList = new List<Transactions>();

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 0)
            {
                intList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int voucherGen_id = Convert.ToInt32(row["voucherGen_id"]);
                    string voucherStats = row["voucherStats"].ToString();
                    DateTime voucherExpiry = Convert.ToDateTime(row["voucherExpiry"].ToString());
                    int confirmCode = Convert.ToInt32(row["confirmCode"]);
                    DateTime voucherDate = Convert.ToDateTime(row["voucherDate"].ToString());
                    int voucherTotalCost = Convert.ToInt32(row["voucherTotalCost"]);
                    int voucherQuantity = Convert.ToInt32(row["voucherQuantity"]);
                    string voucherName = row["voucherName"].ToString();
                    string voucherCategory = row["voucherCategory"].ToString();

                    Transactions objRate = new Transactions(voucherGen_id, voucherStats, voucherExpiry, confirmCode, userId, voucherDate, voucherTotalCost, voucherQuantity, voucherName, voucherCategory);
                    intList.Add(objRate);
                }
            }
            return intList;
        }



        public List<Transactions> getTransactionByIdOldest(int userId)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from [Transaction] " +
                              "WHERE user_id =  @paraUserId " +
                               "ORDER BY voucherDate ";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraUserId", userId);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Transactions> intList = new List<Transactions>();

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 0)
            {
                intList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int voucherGen_id = Convert.ToInt32(row["voucherGen_id"]);
                    string voucherStats = row["voucherStats"].ToString();
                    DateTime voucherExpiry = Convert.ToDateTime(row["voucherExpiry"].ToString());
                    int confirmCode = Convert.ToInt32(row["confirmCode"]);
                    DateTime voucherDate = Convert.ToDateTime(row["voucherDate"].ToString());
                    int voucherTotalCost = Convert.ToInt32(row["voucherTotalCost"]);
                    int voucherQuantity = Convert.ToInt32(row["voucherQuantity"]);
                    string voucherName = row["voucherName"].ToString();
                    string voucherCategory = row["voucherCategory"].ToString();

                    Transactions objRate = new Transactions(voucherGen_id, voucherStats, voucherExpiry, confirmCode, userId, voucherDate, voucherTotalCost, voucherQuantity, voucherName, voucherCategory);
                    intList.Add(objRate);
                }
            }
            return intList;
        }


        public void shopUsed(string shopCode)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [Transaction] SET voucherStats = 'Used' where voucherGen_id = @paravouchergenid ";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);


            sqlCmd = new SqlCommand(sqlStmt.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paravouchergenid", shopCode);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            myConn.Close();


        }











    }
}