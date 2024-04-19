using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Set.Application.Common.Interfaces.Authentication;
using Set.Application.Common.Interfaces.Persistence;
using Set.Application.Common.Services;
using Set.Infrastructure.Authentication;
using Set.Infrastructure.Persistence;
using Set.Infrastructure.Services;

namespace Set.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICardRepository, CardRepository>();

        return services;
    }
}