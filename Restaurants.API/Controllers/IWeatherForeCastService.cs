namespace Restaurants.API.Controllers
{
    public interface IWeatherForeCastService
    {
        IEnumerable<WeatherForecast> Get();
    }
}
