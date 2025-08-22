using MindFactory.Noticias.Backend.Infrastructure.Entities;
using MindFactory.Noticias.Backend.Infrastructure.ReadModels.NoticiasSearch;

namespace MindFactory.Noticias.Backend.Services.Contracts.Services;
public interface INoticiaService
{
    Task<IEnumerable<Noticia>> GetAllAsync();
    Task<Noticia?> GetByIdAsync(int id);
    Task<Noticia> CreateAsync(Noticia noticia);
    Task<Noticia?> UpdateAsync(Noticia noticia);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<NoticiaSearchDto>> SearchNoticias(NoticiaSearchFilter noticiaSearchFilter);
}