using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassBook.Domain.Entities;

namespace ClassBook.DAL.IRepositories
{
    public interface IClassRepository : IGenericRepository<Class>
    {
        Task<IEnumerable<Class>> GetAllClassesByFloorAsync(int floor);
    }
}
