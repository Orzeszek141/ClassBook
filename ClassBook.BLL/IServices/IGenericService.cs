namespace ClassBook.BLL.IServices;

public interface IGenericService<T, D, R> where T : class where D : class where R : class
{
    Task<IEnumerable<D>> GetAllAsync();
    Task<D> GetByIdAsync(int Id);
    Task AddAsync(R obj);
    Task UpdateAsync(R obj);
    Task RemoveAsync(int id);
}
