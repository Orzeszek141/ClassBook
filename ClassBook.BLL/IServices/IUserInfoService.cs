using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.Domain.Entities;

namespace ClassBook.BLL.IServices;

public interface IUserInfoService : IGenericService<UserInfo, UserInfoResponseDto, UserInfoUpdateDto>
{
    Task<OldestDto> FindAndGetTheOldestUserAsync();
    Task AddAsync(UserInfoAddDto obj);
}