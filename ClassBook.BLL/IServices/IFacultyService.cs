using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.Domain.Entities;

namespace ClassBook.BLL.IServices;

public interface IFacultyService : IGenericService<Faculty, FacultyResponseDto, FacultyUpdateDto>
{
    Task<IEnumerable<FacultyResponseDto>> GetFacultiesByCityAsync(string city);
    Task AddAsync(FacultyAddDto obj);
}