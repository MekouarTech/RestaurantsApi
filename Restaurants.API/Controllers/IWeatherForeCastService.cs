namespace Restaurants.API.Controllers
{
    public interface IWeatherForeCastService
    {
        IEnumerable<WeatherForecast> Get(int count, int minTemperature, int maxTemperature);
    }
}
