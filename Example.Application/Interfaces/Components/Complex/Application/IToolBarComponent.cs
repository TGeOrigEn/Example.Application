using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Buttons;

namespace Example.Application.Interfaces.Components.Complex.Application
{
    public interface IToolBarComponent : IApplicationWebComponent
    {
        IButtonComponent ShowPreviewPanelButton { get; }

        IButtonComponent DownloadArchiveButton { get; }

        IButtonComponent ShowTreeViewButton { get; }

        IButtonComponent WriteMessageButton { get; }

        IButtonComponent CreateObjectButton { get; }

        IButtonComponent AttachFilesButton { get; }

        IButtonComponent EditCardButton { get; }

        IButtonComponent SystemButton { get; }

        IButtonComponent UpdateButton { get; }

        IButtonComponent BackButton { get; }

        IWebComponentBuilder<IButtonComponent> GetButton();
    }
}
