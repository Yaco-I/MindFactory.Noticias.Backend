using Artifacts.EntityFramework;
using MindFactory.Noticias.Backend.Services.Contracts.Repositories;
using MindFactory.Noticias.Backend.Services.Repositories;

namespace MindFactory.Noticias.Backend.Api.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddApplicationRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped<INoticiaRepository, NoticiaRepository>();
        return services;
    }
}
