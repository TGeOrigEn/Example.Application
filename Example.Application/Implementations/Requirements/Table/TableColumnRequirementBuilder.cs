using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Table;
using static Example.Application.Interfaces.Components.Primary.Table.ITableColumnComponent;

namespace Example.Application.Implementations.Requirements.Table
{
    public sealed class TableColumnRequirement<TComponent> : TableColumnRequirementBuilder<TComponent, TableColumnRequirement<TComponent>> where TComponent : ITableColumnComponent { }

    public sealed class TableColumnRequirement : TableColumnRequirementBuilder<ITableColumnComponent, TableColumnRequirement> { }

    public abstract class TableColumnRequirementBuilder<TComponent, TBuilder> : ApplicationWebComponentRequirementBuilder<TComponent, TBuilder>
        where TBuilder : TableColumnRequirementBuilder<TComponent, TBuilder>
        where TComponent : ITableColumnComponent
    {
        public IOperationBuilder<TComponent, TBuilder> BySortEquality(SortVariant value) =>
            CreateBuilder(new Requirement<TComponent, SortVariant>(component => component.GetSort(), value, "Сортировка"));

        public IOperationBuilder<TComponent, TBuilder> ByNameEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Имеет имя"));

        public IOperationBuilder<TComponent, TBuilder> ByNameContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Содержит имя", ByStringContent));
    }
}
