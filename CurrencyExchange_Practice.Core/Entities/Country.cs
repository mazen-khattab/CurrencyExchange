using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Core.Entities
{
    public class Country : BaseEntity
    {
        [MinLength(2)]
        public string CountryName { get; set; } = null!;

        [MinLength(2)]
        public string CountryCode { get; set; } = null!;
        public int? CurrencyId { get; set; }
        public Currency? Currency { get; set; }
    }
}
