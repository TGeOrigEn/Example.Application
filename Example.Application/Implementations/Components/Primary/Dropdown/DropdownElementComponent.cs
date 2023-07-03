using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Dropdown;

namespace Example.Application.Implementations.Components.Primary.Dropdown
{
    public class DropdownElementComponent : ApplicationWebComponent, IDropdownElementComponent
    {
        public static IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Элемент меню");

        private const string _DEFAULT_SELECTOR = "*[class^='x-boundlist-item']";

        private const string _NAME_SELECTOR = "span";

        private const string _ICON_SELECTOR = "img";

        protected IWebComponent iconComponent;

        protected IWebComponent nameComponent;

        protected DropdownElementComponent()
        {
            var nameDescription = new Description(_NAME_SELECTOR, "Название элемента");
            var iconDescription = new Description(_ICON_SELECTOR, "Иконка элемента");

            nameComponent = GetComponent().WithDescription(nameDescription).Perform();
            iconComponent = GetComponent().WithDescription(iconDescription).Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual void Click() => Actions.Click();

        public virtual string GetName() => Properties.GetText();

        public virtual void Hover() => Actions.Hover();

        public bool HasIcon() => iconComponent.IsAvalable();

        public string GetIcon() => iconComponent.Properties.GetClass();
    }
}
