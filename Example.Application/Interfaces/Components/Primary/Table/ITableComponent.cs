using Empyrean.Core.Interfaces;

namespace Example.Application.Interfaces.Components.Primary.Table
{
    public interface ITableComponent : IApplicationWebComponent
    {
        IWebComponentCollectionBuilder<ITableColumnComponent> GetColumns();

        IWebComponentCollectionBuilder<ITableCellComponent> GetCells();

        IWebComponentCollectionBuilder<ITableRowComponent> GetRows();

        IWebComponentBuilder<ITableColumnComponent> GetColumn();

        IWebComponentBuilder<ITableCellComponent> GetCell();

        IWebComponentBuilder<ITableRowComponent> GetRow();
    }
}
