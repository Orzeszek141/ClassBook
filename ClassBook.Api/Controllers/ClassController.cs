using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.BLL.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ClassResponseDto>> GetAll()
        {
            return await _classService.GetAllAsync();
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<ClassResponseDto> GetById([FromRoute] int id)
        {
            return await _classService.GetByIdAsync(id);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] ClassRequestDto clas)
        {
            await _classService.AddAsync(clas);
            return CreatedAtAction(nameof(GetAll),  clas);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _classService.RemoveAsync(id);
            return Ok();
        }

        [HttpPatch("Update/{id:int}")]
        public async Task<IActionResult> Update([FromBody] ClassRequestDto clas, [FromRoute] int id)
        {
            await _classService.UpdateAsync(id, clas);
            return AcceptedAtAction(nameof(GetAll), clas);
        }

        [HttpGet("GetByFloor/{floor:int}")]
        public async Task<IEnumerable<ClassResponseDto>> GetByFloor([FromRoute] int floor)
        {
            return await _classService.GetClassesByGivenFloorAsync(floor);
        }
    }
}
