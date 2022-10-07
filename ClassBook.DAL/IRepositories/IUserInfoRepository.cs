using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassBook.Domain.Entities;

namespace ClassBook.DAL.IRepositories
{
    public interface IUserInfoRepository : IGenericRepository<UserInfo>
    {
        Task<UserInfo> FindTheOldestUserAsync();
    }
}
