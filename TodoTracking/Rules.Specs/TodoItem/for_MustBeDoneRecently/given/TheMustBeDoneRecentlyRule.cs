using Dolittle.ReadModels;
using Machine.Specifications;
using NSubstitute;
using Read.TodoItem;
using Rules.TodoItem;

namespace Rules.Specs.TodoItem.for_MustBeDoneRecently.given
{
    [Subject(typeof(MustBeDoneRecently))]
    public class TheMustBeDoneRecentlyRule
    {
        Establish the_rule = () =>
        {
            _repository = Substitute.For<IReadModelRepositoryFor<TaskCompletions>>();
            _rule = new MustBeDoneRecently(_repository);
        };

        protected static MustBeDoneRecently _rule;
        protected static IReadModelRepositoryFor<TaskCompletions> _repository;
    }
}