namespace MindFactory.Noticias.Backend.Infrastructure.ReadModels.NoticiasSearch;

public class NoticiaSearchFilter()
{
    public string? Titulo { get; set; }
    public string? Contenido { get; set; }
    public string? Resumen { get; set; }
    public int? CategoriaId { get; set; }
}
