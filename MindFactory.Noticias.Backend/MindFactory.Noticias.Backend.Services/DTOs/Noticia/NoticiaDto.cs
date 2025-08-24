using MindFactory.Noticias.Backend.Services.DTOs.Categoria;

namespace MindFactory.Noticias.Backend.Services.DTOs.Noticia;

public record NoticiaDto(
    int Id,
    string Titulo,
    string URL,
    string Contenido,
    string? Resumen,
    int CategoriaId,
    string? CategoriaNombre,
    bool Publicada
);
