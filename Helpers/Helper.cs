using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Tasinmaz.Helpers
{
    public class Helper
    {
        public static string Sifreleme(string sifre)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(sifre));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return sifre = builder.ToString();
            }
        }

        public static string SifreKontrol(string sifre)
        {
            string stregex = @"^[a-zA-Z0-9#?!@$%^&*+./]{8,20}$";
            Regex rgx = new Regex(stregex);
            if (rgx.IsMatch(sifre))
            {
                return sifre;
            }
            else
            {
                return "hata";
            }
        }
    }
}