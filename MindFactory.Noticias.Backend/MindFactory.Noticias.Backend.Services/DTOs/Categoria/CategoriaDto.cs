namespace MindFactory.Noticias.Backend.Services.DTOs.Categoria;

public record CategoriaDto(
    int Id,
    string Nombre,
    string Slug,
    string? Descripcion
);
