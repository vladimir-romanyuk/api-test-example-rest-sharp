using RestSharp;

namespace OpenWeatherTests.Api.RestClient
{
    public interface IWeatherClient
    {
        IRestResponse GetCurrentWeather(string q);
    }
}
