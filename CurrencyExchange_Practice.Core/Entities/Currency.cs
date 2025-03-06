using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CurrencyExchange_Practice.Core.Entities
{
    public class Currency : BaseEntity
    {
        [MinLength(2)]
        public string CurrencyName { get; set; } = null!;

        [MinLength(2)]
        public string CurrencyCode { get; set; } = null!;

        [JsonIgnore]
        public ICollection<Country>? Countries { get; set; }
        [JsonIgnore]
        public ICollection<ExchangeRate>? Rates { get; set; }
    }
}
