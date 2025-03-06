using System.Linq.Expressions;

namespace CurrencyExchange_Practice.Core.Interfaces
{
    public interface IRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null!, bool tracked = true, params Expression<Func<T, object>>[] includes);
        Task<T?> GetById(Expression<Func<T, bool>> filter = null!, bool tracked = true, params Expression<Func<T, object>>[] includes);
        Task Create(T entity);
        Task Update(T entity);
        Task Remove(T entity);
    }
}
