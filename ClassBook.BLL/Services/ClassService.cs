﻿using System;
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

internal class ClassService : GenericService<Class,ClassResponseDto, ClassUpdateDto>, IClassService
{
    private readonly IClassRepository _classRepository;
    public ClassService(IGenericRepository<Class> repository, IMapper mapper, IClassRepository classRepository) : base(repository, mapper)
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
        if (await _classRepository.GetClassByClassNumber(obj.ClassNumber) != null)
            throw new ClassNumberAlreadyTakenException(obj.ClassNumber);
        var help = Mapper.Map<Class>(obj);

        await _classRepository.InsertAsync(help);
        await _classRepository.SaveAsync();
    }
}