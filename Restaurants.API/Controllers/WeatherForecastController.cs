using Microsoft.AspNetCore.Mvc;

namespace Restaurants.API.Controllers;

public class TemperatureRequest
{
    public int Min { get; set; }
    public int Max { get; set; }
}

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
        var results = _weatherForeCastService.Get(5,-22,55);
        return results;
    }

    [HttpGet("{index}/currentDay")]
    public WeatherForecast GetCurrentDayForeCast([FromQuery]int max, [FromRoute]int index)
    {
        var results = _weatherForeCastService.Get(5, -22, 55).First();
        return results;
    }

    [HttpPost]
    public string Hello([FromBody] string name)
    {
        return $"Hello {name}";
    }

    [HttpPost("generate")]
    public IActionResult Generate([FromQuery]int count, [FromBody] TemperatureRequest request)
    {
        if(count < 0 || request.Max < request.Min)
        {
            return BadRequest("Invalid parameters. Count must be non-negative and Min must be less than or equal to Max.");
        }
        var results = _weatherForeCastService.Get(count, request.Min, request.Max);
        return Ok(results);
    }
}
