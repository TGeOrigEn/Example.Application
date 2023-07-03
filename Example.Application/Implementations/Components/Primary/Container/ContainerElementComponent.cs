using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Container;

namespace Example.Application.Implementations.Components.Primary.Container
{
    public class ContainerElementComponent : ApplicationWebComponent, IContainerElementComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Элемент контейнера");

        private const string _DEFAULT_SELECTOR = "*[class*='dataview'][class*='item']";

        private const string _ICON_SELECTOR = "img[style]";

        private const string _NAME_SELECTOR = "a:not([href^='#r'])";

        private const string _REMOVE_SELECTOR = "img[src='/api/images/62']";

        protected IWebComponent iconComponent;

        protected IWebComponent nameComponent;

        protected IWebComponent removeButton;

        protected ContainerElementComponent()
        {
            var iconDescription = new Description(_ICON_SELECTOR, "Иконка элемента");
            var nameDescription = new Description(_NAME_SELECTOR, "Название элемента");
            var removeDescription = new Description(_REMOVE_SELECTOR, "Кнопка 'Удалить'");

            iconComponent = GetComponent().WithDescription(iconDescription).Perform();
            nameComponent = GetComponent().WithDescription(nameDescription).Perform();
            removeButton = GetComponent().WithDescription(removeDescription).Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public bool CanRemove() => removeButton.IsAvalable();

        public void Click() => Actions.Click();

        public string GetIcon() => GetAttribute("src", iconComponent);

        public string GetName() => nameComponent.Properties.GetText();

        public bool HasIcon() => iconComponent.IsAvalable();

        public void Remove() => removeButton.Actions.Click();
    }
}
