using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Dropdown;

namespace Example.Application.Implementations.Components.Primary.Dropdown
{
    public class DropdownComponent : ApplicationWebComponent, IDropdownComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Выпадающий список");

        private const string _DEFAULT_SELECTOR = "div[class^='x-boundlist x-boundlist-floating']:not([style*='display'])";

        protected DropdownComponent() { }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual IWebComponentBuilder<IDropdownElementComponent> GetElement() =>
            GetComponent<IDropdownElementComponent>(typeof(DropdownElementComponent));

        public virtual IWebComponentCollectionBuilder<IDropdownElementComponent> GetElements() =>
            GetComponents<IDropdownElementComponent>(typeof(DropdownElementComponent));
    }
}
