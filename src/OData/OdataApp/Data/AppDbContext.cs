using Microsoft.EntityFrameworkCore;
using OdataApp.Data.Models;

namespace OdataApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Id).UseIdentityAlwaysColumn();
            modelBuilder.Entity<Comment>().Property(x => x.Id).UseIdentityAlwaysColumn();
        }
    }
}
