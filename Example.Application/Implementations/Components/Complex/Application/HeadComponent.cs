using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Implementations.Components.Primary.Buttons;
using Example.Application.Implementations.Components.Primary.Fields;
using Example.Application.Implementations.Requirements.Buttons;
using Example.Application.Interfaces.Components.Complex.Application;
using Example.Application.Interfaces.Components.Primary.Buttons;
using Example.Application.Interfaces.Components.Primary.Fields;

namespace Example.Application.Implementations.Components.Complex.Application
{
    public class HeadComponent : ApplicationWebComponent, IHeadComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Заголовок приложения");

        private const string _DEFAULT_SELECTOR = "div[id='mainView_header']";

        public IButtonComponent NotificationsButton { get; protected set; }

        public IButtonComponent SettingsButton { get; protected set; }

        public IButtonComponent DesktopButton { get; protected set; }

        public IButtonComponent ObjectsButton { get; protected set; }

        public IButtonComponent MailButton { get; protected set; }

        public ISearchFieldComponent SearchField { get; protected set; }

        protected HeadComponent()
        {
            var buttonRequirement = new ButtonRequirement<ButtonComponent>();

            var notificationsRequirement = buttonRequirement.HasTip().And().ByTipEquality("Уведомления").Perform();
            var settingsRequirement = buttonRequirement.HasTip().And().ByTipEquality("Настройки").Perform();
            var desktopRequirement = buttonRequirement.HasTip().And().ByTipEquality("Рабочий стол").Perform();
            var objectsRequirement = buttonRequirement.HasTip().And().ByTipEquality("Объекты").Perform();
            var mailRequirement = buttonRequirement.HasTip().And().ByTipEquality("Почта").Perform();

            NotificationsButton = GetComponent<ButtonComponent>().WithRequirement(notificationsRequirement).Perform();
            SettingsButton = GetComponent<ButtonComponent>().WithRequirement(settingsRequirement).Perform();
            DesktopButton = GetComponent<ButtonComponent>().WithRequirement(desktopRequirement).Perform();
            ObjectsButton = GetComponent<ButtonComponent>().WithRequirement(objectsRequirement).Perform();
            MailButton = GetComponent<ButtonComponent>().WithRequirement(mailRequirement).Perform();

            SearchField = GetComponent<SearchFieldComponent>().Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;
    }
}
