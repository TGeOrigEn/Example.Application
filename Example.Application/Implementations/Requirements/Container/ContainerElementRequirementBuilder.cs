using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Container;

namespace Example.Application.Implementations.Requirements.Dropdown
{
    public sealed class ContainerElementRequirement<TComponent> : ContainerElementRequirementBuilder<TComponent, ContainerElementRequirement<TComponent>> where TComponent : IContainerElementComponent { }

    public sealed class ContainerElementRequirement : ContainerElementRequirementBuilder<IContainerElementComponent, ContainerElementRequirement> { }

    public abstract class ContainerElementRequirementBuilder<TComponent, TBuilder> : ApplicationWebComponentRequirementBuilder<TComponent, TBuilder>
        where TBuilder : ContainerElementRequirementBuilder<TComponent, TBuilder>
        where TComponent : IContainerElementComponent
    {
        public virtual IOperationBuilder<TComponent, TBuilder> HasIcon(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasIcon(), flag, "Имеет иконку"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByNameEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Имеет имя"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByNameContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Содержит имя", ByStringContent));

        public virtual IOperationBuilder<TComponent, TBuilder> ByIconEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Имеет иконку"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByIconContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Содержит иконку", ByStringContent));
    }
}
