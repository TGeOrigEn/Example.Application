using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Implementations.Components.Primary.Fields;
using Example.Application.Interfaces.Components.Primary.Fields.Dropdown;

namespace Example.Application.Implementations.Components.Primary.Fields.Dropdown
{
    public class DropdownFieldComponent : FieldComponent, IDropdownFieldComponent
    {
        public new static IDescription DEFAULT_DESCRIPTION = FieldComponent.DEFAULT_DESCRIPTION.With("Поле выбора");

        private const string _CONTAINER_SELECTOR = "ul[id^='tagfield'][id*='itemList']";

        private const string _TRIGGER_SELECTOR = "div[id*='trigger-picker']";

        protected IWebComponent containerComponent;

        protected IWebComponent triggerComponent;

        protected DropdownFieldComponent()
        {
            var containerDescription = new Description(_CONTAINER_SELECTOR, "Контейнер для элементов");
            var triggerDescription = new Description(_TRIGGER_SELECTOR, "Кнопка 'Стрелка'");

            containerComponent = GetComponent().WithDescription(containerDescription).Perform();
            triggerComponent = GetComponent().WithDescription(triggerDescription).Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual bool CanHaveElements() => containerComponent.IsAvalable();

        public virtual IWebComponentCollectionBuilder<IDropdownFieldElementComponent> GetElements() =>
            GetComponents<IDropdownFieldElementComponent>(typeof(DropdownFieldElementComponent));

        public virtual IWebComponentBuilder<IDropdownFieldElementComponent> GetElement() =>
            GetComponent<IDropdownFieldElementComponent>(typeof(DropdownFieldElementComponent));

        public virtual void ClickOnTrigger() => triggerComponent.Actions.Click();
    }
}
