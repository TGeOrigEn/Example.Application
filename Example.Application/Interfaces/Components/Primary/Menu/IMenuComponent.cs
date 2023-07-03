using Empyrean.Core.Interfaces;

namespace Example.Application.Interfaces.Components.Primary.Menu
{
    public interface IMenuComponent : IApplicationWebComponent
    {
        IWebComponentCollectionBuilder<IMenuElementComponent> GetElements();

        IWebComponentBuilder<IMenuElementComponent> GetElement();
    }
}
