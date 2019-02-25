using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.TodoItem
{
    public class MarkItemAsNotDoneBusinessValidator 
    : CommandBusinessValidatorFor<MarkItemAsNotDone>
    {
        MustBeAnExistingList _beAnExistingList;
        MustBeATaskOnTheList _beATaskOnTheList;
        MustBeDoneOnTheList _beDoneOnTheList;
        MustBeDoneRecently _beDoneRecently;

        public MarkItemAsNotDoneBusinessValidator(
            MustBeAnExistingList beAnExistingList,
            MustBeATaskOnTheList beATaskOnTheList,
            MustBeDoneOnTheList beDoneOnTheList,
            MustBeDoneRecently beDoneRecently
        )
        {
            _beAnExistingList = beAnExistingList;
            _beATaskOnTheList = beATaskOnTheList;
            _beDoneOnTheList = beDoneOnTheList;
            _beDoneRecently = beDoneRecently;

            RuleFor(cmd => cmd)
                .Must(BeAnExistingList)
                .WithMessage(ValidationStrings.ListDoesNotExist);

            RuleFor(cmd => cmd)
                .Must(BeATaskOnTheList)
                .WithMessage(ValidationStrings.RuleDoesNotExistOnTheList);

            RuleFor(cmd => cmd)
                .Must(BeDone)
                .WithMessage(ValidationStrings.TaskIsNotDone);

            RuleFor(cmd => cmd)
                .Must(BeDoneRecently)
                .WithMessage(ValidationStrings.TaskMustBeRecentlyDone);
        }

        bool BeDone(MarkItemAsNotDone cmd)
        {
            return _beDoneOnTheList(cmd.List, cmd.Text);
        }

        bool BeDoneRecently(MarkItemAsNotDone cmd)
        {
            return _beDoneRecently(cmd.List, cmd.Text);
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
