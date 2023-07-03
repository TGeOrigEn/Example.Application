using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Table;
using static Example.Application.Interfaces.Components.Primary.Table.ITableColumnComponent;

namespace Example.Application.Implementations.Components.Primary.Table
{
    public class TableColumnComponent : ApplicationWebComponent, ITableColumnComponent
    {
        private const string _SORT_ATTRIBUTE = "aria-sort";

        public static IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Столбец таблицы");

        private const string _DEFAULT_SELECTOR = "div[class^='x-column-header x-column-header-align-start']:not([aria-hidden='true'])";

        private const string _NAME_SELECTOR = "span[class*='x-column-header-text-inner']";

        private const string _TRIGGER_SELECTOR = "div[class*='x-column-header-trigger']";

        public ITableFilterComponent Filter { get; protected set; }

        protected IWebComponent triggerComponent;

        protected IWebComponent nameComponent;

        protected TableColumnComponent()
        {
            var triggerDescription = new Description(_TRIGGER_SELECTOR, "Триггер");

            var nameDescription = new Description(_NAME_SELECTOR, "Имя заголовка");

            triggerComponent = GetComponent()
                .WithDescription(triggerDescription)
                .Perform();

            nameComponent = GetComponent()
                .WithDescription(nameDescription)
                .Perform();

            Filter = GetComponent<TableFilterComponent>().Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual void Click() => Actions.Click();

        public virtual void ClickOnTrigger()
        {
            Actions.Hover();
            triggerComponent.Actions.Click();
        }

        public virtual string GetName() => nameComponent.Properties.GetText();

        public virtual SortVariant GetSort()
        {
            return GetAttribute(_SORT_ATTRIBUTE, this) switch
            {
                "descending" => SortVariant.DESC,
                "ascending" => SortVariant.ASC,
                _ => SortVariant.None
            };
        }

        public virtual void Hover() => Actions.Hover();
    }
}
