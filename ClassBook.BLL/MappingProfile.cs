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
        CreateMap<UserRequestDto, User>();
        CreateMap<Class, ClassResponseDto>();
        CreateMap<ClassRequestDto, Class>();
        CreateMap<Faculty, FacultyResponseDto>();
        CreateMap<FacultyRequestDto, Faculty>();
        CreateMap<UserInfo, UserInfoResponseDto>();
        CreateMap<UserInfoRequestDto, UserInfo>();
        CreateMap<UserInfo, OldestDto>();
    }
}