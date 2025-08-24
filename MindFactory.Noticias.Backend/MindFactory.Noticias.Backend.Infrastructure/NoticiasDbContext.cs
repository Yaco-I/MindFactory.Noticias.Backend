using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MindFactory.Noticias.Backend.Infrastructure.Entities;
using MindFactory.Noticias.Backend.Infrastructure.ReadModels.NoticiasSearch;

namespace MindFactory.Noticias.Backend.Infrastructure
{
    public class NoticiasDbContext : IdentityDbContext
    {
        public NoticiasDbContext(DbContextOptions<NoticiasDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<NoticiaSearchDto> NoticiasSearch { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>().ToTable("Categorias");
            modelBuilder.Entity<Noticia>().ToTable("Noticias");

            modelBuilder.Entity<NoticiaSearchDto>().HasNoKey();

            // Configuración de índices únicos
            modelBuilder.Entity<Categoria>()
                .HasIndex(c => c.Slug)
                .IsUnique();

            modelBuilder.Entity<Noticia>()
                .HasIndex(n => n.URL)
                .IsUnique();

        }

        
    }
}
