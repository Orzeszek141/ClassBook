using AutoMapper;
using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.BLL.Exceptions;
using ClassBook.BLL.IServices;
using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;

namespace ClassBook.BLL.Services;

internal class UserInfoService : GenericService<UserInfo, UserInfoResponseDto, UserInfoUpdateDto>, IUserInfoService
{
    private readonly IUserInfoRepository _userInfoRepository;

    public UserInfoService(IGenericRepository<UserInfo> repository, IMapper mapper,
        IUserInfoRepository userInfoRepository) : base(repository, mapper)
    {
        _userInfoRepository = userInfoRepository;
    }

    public async Task<OldestDto> FindAndGetTheOldestUserAsync()
    {
        if (!_userInfoRepository.IsEmpty().Result)
            throw new NoContentFoundException();

        var oldest = await _userInfoRepository.GetTheOldestUserAsync();

        Mapper.Map<UserResponseDto>(oldest.User);
        return Mapper.Map<OldestDto>(oldest);
    }

    public async Task AddAsync(UserInfoAddDto obj)
    {
        if (await _userInfoRepository.GetUserInfoByPhoneNumber(obj.PhoneNumber) != null)
            throw new PhoneNumberAlreadyTakenException(obj.PhoneNumber);

        var help = Mapper.Map<UserInfo>(obj);

        await _userInfoRepository.InsertAsync(help);
        await _userInfoRepository.SaveAsync();
    }
}