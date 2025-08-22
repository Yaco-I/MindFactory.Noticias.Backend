using MindFactory.Noticias.Backend.Infrastructure.Entities;

namespace MindFactory.Noticias.Backend.Services.Contracts;
public interface INoticiaService
{
    Task<IEnumerable<Noticia>> GetAllAsync();
    Task<Noticia?> GetByIdAsync(int id);
    Task<Noticia> CreateAsync(Noticia noticia);
    Task<Noticia?> UpdateAsync(Noticia noticia);
    Task<bool> DeleteAsync(int id);
}