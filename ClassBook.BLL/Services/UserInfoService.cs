using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.BLL.IServices;
using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;

namespace ClassBook.BLL.Services;

internal class UserInfoService : GenericService<UserInfo, UserInfoResponseDto, UserInfoAddDto, UserInfoUpdateDto>, IUserInfoService
{
    private readonly IUserInfoRepository _userInfoRepository;
    public UserInfoService(IGenericRepository<UserInfo> repository, IMapper mapper, IUserInfoRepository userInfoRepository) : base(repository, mapper)
    {
        _userInfoRepository = userInfoRepository;
    }

    public async Task<OldestDto> FindAndGetTheOldestUserAsync()
    {
        var oldest = await _userInfoRepository.GetTheOldestUserAsync();
        Mapper.Map<UserResponseDto>(oldest.User);
        return Mapper.Map<OldestDto>(oldest);
    }
}