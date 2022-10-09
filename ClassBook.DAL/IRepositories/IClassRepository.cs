using ClassBook.Domain.Entities;

namespace ClassBook.DAL.IRepositories;

public interface IClassRepository : IGenericRepository<Class>
{
    Task<IEnumerable<Class>> GetAllClassesByFloorAsync(int floor);
    Task<Class> GetClassByClassNumber(string classNumber);
    Task<IEnumerable<Class>> GetClassesByFacultyId(int facultyId);
}