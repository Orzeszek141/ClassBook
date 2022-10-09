using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ClassBook.Api.Authorization;
using ClassBook.Api.Middlewares;
using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.BLL.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ClassBook.Api.Controllers
{
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOptions<JwtKey> _jwtOptions;

        public LoginController(IUserService userService, IOptions<JwtKey> jwtOptions)
        {
            _userService = userService;
            _jwtOptions = jwtOptions;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        [HttpPost]
        public async Task<TokenDto> Login([FromBody] LoginDto loginDto)
        {
            var tokenDto = await _userService.Login(loginDto, _jwtOptions.Value.Key);
            return tokenDto;
        }
    }
}
