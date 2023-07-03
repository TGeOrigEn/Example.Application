using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Table;

namespace Example.Application.Implementations.Components.Primary.Table
{
    public class TableCellComponent : ApplicationWebComponent, ITableCellComponent
    {
        public static IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Ячейка таблицы");

        private const string _DEFAULT_SELECTOR = "td[class^='x-grid-cell']";

        private const string _CHECK_BOX_SELECTOR = "span[class^='x-grid-checkcolumn']";

        private const string _VALUE_SELECTOR = "div[class^='x-grid-cell-inner']";

        private const string _ICON_SELECTOR = "div[class*='tdms-icn-pic']";

        protected IWebComponent checkBoxComponent;

        protected IWebComponent valueComponent;

        protected IWebComponent iconComponent;

        protected TableCellComponent()
        {
            var checkBoxDescription = new Description(_CHECK_BOX_SELECTOR, "Флаг ячейки");
            var valueDescription = new Description(_VALUE_SELECTOR, "Значение ячейки");
            var iconDescription = new Description(_ICON_SELECTOR, "Картинка ячейки");

            checkBoxComponent = GetComponent().WithDescription(checkBoxDescription).Perform();
            valueComponent = GetComponent().WithDescription(valueDescription).Perform();
            iconComponent = GetComponent().WithDescription(iconDescription).Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual void Click() => Actions.Click();

        public virtual void ContextClick() => Actions.ContextClick();

        public virtual void DoubleClick() => Actions.DoubleClick();

        public virtual string GetIcon() => GetAttribute("url", iconComponent);

        public virtual string GetValue() => valueComponent.Properties.GetText();

        public virtual bool HasCheckBox() => checkBoxComponent.IsAvalable();

        public virtual bool HasIcon() => iconComponent.IsAvalable();

        public virtual bool IsChecked() => checkBoxComponent.Properties.GetClass().Contains("checked");
    }
}
