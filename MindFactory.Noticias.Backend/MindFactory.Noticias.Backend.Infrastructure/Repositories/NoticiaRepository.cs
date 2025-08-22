using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MindFactory.Noticias.Backend.Infrastructure;
using MindFactory.Noticias.Backend.Infrastructure.Entities;
using MindFactory.Noticias.Backend.Infrastructure.ReadModels.NoticiasSearch;
using MindFactory.Noticias.Backend.Services.Contracts.Repositories;

namespace MindFactory.Noticias.Backend.Services.Repositories;

public class NoticiaRepository : INoticiaRepository
{
    private readonly NoticiasDbContext _noticiasDbContext;
    public NoticiaRepository(NoticiasDbContext noticiasDbContext)
    {
        _noticiasDbContext = noticiasDbContext;
    }

    public async Task<IEnumerable<NoticiaSearchDto>> SearchNoticias(NoticiaSearchFilter noticiaSearchFilter)
    {

        var tituloParam = new SqlParameter("@Titulo", (object?)noticiaSearchFilter.Titulo ?? DBNull.Value);
        var contenidoParam = new SqlParameter("@Contenido", (object?)noticiaSearchFilter.Contenido ?? DBNull.Value);
        var resumenParam = new SqlParameter("@Resumen", (object?)noticiaSearchFilter.Resumen ?? DBNull.Value);
        var categoriaIdParam = new SqlParameter("@CategoriaId", (object?)noticiaSearchFilter.CategoriaId ?? DBNull.Value);

        return await _noticiasDbContext.NoticiasSearch
            .FromSqlRaw("EXEC [dbo].[S_SearchNoticias] @Titulo, @Contenido, @Resumen, @CategoriaId",
                tituloParam, contenidoParam, resumenParam, categoriaIdParam)
            .ToListAsync();

    }

}

