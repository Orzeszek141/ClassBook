using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClassBook.BLL.DTOs;
using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;

namespace ClassBook.BLL;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserResponseDto>();
        CreateMap<UserAddDto, User>();
        CreateMap<UserUpdateDto, User>();

        CreateMap<Class, ClassResponseDto>();
        CreateMap<ClassAddDto, Class>();
        CreateMap<ClassUpdateDto, Class>();

        CreateMap<Faculty, FacultyResponseDto>();
        CreateMap<FacultyAddDto, Faculty>();
        CreateMap<FacultyUpdateDto, Faculty>();

        CreateMap<UserInfo, UserInfoResponseDto>();
        CreateMap<UserInfoAddDto, UserInfo>();
        CreateMap<UserInfoUpdateDto, UserInfo>();
        CreateMap<UserInfo, OldestDto>();
    }
}