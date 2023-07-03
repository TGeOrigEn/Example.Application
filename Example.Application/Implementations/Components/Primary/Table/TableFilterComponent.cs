using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Interfaces.Components.Primary.Table;

namespace Example.Application.Implementations.Components.Primary.Table
{
    public class TableFilterComponent : ApplicationWebComponent, ITableFilterComponent
    {
        public static IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Фильтр таблицы");

        private const string _DEFAULT_SELECTOR = "div[id^='contentfilter'][id*='bodyEl']";

        private const string _TRIGGER_SELECTOR = "div[id*='trigger-picker']";

        private const string _INPUT_SELECTOR = "input[class*='x-form-field']";

        protected IWebComponent triggerComponent;

        protected IWebComponent inputComponent;

        protected TableFilterComponent()
        {
            var triggerDescription = new Description(_TRIGGER_SELECTOR, "Кнопка-триггер");

            var inputDescription = new Description(_INPUT_SELECTOR, "Ввод фильтра");

            triggerComponent = GetComponent()
                .WithDescription(triggerDescription)
                .Perform();

            inputComponent = GetComponent()
                .WithDescription(inputDescription)
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual void Clear() => inputComponent.Actions.Clear();

        public virtual void ClickOnTrigger() => triggerComponent.Actions.Click();

        public virtual string GetValue() => GetValue(inputComponent);

        public virtual void SendKeys(string keys) => inputComponent.Actions.SendKeys(keys);

        public virtual void SetValue(string value) => inputComponent.Actions.SetValue(value);
    }
}
