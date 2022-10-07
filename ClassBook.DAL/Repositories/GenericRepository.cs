using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassBook.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ClassBook.DAL.Repositories
{ 
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly MyDbContext Context;
        private readonly DbSet<T> _table;
        public GenericRepository(MyDbContext context)
        {
            this.Context = context;
            _table = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.AsNoTracking().ToListAsync();
        }
        public async Task<T> GetByIdAsync(object id)
        {
            _table.AsNoTracking();
             return await _table.FindAsync(id);
        }
        public async Task InsertAsync(T obj)
        {
           await _table.AddAsync(obj);
        }
        public async Task DeleteAsync(object id)
        {
            var existing = await _table.FindAsync(id);
            _table.Remove(existing);
        }
        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
