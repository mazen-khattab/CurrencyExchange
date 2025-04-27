using CurrencyExchange_Practice.Core.Interfaces;
using CurrencyExchange_Practice.Infrasturcture.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Infrasturcture.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context,
            ICurrencyRepo currencyRepo,
            ICountryRepo countryRepo,
            IRateRepo rateRepo) =>
            (_context, CurrencyRepo, CountryRepo, RateRepo) = (context, currencyRepo, countryRepo, rateRepo);

        public ICountryRepo CountryRepo { get; private set; }
        public ICurrencyRepo CurrencyRepo { get; private set; }
        public IRateRepo RateRepo { get; private set; }

        public void Dispose() => _context.Dispose();

        public IRepo<T> GetRepo<T>() where T : class => new Repo<T>(_context);

        public async Task<int> SaveChanges() => await _context.SaveChangesAsync();
    }
}
