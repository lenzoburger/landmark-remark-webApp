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

        public Task<User> Login(string username, string password)
        {
            throw new System.NotImplementedException();
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

        private void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
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
    }
}