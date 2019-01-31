using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.TodoItem
{
    public class ClearListBusinessValidator 
    : CommandBusinessValidatorFor<ClearList>
    {
        private MustBeAnExistingList _mustBeAnExistingList;

        public ClearListBusinessValidator(
            MustBeAnExistingList beAnExistingList
        )
        {
            _mustBeAnExistingList = beAnExistingList;

            RuleFor(cmd => cmd)
                .Must(BeAnExistingList)
                .WithMessage(ValidationStrings.ListDoesNotExist);
        }

        bool BeAnExistingList(ClearList cmd)
        {
            return _mustBeAnExistingList(cmd.List);
        }
    }
}
