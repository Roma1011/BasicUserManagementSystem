using Domain.Abstractions.IReposiotories;
using Domain.Entities;
using Persistance.DatabseContext;

namespace Persistance.Repositories;

public class UserProfileRepository:GenericRepository<UserProfile>,IUserProfileRepository
{
    public UserProfileRepository(UserManagementDbContext context) : base(context)
    { }
}