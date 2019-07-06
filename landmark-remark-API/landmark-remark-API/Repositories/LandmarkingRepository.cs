using System.Threading.Tasks;
using landmark_remark_API.Data;
using landmark_remark_API.Models;
using Microsoft.EntityFrameworkCore;

namespace landmark_remark_API.Repositories
{
    public class LandmarkingRepository : ILandmarkingRepository
    {
        private readonly LandmarkingContext _context;

        public LandmarkingRepository(LandmarkingContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}