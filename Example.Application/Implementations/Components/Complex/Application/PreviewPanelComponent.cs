using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Implementations.Components.Primary.Table;
using Example.Application.Implementations.Components.Primary.TabPanel;
using Example.Application.Interfaces.Components.Complex.Application;
using Example.Application.Interfaces.Components.Primary.Table;
using Example.Application.Interfaces.Components.Primary.TabPanel;
using System;

namespace Example.Application.Implementations.Components.Complex.Application
{
    public class PreviewPanelComponent : ApplicationWebComponent, IPreviewPanelComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Заголовок приложения");

        private const string _DEFAULT_SELECTOR = "div[id^='tdmsObjectPropertiesView'][class='x-panel x-fit-item x-panel-default']";

        private const string _TABLE_SELECTOR = "div[class^='x-panel x-tabpanel-child x-panel-default'][aria-hidden='false']";

        public IFileViewPanelComponent FileViewPanel { get; protected set; }

        public ITabPanelComponent TabPanel { get; protected set; }

        public ITableComponent Table { get; protected set; }

        protected PreviewPanelComponent()
        {
            var tableDescription = TableComponent.DEFAULT_DESCRIPTION.With(new Selector(_TABLE_SELECTOR));

            Table = GetComponent<TableComponent>().WithDescription(tableDescription).Perform();
            FileViewPanel = GetComponent<FileViewPanelComponent>().Perform();
            TabPanel = GetComponent<TabPanelComponent>().Perform();        
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;
    }
}
