using WebApi.Models;

using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
