using CurrencyExchange_Practice.Core.Entities;
using CurrencyExchange_Practice.Core.Interfaces;
using CurrencyExchange_Practice.Infrasturcture.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Infrasturcture.Repositories
{
    public class RateRepo : Repo<ExchangeRate>, IRateRepo
    {
        public RateRepo(AppDbContext context) : base(context) { }
    }
}
