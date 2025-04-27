using CurrencyExchange_Practice.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Core.Interfaces
{
    public interface ICurrencyService : IService<Currency>
    {
        Task<IEnumerable<Currency>> GetCurrencyByCode(string code);
        Task<IEnumerable<Currency>> GetAllCurrenciesPaginated(int pageSize, int pageNumber);
        Task<Currency> GetCurrencyByCountry(int countryId);
    }
}
