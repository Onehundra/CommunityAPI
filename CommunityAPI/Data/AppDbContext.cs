using Microsoft.EntityFrameworkCore;
using CommunityAPI.Models;

namespace CommunityAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
