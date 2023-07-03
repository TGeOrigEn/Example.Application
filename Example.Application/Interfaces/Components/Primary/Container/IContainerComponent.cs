using Empyrean.Core.Interfaces;

namespace Example.Application.Interfaces.Components.Primary.Container
{
    public interface IContainerComponent : IApplicationWebComponent
    {
        bool HasLabel();

        string GetLabel();

        IWebComponentBuilder<IContainerElementComponent> GetElement();

        IWebComponentCollectionBuilder<IContainerElementComponent> GetElements();
    }
}
