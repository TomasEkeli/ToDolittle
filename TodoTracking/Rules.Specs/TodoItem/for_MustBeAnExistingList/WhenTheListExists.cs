using System;
using Concepts.TodoItem;
using Machine.Specifications;
using NSubstitute;
using Rules.TodoItem;

namespace Rules.Specs.TodoItem.for_MustBeAnExistingList
{
    [Subject(typeof(MustBeAnExistingList))]
    public class WhenTheListExists : given.TheMustBeAnExistingListRule
    {
        Establish that_the_rule_lists_exist = () =>
        {
            the_list_id = Guid.NewGuid();
            Read.TodoItem.TaskList a_read_model = new Read.TodoItem.TaskList
            {
                Id = the_list_id
            };

            _repository
                .GetById(the_list_id)
                .Returns(a_read_model);
        };
    
        Because checking_the_rule = () =>
            result = _rule.Rule(the_list_id);
    
        It is_not_broken = () =>
            result.ShouldBeTrue();

        static ListId the_list_id;
        private static bool result;
    }
}