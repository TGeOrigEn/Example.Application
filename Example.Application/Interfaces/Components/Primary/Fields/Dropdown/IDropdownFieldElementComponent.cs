namespace Example.Application.Interfaces.Components.Primary.Fields.Dropdown
{
    public interface IDropdownFieldElementComponent : IApplicationWebComponent
    {
        string GetName();

        void Remove();
    }
}
