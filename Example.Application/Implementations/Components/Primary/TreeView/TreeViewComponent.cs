using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.TreeView;

namespace Example.Application.Implementations.Components.Primary.TreeView
{
    public class TreeViewComponent : ApplicationWebComponent, ITreeViewComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Дерево объектов");

        private const string _DEFAULT_SELECTOR = "div[id^='treeview'][class^='x-tree-view']";

        protected TreeViewComponent() { }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual IWebComponentCollectionBuilder<ITreeViewElementComponent> GetElements() =>
            GetComponents<ITreeViewElementComponent>().WithType(typeof(TreeViewElementComponent));

        public virtual IWebComponentBuilder<ITreeViewElementComponent> GetElement() =>
            GetComponent<ITreeViewElementComponent>().WithType(typeof(TreeViewElementComponent));
    }
}
