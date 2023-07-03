using Empyrean.Core.Implementations;
using Empyrean.Core.Interfaces;
using Example.Application.Implementations.Components.Primary.Buttons;
using Example.Application.Implementations.Components.Primary.Fields;
using Example.Application.Implementations.Requirements.Buttons;
using Example.Application.Implementations.Requirements.Fields;
using Example.Application.Interfaces.Components.Complex.Forms;
using Example.Application.Interfaces.Components.Primary.Buttons;
using Example.Application.Interfaces.Components.Primary.Fields;

namespace Example.Application.Implementations.Components.Complex.Forms
{
    public class AuthorizationFormComponent : ApplicationWebComponent, IAuthorizationFormComponent
    {
        public static readonly IDescription DEFAULT_DESCRIPTION = new Description(_DEFAULT_SELECTOR, "Форма авторизации");

        private const string _DEFAULT_SELECTOR = "div[id^='form'][class*='x-panel ']";

        public IFieldComponent UsernameField { get; }

        public IFieldComponent PasswordField { get; }

        public IButtonComponent LogInButton { get; }

        protected AuthorizationFormComponent()
        {
            var usernameFieldRequirement = new FieldRequirement<FieldComponent>()
                .ByLabelEquality("Пользователь:")
                .Perform();

            var passwordFieldRequirement = new FieldRequirement<FieldComponent>()
                .ByLabelEquality("Пароль:")
                .Perform();

            var loginButtonRequirement = new ButtonRequirement<ButtonComponent>()
                .HasName()
                .And()
                .ByNameEquality("Войти")
                .Perform();

            UsernameField = GetComponent<FieldComponent>()
                .WithRequirement(usernameFieldRequirement)
                .Perform();

            PasswordField = GetComponent<FieldComponent>()
                .WithRequirement(passwordFieldRequirement)
                .Perform();

            LogInButton = GetComponent<ButtonComponent>()
                .WithRequirement(loginButtonRequirement)
                .Perform();
        }

        protected override IDescription InitializeDescription() => DEFAULT_DESCRIPTION;

        public virtual IAuthorizationFormComponent LogIn(string username, string password)
        {
            UsernameField.SetValue(username);
            PasswordField.SetValue(password);
            LogInButton.Click();
            return this;
        }
    }
}
