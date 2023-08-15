using CleanArchitectureTemplate.Application.Common.Interfaces.Authentication;
using CleanArchitectureTemplate.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureTemplate.Infrastructure;


public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }

}