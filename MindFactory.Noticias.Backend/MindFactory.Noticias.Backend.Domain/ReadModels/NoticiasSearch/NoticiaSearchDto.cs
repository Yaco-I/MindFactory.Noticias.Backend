using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindFactory.Noticias.Backend.Infrastructure.ReadModels.NoticiasSearch;
public class NoticiaSearchDto
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public string? URL { get; set; }
    public string? Contenido { get; set; }
    public string? Resumen { get; set; }
    public bool Publicada { get; set; }
    public int CategoriaId { get; set; }
    public string? CategoriaNombre { get; set; }
}
