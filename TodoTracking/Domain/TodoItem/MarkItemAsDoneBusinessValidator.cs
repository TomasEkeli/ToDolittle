using System;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.TodoItem
{
    public class MarkItemAsDoneBusinessValidator 
    : CommandBusinessValidatorFor<MarkItemAsDone>
    {
        MustBeAnExistingList _beAnExistingList;
        MustBeATaskOnTheList _beATaskOnTheList;
        MustNotBeDoneOnTheList _beNotDoneOnTheList;

        public MarkItemAsDoneBusinessValidator(
            MustBeAnExistingList beAnExistingList,
            MustBeATaskOnTheList beATaskOnTheList,
            MustNotBeDoneOnTheList beNotDoneOnTheList
        )
        {
            _beAnExistingList = beAnExistingList;
            _beATaskOnTheList = beATaskOnTheList;
            _beNotDoneOnTheList = beNotDoneOnTheList;

            RuleFor(cmd => cmd)
                .Must(BeAnExistingList)
                .WithMessage(ValidationStrings.ListDoesNotExist);

            RuleFor(cmd => cmd)
                .Must(BeATaskOnTheList)
                .WithMessage(ValidationStrings.RuleDoesNotExistOnTheList);

            RuleFor(cmd => cmd)
                .Must(NotBeDone)
                .WithMessage(ValidationStrings.TaskIsAlreadyDone);
        }

        bool NotBeDone(MarkItemAsDone cmd)
        {
            return _beNotDoneOnTheList(cmd.List, cmd.Text);
        }

        bool BeAnExistingList(MarkItemAsDone cmd)
        {
            return _beAnExistingList(cmd.List);
        }

        bool BeATaskOnTheList(MarkItemAsDone cmd)
        {
            return _beATaskOnTheList(cmd.List, cmd.Text);
        }
    }
}
