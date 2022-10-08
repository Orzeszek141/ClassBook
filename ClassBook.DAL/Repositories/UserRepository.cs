using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassBook.DAL.Repositories;

internal sealed class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(MyDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<User>> GetAllUsersSortedByLastNameAsync()
    {
        return await Context.Users.AsNoTracking().OrderBy(x => x.LastName).ToListAsync();
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await Context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
    }
}