using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassBook.DAL.Repositories
{
    internal sealed class FaculltyRepository : GenericRepository<Faculty>, IFacultyRepository 
    {
        public FaculltyRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Faculty>> GetAllFacultiesByCityAsync(string city)
        {
            return await Context.Faculties.AsNoTracking().Where(x => x.City == city).ToListAsync();
        }
    }
}
