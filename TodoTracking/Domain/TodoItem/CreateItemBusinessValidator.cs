using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.TodoItem
{
    public class CreateItemBusinessValidator
    : CommandBusinessValidatorFor<CreateItem>
    {
        MustNotBeATaskOnTheList _notBeATaskOnTheList;

        public CreateItemBusinessValidator(
            MustNotBeATaskOnTheList notBeATaskOnTheList
        )
        {
            _notBeATaskOnTheList = notBeATaskOnTheList;

            RuleFor(cmd => cmd)
                .Must(NotBeATaskOnTheList)
                .WithMessage(ValidationStrings.RuleDoesNotExistOnTheList);
        }

        bool NotBeATaskOnTheList(CreateItem cmd)
        {
            return _notBeATaskOnTheList(cmd.List, cmd.Text);
        }
    }
}
