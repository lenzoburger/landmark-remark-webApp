using landmark_remark_API.Data;
using landmark_remark_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace landmark_remark_API.Tests
{
     //Mock LandmarkingContext db extension methods
    public static class DbContextExtensions
    {
        // Seeds data into Mock LandmarkingContext db
        public static void Seed(this LandmarkingContext dbContext)
        {
            // retreive JSON user data
            var userData = System.IO.File.ReadAllText("Data/userData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);

            // Add Users for DbContext instance
            foreach (var user in users)
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);

                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;
                user.Username = user.Username.ToLower();

                dbContext.Add(user);
            }

            dbContext.SaveChanges();
        }

        // Hash seed data passwords
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
    }
}
