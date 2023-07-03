using System;

namespace Example.Application.Interfaces.Components.Primary.Loading
{
    public interface ILoadingComponent : IApplicationWebComponent
    {
        string GetMessage();

        void Wait(TimeSpan timeout);
    }
}
