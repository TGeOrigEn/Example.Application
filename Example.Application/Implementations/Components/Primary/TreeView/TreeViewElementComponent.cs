using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.TreeView;
using static Example.Application.Interfaces.Components.Primary.TreeView.ITreeViewElementComponent;

namespace Example.Application.Implementations.Components.Primary.TreeView
{
    public class TreeViewElementComponent : ApplicationWebComponent, ITreeViewElementComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Элемент дерева объектов");

        private const string _DEFAULT_SELECTOR = "table[id^='treeview'] tr[class*='x-grid-row']";

        private const string _EXPAND_BUTTON_SELECTOR = "div[class*='x-tree-elbow'][class*='plus']";

        private const string _NAME_SELECTOR = "span[class^='x-tree-node-text']";

        private const string _ICON_SELECTOR = "img[class*='x-tree-icon']";

        protected IWebComponent nameComponent;

        protected IWebComponent expandButton;

        protected IWebComponent iconComponent;

        protected TreeViewElementComponent()
        {
            var expandDescription = new Description(_EXPAND_BUTTON_SELECTOR, "Кнопка 'Развернуть/Свернуть'");

            var nameDescription = new Description(_NAME_SELECTOR, "Название элемента");

            var iconDescriptopn = new Description(_ICON_SELECTOR, "Изображение элемента");

            expandButton = GetComponent()
                .WithDescription(expandDescription)
                .Perform();

            nameComponent = GetComponent()
                .WithDescription(nameDescription)
                .Perform();

            iconComponent = GetComponent()
                .WithDescription(iconDescriptopn)
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual void Click() => Actions.Click();

        public virtual void ContextClick() => Actions.ContextClick();

        public virtual void Expand(ExpandVariant variant = ExpandVariant.DoubleClick)
        {
            if (variant == ExpandVariant.DoubleClick) Actions.DoubleClick();
            else expandButton.Actions.Click();
        }

        public virtual string GetIcon() => GetProperty("background-image", iconComponent);

        public virtual string GetName() => nameComponent.Properties.GetText();

        public virtual bool HasIcon() => iconComponent.IsAvalable();

        public virtual void Hover() => Actions.Hover();

        public virtual bool IsExpanded() => GetAttribute("aria-expanded", this).Equals("true");

        public virtual bool IsExpandable() => expandButton.IsAvalable();
    }
}
