using ClassBook.BLL.DTOs;
using ClassBook.BLL.DTOs.Request;
using ClassBook.BLL.DTOs.Response;
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

    private  readonly IUserService _userService;
    private readonly IClassService _classService;

    public WeatherForecastController(IClassService classService, IUserService userService)
    {
        _classService = classService;
        _userService = userService;
    }

    [HttpPost(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Post()
    {
        var user = new UserRequestDto("Hubert","jkkkkk","Test7@o2.pl", "qwerty",Role.Student);
        //var userInfo = new UserInfo{BirthDate = new DateTime(2022,5,2),PhoneNumber = "9297",UserId = 1, User = user};
        var klasa = new ClassRequestDto("A2",2,3);
        //await _classService.AddAsync(klasa);
        //_userRepository.InsertAsync(user);
        await _userService.AddAsync(user);
        return Ok();
    }

    [HttpGet(Name = "Get")]
    public async Task<IEnumerable<UserResponseDto>> Get()
    {
        //
        //_userRepository.InsertAsync(user);
        //_userRepository.SaveAsync();
        ////_context.Users.AddAsync(user);
        ////_context.SaveChangesAsync();

        //return _userRepository.GetAllUsersSortedByLastNameAsync().Result;
        //return _userService.GetUsersSortedByLastNameAsync();
        return await _userService.GetAllAsync();
    }
}