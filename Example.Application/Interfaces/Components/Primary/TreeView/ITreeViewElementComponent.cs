namespace Example.Application.Interfaces.Components.Primary.TreeView
{
    public interface ITreeViewElementComponent : IApplicationWebComponent
    {
        enum ExpandVariant { DoubleClick, ClickOnExpandButton }

        bool IsExpandable();

        bool IsExpanded();

        bool HasIcon();

        string GetName();

        string GetIcon();

        void Expand(ExpandVariant variant = ExpandVariant.DoubleClick);

        void ContextClick();

        void Click();

        void Hover();
    }
}
