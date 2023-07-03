using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Table;

namespace Example.Application.Implementations.Components.Primary.Table
{
    public class TableRowComponent : ApplicationWebComponent, ITableRowComponent
    {
        private const string _SELECTED_ATTRIBUTE = "aria-selected";

        public static IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Строка таблицы");

        private const string _DEFAULT_SELECTOR = "table[id^='gridview']";

        protected TableRowComponent() { }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual void Click() => Actions.Click();

        public virtual void ContextClick() => Actions.ContextClick();

        public virtual void DoubleClick() => Actions.DoubleClick();

        public virtual IWebComponentBuilder<ITableCellComponent> GetCell() =>
            GetComponent<ITableCellComponent>(typeof(TableCellComponent));

        public virtual IWebComponentCollectionBuilder<ITableCellComponent> GetCells() =>
            GetComponents<ITableCellComponent>(typeof(TableCellComponent));

        public virtual bool IsSelected() => GetAttribute(_SELECTED_ATTRIBUTE, this).Equals("true");
    }
}
