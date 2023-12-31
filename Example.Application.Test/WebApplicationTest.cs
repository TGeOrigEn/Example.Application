using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Implementations.Components.Complex.Application;
using Example.Application.Implementations.Components.Complex.Forms;
using Example.Application.Implementations.Requirements.Menu;
using Example.Application.Interfaces.Components.Complex.Application;
using Example.Application.Test.Configurations;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Text;

namespace Example.Application.Test
{
    [AllureNUnit]
    public abstract class WebApplicationTest
    {
        protected static bool IsRemoted => (IWebComponent.Configuration.Driver as RemoteWebDriver) != null;

        protected static IContext Context => new Context();

        protected virtual TimeSpan Timeout { get; } = TimeSpan.FromSeconds(5);

        protected virtual string Host { get; } = "http://docker-dev:4444/";

        protected abstract IWebDriver Driver { get; }

        protected abstract string Address { get; }

        protected IApplicationComponent Application { get; set; }

        [SetUp]
        public virtual void Setup()
        {
            IWebComponent.Configuration = new Configuration(Driver, Context, Timeout);
            IWebComponent.Configuration.Driver.Navigate().GoToUrl(Address);
            IWebComponent.Configuration.Driver.Manage().Window.Maximize();

            Application = IWebComponent.Configuration.Context.GetComponent<ApplicationComponent>().Perform();

            Thread.Sleep(1_750);
        }

        [TearDown]
        public virtual void TearDown()
        {
            AddVideo();
            IWebComponent.Configuration.Driver.Dispose();
        }

        protected void LogIn(string username, string password)
        {
            IWebComponent.Configuration.Context.GetComponent<AuthorizationFormComponent>().Perform().LogIn(username, password);
            Application.Loading.Wait(TimeSpan.FromSeconds(1));
        }

        protected void LogOut()
        {
            Application.Head.SettingsButton.Click();

            var menuElementRequirement = new MenuElementRequirement()
                .ByNameEquality("Выход")
                .Perform();

            Application.GetMenu().Perform().GetElement()
                .WithRequirement(menuElementRequirement)
                .Perform()
                .Click();

            Application.GetMessageBox().Perform().YesButton.Click();
        }

        private void AddVideo()
        {
            if (!IsRemoted)
                return;

            var allure = Allure.Net.Commons.AllureLifecycle.Instance;
            var src = $"{Host}video/{(IWebComponent.Configuration.Driver as RemoteWebDriver)?.SessionId}.mp4";
            var html = $"<html><body><video width='100%' height='100%' controls autoplay><source src='{src}' type='video/mp4'></video></body></html>";

            var content = Encoding.UTF8.GetBytes(html);
            allure.AddAttachment("Видео", "text/html", content, ".html");
        }
    }
}