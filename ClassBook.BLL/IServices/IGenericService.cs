namespace ClassBook.BLL.IServices;

public interface IGenericService<T, D, A, U> where T : class where D : class where A : class where U : class
{
    Task<IEnumerable<D>> GetAllAsync();
    Task<D> GetByIdAsync(int Id);
    Task AddAsync(A obj);
    Task UpdateAsync(U obj);
    Task RemoveAsync(int id);
}
