using System.Data;
using System.Security.Principal;
using Artifacts.EntityFramework;
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

    public async Task<PagedResult<NoticiaSearchDto>> SearchNoticias(NoticiaSearchFilter noticiaSearchFilter)
    {

        var tituloParam = new SqlParameter("@Titulo", (object?)noticiaSearchFilter.Titulo ?? DBNull.Value);
        var contenidoParam = new SqlParameter("@Contenido", (object?)noticiaSearchFilter.Contenido ?? DBNull.Value);
        var resumenParam = new SqlParameter("@Resumen", (object?)noticiaSearchFilter.Resumen ?? DBNull.Value);
        var categoriaIdParam = new SqlParameter("@CategoriaId", (object?)noticiaSearchFilter.CategoriaId ?? DBNull.Value);
        var pageNumberParam = new SqlParameter("@PageNumber", (object?)noticiaSearchFilter.PageIndex ?? DBNull.Value);
        var pageSizeParam = new SqlParameter("@PageSize", (object?)noticiaSearchFilter.PageSize ?? DBNull.Value);

        var totalRecordsParam = new SqlParameter
        {
            ParameterName = "@TotalNumberRows",
            SqlDbType = SqlDbType.BigInt,
            Direction = ParameterDirection.Output
        };

        var noticias = await _noticiasDbContext.NoticiasSearch
            .FromSqlRaw("EXEC [dbo].[S_SearchNoticias] @Titulo, @Contenido, @Resumen, @CategoriaId, @PageNumber, @PageSize, @TotalNumberRows OUTPUT",
                tituloParam, contenidoParam, resumenParam, categoriaIdParam, pageNumberParam, pageSizeParam, totalRecordsParam)
            .ToListAsync();

        var total = (long)totalRecordsParam.Value;

        return new PagedResult<NoticiaSearchDto>
        {
            PageIndex = noticiaSearchFilter.PageIndex ?? 1,
            PageSize = noticiaSearchFilter.PageSize ?? (int)total,
            TotalRecords = (int)total,
            TotalPages = (int)Math.Ceiling(total / (double)(noticiaSearchFilter.PageSize ?? (int)total)),
            Items = noticias
        };



    }

}

