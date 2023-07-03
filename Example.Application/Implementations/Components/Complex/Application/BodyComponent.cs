using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Implementations.Components.Primary.TreeView;
using Example.Application.Interfaces.Components.Complex.Application;
using Example.Application.Interfaces.Components.Primary.TreeView;

namespace Example.Application.Implementations.Components.Complex.Application
{
    public class BodyComponent : ApplicationWebComponent, IBodyComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Тело приложения");

        private const string _DEFAULT_SELECTOR = "div[id^='tdmsNavigationPage'][class*='x-panel x-fit-item']:not([class*='x-hidden-offsets'])";

        private const string _TREE_VIEW_SELECTOR = "div[id^='treeview'][class^='x-tree-view x-fit-item']";

        public IPreviewPanelComponent PreviewPanel { get; protected set; }

        public IViewPanelComponent ViewPanel { get; protected set; }

        public ITreeViewComponent TreeView { get; protected set; }

        public IToolBarComponent ToolBar { get; protected set; }

        protected BodyComponent()
        {
            var treeViewDescription = TreeViewComponent.DEFAULT_DESCRIPTION.With(new Selector(_TREE_VIEW_SELECTOR));

            TreeView = GetComponent<TreeViewComponent>().WithDescription(treeViewDescription).Perform();
            PreviewPanel = GetComponent<PreviewPanelComponent>().Perform();
            ViewPanel = GetComponent<ViewPanelComponent>().Perform();
            ToolBar = GetComponent<ToolBarComponent>().Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;
    }
}
