using Example.Application.Interfaces.Components.Primary.Buttons;
using Example.Application.Interfaces.Components.Primary.Fields;

namespace Example.Application.Interfaces.Components.Complex.Forms
{
    public interface IAuthorizationFormComponent : IApplicationWebComponent
    {
        public IFieldComponent UsernameField { get; }

        public IFieldComponent PasswordField { get; }

        public IButtonComponent LogInButton { get; }

        public IAuthorizationFormComponent LogIn(string username, string password);
    }
}
