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
            // Configuração para a entidade User
            modelBuilder.Entity<User>().HasKey(u => u.Id);

            // Configuração para a entidade Post
            modelBuilder.Entity<Post>().HasKey(p => p.Id);

            modelBuilder.Entity<Post>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Post>()
                .Property(p => p.Content)
                .IsRequired()
                .HasMaxLength(1000); // Adicionado limite de caracteres para o conteúdo

            modelBuilder.Entity<Post>()
                .Property(p => p.CreatedAt)
                .IsRequired();

            // Relacionamento entre Post e User
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User) // Um post tem um autor
                .WithMany(u => u.Posts) // Um usuário pode ter muitos posts
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Se um usuário for deletado, seus posts serão removidos

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=localhost;Database=BASE;User Id=sa;Password=Bkur6etc@10;TrustServerCertificate=True;",
                    b => b.MigrationsAssembly("SocialHubAPI") // Ajuste para o assembly correto do projeto
                );
            }
        }
    }
}
