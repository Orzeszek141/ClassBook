using ClassBook.Domain.Entities;

namespace ClassBook.DAL.IRepositories;

public interface IUserInfoRepository : IGenericRepository<UserInfo>
{
    Task<UserInfo> GetTheOldestUserAsync();
    Task<UserInfo> GetUserInfoByPhoneNumber(string phoneNumber);
    Task<bool> IsEmpty();
}