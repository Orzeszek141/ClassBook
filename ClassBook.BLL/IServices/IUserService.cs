using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.Domain.Entities;

namespace ClassBook.BLL.IServices;

public interface IUserService : IGenericService<User, UserResponseDto, UserUpdateDto>
{
    Task<IEnumerable<UserResponseDto>> GetUsersSortedByLastNameAsync();
    Task<UserResponseDto> GetByEmail(string email);
    Task AddStudentToClass(string studentEmail, int classId);
    Task AddAsync(UserAddDto obj);
    Task<TokenDto> Login(LoginDto obj, string key);
    new Task UpdateAsync(int id, UserUpdateDto obj);
}