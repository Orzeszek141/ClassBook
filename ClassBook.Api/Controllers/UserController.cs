using ClassBook.Api.Middlewares;
using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.BLL.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClassBook.Api.Controllers
{
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IEnumerable<UserResponseDto>> GetAll()
        {
            return await _userService.GetAllAsync();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Teacher, Student")]
        [HttpGet("GetById/{id:int}")]
        public async Task<UserResponseDto> GetById([FromRoute] int id)
        {
            return await _userService.GetByIdAsync(id);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [Authorize(Roles = "Teacher")]
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] UserAddDto user)
        {
            await _userService.AddAsync(user);
            return CreatedAtAction(nameof(GetAll), user);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Teacher")]
        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _userService.RemoveAsync(id);
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [Authorize(Roles = "Teacher")]
        [HttpPatch("Update")]
        public async Task<IActionResult> Update([FromBody] UserUpdateDto user)
        {
            await _userService.UpdateAsync(user.Id,user);
            return AcceptedAtAction(nameof(GetByEmail), new { user.Email }, user);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Teacher, Student")]
        [HttpGet("GetByEmail/{email}")]
        public async Task<UserResponseDto> GetByEmail([FromRoute] string email)
        {
            return await _userService.GetByEmail(email);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Teacher, Student")]
        [HttpGet("GetSortedByLastNameAsync")]
        public async Task<IEnumerable<UserResponseDto>> GetSorted()
        {
            return await _userService.GetUsersSortedByLastNameAsync();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize]
        [HttpPost("SaveToClass/{id:int}")]
        public async Task<IActionResult> AddStudentToClass([FromRoute] int id)
        {
            await _userService.AddStudentToClass("string", id); 
            return Ok();
        }
    }
}
