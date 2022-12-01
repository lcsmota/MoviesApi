using System.Linq.Expressions;

namespace MoviesApi.Contracts;
public interface IRepository<T>
{
    IQueryable<T> Get();
    Task<T> GetById(Expression<Func<T, bool>> predicate);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);

}