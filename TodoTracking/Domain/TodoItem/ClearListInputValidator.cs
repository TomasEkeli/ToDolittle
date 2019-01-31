using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.TodoItem
{
    public class ClearListInputValidator 
    : CommandInputValidatorFor<ClearList>
    {
        public ClearListInputValidator()
        {
            RuleFor(cmd => cmd.List)
                .NotEmpty()
                .WithMessage(ValidationStrings.ListIdMustBeSet);
        }
    }
}
