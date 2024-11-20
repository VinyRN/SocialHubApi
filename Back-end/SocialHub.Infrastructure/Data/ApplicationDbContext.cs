using Microsoft.EntityFrameworkCore;
using SocialHub.Domain.Entities;

namespace SocialHub.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>()
            .HasKey(p => p.Id);

            modelBuilder.Entity<Post>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Post>()
                .Property(p => p.Content)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=localhost;Database=BASE;User Id=sa;Password=Bkur6etc@10;TrustServerCertificate=True;",
                    b => b.MigrationsAssembly("SocialHubAPI") 
                );
            }
        }

    }
}
