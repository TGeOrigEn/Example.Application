using Empyrean.Core.Extensions;
using Empyrean.Core.Implementations;
using Example.Application.Implementations.Components.Complex.Windows;
using Example.Application.Implementations.Components.Primary.Buttons;
using Example.Application.Implementations.Components.Primary.Container;
using Example.Application.Implementations.Components.Primary.Fields;
using Example.Application.Implementations.Components.Primary.Fields.Dropdown;
using Example.Application.Implementations.Components.Primary.Table;
using Example.Application.Implementations.Requirements.Buttons;
using Example.Application.Implementations.Requirements.Dropdown;
using Example.Application.Implementations.Requirements.Fields;
using Example.Application.Implementations.Requirements.Menu;
using Example.Application.Implementations.Requirements.Table;
using Example.Application.Implementations.Requirements.TreeView;
using Example.Application.Implementations.Requirements.Windows;
using Example.Application.Test.Drivers;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace Example.Application.Test
{
    public class TestTest : WebApplicationTest
    {
        protected override IWebDriver Driver => Chrome.Remote(Host);
        /*protected override IWebDriver Driver => Chrome.Local();*/
        protected override string Address => "http://10.0.11.18:8081/client/";

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            LogIn("SYSADMIN", "");

            Application.Head.GetComponent<ButtonComponent>().WithDescription(ButtonComponent.DEFAULT_DESCRIPTION.With(2)).Perform().Click();
            var window = Application.GetWindow().Perform();
            window.GetComponent<DropdownFieldComponent>().Perform().ClickOnTrigger();
            Application.Dropdown.GetElement().Perform().Click();
            window.OkButton.Click();

            Application.GetMessageBox().Perform().YesButton.Click();
        }

        [Test]
        [AllureOwner("Артём Тисло Максимович")]
        [AllureName("Всё-всё")]
        public void Test()
        {
            var guid = Guid.NewGuid().ToString();

            //Application.Loading.Wait(TimeSpan.FromSeconds(2));

            Application.Head.MailButton.Click();
            Application.Body.ToolBar.WriteMessageButton.Click();

            var messageWritingWindow = Application.GetComponent<MessageWritingWindowComponent>()
                .WithRequirement(new WindowRequirement<MessageWritingWindowComponent>().ByTitleEquality("Сообщение").Perform())
                .Perform();

            messageWritingWindow.SelectUserButton.Click();

            var selectObjectWindow = Application.GetWindow()
                .WithRequirement(new WindowRequirement().ByTitleEquality("Выбор объектов").Perform())
                .Perform();

            //Application.Loading.Wait(TimeSpan.FromSeconds(2));

            var searchField = selectObjectWindow.GetComponent<SearchFieldComponent>().Perform();
            searchField.SetValue("ADMIN");
            searchField.Search();

            //Application.Loading.Wait(TimeSpan.FromSeconds(2));

            selectObjectWindow.GetComponent<TableCellComponent>()
                .WithRequirement(new TableCellRequirement<TableCellComponent>().ByValueEquality("ADMIN").Perform())
                .Perform()
                .Click();

            selectObjectWindow.OkButton.Click();

            messageWritingWindow.RecipientField.Should(new FieldRequirement().ByValueEquality("ADMIN; ").Perform(), TimeSpan.Zero);

            messageWritingWindow.AttachButton.Click();

            Application.GetMenu().Perform().GetElement()
                .WithRequirement(new MenuElementRequirement().ByNameEquality("Добавить объект...").Perform())
                .Perform()
                .Click();

            //Application.Loading.Wait(TimeSpan.FromSeconds(2));

            var objectNames = new List<string>();

            selectObjectWindow.GetComponents<TableRowComponent>().Perform().Take(2).ToList().ForEach(row =>
            {
                var cells = row.GetCells().Perform().ToArray();
                var objectName = cells[1].GetValue();
                cells[0].Click();

                objectNames.Add(objectName);
            });

            selectObjectWindow.OkButton.Click();

            objectNames.ForEach(objectName =>
            {
                messageWritingWindow.ObjectContainer.GetElement()
                    .WithRequirement(new ContainerElementRequirement().ByNameContent(objectName).Perform())
                    .Perform().Should(new WebComponentRequirement().IsAvalable().Perform(), TimeSpan.Zero);
            });

            var message = $"Тест: {guid}. Здравствуйте! Для тестирования созданы объекты {string.Join(", ", objectNames)}!";

            messageWritingWindow.SubjectField.SetValue(message);

            messageWritingWindow.SendButton.Click();


            LogOut();

            /////////////////////////////

            LogIn("ADMIN", "");

            Application.Head.MailButton.Click();

            Application.Body.TreeView.GetElement()
                .WithRequirement(new TreeViewElementRequirement().ByNameContent("Входящие").Perform())
                .Perform()
                .Click();

            var column = Application.Body.ViewPanel.Table.GetColumn()
                .WithRequirement(new TableColumnRequirement().ByNameEquality("Тема").Perform())
                .Perform();

            Application.Body.ToolBar.ShowPreviewPanelButton.Click();

            Application.Body.ViewPanel.Table.GetCell()
                .WithRequirement(new TableCellRequirement().ByColumn(column).Perform())
                .Perform()
                .Click();

            //Application.Loading.Wait(TimeSpan.FromSeconds(2));

            var objects = Application.Body.ViewPanel.GetComponent<ContainerComponent>()
                .WithRequirement(new ContainerRequirement<ContainerComponent>().ByLabelEquality("Объекты:").Perform())
                .Perform().GetElements().Perform();

            objects.ToList().ForEach(obj => Assert.Contains(obj.GetName(), objectNames, ""));

            Application.Body.ToolBar.GetButton()
                .WithRequirement(new ButtonRequirement().ByTipEquality("Ответить").Perform())
                .Perform()
                .Click();

            messageWritingWindow.SendButton.Click();

            LogOut();

            /////////////////////////////

            LogIn("SYSADMIN", "");

            Application.Head.MailButton.Click();

            Application.Body.TreeView.GetElement()
                .WithRequirement(new TreeViewElementRequirement().ByNameContent("Входящие").Perform())
                .Perform()
                .Click();

            //Application.Loading.Wait(TimeSpan.FromSeconds(2));

            Application.Body.ViewPanel.Table.GetCell()
                .WithRequirement(new TableCellRequirement().ByColumn(column).And().ByValueEquality("Re: " + message).Perform())
                .Perform()
                .Click();

            //Application.Loading.Wait(TimeSpan.FromSeconds(2));

            objects = Application.Body.ViewPanel.GetComponent<ContainerComponent>()
                .WithRequirement(new ContainerRequirement<ContainerComponent>().ByLabelEquality("Объекты:").Perform())
                .Perform().GetElements().Perform();

            objects.ToList().ForEach(obj => Assert.Contains(obj.GetName(), objectNames, ""));
        }
    }
}
