using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.DatabseContext;
using Persistance.Repositories;
using Domain.Abstractions;
using Domain.Abstractions.IReposiotories;
using Microsoft.EntityFrameworkCore;
using Persistance.UnitOfWorknm;

namespace Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddDbContext<UserManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MyLocalConn"));
            });
            collection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            collection.AddScoped<IUnitOfWork, UnitOfWork>();
            collection.AddScoped<IUserRepository, UserRepository>();
            collection.AddScoped<IUserProfileRepository, UserProfileRepository>();
            return collection;
        }
    }
}