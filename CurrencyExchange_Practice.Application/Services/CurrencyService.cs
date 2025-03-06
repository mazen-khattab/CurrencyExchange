using CurrencyExchange_Practice.Core.Entities;
using CurrencyExchange_Practice.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Application.Services
{
    public class CurrencyService
    {
        readonly IUnitOfWork _unitOfWork;

        public CurrencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Currency>> GetAll(bool track = true) => await _unitOfWork.CurrencyRepo.GetAll(tracked: track);

        public async Task<IEnumerable<Currency>> GetCurrencyByCode(string code) => await _unitOfWork.CurrencyRepo.GetAll(currency => currency.CurrencyCode == code);

        public async Task<IEnumerable<Currency>> GetAllCurrenciesPaginated (int pageSize, int pageNumber) => await _unitOfWork.CurrencyRepo.GetAllCurrenciesPaginated(pageSize, pageNumber);

        public async Task<Currency> GetById(int id, bool track = true) => await _unitOfWork.CurrencyRepo.GetById(curr => curr.Id == id, track);

        public async Task<Currency> GetCurrencyByCountry(int countryId) => await _unitOfWork.CurrencyRepo.CurrencyByCountryId(countryId);

        public async Task AddCurrency(Currency currency)
        {
            await _unitOfWork.CurrencyRepo.Create(currency);
            await _unitOfWork.SaveChanges();
        }

        public async Task UpdateCurrency(Currency currency)
        {
            await _unitOfWork.CurrencyRepo.Update(currency);
            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteCurrency(Currency currency)
        {
            await _unitOfWork.CurrencyRepo.Remove(currency);
            await _unitOfWork.SaveChanges();
        }
    }
}
