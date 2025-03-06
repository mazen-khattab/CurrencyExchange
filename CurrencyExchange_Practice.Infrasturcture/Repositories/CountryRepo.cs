using CurrencyExchange_Practice.Core.Entities;
using CurrencyExchange_Practice.Core.Interfaces;
using CurrencyExchange_Practice.Infrasturcture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange_Practice.Infrasturcture.Repositories
{
    public class CountryRepo(AppDbContext context) : Repo<Country>(context), ICountryRepo
    {
        public async Task<bool> CountryExistsById(int Id)
        {
            var country = GetById(country => country.Id == Id, false);
            return await country != null;
        }

        public async Task<IEnumerable<Country>> GetAllCountriesPaginated(int pageSize, int pageNumber)
        {
            var countries = _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return await countries;
        }
    }
}
