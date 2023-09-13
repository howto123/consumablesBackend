using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

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

    [HttpGet]
    [Route("Init")]
    public IEnumerable<WeatherForecast> Get()
    {
        var entries = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();


        // clear all
        var all = _db.WeatherForecasts.Where( e => true ).AsEnumerable();
        _db.WeatherForecasts.RemoveRange(all);
        _db.SaveChanges();

        // fresh init
        _db.WeatherForecasts.AddRange(entries);
        _db.SaveChanges();

        // get all
        var allFresh = _db.WeatherForecasts.Where( e => true ).AsEnumerable();


        Console.WriteLine("called!");
        return allFresh;

    }

    [HttpGet]
    [Route("")]
    public string AreWeRunning()
    {
        Console.WriteLine("Running!");
        return "We are running!";
    }

    [HttpPost]
    [Route("add")]
    public WeatherForecast AddWeatherForecast([FromBody] WeatherForecast forecast)
    {
        _db.WeatherForecasts.Add(forecast);
        _db.SaveChanges();

        Console.WriteLine("Added!");
        return forecast;
    }

}
