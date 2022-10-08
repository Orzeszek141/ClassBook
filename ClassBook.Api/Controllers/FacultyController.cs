using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.BLL.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<FacultyResponseDto>> GetAll()
        {
            return await _facultyService.GetAllAsync();
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<FacultyResponseDto> GetById([FromRoute] int id)
        {
            return await _facultyService.GetByIdAsync(id);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] FacultyAddDto faculty)
        {
            await _facultyService.AddAsync(faculty);
            return CreatedAtAction(nameof(GetAll), faculty);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _facultyService.RemoveAsync(id);
            return Ok();
        }

        [HttpPatch("Update")]
        public async Task<IActionResult> Update([FromBody] FacultyUpdateDto faculty)
        {
            await _facultyService.UpdateAsync(faculty);
            return AcceptedAtAction(nameof(GetAll), faculty);
        }

        [HttpGet("GetByCities/{city}")]
        public async Task<IEnumerable<FacultyResponseDto>> GetByCities([FromRoute] string city)
        {
            return await _facultyService.GetFacultiesByCityAsync(city);
        }
    }
}
