using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Context;
using MoviesApi.Contracts;

namespace MoviesApi.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly MovieContext context;
    public Repository(MovieContext context)
    {
        this.context = context;
    }

    public void Create(T entity)
    {
        context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        context.Set<T>().Remove(entity);
    }

    public IQueryable<T> Get()
    {
        return context.Set<T>().AsNoTracking();
    }

    public async Task<T> GetById(Expression<Func<T, bool>> predicate)
    {
        return await context.Set<T>().AsNoTracking().SingleOrDefaultAsync(predicate);
    }

    public void Update(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        context.Set<T>().Update(entity);
    }
}
