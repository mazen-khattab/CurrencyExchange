namespace CurrencyExchange_Practice.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepo<T> GetRepo<T>() where T : class;
        ICurrencyRepo CurrencyRepo { get; }
        ICountryRepo CountryRepo { get; }
        IRateRepo RateRepo { get; }
        Task<int> SaveChanges();
    }
}
