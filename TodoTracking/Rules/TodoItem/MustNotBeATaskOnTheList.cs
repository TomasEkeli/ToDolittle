using System.Linq;
using Dolittle.ReadModels;
using Dolittle.Rules;
using Read.TodoItem;

namespace Rules.TodoItem
{
    public class MustNotBeATaskOnTheList
    : IRuleImplementationFor<Domain.TodoItem.MustNotBeATaskOnTheList>
    {
        private IReadModelRepositoryFor<TaskList> _repository;

        public MustNotBeATaskOnTheList(IReadModelRepositoryFor<TaskList> repository)
        {
            _repository = repository;
        }

        public Domain.TodoItem.MustNotBeATaskOnTheList Rule => 
            (list, text) => 
            {
                var stored_list = _repository.GetById(list);
                if (stored_list == null)
                {
                    return true;
                }

                return stored_list
                    ?.Tasks
                    .All(task => task.Text != text)
                    ?? false;
            };
    }
}
