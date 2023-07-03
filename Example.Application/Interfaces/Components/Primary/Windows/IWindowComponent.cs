using Example.Application.Interfaces.Components.Primary.Buttons;

namespace Example.Application.Interfaces.Components.Primary.Window
{
    public interface IWindowComponent : IApplicationWebComponent
    {
        public IButtonComponent MaximizeButton { get; }

        public IButtonComponent CloseButton { get; }

        public IButtonComponent CancelButton { get; }

        public IButtonComponent ApplyButton { get; }

        public IButtonComponent YesButton { get; }

        public IButtonComponent OkButton { get; }

        public IButtonComponent NoButton { get; } 

        bool IsMaximized();

        bool CanMaximize();

        bool CanClose();

        string GetTitle();
    }
}
