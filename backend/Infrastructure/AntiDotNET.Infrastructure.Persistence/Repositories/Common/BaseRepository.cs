using System.Linq.Expressions;
using AntiDotNET.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace AntiDotNET.Infrastructure.Persistence.Repositories.Common;

public abstract class BaseRepository<TEntity> where TEntity : class, IEntity
{
    public ApplicationDatabaseContext Context { get; }
    private DbSet<TEntity> Entities { get; }
    protected virtual IQueryable<TEntity> Table => Entities;
    protected virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTrackingWithIdentityResolution();

    protected BaseRepository(ApplicationDatabaseContext context)
    {
        Context = context;
        Entities = Context.Set<TEntity>(); // City => Cities
    }

    protected virtual async Task<List<TEntity>> ListAllAsync()
    {
        return await Entities.ToListAsync();
    }

    protected virtual async Task AddAsync(TEntity entity)
    { 
        await Entities.AddAsync(entity);
           
    }

    protected virtual async Task UpdateAsync(
        Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> updateExpression)
    {
        await Entities.ExecuteUpdateAsync(updateExpression);
    }

    protected virtual async Task DeleteAsync(Expression<Func<TEntity,bool>> deleteExpression)
    {
        await Entities.Where(deleteExpression).ExecuteDeleteAsync();
    }
}