using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using consumablesBackend;

public class WeatherContext : DbContext
{
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    public string DbPath { get; }

    public WeatherContext()
    {
        DbPath = "C:\\Users\\Thinkpad53u\\Files\\Dev\\99 ProjectIdeas\\consumablesBackend\\weather.db";
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}