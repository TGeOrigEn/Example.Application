using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Fields.Dropdown;

namespace Example.Application.Implementations.Requirements.Fields
{
    public sealed class DropdownFieldElementRequiremen<TComponent> : DropdownFieldElementRequiremenBuilder<TComponent, DropdownFieldElementRequiremen<TComponent>> where TComponent : IDropdownFieldElementComponent { }

    public sealed class DropdownFieldElementRequiremen : DropdownFieldElementRequiremenBuilder<IDropdownFieldElementComponent, DropdownFieldElementRequiremen> { }

    public abstract class DropdownFieldElementRequiremenBuilder<TComponent, TBuilder> : ApplicationWebComponentRequirementBuilder<TComponent, TBuilder>
        where TBuilder : DropdownFieldElementRequiremenBuilder<TComponent, TBuilder>
        where TComponent : IDropdownFieldElementComponent
    {
        public virtual IOperationBuilder<TComponent, TBuilder> ByNameEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Имеет имя"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByNameContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Содержит имя", ByStringContent));
    }
}
