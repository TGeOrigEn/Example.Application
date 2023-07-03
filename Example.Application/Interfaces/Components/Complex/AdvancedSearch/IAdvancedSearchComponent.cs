using Example.Application.Interfaces.Components.Primary.Buttons;
using Example.Application.Interfaces.Components.Primary.Fields;
using Example.Application.Interfaces.Components.Primary.Fields.Dropdown;
using Example.Application.Interfaces.Components.Primary.FieldSet;

namespace Example.Application.Interfaces.Components.Complex.AdvancedSearch
{
    public interface IAdvancedSearchComponent : IApplicationWebComponent
    {
        interface IFieldSetObjectComponent : IFieldSetComponent
        {
            IDropdownFieldComponent TypeField { get; }

            IFieldComponent DescriptionField { get; }
        }

        interface IFieldSetStatusComponent : IFieldSetComponent
        {
            IDropdownFieldComponent StatusField { get; }

            IDropdownFieldComponent UserField { get; }

            IDropdownFieldComponent DateModificationField { get; }
        }

        interface IFieldSetDateModificationComponent : IFieldSetComponent
        {
            IDropdownFieldComponent UserField { get; }

            IDropdownFieldComponent DateModificationField { get; }
        }

        interface IFieldSetDateCreationComponent : IFieldSetComponent
        {
            IDropdownFieldComponent UserField { get; }

            IDropdownFieldComponent DateCreationField { get; }
        }

        interface IFieldSetFileComponent : IFieldSetComponent
        {
            IFieldComponent NameField { get; }

            IDropdownFieldComponent TypeField { get; }

            IFieldComponent ContentField { get; }
        }

        interface IFieldSetVerisonComponent : IFieldSetComponent
        {
            IFieldComponent NameField { get; }

            IFieldComponent CommentField { get; }

            IDropdownFieldComponent UserField { get; }

            IDropdownFieldComponent DateCreationField { get; }
        }

        IButtonComponent SearchButton { get; }

        IButtonComponent ClearButton { get; }

        IFieldSetDateModificationComponent DateModificationFieldSet { get; }

        IFieldSetDateCreationComponent DateCreationFieldSet { get; }

        IFieldSetVerisonComponent VersionFieldSet { get; }

        IFieldSetObjectComponent ObjectFieldSet { get; }

        IFieldSetStatusComponent StatusFieldSet { get; }

        IFieldSetFileComponent FileFieldSet { get; }
    }
}
