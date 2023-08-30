using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Buttons;

namespace Example.Application.Implementations.Requirements.Buttons
{
    public sealed class ButtonRequirement<TComponent> : ButtonRequirementBuilder<TComponent, ButtonRequirement<TComponent>> where TComponent : IButtonComponent { }

    public sealed class ButtonRequirement : ButtonRequirementBuilder<IButtonComponent, ButtonRequirement> { }

    public abstract class ButtonRequirementBuilder<TComponent, TBuilder> : ApplicationWebComponentRequirementBuilder<TComponent, TBuilder>
        where TBuilder : ButtonRequirementBuilder<TComponent, TBuilder>
        where TComponent : IButtonComponent
    {
        public IRequirementCombiner<TComponent, TBuilder> HasName(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasName(), flag, "Имеет имя"));

        public virtual IRequirementCombiner<TComponent, TBuilder> ByNameEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Имеет имя"));

        public virtual IRequirementCombiner<TComponent, TBuilder> ByNameContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Содержит имя", ByStringContent));
    }
}
