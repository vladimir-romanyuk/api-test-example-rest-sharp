using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Linq;

namespace OpenWeatherTests.Log
{
    public class SimpleConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            TestContext.Out.WriteLine(message);
        }

        public void LogRequest(IRestClient restClient, IRestRequest request, IRestResponse response)
        {
            var requestToLog = new
            {
                resource = request.Resource,
                parameters = request.Parameters.Select(parameter => new
                {
                    name = parameter.Name,
                    value = parameter.Value,
                    type = parameter.Type.ToString()
                }),
                body = request.Body,
                method = request.Method.ToString(),
                uri = restClient.BuildUri(request)
            };

            var responseToLog = new
            {
                statusCode = response.StatusCode,
                content = response.Content,
                headers = response.Headers,
                responseUri = response.ResponseUri,
                errorMessage = response.ErrorMessage
            };

            string messageToLog = string.Format("Request completed,\nRequest:\n{0},\nResponse:\n{1}",
                    JsonConvert.SerializeObject(requestToLog),
                    JsonConvert.SerializeObject(responseToLog));
            TestContext.Out.WriteLine(messageToLog);
        }
    }
}
