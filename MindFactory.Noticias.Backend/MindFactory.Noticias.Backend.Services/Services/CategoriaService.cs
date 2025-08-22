using Artifacts.EntityFramework;
using MindFactory.Noticias.Backend.Infrastructure;
using MindFactory.Noticias.Backend.Infrastructure.Entities;
using MindFactory.Noticias.Backend.Services.Contracts;

namespace MindFactory.Noticias.Backend.Services.Services;

public class CategoriaService : ICategoriaService
{
    private readonly IRepository<Categoria,NoticiasDbContext> _repository;

    public CategoriaService(IRepository<Categoria, NoticiasDbContext> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Categoria>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Categoria?> GetByIdAsync(int id)
    {
        return await _repository.FirstAsync(x => x.Id == id);
    }

    public async Task<Categoria> CreateAsync(Categoria categoria)
    {
        return await _repository.InsertAsync(categoria);
    }

    public async Task<Categoria?> UpdateAsync(Categoria categoria)
    {
        return await _repository.UpdateAsync(categoria);
    }
    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
