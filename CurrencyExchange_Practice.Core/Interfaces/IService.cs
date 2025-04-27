using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Core.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null!, bool tracked = true, params Expression<Func<T, object>>[] includes);
        Task<T> GetById(Expression<Func<T, bool>> filter = null!, bool tracked = true, params Expression<Func<T, object>>[] includes);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
