using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassBook.DAL.Repositories;

internal sealed class ClassRepository : GenericRepository<Class>, IClassRepository
{
    public ClassRepository(MyDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Class>> GetAllClassesByFloorAsync(int floor)
    {
        return await Context.Classes.AsNoTracking().Where(c => c.Floor == floor).ToListAsync();
    }

    public async Task<Class> GetClassByClassNumber(string classNumber)
    {
        return await Context.Classes.AsNoTracking().FirstOrDefaultAsync(x => x.ClassNumber == classNumber);
    }

    public Task<IEnumerable<Class>> GetClassesByFacultyId(int facultyId)
    {
        return Task.FromResult(Context.Classes.AsNoTracking().Where(x => x.FacultyId == facultyId).AsEnumerable());
    }
}