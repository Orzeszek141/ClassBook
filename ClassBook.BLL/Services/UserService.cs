using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassBook.BLL.IServices;
using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;

namespace ClassBook.BLL.Services;

internal class UserService : GenericService<User>, IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IGenericRepository<User> repository, IUserRepository userRepository) : base(repository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetUsersSortedByLastNameAsync()
    {
        return await _userRepository.GetAllUsersSortedByLastNameAsync();
    }
}