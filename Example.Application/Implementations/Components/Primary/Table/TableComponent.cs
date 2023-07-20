using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Table;

namespace Example.Application.Implementations.Components.Primary.Table
{
    public class TableComponent : ApplicationWebComponent, ITableComponent
    {
        public static IDescription DEFAULT_DESCRIPTION = new Description("*", "Таблица");

        protected TableComponent() { }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual IWebComponentBuilder<ITableCellComponent> GetCell() =>
            GetComponent<ITableCellComponent>().WithType(typeof(TableCellComponent));

        public virtual IWebComponentCollectionBuilder<ITableCellComponent> GetCells() =>
            GetComponents<ITableCellComponent>().WithType(typeof(TableCellComponent));

        public virtual IWebComponentBuilder<ITableColumnComponent> GetColumn() =>
            GetComponent<ITableColumnComponent>().WithType(typeof(TableColumnComponent));

        public virtual IWebComponentCollectionBuilder<ITableColumnComponent> GetColumns() =>
            GetComponents<ITableColumnComponent>().WithType(typeof(TableColumnComponent));

        public virtual IWebComponentBuilder<ITableRowComponent> GetRow() =>
            GetComponent<ITableRowComponent>().WithType(typeof(TableRowComponent));

        public virtual IWebComponentCollectionBuilder<ITableRowComponent> GetRows() =>
            GetComponents<ITableRowComponent>().WithType(typeof(TableRowComponent));
    }
}
