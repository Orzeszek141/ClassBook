using ClassBook.Api.Middlewares;
using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.BLL.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClassBook.Api.Controllers;

[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status401Unauthorized)]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status403Forbidden)]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
[Route("api/[controller]")]
[ApiController]
public class FacultyController : ControllerBase
{
    private readonly IFacultyService _facultyService;

    public FacultyController(IFacultyService facultyService)
    {
        _facultyService = facultyService;
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [AllowAnonymous]
    [HttpGet("GetAll")]
    public async Task<IEnumerable<FacultyResponseDto>> GetAll()
    {
        return await _facultyService.GetAllAsync();
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [Authorize(Roles = "Teacher, Student")]
    [HttpGet("GetById/{id:int}")]
    public async Task<FacultyResponseDto> GetById([FromRoute] int id)
    {
        return await _facultyService.GetByIdAsync(id);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [Authorize(Roles = "Teacher")]
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] FacultyAddDto faculty)
    {
        await _facultyService.AddAsync(faculty);

        return CreatedAtAction(nameof(GetAll), faculty);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [Authorize(Roles = "Teacher")]
    [HttpDelete("Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _facultyService.RemoveAsync(id);

        return Ok();
    }

    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [Authorize(Roles = "Teacher")]
    [HttpPatch("Update")]
    public async Task<IActionResult> Update([FromBody] FacultyUpdateDto faculty)
    {
        await _facultyService.UpdateAsync(faculty.Id, faculty);

        return AcceptedAtAction(nameof(GetAll), faculty);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [Authorize]
    [HttpGet("GetByCities/{city}")]
    public async Task<IEnumerable<FacultyResponseDto>> GetByCities([FromRoute] string city)
    {
        return await _facultyService.GetFacultiesByCityAsync(city);
    }
}