using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.TodoItem
{
    public class CreateItemInputValidator
    : CommandInputValidatorFor<CreateItem>
    {
        public CreateItemInputValidator()
        {
            RuleFor(cmd => cmd.List)
                .NotEmpty()
                .WithMessage("Please set the list to add to");

            RuleFor(cmd => cmd.Text)
                .NotEmpty()
                .WithMessage("Need some text in the todo item");
        }
    }
}
