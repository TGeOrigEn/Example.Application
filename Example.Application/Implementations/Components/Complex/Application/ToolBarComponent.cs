using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Implementations.Components.Primary.Buttons;
using Example.Application.Implementations.Requirements.Buttons;
using Example.Application.Interfaces.Components.Complex.Application;
using Example.Application.Interfaces.Components.Primary.Buttons;

namespace Example.Application.Implementations.Components.Complex.Application
{
    public class ToolBarComponent : ApplicationWebComponent, IToolBarComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Панель инструментов");

        private const string _DEFAULT_SELECTOR = "div[id^='container'][class*='x-panel-navigation-tdms']";

        public IButtonComponent ShowPreviewPanelButton { get; protected set; }

        public IButtonComponent DownloadArchiveButton { get; protected set; }

        public IButtonComponent ShowTreeViewButton { get; protected set; }

        public IButtonComponent WriteMessageButton { get; protected set; }

        public IButtonComponent CreateObjectButton { get; protected set; }

        public IButtonComponent AttachFilesButton { get; protected set; }

        public IButtonComponent EditCardButton { get; protected set; }

        public IButtonComponent SystemButton { get; protected set; }

        public IButtonComponent UpdateButton { get; protected set; }

        public IButtonComponent BackButton { get; protected set; }

        protected ToolBarComponent()
        {
            var buttonRequirement = new ButtonRequirement<ButtonComponent>().HasTip().And();

            var showPreviewPanelRequirement = buttonRequirement.ByTipEquality("Показать/скрыть панель предварительного просмотра").Perform();
            var downloadArchiveRequirement = buttonRequirement.ByTipEquality("Скачать архив...").Perform();
            var showTreeViewRequirement = buttonRequirement.ByTipEquality("Показать/скрыть дерево").Perform();
            var writeMessageRequirement = buttonRequirement.ByTipEquality("Написать письмо").Perform();
            var createObjectRequirement = buttonRequirement.ByTipEquality("Создать...").Perform();
            var attachFilesRequirement = buttonRequirement.ByTipEquality("Добавить файлы...").Perform();
            var editCardRequirement = buttonRequirement.ByTipEquality("Редактировать карточку...").Perform();
            var systemRequirement = buttonRequirement.ByTipEquality("Системные вкладки").Perform();
            var updateRequirement = buttonRequirement.ByTipEquality("Обновить").Perform();
            var backRequirement = buttonRequirement.ByTipEquality("Вернуться").Perform();

            ShowPreviewPanelButton = GetComponent<ButtonComponent>().WithRequirement(showPreviewPanelRequirement).Perform();
            DownloadArchiveButton = GetComponent<ButtonComponent>().WithRequirement(downloadArchiveRequirement).Perform();
            ShowTreeViewButton = GetComponent<ButtonComponent>().WithRequirement(showTreeViewRequirement).Perform();
            WriteMessageButton = GetComponent<ButtonComponent>().WithRequirement(writeMessageRequirement).Perform();
            CreateObjectButton = GetComponent<ButtonComponent>().WithRequirement(createObjectRequirement).Perform();
            AttachFilesButton = GetComponent<ButtonComponent>().WithRequirement(attachFilesRequirement).Perform();
            EditCardButton = GetComponent<ButtonComponent>().WithRequirement(editCardRequirement).Perform();
            SystemButton = GetComponent<ButtonComponent>().WithRequirement(systemRequirement).Perform();
            UpdateButton = GetComponent<ButtonComponent>().WithRequirement(updateRequirement).Perform();
            BackButton = GetComponent<ButtonComponent>().WithRequirement(backRequirement).Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public IWebComponentBuilder<IButtonComponent> GetButton() =>
            GetComponent<IButtonComponent>(typeof(ButtonComponent));
    }
}
