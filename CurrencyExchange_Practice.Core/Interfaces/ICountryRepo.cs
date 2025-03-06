using CurrencyExchange_Practice.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Core.Interfaces
{
    public interface ICountryRepo : IRepo<Country>
    {
        Task<bool> CountryExistsById(int Id);
        Task<IEnumerable<Country>> GetAllCountriesPaginated(int pageSize, int pageNumber);
    }
}
