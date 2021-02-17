using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace TouristHelp.BLL
{
    public static class SHA256Hash
    {
        public static string GenerateSHA256(string raw)
        {
            using(SHA256 hash = SHA256.Create())
            {
                byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(raw));
                StringBuilder str = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    str.Append(bytes[i].ToString("x2"));
                }

                return str.ToString();
            }
        }
    }
}