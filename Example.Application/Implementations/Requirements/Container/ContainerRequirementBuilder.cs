using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Container;

namespace Example.Application.Implementations.Requirements.Dropdown
{
    public sealed class ContainerRequirement<TComponent> : ContainerRequirementBuilder<TComponent, ContainerRequirement<TComponent>> where TComponent : IContainerComponent { }

    public sealed class ContainerRequirement : ContainerRequirementBuilder<IContainerComponent, ContainerRequirement> { }

    public abstract class ContainerRequirementBuilder<TComponent, TBuilder> : ApplicationWebComponentRequirementBuilder<TComponent, TBuilder>
        where TBuilder : ContainerRequirementBuilder<TComponent, TBuilder>
        where TComponent : IContainerComponent
    {
        public virtual IOperationBuilder<TComponent, TBuilder> HasLabel(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasLabel(), flag, "Имеет название"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByLabelEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetLabel(), value, "Имеет название"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByLabelContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetLabel(), value, "Содержит название", ByStringContent));
    }
}
