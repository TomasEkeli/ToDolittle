using System;
using System.Collections.Generic;
using Concepts.TodoItem;
using Machine.Specifications;
using NSubstitute;
using Read.TodoItem;
using Rules.TodoItem;

namespace Rules.Specs.TodoItem.for_MustBeDoneRecently
{
    [Subject(typeof(MustBeDoneRecently))]
    public class WhenTheTaskCompletionsHasTheTaskDoneTooLongAgo 
    : given.TheMustBeDoneRecentlyRule
    {
        Establish the_list_has_an_ancient_completion = () =>
        {
            list_id = Guid.NewGuid();
            text = "Some todo text";

            var read_model_with_no_completions = new TaskCompletions
            {
                Id = list_id,
                TaskCompletion = new Dictionary<TodoText, DateTime>
                {
                    [text] = DateTime.UtcNow.AddDays(-100)
                }
            };

            _repository
                .GetById(list_id)
                .Returns(read_model_with_no_completions);
        };
    
        Because the_rule_is_checked = () =>
            result = _rule.Rule(list_id, text);
    
        It fails_because_the_task_was_completed_too_long_ago = () =>
            result.ShouldBeFalse();

        static ListId list_id;
        static TodoText text;
        static bool result;
    }
}