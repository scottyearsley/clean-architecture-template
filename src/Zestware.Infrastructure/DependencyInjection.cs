using Microsoft.Extensions.DependencyInjection;
using Zestware.Application.Common.Interfaces;
using Zestware.Infrastructure.Repositories;

namespace Zestware.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IArtistRepository, InMemoryArtistRepository>();
        services.AddSingleton<IAlbumRepository, InMemoryAlbumRepository>();
        return services;
    }
}