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

    public async Task<(User, Class)> GetStudentAndClass(string studentEmail, int classId)
    {
        var user = await Context.Users.Include(x => x.Classes).FirstOrDefaultAsync(x => x.Email == studentEmail);
        var clas = await Context.Classes.Include(x => x.Users).FirstOrDefaultAsync(x => x.Id == classId);

        return (user, clas);
    }
}