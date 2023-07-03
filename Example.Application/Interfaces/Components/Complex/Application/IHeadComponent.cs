using Example.Application.Interfaces.Components.Primary.Buttons;
using Example.Application.Interfaces.Components.Primary.Fields;

namespace Example.Application.Interfaces.Components.Complex.Application
{
    public interface IHeadComponent : IApplicationWebComponent
    {
        ISearchFieldComponent SearchField { get; }

        IButtonComponent NotificationsButton { get; }

        IButtonComponent SettingsButton { get; }

        IButtonComponent DesktopButton { get; }

        IButtonComponent ObjectsButton { get; }

        IButtonComponent MailButton { get; }
    }
}
