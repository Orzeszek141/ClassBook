using ClassBook.BLL.Exceptions;
using ClassBook.DAL;
using ClassBook.Domain.Entities;
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

        private readonly MyDbContext _context;

        public WeatherForecastController( MyDbContext context)
        {
            _context = context;
        }

        [HttpPost(Name = "GetWeatherForecast")]
        public Class Post()
        {
            throw new NotFoundException("test");
            var klasa = new Class{ ClassNumber = "Test", Floor = 2, NumberOfComputers = 15 };
            _context.Classes.Add(klasa);
            _context.SaveChanges();
            
            return _context.Classes.First();
        }
    }
}