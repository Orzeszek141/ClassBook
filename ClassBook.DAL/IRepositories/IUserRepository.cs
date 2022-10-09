using ClassBook.Domain.Entities;

namespace ClassBook.DAL.IRepositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<IEnumerable<User>> GetAllUsersSortedByLastNameAsync();
    Task<User> GetUserByEmail(string email);
    Task<(User, Class)> GetStudentAndClass(string studentEmail, int classId);
}