using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassBook.BLL.IServices;
using ClassBook.DAL.IRepositories;

namespace ClassBook.BLL.Services;

internal class GenericService<T> : IGenericService<T> where T : class
{
    internal readonly IGenericRepository<T> Repository;
    public GenericService(IGenericRepository<T> repository)
    {
        Repository = repository;
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Repository.GetAllAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await Repository.GetByIdAsync(id);
    }

    public async Task AddAsync(T obj)
    { 
        await Repository.InsertAsync(obj);
        await Repository.SaveAsync();
    }

    public async Task UpdateAsync(T obj)
    {
        await Repository.UpdateAsync(obj);
        await Repository.SaveAsync();
    }

    public async Task RemoveAsync(int id)
    {
        await Repository.DeleteAsync(id);
        await Repository.SaveAsync();
    }
}