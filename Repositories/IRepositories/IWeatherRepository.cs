namespace Generics.Repositories.IRepositories
{
    public interface IWeatherRepository<T>
    {
        public T GetWeather();
    }
}
