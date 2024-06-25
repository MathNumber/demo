using Generics.Repositories.IRepositories;

namespace Generics.Repositories
{
    public class WeatherRepository : IWeatherRepository<WeatherForecast>
    {
        private readonly WeatherForecast weatherForecast;
        public WeatherRepository(WeatherForecast weatherForecast)
        {
            this.weatherForecast = weatherForecast;
        }
        public WeatherForecast GetWeather()
        {
            return weatherForecast;   
        }
    }
}
