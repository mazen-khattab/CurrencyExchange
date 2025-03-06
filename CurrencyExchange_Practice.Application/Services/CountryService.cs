using CurrencyExchange_Practice.Core.Entities;
using CurrencyExchange_Practice.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Application.Services
{
    public class CountryService
    {
        readonly IUnitOfWork _unitOfWork;

        public CountryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Country>> GetAll(bool track = true) => await _unitOfWork.CountryRepo.GetAll(tracked: track);

        public async Task<IEnumerable<Country>> GetAllCountriesByCode(string code) => await _unitOfWork.CountryRepo.GetAll(country => country.CountryCode.CompareTo(code) == 0);

        public async Task<IEnumerable<Country>> GetAllCountriesPaginated(int pageSize, int pageNumber) => await _unitOfWork.CountryRepo.GetAllCountriesPaginated(pageSize, pageNumber);

        public async Task<Country> GetById(int id, bool track = true) => await _unitOfWork.CountryRepo.GetById(country => country.Id == id, track);

        public async Task<bool> CountryExistsById(int id) => await _unitOfWork.CountryRepo.CountryExistsById(id);

        public async Task AddCountry(Country country)
        {
            await _unitOfWork.CountryRepo.Create(country);
            await _unitOfWork.SaveChanges();
        }

        public async Task UpdateCountry(Country country)
        {
            await _unitOfWork.CountryRepo.Update(country);
            await _unitOfWork.SaveChanges();
        }

        public async Task DeleteCountry(Country country)
        {
            await _unitOfWork.CountryRepo.Remove(country);
            await _unitOfWork.SaveChanges();
        }
    }
}
