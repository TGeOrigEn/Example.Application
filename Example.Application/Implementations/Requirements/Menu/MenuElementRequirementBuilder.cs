﻿using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Menu;

namespace Example.Application.Implementations.Requirements.Menu
{
    public sealed class MenuElementRequirement<TComponent> : MenuElementRequirementBuilder<TComponent, MenuElementRequirement<TComponent>> where TComponent : IMenuElementComponent { }

    public sealed class MenuElementRequirement : MenuElementRequirementBuilder<IMenuElementComponent, MenuElementRequirement> { }

    public abstract class MenuElementRequirementBuilder<TComponent, TBuilder> : ApplicationWebComponentRequirementBuilder<TComponent, TBuilder>
        where TBuilder : MenuElementRequirementBuilder<TComponent, TBuilder>
        where TComponent : IMenuElementComponent
    {
        public IRequirementCombiner<TComponent, TBuilder> IsChecked(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.IsChecked(), flag, "Значение флага"));

        public IRequirementCombiner<TComponent, TBuilder> HasCheckBox(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasCheckBox(), flag, "Имеет флаг"));

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
