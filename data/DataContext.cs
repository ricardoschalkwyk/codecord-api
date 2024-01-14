using Microsoft.EntityFrameworkCore;
using codecord_api.Models;

namespace codecord_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(pc => new { pc.Id });
        }

    }
}
