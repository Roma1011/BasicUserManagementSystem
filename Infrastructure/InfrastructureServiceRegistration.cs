using Domain.IServices.ISecuriyServices;
using Infrastructure.Security.PasswordService;
using Infrastructure.Security.TokenService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServiceRegistration(this IServiceCollection collection,
        IConfiguration configuration)
    {
        collection.AddScoped<ITokenService, TokenService>();
        collection.AddScoped<IPasswordService, PasswordService>();
        return collection;
    }
}