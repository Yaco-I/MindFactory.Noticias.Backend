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
    private readonly ICategoriaService _categoriaService;

    public NoticiaService(IRepository<Noticia, NoticiasDbContext> repository, INoticiaRepository noticiaRepository, ICategoriaService categoriaService)
    {
        _genericRepository = repository;
        _noticiaRepository = noticiaRepository;
        _categoriaService = categoriaService;
    }

    public async Task<PagedResult<Noticia>> GetAllAsync(int pageIndex, int pageSize)
    {
        return await _genericRepository.PaginedSearchAsync(x => x.Publicada == true, pageIndex:pageIndex, pageSize:pageSize, x => x.Categoria);
    }

    public async Task<Noticia?> GetByIdAsync(int id)
    {
        return await _genericRepository.FirstAsync(x => x.Id == id && x.Publicada == true, x => x.Categoria);
    }

    public async Task<Noticia> CreateAsync(Noticia noticia)
    {
        ValidarCategoria(noticia);
        ValidarURL(noticia);

        return await _genericRepository.InsertAsync(noticia);
    }

    public async Task<Noticia?> UpdateAsync(Noticia noticia)
    {
        ValidarCategoria(noticia);
        ValidarURL(noticia);
        
        return await _genericRepository.UpdateAsync(noticia);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _genericRepository.DeleteAsync(id);
    }

    public async Task<PagedResult<NoticiaSearchDto>> SearchNoticias(NoticiaSearchFilter noticiaSearchFilter)
    {
        return await _noticiaRepository.SearchNoticias(noticiaSearchFilter);
    }

    public async void ValidarURL(Noticia noticia)
    {
        var noticiaURL =  await _genericRepository.FirstAsync(x => x.URL == noticia.URL);
        if(noticiaURL?.Id != noticia.Id)
            throw new ArgumentException("Ya existe una noticia con esta misma URL");
        
    }

    public async void ValidarCategoria(Noticia noticia)
    {
        var categoria = await _categoriaService.GetByIdAsync(noticia.CategoriaId);
        if (categoria is null)
            throw new ArgumentException($"La categoria no existe");
    }

}
