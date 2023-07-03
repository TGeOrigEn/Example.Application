using Empyrean.Core.Interfaces;

namespace Example.Application.Interfaces.Components.Primary.Fields.Dropdown
{
    public interface IDropdownFieldComponent : IFieldComponent
    {
        bool CanHaveElements();

        IWebComponentCollectionBuilder<IDropdownFieldElementComponent> GetElements();

        IWebComponentBuilder<IDropdownFieldElementComponent> GetElement();

        void ClickOnTrigger();
    }
}
