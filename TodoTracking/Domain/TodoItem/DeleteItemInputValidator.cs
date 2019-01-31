using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.TodoItem
{
    public class DeleteItemInputValidator 
    : CommandInputValidatorFor<DeleteItem>
    {
        public DeleteItemInputValidator()
        {
             RuleFor(cmd => cmd.List)
                .NotEmpty()
                .WithMessage("Please set the list to delete from");

            RuleFor(cmd => cmd.Text)
                .NotEmpty()
                .WithMessage("Need some text in the todo item");
        }
    }
}
