using landmark_remark_API.Models;
using Microsoft.EntityFrameworkCore;

namespace landmark_remark_API.Data
{
    //db context for LandmarkingRemark database
    public class LandmarkingContext : DbContext
    {
        public LandmarkingContext(DbContextOptions<LandmarkingContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<MarkerNote> MarkerNotes { get; set; }
    }
}