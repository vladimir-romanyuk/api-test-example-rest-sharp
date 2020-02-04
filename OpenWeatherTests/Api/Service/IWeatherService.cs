using OpenWeatherTests.Model;

namespace OpenWeatherTests.Api.Service
{
    public interface IWeatherService
    {
        GetCurrentWeatherResponse GetCurrentWeather(string q);
    }
}
