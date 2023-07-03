namespace Example.Application.Interfaces.Components.Primary.Dropdown
{
    public interface IDropdownElementComponent : IApplicationWebComponent
    {
        bool HasIcon();

        string GetName();

        string GetIcon();

        void Hover();

        void Click();
    }
}
