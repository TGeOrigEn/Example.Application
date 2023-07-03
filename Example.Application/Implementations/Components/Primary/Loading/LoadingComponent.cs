using Empyrean.Core.Extensions;
using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Loading;
using System;

namespace Example.Application.Implementations.Components.Primary.Loading
{
    public class LoadingComponent : ApplicationWebComponent, ILoadingComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Индикатор загрузки");

        private const string _DEFAULT_SELECTOR = "div[id^='loadmask'][class^='x-component x-border-box'][aria-hidden='false']";

        private const string _MESSAGE_SELECTOR = "div[class*='x-mask-msg-text']";

        protected IWebComponent messageComponent;

        protected LoadingComponent()
        {
            var messageDescription = new Description(_MESSAGE_SELECTOR, "Сообщение загрузки");

            messageComponent = GetComponent()
                .WithDescription(messageDescription)
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual string GetMessage() => messageComponent.Properties.GetText();

        public virtual void Wait(TimeSpan timeout)
        {
            var requirement = new WebComponentRequirement().IsAvalable();

            this.Has(requirement.Perform(), timeout);
            this.Has(requirement.No().Perform(), timeout);

            if (this.Until(requirement.Perform(), TimeSpan.FromSeconds(1)))
                Wait(timeout);
        }
    }
}
