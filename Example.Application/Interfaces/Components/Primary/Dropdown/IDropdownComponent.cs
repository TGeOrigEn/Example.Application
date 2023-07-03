using Empyrean.Core.Interfaces;

namespace Example.Application.Interfaces.Components.Primary.Dropdown
{
    public interface IDropdownComponent : IApplicationWebComponent
    {
        IWebComponentCollectionBuilder<IDropdownElementComponent> GetElements();

        IWebComponentBuilder<IDropdownElementComponent> GetElement();
    }
}
