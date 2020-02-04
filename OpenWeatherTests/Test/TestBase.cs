using Autofac;
using NUnit.Framework;
using OpenWeatherTests.Api.Service;
using OpenWeatherTests.Configuration;

namespace OpenWeatherTests.Test
{
    public abstract class TestBase
    {
        protected IWeatherService weatherService;

        [SetUp]
        public void Before()
        {
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                weatherService = scope.Resolve<IWeatherService>();
            }
        }
    }
}
