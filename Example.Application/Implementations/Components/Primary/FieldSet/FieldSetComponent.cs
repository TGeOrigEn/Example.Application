using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Fields;
using Example.Application.Interfaces.Components.Primary.FieldSet;

namespace Example.Application.Implementations.Components.Primary.FieldSet
{
    public class FieldSetComponent : ApplicationWebComponent, IFieldSetComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Набор полей");

        private const string _DEFAULT_SELECTOR = "fieldset[id^='fieldset']:not([style*='display'])";

        private const string _LEGEND_SELECTOR = "legend[id*='legend']";

        protected IWebComponent legendComponent;

        protected FieldSetComponent()
        {
            var legendDescription = new Description(_LEGEND_SELECTOR, "Легенда набора полей");

            legendComponent = GetComponent().WithDescription(legendDescription).Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual bool HasLegend() => legendComponent.IsAvalable();

        public virtual IWebComponentBuilder<TField> GetField<TField>() where TField : IFieldComponent => GetComponent<TField>();

        public virtual string GetLegend() => legendComponent.Properties.GetText();
    }
}
