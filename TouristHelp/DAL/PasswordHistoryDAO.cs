using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TouristHelp.BLL;

namespace TouristHelp.DAL
{
    public class PasswordHistoryDAO
    {
        public void InsertPasswordHistory(PasswordHistory passwordEntry)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO PasswordGen (email, passwordHash, passwordSalt, timeGenerated) " +
                             "VALUES (@paraEmail, @paraPasswordHash, @paraPasswordSalt, @paraTimeGenerated)";


            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraEmail", passwordEntry.email);
            sqlCmd.Parameters.AddWithValue("@paraPasswordHash", passwordEntry.passwordHash);
            sqlCmd.Parameters.AddWithValue("@paraPasswordSalt", passwordEntry.passwordSalt);
            sqlCmd.Parameters.AddWithValue("@paraTimeGenerated", passwordEntry.timeGenerated);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            myConn.Close();
        }

        public List<PasswordHistory> GetAllPassword(string email)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            String sqlstmt = "SELECT * From PasswordGen " +
                             "where email = @paraEmail";

            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<PasswordHistory> passwordList = new List<PasswordHistory>();

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 0)
            {
                passwordList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int passwordId = Convert.ToInt32(row["pwId"].ToString());
                    string passwordhash = row["passwordHash"].ToString();
                    string passwordsalt = row["passwordSalt"].ToString();
                    DateTime timegenerated = Convert.ToDateTime(row["timeGenerated"]);
                    PasswordHistory obj = new PasswordHistory(email, passwordhash, passwordsalt, timegenerated);
                    passwordList.Add(obj);
                }
            }
            return passwordList;
        }

        public void DeletePassword(string hash)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "DELETE FROM PasswordGen where passwordHash = @paraHash";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);


            sqlCmd = new SqlCommand(sqlStmt.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraHash", hash);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            myConn.Close();


        }
    }
}