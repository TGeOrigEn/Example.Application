using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Menu;

namespace Example.Application.Implementations.Components.Primary.Menu
{
    public class MenuElementComponent : ApplicationWebComponent, IMenuElementComponent
    {
        private const string _CHECKED_ATTRIBUTE = "aria-checked";

        public static IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Элемент меню");

        private const string _DEFAULT_SELECTOR = "div[id*='item'][class^='x-menu-item x-menu-item-default']";

        private const string _CHECK_BOX_SELECTOR = "div[class*='x-menu-item-checkbox']";

        private const string _NAME_SELECTOR = "span[class*='x-menu-item-indent']";

        private const string _ICON_SELECTOR = "div[class*='icon-default']";

        protected IWebComponent checkBoxComponent;

        protected IWebComponent iconComponent;

        protected IWebComponent nameComponent;

        protected MenuElementComponent()
        {
            var checkBoxDescription = new Description(_CHECK_BOX_SELECTOR, "Флаг элемента");
            var nameDescription = new Description(_NAME_SELECTOR, "Название элемента");
            var iconDescription = new Description(_ICON_SELECTOR, "Иконка элемента");

            checkBoxComponent = GetComponent().WithDescription(checkBoxDescription).Perform();
            nameComponent = GetComponent().WithDescription(nameDescription).Perform();
            iconComponent = GetComponent().WithDescription(iconDescription).Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual void Click() => Actions.Click();

        public virtual string GetName() => nameComponent.Properties.GetText();

        public virtual bool HasCheckBox() => checkBoxComponent.IsAvalable();

        public virtual void Hover() => Actions.Hover();

        public virtual bool IsChecked() => GetAttribute(_CHECKED_ATTRIBUTE, this).Equals("true");

        public bool HasIcon() => iconComponent.IsAvalable();

        public string GetIcon() => GetProperty("background-image", iconComponent);
    }
}
