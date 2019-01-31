using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.TodoItem
{
    public class MarkItemAsNotDoneInputValidator
    : CommandInputValidatorFor<MarkItemAsNotDone>
    {
        public MarkItemAsNotDoneInputValidator()
        {
            RuleFor(cmd => cmd.List)
                .NotEmpty()
                .WithMessage("Please set the list to mark as not done on");

            RuleFor(cmd => cmd.Text)
                .NotEmpty()
                .WithMessage("Need some text to identify the todo item to mark as not done");
        }
    }
}
