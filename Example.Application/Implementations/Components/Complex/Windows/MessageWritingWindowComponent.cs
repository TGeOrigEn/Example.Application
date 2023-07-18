using Empyrean.Core.Interfaces;
using Example.Application.Implementations.Components.Primary.Buttons;
using Example.Application.Implementations.Components.Primary.Container;
using Example.Application.Implementations.Components.Primary.Fields;
using Example.Application.Implementations.Components.Primary.Fields.Dropdown;
using Example.Application.Implementations.Components.Primary.Windows;
using Example.Application.Implementations.Requirements.Buttons;
using Example.Application.Implementations.Requirements.Dropdown;
using Example.Application.Implementations.Requirements.Fields;
using Example.Application.Interfaces.Components.Complex.Windows;
using Example.Application.Interfaces.Components.Primary.Buttons;
using Example.Application.Interfaces.Components.Primary.Container;
using Example.Application.Interfaces.Components.Primary.Fields;
using Example.Application.Interfaces.Components.Primary.Fields.Dropdown;

namespace Example.Application.Implementations.Components.Complex.Windows
{
    public class MessageWritingWindowComponent : WindowComponent, IMessageWritingWindowComponent
    {
        public new static readonly IDescription DEFAULT_DESCRIPTION = WindowComponent.DEFAULT_DESCRIPTION.With("Окно написания сообщения");

        public IButtonComponent AttachButton { get; protected set; }

        public IButtonComponent SendButton { get; protected set; }

        public IButtonComponent SaveButton { get; protected set; }

        public IDropdownFieldComponent RecipientField { get; protected set; }

        public IFieldComponent SubjectField { get; protected set; }

        public IFieldComponent MessageField { get; protected set; }

        public IContainerComponent ObjectContainer { get; protected set; }

        public IContainerComponent FileContainer { get; protected set; }

        public IButtonComponent SelectUserButton { get; protected set; }

        protected MessageWritingWindowComponent()
        {
            AttachButton = GetComponent<ButtonComponent>()
                .WithRequirement(new ButtonRequirement<ButtonComponent>().ByNameEquality("Прикрепить").Perform())
                .Perform();

            SendButton = GetComponent<ButtonComponent>()
                .WithRequirement(new ButtonRequirement<ButtonComponent>().ByNameEquality("Отправить").Perform())
                .Perform();

            SaveButton = GetComponent<ButtonComponent>()
                .WithRequirement(new ButtonRequirement<ButtonComponent>().ByNameEquality("Сохранить").Perform())
                .Perform();

            SelectUserButton = GetComponent<ButtonComponent>()
                .WithRequirement(new ButtonRequirement<ButtonComponent>().ByTipContent("Выбрать пользователей").Perform())
                .Perform();

            RecipientField = GetComponent<DropdownFieldComponent>()
                .WithRequirement(new FieldRequirement<DropdownFieldComponent>().ByLabelEquality("Кому:").Perform())
                .Perform();

            SubjectField = GetComponent<FieldComponent>()
                .WithRequirement(new FieldRequirement<FieldComponent>().ByLabelEquality("Тема:").Perform())
                .Perform();

            ObjectContainer = GetComponent<ContainerComponent>()
                .WithRequirement(new ContainerRequirement<ContainerComponent>().ByLabelEquality("Объекты:").Perform())
                .Perform();

            FileContainer = GetComponent<ContainerComponent>()
                .WithRequirement(new ContainerRequirement<ContainerComponent>().ByLabelEquality("Файлы:").Perform())
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;
    }
}
