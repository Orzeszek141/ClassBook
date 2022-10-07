using ClassBook.BLL.Exceptions;
using ClassBook.DAL;
using ClassBook.DAL.IRepositories;
using ClassBook.Domain.Entities;
using ClassBook.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ClassBook.Api.Controllers
{
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

        public WeatherForecastController(IUserRepository userRepository, IUserInfoRepository userInfoRepository)
        {
            _userRepository = userRepository;
            _userInfoRepository = userInfoRepository;
        }

        [HttpPost(Name = "GetWeatherForecast")]
        public IActionResult Post()
        {
            var user = new User { FirstName = "Hubert", LastName = "Aafa", Email = "Test3@o2.pl", Password = "qwerty", Role = Role.Student };
            var userInfo = new UserInfo{BirthDate = new DateTime(2022,5,2),PhoneNumber = "9297",UserId = 1, User = user};
            //_userRepository.InsertAsync(user);
            _userInfoRepository.InsertAsync(userInfo);
            _userInfoRepository.SaveAsync();
            return Ok();
        }

        [HttpGet(Name = "Get")]
        public Task<UserInfo> Get()
        {
            //
            //_userRepository.InsertAsync(user);
            //_userRepository.SaveAsync();
            ////_context.Users.AddAsync(user);
            ////_context.SaveChangesAsync();

            //return _userRepository.GetAllUsersSortedByLastNameAsync().Result;
            return _userInfoRepository.FindTheOldestUserAsync();
        }
    }
}