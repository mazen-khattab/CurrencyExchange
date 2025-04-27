using CurrencyExchange_Practice.Core.Entities;
using CurrencyExchange_Practice.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Application.Services
{
    public class CurrencyService : Service<Currency>, ICurrencyService
    {
        public CurrencyService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<IEnumerable<Currency>> GetCurrencyByCode(string code) => await _unitOfWork.CurrencyRepo.GetAll(currency => currency.CurrencyCode == code);

        public async Task<IEnumerable<Currency>> GetAllCurrenciesPaginated (int pageSize, int pageNumber) => await _unitOfWork.CurrencyRepo.GetAllCurrenciesPaginated(pageSize, pageNumber);

        public async Task<Currency> GetCurrencyByCountry(int countryId) => await _unitOfWork.CurrencyRepo.CurrencyByCountryId(countryId);
    }
}
