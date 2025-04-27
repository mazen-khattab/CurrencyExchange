using AutoMapper;
using CurrencyExchange_Practice.Application.Services;
using CurrencyExchange_Practice.Core.DTOs.NewFolder;
using CurrencyExchange_Practice.Core.Entities;
using CurrencyExchange_Practice.Core.Interfaces;
using CurrencyExchange_Practice.Core.OtherObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CurrencyExchange_Practice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ICountryService _countryService;

        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        [ResponseCache(Duration = 30)]
        [Authorize(Roles = $"{StaticUserRoles.ADMIN},{StaticUserRoles.OWNER}, {StaticUserRoles.USER}")]
        public async Task<ActionResult<Country>> Getall() => Ok(await _countryService.GetAll(tracked: false));


        [HttpGet("GetCountriesByCode")]
        [Authorize(Roles = StaticUserRoles.USER)]
        public async Task<ActionResult<IEnumerable<Country>>> GetAllCountriesByCode(string code) => Ok(await _countryService.GetAllCountriesByCode(code));


        [HttpGet("GetAllCountriesPaginated")]
        public async Task<ActionResult<IEnumerable<Country>>> GetAllCountriesPaginated([FromQuery] int pageSize, int pageNumber)
            => Ok(await _countryService.GetAllCountriesPaginated(pageSize, pageNumber));

        [HttpGet("id")]
        [Authorize(Roles = $"{StaticUserRoles.ADMIN},{StaticUserRoles.OWNER}, {StaticUserRoles.USER}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Country>> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var country = await _countryService.GetById(country => country.Id == id, false);

            return country != null ? Ok(country) : NotFound();
        }


        [HttpPost("create")]
        [Authorize(Roles = $"{StaticUserRoles.ADMIN},{StaticUserRoles.OWNER}")]
        public async Task<ActionResult> Add([FromBody] CountryDTO countryDTO)
        {
            var country = _mapper.Map<Country>(countryDTO);
            await _countryService.Add(country);
            return Ok(country);
        }


        [HttpPut]
        [Route("update")]
        [Authorize(Roles = $"{StaticUserRoles.ADMIN},{StaticUserRoles.OWNER}")]
        public async Task<ActionResult> Update([FromBody] CountryDTO newCountry, int id)
        {
            var oldCountry = await _countryService.GetById(country => country.Id == id);

            if (!(oldCountry is { }))
            {
                return NotFound();
            }

            _mapper.Map(newCountry, oldCountry);

            await _countryService.Update(oldCountry);

            return Ok(newCountry);
        }


        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = $"{StaticUserRoles.ADMIN},{StaticUserRoles.OWNER}")]
        public async Task<ActionResult> Delete(int id)
        {
            var country = await _countryService.GetById(country => country.Id == id, false);

            if (!(country is { }))
            {
                return NotFound();
            }

            await _countryService.Delete(country);

            return Ok();
        }
    }
}
