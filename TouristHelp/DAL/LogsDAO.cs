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
    public class LogsDAO
    {
        public List<Logs> SelectAll(bool newFirst)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            
            string sqlStmt = "Select * from SecurityLogs";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            DataSet ds = new DataSet();
            
            da.Fill(ds);

            List<Logs> empList = new List<Logs>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int id = int.Parse(row["logId"].ToString());
                string target = row["logTarget"].ToString();
                string type = row["logType"].ToString();
                string content = row["logContent"].ToString();
                DateTime dateTime = DateTime.Parse(row["dateTimeCreated"].ToString());

                Logs obj = new Logs(id, target, type, content, dateTime);
                empList.Add(obj);
            }
            if (newFirst)
            {
                empList.Reverse();
            }
            return empList;
        }

        public List<Logs> SelectFiltered(string paraTarget, string paraType, DateTime? paratime1, DateTime? paratime2, string paraKey, bool newFirst)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "";
            if (!string.IsNullOrWhiteSpace(paraTarget) && !string.IsNullOrWhiteSpace(paraType))
            {
                sqlStmt = "SELECT * FROM SecurityLogs WHERE logTarget = @paraTarget AND logType = @paraType AND logContent LIKE @paraKey";
            }
            else if(!string.IsNullOrWhiteSpace(paraTarget))
            {
                sqlStmt = "SELECT * FROM SecurityLogs WHERE logTarget = @paraTarget AND logContent LIKE @paraKey";
            }
            else if (!string.IsNullOrWhiteSpace(paraType))
            {
                sqlStmt = "SELECT * FROM SecurityLogs WHERE logType = @paraType AND logContent LIKE @paraKey";
            }
            else
            {
                sqlStmt = "SELECT * FROM SecurityLogs WHERE logContent LIKE @paraKey";
            }

            if (paratime1 != null && paratime2 != null)
            {
                sqlStmt += " AND dateTimeCreated >= @paraTime1 AND dateTimeCreated <= @paraTime2";
            }

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraTarget", paraTarget);
            da.SelectCommand.Parameters.AddWithValue("@paraType", paraType);
            da.SelectCommand.Parameters.AddWithValue("@paraKey", "%"+paraKey+"%");
            if (paratime1 != null)
            {
                da.SelectCommand.Parameters.AddWithValue("@paraTime1", paratime1);
                da.SelectCommand.Parameters.AddWithValue("@paraTime2", paratime2);
            }

            DataSet ds = new DataSet();

            da.Fill(ds);

            List<Logs> empList = new List<Logs>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int id = int.Parse(row["logId"].ToString());
                string target = row["logTarget"].ToString();
                string type = row["logType"].ToString();
                string content = row["logContent"].ToString();
                DateTime dateTime = DateTime.Parse(row["dateTimeCreated"].ToString());

                Logs obj = new Logs(id, target, type, content, dateTime);
                empList.Add(obj);
            }
            if (newFirst)
            {
                empList.Reverse();
            }
            return empList;
        }

        public void InsertNewLog(Logs log)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO SecurityLogs (logTarget, logType, logContent, dateTimeCreated) VALUES (@paraTarget, @paraType, @paraContent, @paraDateTime)";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraTarget", log.Target);
            sqlCmd.Parameters.AddWithValue("@paraType", log.Type);
            sqlCmd.Parameters.AddWithValue("@paraContent", log.Content);
            sqlCmd.Parameters.AddWithValue("@paraDateTime", log.DateTime);


            myConn.Open();
            sqlCmd.ExecuteNonQuery();
            myConn.Close();
        }

        public int SelectLogsForChart(string paraType, string paraKey)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT COUNT(LogContent) FROM SecurityLogs WHERE logType = @paraType AND logContent LIKE @paraKey AND dateTimeCreated >= @paraTime1 AND dateTimeCreated <= @paraTime2";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraType", paraType );
            da.SelectCommand.Parameters.AddWithValue("@paraKey", "%" + paraKey + "%");
            da.SelectCommand.Parameters.AddWithValue("@paraTime2", DateTime.Parse(DateTime.Today.ToString("yyyy-MM-dd") + "T23:59:59"));
            da.SelectCommand.Parameters.AddWithValue("@paraTime1", DateTime.Parse(DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd") + "T00:00:00"));

            DataSet ds = new DataSet();

            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;
            
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int count = int.Parse(row[0].ToString());
                return count;
            }
            return 0;
        }
    }
}