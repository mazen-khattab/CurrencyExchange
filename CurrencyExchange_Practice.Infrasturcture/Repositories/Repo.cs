using CurrencyExchange_Practice.Core.Interfaces;
using CurrencyExchange_Practice.Infrasturcture.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CurrencyExchange_Practice.Infrasturcture.Repositories
{
    public class Repo<T> : IRepo<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repo(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task Create(T entity) => await _dbSet.AddAsync(entity);

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null!, bool tracked = true, params Expression<Func<T, object>>[] includes)
        {
            var query = tracked ? _dbSet.AsQueryable() : _dbSet.AsQueryable().AsNoTracking();

            if (filter is { })
            {
                query = query.Where(filter);
            }

            if (includes is { } && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T?> GetById(Expression<Func<T, bool>> filter = null!, bool tracked = true, params Expression<Func<T, object>>[] includes)
        {
            var query = tracked ? _dbSet : _dbSet.AsNoTracking();

            if (filter is { })
            {
                query = query.Where(filter);
            }

            if (includes is { } && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task Remove(T team)
        {
            _dbSet.Remove(team);
        }

        public async Task Update(T entity) => _dbSet.Update(entity);
    }
}
