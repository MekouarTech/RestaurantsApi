using Microsoft.AspNetCore.Mvc;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForeCastService _weatherForeCastService;
    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForeCastService weatherForeCastService)
    {
        _logger = logger;
        _weatherForeCastService = weatherForeCastService;
    }

    [HttpGet]
    [Route("weather")]
    public IEnumerable<WeatherForecast> Get()
    {
        var results = _weatherForeCastService.Get();
        return results;
    }
}
