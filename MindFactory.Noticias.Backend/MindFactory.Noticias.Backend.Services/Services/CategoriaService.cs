using Artifacts.EntityFramework;
using MindFactory.Noticias.Backend.Infrastructure;
using MindFactory.Noticias.Backend.Infrastructure.Entities;
using MindFactory.Noticias.Backend.Infrastructure.ReadModels.NoticiasSearch;
using MindFactory.Noticias.Backend.Services.Contracts.Repositories;
using MindFactory.Noticias.Backend.Services.Contracts.Services;

namespace MindFactory.Noticias.Backend.Services.Services;

public class CategoriaService : ICategoriaService
{
    private readonly IRepository<Categoria,NoticiasDbContext> _genericRepository;
    
    public CategoriaService(IRepository<Categoria, NoticiasDbContext> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<IEnumerable<Categoria>> GetAllAsync()
    {
        return await _genericRepository.GetAllAsync();
    }

    public async Task<Categoria?> GetByIdAsync(int id)
    {
        return await _genericRepository.FirstAsync(x => x.Id == id);
    }

    public async Task<Categoria> CreateAsync(Categoria categoria)
    {
        return await _genericRepository.InsertAsync(categoria);
    }

    public async Task<Categoria?> UpdateAsync(Categoria categoria)
    {
        return await _genericRepository.UpdateAsync(categoria);
    }
    public async Task<bool> DeleteAsync(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    
}
