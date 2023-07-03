using Empyrean.Core.Extensions;
using Empyrean.Core.Implementations;
using Example.Application.Implementations.Components.Complex.Windows;
using Example.Application.Implementations.Components.Primary.Fields;
using Example.Application.Implementations.Components.Primary.Table;
using Example.Application.Implementations.Requirements.Fields;
using Example.Application.Implementations.Requirements.Windows;
using Example.Application.Test.Drivers;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Example.Application.Test
{
    public class TestTest : WebApplicationTest
    {
        protected override IWebDriver Driver => Chrome.Remote(Host);

        protected override string Address => "http://10.0.11.18:8081/client/";

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            LogIn("SYSADMIN", "");
        }

        [Test]
        [AllureOwner("Артём Тисло Максимович")]
        [AllureName("Всё-всё")]
        public void Test()
        {
            Application.Head.MailButton.Click();
            Application.Body.ToolBar.WriteMessageButton.Click();

            var messageWritingWindow = Application.GetComponent<MessageWritingWindowComponent>()
                .WithRequirement(new WindowRequirement<MessageWritingWindowComponent>().ByTitleEquality("Сообщение").Perform())
                .Perform();

            messageWritingWindow.SelectUserButton.Click();

            var selectObjectWindow = Application.GetWindow()
                .WithRequirement(new WindowRequirement().ByTitleEquality("Выбор объектов").Perform())
                .Perform();

            var searchField = selectObjectWindow.GetComponent<SearchFieldComponent>().Perform();
            searchField.SetValue("Мартенс Алексей Александрович");
            searchField.Search();

            selectObjectWindow.GetComponent<TableRowComponent>().Perform().Click();
            selectObjectWindow.OkButton.Click();

            var recipient = messageWritingWindow.RecipientField.GetElement()
                .WithRequirement(new DropdownFieldElementRequiremen().ByNameEquality("Мартенс Алексей Александрович").Perform())
                .Perform();

            recipient.Should(new WebComponentRequirement().IsAvalable().Perform(), TimeSpan.Zero);

            messageWritingWindow.SubjectField.SetValue("Здравствуйте!");
        }
    }
}
