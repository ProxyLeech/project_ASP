using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristHelp.DAL;

namespace TouristHelp.BLL
{
    public class EmailVerification
    {

        public string emailVerificationCode { get; set; }
        public string email { get; set; }
        public bool expire { get; set; }
        public DateTime timeGenerated { get; set; }

        public EmailVerification()
        {

        }

        public EmailVerification(string emailverificationcode, string Email, bool Expire, DateTime timegenerated)
        {
            emailVerificationCode = emailverificationcode;
            email = Email;
            expire = Expire;
            timeGenerated = timegenerated;
        }

        public void InsertVerificationCode()
        {
            EmailVerificationDAO verification = new EmailVerificationDAO();
            verification.InsertVerificationCode(this);
        }

        public bool GetVerificationCode(string code)
        {
            EmailVerificationDAO dao = new EmailVerificationDAO();
            return dao.GetVerificationCode(code);
        }

        public bool VerifyVerification(string email)
        {
            EmailVerificationDAO dao = new EmailVerificationDAO();
            return dao.GetAccountVerification(email);
        }

        public void UpdateConfirmVerification(string code)
        {
            EmailVerificationDAO changeStatus = new EmailVerificationDAO();
            changeStatus.UpdateConfirmVerification(code);
        }

        public string GetEmail(string code)
        {
            EmailVerificationDAO dao = new EmailVerificationDAO();
            return dao.GetEmail(code);
        }

        public List<EmailVerification> GetAllCodes()
        {
            EmailVerificationDAO dao = new EmailVerificationDAO();
            return dao.GetAllVerification();
        }

        public DateTime GetExpiry(string code)
        {
            EmailVerificationDAO dao = new EmailVerificationDAO();
            return dao.GetExpiry(code);
        }

        public void UpdateExpireCode(string code)
        {
            EmailVerificationDAO dao = new EmailVerificationDAO();
            dao.ExpireCode(code);
        }

        public void ExpireCodeByEmail(string email)
        {
            EmailVerificationDAO dao = new EmailVerificationDAO();
            dao.ExpireCodeByEmail(email);
        }
    }
}