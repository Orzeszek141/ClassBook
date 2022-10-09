using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassBook.DAL.Repositories;

internal sealed class FaculltyRepository : GenericRepository<Faculty>, IFacultyRepository
{
    public FaculltyRepository(MyDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Faculty>> GetAllFacultiesByCityAsync(string city)
    {
        return await Context.Faculties.AsNoTracking().Where(x => x.City == city).ToListAsync();
    }

    public async Task<Faculty> GetFacultyByFacultyName(string facultyName)
    {
        return await Context.Faculties.AsNoTracking().FirstOrDefaultAsync(x => x.FacultyName == facultyName);
    }
}