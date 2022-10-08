using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.BLL.Exceptions;
using ClassBook.BLL.IServices;
using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;

namespace ClassBook.BLL.Services;

internal class FacultyService : GenericService<Faculty,FacultyResponseDto, FacultyUpdateDto>, IFacultyService
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

    public async Task AddAsync(FacultyAddDto obj)
    {
        if (await _faultyRepository.GetFacultyByFacultyName(obj.FacultyName) != null)
            throw new FacultyNameAlreadyTakenException(obj.FacultyName);
        var help = Mapper.Map<Faculty>(obj);

        await _faultyRepository.InsertAsync(help);
        await _faultyRepository.SaveAsync();
    }
}