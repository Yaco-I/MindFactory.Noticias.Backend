using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MindFactory.Noticias.Backend.Infrastructure.Entities;

namespace MindFactory.Noticias.Backend.Infrastructure
{
    public class NoticiasDbContext : IdentityDbContext
    {
        public NoticiasDbContext(DbContextOptions<NoticiasDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Noticia> Noticias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de índices únicos
            modelBuilder.Entity<Categoria>()
                .HasIndex(c => c.Slug)
                .IsUnique();

            modelBuilder.Entity<Noticia>()
                .HasIndex(n => n.URL)
                .IsUnique();

            // Seed de datos
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Categorías
            var categorias = new List<Categoria>
            {
                new() { Id = 1, Nombre = "Tecnología", Slug = "tecnologia", Descripcion = "Noticias sobre el mundo de la tecnología." },
                new() { Id = 2, Nombre = "Deportes", Slug = "deportes", Descripcion = "Noticias deportivas nacionales e internacionales." },
                new() { Id = 3, Nombre = "Economía", Slug = "economia", Descripcion = "Información sobre finanzas y mercados." },
                new() { Id = 4, Nombre = "Salud", Slug = "salud", Descripcion = "Artículos sobre bienestar y salud." },
                new() { Id = 5, Nombre = "Cultura", Slug = "cultura", Descripcion = "Eventos y noticias culturales." },
                new() { Id = 6, Nombre = "Ciencia", Slug = "ciencia", Descripcion = "Descubrimientos y avances científicos." }
            };
            modelBuilder.Entity<Categoria>().HasData(categorias);

            // Seed Noticias
            var noticias = new List<Noticia>
            {
                new() { Id = 1, Titulo = "Nuevo Avance en IA", URL = "#prueba1", Contenido = "Contenido de la noticia sobre IA.", Resumen = "Resumen sobre IA.", CategoriaId = 1, Publicada = true },
                new() { Id = 2, Titulo = "Final del Campeonato", URL = "#prueba2", Contenido = "Contenido de la noticia sobre la final.", Resumen = "Resumen sobre la final.", CategoriaId = 2, Publicada = true },
                new() { Id = 3, Titulo = "Caída de la Bolsa", URL = "#prueba3", Contenido = "Contenido de la noticia sobre la bolsa.", Resumen = "Resumen sobre la bolsa.", CategoriaId = 3, Publicada = false },
                new() { Id = 4, Titulo = "Descubren Nueva Vacuna", URL = "#prueba4", Contenido = "Contenido de la noticia sobre la vacuna.", Resumen = "Resumen sobre la vacuna.", CategoriaId = 4, Publicada = true },
                new() { Id = 5, Titulo = "Exposición de Arte Moderno", URL = "#prueba5", Contenido = "Contenido de la noticia sobre la exposición.", Resumen = "Resumen sobre la exposición.", CategoriaId = 5, Publicada = true },
                new() { Id = 6, Titulo = "Viaje a Marte", URL = "#prueba6", Contenido = "Contenido de la noticia sobre el viaje a Marte.", Resumen = "Resumen sobre el viaje a Marte.", CategoriaId = 6, Publicada = false },
                new() { Id = 7, Titulo = "Lanzamiento Nuevo Smartphone", URL = "#prueba7", Contenido = "Contenido de la noticia sobre el smartphone.", Resumen = "Resumen sobre el smartphone.", CategoriaId = 1, Publicada = true },
                new() { Id = 8, Titulo = "Récord Olímpico", URL = "#prueba8", Contenido = "Contenido de la noticia sobre el récord.", Resumen = "Resumen sobre el récord.", CategoriaId = 2, Publicada = true },
                new() { Id = 9, Titulo = "Impacto de la Inflación", URL = "#prueba9", Contenido = "Contenido de la noticia sobre la inflación.", Resumen = "Resumen sobre la inflación.", CategoriaId = 3, Publicada = true },
                new() { Id = 10, Titulo = "Avances en Genética", URL = "#prueba10", Contenido = "Contenido de la noticia sobre genética.", Resumen = "Resumen sobre genética.", CategoriaId = 6, Publicada = false }
            };
            modelBuilder.Entity<Noticia>().HasData(noticias);
        }
    }
}
