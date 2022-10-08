using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassBook.Domain.Entities;

namespace ClassBook.BLL.IServices;

public interface IFacultyService : IGenericService<Faculty>
{
    Task<IEnumerable<Faculty>> GetFacultiesByCityAsync(string city);
}