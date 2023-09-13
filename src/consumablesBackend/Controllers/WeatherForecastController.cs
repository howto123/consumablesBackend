using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace consumablesBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly WeatherContext _db;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherContext db)
    {
        _logger = logger;
        _db = db;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var entries = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();

        Array.ForEach(entries, e => _db.AddRange(entries));

        Console.WriteLine("called!");

        return _db.WeatherForecasts.ToList();

    }
}
