using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassBook.Domain.Entities;

namespace ClassBook.DAL.IRepositories
{
    public interface IFacultyRepository : IGenericRepository<Faculty>
    {
        Task<IEnumerable<Faculty>> GetAllFacultiesByCityAsync(string city);
    }
}
