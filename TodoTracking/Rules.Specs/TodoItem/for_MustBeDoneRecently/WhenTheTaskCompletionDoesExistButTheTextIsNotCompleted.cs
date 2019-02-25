using System;
using Concepts.TodoItem;
using Machine.Specifications;
using NSubstitute;
using Read.TodoItem;
using Rules.TodoItem;

namespace Rules.Specs.TodoItem.for_MustBeDoneRecently
{
    [Subject(typeof(MustBeDoneRecently))]
    public class WhenTheTaskCompletionDoesExistButTheTextIsNotCompleted 
    : given.TheMustBeDoneRecentlyRule
    {
        Establish the_list_has_no_completions = () =>
        {
            list_id = Guid.NewGuid();
            text = "Some todo text";

            var read_model_with_no_completions = new TaskCompletions
            {
                Id = list_id,
            };

            _repository
                .GetById(list_id)
                .Returns(read_model_with_no_completions);
        };
    
        Because the_rule_is_checked = () =>
            result = _rule.Rule(list_id, text);
    
        It fails_because_the_task_is_not_on_the_list_of_completions = () =>
            result.ShouldBeFalse();

        static ListId list_id;
        static TodoText text;
        static bool result;
    }
}