using CurrencyExchange_Practice.Application.Services;
using CurrencyExchange_Practice.Core.Interfaces;
using CurrencyExchange_Practice.Infrasturcture.Mappers;
using CurrencyExchange_Practice.Infrasturcture.Persistence;
using CurrencyExchange_Practice.Infrasturcture.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Infrasturcture.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            // Register DbContext
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IRepo<>), typeof(Repo<>));
            services.AddScoped(typeof(ICountryRepo), typeof(CountryRepo));
            services.AddScoped(typeof(ICurrencyRepo), typeof(CurrencyRepo));
            services.AddScoped(typeof(IRateRepo), typeof(RateRepo));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped<CountryService>();
            services.AddScoped<CurrencyService>();
            services.AddScoped<RateService>();
            services.AddAutoMapper(typeof(MappingConfig));

            return services;
        }
    }
}
