namespace ClassBook.BLL.IServices;

public interface IGenericService<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int Id);
    Task AddAsync(T obj);
    Task UpdateAsync(T obj);
    Task RemoveAsync(int id);
}
