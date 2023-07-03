using Empyrean.Core.Interfaces;

namespace Example.Application.Interfaces.Components.Primary.TreeView
{
    public interface ITreeViewComponent : IApplicationWebComponent
    {
        IWebComponentCollectionBuilder<ITreeViewElementComponent> GetElements();

        IWebComponentBuilder<ITreeViewElementComponent> GetElement();
    }
}
