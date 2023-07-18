using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Fields;
using OpenQA.Selenium;

namespace Example.Application.Implementations.Components.Primary.Fields
{
    public class FieldComponent : ApplicationWebComponent, IFieldComponent
    {
        private const string _PLACEHOLDER_ATTRIBUTE = "placeholder";

        private const string _REQUIRED_ATTRIBUTE = "aria-required";

        private const string _DISABLED_ATTRIBUTE = "aria-disabled";

        private const string _INVALID_ATTRIBUTE = "aria-invalid";

        private const string _READONLY_ATTRIBUTE = "readonly";

        public static IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Поле");

        private const string _DEFAULT_SELECTOR = "div[class^='x-field']:not([style*='display'])";

        private const string _INPUT_SELECTOR = "input[class*='x-form-field']";

        private const string _LABEL_SELECTOR = "span[class*='label-text']";

        protected IWebComponent labelComponent;

        protected IWebComponent inputComponent;

        protected FieldComponent()
        {
            var labelDescription = new Description(_LABEL_SELECTOR, "Ярлык поля");
            var inputDescription = new Description(_INPUT_SELECTOR, "Ввод поля");

            labelComponent = GetComponent().WithDescription(labelDescription).Perform();
            inputComponent = GetComponent().WithDescription(inputDescription).Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual bool IsReadOnly() => GetAttribute(_READONLY_ATTRIBUTE, inputComponent).Equals("true");

        public virtual bool IsRequired() => GetAttribute(_REQUIRED_ATTRIBUTE, inputComponent).Equals("true");

        public virtual bool IsEnabled() => GetAttribute(_DISABLED_ATTRIBUTE, inputComponent).Equals("false");

        public virtual bool IsInvalid() => GetAttribute(_INVALID_ATTRIBUTE, inputComponent).Equals("true");

        public virtual bool HasLabel() => labelComponent.IsAvalable();

        public bool HasPlaceholder() => HasAttribute(_PLACEHOLDER_ATTRIBUTE, inputComponent);

        public virtual string GetPlaceholder() => GetAttribute(_PLACEHOLDER_ATTRIBUTE, inputComponent);

        public virtual string GetLabel() => labelComponent.Properties.GetText();

        public virtual string GetValue() => GetValue(inputComponent);

        public virtual void SetValue(string value) => inputComponent.Actions.SetValue(value);

        public virtual void SendKeys(string keys) => inputComponent.Actions.SendKeys(keys);

        public virtual void Sumbit() => inputComponent.Actions.SendKeys(Keys.Enter);

        public virtual void Clear() => inputComponent.Actions.Clear();
    }
}
