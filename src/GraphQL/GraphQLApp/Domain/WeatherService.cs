using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLApp.Domain
{
  internal class WeatherService : IWeatherService
  {
    private static readonly string[] Summaries =
    {
      "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static readonly IEnumerable<WeatherForecast> WeatherForecasts;

    static WeatherService()
    {
      var rng = new Random();
      WeatherForecasts =
        Enumerable
          .Range(1, 5)
          .Select(index => new WeatherForecast()
          {
            ForecastDate = DateTime.Now.AddDays(index),
            TemperatureC = rng.Next(-20, 55),
            Summary = Summaries[rng.Next(Summaries.Length)]
          })
          .ToList();
    }

    public IEnumerable<WeatherForecast> GetWeatherForecast()
    {
      return WeatherForecasts;
    }
  }
}