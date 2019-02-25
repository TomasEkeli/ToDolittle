using System;
using Concepts.TodoItem;
using Machine.Specifications;
using Rules.TodoItem;

namespace Rules.Specs.TodoItem.for_MustBeDoneRecently
{
    [Subject(typeof(MustBeDoneRecently))]
    public class WhenTheTaskCompletionDoesNotExist 
    : given.TheMustBeDoneRecentlyRule
    {
        Establish that_no_such_list_exists = () =>
        {
            list_id = Guid.NewGuid();
            text = "Some todo text";
        };
    
        Because the_rule_is_checked = () =>
            result = _rule.Rule(list_id, text);
    
        It fails_because_the_task_list_does_not_exist = () =>
            result.ShouldBeFalse();

        static ListId list_id;
        static TodoText text;
        static bool result;
    }
}