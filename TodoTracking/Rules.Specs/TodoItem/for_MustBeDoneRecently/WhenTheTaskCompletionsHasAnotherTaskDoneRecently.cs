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
    public class WhenTheTaskCompletionsHasAnotherTaskDoneRecently 
    : given.TheMustBeDoneRecentlyRule
    {
        Establish the_list_has_a_recent_completion_of_some_other_task = () =>
        {
            list_id = Guid.NewGuid();
            text = "Some todo text";
            var someOtherTask = "Do something else";

            var read_model_with_no_completions = new TaskCompletions
            {
                Id = list_id,
                TaskCompletion = new Dictionary<TodoText, DateTime>
                {
                    [someOtherTask] = DateTime.UtcNow.AddHours(-2)
                }
            };

            _repository
                .GetById(list_id)
                .Returns(read_model_with_no_completions);

        };
    
        Because the_rule_is_checked = () =>
            result = _rule.Rule(list_id, text);
    
        It fails_because_the_task_completed_just_recently_was_a_different_one = () =>
            result.ShouldBeFalse();

        static ListId list_id;
        static TodoText text;
        static bool result;
    }
}