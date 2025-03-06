using CurrencyExchange_Practice.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Core.DTOs.Currency
{
    public class CurrencyDTO
    {
        [MinLength(2)]
        public string CurrencyName { get; set; } = null!;

        [MinLength(2)]
        public string CurrencyCode { get; set; } = null!;
    }
}
