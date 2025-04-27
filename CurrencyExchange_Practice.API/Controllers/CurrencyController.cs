using AutoMapper;
using CurrencyExchange_Practice.Application.Services;
using CurrencyExchange_Practice.Core.DTOs.Currency;
using CurrencyExchange_Practice.Core.Entities;
using CurrencyExchange_Practice.Core.OtherObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange_Practice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly CurrencyService _currencyService;

        public CurrencyController(CurrencyService currencyService, IMapper mapper)
        {
            _currencyService = currencyService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = $"{StaticUserRoles.ADMIN},{StaticUserRoles.OWNER}, {StaticUserRoles.USER}")]
        public async Task<ActionResult<List<Currency>>> Getall() => Ok(await _currencyService.GetAll());


        [HttpGet("GetCurrencyByCode")]
        [Authorize(Roles = $"{StaticUserRoles.ADMIN},{StaticUserRoles.OWNER}, {StaticUserRoles.USER}")]
        public async Task<ActionResult<IEnumerable<Currency>>> GetCurrencyByCode([FromQuery] string code) => Ok (await _currencyService.GetCurrencyByCode(code));


        [HttpGet("GetAllCurrenciesPaginated")]
        public async Task<ActionResult<IEnumerable<Currency>>> GetAllCountriesPaginated([FromQuery] int pageSize, int pageNumber)
           => Ok(await _currencyService.GetAllCurrenciesPaginated(pageSize, pageNumber));


        [HttpGet("id")]
        [Authorize(Roles = $"{StaticUserRoles.ADMIN},{StaticUserRoles.OWNER}, {StaticUserRoles.USER}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Currency>> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var currency = await _currencyService.GetById(currency => currency.Id == id);

            return currency != null ? Ok(currency) : NotFound();
        }


        [HttpGet("GetCurrencyByCountry")]
        public async Task<ActionResult<Currency>> GetCurrencybyCountryId([FromQuery] int countryId) => Ok(await _currencyService.GetCurrencyByCountry(countryId));


        [HttpPost("create")]
        [Authorize(Roles = $"{StaticUserRoles.ADMIN},{StaticUserRoles.OWNER}")]
        public async Task<ActionResult> Add([FromBody] CurrencyDTO currencyDTO)
        {
            var currency = _mapper.Map<Currency>(currencyDTO);
            await _currencyService.Add(currency);
            return Ok(currency);
        }


        [HttpPut]
        [Route("Update")]
        [Authorize(Roles = $"{StaticUserRoles.ADMIN},{StaticUserRoles.OWNER}")]
        public async Task<ActionResult> Update([FromBody] CurrencyDTO newCurrency, int id)
        {
            var oldCurrency = await _currencyService.GetById(currency => currency.Id == id);

            if (!(oldCurrency is { }))
            {
                return NotFound();
            }

            _mapper.Map(newCurrency, oldCurrency);

            await _currencyService.Update(oldCurrency);

            return Ok(newCurrency);
        }


        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = $"{StaticUserRoles.ADMIN},{StaticUserRoles.OWNER}")]
        public async Task<ActionResult> Delete(int id)
        {
            var currency = await _currencyService.GetById(currency => currency.Id == id, false);

            if (!(currency is { }))
            {
                return NotFound();
            }

            await _currencyService.Delete(currency);

            return Ok();
        }
    }
}
