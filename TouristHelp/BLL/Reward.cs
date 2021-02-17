using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristHelp.DAL;

namespace TouristHelp.BLL
{
    public class Reward
    {

        public int Id { get; set; }
        public int loginCount { get; set; }
        public int loginStreak { get; set; }
        public string loyaltyTier { get; set; }
        public int totalDiscount { get; set; }
        public int bonusCredits { get; set; }
        public string membershipTier { get; set; }
        public int creditBalance { get; set; }
        public int remainBonusDays { get; set; }
        public bool loggedInLog { get; set; }
        public DateTime loggedInDate { get; set; }
        public bool newDateCheck { get; set; }

        public Reward()
        {
        }

        public Reward(int id, int creditbalance)
        {
            this.Id = id;
            this.creditBalance = creditbalance;
        }

        public Reward(int logincount, int loginstreak, string loyaltytier, int totaldiscount, int bonuscredits, string membershiptier, int creditbalance, int remainbonusdays)
        {
            this.loginCount = logincount;
            this.loginStreak = loginstreak;
            this.loyaltyTier = loyaltytier;
            this.totalDiscount = totaldiscount;
            this.bonusCredits = bonuscredits;
            this.membershipTier = membershiptier;
            this.creditBalance = creditbalance;
            this.remainBonusDays = remainbonusdays;
        }
        public Reward(int id, int logincount, int loginstreak, string loyaltytier, int totaldiscount, int bonuscredits, string membershiptier, int creditbalance, int remainbonusdays, DateTime loggedindate)
        {
            this.Id = id;
            this.loginCount = logincount;
            this.loginStreak = loginstreak;
            this.loyaltyTier = loyaltytier;
            this.totalDiscount = totaldiscount;
            this.bonusCredits = bonuscredits;
            this.membershipTier = membershiptier;
            this.creditBalance = creditbalance;
            this.remainBonusDays = remainbonusdays;
            this.loggedInDate = loggedindate;

        }

        public Reward(int id, int logincount, int loginstreak, string loyaltytier, int totaldiscount, int bonuscredits, string membershiptier, int creditbalance, int remainbonusdays, bool loggedinlog, DateTime loggedindate)
        {
            this.Id = id;
            this.loginCount = logincount;
            this.loginStreak = loginstreak;
            this.loyaltyTier = loyaltytier;
            this.totalDiscount = totaldiscount;
            this.bonusCredits = bonuscredits;
            this.membershipTier = membershiptier;
            this.creditBalance = creditbalance;
            this.remainBonusDays = remainbonusdays;
            this.loggedInLog = loggedinlog;
            this.loggedInDate = loggedindate;
        }
        public Reward(int id, int logincount, int loginstreak, string loyaltytier, int totaldiscount, int bonuscredits, string membershiptier, int creditbalance, int remainbonusdays, bool loggedinlog, DateTime loggedindate, bool newdatecheck)
        {
            this.Id = id;
            this.loginCount = logincount;
            this.loginStreak = loginstreak;
            this.loyaltyTier = loyaltytier;
            this.totalDiscount = totaldiscount;
            this.bonusCredits = bonuscredits;
            this.membershipTier = membershiptier;
            this.creditBalance = creditbalance;
            this.remainBonusDays = remainbonusdays;
            this.loggedInLog = loggedinlog;
            this.loggedInDate = loggedindate;
            this.newDateCheck = newdatecheck;
        }

        public Reward GetRewardById(string userId)
        {
            RewardDAO dao = new RewardDAO();
            return dao.SelectByAccount(userId);


        }


        public void nextLogin()
        {

            RewardDAO dao = new RewardDAO();
          
            
        }

        public int UpdateAccount(Reward emp)
        {
            RewardDAO dao = new RewardDAO();
            int result = dao.UpdateCredit(emp);
            return result;
        }

        public void insertNewReward()
        {
            RewardDAO userId = new RewardDAO();
            userId.insertNewReward(this);
        }


        public void updateLoggedIn(int userId, int loginCount, int loginStreak, int creditBalance, int remainBonusDays, bool loggedInLog, DateTime loggedInDate, bool newDateCheck)
        {
            RewardDAO dao = new RewardDAO();
            dao.updateLogIn(userId,loginCount, loginStreak, creditBalance,remainBonusDays, loggedInLog, loggedInDate, newDateCheck);
        }

        public void updateBonus(int userId, int loginStreak, int creditBalance, int remainBonusDays)
        {
            RewardDAO dao = new RewardDAO();
            dao.updateBonus(userId,  loginStreak,  creditBalance, remainBonusDays);
        }

        public void updateLoyaltyBonus(int userId, string loyaltyTier, int bonusCredits)
        {
            RewardDAO dao = new RewardDAO();
            dao.loyaltyBonus(userId, loyaltyTier, bonusCredits);
        }


        public void membershipSubscription(int userId, int totalDiscount, string membershipTier)
        {
            RewardDAO dao = new RewardDAO();
            dao.membershipSubscription(userId, totalDiscount, membershipTier);
        }
    }
}