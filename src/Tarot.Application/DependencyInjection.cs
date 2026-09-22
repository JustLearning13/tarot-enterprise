using Microsoft.Extensions.DependencyInjection;
using Tarot.Application.Services;

namespace Tarot.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<DeckService>();

        return services;
    }
}
