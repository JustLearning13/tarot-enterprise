using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tarot.Domain.Repositories;
using Tarot.Infrastructure.Data;
using Tarot.Infrastructure.Data.Repositories;

namespace Tarot.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TarotDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("TarotDb")));

        services.AddScoped<IDeckRepository, DeckRepository>();
        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<IReadingSessionRepository, ReadingSessionRepository>();
        services.AddScoped<IMusicTrackRepository, MusicTrackRepository>();

        return services;
    }
}
