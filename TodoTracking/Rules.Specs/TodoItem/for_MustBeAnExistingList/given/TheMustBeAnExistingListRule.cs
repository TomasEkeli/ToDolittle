using Dolittle.ReadModels;
using Machine.Specifications;
using NSubstitute;
using Read.TodoItem;
using Rules.TodoItem;

namespace Rules.Specs.TodoItem.for_MustBeAnExistingList.given
{
    [Subject(typeof(MustBeAnExistingList))]
    public class TheMustBeAnExistingListRule
    {
        Establish that_the_rule_exists = () =>
        {
            _repository = Substitute.For<IReadModelRepositoryFor<TaskList>>();
            _rule = new MustBeAnExistingList(_repository);
        };
    
        protected static MustBeAnExistingList _rule;
        protected static IReadModelRepositoryFor<TaskList> _repository;
    }
}