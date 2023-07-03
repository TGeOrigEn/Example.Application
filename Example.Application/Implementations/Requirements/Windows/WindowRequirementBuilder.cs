using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Window;

namespace Example.Application.Implementations.Requirements.Windows
{
    public sealed class WindowRequirement<TComponent> : WindowRequirementBuilder<TComponent, WindowRequirement<TComponent>> where TComponent : IWindowComponent { }

    public sealed class WindowRequirement : WindowRequirementBuilder<IWindowComponent, WindowRequirement> { }

    public abstract class WindowRequirementBuilder<TComponent, TBuilder> : ApplicationWebComponentRequirementBuilder<TComponent, TBuilder>
        where TBuilder : WindowRequirementBuilder<TComponent, TBuilder>
        where TComponent : IWindowComponent
    {
        public virtual IOperationBuilder<TComponent, TBuilder> ByTitleEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetTitle(), value, "Имеет имя"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByTitleContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetTitle(), value, "Содержит имя", ByStringContent));
    }
}
