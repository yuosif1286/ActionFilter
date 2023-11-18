using ActionFilter.ActionFilters;
using ActionFilter.DataAccess;
using ActionFilter.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ActionFilter.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IWeatherRepo _weatherRepo;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherRepo weatherRepo)
    {
        _logger = logger;
        _weatherRepo = weatherRepo;
    }

    [HttpGet]
    // USE THIS WITH POST AND PUT
  //  [ServiceFilter(typeof(ValidationFilterAttribute))]
    public IActionResult GetAll([FromQuery] WeatherDto weatherDto)
    {
        return Ok(_weatherRepo.GetWeather(weatherDto.PageNumber,weatherDto.PageSize,""));
    }
    
    [HttpGet]
   // use THIS WITH delete and put 
   [ServiceFilter(typeof(ValidateEntityExistAttribute<WeatherForecast>))]
    public IActionResult FindById(Guid id)
    {
        return Ok(HttpContext.Items["entity"]);
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
}
