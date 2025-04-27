using CurrencyExchange_Practice.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Core.Interfaces
{
    public interface ICountryService : IService<Country> 
    {
        Task<IEnumerable<Country>> GetAllCountriesByCode(string code);
        Task<IEnumerable<Country>> GetAllCountriesPaginated(int pageSize, int pageNumber);
        Task<bool> CountryExistsById(int id);
    }
}
