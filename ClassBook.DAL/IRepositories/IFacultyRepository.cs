using ClassBook.Domain.Entities;

namespace ClassBook.DAL.IRepositories;

public interface IFacultyRepository : IGenericRepository<Faculty>
{
    Task<IEnumerable<Faculty>> GetAllFacultiesByCityAsync(string city);
    Task<Faculty> GetFacultyByFacultyName(string facultyName);
}