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
public class ClassController : ControllerBase
{
    private readonly IClassService _classService;

    public ClassController(IClassService classService)
    {
        _classService = classService;
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [AllowAnonymous]
    [HttpGet("GetAll")]
    public async Task<IEnumerable<ClassResponseDto>> GetAll()
    {
        return await _classService.GetAllAsync();
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [Authorize(Roles = "Teacher, Student")]
    [HttpGet("GetById/{id:int}")]
    public async Task<ClassResponseDto> GetById([FromRoute] int id)
    {
        return await _classService.GetByIdAsync(id);
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [Authorize(Roles = "Teacher")]
    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] ClassAddDto clas)
    {
        await _classService.AddAsync(clas);

        return CreatedAtAction(nameof(GetAll), clas);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [Authorize(Roles = "Teacher")]
    [HttpDelete("Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _classService.RemoveAsync(id);

        return Ok();
    }

    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [Authorize(Roles = "Teacher")]
    [HttpPatch("Update")]
    public async Task<IActionResult> Update([FromBody] ClassUpdateDto clas)
    {
        await _classService.UpdateAsync(clas.Id, clas);

        return AcceptedAtAction(nameof(GetAll), clas);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [Authorize]
    [HttpGet("GetByFloor/{floor:int}")]
    public async Task<IEnumerable<ClassResponseDto>> GetByFloor([FromRoute] int floor)
    {
        return await _classService.GetClassesByGivenFloorAsync(floor);
    }
}