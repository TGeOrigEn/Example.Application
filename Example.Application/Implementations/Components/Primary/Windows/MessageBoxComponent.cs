using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Window;

namespace Example.Application.Implementations.Components.Primary.Windows
{
    public class MessageBoxComponent : WindowComponent, IMessageBoxComponent
    {
        public static new readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Окно сообщения");

        private const string _DEFAULT_SELECTOR = "div[id^='messagebox'][class^='x-window x-message-box']:not([aria-hidden='true'])";

        private const string _MESSAGE_SELECTOR = "div[class*='x-window-text']";

        private const string _FOOTER_SELECTOR = "div[class*='x-toolbar-footer']";

        protected IWebComponent messageComponent;

        protected MessageBoxComponent() : base()
        {
            var messageDescription = new Description(_MESSAGE_SELECTOR, "Сообщение окна");

            var footerDescription = new Description(_FOOTER_SELECTOR, "Нижний колонтитул окна");

            footerComponent = GetComponent()
                .WithDescription(footerDescription)
                .Perform();

            messageComponent = GetComponent()
                .WithDescription(messageDescription)
                .Perform();

            InitializeButtons(footerComponent);
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual string GetMessage() => messageComponent.Properties.GetText();
    }
}
