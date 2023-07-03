using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Implementations.Components.Primary.Buttons;
using Example.Application.Implementations.Components.Primary.Table;
using Example.Application.Implementations.Requirements.Buttons;
using Example.Application.Interfaces.Components.Complex.Application;
using Example.Application.Interfaces.Components.Primary.Buttons;
using Example.Application.Interfaces.Components.Primary.Table;

namespace Example.Application.Implementations.Components.Complex.Application
{
    public class FileViewPanelComponent : ApplicationWebComponent, IFileViewPanelComponent
    {
        public static readonly IDescription DEAFULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Панель просмотра файлов");

        private const string _DEFAULT_SELECTOR = "div[id^='tdmsObjectFilesView'][class^='x-panel x-box-item']";

        private const string _TABLE_SELECTOR = "div[id^='grid'][class^='x-panel x-fit-item']";

        private const string _ADD_FILE_SELECTOR = "a[href='#add']";

        public IButtonComponent ShowTableButton { get; protected set; }

        public ITableComponent Table { get; protected set; }

        protected IWebComponent addFileButton;

        protected FileViewPanelComponent()
        {
            var buttonRequirement = new ButtonRequirement<ToolButtonComponent>();

            var a = buttonRequirement.ByTipEquality("Раскрыть панель").Perform();
            var b = buttonRequirement.ByTipEquality("Скрыть панель").Perform();
            var c = buttonRequirement.HasTip().Perform();

            var showTableRequirement = c.And(a.Or(b).Isolate());
            var tableDescription = TableComponent.DEFAULT_DESCRIPTION.With(new Selector(_TABLE_SELECTOR));
            var addFileDescription = new Description(_ADD_FILE_SELECTOR, "Кнопка 'Добавить...'");

            ShowTableButton = GetComponent<ToolButtonComponent>().WithRequirement(showTableRequirement).Perform();
            Table = GetComponent<TableComponent>().WithDescription(tableDescription).Perform();
            addFileButton = GetComponent().WithDescription(addFileDescription).Perform();
        }

        protected override IDescription InitializeDescription() => DEAFULT_DESCRIPTION;

        public void Add(string path) => throw new System.NotImplementedException();
    }
}
