using NUnit.Framework;

namespace OpenWeatherTests.Log
{
    public class SimpleConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            TestContext.Out.WriteLine(message);
        }
    }
}
