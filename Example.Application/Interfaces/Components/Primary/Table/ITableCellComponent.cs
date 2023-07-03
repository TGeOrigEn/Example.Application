namespace Example.Application.Interfaces.Components.Primary.Table
{
    public interface ITableCellComponent : IApplicationWebComponent
    {
        bool HasCheckBox();

        bool HasIcon();

        bool IsChecked();

        string GetValue();

        string GetIcon();

        void ContextClick();

        void DoubleClick();

        void Click();
    }
}
