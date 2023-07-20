using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Implementations.Components.Primary.Dropdown;
using Example.Application.Implementations.Components.Primary.Loading;
using Example.Application.Implementations.Components.Primary.Menu;
using Example.Application.Implementations.Components.Primary.TreeView;
using Example.Application.Implementations.Components.Primary.Windows;
using Example.Application.Interfaces.Components.Complex.AdvancedSearch;
using Example.Application.Interfaces.Components.Complex.Application;
using Example.Application.Interfaces.Components.Primary.Dropdown;
using Example.Application.Interfaces.Components.Primary.Loading;
using Example.Application.Interfaces.Components.Primary.Menu;
using Example.Application.Interfaces.Components.Primary.TreeView;
using Example.Application.Interfaces.Components.Primary.Window;

namespace Example.Application.Implementations.Components.Complex.Application
{
    public class ApplicationComponent : ApplicationWebComponent, IApplicationComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Приложение");

        private const string _DEFAULT_SELECTOR = "body[id='ext-element-1']";

        private const string _TREE_VIEW_SELECTPR = "div[id^='treepanel'][class^='x-panel x-autowidth-table']:not([style*='display'])";

        public IAdvancedSearchComponent AdvancedSearch { get; protected set; }

        public IDropdownComponent Dropdown { get; protected set; }

        public ITreeViewComponent TreeView { get; protected set; }

        public ILoadingComponent Loading { get; protected set; }

        public IBodyComponent Body { get; protected set; }

        public IHeadComponent Head { get; protected set; }

        protected ApplicationComponent()
        {
            var treeViewDescription = TreeViewComponent.DEFAULT_DESCRIPTION.With(new Selector(_TREE_VIEW_SELECTPR));

            Head = GetComponent<HeadComponent>().Perform();
            Body = GetComponent<BodyComponent>().Perform();
            Loading = GetComponent<LoadingComponent>().Perform();
            Dropdown = GetComponent<DropdownComponent>().Perform();
            TreeView = GetComponent<TreeViewComponent>().WithDescription(treeViewDescription).Perform();
            AdvancedSearch = null!;
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public IWebComponentBuilder<IMenuComponent> GetMenu() =>
            GetComponent<IMenuComponent>().WithType(typeof(MenuComponent));

        public IWebComponentBuilder<IMessageBoxComponent> GetMessageBox() =>
            GetComponent<IMessageBoxComponent>().WithType(typeof(MessageBoxComponent));

        public IWebComponentBuilder<IWindowComponent> GetWindow() =>
            GetComponent<IWindowComponent>().WithType(typeof(WindowComponent));
    }
}
