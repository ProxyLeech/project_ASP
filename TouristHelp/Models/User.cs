using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TouristHelp.DAL;

namespace TouristHelp.Models
{
    public class User
    {
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool firstLogin { get; set; }
        public int Count { get; set; }
        public DateTime AccountLockedUntil { get; set; }
        public DateTime LastLoggedIn { get; set; }
        public string logStatus { get; set; }
        public bool email2FAON { get; set; }
        public string email2FACode { get; set; }
        public string token { get; set; }
        public DateTime expiryToken { get; set; }
        public string secretKey { get; set; }


        public User(string name, string email, string pswd)
        {
            UserId = null;
            Name = name;
            Email = email;
            Password = pswd;
        }


        public User(int id, string name, string email)
        {
            UserId = id;
            Name = name;
            Email = email;
        }


        public User(string email, string logstatus)
        {
            Email = email;
            logStatus = logstatus;
        }

        public User(int id, string logstatus)
        {
            UserId = id;
            logStatus = logstatus;
        }



        public User(int id, string name, string email, string pswd)
        {
            UserId = id;
            Name = name;
            Email = email;
            Password = pswd;
        }


  
        public User(int id, bool firstlogin)    
        {
            UserId = id;
            firstLogin = firstlogin;
        }

        public User(int id)
        {
            UserId = id;
        }
        public User(int id, string name, int count, DateTime accountlockeduntil)
        {
            UserId = id;
            Name = name;
            Count = count;
            AccountLockedUntil = accountlockeduntil;
        }
        public static void UpdateUser(User user)
        {
            UserDAO.UpdateUser(user);
        }

        public User(int id, DateTime lastloggedin)
        {
            UserId = id;
            LastLoggedIn = lastloggedin;
        }

        public User(string name, string email, string pswd, string salt)
        {
            UserId = null;
            Name = name;
            Email = email;
            Password = pswd;
            Salt = salt;
        }


        public User(string email)
        {
 
            Email = email;
    
        }

        public User(string name, string email, DateTime lastloggedin, int id)
        {
            Name = name;
            Email = email;
            LastLoggedIn = lastloggedin;
            UserId = id;
        }

    }

    public class TourGuide : User
    {
        public int? TourGuideId { get; set; }
        public string Description { get; set; }
        public string Languages { get; set; }
        public string Credentials { get; set; }
        public string TourGuideImage { get; set; }

        public TourGuide(string name, string email, string pswd, string description, string languages, string credentials, string tourguideimage) : base(name, email, pswd)
        {
            TourGuideId = null;
            Description = description;
            Languages = languages;
            Credentials = credentials;
            TourGuideImage = tourguideimage;
        }
        public TourGuide(int tourguide_id, int user_id, string name, string email, string pswd, string description, string languages, string credentials, string tourguideimage) : base(user_id, name, email, pswd)
        {
            TourGuideId = tourguide_id;
            Description = description;
            Languages = languages;
            Credentials = credentials;
            TourGuideImage = tourguideimage;

        }


        public static List<TourGuide> GetAllTourGuide()
        {
            return TourGuideDAO.SelectAllTourGuides();
        }

        public static List<TourGuide> GetAllTourGuidesByLanguage(string language)
        {
            return TourGuideDAO.SelectTourGuideByLanguage(language);
        }



        public static void UpdateTourGuide(TourGuide tg)
        {
            TourGuideDAO.UpdateTourGuide(tg);
        }

    }

    public class Tourist : User
    {
        public int? TouristId { get; set; }
        public string Nationality { get; set; }

        public Tourist(string name, string email, string pswd, string salt, string nationality) : base(name, email, pswd, salt)
        {
            Nationality = nationality;
        }
        public Tourist(int touristId, int user, string name, string email, string pswd, string nationality) : base(user, name, email, pswd)
        {
            TouristId = touristId;
            Nationality = nationality;
        }

        public Tourist(int touristId, int user, string name, string email, string pswd, bool firstLogin, string nationality) : base(user, firstLogin)
        {
            TouristId = touristId;
            Nationality = nationality;
        }

        public Tourist(string email) : base(email)
        {
            Email = email;
        }
    }
}