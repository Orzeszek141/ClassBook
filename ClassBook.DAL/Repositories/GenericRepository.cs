using ClassBook.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ClassBook.DAL.Repositories;

internal class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbSet<T> _table;
    internal readonly MyDbContext Context;

    public GenericRepository(MyDbContext context)
    {
        Context = context;
        _table = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _table.AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        _table.AsNoTracking();
        return await _table.FindAsync(id);
    }

    public async Task InsertAsync(T obj)
    {
        await _table.AddAsync(obj);
    }

    public Task UpdateAsync(T obj)
    {
        Context.ChangeTracker.Clear();

        _table.Attach(obj);
        Context.Entry(obj).State = EntityState.Modified;

        return Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var existing = await _table.FindAsync(id);

        _table.Remove(existing);
    }

    public async Task SaveAsync()
    {
        await Context.SaveChangesAsync();
    }
}