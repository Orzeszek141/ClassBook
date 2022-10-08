using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassBook.BLL.DTOs;
using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.Domain.Entities;

namespace ClassBook.BLL.IServices;

public interface IUserService : IGenericService<User, UserResponseDto, UserRequestDto>
{
    Task<IEnumerable<UserResponseDto>> GetUsersSortedByLastNameAsync();
    
    Task<UserResponseDto> GetByEmail(string email);
}