using Artifacts.EntityFramework;
using MindFactory.Noticias.Backend.Infrastructure;
using MindFactory.Noticias.Backend.Infrastructure.Entities;
using MindFactory.Noticias.Backend.Services.Contracts;

namespace MindFactory.Noticias.Backend.Services.Services;

public class NoticiaService : INoticiaService
{
    private readonly IRepository<Noticia, NoticiasDbContext> _repository;

    public NoticiaService(IRepository<Noticia, NoticiasDbContext> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Noticia>> GetAllAsync()
    {
        return await _repository.GetAllAsync(x => x.Categoria);
    }

    public async Task<Noticia?> GetByIdAsync(int id)
    {
        return await _repository.FirstAsync(x => x.Id == id, x => x.Categoria);
    }

    public async Task<Noticia> CreateAsync(Noticia noticia)
    {
        return await _repository.InsertAsync(noticia);
    }

    public async Task<Noticia?> UpdateAsync(Noticia noticia)
    {
        return await _repository.UpdateAsync(noticia);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}
