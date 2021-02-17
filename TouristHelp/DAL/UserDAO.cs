using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using TouristHelp.Models;

namespace TouristHelp.DAL
{
    public static class UserDAO
    {
        private static string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public static bool UserWithEmailExists(string email)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * From Users Where email = @paraEmail";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        public static string GetLoginCredentials(string email)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select password From Users Where email = @paraEmail";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                return row["password"].ToString();
            }

            return null;
        }

        //Email Verification / Registration Section
        public static string GetDBPasswordHash(string email)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select password From Users Where email = @paraEmail";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                return row["password"].ToString();
            }

            return null;
        }

        public static string GetDBPasswordSalt(string email)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select salt From Users Where email = @paraEmail";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                return row["salt"].ToString();
            }

            return null;
        }

        public static bool GetUserVerification(int? userId)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * From Users Where user_id = @paraUserId AND verified = 1";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraUserId", userId);

            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }

            return false;
        }








        public static User SelectUserByEmail(string email)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select user_id, name, email, lastLoggedIn From Users Where email = @paraEmail";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string name = row["name"].ToString();
                DateTime lastLoggedIn = DateTime.Parse(row["lastLoggedIn"].ToString());
                int user_id = int.Parse(row["user_id"].ToString());

                User obj = new User(name, email, lastLoggedIn, user_id);
                return obj;
            }
            else
            {
                return null;
            }

        }

        public static void UpdateUser(User user)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Update Users Set logstatus = @paraLogStatus   Where user_id = @paraUser;";

            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);
            cmd.Parameters.AddWithValue("@paraLogStatus", user.logStatus);
            cmd.Parameters.AddWithValue("@paraUser", user.UserId);

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

        public static User CheckUserLocked(string email)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select email, logStatus From Users Where email = @paraEmail";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string logStatus = row["logStatus"].ToString();


                User obj = new User(email, logStatus);
                return obj;
            }
            else
            {
                return null;
            }

        }










        public static void UpdateUserLastLogin(User user)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Update Users Set lastLoggedIn = @paraLastLoggedIn   Where user_id = @paraUser;";

            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);
            cmd.Parameters.AddWithValue("@paraUser", user.UserId);
            cmd.Parameters.AddWithValue("@paraLastLoggedIn", user.LastLoggedIn);


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




        public static User GetCountInfo(string email)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select * From Users Where email = @paraEmail";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            DataSet ds = new DataSet();
            da.Fill(ds);
            User u = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int id = int.Parse(row["user_id"].ToString());
                string name = row["name"].ToString();
                int count = int.Parse(row["failCount"].ToString());
                DateTime accountlockeduntil = DateTime.Parse(row["accountLockedUntil"].ToString());
                u = new User(id, name, count, accountlockeduntil);
                return u;
            }

            return null;
        }

        public static void CounterUpdate(User u)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Update Users Set failCount = @paraCount, accountLockedUntil = @paraAccountLockedUntil Where user_id = @paraUser;";

            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);
            cmd.Parameters.AddWithValue("@paraCount", u.Count);
            cmd.Parameters.AddWithValue("@paraAccountLockedUntil", u.AccountLockedUntil);
            cmd.Parameters.AddWithValue("@paraUser", u.UserId);
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

        public static void UpdateEmailVerification(string email)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Update Users Set verified = 1 Where email = @paraEmail;";

            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);
            cmd.Parameters.AddWithValue("@paraEmail", email);
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
    }


    public static class TourGuideDAO
    {
        private static string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public static List<TourGuide> SelectAllTourGuides()
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select TourGuides.tourguide_id, TourGuides.user_id, Users.name, Users.password, Users.email,  TourGuides.description, TourGuides.languages, TourGuides.credentials, TourGuides.tourguideimage " +
                "From [TourGuides] " +
                "Inner Join [Users] On TourGuides.user_id = Users.user_id";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<TourGuide> userList = new List<TourGuide>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int id = int.Parse(row["tourguide_id"].ToString());
                int user_id = int.Parse(row["user_id"].ToString());
                string name = row["name"].ToString();
                string password = row["password"].ToString();
                string email = row["email"].ToString();
                string desc = row["description"].ToString();
                string languages = row["languages"].ToString();
                string credentials = row["credentials"].ToString();
                string tourguideimage = row["tourguideimage"].ToString();


                TourGuide obj = new TourGuide(id, user_id, name, email, password, desc, languages, credentials, tourguideimage);
                userList.Add(obj);
            }
            return userList;
        }

        public static List<TourGuide> SelectTourGuideByLanguage(string language)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select TourGuides.tourguide_id, TourGuides.user_id, Users.name, Users.password, Users.email,  TourGuides.description, TourGuides.languages, TourGuides.credentials, TourGuides.tourguideimage " +
                "From [TourGuides] " +
                "Inner Join [Users] On TourGuides.user_id = Users.user_id " +
            "Where TourGuides.languages LIKE @paralanguage";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            da.SelectCommand.Parameters.AddWithValue("paralanguage", language);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<TourGuide> userList = new List<TourGuide>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int id = int.Parse(row["tourguide_id"].ToString());
                int user_id = int.Parse(row["user_id"].ToString());
                string name = row["name"].ToString();
                string password = row["password"].ToString();
                string email = row["email"].ToString();
                string desc = row["description"].ToString();
                string languages = row["languages"].ToString();
                string credentials = row["credentials"].ToString();
                string tourguideimage = row["tourguideimage"].ToString();

                TourGuide obj = new TourGuide(id, user_id, name, email, password, desc, languages, credentials, tourguideimage);
                userList.Add(obj);
            }
            return userList;
        }

        public static TourGuide SelectTourGuideById(int id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select TourGuides.tourguide_id, TourGuides.user_id, Users.name, Users.password, Users.email, TourGuides.description, TourGuides.languages, TourGuides.credentials, TourGuides.tourguideimage " +
                "From TourGuides " +
                "Inner Join Users On TourGuides.user_id = Users.user_id Where TourGuides.tourguide_id = @paraId";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id.ToString());

            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int user_id = int.Parse(row["user_id"].ToString());
                string name = row["name"].ToString();
                string password = row["password"].ToString();
                string email = row["email"].ToString();
                string desc = row["description"].ToString();
                string languages = row["languages"].ToString();
                string credentials = row["credentials"].ToString();
                string tourguideimage = row["tourguideimage"].ToString();

                TourGuide obj = new TourGuide(id, user_id, name, email, password, desc, languages, credentials, tourguideimage);
                return obj;
            }
            else
            {
                return null;
            }
        }

        public static TourGuide SelectTourGuideByEmail(string email)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select TourGuides.tourguide_id, TourGuides.user_id, Users.name, Users.password, Users.email, TourGuides.description, TourGuides.languages, TourGuides.credentials, TourGuides.tourguideimage " +
                "From TourGuides " +
                "Inner Join Users On TourGuides.user_id = Users.user_id Where Users.email = @paraEmail";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int id = int.Parse(row["tourguide_id"].ToString());
                int user_id = int.Parse(row["user_id"].ToString());
                string name = row["name"].ToString();
                string password = row["password"].ToString();
                string desc = row["description"].ToString();
                string languages = row["languages"].ToString();
                string credentials = row["credentials"].ToString();
                string tourguideimage = row["tourguideimage"].ToString();


                TourGuide obj = new TourGuide(id, user_id, name, email, password, desc, languages, credentials, tourguideimage);
                return obj;
            }
            else
            {
                return null;
            }
        }

        public static void InsertTourGuide(TourGuide tg)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Insert into Users (password, name, email) Values (@paraPswd, @paraName, @paraEmail); " +
                "Select Cast(scope_identity() as int)";

            SqlCommand cmdUsers = new SqlCommand(sqlStmt, myConn);

            cmdUsers.Parameters.AddWithValue("@paraPswd", tg.Password);
            cmdUsers.Parameters.AddWithValue("@paraName", tg.Name);
            cmdUsers.Parameters.AddWithValue("@paraEmail", tg.Email);

            try
            {
                myConn.Open();
                int user_id = (int)cmdUsers.ExecuteScalar();
                string newStmt = "Insert into TourGuides (user_id, description, languages, credentials, tourguideimage) Values (@paraUser, @paraDesc, @paraLang, @paraCred, @paraImage);";

                SqlCommand cmdTG = new SqlCommand(newStmt, myConn);

                cmdTG.Parameters.AddWithValue("@paraUser", user_id);
                cmdTG.Parameters.AddWithValue("@paraDesc", tg.Description);
                cmdTG.Parameters.AddWithValue("@paraLang", tg.Languages);
                cmdTG.Parameters.AddWithValue("@paraCred", tg.Credentials);
                cmdTG.Parameters.AddWithValue("@paraImage", tg.TourGuideImage);

                cmdTG.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void UpdateTourGuide(TourGuide tg)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Update TourGuides Set description = @paraDesc, languages = @paraLang, credentials = @paraCred, tourguideimage = @paraImage Where tourguide_id = @paraTG; " +
                "Update Users Set name = @paraName, password = @paraPswd, email = @paraEmail Where user_id = @paraUser;";

            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);
            cmd.Parameters.AddWithValue("@paraDesc", tg.Description);
            cmd.Parameters.AddWithValue("@paraLang", tg.Languages);
            cmd.Parameters.AddWithValue("@paraCred", tg.Credentials);
            cmd.Parameters.AddWithValue("@paraImage", tg.TourGuideImage);
            cmd.Parameters.AddWithValue("@paraTG", tg.TourGuideId);
            cmd.Parameters.AddWithValue("@paraName", tg.Name);
            cmd.Parameters.AddWithValue("@paraPswd", tg.Password);
            cmd.Parameters.AddWithValue("@paraEmail", tg.Email);
            cmd.Parameters.AddWithValue("@paraUser", tg.UserId);
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

        public static void InsertImageIntoTG(int tourguide_id, string filename)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            FileInfo file = new FileInfo(filename);
            byte[] btImg = new byte[file.Length];
            FileStream stream = file.OpenRead();
            stream.Read(btImg, 0, btImg.Length);
            stream.Close();

            string sqlstmt = "Insert Into TourGuides (profile_img) Values (@paraImage) Where tourguide_id = @paraID;";
            SqlCommand cmd = new SqlCommand(sqlstmt, myConn);
            SqlParameter imgPara = new SqlParameter("@paraImage", SqlDbType.Image);
            imgPara.Value = btImg;
            cmd.Parameters.Add(imgPara);
            cmd.Parameters.AddWithValue("@paraID", tourguide_id);

            try
            {
                myConn.Open();
                cmd.ExecuteNonQuery();
                myConn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    public static class TouristDAO
    {
        private static string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public static List<Tourist> SelectAllTourists()
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "SELECT Tourists.tourist_id, Tourists.user_id, Users.name, Users.password, Users.email, Users.firstLogin Tourists.nationality " +
                "FROM Tourists " +
                "INNER JOIN Users ON Tourists.user_id = Users.user_id";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            DataSet ds = new DataSet();
            da.Fill(ds);

            List<Tourist> userList = new List<Tourist>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                int id = int.Parse(row["tourist_id"].ToString());
                int user_id = int.Parse(row["user_id"].ToString());
                string name = row["name"].ToString();
                string password = row["password"].ToString();
                string email = row["email"].ToString();
                string nationality = row["nationality"].ToString();
                bool firstLogin = bool.Parse(row["firstlogin"].ToString());
                Console.WriteLine(name);
                Console.WriteLine(password);
                Tourist obj = new Tourist(id, user_id, name, email, password,firstLogin, nationality);
                userList.Add(obj);
            }
            return userList;
        }

        public static Tourist SelectTouristById(int id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select Tourists.tourist_id, Tourists.user_id, Users.name, Users.password, Users.email, Users.firstLogin, Tourists.nationality " +
                "From Tourists " +
                "Inner Join Users On Tourists.user_id = Users.user_id Where Tourists.tourist_id = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id.ToString());

            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int user_id = int.Parse(row["user_id"].ToString());
                string name = row["name"].ToString();
                string password = row["password"].ToString();
                string email = row["email"].ToString();
                 string nationality = row["nationality"].ToString();
                bool firstLogin = bool.Parse(row["firstlogin"].ToString());

                Tourist obj = new Tourist(id, user_id, name, email, password, firstLogin, nationality);
                return obj;
            }
            else
            {
                return null;
            }
        }

        public static Tourist SelectTouristByEmail(string email)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select Tourists.tourist_id, Tourists.user_id, Users.name, Users.password, Users.email, Users.firstLogin, Tourists.nationality " +
                "From Tourists " +
                "Inner Join Users On Tourists.user_id = Users.user_id Where Users.email = @paraEmail";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int id = int.Parse(row["tourist_id"].ToString());
                int user_id = int.Parse(row["user_id"].ToString());
                string name = row["name"].ToString();
                string password = row["password"].ToString();
                string nationality = row["nationality"].ToString();
                bool firstLogin = bool.Parse(row["firstlogin"].ToString());

                Tourist obj = new Tourist(id, user_id, name, email, password,firstLogin, nationality);
                return obj;
            }
            else
            {
                return null;
            }
        }

        public static void InsertTourist(Tourist tourist)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Insert into Users (password, salt, name, email) Values (@paraPswd, @paraSalt, @paraName, @paraEmail); " +
                "Select Cast(scope_identity() as int)";

            SqlCommand cmdUsers = new SqlCommand(sqlStmt, myConn);

            cmdUsers.Parameters.AddWithValue("@paraPswd", tourist.Password);
            cmdUsers.Parameters.AddWithValue("@paraSalt", tourist.Salt);
            cmdUsers.Parameters.AddWithValue("@paraName", tourist.Name);
            cmdUsers.Parameters.AddWithValue("@paraEmail", tourist.Email);

            try
            {
                myConn.Open();
                int user_id = (int)cmdUsers.ExecuteScalar();
                string newStmt = "Insert into Tourists (nationality, user_id) Values (@paraNation, @paraUser);";

                SqlCommand cmdTourists = new SqlCommand(newStmt, myConn);

                cmdTourists.Parameters.AddWithValue("@paraNation", tourist.Nationality);
                cmdTourists.Parameters.AddWithValue("@paraUser", user_id);

                cmdTourists.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void UpdateTourist(Tourist t)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Update Tourists Set nationality = @paraNation Where tourist_id = @paraT; " +
                "Update Users Set name = @paraName, password = @paraPswd, email = @paraEmail Where user_id = @paraUser;";

            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);
            cmd.Parameters.AddWithValue("@paraNation", t.Nationality);
            cmd.Parameters.AddWithValue("@paraT", t.TouristId);
            cmd.Parameters.AddWithValue("@paraName", t.Name);
            cmd.Parameters.AddWithValue("@paraPswd", t.Password);
            cmd.Parameters.AddWithValue("@paraEmail", t.Email);
            cmd.Parameters.AddWithValue("@paraUser", t.UserId);
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

     



        public static bool firstLoginCheck(int? id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select user_id From Users Where firstLogin = 1 AND user_id = @paraid ";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraid", id.ToString());

            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }

            else
            {
                return false;

            }

        }

        public static bool Email2FAON(int? id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select user_id From Users Where email2FAON = 1 AND user_id = @paraid ";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraid", id.ToString());

            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }

            else
            {
                return false;

            }

        }

        public static bool Phone2FAON(int? id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select user_id From Users Where phone2FAON = 1 AND user_id = @paraid ";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraid", id.ToString());

            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }

            else
            {
                return false;

            }

        }

        public static bool Email2FAValidation(string code)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select email2FACode From Users Where email2FACode = @paraemail2facode AND email2FAON = 1";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraemail2facode", code);

            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }

            else
            {
                return false;

            }

        }


        public static bool Phone2FAValidation(string code)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select phone2FACode From Users Where phone2FACode = @paraphone2facode AND phone2FAON = 1";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraphone2facode", code);

            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }

            else
            {
                return false;

            }

        }



        public static int VerifyUserByToken(string code)
        {


            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select user_id From Users Where email2FACode = @paraemail2facode AND email2FAON = 1";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraemail2facode", code);

            DataSet ds = new DataSet();
            User u = null;
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int id = int.Parse(row["user_id"].ToString());

                return id;
            }

            else
            {
                return 0;
            }

        }


        public static void updateFirstLoginCheck(int? id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Update Users Set firstLogin = 0 WHERE user_id = @paraid";

            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);
            cmd.Parameters.AddWithValue("@paraid", id.ToString());

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



        public static void updateEmail2FACode(int? id, string code)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Update Users Set email2FACode = @paraemail2facode WHERE user_id = @paraid";

            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);
            cmd.Parameters.AddWithValue("@paraid", id.ToString());
            cmd.Parameters.AddWithValue("@paraemail2facode", code);


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

        public static void updatePhone2FACode(int? id, string code)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Update Users Set phone2FACode = @paraphone2facode WHERE user_id = @paraid";

            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);
            cmd.Parameters.AddWithValue("@paraid", id.ToString());
            cmd.Parameters.AddWithValue("@paraphone2facode", code);


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

        public static void update2FAToken(int? id, string token, DateTime expiryToken)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Update Users Set token = @paratoken , expiryToken = @paraexpiryToken WHERE user_id = @paraid";

            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);
            cmd.Parameters.AddWithValue("@paraid", id.ToString());
            cmd.Parameters.AddWithValue("@paratoken", token);
            cmd.Parameters.AddWithValue("@paraexpiryToken", expiryToken);


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


        public static DateTime tokenTimeValidation(string token)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select expiryToken From Users Where token = @paratoken";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paratoken", token);

            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                DateTime expiryToken = DateTime.Parse(row["expiryToken"].ToString());

                return expiryToken;
            }

            else
            {

                return DateTime.Now;
            }
        }


        //Google authentication 
     

        public static string userIDFromEmail(string email)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select user_id From Users Where email = @paraEmail";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                return row["user_id"].ToString();
            }

            return null;
        }


        public static string findSecretKey(int? id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select secretKey From Users Where user_id = @parauserid";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@parauserid", id);

            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                string getKey = row["secretKey"].ToString();

                return getKey;
            }

            else
            {

                return null;
            }
        }


        //public static void updateSecretKey(int? id)
        //{
        //    SqlConnection myConn = new SqlConnection(DBConnect);

        //    string sqlStmt = "Update Users Set secretKey = @parasecretkey WHERE user_id = @paraid";

        //    SqlCommand cmd = new SqlCommand(sqlStmt, myConn);
        //    cmd.Parameters.AddWithValue("@paraid", id.ToString());

        //    try
        //    {
        //        myConn.Open();
        //        cmd.ExecuteNonQuery();
        //        myConn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //    }
        //}


        public static void updateSecretKeyEmail(string email, string key)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Update Users Set secretKey = @parasecretkey WHERE email = @paraemail";

            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);
            cmd.Parameters.AddWithValue("@paraemail", email);
            cmd.Parameters.AddWithValue("@parasecretkey", key);

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


        public static string selectEmailbyID(int? id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select email From Users Where user_id = @paraid";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraid", id);

            DataSet ds = new DataSet();
            da.Fill(ds);
            string email = "";

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                email = row["email"].ToString();




                return email;
            }
            else
            {
                return null;
            }

        }



        //public static string SelectPhoneById(int? id)
        //{
        //    SqlConnection myConn = new SqlConnection(DBConnect);
        //    string sqlStmt = "Select phone From Users Where user_id = @paraid";
        //    SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
        //    da.SelectCommand.Parameters.AddWithValue("@paraid", id);

        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    string phone = "";

        //    if (ds.Tables[0].Rows.Count == 1)
        //    {
        //        DataRow row = ds.Tables[0].Rows[0];
        //        phone = row["phone"].ToString();
               


                
        //        return phone;
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}


        public static string selectStatus2FAbyID(int? id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select status2FA From Users Where user_id = @paraid";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraid", id);

            DataSet ds = new DataSet();
            da.Fill(ds);
            string status2FA = "";

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                status2FA = row["status2FA"].ToString();




                return status2FA;
            }

            return null;
        }


        public static void update2FAStatusON(int? id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Update Users Set Status2FA = 'ON' Where email2FAON == 1 OR phone2FAON == 1 ";

            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);
            
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

        public static void update2FAStatusOFF(int? id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Update Users Set Status2FA = 'OFF' Where email2FAON == 0 AND phone2FAON == 0 ";

            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);

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

        public static void activateEmail2FA(int? id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Update Users Set email2FAON = 1, status2FA = 'ON' Where user_id = @paraid AND email2FAON = 0 AND phone2FAON = 0 ";

            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);
            cmd.Parameters.AddWithValue("@paraid", id.ToString());
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


        public static void activatePhone2FA(int? id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Update Users Set phone2FAON = 1, status2FA = 'ON' Where user_id = @paraid AND email2FAON = 0 AND phone2FAON = 0 AND phone != '' ";

            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);
            cmd.Parameters.AddWithValue("@paraid", id.ToString());
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



        public static void deactivateEmail2FA(int? id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Update Users Set email2FAON = 0, status2FA = 'OFF' Where user_id = @paraid AND email2FAON = 1 OR phone2FAON = 1 ";

            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);
            cmd.Parameters.AddWithValue("@paraid", id.ToString());
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


        public static void deactivatePhone2FA(int? id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Update Users Set phone2FAON = 0, status2FA = 'OFF' Where user_id = @paraid AND email2FAON = 1 OR phone2FAON = 1 ";

            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);
            cmd.Parameters.AddWithValue("@paraid", id.ToString());
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


        public static string checkEmail2FAON(int? id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select email2FAON From Users Where user_id = @paraid";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraid", id);

            DataSet ds = new DataSet();
            da.Fill(ds);
            string email2FAON = "";

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                email2FAON = row["email2FAON"].ToString();




                return email2FAON;
            }

            return null;
        }

        public static string checkPhone2FAON(int? id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select Phone2FAON From Users Where user_id = @paraid";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraid", id);

            DataSet ds = new DataSet();
            da.Fill(ds);
            string Phone2FAON = "";

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                Phone2FAON = row["Phone2FAON"].ToString();




                return Phone2FAON;
            }

            return null;
        }


        public static string checkPhone(int? id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select phone From Users Where user_id = @paraid";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraid", id);

            DataSet ds = new DataSet();
            da.Fill(ds);
            string phone = "";

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                phone = row["phone"].ToString();




                return phone;
            }

            return null;
        }



        public static string selectAuthStatusById(int? id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select authStatus From Users Where user_id = @paraid";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraid", id);

            DataSet ds = new DataSet();
            da.Fill(ds);
            string authStatus = "";

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                authStatus = row["authStatus"].ToString();




                return authStatus;
            }

            return null;
        }


        public static string getTokenById(int? id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select token From Users Where user_id = @paraid";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraid", id);

            DataSet ds = new DataSet();
            da.Fill(ds);
            string token = "";

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                token = row["token"].ToString();




                return token;
            }

            return null;
        }

        public static void updatePhoneNo(int? id, string phone)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Update Users Set phone = @paraphone WHERE user_id = @paraid";

            SqlCommand cmd = new SqlCommand(sqlStmt, myConn);
            cmd.Parameters.AddWithValue("@paraid", id.ToString());
            cmd.Parameters.AddWithValue("@paraphone", phone.ToString());


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


        public static bool validatePhoneVerification(string code)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "Select phone2FACode From Users Where phone2FACode = @paraphone2facode";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraphone2facode", code);

            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }

            else
            {
                return false;

            }

        }


        public static int getUserIdByTouristId(int id)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select Users.user_id From Users INNER JOIN Tourists ON Users.user_id = Tourists.user_id WHERE Tourists.tourist_id = @paraid";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraid", id);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int userId = 0;

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                userId = int.Parse(row["user_id"].ToString());




                return userId;
            }

            return 0;
        }

        public static string getEmailByToken(string token)
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select email From Users Where token = @paratoken";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paratoken", token);

            DataSet ds = new DataSet();
            da.Fill(ds);
            string getEmail = "";

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                getEmail = row["email"].ToString();




                return getEmail;
            }

            return null;
        }

    }
}