using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Buttons;

namespace Example.Application.Implementations.Components.Primary.Buttons
{
    public class ButtonComponent : ApplicationWebComponent, IButtonComponent
    {
        private const string _DISABLED_ATTRIBUTE = "aria-disabled";

        public static IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Кнопка");

        private const string _DEFAULT_SELECTOR = "*[id^='button'][class^='x-btn'][class*='x-unselectable']:not([style*='display'])";

        private const string _NAME_SELECTOR = "span[class*='x-btn-text']";

        protected IWebComponent nameComponent;

        protected ButtonComponent()
        {
            var nameDescription = new Description(_NAME_SELECTOR, "Название кнопки");
            nameComponent = GetComponent().WithDescription(nameDescription).Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual bool IsEnabled() => GetAttribute(_DISABLED_ATTRIBUTE, this).Equals("false");

        public virtual bool HasName() => nameComponent.IsAvalable();

        public virtual string GetName() => nameComponent.Properties.GetText();

        public virtual void Click() => Actions.Click();
    }
}
