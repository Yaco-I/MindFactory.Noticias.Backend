using Artifacts.EntityFramework;
using MindFactory.Noticias.Backend.Infrastructure.Entities;
using MindFactory.Noticias.Backend.Infrastructure.ReadModels.NoticiasSearch;

namespace MindFactory.Noticias.Backend.Services.Contracts.Services;
public interface INoticiaService
{
    Task<PagedResult<Noticia>> GetAllAsync(int pageIndex, int pageSize);
    Task<Noticia?> GetByIdAsync(int id);
    Task<Noticia> CreateAsync(Noticia noticia);
    Task<Noticia?> UpdateAsync(Noticia noticia);
    Task<bool> DeleteAsync(int id);
    Task<PagedResult<NoticiaSearchDto>> SearchNoticias(NoticiaSearchFilter noticiaSearchFilter);
}