using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristHelp.DAL;

namespace TouristHelp.BLL
{
    public class PasswordHistory
    {
        public int pwId { get; set; }
        public string email { get; set; }
        public string passwordHash { get; set; }
        public string passwordSalt { get; set; }
        public DateTime timeGenerated { get; set; }

        public PasswordHistory()
        {

        }

        public PasswordHistory(string Email, string passwordhash, string passwordsalt, DateTime timegenerated)
        {
            email = Email;
            passwordHash = passwordhash;
            passwordSalt = passwordsalt;
            timeGenerated = timegenerated;
        }

        public void insertPasswordHistory()
        {
            PasswordHistoryDAO dao = new PasswordHistoryDAO();
            dao.InsertPasswordHistory(this);
        }

        public List<PasswordHistory> getAllPasswordByEmail(string email)
        {
            PasswordHistoryDAO dao = new PasswordHistoryDAO();
            return dao.GetAllPassword(email);
        }

        public void deletePassword(string hash)
        {
            PasswordHistoryDAO dao = new PasswordHistoryDAO();
            dao.DeletePassword(hash);
        }
    }
}