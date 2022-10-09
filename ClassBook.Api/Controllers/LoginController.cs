using System.Text;
using ClassBook.Api.Authorization;
using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.BLL.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ClassBook.Api.Controllers
{
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

        [HttpPost]
        public async Task<TokenDto> Login([FromBody] LoginDto loginDto)
        {
            var tokenDto = await _userService.Login(loginDto, _jwtOptions.Value.Key);

            return tokenDto;
        }
    }
}
