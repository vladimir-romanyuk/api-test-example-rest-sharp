using Newtonsoft.Json;
using OpenWeatherTests.Api.RestClient;
using OpenWeatherTests.Model;
using RestSharp;

namespace OpenWeatherTests.Api.Service
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherClient _weatherClient;

        public WeatherService(IWeatherClient weatherClient)
        {
            this._weatherClient = weatherClient;
        }

        public GetCurrentWeatherResponse GetCurrentWeather(string q)
        {
            IRestResponse restResponse = _weatherClient.GetCurrentWeather(q);
            GetCurrentWeatherResponse response = JsonConvert.DeserializeObject<GetCurrentWeatherResponse>(restResponse.Content);
            return response;
        }
    }
}
