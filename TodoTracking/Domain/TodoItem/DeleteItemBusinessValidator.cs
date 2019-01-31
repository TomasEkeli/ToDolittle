using System;
using Concepts.TodoItem;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.TodoItem
{
    public class DeleteItemBusinessValidator
    : CommandBusinessValidatorFor<DeleteItem>
    {
        MustBeAnExistingList _beAnExistingList;
        MustBeATaskOnTheList _beATaskOnTheList;

        public DeleteItemBusinessValidator(
            MustBeAnExistingList beAnExistingList,
            MustBeATaskOnTheList beATaskOnTheList
        )
        {
            _beAnExistingList = beAnExistingList;
            _beATaskOnTheList = beATaskOnTheList;

            RuleFor(cmd => cmd)
                .Must(BeAnExistingList)
                .WithMessage(ValidationStrings.ListDoesNotExist);

            RuleFor(cmd => cmd)
                .Must(BeATaskOnTheList)
                .WithMessage(ValidationStrings.RuleDoesNotExistOnTheList);
        }

        bool BeAnExistingList(DeleteItem cmd)
        {
            return _beAnExistingList(cmd.List);
        }

        bool BeATaskOnTheList(DeleteItem cmd)
        {
            return _beATaskOnTheList(cmd.List, cmd.Text);
        }
    }
}
