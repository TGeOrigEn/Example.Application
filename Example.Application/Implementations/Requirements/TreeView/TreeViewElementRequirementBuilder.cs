using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.TreeView;

namespace Example.Application.Implementations.Requirements.TreeView
{
    public sealed class TreeViewElementRequirement<TComponent> : TreeViewElementRequirementBuilder<TComponent, TreeViewElementRequirement<TComponent>> where TComponent : ITreeViewElementComponent { }

    public sealed class TreeViewElementRequirement : TreeViewElementRequirementBuilder<ITreeViewElementComponent, TreeViewElementRequirement> { }

    public abstract class TreeViewElementRequirementBuilder<TComponent, TBuilder> : ApplicationWebComponentRequirementBuilder<TComponent, TBuilder>
        where TBuilder : TreeViewElementRequirementBuilder<TComponent, TBuilder>
        where TComponent : ITreeViewElementComponent
    {
        public virtual IRequirementCombiner<TComponent, TBuilder> HasIcon(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.HasIcon(), flag, "Имеет иконку"));

        public virtual IRequirementCombiner<TComponent, TBuilder> IsExpandable(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.IsExpandable(), flag, "Разворачиваем"));

        public virtual IRequirementCombiner<TComponent, TBuilder> IsExpanded(bool flag = true) =>
            CreateBuilder(new Requirement<TComponent, bool>(component => component.IsExpanded(), flag, "Развёрнут"));

        public virtual IRequirementCombiner<TComponent, TBuilder> ByIconEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetIcon(), value, "Имеет иконку"));

        public virtual IRequirementCombiner<TComponent, TBuilder> ByNameEquality(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Имеет имя"));

        public virtual IRequirementCombiner<TComponent, TBuilder> ByNameContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetName(), value, "Содержит имя", ByStringContent));

        public virtual IRequirementCombiner<TComponent, TBuilder> ByIconContent(string value) =>
            CreateBuilder(new Requirement<TComponent, string>(component => component.GetIcon(), value, "Содержит иконку", ByStringContent));
    }
}
