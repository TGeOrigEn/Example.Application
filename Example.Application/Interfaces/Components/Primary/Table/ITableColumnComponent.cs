namespace Example.Application.Interfaces.Components.Primary.Table
{
    public interface ITableColumnComponent : IApplicationWebComponent
    {
        enum SortVariant { None, ASC, DESC }

        ITableFilterComponent Filter { get; }

        string GetName();

        SortVariant GetSort();

        void ClickOnTrigger();

        void Click();

        void Hover();
    }
}
