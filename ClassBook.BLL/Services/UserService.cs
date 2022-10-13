using AutoMapper;
using ClassBook.BLL.Authorization;
using ClassBook.BLL.Authorization.PasswordHashers;
using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
using ClassBook.BLL.Exceptions;
using ClassBook.BLL.IServices;
using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;

namespace ClassBook.BLL.Services;

public class UserService : GenericService<User, UserResponseDto, UserUpdateDto>, IUserService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;

    public UserService(IGenericRepository<User> repository, IMapper mapper, IUserRepository userRepository,
        IPasswordHasher passwordHasher) : base(repository, mapper)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<IEnumerable<UserResponseDto>> GetUsersSortedByLastNameAsync()
    {
        var users = await _userRepository.GetAllUsersSortedByLastNameAsync();

        return Mapper.Map<IEnumerable<UserResponseDto>>(users);
    }

    public async Task<UserResponseDto> GetByEmail(string email)
    {
        var user = await _userRepository.GetUserByEmail(email);

        if (user == null)
            throw new NotFoundException(email);

        return Mapper.Map<UserResponseDto>(user);
    }

    public async Task AddStudentToClass(string studentEmail, int classId)
    {
        var pair = await _userRepository.GetStudentAndClass(studentEmail, classId);

        if (pair.Item1 == null || pair.Item2 == null)
            throw new NotFoundException();

        pair.Item1.Classes.Add(pair.Item2);
        await _userRepository.SaveAsync();
    }

    public async Task AddAsync(UserAddDto obj)
    {
        if (await _userRepository.GetUserByEmail(obj.Email) != null)
            throw new EmailAlreadyTakenException(obj.Email);

        var help = Mapper.Map<User>(obj);
        help.Password = _passwordHasher.HashPassword(obj.Password);

        await _userRepository.InsertAsync(help);
        await _userRepository.SaveAsync();
    }

    public new async Task UpdateAsync(int id, UserUpdateDto obj)
    {
        var o = await Repository.GetByIdAsync(id);

        if (o == null)
            throw new NotFoundException();

        var help = Mapper.Map<User>(obj);
        help.Password = _passwordHasher.HashPassword(obj.Password);

        await Repository.UpdateAsync(help);
        await Repository.SaveAsync();
    }

    public async Task<TokenDto> Login(LoginDto obj, string key)
    {
        var user = await _userRepository.GetUserByEmail(obj.Email);

        if (user == null)
            throw new NotFoundException(obj.Email);

        if (!_passwordHasher.VerifyPassword(obj.Password, user.Password))
            throw new WrongPasswordException();

        var tokenDescriptor = TokenHandler.GenerateTokenDescriptor(user, key);

        return TokenGenerator.GetToken(tokenDescriptor);
    }


}