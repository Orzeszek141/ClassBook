using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.Domain.Entities;

namespace ClassBook.BLL.IServices;

public interface IClassService : IGenericService<Class, ClassResponseDto, ClassUpdateDto>
{
    Task<IEnumerable<ClassResponseDto>> GetClassesByGivenFloorAsync(int floor);
    Task AddAsync(ClassAddDto obj);
}