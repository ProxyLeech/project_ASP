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
    public class InterestDAO
    {
        public void Insert(Interest inter)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "IF EXISTS(select * from Interest where user_id = @paraUserId) " +
                             "UPDATE Interest set InterestName = @paraInterestName where user_id = @paraUserId " +
                             "ELSE " +
                             "INSERT INTO Interest (InterestName, user_id) values(@paraInterestName, @paraUserId)";


            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraInterestName", inter.InterestName);
            sqlCmd.Parameters.AddWithValue("@paraUserId", inter.userId);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            myConn.Close();
        }

        public Interest SelectInterestById(int userId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            String sqlstmt = "SELECT * From Interest " +
                             "where user_id = @paraUserId";

            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraUserId", userId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            
            int rec_cnt = ds.Tables[0].Rows.Count;

            if (rec_cnt == 0)
            {
                return null;
            }
            
            DataRow row = ds.Tables[0].Rows[0];
            string interestName = row["InterestName"].ToString();
            Interest objRate = new Interest(interestName, userId);
            
            return objRate;
        }

        public void RemoveInterest(string InterestName, int userId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "DELETE FROM Interest where user_id = @paraUserId";


            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);
            
            sqlCmd.Parameters.AddWithValue("@paraUserId", userId);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            myConn.Close();
        }
    }
}