using AutoMapper;
using ClassBook.BLL.Exceptions;
using ClassBook.BLL.IServices;
using ClassBook.DAL.IRepositories;

namespace ClassBook.BLL.Services;

internal class GenericService<T, D, U> : IGenericService<T, D, U> where T : class where D : class where U : class
{
    internal readonly IMapper Mapper;
    internal readonly IGenericRepository<T> Repository;

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

        if (o == null)
            throw new NotFoundException();

        return Mapper.Map<D>(o);
    }

    public async Task UpdateAsync(int id, U obj)
    {
        var o = await Repository.GetByIdAsync(id);

        if (o == null)
            throw new NotFoundException();

        var help = Mapper.Map<T>(obj);

        await Repository.UpdateAsync(help);
        await Repository.SaveAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var o = await Repository.GetByIdAsync(id);

        if (o == null)
            throw new NotFoundException();

        await Repository.DeleteAsync(id);
        await Repository.SaveAsync();
    }
}