using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Menu;

namespace Example.Application.Implementations.Components.Primary.Menu
{
    public class MenuComponent : ApplicationWebComponent, IMenuComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Меню");

        private const string _DEFAULT_SELECTOR = "div[id^='menu'][class^='x-menu x-layer x-menu-default x-border-box']:not([aria-expanded='false'])";

        protected MenuComponent() { }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual IWebComponentBuilder<IMenuElementComponent> GetElement() =>
            GetComponent<IMenuElementComponent>().WithType(typeof(MenuElementComponent));

        public virtual IWebComponentCollectionBuilder<IMenuElementComponent> GetElements() =>
            GetComponents<IMenuElementComponent>().WithType(typeof(MenuElementComponent));
    }
}
