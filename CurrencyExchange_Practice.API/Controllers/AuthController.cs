using CurrencyExchange_Practice.Core.AuthDtos;
using CurrencyExchange_Practice.Core;
using CurrencyExchange_Practice.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange_Practice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase  
    {
        readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("Adding_Roles")]
        public async Task<ActionResult> SeedRoles()
        {
            var seedRole = await _authService.SeedRolesAsync();

            return Ok(seedRole);
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var register = await _authService.RegisterAsync(registerDto);

            return Ok(register);
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var login = await _authService.LoginAsync(loginDto);

            return Ok(login);
        }


        [HttpPost]
        [Route("make-admin")]
        public async Task<IActionResult> MakeAdmin([FromBody] UpdatePermissionDto updatePermissionDto)
        {
            var makeAdmin = await _authService.MakeAdminAsynce(updatePermissionDto);

            return Ok(makeAdmin);
        }


        [HttpPost]
        [Route("make-owner")]
        public async Task<IActionResult> MakeOwner([FromBody] UpdatePermissionDto updatePermissionDto)
        {
            var makeOwner = await _authService.MakeOwnerAsynce(updatePermissionDto);

            return Ok(makeOwner);
        }
    }
}
