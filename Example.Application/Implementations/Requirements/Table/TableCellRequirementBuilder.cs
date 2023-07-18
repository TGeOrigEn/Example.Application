using Empyrean.Core.Extensions;
using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Table;

namespace Example.Application.Implementations.Requirements.Table
{
    public sealed class TableCellRequirement<TComponent> : TableCellRequirementBuilder<TComponent, TableCellRequirement<TComponent>> where TComponent : ITableCellComponent { }

    public sealed class TableCellRequirement : TableCellRequirementBuilder<ITableCellComponent, TableCellRequirement> { }

    public abstract class TableCellRequirementBuilder<TComponent, TBuilder> : ApplicationWebComponentRequirementBuilder<TComponent, TBuilder>
        where TBuilder : TableCellRequirementBuilder<TComponent, TBuilder>
        where TComponent : ITableCellComponent
    {
        public virtual IOperationBuilder<TComponent, TBuilder> HasCheckBox(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasCheckBox(), flag, "Имеет флаг"));

        public virtual IOperationBuilder<TComponent, TBuilder> HasIcon(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasIcon(), flag, "Имеет иконку"));

        public virtual IOperationBuilder<TComponent, TBuilder> IsChecked(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.IsChecked(), flag, "Флаг"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByColumn(ITableColumnComponent column)
        {
            int GetColumnIndex()
            {
                var headerRequirement = new WebComponentRequirement<ITableColumnComponent>();
                return column.Should(headerRequirement.IsAvalable().Perform()).Index + 1;
            }

            var description = $"Относится к '{column}'";

            return CreateBuilder(new Requirement<TComponent, int>(component => component.Index, () => GetColumnIndex(), description));
        }

        public override IOperationBuilder<TComponent, TBuilder> ByValueEquality(string? value) =>
            CreateBuilder(new Requirement<TComponent, string?>(component => component.GetValue(), value, "Имеет значение"));

        public virtual IOperationBuilder<TComponent, TBuilder> ByIconEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetIcon(), value, "Имеет иконку"));

        public override IOperationBuilder<TComponent, TBuilder> ByValueContent(string? value) =>
            CreateBuilder(new Requirement<TComponent, string?>(component => component.GetValue(), value, "Содержит значение", ByStringContent));

        public virtual IOperationBuilder<TComponent, TBuilder> ByIconContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetIcon(), value, "Содержит иконку", ByStringContent));
    }
}
