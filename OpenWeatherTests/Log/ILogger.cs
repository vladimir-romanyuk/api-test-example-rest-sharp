using RestSharp;

namespace OpenWeatherTests.Log
{
    public interface ILogger
    {
        void Log(string message);

        void LogRequest(IRestClient restClient, IRestRequest request, IRestResponse response);
    }
}
