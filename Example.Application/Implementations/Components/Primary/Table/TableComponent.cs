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
            GetComponent<ITableCellComponent>(typeof(TableCellComponent));

        public virtual IWebComponentCollectionBuilder<ITableCellComponent> GetCells() =>
            GetComponents<ITableCellComponent>(typeof(TableCellComponent));

        public virtual IWebComponentBuilder<ITableColumnComponent> GetColumn() =>
            GetComponent<ITableColumnComponent>(typeof(TableColumnComponent));

        public virtual IWebComponentCollectionBuilder<ITableColumnComponent> GetColumns() =>
            GetComponents<ITableColumnComponent>(typeof(TableColumnComponent));

        public virtual IWebComponentBuilder<ITableRowComponent> GetRow() =>
            GetComponent<ITableRowComponent>(typeof(TableRowComponent));

        public virtual IWebComponentCollectionBuilder<ITableRowComponent> GetRows() =>
            GetComponents<ITableRowComponent>(typeof(TableRowComponent));
    }
}
