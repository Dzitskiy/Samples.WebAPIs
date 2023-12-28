using System.Collections.Generic;

namespace GraphQLApp.Domain
{
  public interface IWeatherService
  {
    IEnumerable<WeatherForecast> GetWeatherForecast();
  }
}