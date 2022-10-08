using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassBook.BLL.IServices;
using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;

namespace ClassBook.BLL.Services;

internal class ClassService : GenericService<Class>, IClassService
{
    private readonly IClassRepository _classRepository;
    public ClassService(IGenericRepository<Class> repository, IClassRepository classRepository) : base(repository)
    {
        _classRepository = classRepository;
    }

    public async Task<IEnumerable<Class>> GetClassesByGivenFloorAsync(int floor)
    {
        return await _classRepository.GetAllClassesByFloorAsync(floor);
    }
}