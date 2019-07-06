using landmark_remark_API.Models;
using Microsoft.EntityFrameworkCore;

namespace landmark_remark_API.Data
{
    public class LandmarkingContext : DbContext
    {
        public LandmarkingContext(DbContextOptions<LandmarkingContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}