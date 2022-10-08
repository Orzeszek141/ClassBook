using ClassBook.BLL.Exceptions;
using ClassBook.BLL.IServices;
using ClassBook.DAL;
using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;
using ClassBook.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ClassBook.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IUserRepository _userRepository;
    private  readonly IUserInfoRepository _userInfoRepository;
    private  readonly IUserService _userService;

    public WeatherForecastController(IUserRepository userRepository, IUserInfoRepository userInfoRepository, IUserService userService)
    {
        _userRepository = userRepository;
        _userInfoRepository = userInfoRepository;
        _userService = userService;
    }

    [HttpPost(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Post()
    {
        var user = new User { FirstName = "Hubert", LastName = "Aaakda", Email = "Test5@o2.pl", Password = "qwerty", Role = Role.Student };
        var userInfo = new UserInfo{BirthDate = new DateTime(2022,5,2),PhoneNumber = "9297",UserId = 1, User = user};
        //_userRepository.InsertAsync(user);
        await _userService.AddAsync(user);
        return Ok();
    }

    [HttpGet(Name = "Get")]
    public Task<IEnumerable<User>> Get()
    {
        //
        //_userRepository.InsertAsync(user);
        //_userRepository.SaveAsync();
        ////_context.Users.AddAsync(user);
        ////_context.SaveChangesAsync();

        //return _userRepository.GetAllUsersSortedByLastNameAsync().Result;
        //return _userService.GetUsersSortedByLastNameAsync();
        return _userService.GetAllAsync();
    }
}