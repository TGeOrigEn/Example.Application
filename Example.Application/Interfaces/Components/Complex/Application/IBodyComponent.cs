using Example.Application.Interfaces.Components.Primary.TreeView;

namespace Example.Application.Interfaces.Components.Complex.Application
{
    public interface IBodyComponent : IApplicationWebComponent
    {
        IPreviewPanelComponent PreviewPanel { get; }

        IViewPanelComponent ViewPanel { get; }

        ITreeViewComponent TreeView { get; }

        IToolBarComponent ToolBar { get; }
    }
}
