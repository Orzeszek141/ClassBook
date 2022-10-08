using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClassBook.BLL.IServices;
using ClassBook.DAL;
using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;

namespace ClassBook.BLL.Services;

internal class GenericService<T, D, R> : IGenericService<T, D, R> where T : class where D : class where R : class
{
    internal readonly IGenericRepository<T> Repository;
    internal readonly IMapper Mapper;

    public GenericService(IGenericRepository<T> repository, IMapper mapper)
    {
        Repository = repository;
        Mapper = mapper;
    }

    public async Task<IEnumerable<D>> GetAllAsync()
    {
        var list = await Repository.GetAllAsync();
        return Mapper.Map<IEnumerable<D>>(list);
    }

    public async Task<D> GetByIdAsync(int id)
    {
        var o = await Repository.GetByIdAsync(id);
        return Mapper.Map<D>(o);
    }

    public async Task AddAsync(R obj)
    {
        var help = Mapper.Map<T>(obj);
        await Repository.InsertAsync(help);
        await Repository.SaveAsync();
    }

    public async Task UpdateAsync(int id, R obj)
    {
        var help = Mapper.Map<T>(obj);
        await Repository.UpdateAsync(id, help);
        await Repository.SaveAsync();
    }

    public async Task RemoveAsync(int id)
    {
        await Repository.DeleteAsync(id);
        await Repository.SaveAsync();
    }
}