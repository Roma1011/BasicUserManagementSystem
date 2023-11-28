using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection collection)
    {
        collection.AddAutoMapper(Assembly.GetExecutingAssembly());
        collection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        collection.AddMediatR(Assembly.GetExecutingAssembly());
        return collection;
    }
} 