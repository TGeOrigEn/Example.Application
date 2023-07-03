namespace Example.Application.Interfaces.Components.Primary.Buttons
{
    public interface IButtonComponent : IApplicationWebComponent
    {
        bool IsEnabled();

        bool HasName();

        string GetName();

        void Click();
    }
}
