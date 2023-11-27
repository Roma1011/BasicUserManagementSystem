using System.Linq.Expressions;

namespace Domain.Abstractions;

public interface IGenericRepository<TEntity>
{
    IQueryable<TEntity> Set { get; }
    TEntity? Get(Expression<Func<TEntity, bool>> expression);
    TEntity? GetAsNoTracking(Expression<Func<TEntity, bool>> expression);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
    Task<TEntity?> GetAsNoTrackingAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
    TEntity First(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
    void Add(TEntity entity);
    ValueTask AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    void Update(TEntity entity);
    ValueTask UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
    ValueTask<TEntity?> FindAsync(object id, CancellationToken cancellationToken = default);
}