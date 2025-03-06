using CurrencyExchange_Practice.Core.Entities;
using CurrencyExchange_Practice.Core.Interfaces;
using CurrencyExchange_Practice.Infrasturcture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange_Practice.Infrasturcture.Repositories
{
    public class CurrencyRepo(AppDbContext context) : Repo<Currency>(context), ICurrencyRepo
    {
        public async Task<Currency> CurrencyByCountryId(int countryId)
        {
            var currency = await _context.Countries.Where(country => country.Id == countryId)
                .Select(country => country.Currency).FirstOrDefaultAsync();

            return currency;
        }

        public async Task<IEnumerable<Currency>> GetAllCurrenciesPaginated(int pageSize, int pageNumber)
        {
            var currencies = _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return await currencies;
        }
    }
}
