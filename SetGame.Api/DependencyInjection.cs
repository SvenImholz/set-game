using Microsoft.AspNetCore.Mvc.Infrastructure;

using SetGame.Api.Common.Errors;
using SetGame.Api.Common.Mapping;

namespace SetGame.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, SetProblemDetailsFactory>();
        services.AddMappings();

        return services;
    }
}