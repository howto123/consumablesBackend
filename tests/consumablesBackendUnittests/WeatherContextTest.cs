using System.Diagnostics;
using System.Linq;
using consumablesBackend;

namespace consumablesBackendUnittests;

[TestClass]
public class WeatherContextTest
{
    private readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly WeatherForecast[] entries;

    private readonly WeatherContext context;


    public WeatherContextTest()
    {
        entries = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();

        context = new WeatherContext();
    }

    [TestCleanup]
    public void ClearDB()
    {
        // delete all
        var all = context.WeatherForecasts.Where( e => true ).AsEnumerable();
        context.WeatherForecasts.RemoveRange(all);
        context.SaveChanges();
    }

    [TestMethod]
    public void Path_Is_weatherDB()
    {
        string path = context.DbPath;

        Assert.AreEqual(path, "C:\\Users\\Thinkpad53u\\Files\\Dev\\99 ProjectIdeas\\consumablesBackend\\weather.db");
    }

    [TestMethod]
    public void Adding_One_Works()
    {

        // Add One
        var original = entries[1];
        context.WeatherForecasts.Add(original);
        context.SaveChanges();

        // Retrieve One, Compare with original
        var found = context.WeatherForecasts.Where( e => e.WeatherForecastId == original.WeatherForecastId).First();
        Assert.AreEqual(found.Date, original.Date);
        Assert.AreEqual(found.Summary, original.Summary);
        Assert.AreEqual(found, original);

        // compare with something else
        var other = entries[3];
        Assert.AreNotEqual(found, other);

        
    }

    [TestMethod]
    public void AddingAndDeleting_One_Works()
    {
        // add
        var original = entries[2];
        context.WeatherForecasts.Add(original);
        context.SaveChanges();

        // check contained
        var found = context.WeatherForecasts.Where( e => e.WeatherForecastId == original.WeatherForecastId).First();
        Assert.IsNotNull(found);

        // delete
        context.Remove(found);
        context.SaveChanges();

        // is empty
        var count = context.WeatherForecasts.Where( e => true ).Count();
        Assert.AreEqual(count, 0);

        
    }
}