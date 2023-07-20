using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.TabPanel;

namespace Example.Application.Implementations.Components.Primary.TabPanel
{
    public class TabPanelComponent : ApplicationWebComponent, ITabPanelComponent
    {
        public static IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Панель вкладок");

        private const string _DEFAULT_SELECTOR = "div[id^='tabbar'][class^='x-tab-bar tdms-sub-header']";

        protected TabPanelComponent() { }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual IWebComponentBuilder<ITabComponent> GetTab() =>
            GetComponent<ITabComponent>().WithType(typeof(TabComponent));

        public virtual IWebComponentCollectionBuilder<ITabComponent> GetTabs() =>
            GetComponents<ITabComponent>().WithType(typeof(TabComponent));
    }
}
