using Empyrean.Core.Interfaces;

namespace Example.Application.Interfaces.Components.Primary.TabPanel
{
    public interface ITabPanelComponent : IApplicationWebComponent
    {
        IWebComponentCollectionBuilder<ITabComponent> GetTabs();

        IWebComponentBuilder<ITabComponent> GetTab();
    }
}
