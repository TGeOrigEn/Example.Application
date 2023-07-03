using Empyrean.Core.Exceptions;
using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components;

namespace Example.Application.Implementations.Components
{
    public class ApplicationWebComponent : WebComponent, IApplicationWebComponent
    {
        private const string _REFERENCE_ATTRIBUTE = "data-reference";

        private const string _TIP_ATTRIBUTE = "data-qtip";

        protected IWebComponent referenceComponent;

        protected IWebComponent tipComponent;

        protected ApplicationWebComponent()
        {
            referenceComponent = this;
            tipComponent = this;
        }

        public virtual string GetReference() => GetAttribute(_REFERENCE_ATTRIBUTE, referenceComponent);

        public virtual string GetTip() => GetAttribute(_TIP_ATTRIBUTE, tipComponent);

        public virtual bool HasReference() => HasAttribute(_REFERENCE_ATTRIBUTE, referenceComponent);

        public virtual bool HasTip() => HasAttribute(_TIP_ATTRIBUTE, tipComponent);

        protected static bool HasAttribute(string attributeName, IWebComponent attributeComponent)
        {
            if (attributeComponent.IsAvalable())
                return attributeComponent.Properties.GetAttribute(attributeName) != null;

            return false;
        }

        protected static string GetAttribute(string attributeName, IWebComponent attributeComponent) =>
            attributeComponent.Properties.GetAttribute(attributeName) ?? string.Empty;

        protected static string GetProperty(string propertyName, IWebComponent attributeComponent) =>
            attributeComponent.Properties.GetProperty(propertyName) ?? string.Empty;

        protected static string GetValue(IWebComponent inputComponent) => inputComponent.Properties.GetValue()
            ?? throw new WebComponentException($"Веб-компонент '{inputComponent.Hierarchy}' не поддерживает атрибут 'value'.");
    }
}
