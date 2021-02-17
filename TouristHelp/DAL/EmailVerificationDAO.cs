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
    public class EmailVerificationDAO
    {
        public void InsertVerificationCode(EmailVerification emailVerification)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO EmailVerification (emailVerificationCode, email, expire, timeGenerated) " +
                             "VALUES (@paraEmailVerificationCode, @paraEmail, @paraExpire, @paraTimeGenerated)";


            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraEmailVerificationCode", emailVerification.emailVerificationCode);
            sqlCmd.Parameters.AddWithValue("@paraEmail", emailVerification.email);
            sqlCmd.Parameters.AddWithValue("@paraExpire", emailVerification.expire);
            sqlCmd.Parameters.AddWithValue("@paraTimeGenerated", emailVerification.timeGenerated);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            myConn.Close();
        }

        public bool GetVerificationCode(string code)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * From EmailVerification Where emailVerificationCode = @paraCode AND expire = 0";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraCode", code);

            DataSet ds = new DataSet();
            da.Fill(ds);

            

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string emailVerificationCode = row["emailVerificationCode"].ToString();
                string email = row["email"].ToString();
                bool Expire = Convert.ToBoolean(row["expire"]);
                DateTime timegenerated = Convert.ToDateTime(row["timeGenerated"]);

                EmailVerification currentVerification = new EmailVerification(emailVerificationCode, email, Expire, timegenerated);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateConfirmVerification(string code)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE EmailVerification SET expire = 1 where emailVerificationCode =  @paraCode";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);


            sqlCmd = new SqlCommand(sqlStmt.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraCode", code);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            myConn.Close();


        }

        public string GetEmail(string code)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * From EmailVerification Where emailVerificationCode = @paraCode AND expire = 0";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraCode", code);

            DataSet ds = new DataSet();
            da.Fill(ds);



            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string email = row["email"].ToString();

                return email;
            }
            else
            {
                return null;
            }
        }

        public List<EmailVerification> GetAllVerification()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            String sqlstmt = "SELECT * From EmailVerification ";

            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);


            DataSet ds = new DataSet();
            da.Fill(ds);

            List<EmailVerification> verificationList = new List<EmailVerification>();

            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 0)
            {
                verificationList = null;
            }
            else
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string emailVerificationCode = row["emailVerificationCode"].ToString();
                    string email = row["email"].ToString();
                    bool expire = Convert.ToBoolean(row["expire"]);
                    DateTime timeGenerated = Convert.ToDateTime(row["timeGenerated"]);
                    EmailVerification obj = new EmailVerification(emailVerificationCode, email, expire, timeGenerated);
                    verificationList.Add(obj);
                }
            }
            return verificationList;
        }

        public DateTime GetExpiry(string code)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select timeGenerated From EmailVerification Where emailVerificationCode = @paraCode AND expire = 0";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraCode", code);

            DataSet ds = new DataSet();
            da.Fill(ds);



            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                DateTime timeGenerated = Convert.ToDateTime(row["timeGenerated"]);

                return timeGenerated;
            }
            else
            {
                return DateTime.Now.AddMinutes(60);
            }
        }

        public void ExpireCode(string code)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE EmailVerification SET expire = 1 where emailVerificationCode =  @paraCode";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);


            sqlCmd = new SqlCommand(sqlStmt.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraCode", code);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            myConn.Close();


        }

        public bool GetAccountVerification(string email)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * From EmailVerification Where email = @paraEmail AND expire = 0";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            DataSet ds = new DataSet();
            da.Fill(ds);



            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string emailVerificationCode = row["emailVerificationCode"].ToString();
                bool Expire = Convert.ToBoolean(row["expire"]);
                DateTime timegenerated = Convert.ToDateTime(row["timeGenerated"]);

                EmailVerification currentVerification = new EmailVerification(emailVerificationCode, email, Expire, timegenerated);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ExpireCodeByEmail(string email)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE EmailVerification SET expire = 1 where email =  @paraEmail";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);


            sqlCmd = new SqlCommand(sqlStmt.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraEmail", email);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            myConn.Close();


        }

    }
}