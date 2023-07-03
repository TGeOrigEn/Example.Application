using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Implementations.Components.Primary.Buttons;
using Example.Application.Implementations.Requirements.Buttons;
using Example.Application.Interfaces.Components.Primary.Buttons;
using Example.Application.Interfaces.Components.Primary.Window;

namespace Example.Application.Implementations.Components.Primary.Windows
{
    public class WindowComponent : ApplicationWebComponent, IWindowComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Окно");

        private const string _DEFAULT_SELECTOR = "div[class^='x-window x-layer']";

        private const string _HEADER_SELECTOR = "div[class^='x-window-header']";

        private const string _FOOTER_SELECTOR = "div[id^='panel'][class^='x-panel x-docked']";

        private const string _TITLE_SELECTOR = "div[id*='header-title'][class*='x-title-text']";

        public IButtonComponent MaximizeButton { get; protected set; }

        public IButtonComponent CloseButton { get; protected set; }

        public IButtonComponent CancelButton { get; protected set; } = null!;

        public IButtonComponent ApplyButton { get; protected set; } = null!;

        public IButtonComponent OkButton { get; protected set; } = null!;

        public IButtonComponent YesButton { get; protected set; } = null!;

        public IButtonComponent NoButton { get; protected set; } = null!;

        protected IWebComponent headerComponent;

        protected IWebComponent footerComponent;

        protected IWebComponent titleComponent;

        protected WindowComponent()
        {
            var nameDescription = new Description(_TITLE_SELECTOR, "Заголовок окна");

            var footerDescription = new Description(_FOOTER_SELECTOR, "Нижний колонтитул окна");

            var headerDescription = new Description(_HEADER_SELECTOR, "Верхний колонтитул окна");

            var toolButtonRequirement = new ButtonRequirement<ToolButtonComponent>();

            var maximizeRequirement = toolButtonRequirement.HasTip(false).Perform();

            var closeRequirement = toolButtonRequirement.HasTip().And().ByTipContent("Закрыть").Perform();

            headerComponent = GetComponent()
                .WithDescription(headerDescription)
                .Perform();

            footerComponent = GetComponent()
                .WithDescription(footerDescription)
                .Perform();

            titleComponent = headerComponent.GetComponent()
                .WithDescription(nameDescription)
                .Perform();

            MaximizeButton = headerComponent.GetComponent<ToolButtonComponent>()
                .WithRequirement(maximizeRequirement)
                .Perform();

            CloseButton = headerComponent.GetComponent<ToolButtonComponent>()
                .WithRequirement(closeRequirement)
                .Perform();

            InitializeButtons(footerComponent);
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        protected virtual void InitializeButtons(IWebComponent footerComponent)
        {
            var buttonRequirement = new ButtonRequirement<ButtonComponent>();

            var cancelRequirement = buttonRequirement.ByNameEquality("Отмена").Perform();

            var applyRequirement = buttonRequirement.ByNameEquality("Принять").Perform();

            var yesRequirement = buttonRequirement.ByNameEquality("Да").Perform();

            var noRequirement = buttonRequirement.ByNameEquality("Нет").Perform();

            var okRequirement = buttonRequirement.ByNameEquality("Ок").Perform();

            CancelButton = footerComponent.GetComponent<ButtonComponent>()
                .WithRequirement(cancelRequirement)
                .Perform();

            ApplyButton = footerComponent.GetComponent<ButtonComponent>()
               .WithRequirement(applyRequirement)
               .Perform();

            YesButton = footerComponent.GetComponent<ButtonComponent>()
               .WithRequirement(yesRequirement)
               .Perform();

            OkButton = footerComponent.GetComponent<ButtonComponent>()
               .WithRequirement(okRequirement)
               .Perform();

            NoButton = footerComponent.GetComponent<ButtonComponent>()
               .WithRequirement(noRequirement)
               .Perform();
        }

        public virtual bool IsMaximized() => Properties.GetClass().Contains("x-window-maximized");

        public virtual bool CanMaximize() => MaximizeButton.IsAvalable();

        public virtual bool CanClose() => CloseButton.IsAvalable();

        public virtual string GetTitle() => titleComponent.Properties.GetText();
    }
}
