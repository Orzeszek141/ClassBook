using ClassBook.Api.Middlewares;
using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.BLL.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassBook.Api.Controllers
{
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService _userInfoService;

        public UserInfoController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IEnumerable<UserInfoResponseDto>> GetAll()
        {
            return await _userInfoService.GetAllAsync();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Teacher, Student")]
        [HttpGet("GetById/{id:int}")]
        public async Task<UserInfoResponseDto> GetById([FromRoute] int id)
        {
            return await _userInfoService.GetByIdAsync(id);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [Authorize(Roles = "Teacher")]
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] UserInfoAddDto userInfo)
        {
            await _userInfoService.AddAsync(userInfo);
            return CreatedAtAction(nameof(GetAll), userInfo);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Teacher")]
        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _userInfoService.RemoveAsync(id);
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [Authorize(Roles = "Teacher")]
        [HttpPatch("Update")]
        public async Task<IActionResult> Update([FromBody] UserInfoUpdateDto userInfo)
        {
            await _userInfoService.UpdateAsync(userInfo.Id, userInfo);
            return AcceptedAtAction(nameof(GetAll), userInfo);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize]
        [HttpGet("GetOldest")]
        public async Task<OldestDto> GetOldest()
        {
            return await _userInfoService.FindAndGetTheOldestUserAsync();
        }
    }
}
