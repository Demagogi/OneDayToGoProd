using Microsoft.EntityFrameworkCore;
using OneDayToGoProd.Domain.Models;

namespace OneDayToGoProd.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
