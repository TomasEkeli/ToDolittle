using System;
using Concepts.TodoItem;
using Machine.Specifications;
using NSubstitute;
using Rules.TodoItem;

namespace Rules.Specs.TodoItem.for_MustBeAnExistingList
{
    [Subject(typeof(MustBeAnExistingList))]
    public class WhenTheListDoesNotExist : given.TheMustBeAnExistingListRule
    {
        Establish that_no_rule_lists_exist = () =>
        {
            the_list_id = Guid.NewGuid();
            Read.TodoItem.TaskList no_read_model = null;

            _repository
                .GetById(Arg.Any<ListId>())
                .Returns(no_read_model);
        };
    
        Because checking_the_rule = () =>
            result = _rule.Rule(the_list_id);
    
        It is_broken = () =>
            result.ShouldBeFalse();

        static ListId the_list_id;
        static bool result;
    }
}