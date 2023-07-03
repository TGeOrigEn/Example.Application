namespace Example.Application.Interfaces.Components.Primary.Table
{
    public interface ITableFilterComponent : IApplicationWebComponent
    {
        string GetValue();

        void SetValue(string value);

        void SendKeys(string keys);

        void ClickOnTrigger();

        void Clear();
    }
}
