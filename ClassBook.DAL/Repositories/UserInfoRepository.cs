using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ClassBook.DAL.IRepositories;
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
}