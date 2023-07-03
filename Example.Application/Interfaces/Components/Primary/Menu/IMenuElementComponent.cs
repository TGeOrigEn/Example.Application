namespace Example.Application.Interfaces.Components.Primary.Menu
{
    public interface IMenuElementComponent : IApplicationWebComponent
    {
        bool HasIcon();

        bool HasCheckBox();

        bool IsChecked();

        string GetName();

        string GetIcon();

        void Hover();

        void Click();
    }
}
