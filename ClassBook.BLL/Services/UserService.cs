using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClassBook.BLL.DTOs;
using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.BLL.IServices;
using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;

namespace ClassBook.BLL.Services;

internal class UserService : GenericService<User,UserResponseDto,UserRequestDto>, IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IGenericRepository<User> repository, IMapper mapper, IUserRepository userRepository) : base(repository, mapper)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserResponseDto>> GetUsersSortedByLastNameAsync()
    {
        var users = await _userRepository.GetAllUsersSortedByLastNameAsync();
        return Mapper.Map<IEnumerable<UserResponseDto>>(users);
    }

    public async Task<UserResponseDto> GetByEmail(string email)
    {
        var user = await _userRepository.GetUserByEmail(email);
        return Mapper.Map<UserResponseDto>(user);
    }
}