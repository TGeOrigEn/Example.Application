namespace Example.Application.Interfaces.Components.Primary.Container
{
    public interface IContainerElementComponent : IApplicationWebComponent
    {
        bool CanRemove();

        bool HasIcon();

        string GetIcon();

        string GetName();

        void Remove();

        void Click();
    }
}
