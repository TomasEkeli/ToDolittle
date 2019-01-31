using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.TodoItem
{
    public class MarkItemAsNotDoneBusinessValidator 
    : CommandBusinessValidatorFor<MarkItemAsNotDone>
    {
        MustBeAnExistingList _beAnExistingList;
        MustBeATaskOnTheList _beATaskOnTheList;
        MustBeDoneOnTheList _beDonOnTheList;

        public MarkItemAsNotDoneBusinessValidator(
            MustBeAnExistingList beAnExistingList,
            MustBeATaskOnTheList beATaskOnTheList,
            MustBeDoneOnTheList beDoneOnTheList
        )
        {
            _beAnExistingList = beAnExistingList;
            _beATaskOnTheList = beATaskOnTheList;
            _beDonOnTheList = beDoneOnTheList;

            RuleFor(cmd => cmd)
                .Must(BeAnExistingList)
                .WithMessage(ValidationStrings.ListDoesNotExist);

            RuleFor(cmd => cmd)
                .Must(BeATaskOnTheList)
                .WithMessage(ValidationStrings.RuleDoesNotExistOnTheList);

            RuleFor(cmd => cmd)
                .Must(BeDone)
                .WithMessage(ValidationStrings.TaskIsNotDone);
        }

        bool BeDone(MarkItemAsNotDone cmd)
        {
            return _beDonOnTheList(cmd.List, cmd.Text);
        }

        bool BeAnExistingList(MarkItemAsNotDone cmd)
        {
            return _beAnExistingList(cmd.List);
        }

        bool BeATaskOnTheList(MarkItemAsNotDone cmd)
        {
            return _beATaskOnTheList(cmd.List, cmd.Text);
        }
    }        
}
