using OpenWeatherTests.Log;
using RestSharp;

namespace OpenWeatherTests.Api.RestClient
{
    public class WeatherClient : IWeatherClient
    {
        private readonly IRestClient _restClient;
        private readonly ILogger _logger;
        private const string GET_CURRENT_WEATHER_PATH = "data/2.5/weather";

        public WeatherClient(IRestClient restClient, ILogger logger)
        {
            this._restClient = restClient;
            this._logger = logger;
        }

        public IRestResponse GetCurrentWeather(string q)
        {
            var request = new RestRequest(GET_CURRENT_WEATHER_PATH, DataFormat.Json);
            request.AddParameter("q", q);
            _logger.Log("Sending Get Current Weather request");
            IRestResponse response = _restClient.Get(request);
            _logger.LogRequest(_restClient, request, response);
            return response;
        }
    }
}
