using RestSharp;
using System.Configuration;
using Autofac;
using OpenWeatherTests.Log;
using OpenWeatherTests.Api.RestClient;
using OpenWeatherTests.Api.Service;

namespace OpenWeatherTests.Configuration
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SimpleConsoleLogger>().As<ILogger>();

            builder.RegisterInstance(BuildWeatherRestClient()).As<IRestClient>().Keyed<IRestClient>("weather");
            builder.Register(ctx => new WeatherClient(ctx.ResolveKeyed<IRestClient>("weather"), ctx.Resolve<ILogger>()))
                .As<IWeatherClient>();
            builder.RegisterType<WeatherService>().As<IWeatherService>();

            return builder.Build();
        }

        private static IRestClient BuildWeatherRestClient()
        {
            string url = ConfigurationManager.AppSettings["OpenWeatherMapUrl"];
            string appId = ConfigurationManager.AppSettings["AppId"];
            IRestClient restClient = new RestClient(url);
            restClient.AddDefaultParameter("APPID", appId);
            return restClient;
        }
    }
}
