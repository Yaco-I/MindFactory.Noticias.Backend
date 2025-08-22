using Artifacts.EntityFramework;
using MindFactory.Noticias.Backend.Infrastructure;
using MindFactory.Noticias.Backend.Infrastructure.Entities;
using MindFactory.Noticias.Backend.Infrastructure.ReadModels.NoticiasSearch;
using MindFactory.Noticias.Backend.Services.Contracts.Repositories;
using MindFactory.Noticias.Backend.Services.Contracts.Services;

namespace MindFactory.Noticias.Backend.Services.Services;

public class NoticiaService : INoticiaService
{
    private readonly IRepository<Noticia, NoticiasDbContext> _genericRepository;
    private readonly INoticiaRepository _noticiaRepository;

    public NoticiaService(IRepository<Noticia, NoticiasDbContext> repository, INoticiaRepository noticiaRepository)
    {
        _genericRepository = repository;
        _noticiaRepository = noticiaRepository;
    }

    public async Task<IEnumerable<Noticia>> GetAllAsync()
    {
        return await _genericRepository.SearchAsync(x => x.Publicada == true, x => x.Categoria);
    }

    public async Task<Noticia?> GetByIdAsync(int id)
    {
        return await _genericRepository.FirstAsync(x => x.Id == id && x.Publicada == true, x => x.Categoria);
    }

    public async Task<Noticia> CreateAsync(Noticia noticia)
    {
        return await _genericRepository.InsertAsync(noticia);
    }

    public async Task<Noticia?> UpdateAsync(Noticia noticia)
    {
        return await _genericRepository.UpdateAsync(noticia);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<NoticiaSearchDto>> SearchNoticias(NoticiaSearchFilter noticiaSearchFilter)
    {
        return await _noticiaRepository.SearchNoticias(noticiaSearchFilter);
    }
}
