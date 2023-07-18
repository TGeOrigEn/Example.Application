namespace Example.Application.Interfaces.Components.Primary.Fields
{
    public interface IFieldComponent : IApplicationWebComponent
    {
        bool IsRequired();

        bool IsReadOnly();

        bool IsEnabled();

        bool IsInvalid();

        bool HasLabel();

        bool HasPlaceholder();

        string GetPlaceholder();

        string GetValue();

        string GetLabel();

        void SetValue(string value);

        void SendKeys(string keys);

        void Sumbit();

        void Clear();
    }
}
