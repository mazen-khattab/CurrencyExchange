using CurrencyExchange_Practice.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Application.Services
{
    public class Service<T> : IService<T> where T : class
    {
        protected IUnitOfWork _unitOfWork;
        protected IRepo<T> _repo;

        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repo = unitOfWork.GetRepo<T>();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null!, bool tracked = true, params Expression<Func<T, object>>[] includes) => await _repo.GetAll(filter, tracked, includes);

        public async Task<T> GetById(Expression<Func<T, bool>> filter = null!, bool tracked = true, params Expression<Func<T, object>>[] includes) => await _repo.GetById(filter, tracked, includes);

        public async Task Add(T entity)
        {
            await _repo.Create(entity);
            await _unitOfWork.SaveChanges();
        }

        public async Task Delete(T entity)
        {
            await _repo.Remove(entity);
            await _unitOfWork.SaveChanges();
        }

        public async Task Update(T entity)
        {
            await _repo.Update(entity);
            await _unitOfWork.SaveChanges();
        }
    }
}
