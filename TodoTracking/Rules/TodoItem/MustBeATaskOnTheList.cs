using System.Linq;
using Dolittle.ReadModels;
using Dolittle.Rules;
using Read.TodoItem;

namespace Rules.TodoItem
{
    public class MustBeATaskOnTheList
    : IRuleImplementationFor<Domain.TodoItem.MustBeATaskOnTheList>
    {
        private IReadModelRepositoryFor<TaskList> _repository;

        public MustBeATaskOnTheList(IReadModelRepositoryFor<TaskList> repository)
        {
            _repository = repository;
        }

        public Domain.TodoItem.MustBeATaskOnTheList Rule => 
            (list, text) => 
            {
                var stored_list = _repository.GetById(list);

                return stored_list
                    ?.Tasks
                    .Any(task => task.Text == text)
                    ?? false;
            };
    }
}
