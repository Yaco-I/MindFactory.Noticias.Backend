using MindFactory.Noticias.Backend.Infrastructure.Entities;

namespace MindFactory.Noticias.Backend.Services.Contracts;
public interface ICategoriaService
{
    Task<IEnumerable<Categoria>> GetAllAsync();
    Task<Categoria?> GetByIdAsync(int id);
    Task<Categoria> CreateAsync(Categoria categoria);
    Task<Categoria?> UpdateAsync( Categoria categoria);
    Task<bool> DeleteAsync(int id);
}