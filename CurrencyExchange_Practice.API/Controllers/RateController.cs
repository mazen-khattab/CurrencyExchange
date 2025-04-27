using AutoMapper;
using CurrencyExchange_Practice.Application.Services;
using CurrencyExchange_Practice.Core.DTOs.Rate;
using CurrencyExchange_Practice.Core.Entities;
using CurrencyExchange_Practice.Core.OtherObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange_Practice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly RateService _rateService;

        public RateController(RateService rateService, IMapper mapper)
        {
            _rateService = rateService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = $"{StaticUserRoles.ADMIN},{StaticUserRoles.OWNER}, {StaticUserRoles.USER}")]
        public async Task<ActionResult<List<ExchangeRate>>> Getall() => Ok(await _rateService.GetAll());


        [HttpGet("id")]
        [Authorize(Roles = $"{StaticUserRoles.ADMIN},{StaticUserRoles.OWNER}, {StaticUserRoles.USER}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ExchangeRate>> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var rate = await _rateService.GetById(rate => rate.Id == id, false);

            return rate != null ? Ok(rate) : NotFound();
        }


        [HttpPost("create")]
        [Authorize(Roles = $"{StaticUserRoles.ADMIN},{StaticUserRoles.OWNER}")]
        public async Task<ActionResult> Add([FromBody] ExchangeRateDTO rateDTO)
        {
            var rate = _mapper.Map<ExchangeRate>(rateDTO);
            await _rateService.Add(rate);
            return Ok(rate);
        }


        [HttpPut]
        [Route("Update")]
        [Authorize(Roles = $"{StaticUserRoles.ADMIN},{StaticUserRoles.OWNER}")]
        public async Task<ActionResult> Update([FromBody] ExchangeRateDTO newRate, int id)
        {
            var oldRate = await _rateService.GetById(rate => rate.Id == id);

            if (!(oldRate is { }))
            {
                return NotFound();
            }

            _mapper.Map(newRate, oldRate);

            await _rateService.Update(oldRate);

            return Ok(newRate);
        }


        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = $"{StaticUserRoles.ADMIN},{StaticUserRoles.OWNER}"]
        public async Task<ActionResult> Delete(int id)
        {
            var rate = await _rateService.GetById(rate => rate.Id == id, false);

            if (!(rate is { }))
            {
                return NotFound();
            }

            await _rateService.Delete(rate);

            return Ok();
        }
    }
}
