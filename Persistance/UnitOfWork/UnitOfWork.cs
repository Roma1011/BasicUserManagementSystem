using Domain.Abstractions;
using Domain.Abstractions.IReposiotories;
using Persistance.DatabseContext;
using Persistance.Repositories;

namespace Persistance.UnitOfWorknm;

public class UnitOfWork:IUnitOfWork
{ 
    private readonly UserManagementDbContext _context;
    
    #region Private Fields

    private IUserRepository _userRepository;
    private IUserProfileRepository _userProfileRepository;
    #endregion
    public UnitOfWork(UserManagementDbContext context)
    {
        _context = context;
    }
    
    #region Public Properties
    public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

    public IUserProfileRepository UserProfileRepository =>
        _userProfileRepository ??= new UserProfileRepository(_context);

    #endregion
    
    #region Public Methods

    public Task<int> SaveAsync() => _context.SaveChangesAsync();

    public int Save() => _context.SaveChanges();

    #endregion
}