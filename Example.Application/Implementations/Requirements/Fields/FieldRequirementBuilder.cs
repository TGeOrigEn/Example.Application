using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Fields;

namespace Example.Application.Implementations.Requirements.Fields
{
    public sealed class FieldRequirement<TComponent> : FieldRequirementBuilder<TComponent, FieldRequirement<TComponent>> where TComponent : IFieldComponent { }

    public sealed class FieldRequirement : FieldRequirementBuilder<IFieldComponent, FieldRequirement> { }

    public abstract class FieldRequirementBuilder<TComponent, TBuilder> : ApplicationWebComponentRequirementBuilder<TComponent, TBuilder>
        where TBuilder : FieldRequirementBuilder<TComponent, TBuilder>
        where TComponent : IFieldComponent
    {
        public virtual IOperationBuilder<TComponent, TBuilder> HasLabel(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasLabel(), flag, "Имеет заголовок"));

        public virtual IOperationBuilder<TComponent, TBuilder> HasPlaceholder(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasPlaceholder(), flag, "Имеет заполнитель"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByPlaceholderEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetPlaceholder(), value, "Имеет заполнитель", ByStringContent));

        public virtual IOperationBuilder<TComponent, TBuilder> ByLabelEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetLabel(), value, "Имеет заголовок", ByStringContent));

        public override IOperationBuilder<TComponent, TBuilder> ByValueEquality(string? value) =>
           CreateBuilder(new Requirement<TComponent, string?>(component => component.GetValue(), value, "Имеет значение"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByPlaceholderContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetPlaceholder(), value, "Содержит заполнитель", ByStringContent));

        public virtual IOperationBuilder<TComponent, TBuilder> ByLabelContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetLabel(), value, "Содержит заголовок", ByStringContent));

        public override IOperationBuilder<TComponent, TBuilder> ByValueContent(string? value) =>
            CreateBuilder(new Requirement<TComponent, string?>(component => component.GetValue(), value, "Содержит значение", ByStringContent));
    }
}
