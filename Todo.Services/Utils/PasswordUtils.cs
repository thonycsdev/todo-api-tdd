using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Utils
{
    public static class PasswordUtils
    {
        public static string GeneratePassword(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                             .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string CryptPassword(this string input)
        {

            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Password cannot be null or empty");
            using SHA256 sha256 = SHA256.Create();
            Console.WriteLine(input);
            byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(bytes);
        }
    }
}
