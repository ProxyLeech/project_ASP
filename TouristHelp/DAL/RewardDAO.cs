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
    public class RewardDAO
    {


        public Reward SelectByAccount(string rewardId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlstmt = "Select * from Reward where user_id = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlstmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", rewardId);

            DataSet ds = new DataSet();
            da.Fill(ds);
            int rec_cnt = ds.Tables[0].Rows.Count;

            Reward td = null;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                int user_id = Convert.ToInt32(row["user_id"]);
                int loginCount  = Convert.ToInt32(row["loginCount"]);
                int loginStreak = Convert.ToInt32(row["loginStreak"]);
                string loyaltyTier = row["loyaltyTier"].ToString();
                int totalDiscount = Convert.ToInt32(row["totalDiscount"]);
                int bonusCredits = Convert.ToInt32(row["bonusCredits"]);
                string membershipTier = row["membershipTier"].ToString();
                int creditBalance = Convert.ToInt32(row["creditBalance"]);
                int remainBonusDays = Convert.ToInt32(row["remainBonusDays"]);
                bool loggedinLog = Convert.ToBoolean(row["loggedInLog"]);
                DateTime loggedInDate = Convert.ToDateTime(row["loggedInDate"]);
                bool newDateCheck = Convert.ToBoolean(row["newDateCheck"]);

                td = new Reward(user_id, loginCount, loginStreak, loyaltyTier,totalDiscount,bonusCredits, membershipTier, creditBalance, remainBonusDays, loggedinLog, loggedInDate, newDateCheck);
            }
            return td;
        }


        //public int Insert(Reward td)
        //{
        //    string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        //    SqlConnection myConn = new SqlConnection(DBConnect);

        //    string sqlStmt = "INSERT INTO Reward (user_id, loginCount, loginStreak, loyaltyTier, " +
        //                            "totalDiscount, bonusCredits,membershipTier,creditBalance,remainBonusDays)" +
        //                     "VALUES (@paraAccount,@paraLoginCount,@paraLoginStreak,@paraLoyaltyTier," +
        //                            "@paraTotalDiscount,@paraBonusCredits,@paraMembershipTier,@paraCreditBalance,@paraRemainBonusDays)";

        //    int result = 0;    // Execute NonQuery return an integer value
        //    SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

        //    sqlCmd.Parameters.AddWithValue("@paraAccount", td.Id);
        //    sqlCmd.Parameters.AddWithValue("@paraLoginCount", td.loginCount);
        //    sqlCmd.Parameters.AddWithValue("@paraLoginStreak", td.loginStreak);
        //    sqlCmd.Parameters.AddWithValue("@paraLoyaltyTier", td.loyaltyTier);
        //    sqlCmd.Parameters.AddWithValue("@paraTotalDiscount", td.totalDiscount);
        //    sqlCmd.Parameters.AddWithValue("@paraBonusCredits", td.bonusCredits);
        //    sqlCmd.Parameters.AddWithValue("@paraMembershipTier", td.membershipTier);
        //    sqlCmd.Parameters.AddWithValue("@paraCreditBalance", td.creditBalance);
        //    sqlCmd.Parameters.AddWithValue("@paraRemainBonusDays", td.remainBonusDays);
       

        //    myConn.Open();
        //    result = sqlCmd.ExecuteNonQuery();

        //    myConn.Close();

        //    return result;
        //}


        public int UpdateCredit(Reward credit)
        {
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Instantiate SqlCommand instance to add record 
            //          with INSERT statement
            string sqlStmt = "UPDATE Reward SET creditBalance = @paraCreditBalance " +
                "where user_id = @paraAccount ";

            sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraCreditBalance", credit.creditBalance);
            sqlCmd.Parameters.AddWithValue("@paraAccount", credit.Id);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }



        public void insertNewReward(Reward newUser)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO Reward (user_id ,loginCount, loginStreak, loyaltyTier, totalDiscount, bonusCredits, membershipTier, creditbalance, remainBonusDays, loggedInLog, loggedInDate,  newDateCheck) " +
                             "VALUES (@paraUser, @paraLoginCount, @paraLoginStreak, @paraLoyaltyTier, @paraTotalDiscount, @paraBonusCredits, @paraMembershipTier, @paraCreditBalance, @paraRemainBonuaDays, @paraloggedinlog, @paraloggedindate, @paranewdatecheck)";


            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);


            sqlCmd.Parameters.AddWithValue("@paraUser", newUser.Id);
            sqlCmd.Parameters.AddWithValue("@paraLoginCount", newUser.loginCount);
            sqlCmd.Parameters.AddWithValue("@paraLoginStreak", newUser.loginStreak);
            sqlCmd.Parameters.AddWithValue("@paraLoyaltyTier", newUser.loyaltyTier);
            sqlCmd.Parameters.AddWithValue("@paraTotalDiscount", newUser.totalDiscount);
            sqlCmd.Parameters.AddWithValue("@paraBonusCredits", newUser.bonusCredits);
            sqlCmd.Parameters.AddWithValue("@paraMembershipTier", newUser.membershipTier);
            sqlCmd.Parameters.AddWithValue("@paraCreditBalance", newUser.creditBalance);
            sqlCmd.Parameters.AddWithValue("@paraRemainBonuaDays", newUser.remainBonusDays);
            sqlCmd.Parameters.AddWithValue("@paraloggedinlog", newUser.loggedInLog);
            sqlCmd.Parameters.AddWithValue("@paraloggedindate", newUser.loggedInDate);
            sqlCmd.Parameters.AddWithValue("@paranewdatecheck", newUser.newDateCheck);

            myConn.Open();

            sqlCmd.ExecuteNonQuery();

            myConn.Close();
        }


        public void updateLogIn(int userId, int loginCount, int loginStreak, int creditBalance, int remainBonusdays, bool loggedInLog, DateTime loggedInDate, bool newDateCheck)
        {

            SqlCommand sqlCmd = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Instantiate SqlCommand instance to add record 
            //          with INSERT statement
            string sqlStmt = "UPDATE Reward SET loginCount = @paralogincount, loginStreak = @paraloginstreak, creditBalance = @paracreditbalance, remainBonusDays = @pararemainbonusdays, loggedInLog = @paraloggedinlog, loggedInDate = @paraloggedindate, newDateCheck = @paranewdatecheck " +
                                "WHERE user_id = @parauserid ";

            sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@parauserid", userId);

            sqlCmd.Parameters.AddWithValue("@paralogincount", loginCount);
            sqlCmd.Parameters.AddWithValue("@paraloginstreak", loginStreak);
            sqlCmd.Parameters.AddWithValue("@paracreditbalance", creditBalance);
            sqlCmd.Parameters.AddWithValue("@pararemainbonusdays", remainBonusdays);

            sqlCmd.Parameters.AddWithValue("@paraloggedinlog", loggedInLog);

            sqlCmd.Parameters.AddWithValue("@paraloggedindate", loggedInDate);
            sqlCmd.Parameters.AddWithValue("@paranewdatecheck", newDateCheck);
            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

        }



        public void updateBonus(int userId, int loginStreak, int creditBalance, int remainBonusDays)
        {

            SqlCommand sqlCmd = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Instantiate SqlCommand instance to add record 
            //          with INSERT statement
            string sqlStmt = "UPDATE Reward SET loginStreak = @paraloginstreak,  creditBalance = @paracreditbalance, remainBonusDays = @remainbonusdays " +
                                "WHERE user_id = @parauserid ";

            sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@parauserid", userId);

            sqlCmd.Parameters.AddWithValue("@paraloginstreak", loginStreak);
            sqlCmd.Parameters.AddWithValue("@paracreditbalance", creditBalance);
            sqlCmd.Parameters.AddWithValue("@remainbonusdays", remainBonusDays);

            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

        }









        public void loyaltyBonus(int userId, string loyaltyTier, int bonusCredits)
        {

            SqlCommand sqlCmd = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Instantiate SqlCommand instance to add record 
            //          with INSERT statement
            string sqlStmt = "UPDATE Reward SET loyaltyTier = @paraloyaltytier, bonusCredits = @parabonuscredits " +
                                "WHERE user_id = @parauserid ";

            sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@parauserid", userId);

            sqlCmd.Parameters.AddWithValue("@paraloyaltytier", loyaltyTier);
            sqlCmd.Parameters.AddWithValue("@parabonuscredits", bonusCredits);
        
            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

        }



        public void membershipSubscription(int userId, int totalDiscount, string membershipTier)
        {

            SqlCommand sqlCmd = new SqlCommand();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Instantiate SqlCommand instance to add record 
            //          with INSERT statement
            string sqlStmt = "UPDATE Reward SET totalDiscount = @paratotaldiscount, membershipTier = @paramembershiptier " +
                                "WHERE user_id = @parauserid ";

            sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@parauserid", userId);

            sqlCmd.Parameters.AddWithValue("@paratotaldiscount", totalDiscount);
            sqlCmd.Parameters.AddWithValue("@paramembershiptier", membershipTier);

            myConn.Open();
            sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

        }


    }
}