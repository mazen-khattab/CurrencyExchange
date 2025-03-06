using CurrencyExchange_Practice.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Core.DTOs.Rate
{
    public class ExchangeRateDTO
    {
        public decimal Rate { get; set; }
        public DateOnly Date { get; set; }
        public int? CurrencyId { get; set; }
    }
}
