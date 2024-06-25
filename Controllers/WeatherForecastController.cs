using Generics.Repositories;
using Generics.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Generics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherRepository _weatherRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherRepository weatherRepository)
        {
            _logger = logger;
            _weatherRepository = weatherRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet(Name = "GetWeather")]
        public WeatherForecast GetWeather()
        {
            return _weatherRepository.GetWeather();
        }
    }
}