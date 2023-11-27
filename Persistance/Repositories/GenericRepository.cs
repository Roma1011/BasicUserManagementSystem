using System.Linq.Expressions;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Persistance.DatabseContext;

namespace Persistance.Repositories;

public class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity : class
{
    private readonly UserManagementDbContext _context;
    private readonly DbSet<TEntity> _set;

    protected GenericRepository(UserManagementDbContext context)
    {
        _context = context;
        _set = _context.Set<TEntity>();
    }
    public IQueryable<TEntity> Set => _set;
    public TEntity? Get(Expression<Func<TEntity, bool>> expression) => _set.FirstOrDefault(expression);

    public TEntity? GetAsNoTracking(Expression<Func<TEntity, bool>> expression) => _set.AsNoTracking().FirstOrDefault(expression);
    public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default) =>
        _set.FirstOrDefaultAsync(expression, cancellationToken);

    public Task<TEntity?> GetAsNoTrackingAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        => _set.AsNoTracking().FirstOrDefaultAsync(expression, cancellationToken);

    public TEntity First(Expression<Func<TEntity, bool>> expression) => _set.First(expression);

    public Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default) =>
        _set.FirstAsync(expression, cancellationToken);
    
    public void Add(TEntity entity) => _set.Add(entity);

    public ValueTask AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _set.AddAsync(entity, cancellationToken);
        return ValueTask.CompletedTask;
    }
    public void Update(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public ValueTask UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression) => _set.Where(expression);

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default) => _set.AnyAsync(expression, cancellationToken);

    public ValueTask<TEntity?> FindAsync(object id, CancellationToken cancellationToken = default) =>
        _set.FindAsync(new[] { id }, cancellationToken: cancellationToken);
}