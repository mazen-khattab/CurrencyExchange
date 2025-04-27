using CurrencyExchange_Practice.Core.Entities;
using CurrencyExchange_Practice.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Application.Services
{
    public class CountryService : Service<Country>, ICountryService
    {
        public CountryService(IUnitOfWork unitOfWork) : base(unitOfWork) { }


        public async Task<IEnumerable<Country>> GetAllCountriesByCode(string code) => await _unitOfWork.CountryRepo.GetAll(country => country.CountryCode.CompareTo(code) == 0);

        public async Task<IEnumerable<Country>> GetAllCountriesPaginated(int pageSize, int pageNumber) => await _unitOfWork.CountryRepo.GetAllCountriesPaginated(pageSize, pageNumber);

        public async Task<bool> CountryExistsById(int id) => await _unitOfWork.CountryRepo.CountryExistsById(id);
    }
}
