using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components;

namespace Example.Application.Implementations.Requirements
{
    public sealed class ApplicationWebComponentRequirement<TComponent> : ApplicationWebComponentRequirementBuilder<TComponent, ApplicationWebComponentRequirement<TComponent>> where TComponent : IApplicationWebComponent { }

    public sealed class ApplicationWebComponentRequirement : ApplicationWebComponentRequirementBuilder<IApplicationWebComponent, ApplicationWebComponentRequirement> { }

    public abstract class ApplicationWebComponentRequirementBuilder<TComponent, TBuilder> : WebComponentRequirementBuilder<TComponent, TBuilder>
        where TBuilder : ApplicationWebComponentRequirementBuilder<TComponent, TBuilder>
        where TComponent : IApplicationWebComponent
    {
        public virtual IOperationBuilder<TComponent, TBuilder> HasReference(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasReference(), flag, "Имеет ссылку"));

        public virtual IOperationBuilder<TComponent, TBuilder> HasTip(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasTip(), flag, "Имеет подсказку"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByReferenceEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetReference(), value, "Имеет ссылку"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByTipEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetTip(), value, "Имеет подсказку"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByReferenceContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetReference(), value, "Содержит ссылку", ByStringContent));

        public virtual IOperationBuilder<TComponent, TBuilder> ByTipContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetTip(), value, "Содержит подсказку", ByStringContent));
    }
}
