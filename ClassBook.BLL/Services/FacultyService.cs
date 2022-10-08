using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.BLL.IServices;
using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;

namespace ClassBook.BLL.Services;

internal class FacultyService : GenericService<Faculty,FacultyResponseDto, FacultyAddDto, FacultyUpdateDto>, IFacultyService
{
    private readonly IFacultyRepository _faultyRepository;
    public FacultyService(IGenericRepository<Faculty> repository, IMapper mapper, IFacultyRepository facultyRepository) : base(repository, mapper)
    {
        _faultyRepository = facultyRepository;
    }

    public async Task<IEnumerable<FacultyResponseDto>> GetFacultiesByCityAsync(string city)
    {
        var faculties = await _faultyRepository.GetAllFacultiesByCityAsync(city);
        return Mapper.Map<IEnumerable<FacultyResponseDto>>(faculties);
    }
}