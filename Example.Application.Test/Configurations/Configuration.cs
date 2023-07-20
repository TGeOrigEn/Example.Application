using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using OpenQA.Selenium;

namespace Example.Application.Test.Configurations
{
    internal sealed class Configuration : IConfiguration
    {
        public IWebDriver Driver { get; }

        public TimeSpan Timeout { get; }

        public Configuration(IWebDriver driver, TimeSpan timeout) =>
            (Driver, Timeout) = (driver, timeout);

        public IActions GetActions(IWebComponent component) =>
            new Empyrean.Core.Allure.Implementations.Actions(new Actions(component));

        public IWebDriver GetDeafultDriver() => Driver;

        public TimeSpan GetDeafultTimeout() => Timeout;
    }
}
