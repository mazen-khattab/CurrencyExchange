using CurrencyExchange_Practice.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Core.Interfaces
{
    public interface ICurrencyRepo : IRepo<Currency>
    {
        Task<Currency> CurrencyByCountryId(int countryId);
        Task<IEnumerable<Currency>> GetAllCurrenciesPaginated(int pageSize, int pageNumber);
    }
}
