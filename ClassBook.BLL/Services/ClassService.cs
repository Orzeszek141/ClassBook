using AutoMapper;
using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.BLL.Exceptions;
using ClassBook.BLL.IServices;
using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;

namespace ClassBook.BLL.Services;

internal class ClassService : GenericService<Class, ClassResponseDto, ClassUpdateDto>, IClassService
{
    private readonly IClassRepository _classRepository;

    public ClassService(IGenericRepository<Class> repository, IMapper mapper, IClassRepository classRepository) : base(
        repository, mapper)
    {
        _classRepository = classRepository;
    }

    public async Task<IEnumerable<ClassResponseDto>> GetClassesByGivenFloorAsync(int floor)
    {
        var classes = await _classRepository.GetAllClassesByFloorAsync(floor);

        return Mapper.Map<IEnumerable<ClassResponseDto>>(classes);
    }

    public async Task AddAsync(ClassAddDto obj)
    {
        var classes = _classRepository.GetAllClassesByFloorAsync(obj.FacultyId).Result;

        if (classes.Any(x => x.ClassNumber != obj.ClassNumber))
            throw new ClassNumberAlreadyTakenException(obj.ClassNumber);

        var help = Mapper.Map<Class>(obj);

        await _classRepository.InsertAsync(help);
        await _classRepository.SaveAsync();
    }
}