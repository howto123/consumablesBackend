using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using consumablesBackend;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

public class WeatherContext : DbContext
{
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    public string DbPath { get; }

    public WeatherContext()
    {
        string? dbPath = Environment.GetEnvironmentVariable("dbPath");
        if ( dbPath == null )
        {
            throw new Exception("dbPath not set in environment");
        }

        DbPath = dbPath;
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}