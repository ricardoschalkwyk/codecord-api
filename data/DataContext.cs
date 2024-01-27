using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore;

namespace codecord_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Server> Server { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => new { u.Id });
            modelBuilder.Entity<User>()
                .HasOne(u => u.Server)
                .WithOne(u => u.User)
                .HasForeignKey<Server>(s => s.UserId)
                .IsRequired(false);

            modelBuilder.Entity<Server>()
                .HasKey(s => new { s.Id });
            modelBuilder.Entity<Server>()
                .HasMany(s => s.Categories)
                .WithOne(s => s.Server)
                .HasForeignKey(s => s.ServerId)
                .IsRequired();

            modelBuilder.Entity<Channel>()
                .HasKey(s => new { s.Id });

            modelBuilder.Entity<Category>()
                .HasKey(s => new { s.Id });
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Channels)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .IsRequired(false);
        }

    }
}
