﻿using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassBook.DAL.Repositories;

internal sealed class UserInfoRepository : GenericRepository<UserInfo>, IUserInfoRepository
{
    public UserInfoRepository(MyDbContext context) : base(context)
    {
    }

    public async Task<UserInfo> GetTheOldestUserAsync()
    {
        return await Context.UserInfos.AsNoTracking().OrderBy(x => x.BirthDate).Include(y => y.User).FirstAsync();
    }

    public async Task<UserInfo> GetUserInfoByPhoneNumber(string phoneNumber)
    {
        return await Context.UserInfos.AsNoTracking().FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
    }

    public Task<bool> IsEmpty()
    {
        return Task.FromResult(Context.UserInfos.Any());
    }
}