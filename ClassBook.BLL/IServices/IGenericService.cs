namespace ClassBook.BLL.IServices;

public interface IGenericService<T, D, U> where T : class where D : class where U : class
{
    Task<IEnumerable<D>> GetAllAsync();
    Task<D> GetByIdAsync(int Id);
    Task UpdateAsync(int id, U obj);
    Task RemoveAsync(int id);
}
