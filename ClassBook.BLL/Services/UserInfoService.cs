using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassBook.BLL.IServices;
using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;

namespace ClassBook.BLL.Services;

internal class UserInfoService : GenericService<UserInfo>, IUserInfoService
{
    private readonly IUserInfoRepository _userInfoRepository;
    public UserInfoService(IGenericRepository<UserInfo> repository, IUserInfoRepository userInfoRepository) : base(repository)
    {
        _userInfoRepository = userInfoRepository;
    }

    public async Task<UserInfo> FindAndGetTheOldestUserAsync()
    {
        return await _userInfoRepository.GetTheOldestUserAsync();
    }
}