using FluentAssertions;
using NUnit.Framework;
using OpenWeatherTests.Model;

namespace OpenWeatherTests.Test.CurrentWeatherTests
{
    [TestFixture]
    public class CurrentWeatherForLocationTest : TestBase
    {
        [Test]
        public void GetCurrentWeatherTest()
        {
            string city = "Brest";
            GetCurrentWeatherResponse response = weatherService.GetCurrentWeather(city);
            response.Name.Should().Be(city);
        }
    }
}
