using Artifacts.EntityFramework;
using MindFactory.Noticias.Backend.Infrastructure.ReadModels.NoticiasSearch;

namespace MindFactory.Noticias.Backend.Services.Contracts.Repositories;

public interface INoticiaRepository
{
    Task<PagedResult<NoticiaSearchDto>> SearchNoticias(NoticiaSearchFilter noticiaSearchFilter);
}
