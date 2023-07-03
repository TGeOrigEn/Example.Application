using Example.Application.Interfaces.Components.Primary.Buttons;
using Example.Application.Interfaces.Components.Primary.Container;
using Example.Application.Interfaces.Components.Primary.Fields;
using Example.Application.Interfaces.Components.Primary.Fields.Dropdown;
using Example.Application.Interfaces.Components.Primary.Window;

namespace Example.Application.Interfaces.Components.Complex.Windows
{
    public interface IMessageWritingWindowComponent : IWindowComponent
    {
        IButtonComponent AttachButton { get; }

        IButtonComponent SendButton { get; }

        IButtonComponent SaveButton { get; }

        IButtonComponent SelectUserButton { get; }

        IDropdownFieldComponent RecipientField { get; }

        IFieldComponent SubjectField { get; }

        IFieldComponent MessageField { get; }

        IContainerComponent ObjectContainer { get; }

        IContainerComponent FileContainer { get; }
    }
}
