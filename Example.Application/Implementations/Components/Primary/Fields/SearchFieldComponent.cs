using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Implementations.Requirements;
using Example.Application.Interfaces.Components;
using Example.Application.Interfaces.Components.Primary.Fields;

namespace Example.Application.Implementations.Components.Primary.Fields
{
    public class SearchFieldComponent : FieldComponent, ISearchFieldComponent
    {
        public new static IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Поле для поиска");

        private const string _DEFAULT_SELECTOR = "div[id^='tdmsSearch'][class^='x-field']:not([style*='display'])";

        protected IApplicationWebComponent advanceButton;

        protected IApplicationWebComponent searchButton;

        protected IApplicationWebComponent removeButton;

        protected SearchFieldComponent()
        {
            var requirement = new ApplicationWebComponentRequirement<ApplicationWebComponent>();

            advanceButton = GetComponent<ApplicationWebComponent>()
                .WithRequirement(requirement.ByTipEquality("Расширенный поиск").Perform())
                .WithDescription(new Description("*", "Кпнока"))
                .Perform();

            removeButton = GetComponent<ApplicationWebComponent>()
                .WithRequirement(requirement.ByTipEquality("Очистить").Perform())
                .WithDescription(new Description("*", "Кпнока"))
                .Perform();

            searchButton = GetComponent<ApplicationWebComponent>()
                .WithRequirement(requirement.ByTipEquality("Искать").Perform())
                .WithDescription(new Description("*", "Кпнока"))
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual void ClickOnTrigger() => advanceButton.Actions.Click();

        public virtual void Remove() => removeButton.Actions.Click();

        public virtual void Search() => searchButton.Actions.Click();
    }
}
