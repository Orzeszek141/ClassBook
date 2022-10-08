using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassBook.BLL.IServices;
using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;

namespace ClassBook.BLL.Services;

internal class FacultyService : GenericService<Faculty>, IFacultyService
{
    private readonly IFacultyRepository _faultyRepository;
    public FacultyService(IGenericRepository<Faculty> repository, IFacultyRepository facultyRepository) : base(repository)
    {
        _faultyRepository = facultyRepository;
    }

    public async Task<IEnumerable<Faculty>> GetFacultiesByCityAsync(string city)
    {
        return await _faultyRepository.GetAllFacultiesByCityAsync(city);
    }
}