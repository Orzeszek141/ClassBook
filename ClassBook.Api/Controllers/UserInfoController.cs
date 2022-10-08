using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.BLL.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService _userInfoService;

        public UserInfoController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<UserInfoResponseDto>> GetAll()
        {
            return await _userInfoService.GetAllAsync();
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<UserInfoResponseDto> GetById([FromRoute] int id)
        {
            return await _userInfoService.GetByIdAsync(id);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] UserInfoRequestDto userInfo)
        {
            await _userInfoService.AddAsync(userInfo);
            return CreatedAtAction(nameof(GetAll), userInfo);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _userInfoService.RemoveAsync(id);
            return Ok();
        }

        [HttpPatch("Update/{id:int}")]
        public async Task<IActionResult> Update([FromBody] UserInfoRequestDto userInfo, [FromRoute] int id)
        {
            await _userInfoService.UpdateAsync(id, userInfo);
            return AcceptedAtAction(nameof(GetAll), userInfo);
        }

        [HttpGet("GetOldest")]
        public async Task<OldestDto> GetOldest()
        {
            return await _userInfoService.FindAndGetTheOldestUserAsync();
        }
    }
}
