using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.TodoItem
{
    public class MarkItemAsDoneInputValidator 
    : CommandInputValidatorFor<MarkItemAsDone>
    {
        public MarkItemAsDoneInputValidator()
        {
            RuleFor(cmd => cmd.List)
                .NotEmpty()
                .WithMessage("Please set the list to mark as done on");

            RuleFor(cmd => cmd.Text)
                .NotEmpty()
                .WithMessage("Need some text to identify the todo item to mark as done");
        }
    }
}
