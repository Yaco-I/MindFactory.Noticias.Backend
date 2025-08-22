using Artifacts.EntityFramework;
using MindFactory.Noticias.Backend.Services.Services;
using MindFactory.Noticias.Backend.Services.Contracts.Services;

namespace MindFactory.Noticias.Backend.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoriaService, CategoriaService>();
        services.AddScoped<INoticiaService, NoticiaService>();

        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        return services;
    }
}