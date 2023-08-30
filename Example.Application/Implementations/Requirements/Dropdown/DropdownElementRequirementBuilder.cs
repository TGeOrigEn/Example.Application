using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Dropdown;

namespace Example.Application.Implementations.Requirements.Dropdown
{
    public sealed class DropdownElementRequirement<TComponent> : DropdownElementRequirementBuilder<TComponent, DropdownElementRequirement<TComponent>> where TComponent : IDropdownElementComponent { }

    public sealed class DropdownElementRequirement : DropdownElementRequirementBuilder<IDropdownElementComponent, DropdownElementRequirement> { }

    public abstract class DropdownElementRequirementBuilder<TComponent, TBuilder> : ApplicationWebComponentRequirementBuilder<TComponent, TBuilder>
        where TBuilder : DropdownElementRequirementBuilder<TComponent, TBuilder>
        where TComponent : IDropdownElementComponent
    {
        public virtual IRequirementCombiner<TComponent, TBuilder> HasIcon(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasIcon(), flag, "Имеет иконку"));

        public virtual IRequirementCombiner<TComponent, TBuilder> ByNameEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Имеет имя"));

        public virtual IRequirementCombiner<TComponent, TBuilder> ByNameContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Содержит имя", ByStringContent));

        public virtual IRequirementCombiner<TComponent, TBuilder> ByIconEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Имеет иконку"));

        public virtual IRequirementCombiner<TComponent, TBuilder> ByIconContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Содержит иконку", ByStringContent));
    }
}
