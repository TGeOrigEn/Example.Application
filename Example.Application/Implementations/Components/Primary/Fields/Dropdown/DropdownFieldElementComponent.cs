using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Fields.Dropdown;

namespace Example.Application.Implementations.Components.Primary.Fields.Dropdown
{
    public class DropdownFieldElementComponent : ApplicationWebComponent, IDropdownFieldElementComponent
    {
        public static IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Элемент поля");

        private const string _DEFAULT_SELECTOR = "li[class^='x-tagfield-item']";

        private const string _REMOVE_SELECTOR = "div[class='x-tagfield-item-close']";

        private const string _NAME_SELECTOR = "div[class='x-tagfield-item-text']";

        protected IWebComponent nameComponent;

        protected IWebComponent removeButton;

        protected DropdownFieldElementComponent()
        {
            var nameDescription = new Description(_NAME_SELECTOR, "Имя элемента");
            var removeDescription = new Description(_REMOVE_SELECTOR, "Кнопка 'Удалить'");

            nameComponent = GetComponent().WithDescription(nameDescription).Perform();
            removeButton = GetComponent().WithDescription(removeDescription).Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual string GetName() => nameComponent.Properties.GetText();

        public virtual void Remove() => removeButton.Actions.Click();
    }
}
