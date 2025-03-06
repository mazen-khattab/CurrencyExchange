namespace CurrencyExchange_Practice.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICurrencyRepo CurrencyRepo { get; }
        ICountryRepo CountryRepo { get; }
        IRateRepo RateRepo { get; }
        Task<int> SaveChanges();
    }
}
