using System.Threading.Tasks;
using landmark_remark_API.Data;
using landmark_remark_API.Models;
using Microsoft.EntityFrameworkCore;

namespace landmark_remark_API.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly LandmarkingContext _context;

        public AuthRepository(LandmarkingContext context)
        {
            _context = context;

        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var userToReturn = await _context.Users.FirstOrDefaultAsync(user => user.Username == username);

            if (userToReturn == null)
            {
                return null;
            }

            if (!VerifyHashedPassword(password, userToReturn.PasswordHash, userToReturn.PasswordSalt))
            {
                return null;
            }

            return userToReturn;
        }

        public async Task<User> RegisterAsync(User user, string password)
        {
            byte[] passwordHash, passwordSalt;

            HashPassword(password, out passwordHash, out passwordSalt);

            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            if (await _context.Users.AnyAsync(user => user.Email == email))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UsernameExistsAsync(string username)
        {
            if (await _context.Users.AnyAsync(user => user.Username == username))
            {
                return true;
            }
            return false;
        }

        private void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

        private bool VerifyHashedPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmacKey = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmacKey.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }
    }
}