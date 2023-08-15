using CleanArchitectureTemplate.Application.Common.Interfaces.Authentication;
using CleanArchitectureTemplate.Application.Common.Interfaces.Services;
using CleanArchitectureTemplate.Infrastructure.Authentication;
using CleanArchitectureTemplate.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureTemplate.Infrastructure;


public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }

}