using Dolittle.ReadModels;
using Dolittle.Rules;
using Read.TodoItem;

namespace Rules.TodoItem
{
    public class MustBeAnExistingList
    : IRuleImplementationFor<Domain.TodoItem.MustBeAnExistingList>
    {
        private IReadModelRepositoryFor<TaskList> _repository;

        public MustBeAnExistingList(IReadModelRepositoryFor<TaskList> repository)
        {
            _repository = repository;
        }

        public Domain.TodoItem.MustBeAnExistingList Rule => 
            (list) => 
            {
                return _repository.GetById(list) != null;
            };
    }
}
