using AutoMapper;
using CurrencyExchange_Practice.Core.DTOs.Currency;
using CurrencyExchange_Practice.Core.DTOs.NewFolder;
using CurrencyExchange_Practice.Core.DTOs.Rate;
using CurrencyExchange_Practice.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange_Practice.Infrasturcture.Mappers
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Currency, CurrencyDTO>().ReverseMap();
            CreateMap<ExchangeRate, ExchangeRateDTO>().ReverseMap();
        }
    }
}
