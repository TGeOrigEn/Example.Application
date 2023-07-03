using Empyrean.Core.Interfaces;

namespace Example.Application.Interfaces.Components
{
    public interface IApplicationWebComponent : IWebComponent
    {
        bool HasReference();

        bool HasTip();

        string GetReference();

        string GetTip();
    }
}
