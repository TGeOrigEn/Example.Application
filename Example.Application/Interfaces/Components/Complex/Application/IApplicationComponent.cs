using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Complex.AdvancedSearch;
using Example.Application.Interfaces.Components.Primary.Dropdown;
using Example.Application.Interfaces.Components.Primary.Loading;
using Example.Application.Interfaces.Components.Primary.Menu;
using Example.Application.Interfaces.Components.Primary.TreeView;
using Example.Application.Interfaces.Components.Primary.Window;

namespace Example.Application.Interfaces.Components.Complex.Application
{
    public interface IApplicationComponent : IApplicationWebComponent
    {
        IAdvancedSearchComponent AdvancedSearch { get; }

        IDropdownComponent Dropdown { get; }

        ITreeViewComponent TreeView { get; }

        ILoadingComponent Loading { get; }

        IBodyComponent Body { get; }

        IHeadComponent Head { get; }

        IWebComponentBuilder<IMessageBoxComponent> GetMessageBox();

        IWebComponentBuilder<IWindowComponent> GetWindow();

        IWebComponentBuilder<IMenuComponent> GetMenu();
    }
}
