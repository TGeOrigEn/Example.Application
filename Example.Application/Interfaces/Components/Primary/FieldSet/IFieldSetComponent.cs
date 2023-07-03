using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Fields;

namespace Example.Application.Interfaces.Components.Primary.FieldSet
{
    public interface IFieldSetComponent : IApplicationWebComponent
    {
        bool HasLegend();

        string GetLegend();

        IWebComponentBuilder<TField> GetField<TField>() where TField : IFieldComponent;
    }
}
