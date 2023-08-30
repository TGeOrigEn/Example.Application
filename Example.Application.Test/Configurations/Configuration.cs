using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using OpenQA.Selenium;

namespace Example.Application.Test.Configurations
{
    internal sealed class Configuration : IConfiguration
    {
        public IWebDriver Driver { get; }

        public IContext Context { get; }

        public TimeSpan Timeout { get; }

        public Configuration(IWebDriver driver, IContext context, TimeSpan timeout) =>
            (Driver, Context, Timeout) = (driver, context, timeout);

        public IActions GetActions(IWebComponent component) =>
            new Empyrean.Core.Allure.Implementations.Actions(new Actions(component));
    }
}
