using Empyrean.Core.Interfaces;

namespace Example.Application.Interfaces.Components.Primary.Table
{
    public interface ITableRowComponent : IApplicationWebComponent
    {
        bool IsSelected();

        IWebComponentCollectionBuilder<ITableCellComponent> GetCells();

        IWebComponentBuilder<ITableCellComponent> GetCell();

        void ContextClick();

        void DoubleClick();

        void Click();
    }
}
