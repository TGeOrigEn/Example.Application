using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Implementations.Components.Primary.Table;
using Example.Application.Interfaces.Components.Complex.Application;
using Example.Application.Interfaces.Components.Primary.Table;

namespace Example.Application.Implementations.Components.Complex.Application
{
    public class ViewPanelComponent : ApplicationWebComponent, IViewPanelComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Панель представления");

        private const string _DEFAULT_SELECTOR = "div[id^='panel-'][id$='-body'][class='x-panel-body x-panel-body-default x-border-layout-ct x-panel-body-default']";

        private const string _STATUS_SELECTOR = "span[style*='font-weight: normal']";

        private const string _HEADER_SELECTOR = "div[id^='panel-'][id$='_header']";

        private const string _NAME_SELECTOR = "span[style*='font-weight: bold']";

        private const string _ICON_SELECTOR = "img";

        private const string _TABLE_SELECTOR = "div[id^='tdmsContentView'][class^='x-panel x-fit-item']";

        public ITableComponent Table { get; protected set; }

        protected IWebComponent statusComponent;

        protected IWebComponent headerComponent;

        protected IWebComponent nameComponent;

        protected IWebComponent iconComponent;

        protected ViewPanelComponent()
        {
            var statusDescription = new Description(_STATUS_SELECTOR, "Статус объекта");
            var nameDescription = new Description(_NAME_SELECTOR, "Имя объекта");
            var headerDescription = new Description(_HEADER_SELECTOR, "Заголовок");
            var iconDescription = new Description(_ICON_SELECTOR, "Иконка объекта");
            var tableDescription = TableComponent.DEFAULT_DESCRIPTION.With(new Selector(_TABLE_SELECTOR));

            headerComponent = GetComponent().WithDescription(headerDescription).Perform();
            nameComponent = headerComponent.GetComponent().WithDescription(nameDescription).Perform();
            statusComponent = headerComponent.GetComponent().WithDescription(statusDescription).Perform();
            iconComponent = headerComponent.GetComponent().WithDescription(iconDescription).Perform();

            Table = GetComponent<TableComponent>().WithDescription(tableDescription).Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public string GetIcon() => GetProperty("background-image", iconComponent);

        public string GetName() => nameComponent.Properties.GetText();

        public string GetStatus() => statusComponent.Properties.GetText();
    }
}
