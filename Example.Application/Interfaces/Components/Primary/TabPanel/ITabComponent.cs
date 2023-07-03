namespace Example.Application.Interfaces.Components.Primary.TabPanel
{
    public interface ITabComponent : IApplicationWebComponent
    {
        bool CanClose();

        bool IsSelected();

        string GetName();

        void Close();

        void Click();
    }
}
