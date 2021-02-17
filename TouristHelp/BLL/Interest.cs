using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristHelp.DAL;

namespace TouristHelp.BLL
{
    public class Interest
    {
        public string InterestName { get; set; }
        public int userId { get; set; }
        
        public Interest()
        {

        }

        public Interest(string newName, int newUserId)
        {
            InterestName = newName;
            userId = newUserId;
        }

        public void AddInterest()
        {
            InterestDAO dao = new InterestDAO();
            dao.Insert(this);
        }
        public Interest checkInterests(int userId)
        {
            InterestDAO dao = new InterestDAO();
            return dao.SelectInterestById(userId);
        }

        public void RemoveInterest(string interestName, int userId)
        {
            InterestDAO dao = new InterestDAO();
            dao.RemoveInterest(interestName, userId);
        }
    }
}