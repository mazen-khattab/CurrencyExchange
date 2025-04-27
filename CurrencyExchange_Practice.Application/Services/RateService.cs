using CurrencyExchange_Practice.Core.Entities;
using CurrencyExchange_Practice.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Application.Services
{
    public class RateService : Service<ExchangeRate>, IRateService
    {
        public RateService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
