using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.BLL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ClassBook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<UserResponseDto>> GetAll()
        {
            return await _userService.GetAllAsync();
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<UserResponseDto> GetById([FromRoute] int id)
        {
            return await _userService.GetByIdAsync(id);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] UserRequestDto user)
        {
            await _userService.AddAsync(user);
            return CreatedAtAction(nameof(GetAll), user);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _userService.RemoveAsync(id);
            return Ok();
        }

        [HttpPatch("Update/{id:int}")]
        public async Task<IActionResult> Update([FromBody] UserRequestDto user, [FromRoute] int id)
        {
            await _userService.UpdateAsync(id,user);
            return AcceptedAtAction(nameof(GetByEmail), new { user.Email }, user);
        }

        [HttpGet("GetByEmail/{email}")]
        public async Task<UserResponseDto> GetByEmail([FromRoute] string email)
        {
            return await _userService.GetByEmail(email);
        }

        [HttpGet("GetSortedByLastNameAsync")]
        public async Task<IEnumerable<UserResponseDto>> GetSorted()
        {
            return await _userService.GetUsersSortedByLastNameAsync();
        }
    }
}
