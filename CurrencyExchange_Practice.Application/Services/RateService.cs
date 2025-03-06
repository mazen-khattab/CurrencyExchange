using CurrencyExchange_Practice.Core.Entities;
using CurrencyExchange_Practice.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Application.Services
{
    public class RateService
    {
        readonly IUnitOfWork _unitOfWork;

        public RateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ExchangeRate>> GetAll(bool track = true) => await _unitOfWork.RateRepo.GetAll(tracked: track);

        public async Task<ExchangeRate> GetById(int id, bool track = true) => await _unitOfWork.RateRepo.GetById(rate => rate.Id == id, track);

        public async Task AddRate(ExchangeRate rate)
        {
            await _unitOfWork.RateRepo.Create(rate);
            await _unitOfWork.SaveChanges();
        }

        public async Task UpdateRate(ExchangeRate rate)
        {
            await _unitOfWork.RateRepo.Update(rate);
            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteRate(ExchangeRate rate)
        {
            await _unitOfWork.RateRepo.Remove(rate);
            await _unitOfWork.SaveChanges();
        }
    }
}
