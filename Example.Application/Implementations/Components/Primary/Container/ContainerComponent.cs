using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Container;

namespace Example.Application.Implementations.Components.Primary.Container
{
    public class ContainerComponent : ApplicationWebComponent, IContainerComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Контейнер файлов");

        private const string _DEFAULT_SELECTOR = "div[id^='fieldcontainer'][class^='x-container x-form-fieldcontainer']";

        private const string _LABEL_SELECTOR = "label[id*='label']";

        protected IWebComponent labelComponent;

        protected ContainerComponent()
        {
            var labelDescription = new Description(_LABEL_SELECTOR, "Название контейнера");

            labelComponent = GetComponent().WithDescription(labelDescription).Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public IWebComponentBuilder<IContainerElementComponent> GetElement() =>
            GetComponent<IContainerElementComponent>(typeof(ContainerElementComponent));

        public IWebComponentCollectionBuilder<IContainerElementComponent> GetElements() =>
            GetComponents<IContainerElementComponent>(typeof(ContainerElementComponent));

        public string GetLabel() => labelComponent.Properties.GetText();

        public bool HasLabel() => labelComponent.IsAvalable() && labelComponent.Properties.IsDisplayed();
    }
}
