using Domain.Abstractions.IReposiotories;
using Domain.Entities;
using Persistance.DatabseContext;

namespace Persistance.Repositories;

public class UserRepository:GenericRepository<User>,IUserRepository
{
    public UserRepository(UserManagementDbContext context) : base(context)
    { }
}