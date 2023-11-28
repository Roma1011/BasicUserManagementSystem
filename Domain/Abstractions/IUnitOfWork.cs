using Domain.Abstractions.IReposiotories;

namespace Domain.Abstractions;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IUserProfileRepository UserProfileRepository { get; }
    Task<int> SaveAsync();
    int Save();
}