using Example.Application.Interfaces.Components.Primary.Buttons;
using Example.Application.Interfaces.Components.Primary.Table;

namespace Example.Application.Interfaces.Components.Complex.Application
{
    public interface IFileViewPanelComponent : IApplicationWebComponent
    {
        IButtonComponent ShowTableButton { get; }

        ITableComponent Table { get; }

        void Add(string path);
    }
}
