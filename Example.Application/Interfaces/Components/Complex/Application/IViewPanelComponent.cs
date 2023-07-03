using Example.Application.Interfaces.Components.Primary.Table;

namespace Example.Application.Interfaces.Components.Complex.Application
{
    public interface IViewPanelComponent : IApplicationWebComponent
    {
        ITableComponent Table { get; }

        string GetStatus();

        string GetName();

        string GetIcon();
    }
}
